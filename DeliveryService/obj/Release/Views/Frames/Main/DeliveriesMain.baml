   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DeliveryService.FramesDeliveryService.Frames  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  0    *DeliveryService.Frames.Main.DeliveriesMain   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:DeliveryService.Frames     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9
viewmodels(clr-namespace:DeliveryService.ViewModels    N� Title$  DeliveriesMain��$
��1230��$	��830�� � DataContext -  'DeliveryService.ViewModels.VMDeliveries  .���  � ColumnDefinitions �� $��8* ��� $��2* �.+�� $��0�� � RowDefinitions �� $��1* ��� $	��13* �.+�� $��0��4  .System.Windows.Automation.AutomationProperties   HelpText$! Введите запрос�� �� $
��377* ��� $	��85* �.+�� $��0��.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Введите запрос��$	��800��$��40��$��Center=�$��	10,10,0,5q�
���   � �� 
CaretBrush
 �   �$��20(�$! Введите запрос��
����������	#FFFFCD38���� *Search+� $��1��.+��� $��Right=�$��Center=�$��1��$��0, 0, 10, 0q�$��40��$	��152��.+��� ���	#FFFFCD38$��40��$	��120������ *SearchDelivery+.��� $	��120��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�$��5, 0, 10, 0q�
�������$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� 	 �� ScaleY$	 2Q�
 �� ScaleX$
 2Q��� �� T� �� $��Center=�$��
Поиск��
�������$��20(�� $��1��.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��10q�$��2������ *
Deliveries+ �� SelectedItem �� *SelectedDelivery+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding ��  �� Path$ ID�  $ Дата доставки��$
 auto  �� $ DateS�  $ Дистанция��$
 auto  �� $ Distance�  $ Цена/км��$
 auto  �� $ KmPrice�4
  .System.Windows.Controls.DataGridComboBoxColumn
  $ Курьер�� 
  SelectedValuePath$ ID�� 
  DisplayMemberPath$ CourierName��$
 auto  
  SelectedValueBinding �� *Courier_ID_FK+ 
  ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" N�$ DataContext.Courier� 
  EditingElementStyle �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Courier�
  $ Транспорт��$ ID��$ TransportName��$
 auto  �� *Transport_ID_FK+ �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Car� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Car�
  $ 
Номер��$ ID��$ Number��$
 auto  �� *Transport_ID_FK+ �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Car� �� " ��.���  � �� ��  �� *FindAncestor+" N�$ DataContext.Car�� $��1��.+��� .+��� $��	2,10,2,10q����	#FFFFCD38$��80������ *	Refresh+.��� $	��270��.+�  $ Refresh=�$��10, 0q�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $	 2Q�$
 2Q��� �� T� �� $��Center=�$��Обновить��
�������$��20(��� $��	2,10,2,10q����	#FFFFCD38$��80������ *CreateDelivery+.��� $	��270��.+�  $	 Add=�$��10, 0q�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $	 2Q�$
 2Q��� �� T� �� $��Center=�$��Добавить��
�������$��20(��� $��	2,10,2,10q����	#FFFFCD38$��80������ *EditDelivery+���� *SelectedDelivery+.��� $	��270��.+�  $
 Edit=�$��10, 0q�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $	 2Q�$
 2Q��� �� T� �� $��Center=�$ ��Редактировать��
�������$��20(��� $��	2,10,2,10q����	#FFFFCD38$��80������ *DeleteDelivery+���� *SelectedDelivery+.��� $	��270��.+�  $ Delete=�$��10, 0q�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $	 2Q�$
 2Q��� �� T� �� $��Center=�$��Удалить��
�������$��20(��� $��Bottom=�