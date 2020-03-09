using System;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Xamarin.Forms;

namespace EmulatorBug.Droid
{
    /// <summary>
    /// Adapted from https://byteloom.marek-mierzwa.com/mobile/2018/05/26/detecting-on-screen-keyboard-toggle.html
    /// </summary>
    public class KeyboardNotificationProvider
    {
        private GlobalLayoutListener _globalLayoutListener;

        public void StartNotifying()
        {
            if (_globalLayoutListener == null)
            {
                _globalLayoutListener = new GlobalLayoutListener();
                ActivityProvider.RootContentView.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);
            }
        }

        public void StopNotifying()
        {
            ActivityProvider.RootContentView.ViewTreeObserver.RemoveOnGlobalLayoutListener(_globalLayoutListener);
        }
    }

    internal class GlobalLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        /// <summary>
        /// https://byteloom.marek-mierzwa.com/mobile/2018/05/26/detecting-on-screen-keyboard-toggle.html
        /// https://www.codeproject.com/Articles/1172935/Detecting-Software-Keyboard-Events-in-Xamarin-Andr
        /// </summary>
        private static InputMethodManager _inputManager;

        private bool IsShowing;

        public GlobalLayoutListener()
        {
            _inputManager = ObtainInputManager();
        }

        public void OnGlobalLayout()
        {
            if (_inputManager.Handle == IntPtr.Zero)
                _inputManager = ObtainInputManager();

            //BUG: On an emulator, once _inputManager.IsAcceptingText becomes true, it never becomes false again.

            if (_inputManager.IsAcceptingText)
                SendKeyboardShownNotification();
            else
                SendKeyboardHiddenNotification();
        }

        public void SendKeyboardHiddenNotification()
        {
            IsShowing = false;
            MessagingCenter.Send<object>(this, "KeyboardHidden");
        }
        public void SendKeyboardShownNotification()
        {
            if (!IsShowing)
            {
                IsShowing = true;
                MessagingCenter.Send<object>(this, "KeyboardShown");
            }
        }

        private static InputMethodManager ObtainInputManager()
        {
            return (InputMethodManager)ActivityProvider.CurrentActivity.GetSystemService(Context.InputMethodService);
        }
    }
}