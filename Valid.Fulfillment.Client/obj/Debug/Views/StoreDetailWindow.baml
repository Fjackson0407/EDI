   M S B A M L   `   `   `  ����S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Valid.Fulfillment.Client.ViewsValid.Fulfillment.Client.Views  5   	   6    0Valid.Fulfillment.Client.Views.StoreDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Valid.Fulfillment.Client.Views     5   	   -   5          � Title$  StoreDetailWindow��5	   	   $	��300��6#   $	��500��60    � WindowStartupLocation$ CenterScreen=�5
   	    � DataContext 5   	   �� ��5      �� 5   
    �� 
StartPoint$ 0.5,0&�6    �� EndPoint$ 0.5,1&�61   .��5      �  � Color$ LightSlateGray��6    � Offset$ .1Q�63   6A   � 5      $ Black��6   $ .6Q�6*   68   5      .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   .+�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��20(�6   
�������$��	10,5,10,5q�69   .��6L   Current User :6\   �� 5      $��20(�6   
�������$��	10,5,10,5q�69   ��6L   �� *
CurentUser+6m   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ datagrid_StoreDetail��5      	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     
IsReadOnly . $��20(�5         AutoGenerateColumns .     SelectionMode$ Single=�6B      AlternatingRowBackground
 �����$	��Top=�5   <   ��5      �� *StoreDetailGridList+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ 	DC Number��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
DcNumber+6Y     5"      $ Store Number��6)    .  6?   �� *StoreNumber+6_     5#      $ Number of Packs��6)    .  6B   �� *
OrderQty+6_     5$      $ Status��6)    .  69   �� *OrderStatusDescription+6d   5&      5'      � 5(   
   $��Bottom=�6   $��Right=�6*   .+�5)      �� -   5        $��Img_Logo��5)      $	��125��6@   $��25��6L   $
��Fill=�6X   5*      5,      5-      