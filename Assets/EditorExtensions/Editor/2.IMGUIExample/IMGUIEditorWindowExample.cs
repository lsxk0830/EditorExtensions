using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIEditorWindowExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.IMGUIEditorWindowExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWindowExample>().Show();
        }

        enum APIMode
        {
            GUILayout,
            GUI
        }

        enum PageId
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color
        }

        private APIMode mCurrentAPIMode = APIMode.GUILayout;

        private PageId mCurrentPageId;

        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();
        private void OnGUI()
        {
            mCurrentAPIMode = (APIMode)GUILayout.Toolbar((int)mCurrentAPIMode, Enum.GetNames(typeof(APIMode)));
            mCurrentPageId = (PageId)GUILayout.Toolbar((int)mCurrentPageId,Enum.GetNames(typeof(PageId)));

            if (mCurrentPageId == PageId.Basic)
            {
                Basic();
            }
            else if (mCurrentPageId == PageId.Enabled)
            {
                Enabled();
            }
            else if (mCurrentPageId == PageId.Rotate)
            {
                Rotate();
            }
            else if(mCurrentPageId == PageId.Scale)
            {
                Scale();
            }
            else if (mCurrentPageId == PageId.Color)
            {
                Color();
            }
        }

        #region Enable

        private bool mEnableInteractive = true;

        void Enabled()
        {
            mEnableInteractive = GUILayout.Toggle(mEnableInteractive,"是否可交互");
            // 将该值设置为 false 可禁用所有 GUI 交互
            if (GUI.enabled != mEnableInteractive)
            {
                GUI.enabled = mEnableInteractive;
            }
            Basic();
        }

        #endregion

        #region Rotate

        private bool OpenRotateEffect = false;

        void Rotate()
        {
            OpenRotateEffect = GUILayout.Toggle(OpenRotateEffect, "旋转效果");
            if (OpenRotateEffect)
            {// 帮助函数来围绕一个点旋转GUI
                GUIUtility.RotateAroundPivot(45,Vector2.one*200);
            }
            Basic();
        }

        #endregion

        #region Scale 

        private bool OpenScaleEffect = false;
        void Scale()
        {
            OpenScaleEffect = GUILayout.Toggle(OpenScaleEffect, "缩放效果");

            if (OpenScaleEffect) // 帮助函数来围绕一个点缩放GUI。
                GUIUtility.ScaleAroundPivot(Vector2.one*0.5f,Vector2.one*200);

            Basic();
        }

        #endregion

        #region Basic

        void Basic()
        {
            if (mCurrentAPIMode == APIMode.GUILayout)
                mGUILayoutAPI.Draw();
            else if(mCurrentAPIMode == APIMode.GUI)
                mGUIAPI.Draw();
        }

        #endregion

        #region Color

        private bool mOpenColorEffect= false;

        void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "变换颜色");

            if (mOpenColorEffect)
                GUI.color = UnityEngine.Color.yellow;

            Basic();
        }

        #endregion
    }
}

