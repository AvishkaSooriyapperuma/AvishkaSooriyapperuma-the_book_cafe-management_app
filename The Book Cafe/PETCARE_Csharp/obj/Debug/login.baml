   M S B A M L   `   `   `  ����I  EPETCARE_Csharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PETCARE_CsharpPETCARE_Csharp  5   	       PETCARE_Csharp.login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PETCARE_Csharp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ login��5   	   $	��450��6   $	��800��6$   
������  � Topmost . .��5      �� $	��450��6   $��Bottom=�6    �� CornerRadius$ 	0 0 180 0��65   
�������._�5   
   � ��5      �� 5       �� 
StartPoint$ 0.1,0&�6&    �� EndPoint$ 0.9,1&�69   .��5      � 	 � Color$	 #C8253E��6#   
 � Offset$
 1Q�63   � 5      $	 #363636��6#   $
 0Q�63   5      .+�5      �� -   5        $	��390��5      $	��Top=�6"   $ 	0 0 180 0��6:   
�������5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/book-cafe.png��6   $	��300��6:   $	��300��6F   $��28,30,22,10q�6S   6j   5      �� 5      $��3��6   $	��300��6'   $��0 0 0 60q�64   .+�5       �� $��Stretch=�6    $��Center=�6>   ���#000000$	��300��6h   5!      �� 5"      $	��350��6   .+�5#      �� $��20 40q�6!   .+�5$      �� $��Login��6$   $��20q�61   
���   � �� TextAlignment$ Center=�6P   $��38(�6g   $��DemiBold"�6u   $��monaco)�6�   6�   �� 5%      $ 
Horizontal=�6%   $��10q�6>   .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�66   $��25��6B   $��25��6M   ���#0006Y   �� 5'      -   5         ��Name$ txtUsername��5'   &   $
��10 0q�6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username��6I   ���#000000$	��250��6�   ���#000 �� 
CaretBrush �#000 �� SelectionBrush �#0006�   5(      �� 5)      $ 
Horizontal=�6%   $��10q�6>   .+�5*        $
 Lock=�66   $��25��6B   $��25��6M   ���#0000006Y   G� 5+      -   5         G�Name$ txtPassword��5+   *   $
��10 0q�6?   $ 
**********��6M   ���#000$	��250��6�   ���#000 G� 
CaretBrush �#000 G� SelectionBrush �#0006�   5,      �� 5-      $��10q�6%   $��Center=�61   .+�5.      �� -   5         ��Name$ btnLogin��5/   �   $	��100��5.   %   $��40��61      MaterialDesignRaisedButton#��[  6=   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5/   !   $��2q�6O   ���#C8253E���#C8253E
������� � ToolTip$ Login��6�   $��Login��6�   50      51      �� 52      $	��100��6%   .+�53      �� $��Don't Have an Account?��6(   $��5q�6F   ���#000$ Center=�6c   $��15(�6z   $��Monaco)�6�   6�   �� 54      -   5         ��Name$ 
gotosignup��54   ~   $��	Underline{�6(   $��Sign Up��6D   $��Center=�6S   $��15(�6p   6�   56      57      58      �� 59      $��97��6   .+�5:      �� -   5        $ btnExit��5;   )   $��30 20 20 20q�5:       , (MaterialDesignFloatingActionAccentButton#��[ 62   $ Close��5;      $��44��6P   $
��Auto��6\   ��5:   t   Z� .��5<        $ Close=�62   ���#000$��30��6Q   $��30��6\   5=      5>      5?      5@      5A      5B      