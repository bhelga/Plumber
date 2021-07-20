﻿#pragma checksum "..\..\..\..\Visual\MenuBar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C80FD929EE5B77D12A4C3581CDB49AF29D6FD1D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Plumber;
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


namespace Plumber {
    
    
    /// <summary>
    /// MenuBar
    /// </summary>
    public partial class MenuBar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewGameButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NewGame;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ContinueButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Continue;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoToMainMenuButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GoToMainMenu;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Exit;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Visual\MenuBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line Line1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Plumber;component/visual/menubar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Visual\MenuBar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NewGameButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.NewGame = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ContinueButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Continue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.GoToMainMenuButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.GoToMainMenu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.Exit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 32 "..\..\..\..\Visual\MenuBar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuBarContinue_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Line1 = ((System.Windows.Shapes.Line)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

