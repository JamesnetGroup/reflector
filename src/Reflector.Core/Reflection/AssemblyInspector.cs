using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reflector.Core.Reflection
{
    public class NamespaceNode
    {
        public string Name { get; set; }
        public List<TypeNode> Items { get; set; } = new List<TypeNode>();
    }

    public class TypeNode
    {
        public string Name { get; set; }
        public List<MemberNode> Items { get; set; } = new List<MemberNode>();
    }

    public class MemberNode
    {
        public string Name { get; set; }
    }

    public static class AssemblyInspector
    {
        public static List<IGrouping<string, TypeDetails>> ExtractInfo(string assemblyPath)
        {
            // Load the assembly
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            return ExtractInfo(assembly);
        }

        public static List<IGrouping<string, TypeDetails>> ExtractInfo(Assembly assembly)
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
                    IsInterface = type.IsInterface
                };

                // List all the methods for each type
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    typeDetails.Methods.Add(method.Name);
                }

                // List all the properties for each type
                foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    typeDetails.Properties.Add(prop.Name);
                }

                // List all the fields for each type
                foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    typeDetails.Fields.Add(field.Name);
                }

                assemblyDetails.Add(typeDetails);
            }

            // Group by namespace
            IEnumerable<IGrouping<string, TypeDetails>> namespaceGroups = assemblyDetails.GroupBy(info => info.Namespace);
            return namespaceGroups.ToList();
        }


        public static List<NamespaceNode> CreateHierarchy(Assembly assembly)
        {
            var list = ExtractInfo(assembly);
            return CreateHierarchy(list);
        }

        public static List<NamespaceNode> CreateHierarchy(List<IGrouping<string, TypeDetails>> groupedDetails)
        {
            var namespaces = new List<NamespaceNode>();

            foreach (var group in groupedDetails)
            {
                var namespaceNode = new NamespaceNode { Name = group.Key };

                foreach (var typeDetails in group)
                {
                    var typeNode = new TypeNode { Name = typeDetails.TypeName };
                    typeNode.Items.AddRange(typeDetails.Methods.Select(m => new MemberNode { Name = m }));
                    typeNode.Items.AddRange(typeDetails.Properties.Select(p => new MemberNode { Name = p }));
                    typeNode.Items.AddRange(typeDetails.Fields.Select(f => new MemberNode { Name = f }));

                    namespaceNode.Items.Add(typeNode);
                }

                namespaces.Add(namespaceNode);
            }

            return namespaces;
        }

        private static bool IsCompilerGenerated(Type type)
        {
            // Check for the CompilerGenerated attribute
            return type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Any();
        }
    }
}
