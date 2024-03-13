using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EditorFramework
{
    /// <summary>
    /// 反射的扩展
    /// </summary>
    public static class TypeEx
    {
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            // AppDomain : 表示应用程序域
            // AppDomain.CurrentDomain : 获取当前 Thread 的当前应用程序域
            // AppDomain.GetAssemblies() : 获取已加载到此应用程序域的执行上下文中的程序集
            // Type.IsSubclassOf(Type) : 确定当前 Type 是否派生自指定的 Type
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith("Assembly"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(self));
        }

        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssemblies<TClassAttribute>(this Type self)
            where TClassAttribute : Attribute
        {
            return GetSubTypesInAssemblies(self)
                .Where(type => type.GetCustomAttribute<TClassAttribute>() != null);
        }
    }
}