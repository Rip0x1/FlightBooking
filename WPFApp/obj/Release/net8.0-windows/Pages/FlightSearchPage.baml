   M S B A M L   `   `   `  ����   FlightBooking*    $FlightBooking.Pages.FlightSearchPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  Поиск рейсов��.��� $��20q����#F5F6FA � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,20q����#2196F3$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�$��30��$��30��
��������� $7��1Поиск и управление рейсами��$��28(�$
��Bold"�
�������$��10,0,0,0q�z��� �� $��1��$��16(�
��� � �$��Center=�$��0,0,0,20q����� *NotificationMessage+y��� *NotificationMessage+   NullToVisibilityConverter �� 	Converter# [  �� $��2��
������ 	 � 	Resources	 
 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding ��Name �� Triggers P� Property P� Value �� 
TargetName��%P  '��       �� "
 ��.���  � �� �� " ��.R��� 
������ $
 10,5q�$��2q�._��� $ ContentSite��$��Center=�$��Center=�$��Header�� P�  �@��
IsSelected$
 True��. ��� $ ContentSite�� � �� �#2196F3��  � �� �#E3F2FDP�  �@J�IsMouseOver$
 True��. ���  � �� �#BBDEFB.@��� $��Поиск рейсов��.���  � ColumnDefinitions �� $��* ��� $
��1000 ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��0,0,0,20q����#B0BEC5$��2q�$ 15q�
�������$��1��$��Center=�   $ 5Q�$ 1Q�$ 	#33000000��._��� $ 
Horizontal=�.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Город��$	��250��$��0,0,20,0q� % !MaterialDesignFloatingHintTextBox#��[ ���� *
SearchCity+(  "System.Windows.Controls.DatePicker  $ Дата��$	��250��   SelectedDate �� *
SearchDate+��   MaterialDesignRaisedButton#��[ ���#2196F3
�������$	��150��$��40��$��20,0,0,0q����� *SearchCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ Magnify=�$��16��$��16��$��0,0,5,0q��� $��
Поиск���� $��1��$ 15q����#B0BEC5$��2q�
�������$��Center=�$��1��   $ 5Q�$ 1Q�$ 	#33000000��._��� $	��400������ *	Flights+ �� SelectedItem �� *SelectedFlight+ � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ (UIElement.Opacity)� W� From 0	 W� To 1 g� Duration$ 0:0:0.5D� �� View �� .P��� $��Номер рейса�� �� Width$
 Auto��  �� DisplayMemberBinding  �� *FlightNumber+�� $��Откуда��$
 Auto��  �� *DepartureCity+�� $��Куда��$
 Auto��  �� *ArrivalCity+�� $��Дата вылета��$
 Auto��  �� *DepartureTime+! �� StringFormat$! {0:dd/MM/yyyy HH:mm}���� $��Цена��$
 Auto��  �� *Price+$! {0:C}���� $��
Места��$
 Auto��  �� *AvailableSeats+���� "
 ��.���  � ��
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q�" �� Triggers" P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB�� $)��#Управление рейсами��.���  �� $
��Auto ��� $��* �.+��� $��0��$��0,0,0,20q����#B0BEC5$��2q�$ 15q�
�������$��Center=�   $ 5Q�$ 1Q�$ 	#33000000��._��� .+��� $)��#Управление рейсами��$��16(�$��Center=�$��0,0,0,10q��� $ 
Horizontal=�$��Center=�.+��� $	��150��$��40��$��0,0,10,0q�$ Номер рейса��  MaterialDesignTextBox#��[ ���� *NewFlight.FlightNumber+�� $	��150��$��40��$��0,0,10,0q�$ Откуда��#��[ ���� *NewFlight.DepartureCity+�� $	��150��$��40��$��0,0,10,0q�$ Куда��#��[ ���� *NewFlight.ArrivalCity+  $	��150��$��40��$��0,0,10,0q�$ 
Вылет�� �� *NewFlight.DepartureTime+  $	��150��$��40��$��0,0,10,0q�$ Прибытие�� �� *NewFlight.ArrivalTime+�� $	��100��$��40��$��0,0,10,0q�$ Цена��#��[ ���� *NewFlight.Price+$! {0:N2}���� $	��100��$��40��$��0,0,10,0q�$ 
Места��#��[ ���� *NewFlight.AvailableSeats+�� #��[ $	��150��$��40�����#4CAF50
�������$��0,0,10,0q����� *CreateFlightCommand+.���� $ 
Horizontal=�$��Center=�.+�  $
 Plus=�$��16��$��16��$��0,0,5,0q��� $��Создать���� #��[ $	��150��$��40�����#FF9800
�������$��0,0,10,0q����� *EditFlightCommand+{��� *SelectedFlight+  NullToBoolConverter# [ .���� $ 
Horizontal=�$��Center=�.+�  $ Pencil=�$��16��$��16��$��0,0,5,0q��� $ ��Редактировать���� #��[ $	��150��$��40�����#F44336
����������� *DeleteFlightCommand+{��� *SelectedFlight+# [ .���� $ 
Horizontal=�$��Center=�.+�  $ Delete=�$��16��$��16��$��0,0,5,0q��� $��Удалить���� $��1��$ 15q����#B0BEC5$��2q�
�������$��Center=�   $ 5Q�$ 1Q�$ 	#33000000��._��� $	��400������ *	Flights+ �� *SelectedFlight+ :� $ Loaded��.[��� .���� .��W� $ (UIElement.Opacity)� 0 1$ 0:0:0.5D� �� .P��� $��Номер рейса��$
 Auto��  �� *FlightNumber+�� $��Откуда��$
 Auto��  �� *DepartureCity+�� $��Куда��$
 Auto��  �� *ArrivalCity+�� $��Дата вылета��$
 Auto��  �� *DepartureTime+$! {0:dd/MM/yyyy HH:mm}���� $��Дата прилёта��$
 Auto��  �� *ArrivalTime+$! {0:dd/MM/yyyy HH:mm}���� $��Цена��$
 Auto��  �� *Price+$! {0:C}���� $��
Места��$
 Auto��  �� *AvailableSeats+���� "
 ��.���  � ��
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q�" P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB