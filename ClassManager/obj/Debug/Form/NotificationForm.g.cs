﻿#pragma checksum "..\..\..\Form\NotificationForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D32D5DECC69EF629CC019836DCC874EC25596032"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClassManager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClassManager {
    
    
    /// <summary>
    /// NotificationForm
    /// </summary>
    public partial class NotificationForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbType;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbType;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbiNotification;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbiImportant;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cbiFree;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDate;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbContent;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtContent;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSave;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Form\NotificationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClassManager;component/form/notificationform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Form\NotificationForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lbType = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cbType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbiNotification = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 6:
            this.cbiImportant = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.cbiFree = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.dpDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.lbContent = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.txtContent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.btSave = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Form\NotificationForm.xaml"
            this.btSave.Click += new System.Windows.RoutedEventHandler(this.btSave_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btCancel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Form\NotificationForm.xaml"
            this.btCancel.Click += new System.Windows.RoutedEventHandler(this.btCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
