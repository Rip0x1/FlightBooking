   M S B A M L   `   `   `  ����  FlightBooking%    FlightBooking.Pages.BookingPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Мои брони��5      .��5      � $��20q�6   ���#F5F6FA � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20q�6   $��0,0,0,20q�6+   ���#2196F3$��0��6R    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      ShadowDepth$ 2Q�63      Color$ 	#66000000��6C   .��5      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	BookImage=�6*   $��30��6;   $��30��6F   
�������6R   �� 5      $��
Брони��6   $��28(�6)   $
��Bold"�67   
�������$��10,0,0,0q�6\    � Triggers 5      :� 5      	 :� RoutedEvent$	 Loaded��6'   .[�5      �� .��5   "   �� 5   #   5      5      z�5       �� 5!      5#      5$      5%      �� 5'   
   $��1��6   $��16(�6F   
��� � �$��Center=�5(      $��0,0,0,20q�61   ��5'   !   �� *NotificationMessage+y�5(   C   �� *NotificationMessage+   NullToVisibilityConverter
 �� 	Converter#
 [  �� 5*   
   $��2��6   $
��Auto=�6$   .��5+      � $
��1200��6   $��Center=�6#    5,      �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   .+�53      �� $��0��6   $��0,0,0,20q�6&   ���#B0BEC5$��2q�6N    �� CornerRadius$ 10��6b    �� Padding$ 15q�6t   
�������._�54      �� .+�55      �� $��Выберите рейс��6$   $��16(�69   $��Center=�6G   $��0,0,0,10q�6d   �� 56       �� DisplayMemberPath$ FlightNumber��6C     MaterialDesignComboBox#��[ 57   #   $	��300��6S   $��40��6_    �� 
IsEditable$ False��58   #    �� 
IsReadOnly$ False��66    �� SelectedIndex$ 0��6I   ��56   #   �� *	Flights+ �� SelectedItem 6d   �� *SelectedFlight+58   I   59      5:      �� 5<      $��1��6   $��0,0,0,20q�6&   ���#B0BEC5$��2q�6N   $ 10��6b   $ 15q�6t   
�������._�5=      �� .+�5>      �� $%��Выберите клиента��6$   $��16(�6<   $��Center=�6J   $��0,0,0,10q�6g   �� 5?      $ FullName��6A    �� SelectedValuePath$ UserId��5@   #   #��[ 6>   $	��300��6n   $��40��6z   $ False��5A   #   $ False��66   $ 0��6I   ��5?   #   �� *Users+ �� SelectedValue 6^   �� *SelectedUserId+5A   I   5B      5C      �� 5E      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $��0,0,0,20q�6`   .+�5F      �� $ ��Забронировать��6     MaterialDesignRaisedButton#��[ 5G      $	��200��6Q   $��40��6]   ���#2196F3
�������$��0,0,15,0q�5H   E   ��5F   5   �� *BookCommand+5H   E   �� 5I      $!��Отменить бронь��6   #��[ 5J      $	��200��6Q   $��40��6]   ���#F44336
�������$��0,0,15,0q�5L      ��5I   6   �� *CancelBookingCommand+��6_   �� *SelectedBooking+{�5K   E   �� *SelectedBooking+  NullToBoolConverter#
 [ 5L      �� 5M      $	��200��5N      $��40��6+   #��[ 67   $��0,0,15,0q�6g   ��5M      �� *StatusOptions+ 6E   �� *SelectedBooking.Status+{�5O      �� *SelectedBooking+#
 [ �� 5P      $#��Обновить статус��6   #��[ 5Q      $	��200��6Q   $��40��6]   ���#4CAF50
�������$��0,0,15,0q�5S      ��5P   7   �� *UpdateStatusCommand+��6_   �� *SelectedBooking+{�5R   E   �� *SelectedBooking+#
 [ 5S      �� 5T      $��Экспорт в Excel��6   #��[ 5U      $	��200��6Q   $��40��6]   ���#9E9E9E
�������$��0,0,0,0q�5V   E   ��5T   7   �� *ExportToExcelCommand+5V   E   5W      �� 5Y      $��3��6   $ 15q�6&   ���#B0BEC5$��2q�6I   $ 10��6]   
�������$��Center=�6�   ._�5Z      �� $	��400��6i   ��6   �� *
Bookings+ 6@   �� *SelectedBooking+ �� View 5[      �� 5\      .P�5]   "   �� $��Номер брони��61    �� Width$
 Auto��6q    �� DisplayMemberBinding 6F   �� *	BookingId+6q   �� 5^   "   $��Рейс��61   $
 Auto��6t    6?   �� *Flight.FlightNumber+6t   �� 5_   "   $��Клиент��61   $
 Auto��6p    6A   �� *User.FullName+6p   �� 5`   "   $��Дата брони��61   $
 Auto��6�    6E   �� *BookingDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��6�   �� 5a   "   $��Статус��61   $
 Auto��6i    6A   �� *Status+6i   5b      ��5d      �� 5e       �� 
TargetType" ��6$   .�5f   "   ��  �� Property � �� �� Value
 �����6?   �� 5g   "    � �� �#E0E0E06@   �� 5h   "    � ��$ 0,0,0,1q�6D    �� Triggers 5i   "   P� 5j   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5k   *   ��  � �� �#E3F2FD6G   5l   '   P� 5m   &    �@��
IsSelected$
 True��6D   . �5n   *   ��  � �� �#BBDEFB6G   5o   '   5q      5s      5t      5u      5v      5w      5x      