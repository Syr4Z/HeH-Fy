   M S B A M L   `   `   `  ����@  <HehFy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hehfy.FenêtresHehfy.Fenêtres  5   	   "    Hehfy.Fenêtres.FicheMusique   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Hehfy.Fenêtres     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$" HeH-Fy - Fiche de la musique��5
   	   $	��497��6.   $��691.706��6;    � 
ResizeMode$ NoResize=�6K   .��5      ]� ��. .+�5   
   � $	��Top=�6   $��56��6$   ���	#FFCCCCCC.+�5      �� ���	#FFCCCCCC$��57��6*   $	��Top=�67    J� RenderTransformOrigin$ 0.5,0.5&�6O   $��0,0,0.333,0q�6o   �� 5      -   5         ��Name$ 	LAB_Title��5      $��HeH-Fy��6'   $��Center=�68   $��0q�6\   $	��Top=�6h   ���	#FFB90600$��22(�6�   $
��Bold"�6�   ���	#00444444$��0,0,0.333,0q�6�   �� 5      -   5        $ LAB_Subtitle��5      $��Fiche de la musique��6*   $��Center=�6H   $��0q�6l   $��0,35,0.333,0q�6x   $	��Top=�6�   5      � 5   
   ���	#FF444444.+�5      �� -   5        $ LAB_Affiche��5      $��
Couverture��6)   $
��Left=�6>   $��
2, 0, 0, 0q�6Y   $��	10,10,0,0q�6n   $	��Top=�6�   ���	#FFCCCCCC$ 5.75,1&�6�   �� 5      $��1q�6   $
��Left=�6)   ���	#FFCCCCCC$	��Top=�6]   $	��194��6u   $	��149��6�   $��10,30,434,0q�6�   ._�5      �� -   5         ��Name$ IMG_Affiche��5      $4��./Hehfy;component/Ressources/Images/NoPhoto.png��6-   $��Uniform=�6e   5      �� 5      -   5         ��Name$ BTN_ModifierImage��5      $��Modifier��60   $
��Left=�6C   $��
10,229,0,0q�6^   $	��Top=�6r   $	��149��6�   6�   �� 5      -   5        $ BTN_SupprimerImage��5      $��	Supprimer��61   $
��Left=�6E   $��
10,262,0,0q�6`   $	��Top=�6t   $	��149��6�   6�   �� 5      -   5        $ 	LAB_Titre��5      $��Titre��6'   $
��Left=�67   $��
2, 0, 0, 0q�6R   $��
188,10,0,0q�6g   $	��Top=�6{   ���	#FFCCCCCC$ 5.75,1&�6�   $��29��6�   �� 5      -	   5         ��Name$ TB_Titre��5      $
��Left=�6(   $��23��6C   $��
188,30,0,0q�6O    �� TextWrapping$ NoWrap=�6c   $	��Top=�6�   $	��471��6�   ��6y   �� 	 �� Path$	 Titre�
 �� Mode$
 TwoWay=�6�   �� 5      -
   5        $ LAB_Categorie��5      $��
Catégorie��6+   $
��Left=�6?   $��
2, 0, 0, 0q�6Z   $��
188,64,0,0q�6o   $	��Top=�6�   ���	#FFCCCCCC$ 5.75,1&�6�   $��66��6�   �� 5      -   5         ��Name$ COMBO_Categorie��5      $
��Left=�60   $��
188,85,0,0q�6K   $	��Top=�6_   $	��471��6w    �� DisplayMemberPath$	 Nom��6�    �� SelectedIndex$ 0��6�   ��6�   �� *
categories+6�   �� 5       -   5        $ 
LAB_Auteur��5       $��Auteur/Compositeur��6(   $
��Left=�6E   $��
2, 0, 0, 0q�6`   $��188,118,0,0q�6u   $	��Top=�6�   ���	#FFCCCCCC$ 5.75,1&�6�   $	��120��6�   �� 5!      -   5        $ 	TB_Auteur��5!      $
��Left=�6)   $��23��6D   $��188,139,0,0q�6P   $ NoWrap=�6e   $	��Top=�6�   $	��229��6�   ��6{   �� *Realisateur+$
 TwoWay=�6�   �� 5#      -   5        $ LAB_DateSortie��5#      $!��Date de sortie (JJ/MM/AAAA)��6,   $
��Left=�6R   $��
2, 0, 0, 0q�6m   $��430,118,0,0q�6�   $	��Top=�6�   ���	#FFCCCCCC$ 5.75,1&�6�   $	��161��6�   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ DP_DateSortie��5$      $
��Left=�60   $��430,139,0,0q�6L   $	��Top=�6a   $	��229��6y   ���	#FF333333   IsTodayHighlighted .  ��6�   Z� 6�   �� 5&      -   5        $ LAB_Note��5&      $��Notes personnelles��6&   $
��Left=�6C   $��
2, 0, 0, 0q�6^   $��188,172,0,0q�6s   $	��Top=�6�   ���	#FFCCCCCC$ 5.75,1&�6�   $	��108��6�   �� 5'      -   5        $ TB_Note��5'      $
��Left=�6'   $	��147��6B   $��188,193,0,0q�6O   $	��Top=�6�   $	��471��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� AcceptsReturn . ��6d   �� *Resume+$
 TwoWay=�6�   �� 5)      -   5        $ BTN_Valider��5)      $��Valider��6*   $��Center=�6<   $��222,0,344,11q�6Y   $��Bottom=�6o   $	��104��6�   ���	#FFCCCCCC���	#FFB90600$
��Bold"�6�   ��6�   Z� 6�   �� 5*      -   5        $ BTN_Annuler��5*      $��Annuler��6*   $��Center=�6<   $��342,0,224,11q�6Y   $��Bottom=�6o   $	��104��6�   ���	#FFCCCCCC���	#FF444444$
��Bold"�6�   ��6�   Z� 6�   5,      5-      5.      