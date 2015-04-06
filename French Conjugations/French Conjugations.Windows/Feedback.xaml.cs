using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace French_Conjugations
{
    public sealed partial class Feedback : UserControl
    {
        public Feedback()
        {
            this.InitializeComponent();
        }

        public async void sendMail()
        {
            string Subject;
            if (bug.IsChecked.Value)
            {
                Subject = "Bug Report";
            }
            else if (suggest.IsChecked.Value)
            {
                Subject = "Feature Suggestion";
            }
            else
            {
                Subject = "Other Feedback";
            }

            var mailto = new Uri("mailto:thomas@mtnsoftware.net?subject=" + Subject + "&body=" + message.Text);
            await Windows.System.Launcher.LaunchUriAsync(mailto);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            sendMail();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
