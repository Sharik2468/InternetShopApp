#pragma checksum "..\..\..\..\..\View\Windows\AddProductWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0986E12F9AD73E8E5CBFF5D779D62E2A16AB20BE"
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


namespace PL.View.Windows {
    
    
    /// <summary>
    /// AddProductWindow
    /// </summary>
    public partial class AddProductWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MarketPrice;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PurchasePrice;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ManufDate;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BestDate;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/PL;component/view/windows/addproductwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
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
            this.ProductName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.MarketPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PurchasePrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ManufDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.BestDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CategoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.AddProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            
            #line 165 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Main_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 171 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 177 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Basket_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 183 "..\..\..\..\..\View\Windows\AddProductWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

