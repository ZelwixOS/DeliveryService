   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:DeliveryService.Views.Frames.Courier$DeliveryService.Views.Frames.Courier  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels  8    2DeliveryService.Views.Frames.Courier.SalaryCounter   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >local2clr-namespace:DeliveryService.Views.Frames.Courier  9
viewmodels(clr-namespace:DeliveryService.ViewModels  $
��1230��$	��830��  N� Title$  SalaryCounter�� � DataContext 0   *DeliveryService.ViewModels.VMCourierSalary  .���� .���  � ColumnDefinitions �� $��1* ��� $��3* ��� $��1* � � RowDefinitions �� $
��auto ��� $
��auto �.+�� $��1��$��0��
������� �� $��1* ��� $��1* ��� $
��auto �.+�� $��0�� �� $
��auto ��� $
��auto �.+��� $��0��$��Center=�$��Расчёт с:��
��� ���$��20(�$
��Bold"� �� TextAlignment$ Center=�$��Center=�$��27��$	��142��(  "System.Windows.Controls.DatePicker  $��Center=�$��1��$��Center=�$	��200��$��20(�   SelectedDate �� *	StartDT+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1�� �� $
��auto ��� $
��auto �.+��� $��0��$��Center=�$��и до:��
��� ���$��20(�$
��Bold"�$ Center=�$��Center=�$��27��$	��142��  $��Center=�$��1��$��Center=�$	��200��$��20(� �� *
FinishDT+$ PropertyChanged=���  &  "MaterialDesignToolForegroundButton#���   $��2��$
��Auto��$��Right=�$��Center=����� *
CountSal+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Forward=�
��� ���$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�$��44��$��44��$��Center=�&   System.Windows.Controls.DataGrid  $��1��$��1��	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $��5q����� *CourierSalaries+ �� SelectedItem �� *SelectedSalary+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ ID�  $ ФИО Курьера��$ 3*  �� $ CourierName�  $ 
Сумма��$ 1*  �� $ Salary�