   M S B A M L   `   `   `  ���� S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Valid.Fulfillment.Client.ViewsValid.Fulfillment.Client.Views  4    .Valid.Fulfillment.Client.Views.UserLoginWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >local,clr-namespace:Valid.Fulfillment.Client.Views       � Title$  UserLoginWindow��$	��300��$	��300�� � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=� � DataContext �� ����  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ LightSlateGray�� � Offset$ .1Q�� $ Black��$ .6Q�.��� .+���  �� Orientation$ Vertical=�$��Center=�.+��� $��50���� $ 
Horizontal=�$��Center=�.+��� 
�������$��75��.��User Name :�� -   $��Cbox_UserName��$	��125��	 �� DisplayMemberPath$	 UserName������ *UserInfoList+�� $��25���� $ 
Horizontal=�$��Center=�.+��� 
�������$��75��.��
Password :G� -   
 G�Name$
 Tbox_Password��$	��125�� G� PasswordChar$ *���� -   $��	Lbl_Error��$��10(�
���  ��$��Center=�$y�Hidden=�.��Incorrect Password�� $��25���� $ 
Horizontal=�.+��� -    ��Name$ 	Btn_Login��$��20��$	��100��$��10,10,10,10q�.��Login�� -   $ 
Btn_Logout��$��20��$	��100��$��10,10,10,10q�.��Logout� $��Bottom=�$��Right=�.+��� -   $��Img_Logo��$	��125��$��25��$
��Fill=�