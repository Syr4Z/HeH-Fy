   M S B A M L   `   `   `  ���� F  BVideotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Videotheque.FenêtresVideotheque.Fenêtres  %    Videotheque.Fenêtres.FicheFilm   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Videotheque.Fenêtres     -     � WindowStartupLocation$  CenterScreen=� � Title$&  Ma vidéothèque - Fiche du film��$	��497��$��691.706�� � 
ResizeMode$ NoResize=�.��]� ��. .+�� $	��Top=�$��56�����	#FFCCCCCC.+��� ���	#FFCCCCCC$��57��$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�$��0,0,0.333,0q��� -    ��Name$ 	LAB_Title��$��Ma Vidéothèque��$��Center=�$��0q�$	��Top=����	#FFB90600$��22(�$
��Bold"����	#00444444$��0,0,0.333,0q��� -   $ LAB_Subtitle��$��Fiche du film��$��Center=�$��0q�$��0,35,0.333,0q�$	��Top=�� ���	#FF444444.+��� -   $ LAB_Affiche��$��Affiche��$
��Left=�$��
2, 0, 0, 0q�$��	10,10,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&��� $��1q�$
��Left=����	#FFCCCCCC$	��Top=�$	��194��$	��149��$��10,30,434,0q�._��� -    ��Name$ IMG_Affiche��$:��4/Videotheque;component/Ressources/Images/NoPhoto.png��$��Uniform=��� -    ��Name$ BTN_ModifierImage��$��Modifier��$
��Left=�$��
10,229,0,0q�$	��Top=�$	��149���� -   $ BTN_SupprimerImage��$��	Supprimer��$
��Left=�$��
10,262,0,0q�$	��Top=�$	��149���� -   $ 	LAB_Titre��$��Titre��$
��Left=�$��
2, 0, 0, 0q�$��
188,10,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&�$��29���� -	    ��Name$ TB_Titre��$
��Left=�$��23��$��
188,30,0,0q� �� TextWrapping$ NoWrap=�$	��Top=�$	��471������ 	 �� Path$	 Titre�
 �� Mode$
 TwoWay=��� -
   $ LAB_Categorie��$��
Catégorie��$
��Left=�$��
2, 0, 0, 0q�$��
188,64,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&�$��66���� -    ��Name$ COMBO_Categorie��$
��Left=�$��
188,85,0,0q�$	��Top=�$	��471�� �� DisplayMemberPath$	 Nom�� �� SelectedIndex$ 0������ *
categories+�� -   $ LAB_Realisateur��$��Réalisateur��$
��Left=�$��
2, 0, 0, 0q�$��188,118,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&�$��66���� -   $ TB_Realisateur��$
��Left=�$��23��$��188,139,0,0q�$ NoWrap=�$	��Top=�$	��229������ *Realisateur+$
 TwoWay=��� -   $ LAB_DateSortie��$��Date de sortie��$
��Left=�$��
2, 0, 0, 0q�$��430,118,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&�$��83��(  "System.Windows.Controls.DatePicker  -     Name$ DP_DateSortie��$
��Left=�$��430,139,0,0q�$	��Top=�$	��229�����	#FF333333   IsTodayHighlighted .  ��Z� �� -   $ 
LAB_Resume��$��Résumé��$
��Left=�$��
2, 0, 0, 0q�$��188,172,0,0q�$	��Top=����	#FFCCCCCC$ 5.75,1&�$��48���� -   $ 	TB_Resume��$
��Left=�$	��147��$��188,193,0,0q�$	��Top=�$	��471��" �� VerticalScrollBarVisibility$
 Auto=� �� AcceptsReturn . ���� *Resume+$
 TwoWay=��� -   $ BTN_Valider��$��Valider��$��Center=�$��222,0,344,11q�$��Bottom=�$	��104�����	#FFCCCCCC���	#FFB90600$
��Bold"���Z� �� -   $ BTN_Annuler��$��Annuler��$��Center=�$��342,0,224,11q�$��Bottom=�$	��104�����	#FFCCCCCC���	#FF444444$
��Bold"���Z� 