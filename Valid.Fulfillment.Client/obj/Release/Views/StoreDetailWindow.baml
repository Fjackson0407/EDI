   M S B A M L   `   `   `  ���� S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Valid.Fulfillment.Client.ViewsValid.Fulfillment.Client.Views  6    0Valid.Fulfillment.Client.Views.StoreDetailWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >local,clr-namespace:Valid.Fulfillment.Client.Views       � Title$  StoreDetailWindow��$	��300��$	��500�� � WindowStartupLocation$ CenterScreen=� � DataContext �� ����  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ LightSlateGray�� � Offset$ .1Q�� $ Black��$ .6Q�.��� .+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��Center=�.+��� 
�������$��	10,5,10,5q�.��Current User :�� 
�������$��	10,5,10,5q����� *
CurentUser+&   System.Windows.Controls.DataGrid  -     Name$ datagrid_StoreDetail��	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     
IsReadOnly . $��14(�   AutoGenerateColumns .     SelectionMode$ Single=�   AlternatingRowBackground
 �����$	��Top=����� *StoreDetailGridList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	DC Number��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
DcNumber+  $ Store Number�� .  �� *StoreNumber+  $ Number of Packs�� .  �� *
OrderQty+  $ Status�� .  �� *OrderStatusDescription+� $��Bottom=�$��Right=�.+��� -   $��Img_Logo��$	��125��$��25��$
��Fill=�