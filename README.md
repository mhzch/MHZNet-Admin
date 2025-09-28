#### 📚系统说明

- 基于 .Net 8 、SqlSugar ORM、Vue 2.X、RBAC、前后端分离的开箱则用的企业级权限开发框架(**中后台管理系统**)
- 无业务逻辑代码入侵，适用于任何 .NET/C# 应用程序。
- MHZNet 是一个现代化的企业级后台管理系统
- 采用 DTO/VO/PO 架构模式，提供清晰的数据层次结构

#### 💒代码仓库
- GitHub: <a href="https://github.com/mhzch/MHZNet-Admin" target="_blank">https://github.com/mhzch/MHZNet-Admin</a>



#### ⚙️模块说明

| # | 模块功能                      |  项目文件                    | 说明|
|---|-------------------------------|-------------------------------|-------------------------------|
| 1 | Web 控制器 |MHZNet.Api | 接口交互层 |
| 2 | 业务接口实现 |MHZNet.Business | 业务服务接口实现 |
| 3 | 系统通用 |MHZNet.Common | 通用的工具类；扩展方法、文件、图像操作等 |
| 4 | 系统核心 |MHZNet.Core | Aop拦截、系统配置、App服务等 |
| 5 | 持久化对象 |MHZNet.PO | 数据库实体映射类 (PO模式) |
| 6 | 事件总线 |MHZNet.EventBus | 事件总线|
| 7 | 业务接口 |MHZNet.IBusiness | 业务服务接口 |
| 8 | 基础设施 |MHZNet.Infrastructure | 依赖注入、服务扩展等 |
| 9 | 仓储 |MHZNet.Repository | 数据库仓储扩展 事务等 |
| 10 | 数据传输对象 |MHZNet.DTO | 数据传输对象 (DTO模式) |
| 11 | 作业调度 |MHZNet.TaskService | 系统定时任务 |
| 12 | 视图对象 |MHZNet.VO | UI视图层对象 (VO模式) |

#### 🚀系统特性
- 使用  Async Await 异步编程
- 使用 仓储+服务+接口 搭建基础restful风格API
- 使用 SqlSugar ORM 组件, CodeFirst 模式, 封装 BaseService 数据库基础操作类
- 使用Redis与DistributedCache两种缓存并扩展实现SqlSugar二级缓存处理数据
- 使用 Autofac 依赖注入 Ioc 容器, 实现批量自动注入所有服务
- 使用 Swagger UI 自动生成 WebAPI 说明文档
- 使用 Serilog 日志组件(输出到数据库、输出到控制台、输出到文件、输出到Elasticsearch)模式
- 使用 Quartz.Net 封装任务调度中心功能
- 封装异常过滤器  实现统一记录系统异常日志
- 封装审计过滤器  实现统一记录接口请求日志
- 封装缓存拦截器  实现对业务方法结果缓存处理
- 封装事务拦截器  实现对业务方法操作数据库事务处理
- 封装系统appsettings.json配置Configs类
- 重写ASP.NET Core 鉴权AuthorizationHandler组件  实现自定义鉴权规则
- 支持多种主流数据库(MySql、SqlServer、Sqlite、Oracle、postgresql、达梦、神通数据库、华为 GaussDB)等等；
- 支持RabbitMQ、RedisMQ消息队列
- 支持 CORS 跨域配置
- 支持数据库操作 读写分离、多库、分表
- 支持多租户 ID隔离 、 库隔离
- 支持接口限流 避免恶意请求攻击
- 支持数据权限 (全部、本人、本部门、本部门及以下、自定义)
- 支持数据字典、自定义设置处理
- 支持国际化

#### ⚡快速开始

##### 环境
推荐使用 `JetBrains Rider`、`WebStorm`<br/>
或者 `Visual Studio`、`VSCode`

##### 运行

1. 下载项目，编译无误。然后启动`MHZNet.Api`
2. 系统便会自动创建数据库表并初始化相关基础数据
3. 系统默认使用`Sqlite`数据库与`DistributedCache`缓存


#### ⭐️支持项目
如果觉得框架不错，或者已经在使用了，希望你可以去 <a target="_blank" href="https://github.com/mhzch/MHZNet-Admin">Github</a> 帮我点个 ⭐ Star，这将是对我极大的鼓励与支持。

#### 🤝致谢
感谢所有为开源社区做出贡献的开发者们。

#### 💡说明
MHZNet 是一个现代化的企业级后台管理系统，采用 DTO/VO/PO 架构模式，提供清晰的数据层次结构。