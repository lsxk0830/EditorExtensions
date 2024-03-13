using UnityEditor;
using UnityEditor.AnimatedValues;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup mBuildTargetGroupValue;
        private AnimBool mAnimBool = new AnimBool(false);
        private bool mFoldoutFroup = false;
        private bool mGroupBalue = false;
        private bool mToggleValue1 = false; private bool mToggleValue2 = false; private bool mToggleValue3 = true;

        public void Draw()
        {
            mAnimBool.target = EditorGUILayout.ToggleLeft("Open Fade Group", mAnimBool.target);

            mFoldoutFroup = EditorGUILayout.BeginFoldoutHeaderGroup(mFoldoutFroup, "Foldout");
            if (mFoldoutFroup)
            {
                EditorGUILayout.BeginFadeGroup(mAnimBool.faded);
                if (mAnimBool.target)
                {
                    mBuildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();
                    EditorGUILayout.EndBuildTargetSelectionGrouping();
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            mGroupBalue = EditorGUILayout.BeginToggleGroup("全部设置", mGroupBalue);
            {
                mToggleValue1 = EditorGUILayout.Toggle(mToggleValue1);
                mToggleValue2 = EditorGUILayout.Toggle(mToggleValue2);
                mToggleValue3 = EditorGUILayout.Toggle(mToggleValue3);
            }
            EditorGUILayout.EndToggleGroup();
        }
    }
}