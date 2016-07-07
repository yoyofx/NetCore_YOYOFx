##   YOYOFx框架
YOYOFx是支持Owin协议的MVC框架，基于Dotnet Core 1.0构建。

YOYOFx基于NETStandard1.6和NET451编译，完美支持在Core和full framework(如.net framework 4.5x或mono 4.x)上的运行。

YOYOFx集成了dotnet core上第一款验证码组件。

特性：
YOYOFx的Mvc是基于Owin跑在Core的Web框架 , YOYOFx并没有基于Asp.Net Core MVC进行开发，而选择了使用Owin协议自己来封装Http协议的方式。

### 跨平台特性：
*   .NET framework 4.5x和Mono4.x上直接SelfHost或使用Tinyfox跨平台运行;
*   .NET Core 1.0 RTM 实现跨平台运行； 
*   使用Tinyfox独立版，可支持绿色部署，不需要安装Mono和Framework。
*   通过dotnet publish将Core版本进行打包后，可支持绿色部署，不需要运行时。

### Owin与Core
YOYOFx的Http实现都是基于Owin协议的，并提供两个独立版本NETSTANDRD1.x和NET45x版本。

###目前完成：
1.  封装Owin协议的HttpContext（IOwinContext），包括Request、Response、Http Headers、Cookie等；
2.  路由机制，通过添加自定义路由表为框架添加处理事件；
3.  基于IOwinContext的MVC框架，支持多语言扩展；支持Session和自定义的Action拦截器；
4.  可替换的视图引擎，目前实现Razor视图引擎，加入了缓存机制；
5.  已移植到dotnet core 1.0 RTM版本


###接下来的工作：
1.  将项目的目录结构整合到dotnet core的项目文件中。    (已完成)
2.  完成框架整体的DI，将框架级依赖对象全部通过依赖注入的方式构建和对象创建工厂；首先完成Controller的创建工厂。 (已完成)
3.  完善路由系统                                        (进行中)
    * 支持方法特性[HttpGet] [HttpPost] 等定义路由。
    * 支持自定义路由路径。
    * 支持为路由规则指定特定的Handler处理函数。
