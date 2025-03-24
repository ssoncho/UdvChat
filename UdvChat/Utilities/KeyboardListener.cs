using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;

namespace UdvChat.Utilities
{
#if ANDROID


    public class KeyboardListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        private readonly Action _onKeyboardOpened;
        private bool isOpenedNow;

        public KeyboardListener(Action onKeyboardOpened)
        {
            _onKeyboardOpened = onKeyboardOpened;
        }

        public void OnGlobalLayout()
        {
            var rect = new Android.Graphics.Rect();
            var activity = Platform.CurrentActivity;
            var rootView = activity.Window.DecorView;

            rootView.GetWindowVisibleDisplayFrame(rect);
            int screenHeight = rootView.Height;
            int keyboardHeight = screenHeight - rect.Bottom;

            if (keyboardHeight > screenHeight * 0.15 && isOpenedNow)
            {
                _onKeyboardOpened?.Invoke();
                isOpenedNow = false;
            }
            else if (keyboardHeight <= screenHeight * 0.15)
            {
                isOpenedNow = true;
            }
        }
    }
#endif
}
