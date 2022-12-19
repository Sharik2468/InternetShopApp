﻿#pragma checksum "..\..\..\..\..\View\Windows\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1B980EBB1ED62F0705FFE0E76F3DB4A7705EC1CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PAL.Windows;
using PL.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PAL.Windows {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\..\View\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrderStatusButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\View\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AddProductStackPanel;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\View\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProductButton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\..\View\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel WatchOrdersStackPanel;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\View\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WatchOrders;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PL;component/view/windows/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((PAL.Windows.Settings)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.Page_GotFocus);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((PAL.Windows.Settings)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OrderStatusButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\..\View\Windows\Settings.xaml"
            this.OrderStatusButton.Click += new System.Windows.RoutedEventHandler(this.OrderStatus_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 73 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddProductStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.AddProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\..\..\View\Windows\Settings.xaml"
            this.AddProductButton.Click += new System.Windows.RoutedEventHandler(this.AddProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WatchOrdersStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.WatchOrders = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\..\..\View\Windows\Settings.xaml"
            this.WatchOrders.Click += new System.Windows.RoutedEventHandler(this.WatchOrders_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 120 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 126 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 132 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Basket_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 138 "..\..\..\..\..\View\Windows\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

