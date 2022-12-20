﻿#pragma checksum "..\..\..\..\..\View\Windows\Basket.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "734CC51F74F576B8487D94B88294434978E09891"
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
    /// Basket
    /// </summary>
    public partial class Basket : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\..\..\View\Windows\Basket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer BasketScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\View\Windows\Basket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ClientName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\View\Windows\Basket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox OrderItemListBox;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\View\Windows\Basket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OrderItemSumm;
        
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
            System.Uri resourceLocater = new System.Uri("/PL;V1.0.0.0;component/view/windows/basket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\Basket.xaml"
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
            this.BasketScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 2:
            this.ClientName = ((System.Windows.Controls.TextBlock)(target));
            
            #line 47 "..\..\..\..\..\View\Windows\Basket.xaml"
            this.ClientName.Loaded += new System.Windows.RoutedEventHandler(this.ClientName_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OrderItemListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 61 "..\..\..\..\..\View\Windows\Basket.xaml"
            this.OrderItemListBox.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ProductsListBox_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OrderItemSumm = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            
            #line 144 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 150 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 156 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Basket_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 162 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 115 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddOrderItemAmount_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 116 "..\..\..\..\..\View\Windows\Basket.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DecreaseOrderItemAmount_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

