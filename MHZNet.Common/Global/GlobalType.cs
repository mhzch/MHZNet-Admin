using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MHZNet.Common.Global;

/// <summary>
/// 程序集类型
/// </summary>
public static class GlobalType
{
    public const string ApiAssembly = "MHZNet.Api";
    public const string CoreAssembly = "MHZNet.Core";
    public const string CommonAssembly = "MHZNet.Common";
    public const string IBusinessAssembly = "MHZNet.IBusiness";
    public const string BusinessAssembly = "MHZNet.Business";
    public const string RepositoryAssembly = "MHZNet.Repository";
    public const string TaskServiceAssembly = "MHZNet.TaskService";
    public const string POAssembly = "MHZNet.PO";
    // 注释掉不存在的程序集
    // public const string EntityAssembly = "MHZNet.Entity";
    // public const string SharedModelAssembly = "MHZNet.SharedModel";
    // public const string ViewModelAssembly = "MHZNet.ViewModel";
    public const string EventBusAssembly = "MHZNet.EventBus";

    public static readonly List<Type> ApiTypes;
    public static readonly List<Type> CoreTypes;
    public static readonly List<Type> CommonTypes;
    public static readonly List<Type> IBusinessTypes;
    public static readonly List<Type> BusinessTypes;
    public static readonly List<Type> RepositoryTypes;
    public static readonly List<Type> TaskServiceTypes;
    public static readonly List<Type> POTypes;
    public static readonly List<Type> EntityTypes;
    // 注释掉不存在的程序集类型
    // public static readonly List<Type> SharedModelTypes;
    // public static readonly List<Type> ViewModelTypes;
    public static readonly List<Type> EventBusTypes;

    static GlobalType()
    {
        ApiTypes = LoadAssemblyTypes(ApiAssembly);
        CoreTypes = LoadAssemblyTypes(CoreAssembly);
        CommonTypes = LoadAssemblyTypes(CommonAssembly);
        IBusinessTypes = LoadAssemblyTypes(IBusinessAssembly);
        BusinessTypes = LoadAssemblyTypes(BusinessAssembly);
        RepositoryTypes = LoadAssemblyTypes(RepositoryAssembly);
        TaskServiceTypes = LoadAssemblyTypes(TaskServiceAssembly);
        POTypes = LoadAssemblyTypes(POAssembly);
        EntityTypes = POTypes; // 使用PO程序集中的类型作为实体类型
        // 注释掉不存在的程序集初始化
        // SharedModelTypes = LoadAssemblyTypes(SharedModelAssembly);
        // ViewModelTypes = LoadAssemblyTypes(ViewModelAssembly);
        EventBusTypes = LoadAssemblyTypes(EventBusAssembly);
    }

    private static List<Type> LoadAssemblyTypes(string dllName)
    {
        var assembly = LoadAssembly(dllName + ".dll");
        return assembly.GetTypes().Where(u => u.IsPublic).ToList();
    }

    private static Assembly LoadAssembly(string dllName)
    {
        var basePath = AppContext.BaseDirectory;
        var dllFile = Path.Combine(basePath, dllName);
        if (!File.Exists(dllFile))
        {
            throw new System.Exception($"{dllName} 文件未生成，编译项目成功后重试！");
        }

        return Assembly.LoadFrom(dllFile);
    }
}
