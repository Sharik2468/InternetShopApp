﻿#pragma checksum "..\..\..\..\..\View\Windows\ResultWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E1016DCFF1AE143D3A0DD099AB65BC262DA1FAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PL.View.Windows;
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


namespace PL.View.Windows {
    
    
    /// <summary>
    /// ResultWindow
    /// </summary>
    public partial class ResultWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ProductsListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/PL;component/view/windows/resultwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
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
            this.ProductsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            this.ProductsListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ProductsListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            this.ProductsListBox.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ProductsListBox_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 76 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 82 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 88 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Basket_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 94 "..\..\..\..\..\View\Windows\ResultWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
