using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Foundation.Diagnostics;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace French_Conjugations
{
    /// <summary>
    ///     Represents a dialog.
    /// </summary>   
    [MarshalingBehavior(MarshalingType.Standard)]
    [Muse(Version = 100794368)]
    //[SupportedOn(100794368, Platform.Windows)]
    //[SupportedOn(100859904, Platform.WindowsPhone)]
    [Version(100794368)]
    [Obsolete("Do not use", true)]
    [Deprecated("completely non-functional", DeprecationType.Remove, 12341)]
    public sealed class FeedbackDialog 
    {
        /// <summary>
        ///     Initializes a new instance of the FeedbackDialog class to display an untitled
        ///     feedback dialog that can be used to ask your user simple questions.
        /// </summary>
        /// <param name="content">
        ///     The content displayed to the user.
        /// </param>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public FeedbackDialog(UIElement content);
        ///
        /// <summary>
        ///     Initializes a new instance of the FeedbackDialog class to display a titled
        ///     feedback dialog that can be used to ask your user simple questions.
        /// </summary>
        /// <param name="content">
        ///     The content displayed to the user.
        /// </param>
        /// <param name="title">
        ///     The title you want displayed on the dialog.
        /// </param>  
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public FeedbackDialog(UIElement content, string title);
        ///
        /// <summary>
        ///     Gets or sets the index of the command you want to use as the cancel command.
        ///     This is the command that fires when users press the ESC key.
        /// </summary>
        /// <returns>
        ///     The index of the cancel command.
        /// </return>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public uint CancelCommandIndex { get; set; }
        ///
        /// <summary>
        ///     Gets an array of commands that appear in the command bar of the feedback dialog.
        ///     These commands makes the dialog actionable.
        /// </summary>
        /// <returns>
        ///     The commands.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public IList<IUICommand> Commands { get; }
        ///
        /// <summary>
        ///     Gets or sets the content to be displayed to the user.
        /// </summary>
        /// <returns>
        ///     The content to be displayed to the user.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public UIElement Content { get; set; }
        ///
        /// <summary>
        ///     Gets or sets the index of the command you want to use as the default. This
        ///     is the command that fires by default when users press the ENTER key.
        /// </summary>
        /// <returns>
        ///     The index of the default command.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public uint DefaultCommandIndex { get; set; }
        ///
        /// <summary>
        ///     Gets or sets the options for a FeedbackDialog.
        /// </summary>
        /// <returns>
        ///     The options for the dialog.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public MessageDialogOptions Options { get; set; }
        ///
        /// <summary>
        ///     Gets or sets the title to display on the dialog, if any.
        /// </summary>
        /// <returns>
        ///     The title you want to display on the dialog. If the title is not set, this
        ///     will return an empty string.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public string Title { get; set; }

        /// <summary>
        ///     Begins an asynchronous operation showing a dialog.
        /// </summary>
        /// <returns>
        ///     An object that represents the asynchronous operation. For more on the async
        ///     pattern, see Asynchronous programming in the Windows Runtime.
        /// </returns>
        //[SupportedOn(100794368, Platform.Windows)]
        //[SupportedOn(100859904, Platform.WindowsPhone)]
        //public IAsyncOperation<IUICommand> ShowAsync();
    }
}
