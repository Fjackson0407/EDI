   M S B A M L   `   `   `  ���� S  OValid.Fulfillment.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Valid.Fulfillment.ClientValid.Fulfillment.Client  )    #Valid.Fulfillment.Client.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Valid.Fulfillment.Client     -     � Title$  VALID Fulfillment Client�� � WindowStartupLocation$ CenterScreen=�$	��Top=�$	��600��$	��600�� � DataContext �� ����  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ LightSlateGray�� � Offset$ .1Q�� $ Black��$ .6Q�.��� .+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ 	Btn_Login��$��20��$	��150��$��	10,5,10,5q�.��Login / Logout�� 
�������$��	10,5,10,5q�.��Current User :�� 
�������$��	10,5,10,5q����� *CurrentUser.UserName+�� $ 
Horizontal=�.+�	� -   $��Rbtn_OpenOders��	 d� 	IsChecked$
	 TrueY�
�������$��25��$��10,0,5,0q�$��Center=�.��Open	� -   $��Rbtn_ClosedOrders��
�������$��25��$��5,0,5,0q�$��Center=�.��Closed	� -   $��Rbtn_AllOrders��
�������$��25��$��5,0,5,0q�$��Center=�.��All�� 
�������$��15,0,0,0q�.��Start(  "System.Windows.Controls.DatePicker  -   $��Dp_StartDate��$��Center=��� 
�������$��15,0,0,0q�.��End  -   $��
Dp_EndDate��$��Center=��� -   $��Btn_Load��$��25��$	��100��$��15,0,0,0q�y��� *LoadButtonVisibility+.��Load�� -	   $��
TabControl��$	��Top=�$��10,10,10,10q�.@��� -
   $��FulfillmentDetail��$��Fulfillment Breakdown��$	��Top=�.��� $	��Top=�.+��� $ Vertical=�.+��� $��14(�$
��Bold"�.��Visa Mastercard&   System.Windows.Controls.DataGrid  -   
  Name$
 datagrid_VisaMcDetail��   CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��14(�   AutoGenerateColumns .     SelectionMode$ Single=�   AlternatingRowBackground
 �����$	��Top=�$��2��$��0q�   GridLinesVisibility$
 None=����� *VisaMcDetailList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	DC Number��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
DcNumber+  $ Number of Stores�� .  �� *
StoreCount+  $ Number of Packs�� .  �� *	PackCount+�� $��14(�$
��Bold"�.��AmericanExpress  -   $
 datagrid_AmexDetail�� .   .   . $��14(� .  $ Single=�
 �����$	��Top=�$��2��$��0q�$
 None=����� *AmexDetailList+   $ 	DC Number�� .  �� *
DcNumber+  $ Number of Stores�� .  �� *
StoreCount+  $ Number of Packs�� .  �� *	PackCount+�� -   $��Summary��$��Summary��$	��Top=�.��� $	��Top=� � ColumnDefinitions �� $	��100 ��� $	��100 ��� $	��100 ��� $	��100 ��� $	��100 � � RowDefinitions �� $��10 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 �.+��� $��1��$��1��$��14(�$
��Bold"�$��Center=�$��Center=�.��Total Orders�� $��2��$��1��$��14(�$
��Bold"�$��Center=�$��Center=�.��Orders Picked�� $��3��$��1��$��14(�$
��Bold"�$��Center=�$��Center=�.��Orders Cancelled�� $��4��$��1��$��14(�$
��Bold"�$��Center=�$��Center=�.��Orders Open�� $��0��$��2��$��14(�$
��Bold"�$��Center=�$��Center=�.��	Visa / MC�� $��0��$��3��$��14(�$
��Bold"�$��Center=�$��Center=�.��AMEX�� $��0��$��4��$��14(�$
��Bold"�$��Center=�$��Center=�.��Totals�� -   $��lbl_Summary_VMC_Total��$��1��$��2��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryVisaMc.Total+�� -   $��lbl_Summary_VMC_Picked��$��2��$��2��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryVisaMc.Picked+�� -   $��lbl_Summary_VMC_Cancel��$��3��$��2��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryVisaMc.Cancel+�� -   $��lbl_Summary_VMC_Open��$��4��$��2��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryVisaMc.Open+�� -   $��lbl_Summary_Amex_Total��$��1��$��3��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryAmex.Total+�� -   $��lbl_Summary_Amex_Picked��$��2��$��3��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryAmex.Picked+�� -   $��lbl_Summary_Amex_Cancel��$��3��$��3��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryAmex.Cancel+�� -   $��lbl_Summary_Amex_Open��$��4��$��3��$��14(�$��Normal"�$��Center=�$��Center=����� *SummaryAmex.Open+�� $��1��$��4��$��14(�$
��Bold"�$��Italic$�$��Center=�$��Center=����� *SummaryTotal.Total+�� $��2��$��4��$��14(�$
��Bold"�$��Italic$�$��Center=�$��Center=����� *SummaryTotal.Picked+�� $��3��$��4��$��14(�$
��Bold"�$��Italic$�$��Center=�$��Center=����� *SummaryTotal.Cancel+�� $��4��$��4��$��14(�$
��Bold"�$��Italic$�$��Center=�$��Center=����� *SummaryTotal.Open+� $��Bottom=�$��Right=�.+��� -   $��Img_Logo��$	��125��$��25��$
��Fill=�