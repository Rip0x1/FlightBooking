   M S B A M L   `   `   `  ����   FlightBooking%    FlightBooking.Pages.ReportsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  Отчёты��.��� $��20q����#F5F6FA � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,20q����#4CAF50$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChartBar=�$��30��$��30��
��������� $��Отчёты��$��28(�$
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
 True��. ��� $ ContentSite�� � �� �#4CAF50��  � �� �#E3F2FDP�  �@J�IsMouseOver$
 True��. ���  � �� �#BBDEFB.@��� $��Статистика��.���  �� $
��Auto ��� $��* �.+��� $��0��$��0,0,0,20q�.+��� $4��.Статистика бронирований:��$��18(�$
��Bold"�$��Center=�$��0,0,0,10q��� $ ��Подтверждено: �� � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$8 2(TextBlock.RenderTransform).(TranslateTransform.X)� W� From -50	 W� To 0 g� Duration$ 0:0:0.5D�z�T� �� $��16(����#2196F3$��	20,0,0,10q����� *ConfirmedCount+ :� $ Loaded��.[��� .���� .��W� $8 2(TextBlock.RenderTransform).(TranslateTransform.X)� -50 0$ 0:0:0.5D�z�T� �� $��Завершено: �� :� $ Loaded��.[��� .���� .��W� $8 2(TextBlock.RenderTransform).(TranslateTransform.X)� -50 0$ 0:0:0.5D�z�T� �� $��16(����#2196F3$��20,0,0,0q����� *CompletedCount+ :� $ Loaded��.[��� .���� .��W� $8 2(TextBlock.RenderTransform).(TranslateTransform.X)� -50 0$ 0:0:0.5D�z�T� �� $��1��$ 15q����#B0BEC5$��2q�
�������$��Center=�   $ 5Q�$ 1Q�$ 	#33000000��._��� $	��300������ *
Bookings+ :� $ Loaded��.[��� .���� .��W� $ (UIElement.Opacity)� 0 1$ 0:0:0.5D� �� View �� .P��� $��Номер брони�� �� Width$
 Auto�� �� DisplayMemberBinding �� *	BookingId+�� $��Рейс��$
 Auto�� �� *Flight.FlightNumber+�� $��Клиент��$
 Auto�� �� *User.FullName+�� $��Дата��$
 Auto�� �� *BookingDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}���� $��Статус��$
 Auto�� �� *Status+���� "
 ��.���  � ��
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q� �� Triggers P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB�� $��Экспорт��.���  �� $
��Auto ��� $��* �.+��� $��0��$ 
Horizontal=�$��Center=�$��0,0,0,20q�.+���   MaterialDesignRaisedButton#��[ $	��200��$��40�����#4CAF50
�������$��0,0,20,0q����� *RefreshCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ Refresh=�$��16��$��16��$��0,0,5,0q��� $#��Обновить данные�� :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 200 210$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 210 200$ 0:0:0.2D��� #��[ $	��200��$��40�����#9E9E9E
����������� *ExportToPdfCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ 
FilePdfBox=�$��16��$��16��$��0,0,5,0q��� $��Экспорт в PDF�� :� $ 
MouseEnter��.[��� .���� .��W� $ Width� 200 210$ 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $ Width� 210 200$ 0:0:0.2D�