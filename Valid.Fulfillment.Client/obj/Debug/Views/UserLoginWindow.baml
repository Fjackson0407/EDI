   M S B A M L   `   `   `  ����S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Valid.Fulfillment.Client.ViewsValid.Fulfillment.Client.Views  5   	   4    .Valid.Fulfillment.Client.Views.UserLoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Valid.Fulfillment.Client.Views     5   	     � Title$  UserLoginWindow��5   	   $	��400��6!   $	��500��6.    � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�5
       � DataContext 5	   	   �� ��5      �� 5   
    �� 
StartPoint$ 0.5,0&�6    �� EndPoint$ 0.5,1&�61   .��5      �  � Color$ LightSlateGray��6    � Offset$ .1Q�63   6A   � 5      $ Black��6   $ .6Q�6*   68   5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   .+�5      �� $��20(�6   $��50��6"   60   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��20(�6   
�������$	��125��69   .��6E   User Name :6R   �� 5      -   5        $��Cbox_UserName��5   )   $��20(�6   $	��200��6>   	 �� DisplayMemberPath$	 UserName��6o   ��6J   �� *UserInfoList+6�   5      �� 5      $��20(�6   $��25��6"   60   �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��20(�6   
�������$	��125��69   .��6E   
Password :6Q   G� 5      -   5        
 G�Name$
 Tbox_Password��5   ,   $��20(�6   $	��200��6C    G� PasswordChar$ *��6O   5   ;   5      �� 5      -   5        $��	Lbl_Error��5      $��14(�6%   
���  ��$��Center=�6D   $y�Hidden=�6a   .��6u   Incorrect Password6�   �� 5       $��25��6   6"   �� 5!      $ 
Horizontal=�6   .+�5"      �� -   5         ��Name$ 	Btn_Login��5"   '   $��20(�6   $��40��6:   $	��200��6F   $��10,10,10,10q�6l   .��6�   Login6�   �� 5#      -   5        $ 
Btn_Logout��5#   '   $��20(�6   $��40��6;   $	��200��6G   $��10,10,10,10q�6n   .��6�   Logout6�   5$      5%      � 5&   
   $��Bottom=�6   $��Right=�6*   .+�5'      �� -   5        $��Img_Logo��5'      $	��125��6?   $��25��6K   $
��Fill=�6W   5(      5)      5*      