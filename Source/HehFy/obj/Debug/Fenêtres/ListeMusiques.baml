   M S B A M L   `   `   `  ����@  <HehFy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hehfy.FenêtresHehfy.Fenêtres  5   	   #clr-namespace:Wpf.UtilWpf.Util  5   	   #    Hehfy.Fenêtres.ListeMusiques   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Hehfy.Fenêtres     5   	   'utilclr-namespace:Wpf.Util     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$! HeH-Fy - Liste des musiques��5
   	   $	��600��6-   $	��800��6=    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #   Hehfy.Fenêtres.ListeMusiques   CMD_FicheUtilisateur   Command# Z 5      6W     5   
   -   5           CMD_ChangerUtilisateur# Z 5      6Y     5   
   -   5           CMD_Quitter# Z 5      6N     5   
   -   5           CMD_AjouterCategorie# Z 5      6W     5   
   -   5           CMD_ModifierCategorie# Z 5      6X     5   
   -   5        	   CMD_SupprimerCategorie# Z	 5      6Y     5   
   -   5        
   CMD_AjouterMusique# Z
 5      6U     5   
   -   5           CMD_ModifierMusique# Z 5      6V     5   
   -	   5           CMD_SupprimerMusique# Z 5      6W     5   
   -
   5           CMD_APropos# Z 5      6N   .��5      ]� ��. .+�5   
   o�  o� 
IsMainMenu . $	��Top=�6!   $��20��66   .@�5      m� -   5         m�Name$ MENU_Fichier��5      $��Fichier��6-   .@�5      m� -   5        $ MENU_FicheUtliisateur��5      $��Mes informations��6:    m� InputGestureText$ Alt+F��6T    m� Command# Z 6m   m� 5      -   5        $ MENU_ChangerUtilisateur��5      $��Changer d'utilisateur��6<   $ Alt+S��6[   # Z 6t   m� 5      -   5        $ MENU_Quitter��5      $��Quitter��61   $ Alt+F4��6B   # Z 6\   5      m� 5      -   5        $ MENU_Categories��5      $��Catégories��60   .@�5      m� -   5        $ MENU_AjouterCategorie��5      $��Nouvelle catégorie��6:   $ Alt+N��6V   # Z 6o   m� 5       -   5        $ MENU_ModifierCategorie��5       $+��%Modifier la catégorie sélectionnée��6;   $ Alt+E��6g   # Z 6�   m� 5!      -   5        $ MENU_SupprimerCategorie��5!      $,��&Supprimer la catégorie sélectionnée��6<   $ Alt+D��6i   # Z	 6�   5"      m� 5#      -   5        $ MENU_Musiques��5#      $��Musiques��6.   .@�5$      m� -   5        $ MENU_AjouterMusique��5$      $��Nouvelle musique��68   $ Ctrl+N��6R   # Z
 6l   m� 5%      -   5        $ MENU_ModifierMusique��5%      $(��"Modifier la musique sélectionnée��69   $ Ctrl+E��6c   # Z 6}   m� 5&      -   5        $ MENU_SupprimerMusique��5&      $)��#Supprimer la musique sélectionnée��6:   $ Ctrl+D��6e   # Z 6   5'      m� 5(      -   5        $ 
MENU_Infos��5(      $��?��6+   .@�5)      m� -   5        $ MENU_Apropos��5)      $��A propos��61   $ Ctrl+H��6C   # Z 6]   5*      5+      � 5,   
   $	��Top=�6   $��56��6$   ���	#FFCCCCCC.+�5-      �� ���	#FFCCCCCC$��57��6*   $	��Top=�67    J� RenderTransformOrigin$ 0.5,0.5&�6O   $��0,0,0.333,0q�6o   �� 5.      -   5         ��Name$ 	LAB_Title��5.      $��HeH-Fy��6'   $��Center=�68   $��0q�6\   $	��Top=�6h   ���	#FFB90600$��22(�6�   $
��Bold"�6�   ���	#00444444$��0,0,0.333,0q�6�   �� 5/      -   5        $ LAB_Subtitle��5/      $��Mes musiques��6*   $��Center=�6A   $��0q�6e   $��0,35,0.333,0q�6q   $	��Top=�6�   50      � 51   
   -   5         �Name$ GRID_ListeCategories��51      $
��Left=�6-   ���	#FF888888.+�52      ]� ��. .+�53      �� $	��Top=�6   $
��Bold"�6-   .��6?   Liste des catégories6U   �� 54      -   5         ��Name$ BTN_SupprimerCategorie��54         Style_BTN_Gris#��[  69   $��Bottom=�6a   $��Supprimer la catégorie��6y   6�   �� 55      -   5        $ BTN_ModifierCategorie��55      #��[  68   $��Bottom=�6`   $��Modifier la catégorie��6x   6�   �� 56      -   5        $ BTN_AjouterCategorie��56      #��[  67   $��Bottom=�6_   $��Nouvelle catégorie��6w   6�   �� 58      -   5         ��Name$ LB_ListeCategories��58       �� DisplayMemberPath$	 Nom��6Y    �� SelectedIndex$ 0��6q   ��66   �� *
Categories+6�   59      5:      � 5;   
   -    5        $ GRID_BoutonsMusiques��5;      $��Right=�6-   ���	#FF888888.+�5<      ]� ��.  .+�5=      �� -!   5        $ BTN_AjouterMusique��5=      #��[  65   $��	10,5,10,5q�6]   $	��Top=�6q   $��Nouvelle musique��6�   6�   �� 5>      -"   5        $ BTN_ModifierMusique��5>      #��[  66   $��	10,5,10,5q�6^   $	��Top=�6r   $��Modifier la musique��6�   6�   �� 5?      -#   5        $ BTN_SupprimerMusique��5?      #��[  67   $��	10,5,10,5q�6_   $	��Top=�6s   $��Supprimer la musique��6�   6�   �� 5@      -$   5         ��Name$ TB_Rechercher��5@      $��0,30,0,0q�61   $��	10,5,10,5q�6C   $	��Top=�6W   $��Recherche de titre��6l   $��Italic$�6�   6�   �� 5A      -%   5        $ BTN_Rechercher��5A      #��[  61   $��	10,5,10,5q�6Y   $	��Top=�6m   $��
Rechercher��6�   6�   5B      5C      � 5D   
   -&   5        $ GRID_DetailMusique��5D      $��Bottom=�6+   $	��200��6C   ���	#FFCCCCCC$y�	Collapsed=�6g   .+�5E      �� $��Détails de la musique��6   $
��Left=�64   $	��Top=�6O   $��	10,10,0,0q�6g   $��20(�6z   $
��Bold"�6�   ���	#FF3333336�   �� 5G      $��Titre��6   $
��Left=�6%   $	��Top=�6@   $��	10,40,0,0q�6X   $��12(�6k   $
��Bold"�6y   ���	#FF3333336�   �� 5H      -'   5         ��Name$ TxtBlk_Titre��5H      $��Titre��6.   $
��Left=�6<   $	��Top=�6W   $
��Auto��6o   $��105,45,170,0q�6|   $��12(�6�   ���	#FF3333336�   �� 5J      $��Réalisateur��6   $
��Left=�6+   $	��Top=�6F   $��	10,60,0,0q�6^   $��12(�6q   $
��Bold"�6   ���	#FF3333336�   �� 5K      -(   5        $ TxtBlk_Realisateur��5K      $��Réalisateur��64   $
��Left=�6H   $	��Top=�6c   $
��Auto��6{   $��105,65,170,0q�6�   $��12(�6�   ���	#FF3333336�   �� 5M      $��Date de sortie��6   $
��Left=�6.   $	��Top=�6I   $��	10,80,0,0q�6a   $��12(�6t   $
��Bold"�6�   ���	#FF3333336�   �� 5N      -)   5        $ TxtBlk_DateSortie��5N      $��Date de sortie��63   $
��Left=�6J   $	��Top=�6e   $
��Auto��6}   $��105,85,170,0q�6�   $��12(�6�   ���	#FF3333336�   �� 5P      $��Résumé��6   $
��Left=�6&   $	��Top=�6A   $��
10,100,0,0q�6Y   $��12(�6m   $
��Bold"�6{   ���	#FF3333336�   �� 5Q      $
��Auto=�6   $
��Left=�6>   $	��Top=�6Y   $
��Auto��6q   $
��Auto��6~   $��105,105,170,10q�6�   .��5R      �� -*   5        $ TxtBlk_Resume��5R      $��Résumé��63   $��0,0,10,0q�6A   $
��Wrap=�6S   $��12(�6g   ���	#FF3333336u   5S      �� 5T      -+   5         ��Name$ IMG_Affiche��5T      $��
0,10,10,41q�6)   $��Right=�6=   $	��120��6Y   $4��./HehFy;component/Ressources/Images/NoPhoto.png��6e   �� 5U      -,   5        $ BTN_YouTube��5U      $��Youtube��6*   $��0,159,10,10q�6<   $��Right=�6k   $	��121��6�   5V      � 5W   
   --   5        $ GRID_ListeMusiques��5W      ���	#FF444444.+�5X      �� -.   5        $ LAB_PasDeCategorie��5X      $,��&Pour commencer, ajoutez une catégorie��60   $��18(�6`   $
��Bold"�6n   ���	#FFCCCCCC$��Center=�6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5Y      -/   5        $ LAB_PasDeMusique��5Y      $1��+Cette catégorie ne contient pas de musique��6.   $��18(�6c   $
��Bold"�6q   ���	#FFCCCCCC$��Center=�6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5Z      $
��Auto=�6   .��5[      �� -0   5         ��Name$ LV_ListeMusiques��5[      ��.  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6|      Wpf.Util.GridViewSort   AutoSort .  �� SelectionMode$ Single=�6�   $ 0��6D  ��6[   �� *
Musiques+  �� View  5\      �� 5]      .P�5^      �� ! �� Width$
! auto��6-   $��Titre��6:   "   PropertyName$" Titre��6p   # �� DisplayMemberBinding# 6I   �� *Titre+6p   �� 5_      $
! auto��6-   $��Auteur/Compositeur��6:   $" Realisateur��6�   # 6V   �� *Realisateur+6�   �� 5`      $
! auto��6-   $��Date de sortie��6:   $" 
DateSortie��6�   # 6R   �� *
DateSortie+$ �� StringFormat$$ 
dd/MM/yyyy��6�   5a      5c      5d      5e      5f      5g      