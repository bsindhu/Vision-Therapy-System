﻿

#pragma checksum "C:\Users\sribo\Desktop\sindhu documents\Project Version\Version3\EYE\EYE\EYE\PatientList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14E7202321456BCBBB5ED580F3B73AE6"
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
    partial class PatientList : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 25 "..\..\PatientList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoHome_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 26 "..\..\PatientList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Add_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 75 "..\..\PatientList.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.itemGridView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 60 "..\..\PatientList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.backButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


