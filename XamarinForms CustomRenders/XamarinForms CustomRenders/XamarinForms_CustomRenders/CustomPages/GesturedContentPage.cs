using System;
using Xamarin.Forms;

namespace XamarinForms_CustomRenders.CustomPages
{
    public class GesturedContentPage : ContentPage
    {
        public Action OnSwipeLeftToRight = delegate { };
        public Action OnSwipeRightToLeft = delegate { };
        public Action OnSwipeTopToBottom = delegate { };
        public Action OnSwipeBottomToTop = delegate { };
        public Action OnTap = delegate { };
        public Action OnLongTap = delegate { };

        public bool CaptureSwipeLeftToRight = false;
        public bool CaptureSwipeRightToLeft = false;
        public bool CaptureSwipeTopToBottom = false;
        public bool CaptureSwipeBottomToTop = false;
        public bool CaptureTap = false;
        public bool CaptureLongTap = false;
    }
}
