   M S B A M L   `   `   `  ����   FlightBooking%    FlightBooking.Pages.BookingPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  Мои брони��.��� $��20q����#F5F6FA � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,20q����#F44336$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	BookImage=�$��30��$��30��
��������� $��
Брони��$��28(�$
��Bold"�
�������$��10,0,0,0q�z��� �� $��1��$��16(�
��� � �$��Center=�$��0,0,0,20q����� *NotificationMessage+y��� *NotificationMessage+   NullToVisibilityConverter �� 	Converter# [  �� $��2��$
��Auto=�.��� $
��1200��$��Center=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0,0,0,20q����#B0BEC5$��2q�	 �� CornerRadius$	 10��
 �� Padding$
 15q�
�������._��� .+��� $��Выберите рейс��$��16(�$��Center=�$��0,0,0,10q���  �� DisplayMemberPath$ FlightNumber��  MaterialDesignComboBox#��[ $	��300��$��40�� �� 
IsEditable$ False�� �� 
IsReadOnly$ False�� �� SelectedIndex$ 0������ *	Flights+ �� SelectedItem �� *SelectedFlight+�� $��1��$��0,0,0,20q����#B0BEC5$��2q�$	 10��$
 15q�
�������._��� .+��� $%��Выберите клиента��$��16(�$��Center=�$��0,0,0,10q��� $ FullName�� �� SelectedValuePath$ UserId��#��[ $	��300��$��40��$ False��$ False��$ 0������ *Users+ �� SelectedValue �� *SelectedUserId+�� $��2��$ 
Horizontal=�$��Center=�$��0,0,0,20q�.+��� $ ��Забронировать��  MaterialDesignRaisedButton#��[ $	��200��$��40�����#2196F3
�������$��0,0,15,0q����� *BookCommand+�� $!��Отменить бронь��#��[ $	��200��$��40�����#F44336
�������$��0,0,15,0q����� *CancelBookingCommand+���� *SelectedBooking+{��� *SelectedBooking+  NullToBoolConverter# [ �� $	��200��$��40��#��[ $��0,0,15,0q����� *StatusOptions+ �� *SelectedBooking.Status+{��� *SelectedBooking+# [ �� $#��Обновить статус��#��[ $	��200��$��40�����#4CAF50
�������$��0,0,15,0q����� *UpdateStatusCommand+���� *SelectedBooking+{��� *SelectedBooking+# [ �� $��Экспорт в Excel��#��[ $	��200��$��40�����#9E9E9E
�������$��0,0,0,0q����� *ExportToExcelCommand+�� $��3��$
 15q����#B0BEC5$��2q�$	 10��
�������$��Center=�._��� $	��400������ *
Bookings+ �� *SelectedBooking+ �� View �� .P��� $��Номер брони�� �� Width$
 Auto�� �� DisplayMemberBinding �� *	BookingId+�� $��Рейс��$
 Auto�� �� *Flight.FlightNumber+�� $��Клиент��$
 Auto�� �� *User.FullName+�� $��Дата брони��$
 Auto�� �� *BookingDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}���� $��Статус��$
 Auto�� �� *Status+����  �� 
TargetType" ��.���  �� Property � �� �� Value
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB