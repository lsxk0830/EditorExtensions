using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }

        public class MyDescriptionA : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述A";
        }

        [MyDescAttribute("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述B";
        }

        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }

        private IEnumerable<Type> mDescriptionTypes;
        private IEnumerable<Type> mDescriptionTypesWithAttribute;

        private void OnEnable()
        {
            mDescriptionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
            mDescriptionTypesWithAttribute = typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var type in mDescriptionTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(type.Name);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("With Class Attribute");

            foreach (var type in mDescriptionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("Box");
                {
                    GUILayout.Label(type.Name);
                    GUILayout.Label(type.GetCustomAttribute<MyDescAttribute>().Type);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}