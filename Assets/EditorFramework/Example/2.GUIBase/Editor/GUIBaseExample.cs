using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(2)]
    public class GUIBaseExample : EditorWindow
    {
        public class Label : GUIBase
        {
            public Label(string text)
            {
                mText = text;
            }

            private string mText;

            public override void OnGUI(Rect position)
            {
                GUILayout.Label(mText);
            }

            protected override void OnDispose()
            {
                mText = null;
            }
        }

        private Label mLabel123 = new Label("123");
        private Label mLabel456 = new Label("456");
        private Label mLabel789 = new Label("789");

        private void OnGUI()
        {
            mLabel123.OnGUI(default);
            mLabel456.OnGUI(default);
            mLabel789.OnGUI(default);
        }
    }
}