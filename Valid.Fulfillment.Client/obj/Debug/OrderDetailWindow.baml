   M S B A M L   `   `   `  ����S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Valid.Fulfillment.ClientValid.Fulfillment.Client  5   	   0    *Valid.Fulfillment.Client.OrderDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Valid.Fulfillment.Client     5   	     � Title$  Order Detail��5	   	   $
��Left=�6   $	��Top=�69    � SizeToContent$ Width=�6Q   $	��500��6g    � DataContext 5   	   �� .��5
      � .+�5      � $
��Left=�6   $	��Top=�6&   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   $	��Top=�6.   .+�5      �� $ Vertical=�6   $��10,10,10,10q�60   .+�5      �� $��14(�6   $��20��6*   DC:6;   �� 5      -   5        $��	tblk_DcId��5      $��14(�6-   $��20��6;   #####6N   5      �� 5      $ Vertical=�6   $��10,10,10,10q�60   .+�5      �� $��14(�6   $��20��6*   STORE:6>   �� 5      -   5        $��
tblk_Store��5      $��14(�6.   $��20��6<   
########6R   5      �� 5      $ Vertical=�6   $��10,10,10,10q�60   .+�5      �� $��14(�6   $��20��6*   
ACCOUNT:6@   �� 5      -   5        $��tblk_Account��5      $��14(�60   $��20��6>   ######6R   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid_OrderDetail��5         CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��14(�5!   #      AutoGenerateColumns .  	   SelectionMode$	 Single=�6M   
   AlternatingRowBackground

 �����$
��Left=�5"   H   $	��Top=�6c   ��5   #   �� *OrderDetailGridList+   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Line #��6-      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
LineNumber+6\     5.      $	 UOM��6-    .  6:   �� *UOM+6R     5/      $ Qty Ordered��6-    .  6B   �� *
QtyOrdered+6a     50      $ 	Pack Size��6-    .  6@   �� *
PackSize+6]     51      $ Item Description��6-    .  6G   �� *ItemDescription+6k     52      $ Qty Packs Needed��6-    .  6G   �� *QtyPacksNeeded+6j     53      $ Product UPC��6-    .  6B   �� *
ProductUPC+6a     54      $ Serial Ranges��6-    .  6D   �� *SerialRanges+6e     55      $ 
Qty Packed��6-    .  6A   �� *	QtyPacked+6_   57      59      5;      �� 5<   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   .+�5=      �� -   5        $��	btn_Print��5=      $��30��6&   $	��125��62   $��10,10,10,10q�6>   .��6m   Print Label6z   �� 5>      -   5        $��btn_Reprint��5>      $��30��6(   $	��125��64   $��10,10,10,10q�6@   .��6q   Reprint Label6�   �� 5?      -   5        $��
btn_Cancel��5?      $��30��6'   $	��125��63   $��10,10,10,10q�6?   .��6o   Cancel6w   5@      5A      5B      