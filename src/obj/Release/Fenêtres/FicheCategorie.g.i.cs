﻿#pragma checksum "..\..\..\Fenêtres\FicheCategorie.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "306690B004D4CE9BC082ED6348BDD3F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using Videotheque.Fenêtres;


namespace Videotheque.Fenêtres {
    
    
    /// <summary>
    /// FicheCategorie
    /// </summary>
    public partial class FicheCategorie : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LAB_Title;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LAB_Subtitle;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LAB_Nom;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Nom;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Valider;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Fenêtres\FicheCategorie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Annuler;
        
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
            System.Uri resourceLocater = new System.Uri("/Videotheque;component/fen%c3%aatres/fichecategorie.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Fenêtres\FicheCategorie.xaml"
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
            
            #line 9 "..\..\..\Fenêtres\FicheCategorie.xaml"
            ((Videotheque.Fenêtres.FicheCategorie)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LAB_Title = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LAB_Subtitle = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LAB_Nom = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TB_Nom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.BTN_Valider = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Fenêtres\FicheCategorie.xaml"
            this.BTN_Valider.Click += new System.Windows.RoutedEventHandler(this.BTN_Valider_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BTN_Annuler = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Fenêtres\FicheCategorie.xaml"
            this.BTN_Annuler.Click += new System.Windows.RoutedEventHandler(this.BTN_Annuler_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

