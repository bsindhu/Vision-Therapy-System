﻿

#pragma checksum "C:\Users\sribo\Desktop\sindhu documents\Project Version\Version3\EYE\EYE\EYE\RequestAppointment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D25AFB4696B9780CB1B462B279300A9F"
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
    partial class RequestAppointment : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton GoHome; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBarButton List; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox reason; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TimePicker appointmentTime; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.DatePicker appointmentDate; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox healthcareprovider; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.ComboBox patientName; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///RequestAppointment.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            GoHome = (global::Windows.UI.Xaml.Controls.AppBarButton)this.FindName("GoHome");
            List = (global::Windows.UI.Xaml.Controls.AppBarButton)this.FindName("List");
            reason = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("reason");
            appointmentTime = (global::Windows.UI.Xaml.Controls.TimePicker)this.FindName("appointmentTime");
            appointmentDate = (global::Windows.UI.Xaml.Controls.DatePicker)this.FindName("appointmentDate");
            healthcareprovider = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("healthcareprovider");
            patientName = (global::Windows.UI.Xaml.Controls.ComboBox)this.FindName("patientName");
        }
    }
}



