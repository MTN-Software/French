﻿

#pragma checksum "C:\Users\Thomas\Source\Repos\French\French Conjugations\French Conjugations.Windows\Feedback.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A409A0F347296A5E329812F4CCAFB49E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace French_Conjugations
{
    partial class Feedback : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 33 "..\..\Feedback.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSend_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 34 "..\..\Feedback.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnCancle_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


