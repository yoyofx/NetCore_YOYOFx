using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using System.Reflection.PortableExecutable;
using Microsoft.CodeAnalysis.Emit;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class RoslynCompileService : IRazorCompileService
    {
        public Type Compile(string compilationContent)
        {
            var assemblyName = Path.GetRandomFileName();

            var sourceText = SourceText.From(compilationContent, Encoding.UTF8);
            var syntaxTree = CSharpSyntaxTree.ParseText(
                sourceText,
                path: assemblyName,
                options: new CSharpParseOptions()
                );


            var ApplicationReferences = GetApplicationReferences();

            var compilation = CSharpCompilation.Create(assemblyName,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
                    syntaxTrees: new[] { syntaxTree },
                    references: ApplicationReferences
                );

            using (var assemblyStream = new MemoryStream())
            {
                using (var pdbStream = new MemoryStream())
                {
                    var result = compilation.Emit(
                        assemblyStream,
                        pdbStream,
                        options: new EmitOptions(debugInformationFormat: DebugInformationFormat.PortablePdb));

                    if (!result.Success)
                    {
                        if (!compilation.References.Any() && !ApplicationReferences.Any())
                        {
                            // DependencyModel had no references specified and the user did not use the
                            // preserveCompilationContext in the app's project.json.
                            throw new InvalidOperationException("project.json preserveCompilationContext");
                        }
                    }

                    assemblyStream.Seek(0, SeekOrigin.Begin);
                    pdbStream.Seek(0, SeekOrigin.Begin);
                    var assembly = LoadStream(assemblyStream, pdbStream);
                    var type = assembly.GetExportedTypes().FirstOrDefault(a => !a.IsNested);
                    return type;

                }
            }

        }


        protected virtual DependencyContext GetDependencyContext(Assembly assembly)
        {

            return DependencyContext.Load(assembly);
        }

        private Assembly LoadStream(MemoryStream assemblyStream, MemoryStream pdbStream)
        {
#if NET451
            return Assembly.Load(assemblyStream.ToArray(), pdbStream.ToArray());
#else
            return System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(assemblyStream, pdbStream);
#endif
        }

        private List<MetadataReference> GetApplicationReferences()
        {
            var metadataReferences = new List<MetadataReference>();
            var assembly = Assembly.GetEntryAssembly();

            metadataReferences.Add(CreateMetadataFileReference(typeof(object).GetTypeInfo().Assembly.Location));
            metadataReferences.Add(CreateMetadataFileReference(assembly.Location));



            var referencedAssemblies = assembly.GetReferencedAssemblies();

            foreach (var refAssemblyName in referencedAssemblies)
            {
                var refAssembly = Assembly.Load(refAssemblyName);
                metadataReferences.Add(CreateMetadataFileReference(refAssembly.Location));

            }



            return metadataReferences;
        }

        private MetadataReference CreateMetadataFileReference(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                var moduleMetadata = ModuleMetadata.CreateFromStream(stream, PEStreamOptions.PrefetchMetadata);
                var assemblyMetadata = AssemblyMetadata.Create(moduleMetadata);

                return assemblyMetadata.GetReference(filePath: path);
            }
        }

    }
}
