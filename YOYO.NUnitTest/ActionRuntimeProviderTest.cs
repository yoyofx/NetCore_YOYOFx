using System;
using NUnit.Framework;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.Text;
using YOYO.ActionRuntime.Python;
using YOYO.Owin;

namespace YOYO.NUnitTest
{

	[TestFixture]
	public class ActionRuntimeProviderTest
	{
		[Test]
		public void TestPythonRunntimeProvider ()
		{
//            PythonRuntime runtime = new PythonRuntime();
//            runtime.AddController("pythontest.py");
//
//           var controller = runtime.GetController("pythontest");
//      
//
//            IOwinRequest request = new Mock.MockOwinRequest("/api/p-mycontroller/add/1/2/3/4", "get");
//
//            dynamic result = controller.ActionInvoke("test1", request);
//            //var engine = IronPython.Hosting.Python.CreateEngine();
			//var scriptSource = engine.CreateScriptSourceFromFile("pythontest.py", Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			//var compileCode = scriptSource.Compile();
			//var scope = engine.CreateScope();
			//compileCode.Execute(scope);

			//dynamic func = scope.GetVariable("test1");

			//dynamic result = func("maxzhang");

		}

		[Test]
		public void TestDirWatcher ()
		{
			string path = "/home/peng/test";

			if (!System.IO.Directory.Exists (path))
				System.IO.Directory.CreateDirectory (path);


			DirectoryWatcher watcher = new DirectoryWatcher ("/home/peng/test","*.py");
			watcher.OnFileChanged += (sender, e) => {
				switch (e.FileInfo.status) {
				case YOYO.ActionRuntime.Python.Status.Added_Modified:			
					Assert.AreEqual(e.FileInfo.FileName, "1.py");
					break;
				case YOYO.ActionRuntime.Python.Status.None:
					Assert.AreEqual(e.FileInfo.FileName, "1.py");
					break;
				case YOYO.ActionRuntime.Python.Status.Removed:
					Assert.AreEqual(e.FileInfo.FileName, "1.py");
					break;
				default:
					break;
				}
			};

			watcher.Start ();

			System.IO.File.WriteAllText (System.IO.Path.Combine(path, "1.py"), "test py file.");

			System.Threading.Thread.Sleep (8000);

			System.IO.File.Delete (System.IO.Path.Combine(path, "1.py"));

			System.Threading.Thread.Sleep (8000);

			watcher.Stop ();

		}
	}
}

