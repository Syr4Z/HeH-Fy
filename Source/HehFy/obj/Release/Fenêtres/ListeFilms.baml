   M S B A M L   `   `   `  ���� F  BVideotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Videotheque.FenêtresVideotheque.Fenêtres  &     Videotheque.Fenêtres.ListeFilms   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Videotheque.Fenêtres       � WindowStartupLocation$  CenterScreen=� � Title$( "Ma vidéothèque - Liste des films��$	��600��$	��800�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -   &    Videotheque.Fenêtres.ListeFilms   CMD_FicheUtilisateur   Command# Z   -      CMD_ChangerUtilisateur# Z   -      CMD_Quitter# Z   -      CMD_AjouterCategorie# Z   -      CMD_ModifierCategorie# Z   -   	   CMD_SupprimerCategorie# Z	   -   
   CMD_AjouterFilm# Z
   -      CMD_ModifierFilm# Z   -	      CMD_SupprimerFilm# Z   -
      CMD_APropos# Z .��]� ��. .+�o�  o� 
IsMainMenu . $	��Top=�$��20��.@�m� -    m�Name$ MENU_Fichier��$��Fichier��.@�m� -   $ MENU_FicheUtliisateur��$��Mes informations�� m� InputGestureText$ Alt+F�� m� Command# Z m� -   $ MENU_ChangerUtilisateur��$��Changer d'utilisateur��$ Alt+S��# Z m� -   $ MENU_Quitter��$��Quitter��$ Alt+F4��# Z m� -   $ MENU_Categories��$��Catégories��.@�m� -   $ MENU_AjouterCategorie��$��Nouvelle catégorie��$ Alt+N��# Z m� -   $ MENU_ModifierCategorie��$+��%Modifier la catégorie sélectionnée��$ Alt+E��# Z m� -   $ MENU_SupprimerCategorie��$,��&Supprimer la catégorie sélectionnée��$ Alt+D��# Z	 m� -   $ 
MENU_Films��$��Films��.@�m� -   $ MENU_AjouterFilm��$��Nouveau film��$ Ctrl+N��# Z
 m� -   $ MENU_ModifierFilm��$$��Modifier le film sélectionné��$ Ctrl+E��# Z m� -   $ MENU_SupprimerFilm��$%��Supprimer le film sélectionné��$ Ctrl+D��# Z m� -   $ 
MENU_Infos��$��?��.@�m� -   $ MENU_Apropos��$��A Propos...��$ Ctrl+H��# Z � $	��Top=�$��56�����	#FFCCCCCC.+��� ���	#FFCCCCCC$��57��$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�$��0,0,0.333,0q��� -    ��Name$ 	LAB_Title��$��Ma Vidéothèque��$��Center=�$��0q�$	��Top=����	#FFB90600$��22(�$
��Bold"����	#00444444$��0,0,0.333,0q��� -   $ LAB_Subtitle��$��	Mes films��$��Center=�$��0q�$��0,35,0.333,0q�$	��Top=�� -    �Name$ GRID_ListeCategories��$
��Left=����	#FF888888.+�]� ��. .+��� $	��Top=�$
��Bold"�.��Liste des catégories�� -    ��Name$ BTN_SupprimerCategorie��   Style_BTN_Gris#��[  $��Bottom=�$��Supprimer la catégorie���� -   $ BTN_ModifierCategorie��#��[  $��Bottom=�$��Modifier la catégorie���� -   $ BTN_AjouterCategorie��#��[  $��Bottom=�$��Nouvelle catégorie���� -    ��Name$ LB_ListeCategories�� �� DisplayMemberPath$	 Nom�� �� SelectedIndex$ 0������ *
Categories+� -    $ GRID_BoutonsFilms��$��Right=����	#FF888888.+�]� ��.  .+��� -!   $ BTN_AjouterFilm��#��[  $��	10,5,10,5q�$	��Top=�$��Nouveau Film���� -"   $ BTN_ModifierFilm��#��[  $��	10,5,10,5q�$	��Top=�$��Modifier le film���� -#   $ BTN_SupprimerFilm��#��[  $��	10,5,10,5q�$	��Top=�$��Supprimer le film��� -$   $ GRID_DetailFilm��$��Bottom=�$	��200�����	#FFCCCCCC$y�	Collapsed=�.+��� $��Détail du film��$
��Left=�$	��Top=�$��	10,10,0,0q�$��20(�$
��Bold"����	#FF333333�� $��Titre��$
��Left=�$	��Top=�$��	10,40,0,0q�$��12(�$
��Bold"����	#FF333333�� -%    ��Name$ TxtBlk_Titre��$��Titre��$
��Left=�$	��Top=�$
��Auto��$��105,45,170,0q�$��12(����	#FF333333�� $��Réalisateur��$
��Left=�$	��Top=�$��	10,60,0,0q�$��12(�$
��Bold"����	#FF333333�� -&   $ TxtBlk_Realisateur��$��Réalisateur��$
��Left=�$	��Top=�$
��Auto��$��105,65,170,0q�$��12(����	#FF333333�� $��Date de sortie��$
��Left=�$	��Top=�$��	10,80,0,0q�$��12(�$
��Bold"����	#FF333333�� -'   $ TxtBlk_DateSortie��$��Date de sortie��$
��Left=�$	��Top=�$
��Auto��$��105,85,170,0q�$��12(����	#FF333333�� $��Résumé��$
��Left=�$	��Top=�$��
10,100,0,0q�$��12(�$
��Bold"����	#FF333333�� $
��Auto=�$
��Left=�$	��Top=�$
��Auto��$
��Auto��$��105,105,170,10q�.���� -(   $ TxtBlk_Resume��$��Résumé��$��0,0,10,0q�$
��Wrap=�$��12(����	#FF333333�� -)    ��Name$ IMG_Affiche��$��339,10,10,10q�$��Right=�$	��140��$:��4/Videotheque;component/Ressources/Images/NoPhoto.png��� -*   $ GRID_ListeFilms�����	#FF444444.+��� -+   $ LAB_PasDeCategorie��$,��&Pour commencer, ajouter une catégorie��$��18(�$
��Bold"����	#FFCCCCCC$��Center=�$��Center=�$y�	Collapsed=��� -,   $ LAB_PasDeFilm��$.��(Cette catégorie ne contient pas de film��$��18(�$
��Bold"����	#FFCCCCCC$��Center=�$��Center=�$y�	Collapsed=��� $
��Auto=�.���� --    ��Name$ LV_ListeFilms����.  $ 0������ *Films+ �� View �� .P��� $��Titre�� �� Width$
 Auto�� �� DisplayMemberBinding �� *Titre+�� $��Réalisateur��$
 Auto�� �� *Realisateur+�� $��Date de sortie��$	 100�� �� *
DateSortie+ �� StringFormat$ 
dd/MM/yyyy��