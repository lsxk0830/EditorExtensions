using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public static class MenuItemExample
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        [MenuItem("EditorExtensions/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            Application.OpenURL("https://bilibili.com");
        }

        [MenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath")]
        static void OpenPersistenDataPath()
        {// 持久数据目录路径。
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        [MenuItem("EditorExtensions/01.Menu/04.打开策划目录")]
        static void OpenDesignerFolder()
        {
            string ApplicationdataPath = Application.dataPath;
            ApplicationdataPath = ApplicationdataPath.Replace("Assets", "Library");
            Debug.Log("Application.dataPath"+ Application.dataPath);
            Debug.Log("Application.dataPath" + ApplicationdataPath);
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }

        private static bool mOpenShortCut = false;

        [MenuItem("EditorExtensions/01.Menu/05.快捷键开关")]
        static void ToggleShortCut()
        {
            mOpenShortCut = !mOpenShortCut;
            // Menu.SetChecked :设置给定菜单的检查状态
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关", mOpenShortCut);
        }

        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c")] // _a-zA-Z-a-zA-Z
        static void HelloEditorWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor"); //调用指定路径中的菜单项
        }
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c",validate = true)] 
        static bool HelloEditorWithShortCutValidate()
        {
            return mOpenShortCut;
        }
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e")]  // % -Ctrl
        static void OpenBilibiliWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/02.Open Bilibili"); //调用指定路径中的菜单项
        }
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e",validate =true)]  
        static bool OpenBilibiliWithShortCutValidate()
        {
            return mOpenShortCut;
        }
        [MenuItem("EditorExtensions/01.Menu/08.OpenPersistentDataPath %#t")] // # -Shift
        static void OpenPersistentDataPathWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath"); //调用指定路径中的菜单项
        }
        [MenuItem("EditorExtensions/01.Menu/08.OpenPersistentDataPath %#t",validate =true)] 
        static bool OpenPersistentDataPathWithShortCutValidate()
        {
            return mOpenShortCut;
        }
        [MenuItem("EditorExtensions/01.Menu/09.打开策划目录 &r")] // & -Alt
        static void OpenDesignFolderWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/04.打开策划目录"); //调用指定路径中的菜单项
        }
        [MenuItem("EditorExtensions/01.Menu/09.打开策划目录 &r",validate =true)] 
        static bool OpenDesignFolderWithShortCutValidate()
        {
            return mOpenShortCut; 
        }

        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关", mOpenShortCut);
        }
    }

}
