   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DeliveryService.Frames.MainDeliveryService.Frames.Main  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  ,    &DeliveryService.Frames.Main.OrdersMain   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:DeliveryService.Frames.Main     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9
viewmodels(clr-namespace:DeliveryService.ViewModels    N� Title$  
OrdersMain��$
��1230��$	��830�� � DataContext (   "DeliveryService.ViewModels.VMOrder  .���  � ColumnDefinitions �� $��8* ��� $��2* �.+�� $��0�� � RowDefinitions �� $��1* ��� $	��13* �.+�� $��0��4  .System.Windows.Automation.AutomationProperties   HelpText$! Введите запрос�� �� $
��377* ��� $	��85* �.+�� $��0��.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Введите запрос��$	��800��$��40��$��Center=�$��	10,10,0,5q�
���   � �� 
CaretBrush
 �   �$��20(�$! Введите запрос��
����������	#FFFFCD38���� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��.+��� $��Right=�$��Center=�$��1��$��0, 0, 10, 0q�$��40��$	��152��.+��� ���	#FFFFCD38$��40��$	��120������ *SearchOrder+.��� $	��120��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�$��5, 0, 10, 0q�
�������$��Center=�	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� 
 �� ScaleY$
 2Q� �� ScaleX$ 2Q��� �� T� �� $��Center=�$��
Поиск��
�������$��20(�� $��1�� �� $	��81* ��� $��1015* �.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��10q�$��2������ *Orders+ �� SelectedItem �� *SelectedOrder+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding ��  �� Path$ ID�4
  .System.Windows.Controls.DataGridComboBoxColumn
  $ Клиент�� 
  SelectedValuePath$ ID�� 
  DisplayMemberPath$ CustomerName��$
 auto  
  SelectedValueBinding �� *Customer_ID_FK+$ PropertyChanged=� �� Mode$ TwoWay=� 
  ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" N�$ DataContext.Customer� 
  EditingElementStyle �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Customer�  $ Содержимое��$
 auto  �� $ 	OrderName�  $ Дата заказа��$
 auto  �� $ 
OrderDateS�  $ Крайний срок��$
 auto  �� $ 	DeadlineS�  $ Ценность��$
 auto  �� $ Price�  $ Стоимость��$
 auto  �� $
 Cost�  $! Адрес отправки��$
 auto  �� $ AdressOrigin�  $! Адрес доставки��$
 auto  �� $ AdressDestination�  $ Получатель��$
 auto  �� $ ReceiverName�
  $ Статус��$ ID��$ 
StatusName��$
 auto  �� *Status_ID_FK+$ PropertyChanged=�$ TwoWay=� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Status� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Status�
  $ Тип��$ ID��$ TypeName��$
 auto  �� *TypeOfCargo_ID_FK+$ PropertyChanged=�$ TwoWay=� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.TypeOfCargo� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.TypeOfCargo�  $ Код доставки��$
 auto  �� $ Delivery_ID_FK�
  $ Дата доставки��$ ID��$ DateS��$
 auto  �� *Delivery_ID_FK+$ PropertyChanged=�$ TwoWay=� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Delivery� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Delivery�
  $ Курьер��$ ID��$ CourierName��$
 auto  �� *Courier_ID_FK+$ PropertyChanged=�$ TwoWay=� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Couriers� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Couriers�  $ Комментарий��$
 auto  �� $ AddNote�� $��1��.+��� $	��Top=�.+��� $��	5,10,5,10q����	#FFFFCD38$��80������ *	Refresh+.��� $	��270��.+�  $ Refresh=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Обновить��
�������$��20(�$��27��$
��88,0q�$	��Top=��� $��	5,10,5,10q����	#FFFFCD38$��80������ *CreateOrder+.��� $	��270��.+�  $	 Add=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��
Новый��
�������$��20(��� $��	5,10,5,10q����	#FFFFCD38$��80������ *	EditOrder+���� *SelectedOrder+.��� $	��270��.+�  $
 Edit=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$ ��Редактировать��
�������$��20(��� $��	5,10,5,10q����	#FFFFCD38$��80������ *DeleteOrder+���� *SelectedOrder+.��� $	��270��.+�  $ Delete=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Удалить��
�������$��20(��� $��Bottom=�
�������$��5q�.+��� $��9��$��0��$��Center=�$��Курьер��
��� ���$��20(�$
��Bold"� �� TextAlignment$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142����   �� SelectedValuePath$  ID��! �� DisplayMemberPath$! CourierName��   MaterialDesignComboBox#���   $��1��$��Center=�$��9��$��Center=�$
��auto��$��20(����� *
Couriers+" �� SelectedValue" �� *SelectedOrder.Courier_ID_FK+$ PropertyChanged=�$ TwoWay=��� $��	5,10,5,20q����	#FFFFCD38$��80������ *AppointCourier+���� *SelectedOrder+.��� $	��270��.+�  $ Verified=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Назначить��
�������$��20(��� $��	5,10,5,10q����	#FFFFCD38$��80������ *MakeContract+���� *SelectedOrder+.��� $	��270��.+�  $ Contract=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Контракт��
�������$��20(�