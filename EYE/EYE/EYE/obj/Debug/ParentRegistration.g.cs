﻿

#pragma checksum "C:\Users\sribo\Desktop\sindhu documents\Project Version\Version3\EYE\EYE\EYE\ParentRegistration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3FCEFB70D9FC5962A4A80107262C60D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EYE
{
    partial class ParentRegistration : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 79 "..\..\ParentRegistration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.registerButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 69 "..\..\ParentRegistration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ComboBox_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 29 "..\..\ParentRegistration.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LoginButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


