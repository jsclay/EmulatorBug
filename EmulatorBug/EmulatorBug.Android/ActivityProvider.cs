using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EmulatorBug.Droid
{
    /// <summary>
    /// Taken from https://byteloom.marek-mierzwa.com/mobile/2018/05/26/detecting-on-screen-keyboard-toggle.html
    /// </summary>
    public class ActivityProvider
    {
        public static Activity CurrentActivity { get; set; }
        public static View RootContentView
            => CurrentActivity.FindViewById(Android.Resource.Id.Content);
    }
}