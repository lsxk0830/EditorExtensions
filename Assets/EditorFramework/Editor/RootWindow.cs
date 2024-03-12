using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        private static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private IEnumerable<Type> mEditorWindowTypes;

        private void OnEnable()
        {
            var editorWindowType = typeof(EditorWindow);
            //var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

            #region 注释

            // AppDomain : 表示应用程序域
            // AppDomain.CurrentDomain : 获取当前 Thread 的当前应用程序域
            // AppDomain.GetAssemblies() : 获取已加载到此应用程序域的执行上下文中的程序集
            // Type.IsSubclassOf(Type) : 确定当前 Type 是否派生自指定的 Type

            #endregion 注释

            mEditorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType))
                .Where(type => type.GetCustomAttribute<CustomEditorWindowAttribute>() != null);
        }

        private void OnGUI()
        {
            foreach (var editorWindowType in mEditorWindowTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(editorWindowType.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(80)))
                    {
                        GetWindow(editorWindowType).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}