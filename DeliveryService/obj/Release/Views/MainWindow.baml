   M S B A M L   `   `   `  ���� J  FDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DeliveryServiceDeliveryService  G(clr-namespace:DeliveryService.ViewModelsDeliveryService.ViewModels       DeliveryService.MainWindow   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:DeliveryService     ?
viewmodels(clr-namespace:DeliveryService.ViewModels       � Title$  Delivery Service Manager��$	��900��$
��1600�� J� RenderTransformOrigin$ 0.5,0.5&� � WindowStyle$
 None=�   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=�$	��900��$
��1600�� � Icon$6 0pack://siteoforigin:,,,/Resources/DSMIcon128.ico�� � DataContext -  'DeliveryService.ViewModels.VMMainWindow  .��� 	 � ColumnDefinitions	 �� $	��350 ��� $��1* �
 � RowDefinitions
 �� $��50 ��� $��* �.+� � -   $��	WorkFrame��$��1��$��1�����	#FFCFCFCF  � NavigationUIVisibility$ Hidden=�$��2������ *CurrentPage+� $��1������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFC5C5C5�� � Offset$ 1Q�� $ 	#FFE0E0E0��
 �� $	��170 ��� $��* � J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   Color$ 	#FFDEDEDE��   RenderingBias$ Quality=�   ShadowDepth$ 1Q�.+�� ���	#FFFFCD38.+��� $��	DASHTRACE��$��Center=�$��Center=�$7��1/DeliveryService;component/#WS Simple Gallifreyan)�$��36(����	#99FFFFFF�� $��1��.+��� -   $��OrderMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *OrderCommand+.��� $	��270��.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentPaste=�
�������$��Center=�$ 0.5,0.5&�z�V� .~���  �� ScaleY$ 3Q� �� ScaleX$ 3Q��� �� T� �� $��Right=�$��Заказы��
�������$��30(�$��0,0,85,0q��� -   $��DeliveryMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *DeliveryCommand+.��� $	��270��.+�  $ TruckDelivery=�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��Доставки��
�������$��30(��� -   $��ClientMenuButton��$��2,10,2,5q����	#FFFFCD38$��80��$��30(����� *ClientCommand+.��� $	��270��.+�  $ Person=�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��Клиенты��
�������$��30(��� -   $��CourierMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *CourierCommand+.��� $	��270��.+�  $ Worker=�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Right=�$��Курьеры��
�������$��30(�$��0,0,74,0q��� -   $��CarMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *TransportCommand+.��� $	��270��.+�  $	 Car=�
�������$��Center=�$ 0.5,0.5&�$��30(�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��Транспорт��
�������$��30(��� -   $��CargoTypeMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *TypeOfCargoCommand+.��� $	��270��.+�  $ Weight=�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��Типы грузов��
�������$��30(��� -   $��StatusMenuButton��$��2,10,2,5q����	#FFFFCD38$��80������ *StatusCommand+.��� $	��270��.+�  $ 
ListStatus=�
�������$��Center=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��Статусы��
�������$��30(�� -	    �Name$ UpperBar��$��3��
��� ���.+���  �� Orientation$ 
Horizontal=�$
��Left=�$��10, 0q�.+�  $ DeliveryDiningOutline=�
�������$��Center=�$��10q�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� $��Center=�$��10, 0q�$��Delivery Service Manager��$��24(�$
��Bold"����	#DDFFFFFF�� $ 
Horizontal=�$��Right=�$��10, 0q�.+��� -
    ��Name$ NormalSizeButton�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��5q�$y�	Collapsed=�$��45��$��45��
���������Z� ��Z� .��  $ Resize=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� -   $ FullSizeButton��#��[ $��5q�$��45��$��45��
���������Z� ��Z� .��  $ ArrowExpandAll=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� �� -   $ CloseButton��#��[ $��5q�$��45��$��45��
���������Z� ��Z� .��  $ Power=�$ 0.5,0.5&�z�V� .~��� $ 3Q�$ 3Q��� �� T� 