   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:DeliveryService.Views.Frames.Delivery%DeliveryService.Views.Frames.Delivery  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  >    8DeliveryService.Views.Frames.Delivery.CreateEditDelivery   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Elocal3clr-namespace:DeliveryService.Views.Frames.Delivery     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9
viewmodels(clr-namespace:DeliveryService.ViewModels  $
��1230��$	��830��  N� Title$  CreateEditDelivery�� � DataContext 5   /DeliveryService.ViewModels.VMDeliveryCreateEdit  .���� .���  � RowDefinitions �� $��1* ��� $��1* � � ColumnDefinitions �� $��1* ��� $��3* ��� $��1* �.+�� $��1��
������� �� $��1* ��� $��2* � �� $��1* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $��0��$��0��$��Center=�
�������$��15(� �� TextAlignment$ Center=�$��Center=����� *Textst+��  &  "MaterialDesignToolForegroundButton#���   $��0��$��1��$
��Auto��$��Right=�$��Center=����� *CreateUpdateCommand+���� *SelectedOrder+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSaveOutline=�
�������$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�$��44��$��44��$��Center=��� $��1��$��0��$��Center=�$��Дистанция��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��28��$	��229���� $��1��$��1��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите длину��
���   �$��20(� �� 
CaretBrush
 �   �4  .System.Windows.Automation.AutomationProperties	   HelpText$%	 Введите дину в км��
����������	#FFFFCD38$��Center=�$��Center=����� *SelectedDelivery.Distance+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��2��$��0��$��Center=�$��Цена за км��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��36,33,35,32q�$��27��$	��175���� $��2��$��1��$ Введите цену��
���   �$��20(�
 �   �$	 Введите цену��
����������	#FFFFCD38$��
0,26,10,26q�$��Center=�$��Center=����� *SelectedDelivery.KmPrice+$
 PropertyChanged=��� $��3��$��0��$��Center=�$��Дата��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142��(  "System.Windows.Controls.DatePicker  $��1��$��Center=�$��3��$��Center=�$	��200��$��20(�   SelectedDate �� *SelectedDelivery.Date+$
 PropertyChanged=��� $��4��$��0��$��Center=�$��Транспорт��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142����  �� SelectedValuePath$ ID�� �� DisplayMemberPath$ Number��  MaterialDesignComboBox#���  $��1��$��Center=�$��4��$��Center=�$
��auto��$��20(����� *Car+ �� SelectedValue �� *" SelectedDelivery.Transport_ID_FK+$
 PropertyChanged=� �� Mode$ TwoWay=��� $��5��$��0��$��Center=�$��Курьер��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��52,33,52,32q�$��27��$	��142���� $ ID��$ CourierName��#���  $��1��$��Center=�$��5��$��Center=�$
��auto��$��20(����� *
Couriers+ �� *Cour+$
 PropertyChanged=�$ TwoWay=�� $��1��$��1�� �� $
��auto ��� $��1* �.+��� $��Заказы��
��� ���
�������$��20(�$
��Bold"�$ Center=�$��Center=�&   System.Windows.Controls.DataGrid  $��1��   AutoGenerateColumns .  ���� *Orders+ �� SelectedItem �� *SelectedOrder+   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Доставлен��   Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	    
IsReadOnly .  1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding ��  �� Path$ inDeliv�0  *System.Windows.Controls.DataGridTextColumn  $ ID��$
 auto	  .  �� $ order.ID�  $ Стоимость��$
 auto	  .  �� $ 
order.Cost�  $! Адрес доставки��$
 auto	  .  �� $ order.AdressDestination�  $ Получатель��$
 auto	  .  �� $ order.ReceiverName�