﻿#pragma checksum "..\..\InItCode.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F07064461E29E7F6BDF161C35F19633"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
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


namespace Support_EDI {
    
    
    /// <summary>
    /// InItCode
    /// </summary>
    public partial class InItCode : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FileNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrowse;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetData;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetObject;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdBody;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl grdMain;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView tbvMain;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCode;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\InItCode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKetQua;
        
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
            System.Uri resourceLocater = new System.Uri("/Support_EDI;component/initcode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InItCode.xaml"
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
            this.FileNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\InItCode.xaml"
            this.btnBrowse.Click += new System.Windows.RoutedEventHandler(this.btnBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGetData = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\InItCode.xaml"
            this.btnGetData.Click += new System.Windows.RoutedEventHandler(this.btnGetData_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnGetObject = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\InItCode.xaml"
            this.btnGetObject.Click += new System.Windows.RoutedEventHandler(this.btnGetObject_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grdBody = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.grdMain = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 7:
            this.tbvMain = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            case 8:
            this.txtCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtKetQua = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
