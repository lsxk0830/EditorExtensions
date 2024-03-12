using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect mLabelRect = new Rect(10, 50, 200, 20);

        private bool mDisableedGroupValue = false;
        private float mJumpHeight = 0f;

        public void Draw()
        {
            EditorGUI.LabelField(mLabelRect, "LabelField");

            mDisableedGroupValue = EditorGUILayout.Toggle("Disableed Group", mDisableedGroupValue);
            EditorGUI.BeginDisabledGroup(mDisableedGroupValue == false);
            {
                mJumpHeight = EditorGUILayout.FloatField("Jump Height", mJumpHeight);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}