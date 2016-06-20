##   YOYOFx框架
YOYOFx是一个基于Dotnet Core的MVC框架,支持Owin协议。

YOYOFx基于NETStandard1.5和NET451编译，完美支持在Core和full framework(如.net framework 4.5x或mono 4.x)上的运行。

特性：
YOYOFx的Mvc是基于Owin跑在Core的Web Framework
### 跨平台特性：
*   .NET framework 4.5x和Mono4.x上直接SelfHost或使用Tinyfox跨平台运行;
*   .NET Core 1.0 RC2 实现跨平台运行； 
*   使用Tinyfox独立版，可支持绿色部署，不需要安装Mono和Framework。
*   通过dotnet publish将Core版本进行打包后，可支持绿色部署，不需要运行时。

### Owin与Core
YOYOFx的所为Http实现都是基于Owin协议的，并提供两个独立版本NETSTANDRD1.x和NET45x版本。
