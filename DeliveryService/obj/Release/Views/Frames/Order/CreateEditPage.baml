   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DeliveryService.Views.Frames.Order"DeliveryService.Views.Frames.Order  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  7    1DeliveryService.Views.Frames.Order.CreateEditPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:DeliveryService.Views.Frames.Order     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9
viewmodels(clr-namespace:DeliveryService.ViewModels  $
��1230��$	��830��  N� Title$  CreateEditPage�� � DataContext 2   ,DeliveryService.ViewModels.VMOrderCreateEdit  .���� .���  � ColumnDefinitions �� $��1* ��� $��3* ��� $��1* �.+�� $��1��
������� �� $��1* ��� $��2* � � RowDefinitions �� $��1* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $��0��$��0��$��Center=�
�������$��15(� �� TextAlignment$ Center=�$��Center=����� *Textst+��  &  "MaterialDesignToolForegroundButton#���   $��0��$��1��$
��Auto��$��Right=�$��Center=����� *CreateUpdateCommand+���� *SelectedOrder+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSaveOutline=�
�������$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�$��44��$��44��$��Center=��� $��1��$��0��$��Center=�$'��!Содержимое заказа��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��28��$	��229��$
��7,24q��� $��1��$��1��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Введите название��
���   �$��20(� �� 
CaretBrush
 �   �4  .System.Windows.Automation.AutomationProperties	   HelpText$%	 Введите название��
����������	#FFFFCD38$��
0,20,10,20q����� *SelectedOrder.OrderName+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��2��$��0��$��Center=�$-��'Объявленная ценность��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��28��$	��229���� $��2��$��1��$% Введите ценность��
���   �$��20(�
 �   �$!	 Введите запрос��
����������	#FFFFCD38$��
0,20,10,20q����� *SelectedOrder.Price+$
 PropertyChanged=��� $��3��$��0��$��Center=�$#��Начальный адрес��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��36,33,35,32q�$��27��$	��175���� $��3��$��1��$ Введите адрес��
���   �$��20(�
 �   �$!	 Введите запрос��
����������	#FFFFCD38$��
0,26,10,26q����� *SelectedOrder.AdressOrigin+$
 PropertyChanged=��� $��4��$��0��$��Center=�$!��Конечный адрес��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��42,33,41,32q�$��27��$	��163���� $��4��$��1��$ Введите адрес��
���   �$��20(�
 �   �$!	 Введите запрос��
����������	#FFFFCD38$��
0,26,10,26q����� *!SelectedOrder.AdressDestination+$
 PropertyChanged=��� $��5��$��0��$��Center=�$!��Имя получателя��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��42,33q�$��27��$	��162���� $��5��$��1��$) #Введите получателя��
���   �$��20(�
 �   �$!	 Введите запрос��
����������	#FFFFCD38$��
0,27,10,26q����� *SelectedOrder.ReceiverName+$
 PropertyChanged=��� $��6��$��0��$��Center=�$��Примечание��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��61,33,60,32q�$��27��$	��125���� $��6��$��1��$) #Введите примечание��
���   �$��20(�
 �   �$!	 Введите запрос��
����������	#FFFFCD38$��
0,26,10,26q����� *SelectedOrder.AddNote+$
 PropertyChanged=��� $��7��$��0��$��Center=�$��Крайний срок��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142��(  "System.Windows.Controls.DatePicker  $��1��$��Center=�$��7��$��Center=�$	��200��$��20(�   SelectedDate �� *SelectedOrder.Deadline+$
 PropertyChanged=��� $��8��$��0��$��Center=�$��Тип груза��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142����  �� SelectedValuePath$ ID�� �� DisplayMemberPath$ TypeName��  MaterialDesignComboBox#���  $��1��$��Center=�$��8��$��Center=�$
��auto��$��20(����� *TypeOfCargo+ �� SelectedValue �� *!SelectedOrder.TypeOfCargo_ID_FK+$
 PropertyChanged=� �� Mode$ TwoWay=��� $��9��$��0��$��Center=�$��Клиент��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142���� $ ID��$ CustomerName��#���  $��1��$��Center=�$��9��$��20(�$��Center=�$
��auto������ *
Customer+ �� *SelectedOrder.Customer_ID_FK+$
 PropertyChanged=�$ TwoWay=��� $��10��$��0��$��Center=�$��Курьер��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142���� $ ID��$ CourierName��#���  $��1��$��Center=�$��10��$��Center=�$
��auto��$��20(����� *
Couriers+ �� *SelectedOrder.Courier_ID_FK+$
 PropertyChanged=�$ TwoWay=�