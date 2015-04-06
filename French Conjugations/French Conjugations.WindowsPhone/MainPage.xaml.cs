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
using Windows.Storage;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace French_Conjugations
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.isFirstRun();
            
        }

        

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            
        }

        private async Task<bool> isFirstRun()
        {
#if DEBUG
            ApplicationData.Current.LocalSettings.Values["ranBefore"] = false;
#endif
            bool ranBefore;
            try
            {
                ranBefore = ApplicationData.Current.LocalSettings.Values["ranBefore"].Equals(true);
            }
            catch (Exception)
            {
                ApplicationData.Current.LocalSettings.Values.Add("ranBefore", false);
                ranBefore = false;
            }
            
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(async () =>
            {
                if (!ranBefore)
                {
                    try
                    {
                        Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog("")
                        {
                            Title = "Hi there!",
                            Content = string.Concat("Thank you for participating in the MTN French Conjugations Beta! ",
                            "Right now it might be a little less than expected however features are subject to change. ",
                            "This would be the perfect time to submit any feedback using the built-in feedback feature."),
                            Options = Windows.UI.Popups.MessageDialogOptions.None
                        };
                        await msg.ShowAsync();
                        ApplicationData.Current.LocalSettings.Values["ranBefore"] = true;

                    }
                    catch (Exception ex)
                    {
                        Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog(ex.Message);
                        msg.ShowAsync();
                        throw ex;
                        //return false;
                    }
                }
                else
                {

                }
            }));
            return true;
        }

        /// <summary>
        /// Navigates to email feedback page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFeedback_Click(object sender, RoutedEventArgs e)
        {
            
            if (!Frame.Navigate(typeof(EmailDialog)))
            {
                EmailDialog em = new EmailDialog();
                em.ShowAsync();
                //throw new Exception("Navigation error");
            }
        }

    }
}
