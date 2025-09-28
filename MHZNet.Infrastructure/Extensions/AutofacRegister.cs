using MHZNet.Business;
using MHZNet.Common.DI;
using MHZNet.Common.Global;
using MHZNet.Core;
using MHZNet.Core.Aop;
using MHZNet.Core.ConfigOptions;
using MHZNet.IBusiness;
using MHZNet.Repository.SugarHandler;
using MHZNet.Repository.UnitOfWork;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;

namespace MHZNet.Infrastructure.Extensions;

/// <summary>
/// autofac注册
/// </summary>
public class AutofacRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var options = App.GetOptions<AopOptions>();

        //事务 缓存 AOP
        var registerType = new List<Type>();
        if (options.Tran.Enabled)
        {
            builder.RegisterType<TransactionAop>();
            registerType.Add(typeof(TransactionAop));
        }

        if (options.Cache.Enabled)
        {
            builder.RegisterType<CacheAop>();
            registerType.Add(typeof(CacheAop));
        }

        builder.RegisterGeneric(typeof(SugarRepository<>)).As(typeof(ISugarRepository<>))
            .InstancePerDependency();
        builder.RegisterGeneric(typeof(BaseServices<>)).As(typeof(IBaseServices<>)).InstancePerDependency();

        //注册业务层
        builder
            .RegisterTypes(GlobalType.BusinessTypes.ToArray())
            .AsImplementedInterfaces()
            .InstancePerDependency()
            .PropertiesAutowired()
            .EnableInterfaceInterceptors()
            .InterceptedBy(registerType.ToArray());

        // 注册仓储层
        builder
            .RegisterTypes(GlobalType.RepositoryTypes
                .ToArray()) //.RegisterAssemblyTypes(GlobalData.GetRepositoryAssembly())
            .AsImplementedInterfaces()
            .PropertiesAutowired()
            .InstancePerDependency();

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .PropertiesAutowired();


        //注册控制器
        //var controllerBaseType = typeof(ControllerBase);
        //builder.RegisterAssemblyTypes(typeof(Program).Assembly)
        //    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
        //    .PropertiesAutowired();

        builder.RegisterType<DisposableContainer>()
            .As<IDisposableContainer>()
            .InstancePerLifetimeScope();
    }
}
