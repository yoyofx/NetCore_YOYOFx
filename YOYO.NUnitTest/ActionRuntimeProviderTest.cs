using System;
using NUnit.Framework;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.Text;


namespace YOYO.NUnitTest
{

	[TestFixture]
	public class ActionRuntimeProviderTest
	{
		[Test]
		public void TestPythonRunntimeProvider()
		{

			var engine = Python.CreateEngine ();

			var scriptSource = engine.CreateScriptSourceFromFile ("pythontest.py",Encoding.UTF8,Microsoft.Scripting.SourceCodeKind.File);
			var compileCode = scriptSource.Compile ();
			var runtime = Python.CreateRuntime ();
			var scope = runtime.CreateScope ();
			compileCode.Execute (scope);

			dynamic func = scope.GetVariable ("test1");

			dynamic result = func ("maxzhang");

		}

	}
}

