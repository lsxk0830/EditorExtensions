using Unity.VisualScripting;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect mLabelRect = new Rect(20, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(20, 120, 200, 100);
        private Rect mPassworddFileRect = new Rect(20, 240, 200, 20);
        private Rect mButtonRect = new Rect(20, 270, 200, 20);
        private Rect mRepeatButtonRect = new Rect(20, 300, 200, 20);
        private Rect mToggleRect = new Rect(20, 330, 200, 20);
        private Rect mToolbarRect = new Rect(20, 360, 400, 20);
        private Rect mBoxRect = new Rect(20, 400, 100, 100);
        private Rect mHorizontalSliderRect = new Rect(20, 500, 100, 20);
        private Rect mVerticalSliderRect = new Rect(20, 530, 20, 100);
        private Rect mGroupRect = new Rect(20, 630, 100, 20);
        private Rect mWindowRect = new Rect(20, 660, 100, 100);

        private string mTextFiledValue;
        private string mTextAreaValue;
        private string mPassworddFileValue = string.Empty;
        private bool mToggleValue;
        private int mToolbarIndex;
        private float mSliderValue;
        private Vector2 mScrollPos;

        public void Draw()
        {
            GUI.BeginScrollView(new Rect(20, 0, 400, 500), mScrollPos, new Rect(0, 0, 400, 500));
            {
                GUI.Label(mLabelRect, "Label:Hello GUI API");

                mTextFiledValue = GUI.TextField(mTextFieldRect, mTextFiledValue);

                mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);

                mPassworddFileValue = GUI.PasswordField(mPassworddFileRect, mPassworddFileValue, '$');

                if (GUI.Button(mButtonRect, "Button"))
                {
                    Debug.Log("Button Click");
                }

                if (GUI.RepeatButton(mRepeatButtonRect, "RepeatButton"))
                {
                    Debug.Log("RepeatButton Click");
                }

                mToggleValue = GUI.Toggle(mToggleRect, mToggleValue, "Toggle");

                mToolbarIndex = GUI.Toolbar(mToolbarRect, mToolbarIndex, new string[] { "1", "3", "5", "7", "9" });

                GUI.Box(mBoxRect, "Box Test");
            }
            GUI.EndScrollView();

            mSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mSliderValue, 0, 100);
            mSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mSliderValue, 0, 100);

            GUI.BeginGroup(mGroupRect, "Group");
            {
            }
            GUI.EndGroup();

            GUI.Window(10000, mWindowRect, mBoxRect =>
            {
            }, "窗口");
        }
    }
}