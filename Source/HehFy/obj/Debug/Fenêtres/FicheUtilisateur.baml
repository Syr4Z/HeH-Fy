   M S B A M L   `   `   `  ����@  <HehFy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hehfy.FenêtresHehfy.Fenêtres  5   	   $    Hehfy.Windows.FicheUtilisateur   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Hehfy.Fenêtres     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$% HeH-Fy - Fiche de l'utilisateur��5
   	   $��328.196��61   $	��300��6B    � 
ResizeMode$ NoResize=�6N   .��5      ]� ��. .+�5   
   � $	��Top=�6   $��56��6$   ���	#FFCCCCCC.+�5      �� ���	#FFCCCCCC$��57��6*   $	��Top=�67    J� RenderTransformOrigin$ 0.5,0.5&�6O   $��0,0,0.333,0q�6o   �� 5      -   5         ��Name$ 	LAB_Title��5      $��HeH-Fy��6'   $��Center=�68   $��0q�6\   $	��Top=�6h   ���	#FFB90600$��22(�6�   $
��Bold"�6�   ���	#00444444$��0,0,0.333,0q�6�   �� 5      -   5        $ LAB_Subtitle��5      $��Fiche de l'utilisateur��6*   $��Center=�6K   $��0q�6o   $��0,35,0.333,0q�6{   $	��Top=�6�   5      � 5   
   ���	#FF444444.+�5      �� -   5        $ LAB_Nom��5      $	��Nom��6%   $
��Left=�63   $��
2, 0, 0, 0q�6N   $��	15,10,0,0q�6c   $	��Top=�6v   ���	#FFCCCCCC6�   �� 5      -   5         ��Name$ TB_Nom��5      $
��Left=�6&   $��23��6A   $��	15,31,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6�   $	��169��6�   ��6t   ��  �� Path$	 Nom� �� Mode$ TwoWay=�6�   �� 5      -   5        $ LAB_MotDePasse��5      $��Nouveau mot de passe��6,   $
��Left=�6K   $��
2, 0, 0, 0q�6f   $��	15,64,0,0q�6{   $	��Top=�6�   ���	#FFCCCCCC6�   G� 5      -   5        	 G�Name$	 TB_MotDePasse��5      $
��Left=�61   $��23��6L   $��	15,85,0,0q�6X   $	��Top=�6k   $	��169��6�   �� 5      -   5        $ LAB_MotDePasse2��5      $%��Retapez le nouveau mot de passe��6-   $
��Left=�6W   $��
2, 0, 0, 0q�6r   $��
15,118,0,0q�6�   $	��Top=�6�   ���	#FFCCCCCC6�   G� 5      -	   5        $	 TB_MotDePasse2��5      $
��Left=�62   $��23��6M   $��
15,138,0,0q�6Y   $	��Top=�6m   $	��169��6�   �� 5      -
   5        
 ��Name$
 BTN_Valider��5      $��Valider��6*   $��Center=�6<   $��36,193,154.667,0q�6Y   $	��Top=�6s   $	��104��6�   ���	#FFCCCCCC���	#FFB90600$
��Bold"�6�   ��6�   Z� 6�   �� 5      -   5        $
 BTN_Annuler��5      $��Annuler��6*   $��Center=�6<   $��155,193,35.667,0q�6Y   $	��Top=�6s   $	��104��6�   ���	#FFCCCCCC���	#FF444444$
��Bold"�6�   ��6�   Z� 6�   5       5!      5"      