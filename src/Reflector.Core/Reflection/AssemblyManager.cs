using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Reflector.Core.Reflection
{
    public class AssemblyManager
    {
        public List<IGrouping<string, TypeDetails>> ExtractInfo(string assemblyPath)
        {
            // Load the assembly
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            return ExtractInfo(assembly);
        }

        public List<IGrouping<string, TypeDetails>> ExtractInfo(Assembly assembly)
        {

            // List to store all information
            List<TypeDetails> assemblyDetails = new();

            // List all the types (classes, interfaces, enums, etc.)
            foreach (Type type in assembly.GetTypes())
            {
                // Ignore compiler-generated types
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

                assemblyDetails.Add(typeDetails);
            }

            // Group by namespace
            IEnumerable<IGrouping<string, TypeDetails>> namespaceGroups = assemblyDetails.GroupBy(info => info.Namespace);
            return namespaceGroups.ToList();
        }


        public List<NamespaceNode> CreateHierarchy(Assembly assembly)
        {
            var list = ExtractInfo(assembly);
            return CreateHierarchy(list);
        }

        public List<NamespaceNode> CreateHierarchy(List<IGrouping<string, TypeDetails>> groupedDetails)
        {
            var namespaces = new List<NamespaceNode>();

            foreach (var group in groupedDetails)
            {
                var namespaceNode = new NamespaceNode { Name = group.Key };

                foreach (var typeDetails in group)
                {
                    var typeNode = new TypeNode { Name = typeDetails.TypeName };
                    typeNode.MemberTypes = new();

                    // Methods
                    var methods = typeDetails.Methods.Select(m => new MemberNode
                    {
                        Name = m.Name,
                        IsPublic = m.IsPublic,
                        IsPrivate = m.IsPrivate,
                        IsStatic = m.IsStatic,
                        MemberType = "Method",
                        DataType = m.ReturnType.ToString(),
                        Parameters = m.GetParameters().Select(p => p.ToString()).ToList()
                    }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Methods", Members = methods });

                    // Properties
                    var properties = typeDetails.Properties.Select(p => new MemberNode
                    {
                        Name = p.Name,
                        IsPublic = p.GetMethod?.IsPublic ?? false,
                        IsPrivate = p.GetMethod?.IsPrivate ?? false,
                        IsStatic = p.GetMethod?.IsStatic ?? false,
                        MemberType = "Property",
                        DataType = p.PropertyType.ToString()
                    }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Properties", Members = properties });

                    // Fields
                    var fields = typeDetails.Fields.Select(f => new MemberNode
                    {
                        Name = f.Name,
                        IsPublic = f.IsPublic,
                        IsPrivate = f.IsPrivate,
                        IsStatic = f.IsStatic,
                        MemberType = "Field",
                        DataType = f.FieldType.ToString()
                    }).ToList();

                    typeNode.MemberTypes.Add(new MemberTypeIdentifier { Name = "Fields", Members = fields });

                    namespaceNode.Items.Add(typeNode);
                }

                namespaces.Add(namespaceNode);
            }

            return namespaces;
        }

        public List<MemberTypeNode> CreateHierarchyMemberTypes(List<MemberNode> items)
        {
            return items.GroupBy(node => node.MemberType)
                .Select(group => new MemberTypeNode(group.Key, group.ToList()))
                .ToList();
        }

        private bool IsCompilerGenerated(Type type)
        {
            // Check for the CompilerGenerated attribute
            return type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Any();
        }
    }
}
