using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Input;
using Windows.ApplicationModel.Email;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace French_Conjugations
{
    public sealed partial class EmailDialog : ContentDialog
    {
        public EmailDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
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
            EmailMessage emailMsg = new EmailMessage();
            emailMsg.Subject = Subject;
            emailMsg.Body = message.Text;
            emailMsg.To.Add(new EmailRecipient("thomas@mtnsoftware.net", "Thomas Maloney"));
            
            EmailManager.ShowComposeNewEmailAsync(emailMsg);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
    }
}
