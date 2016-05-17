### buildOptions:  
#### 编译设置
   1. compile : 文件编译，是一个数组，确定一组要编译的文件， **.cs 表示 包含子目录下的所有.cs文件。
   2. defines : 编译变量的定义，用于条件编译，如多平台判断。
   3. frameworks : 所包含的平台，用于定义平台（要编译平台集体）和定义某个平台的特定依赖。
       netcoreapp1.0 平台，是最新的 core平台 ， 替换之前的 DNX Core。DNX是为 ASP.NET 5 平台提供的程序集集合。 DNX包含 MVC 6的 Beta4 以前的版本。 最新的netcoreapp1.0 平台不包含ASP.NET Core 1.0和MVC 6的任何程序集，ASP.NET以后会独立发布。目前netcoreapp1.0基本等同于netstandard1.5平台。

#### 总结：
 >新的project.json意味