using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EmulatorBug
{
    [Preserve(AllMembers = true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM();

            MessagingCenter.Subscribe<object>(this, "KeyboardShown", OnKeyboardShownNotification);
            MessagingCenter.Subscribe<object>(this, "KeyboardHidden", OnKeyboardHiddenNotification);
        }

        private void OnKeyboardShownNotification(object sender)
        {
            ((MainPageVM)BindingContext).KeyboardStatus = "Keyboard Shown!";
        }

        private void OnKeyboardHiddenNotification(object sender)
        {
            ((MainPageVM)BindingContext).KeyboardStatus = "Keyboard Hidden!";
        }
    }
}
