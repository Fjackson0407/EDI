   M S B A M L   `   `   `  ���� S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Valid.Fulfillment.ClientValid.Fulfillment.Client  0    *Valid.Fulfillment.Client.OrderDetailWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Valid.Fulfillment.Client     -     � Title$  Order Detail��$
��Left=�$	��Top=� � SizeToContent$ Width=� � WindowStartupLocation$ CenterScreen=� � DataContext �� ����  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ LightSlateGray�� � Offset$ .1Q�� $ Black��$ .6Q�.��� .+�� $
��Left=�$	��Top=�.+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��Center=�.+��� $��18(�
�������$��	10,5,10,5q����� *	OrderType+�� 
�������$��
100,5,10,5q�.��Current User :�� 
�������$��	10,5,10,5q����� *
CurentUser+�� $ 
Horizontal=�$	��Top=�.+��� $ Vertical=�$��10,10,10,10q�.+��� 
�������$��14(�$��20��DC:�� -   $��	tblk_DcId��
�������$��14(�$��20��#####�� $ Vertical=�$��10,10,10,10q�.+��� 
�������$��14(�$��20��STORE:�� -   $��
tblk_Store��
�������$��14(�$��20��
########�� $ Vertical=�$��10,10,10,10q�.+��� 
�������$��14(�$��20��
ACCOUNT:�� -   $��tblk_Account��
�������$��14(�$��20��######&   System.Windows.Controls.DataGrid  -   	  Name$	 datagrid_OrderDetail��
   CanUserAddRows
 .     CanUserDeleteRows .     
IsReadOnly . $��14(�   AutoGenerateColumns .     SelectionMode$ Single=�   AlternatingRowBackground
 �����$
��Left=�$	��Top=����� *OrderDetailGridList+ �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Line #��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *OriginalLine+  $ Total Qty Ordered�� .  �� *
QtyOrdered+  $ Qty of Bundles�� .  �� *	BundleQty+  $
 DPCI�� .  �� *DPCI+  $ Item Description�� .  �� *SkuItem.Item+  $ Product UPC�� .  �� *UPCode+  $ 
Qty Packed�� .  �� *	QtyPacked+$ TwoWay=�� $��Bottom=�.+��� $ Vertical=�$��Center=�.+�  -   $	 datagrid_SerialRangeList��
 .   .   . $��14(� .  $ Single=�
 �����$��5,5,5,10q�$��Center=�$	��Top=�$��Center=����� *SerialRangeList+$ TwoWay=� � 	Resources    SerialRangeGridMenu  SerialRangeRowMenu �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%   &	        &	       '  [     7   '  �     7  �� .@�m� -   $��Add Row���� .@�m� -   $��
Delete Row��m� -	   $��Add Row���� "  .���  �@�ContextMenu8   �� "  .���  �@ 
IsSelected . ��  �@�ContextMenu8      $ Serial Range��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300  .  �� *Serialbundle+�� $ 
Horizontal=�$��Center=�$��Bottom=�.+��� -
   $��	btn_Print��$��30��$	��125��$��10,10,10,10q�{��� *PrintBtnEnabled+.��Print Label�� -   $��btn_Reprint��$��30��$	��125��$��10,10,10,10q�{�.  .��Reprint Label�� -   $��
btn_Cancel��$��30��$	��125��$��10,10,10,10q�.��Cancel� $��Bottom=�$��Right=�.+��� -   $��Img_Logo��$	��125��$��25��$
��Fill=�