using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeachBody_Workout_Tracker
{
    public class AutoFocusTextBox : TextBox
    {
        public AutoFocusTextBox()
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
        }
    }
}
