using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class UndoExample
    {
        [MenuItem("EditorExtensions/07.Undo/Create Obj")]
        private static void CreateObj()
        {
            var newObj = new GameObject("Undo");
            Undo.RegisterCreatedObjectUndo(newObj, "CreateObj");
        }

        [MenuItem("EditorExtensions/07.Undo/Move Obj")]
        private static void Move()
        {
            var trans = Selection.activeGameObject.transform;
            if (trans)
            {
                Undo.RecordObject(trans, "MoveObj");
                trans.position += Vector3.up;
            }
        }

        [MenuItem("EditorExtensions/07.Undo/AddComponent Obj")]
        private static void AddComponentObj()
        {
            var selectedObj = Selection.activeGameObject;
            if (selectedObj)
            {
                Undo.AddComponent(selectedObj, typeof(Rigidbody));
            }
        }

        [MenuItem("EditorExtensions/07.Undo/Destroy Obj")]
        private static void DestroyObj()
        {
            var selectedObj = Selection.activeGameObject;
            if (selectedObj)
            {
                Undo.DestroyObjectImmediate(selectedObj);
            }
        }

        [MenuItem("EditorExtensions/07.Undo/SetParent Obj")]
        private static void SetParentObj()
        {
            var trans = Selection.activeGameObject.transform;
            var root = Camera.main.transform;

            if (trans)
            {
                Undo.SetTransformParent(trans, root, trans.name);
            }
        }

        [MenuItem("EditorExtensions/07.Undo/AddComponent Obj", validate = true)]
        [MenuItem("EditorExtensions/07.Undo/Move Obj", validate = true)]
        [MenuItem("EditorExtensions/07.Undo/Destroy Obj", validate = true)]
        [MenuItem("EditorExtensions/07.Undo/SetParent Obj", validate = true)]
        private static bool Check()
        {
            return Selection.activeGameObject != null;
        }
    }
}