   M S B A M L   `   `   `  ����S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Valid.Fulfillment.ClientValid.Fulfillment.Client  5   	   0    *Valid.Fulfillment.Client.OrderDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Valid.Fulfillment.Client     5   	   -   5          � Title$  Order Detail��5	   	   $
��Left=�6   $	��Top=�69    � WindowStartupLocation$ CenterScreen=�6Q    � DataContext 5   	   �� ��5      �� 5   
    �� 
StartPoint$ 0.5,0&�6    �� EndPoint$ 0.5,1&�61   .��5      �  � Color$ LightSlateGray��6    � Offset$ .1Q�63   6A   � 5      $ Black��6   $ .6Q�6*   68   5      .��5      � .+�5   
   � $��Center=�6   $	��Top=�6,   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      �� $��24(�6   
�������$��	10,5,10,5q�6>   ��6Q   �� *	OrderType+6q   �� 5      $��20(�6   
�������$��
100,5,10,5q�6=   .��6Q   Current User :6a   �� 5      $��20(�6   
�������$��	10,5,10,5q�6=   ��6P   �� *
CurentUser+6q   5      �� 5      $ 
Horizontal=�6   $	��Top=�66   .+�5      �� $ Vertical=�6!   $��10,10,10,10q�68   .+�5      �� 
�������$��20(�68   $��30��6F   DC:6W   �� 5      -   5        $��	tblk_DcId��5   7   
�������$��20(�6H   $��30��6V   #####6i   5      �� 5       $ Vertical=�6!   $��10,10,10,10q�68   .+�5!      �� 
�������$��20(�67   $��30��6E   STORE:6Y   �� 5"      -   5        $��
tblk_Store��5"   7   
�������$��20(�6I   $��30��6W   
########6m   5#      �� 5$      $ Vertical=�6!   $��10,10,10,10q�68   .+�5%      �� 
�������$��20(�67   $��30��6E   
ACCOUNT:6[   �� 5&      -   5        $��tblk_Account��5&   7   
�������$��20(�6K   $��30��6Y   ######6m   5'      �� 5(      $ Vertical=�6!   $��100,10,10,10q�68   .+�5)      �� 
���/���$��	ExtraBold"�6>   $��24(�6V   $��30��6d   y�6p   �� *
UpcMatched+UPC Code Matched6�   5*      5+      &   System.Windows.Controls.DataGrid  5,      -   5          Name$ datagrid_OrderDetail��5,      	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     
IsReadOnly . $��20(�51   #      AutoGenerateColumns .     SelectionMode$ Single=�6M      AlternatingRowBackground
 �����$
��Left=�52   H   $	��Top=�6c   ��5-   #   �� *OrderDetailGridList+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Line #��6-      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *OriginalLine+6^     56      $ Total Qty Ordered��6-    .  6H   �� *
QtyOrdered+6g     57      $ Qty of Bundles��6-    .  6E   �� *	BundleQty+6c     58      $
 DPCI��6-    .  6;   �� *SkuItem.DPCI+6\     59      $
 DPCI��6-    .  6;   �� *SkuItem.DPCI+6\     5:      $ Item Description��6-    .  6G   �� *SkuItem.Product+6k     5;      $ Product UPC��6-    .  6B   �� *UPCode+6]     5<      $ 
Qty Packed��6-    .  6A   �� *	QtyPacked+6_   5>      5?      5@      � 5A   
   $��Bottom=�6   .+�5B      �� $ Vertical=�6   $��Center=�60   .+�5D        -   5        $ datagrid_SerialRangeList��5D      	 .  
 .   . $��20(�5G   #    .  $ Single=�6M   
 �����$��5,5,5,10q�5H   H   $��Center=�5I   #   $	��Top=�6@   $��Center=�6X   ��5E   #   �� *SerialRangeList+ � 	Resources 5J         SerialRangeGridMenu  SerialRangeRowMenu �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%�  &	        &	 R     '  �     7   '  �     7  �� 5K      .@�5L      m� -   5        $��Add Row��5L   '   68   5M      �� 5N      .@�5P      m� -   5        $��Add Row��5P   '   68   5Q      �� 5R      "  6    .�5S      ��  �@�ContextMenu8   6<   5T      �� 5U      "  6    .�5V      ��  �@ 
IsSelected . 6;   �� 5W       �@�ContextMenu8   6<   5X      5Y       5Z        5[      $ Serial Range��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6C    .  6O   �� *Serialbundle+6p   5]      �� 5^      $ 
Horizontal=�6   $��Center=�66   $��Bottom=�6S   .+�5_      �� -	   5        $��	btn_Print��5_   +   $��20(�6   $��40��6<   $	��200��6H   $��10,10,10,10q�6T   {�6�   �� *PrintBtnEnabled+.��6�   Print Label6�   �� 5a      -
   5        $��
btn_Cancel��5a   +   $��20(�6   $��40��6=   $	��200��6I   $��10,10,10,10q�6U   .��6�   Done6�   5b      �� 5c      -   5        $��Tblk_Status��5c   *   $��20(�6   $��30��6=   
���������6\   �� *StatusMessage+6}   5l      5n      � 5o   
   $��Bottom=�6   $��Right=�6*   .+�5r      �� -   5        $��Img_Logo��5r      $	��125��6@   $��25��6L   $
��Fill=�6X   5t      5u      5v      