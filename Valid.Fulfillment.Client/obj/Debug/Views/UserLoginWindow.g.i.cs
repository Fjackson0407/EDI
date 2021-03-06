﻿#pragma checksum "..\..\..\Views\UserLoginWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D049833E7078DF84865CB9F68915BBC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Valid.Fulfillment.Client.Views;


namespace Valid.Fulfillment.Client.Views {
    
    
    /// <summary>
    /// UserLoginWindow
    /// </summary>
    public partial class UserLoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cbox_UserName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Tbox_Password;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lbl_Error;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Login;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Logout;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\UserLoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img_Logo;
        
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
            System.Uri resourceLocater = new System.Uri("/Valid.Fulfillment.Client;component/views/userloginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserLoginWindow.xaml"
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
            this.Cbox_UserName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\Views\UserLoginWindow.xaml"
            this.Cbox_UserName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cbox_User_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Tbox_Password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 28 "..\..\..\Views\UserLoginWindow.xaml"
            this.Tbox_Password.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Tbx_Password_OnPreviewTextInput);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\Views\UserLoginWindow.xaml"
            this.Tbox_Password.KeyUp += new System.Windows.Input.KeyEventHandler(this.Tbx_Password_OnKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Lbl_Error = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Btn_Login = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Views\UserLoginWindow.xaml"
            this.Btn_Login.Click += new System.Windows.RoutedEventHandler(this.Btn_Login_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Btn_Logout = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Views\UserLoginWindow.xaml"
            this.Btn_Logout.Click += new System.Windows.RoutedEventHandler(this.Btn_Logout_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Img_Logo = ((System.Windows.Controls.Image)(target));
            
            #line 39 "..\..\..\Views\UserLoginWindow.xaml"
            this.Img_Logo.Loaded += new System.Windows.RoutedEventHandler(this.Img_Logo_OnLoaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

