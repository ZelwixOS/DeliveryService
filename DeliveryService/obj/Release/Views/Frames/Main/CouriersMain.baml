   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DeliveryService.FramesDeliveryService.Frames  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  .    (DeliveryService.Frames.Main.CouriersMain   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:DeliveryService.Frames     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9
viewmodels(clr-namespace:DeliveryService.ViewModels    N� Title$  CouriersMain��$
��1230��$	��830�� � DataContext +  %DeliveryService.ViewModels.VMCouriers  .���  � ColumnDefinitions �� $��8* ��� $��2* �.+�� $��0�� � RowDefinitions �� $��1* ��� $	��13* �.+�� $��0��4  .System.Windows.Automation.AutomationProperties   HelpText$! Введите запрос�� �� $
��377* ��� $	��85* �.+�� $��0��.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Введите запрос��$	��800��$��40��$��Center=�$��	10,10,0,5q�
���   � �� 
CaretBrush
 �   �$��20(�$! Введите запрос��
����������	#FFFFCD38���� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��.+��� $��Right=�$��Center=�$��1��$��0, 0, 10, 0q�$��40��$	��152��.+��� ���	#FFFFCD38$��40��$	��120������ *SearchCourier+.��� $	��120��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�$��5, 0, 10, 0q�
�������$��Center=�	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� 
 �� ScaleY$
 2Q� �� ScaleX$ 2Q��� �� T� �� $��Center=�$��
Поиск��
�������$��20(�� $��1��.+�&   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . $��10q�$��2������ *
Couriers+ �� SelectedItem �� *SelectedCourier+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding ��  �� Path$ ID�  $ ФИО Курьера��$ 3*  �� $ CourierName�  $ Телефон��$ 1*  �� $ PhoneNumber�� $��1��.+��� .+��� $��	2,10,2,10q����	#FFFFCD38$��80������ *	Refresh+.��� $	��270��.+�  $ Refresh=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Обновить��
�������$��20(��� $��	2,10,2,10q����	#FFFFCD38$��80������ *SalaryCount+.��� $	��270��.+�  $ CalculatorVariant=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$#��Расчёт зарплаты��
�������$��20(��� $��Bottom=�.+��� 
�������$��2q�.+��� $��Center=�$��ФИО Курьера��
��� ���$��20(�$
��Bold"� �� TextAlignment$ Center=�$��Center=�$��28��$	��229���� $��1��$��1��$ Введите ФИО��
���   �$��20(�
 �   �$ Введите ФИО��
����������	#FFFFCD38$��10,20,10,10q����� *SelectedCourier.CourierName+$ PropertyChanged=��� $��Center=�$��Телефон��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��28��$	��229���� $��1��$��1��$ Введите номер��
���   �$��20(�
 �   �$ Введите номер��
����������	#FFFFCD38$��10,20,10,10q����� *SelectedCourier.PhoneNumber+$ PropertyChanged=��� $��	2,10,2,10q����	#FFFFCD38$��80������ *CreateCourier+$ PropertyChanged=�.��� $	��270��.+�  $��10, 0q�
�������$��Center=�$	 0.5,0.5&� �� *
KindCreate+$ PropertyChanged=�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�
�������$��20(����� *
TextCreate+�� $��	2,10,2,10q����	#FFFFCD38$��80������ *EditCourier+���� *SelectedClient+$ PropertyChanged=�.��� $	��270��.+�  $
 Edit=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$ ��Редактировать��
�������$��20(��� $��	2,10,2,10q����	#FFFFCD38$��80������ *DeleteCourier+���� *SelectedClient+.��� $	��270��.+�  $ Delete=�$��10, 0q�
�������$��Center=�$	 0.5,0.5&�z�V� .~��� $
 2Q�$ 2Q��� �� T� �� $��Center=�$��Удалить��
�������$��20(�