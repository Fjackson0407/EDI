﻿#pragma checksum "..\..\OrderDetailWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "646CC3F2B6A031E7317111847BA2250E"
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
using Valid.Fulfillment.Client;


namespace Valid.Fulfillment.Client {
    
    
    /// <summary>
    /// OrderDetailWindow
    /// </summary>
    public partial class OrderDetailWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblk_DcId;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblk_Store;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblk_Account;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_OrderDetail;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Print;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Reprint;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\OrderDetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Valid.Fulfillment.Client;component/orderdetailwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderDetailWindow.xaml"
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
            this.tblk_DcId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tblk_Store = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.tblk_Account = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.datagrid_OrderDetail = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btn_Print = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\OrderDetailWindow.xaml"
            this.btn_Print.Click += new System.Windows.RoutedEventHandler(this.Btn_Print_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_Reprint = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\OrderDetailWindow.xaml"
            this.btn_Reprint.Click += new System.Windows.RoutedEventHandler(this.Btn_Reprint_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\OrderDetailWindow.xaml"
            this.btn_Cancel.Click += new System.Windows.RoutedEventHandler(this.Btn_Cancel_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
