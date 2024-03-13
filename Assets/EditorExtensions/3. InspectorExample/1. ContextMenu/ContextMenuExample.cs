using UnityEngine;

namespace EditorExtensions
{
    public class ContextMenuExample : MonoBehaviour
    {
        [ContextMenu("Hello ContextMenu")]
        private void HelloContextMenu()
        {
            Debug.Log("Hello ContextMenu");
        }

        [ContextMenuItem("Print Value", "HelloContextMenuItem")]
        [SerializeField]
        private string mContextMenuItemValue;

        private void HelloContextMenuItem()
        {
            Debug.Log(mContextMenuItemValue);
        }

#if UNITY_EDITOR
        private const string mFindScriptPath = "CONTEXT/MonoBehaviour/FindScript";

        [UnityEditor.MenuItem(mFindScriptPath)]
        private static void FindScript(UnityEditor.MenuCommand command)
        {
            UnityEditor.Selection.activeObject =
                UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }

        private const string mCameraScriptPath = "CONTEXT/Camera/LogSelf";

        [UnityEditor.MenuItem(mCameraScriptPath)]
        private static void LogSelf(UnityEditor.MenuCommand command)
        {
            Debug.Log(command.context);
        }

#endif
    }
}