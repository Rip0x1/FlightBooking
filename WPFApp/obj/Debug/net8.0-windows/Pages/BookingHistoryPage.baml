   M S B A M L   `   `   `  ����  FlightBooking,    &FlightBooking.Pages.BookingHistoryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$-  'История бронирований��5      .��5      � $��20q�6   ���#F5F6FA � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20q�6   $��0,0,0,20q�6+   ���#FF5722$��0��6R    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      ShadowDepth$ 2Q�63      Color$ 	#66000000��6C   .��5      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ History=�6*   $��30��69   $��30��6D   
�������6P   �� 5      $-��'История бронирований��6   $��28(�68   $
��Bold"�6F   
�������$��10,0,0,0q�6k   z�5      �� 5      5      5      5      �� 5   
   $��1��6   $��16(�6F   
��� � �$��Center=�5      $��0,0,0,20q�61   ��5   !   �� *NotificationMessage+y�5      �� *NotificationMessage+   NullToVisibilityConverter �� 	Converter# [  �� 5   
   $��2��6   
������ 	 � 	Resources	 5       
 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding ��Name �� Triggers P� Property P� Value �� 
TargetName��%<  '��       �� 5!      "
 ��6   .�5"      ��  � �� 5#      �� 5$      " ��6.   .R�5%   "   �� 
������ $
 10,5q�6B   $��2q�6Q   ._�5&   &   �� $ ContentSite��67   $��Center=�6L   $��Center=�6g   $��Header��5'   7   5(   #    5)   "   P� 5*   &    �@��
IsSelected$
 True��6D   . �5+   *   �� $ ContentSite��61    � �� �#FF57226l   �� 5,   *    � �� �#E3F2FD6G   5-   '   P� 5.   &    �@J�IsMouseOver$
 True��6E   . �5/   *   ��  � �� �#BBDEFB6G   50   '   52      54      55      56      .@�57      �� $��Просмотр��6   .��58      �  59      �� 5:      $
��Auto �6(   �� 5;      $��* �6(   .+�5=      �� $��0��6   $��0,0,0,20q�6*   ���#B0BEC5$��2q�6R   $ 15q�6f   
������� 5>        5?      $ 5Q�6/   $ 1Q�6>   $ 	#33000000��6N   ._�5A      �� .+�5B      �� $��Фильтры��6(   $��16(�67   $��Center=�6E   $��0,0,0,10q�6b   �� 5C      $ 
Horizontal=�6)   $��Center=�6B   .+�5D   "   �� $	��200��5E   +     MaterialDesignComboBox#��[ 67   $��0,0,20,0q�6g   ��5D   +   �� *StatusOptions+ �� SelectedItem 6Q   �� *SelectedStatus+5E   g   �� 5F   "     MaterialDesignRaisedButton#��[ 6L   $	��150��5G   )   $��40��65   ���#FF5722
�������$��0,0,0,0q�6i   ��5F   )   �� *RefreshCommand+.��5H   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5I   *     $ Refresh=�6B   $��16��6Q   $��16��6\   $��0,0,5,0q�6h   �� 5J   *   $��Обновить��64   5K   '   5L   #   5M      5N      5O      �� 5P      $��1��6   $ 15q�6*   ���#B0BEC5$��2q�6M   
�������$��Center=�6t    5Q        5R      $ 5Q�6/   $ 1Q�6>   $ 	#33000000��6N   ._�5T      �� $	��400��6D   ��6#   �� *
Bookings+ � Triggers 5U      :� 5V   "    :� RoutedEvent$ Loaded��6/   .[�5W   &   �� .��5X   *   �� .��5Y   .   W�  �� TargetProperty$ (UIElement.Opacity)�6>    W� From 06n   	 W� To 16w    g� Duration$ 0:0:0.5D�6~   5Z   +   5[   '   5\   #    �� View 5^      �� 5_   "   .P�5`   &   �� $��Номер брони��65    �� Width$
 Auto��6u    �� DisplayMemberBinding 6J   �� *	BookingId+6u   �� 5a   &   $��Рейс��65   $
 Auto��6x    6C   �� *Flight.FlightNumber+6x   �� 5b   &   $��Клиент��65   $
 Auto��6t    6E   �� *User.FullName+6t   �� 5c   &   $��Дата��65   $
 Auto��6�    6C   �� *BookingDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��6�   �� 5d   &   $��Статус��65   $
 Auto��6m    6E   �� *Status+6m   5e   #   ��5g      �� 5h   "   "
 ��6(   .�5i   &   ��  � ��
 �����6C   �� 5j   &    � �� �#E0E0E06D   �� 5k   &    � ��$ 0,0,0,1q�6H    �� Triggers 5l   &   P� 5m   *    �@J�IsMouseOver$
 True��6I   . �5n   .   ��  � �� �#E3F2FD6K   5o   +   P� 5p   *    �@��
IsSelected$
 True��6H   . �5q   .   ��  � �� �#BBDEFB6K   5r   +   5t   #   5v      5w      5x      5y      5z      5{      5|      