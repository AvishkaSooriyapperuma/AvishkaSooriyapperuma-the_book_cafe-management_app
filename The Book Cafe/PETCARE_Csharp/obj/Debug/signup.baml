   M S B A M L   `   `   `  ����I  EPETCARE_Csharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PETCARE_CsharpPETCARE_Csharp  5   	       PETCARE_Csharp.signup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PETCARE_Csharp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ Normal=�5   	    � Title$ SignUp��5   	   $	��450��6   $	��800��6%   .��5      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ #AF2138��6   	 � Offset$	 1Q�6/   � 5      $ #363636��6   $	 0Q�6/   5      .+�5   
   �� -   5        $	��390��5      $	��Top=�6   
 �� CornerRadius$
 	0 0 180 0��66   
�������5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��800��6I   .+�5      �� $	��350��6   .+�5      �� $��/Images/book-cafe.png��6   $	��300��67   $	��300��6C   $��28,50,20,10q�6P   6h   5      �� 5      $��3��6   $	��300��6#   $��0 0 0 60q�60   .+�5      �� $��Stretch=�6   $��Center=�6:   ���#000$	��300��6a   5      �� 5       $	��350��6   .+�5!      �� $��20 40q�6   .+�5"      �� $��Sign Up��6    $��20q�6/   ���#000 �� TextAlignment$ Center=�6M   $��DemiBold"�6d   $��38(�6z   $��Monaco)�6�   6�   �� 5#      $ 
Horizontal=�6!   $��10q�6:   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�62   $��25��6>   $��25��6I   ���#0006U   �� 5%      -   5         ��Name$ Username��5%   "   $
��10 0q�64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username��6B   ���#000$	��250��6�   ���#000 �� 
CaretBrush �#000 �� SelectionBrush �#0006�   5&      �� 5'      $ 
Horizontal=�6!   $��10q�6:   .+�5(        $
 Mail=�62   $��25��6>   $��25��6I   ���#0006U   �� 5)      -   5        $ Email��5)   "   $
��10 0q�61   $ Enter Email Address��6?   ���#000$	��250��6�   ���#000 �#000 �#0006�   5*      �� 5+      $ 
Horizontal=�6!   $��10q�6:   .+�5,        $
 Lock=�62   $��25��6>   $��25��6I   ���#0006U   G� 5-      -   5         G�Name$ Password��5-   &   $
��10 0q�68   $ Password��6F   ���#000$	��250��6�   ���#000 G� 
CaretBrush �#000 G� SelectionBrush �#0006�   5.      �� 5/      $ 
Horizontal=�6!   $��10q�6:   .+�50        $
 Lock=�62   $��25��6>   $��25��6I   ���#0006U   G� 51      -   5        $ ConfirmPassword��51   &   $
��10 0q�6?   $ Confirm Password��6M   ���#000$	��250��6�   ���#000 �#000 �#0006�   52      �� 53      $��10q�6!   $��Center=�6-   .+�54      �� -   5         ��Name$ 	btnsignup��55   �   $	��100��54   !   $��40��6-      MaterialDesignRaisedButton#��[  69   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��55   !   $��2q�6O   ���#AF2138���#AF2138
������� � ToolTip$ Login��6�   $��Sign Up��6�   56      57      58      59      �� 5:      $��97��6   .+�5;      �� -   5        $ btnExit��5<   )   $��30 20 20 20q�5;       , (MaterialDesignFloatingActionAccentButton#��[ 6.   $ Close��5<      $��44��6P   $
��Auto��6\   ��5;   p   Z� .��5=        $ Close=�6.   ���#363636$��30��6P   $��30��6[   5>      5?      5@      5A      5B      