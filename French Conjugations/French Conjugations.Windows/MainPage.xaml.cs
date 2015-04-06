using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

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

            this.isFirstRun();
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
                        //todo
                        //return false;
                    }
                }
                else
                {
                    //return true;
                }
            }));
            return true;
        }

        private void mnuFeedback_Click(object sender, RoutedEventArgs e)
        {
            Feedback ctrlFeed = new Feedback();
            
            gdChild.Children.Add(ctrlFeed);
            //popupFeedback.HorizontalOffset = (Window.Current.Bounds.Width - gdChild.ActualWidth) / 2;
            //popupFeedback.VerticalOffset = (Window.Current.Bounds.Height - gdChild.ActualHeight) / 2;
            popupFeedback.IsOpen = true;
        }

        private void Popup_Loaded(object sender, RoutedEventArgs e)
        {
            popupFeedback.HorizontalOffset = (Window.Current.Bounds.Width - gdChild.ActualWidth) / 2;
            popupFeedback.VerticalOffset = (Window.Current.Bounds.Height - gdChild.ActualHeight) / 2;
        }

        private void popupFeedback_LostFocus(object sender, RoutedEventArgs e)
        {
            popupFeedback.IsOpen = false;
        }

        /*public void test()
        {
            if (!Frame.Navigate(typeof(EmailDialog)))
            {
                
                EmailDialog em = new EmailDialog();
                //em.();
                //throw new Exception("Navigation error");
            }
        }*/
    }
}
