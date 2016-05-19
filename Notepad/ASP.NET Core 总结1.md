### buildOptions:  
#### 编译设置
   1. compile : 文件编译，是一个数组，确定一组要编译的文件进行定义， **.cs （默认） 表示 包含子目录下的所有.cs文件，如果要链接共用的代码进行编译的话
可以在这个地方设置。

   2. defines : 编译变量的定义，用于条件编译，如多平台判断。

   3. frameworks :用于定义平台（要编译平台集体）和定义某个平台的特定依赖。    
        Dotnet Core与DNX在R2这个版本上进行了合并，合并之后以前的众多平台版本得到了统一；   
        (1) netcoreapp1.0 平台，作为dotnet core平台上创建应用程序的基础库，统一了服务端应用程序的开发平台。
            合并了DNX Core(ASP.NET 5)平台，新版本中Dotnet也对程序入口（Program.cs）进行了统一，，对所有应用程序提供统一的工具链进行支持；
            如ASP.NET Core Web程序和Console（.NET Core）程序都可以使用 dotnet run 进行运行。  
        (2) netstandard1.5平台，作为基础组件库，统一了库的开发平台。netcoreapp和netstandard都属于dotnet core的一部分。
        (3) NET4xy (NET451、NET452、NET461等)，统一了Full Dotnet Framework的开发平台。
        (4) MONO? ,在之前的版本中Mono可以作为DNX的CLR版本之一，进行平台开发，目前MS好像没有提到过它了。可能在新的 DNVM（Dotnet的版本管理器）
            开发完成后，可以对所有的CLR进行管理吧，那时候可能有MONO吧。。。


#### 总结：
 >新的项目文件 project.json 主要用于统一管理dotnet的发布、编译、平台、程序集依赖等。