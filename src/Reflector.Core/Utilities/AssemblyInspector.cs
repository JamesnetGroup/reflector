using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Reflector.Core.Utilities
{
    public class AssemblyInspector
    {
        public List<AssemblyModel> LoadAssemblies()
        {
            List<AssemblyModel> assemblyModels = new();
            AssemblyGroupModel allAssembliesGroup = new("All");
            AssemblyGroupModel systemAssembliesGroup = new("Systems");

            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            while (assemblies.Any())
            {
                Assembly assembly = assemblies.First();
                assemblies.Remove(assembly);

                allAssembliesGroup.Items.Add(new AssemblyModel(assembly));

                if (assembly.FullName.Contains("System."))
                {
                    systemAssembliesGroup.Items.Add(new AssemblyModel(assembly));
                }
            }

            assemblyModels.Add(allAssembliesGroup);
            assemblyModels.Add(systemAssembliesGroup);

            return assemblyModels;
        }

        public List<IGrouping<string, TypeDetails>> GatherTypeDetails(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            return GatherTypeDetails(assembly);
        }

        public List<IGrouping<string, TypeDetails>> GatherTypeDetails(Assembly assembly)
        {
            List<TypeDetails> typeDetailsList = new();

            foreach (Type type in assembly.GetTypes())
            {
                if (IsCompilerGenerated(type))
                    continue;

                TypeDetails typeDetails = new()
                {
                    Namespace = type.Namespace ?? "Global",
                    TypeName = type.Name,
                    IsClass = type.IsClass,
                    IsPublic = type.IsPublic,
                    IsPrivate = !type.IsPublic && !type.IsNotPublic,
                    IsAbstract = type.IsAbstract,
                    IsSealed = type.IsSealed,
                    IsInterface = type.IsInterface,
                    Methods = new List<MethodInfo>(type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)),
                    Properties = new List<PropertyInfo>(type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)),
                    Fields = new List<FieldInfo>(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)),
                };

                typeDetailsList.Add(typeDetails);
            }

            IEnumerable<IGrouping<string, TypeDetails>> namespaceGroups = typeDetailsList.GroupBy(info => info.Namespace);
            return namespaceGroups.ToList();
        }

        public List<NamespaceNode> BuildTypeHierarchy(Assembly assembly)
        {
            var typeDetailsList = GatherTypeDetails(assembly);
            return BuildTypeHierarchy(typeDetailsList);
        }

        public List<NamespaceNode> BuildTypeHierarchy(List<IGrouping<string, TypeDetails>> groupedTypeDetails)
        {
            var namespaceNodes = new List<NamespaceNode>();

            foreach (var namespaceGroup in groupedTypeDetails)
            {
                var namespaceNode = new NamespaceNode { Name = namespaceGroup.Key };

                foreach (var typeDetails in namespaceGroup)
                {
                    var typeNode = new TypeNode { Name = typeDetails.TypeName };
                    typeNode.MemberTypes = new();

                    // Get all the getter and setter methods of all properties in the type
                    var propertyMethods = typeDetails.Properties
                        .SelectMany(p => new[] { p.GetMethod, p.SetMethod })
                        .Where(m => m != null)
                        .ToList();

                    // Method nodes
                    var methodNodes = typeDetails.Methods
                        .Where(m => !propertyMethods.Contains(m)) // Exclude property getters and setters
                        .Select(m => new MemberNode
                        {
                            Name = m.Name,
                            IsPublic = m.IsPublic,
                            IsPrivate = m.IsPrivate,
                            IsStatic = m.IsStatic,
                            MemberType = "Method",
                            DataType = m.ReturnType.ToString(),
                            Parameters = m.GetParameters().Select(p => p.ToString()).ToList()
                        }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Methods", Members = methodNodes });

                    // Property nodes
                    var propertyNodes = typeDetails.Properties.Select(p => new MemberNode
                    {
                        Name = p.Name,
                        IsPublic = p.GetMethod?.IsPublic ?? false,
                        IsPrivate = p.GetMethod?.IsPrivate ?? false,
                        IsStatic = p.GetMethod?.IsStatic ?? false,
                        MemberType = "Property",
                        DataType = p.PropertyType.ToString()
                    }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Properties", Members = propertyNodes });

                    // Field nodes
                    var fieldNodes = typeDetails.Fields.Select(f => new MemberNode
                    {
                        Name = f.Name,
                        IsPublic = f.IsPublic,
                        IsPrivate = f.IsPrivate,
                        IsStatic = f.IsStatic,
                        MemberType = "Field",
                        DataType = f.FieldType.ToString()
                    }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Fields", Members = fieldNodes });

                    namespaceNode.Items.Add(typeNode);
                }

                namespaceNodes.Add(namespaceNode);
            }

            return namespaceNodes;
        }

        public List<MemberTypeNode> BuildMemberTypeHierarchy(List<MemberNode> memberNodes)
        {
            return memberNodes.GroupBy(node => node.MemberType)
                .Select(group => new MemberTypeNode(group.Key, group.ToList()))
                .ToList();
        }

        private bool IsCompilerGenerated(Type type)
        {
            return type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Any();
        }
    }
}
