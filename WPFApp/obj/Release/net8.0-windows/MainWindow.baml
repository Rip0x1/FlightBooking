   M S B A M L   `   `   `  ����   FlightBooking    FlightBooking.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
SkyBooking�� � WindowState$ 	Maximized=����#F5F6FA � Cursor$  ��.��� $��30q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,30q����#2196F3 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 AirplaneTakeoff=�$��40��$��40��
��������� $��
SkyBooking��$��32(�$
��Bold"�
�������$��10,0,0,0q�  $��1��$��20q����#E3F2FD$��0,0,0,30q�   $ 5Q�$ 1Q�$ 	#33000000��.���� $��Center=�$ 
Horizontal=�.+��� -      MaterialDesignRaisedButton#��[  ���#2196F3
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 Magnify=�$��16��$��16��$��0,0,5,0q��� $��Поиск рейсов��
 � Triggers
 :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$ Width� W� From 150	 W� To 160 g� Duration$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  ���#F44336
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 CalendarCheck=�$��16��$��16��$��0,0,5,0q��� $��
Брони��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  ���#9C27B0
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 AccountMultiple=�$��16��$��16��$��0,0,5,0q��� $��Клиенты��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  ���#4CAF50
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 ChartBar=�$��16��$��16��$��0,0,5,0q��� $��Отчёты��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  
�������
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 Payment=�$��16��$��16��$��0,0,5,0q��� $��Платежи��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  ���#FF5722
�������$	��160��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 Logout=�$��16��$��16��$��0,0,5,0q��� $��История брони��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D��� -   #��[  
���  ��
�������$	��150��$��40��$
��20,0q�.���� $ 
Horizontal=�$��Center=�.+�  $	 Logout=�$��16��$��16��$��0,0,5,0q��� $��
Выход��
 :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 150 160$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 160 150$ 0:0:0.2D� � -     �Name$ 	MainFrame��$��2��  � NavigationUIVisibility$ Hidden=�