﻿#pragma checksum "..\..\..\Task5Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "841A9BD2D4B0C28BE3CAFF6253F1F1DB94E3A4F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LabWork17;
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


namespace LabWork17 {
    
    
    /// <summary>
    /// Task5Window
    /// </summary>
    public partial class Task5Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox firstComboBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox secondComboBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox thirdComboBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox firstCheckBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox secondCheckBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox thirdCheckBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Task5Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid productsDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LabWork17;component/task5window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Task5Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 27 "..\..\..\Task5Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateSort);
            
            #line default
            #line hidden
            return;
            case 2:
            this.firstComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Task5Window.xaml"
            this.firstComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.thirdComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.secondComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Task5Window.xaml"
            this.secondComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.thirdComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.thirdComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\Task5Window.xaml"
            this.thirdComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.thirdComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.firstCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 49 "..\..\..\Task5Window.xaml"
            this.firstCheckBox.Click += new System.Windows.RoutedEventHandler(this.UpdateSort);
            
            #line default
            #line hidden
            return;
            case 6:
            this.secondCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 50 "..\..\..\Task5Window.xaml"
            this.secondCheckBox.Click += new System.Windows.RoutedEventHandler(this.UpdateSort);
            
            #line default
            #line hidden
            return;
            case 7:
            this.thirdCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 51 "..\..\..\Task5Window.xaml"
            this.thirdCheckBox.Click += new System.Windows.RoutedEventHandler(this.UpdateSort);
            
            #line default
            #line hidden
            return;
            case 8:
            this.productsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

