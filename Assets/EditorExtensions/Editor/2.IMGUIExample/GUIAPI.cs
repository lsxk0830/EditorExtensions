using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI 
    {
        private Rect mLabelRect = new Rect(20,60,200,20);
        private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(20, 120, 200, 100);

        private string mTextFiledValue;
        private string mTextAreaValue;
        public void Draw()
        {
            GUI.Label(mLabelRect,"Label:Hello GUI API");
            mTextFiledValue = GUI.TextField(mTextFieldRect,mTextFiledValue);
            mTextAreaValue = GUI.TextArea(mTextAreaRect,mTextAreaValue);
        }
    }
}