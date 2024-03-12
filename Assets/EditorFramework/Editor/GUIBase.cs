using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {
        public bool mDisposed { get; private set; }
        public Rect mPosition { get; private set; }

        public virtual void OnGUI(Rect position)
        {
            mPosition = position;
        }

        public virtual void Dispose()
        {
            if (mDisposed) return;

            Dispose();
            mDisposed = true;
        }

        protected abstract void OnDispose();
    }
}