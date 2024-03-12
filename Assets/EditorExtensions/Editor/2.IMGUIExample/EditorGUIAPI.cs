using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect mLabelRect = new Rect(10, 70, 200, 20);
        private Rect mTextFieldlRect = new Rect(10, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(10, 120, 200, 40);
        private Rect mPasswordFieldRect = new Rect(10, 170, 200, 20);
        private Rect mDropdownButtonRect = new Rect(10, 200, 200, 20);
        private Rect mLinkButtonRect = new Rect(10, 230, 200, 20);
        private Rect mToggleRect = new Rect(10, 260, 200, 20);
        private Rect mToggleLeftRect = new Rect(10, 290, 200, 20);
        private Rect mHelpBoxRect = new Rect(10, 320, 200, 20);
        private Rect mColorFieldRect = new Rect(10, 350, 200, 20);
        private Rect mBoundsFieldRect = new Rect(10, 380, 200, 20);

        private bool mDisableedGroupValue = false;
        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue;
        private bool mToggleValue = false;
        private Color mColorFieldValue;
        private Bounds mBoundsFieldValue;

        public void Draw()
        {
            mDisableedGroupValue = EditorGUILayout.Toggle("Disableed Group", mDisableedGroupValue);
            EditorGUI.BeginDisabledGroup(mDisableedGroupValue == false);
            {
                EditorGUI.LabelField(mLabelRect, "LabelField");
                mTextFieldValue = EditorGUI.TextField(mTextFieldlRect, mTextFieldValue);
                mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);
                mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue);

                if (EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("12345"), FocusType.Keyboard))
                {
                    Debug.Log("DropdownButton click");
                }
                if (EditorGUI.LinkButton(mLinkButtonRect, "LinkButton"))
                {
                    Debug.Log("LinkButton click");
                }
                mToggleValue = EditorGUI.Toggle(mToggleRect, mToggleValue);
                mToggleValue = EditorGUI.ToggleLeft(mToggleLeftRect, "ToggleLeft", mToggleValue);

                EditorGUI.HelpBox(mHelpBoxRect, "HelpBoxTest", MessageType.Error);

                mColorFieldValue = EditorGUI.ColorField(mColorFieldRect, mColorFieldValue);

                mBoundsFieldValue = EditorGUI.BoundsField(mBoundsFieldRect, mBoundsFieldValue);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}