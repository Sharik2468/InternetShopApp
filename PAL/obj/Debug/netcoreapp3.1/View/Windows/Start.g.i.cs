﻿#pragma checksum "..\..\..\..\..\View\Windows\Start.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10EB352D97EDB963149E1E8FB89AD088B57C346C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// Start
    /// </summary>
    public partial class Start : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ProductsScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame _frame;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Appliances;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Smartphones;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Television;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Computer;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ProductsListBox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\..\View\Windows\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/PL;component/view/windows/start.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Start.xaml"
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
            
            #line 9 "..\..\..\..\..\View\Windows\Start.xaml"
            ((PAL.Windows.Start)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Page_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProductsScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 3:
            this._frame = ((System.Windows.Controls.Frame)(target));
            return;
            case 4:
            this.Appliances = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\View\Windows\Start.xaml"
            this.Appliances.Click += new System.Windows.RoutedEventHandler(this.Appliances_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Smartphones = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\..\View\Windows\Start.xaml"
            this.Smartphones.Click += new System.Windows.RoutedEventHandler(this.Smartphones_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Television = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\..\View\Windows\Start.xaml"
            this.Television.Click += new System.Windows.RoutedEventHandler(this.Television_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Computer = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\..\View\Windows\Start.xaml"
            this.Computer.Click += new System.Windows.RoutedEventHandler(this.Computer_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ProductsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 93 "..\..\..\..\..\View\Windows\Start.xaml"
            this.ProductsListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ProductsListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 105 "..\..\..\..\..\View\Windows\Start.xaml"
            this.ProductsListBox.RequestBringIntoView += new System.Windows.RequestBringIntoViewEventHandler(this.ProductsListBox_RequestBringIntoView);
            
            #line default
            #line hidden
            
            #line 106 "..\..\..\..\..\View\Windows\Start.xaml"
            this.ProductsListBox.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ProductsListBox_MouseWheel);
            
            #line default
            #line hidden
            
            #line 106 "..\..\..\..\..\View\Windows\Start.xaml"
            this.ProductsListBox.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ProductsListBox_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\..\..\..\View\Windows\Start.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.stackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            
            #line 162 "..\..\..\..\..\View\Windows\Start.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 168 "..\..\..\..\..\View\Windows\Start.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 174 "..\..\..\..\..\View\Windows\Start.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Basket_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 180 "..\..\..\..\..\View\Windows\Start.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

