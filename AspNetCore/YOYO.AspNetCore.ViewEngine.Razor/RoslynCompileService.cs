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
using System.Dynamic;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class RoslynCompileService : IRazorCompileService
    {

        public static Assembly viewEngine_Razor_Assembly = typeof(RoslynCompileService).GetTypeInfo().Assembly;
        private static List<MetadataReference> ApplicationReferences = GetApplicationReferences();

        public CompileResult CompileResult { private set; get; }

        public Type Compile(string compilationContent)
        {
            var assemblyName = Path.GetRandomFileName();

            var sourceText = SourceText.From(compilationContent, Encoding.UTF8);
            var syntaxTree = CSharpSyntaxTree.ParseText(
                sourceText,
                path: assemblyName,
                options: new CSharpParseOptions()
                );


            var compilation = CSharpCompilation.Create(assemblyName,
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
                    syntaxTrees: new[] { syntaxTree },
                    references: ApplicationReferences
                );

            using (var assemblyStream = new MemoryStream())
            {

                var result = compilation.Emit(
                    assemblyStream,
                    options: new EmitOptions(debugInformationFormat: DebugInformationFormat.PortablePdb));

                this.CompileResult = new CompileResult()
                {
                    Success = result.Success,
                    Errors = result.Diagnostics.Select(d => d.ToString()).ToList()
                };

                if (!result.Success)
                {
                    if (!compilation.References.Any() && !ApplicationReferences.Any())
                    {
                        throw new InvalidOperationException("project.json preserveCompilationContext");
                    }

                    return null;
                }


                var templateType = LoadTypeForAssemblyStream(assemblyStream, null);
                
                return templateType;

                
            }

        }


        protected virtual DependencyContext GetDependencyContext(Assembly assembly)
        {

            return DependencyContext.Load(assembly);
        }

        private Type LoadTypeForAssemblyStream(MemoryStream assemblyStream, MemoryStream pdbStream)
        {
            assemblyStream.Seek(0, SeekOrigin.Begin);
            Assembly assembly = null;
#if NET451
            assembly = Assembly.Load(assemblyStream.ToArray());
#else
            assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(assemblyStream);
#endif
            var type = assembly.GetExportedTypes().FirstOrDefault(a => !a.IsNested);
            return type;

        }

        private static List<MetadataReference> GetApplicationReferences()
        {
            var metadataReferences = new List<MetadataReference>();
            var assembly = Assembly.GetEntryAssembly();


            metadataReferences.Add(CreateMetadataFileReference(typeof(object).GetTypeInfo().Assembly.Location));
            metadataReferences.Add(CreateMetadataFileReference(typeof(DynamicObject).GetTypeInfo().Assembly.Location));

            metadataReferences.Add(CreateMetadataFileReference(assembly.Location));


            var referencedAssemblies = assembly.GetReferencedAssemblies();


            
            //reference razor view engine by this assembly 
            if (!referencedAssemblies.Contains(viewEngine_Razor_Assembly.GetName()))
                metadataReferences.Add(CreateMetadataFileReference(viewEngine_Razor_Assembly.Location));


            foreach (var refAssemblyName in referencedAssemblies)
            {
                var refAssembly = Assembly.Load(refAssemblyName);
                metadataReferences.Add(CreateMetadataFileReference(refAssembly.Location));

            }



            return metadataReferences;
        }

        private static MetadataReference CreateMetadataFileReference(string path)
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
