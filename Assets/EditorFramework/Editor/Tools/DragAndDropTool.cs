using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public static class DragAndDropTool
    {
        public class DragInfo
        {
            public bool Dragging;
            public bool EnterArea;
            public bool Complete;
            public Object[] ObjectReferences => DragAndDrop.objectReferences;
            public string[] Paths => DragAndDrop.paths;
            public DragAndDropVisualMode VisualMode => DragAndDrop.visualMode;
            public int ActiveControlID => DragAndDrop.activeControlID;
        }

        private static DragInfo mDragInfo = new DragInfo();

        private static bool mDragging;
        private static bool mEnterArea;
        private static bool mComplete;

        public static DragInfo Drag(Event e, Rect content, DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
        {
            if (e.type == EventType.DragUpdated)
            {
                mComplete = false;
                mDragging = true;
                mEnterArea = content.Contains(e.mousePosition);
                if (mEnterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                mComplete = true;
                mDragging = false;
                mEnterArea = content.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                mComplete = true;
                mDragging = false;
                mEnterArea = content.Contains(e.mousePosition);
            }
            else
            {
                mComplete = false;
                mDragging = false;
                mEnterArea = content.Contains(e.mousePosition);
            }

            mDragInfo.Complete = mComplete && e.type == EventType.Used;
            mDragInfo.EnterArea = mEnterArea;
            mDragInfo.Dragging = mDragging;

            return mDragInfo;
        }
    }
}