   M S B A M L   `   `   `  ����   FlightBooking&     FlightBooking.Pages.PaymentsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  Платежи��.��� $��20q����#F5F6FA � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,20q�
�������$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChartBar=�$��30��$��30��
��������� $��Платежи��$��28(�$
��Bold"�
�������$��10,0,0,0q�z��� �� $��1��$��16(�
��� � �$��Center=�$��0,0,0,20q����� *NotificationMessage+y��� *NotificationMessage+   NullToVisibilityConverter �� 	Converter# [  �� $��2��$
��Auto=�.��� $
��1200��$��Center=� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0,0,0,20q����#B0BEC5$��2q�	 �� CornerRadius$	 10��
 �� Padding$
 15q�
�������._��� .+��� $!��Выберите бронь��$��16(�$��Center=�$��0,0,0,10q���  �� DisplayMemberPath$ 	BookingId�� �� SelectedValuePath$ 	BookingId��$	��300��$��40��$��Center=�$��0q�  MaterialDesignComboBox#��[  �� 
IsEditable$ False�� �� 
IsReadOnly$
 True�� �� SelectedIndex$ 0������ *AvailableBookings+ �� SelectedValue �� *NewPayment.BookingId+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��1��$��0,0,0,20q����#B0BEC5$��2q�$	 10��$
 15q�
�������._��� .+��� $!��Детали платежа��$��16(�$��Center=�$��0,0,0,10q��� $ 
Horizontal=�$��Center=�.+��� $	��150��$��40��$��Center=�$��0,0,10,0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Сумма��  MaterialDesignTextBox#��[ ���� *NewPayment.Amount+ �� StringFormat$ {0:N2}��$ PropertyChanged=��� $	��150��$��40��$��Center=�$��0,0,10,0q�$ Метод оплаты��#��[ ���� *NewPayment.PaymentMethod+�� $	��150��$��40��$��Center=�$��0,0,10,0q�#��[ $ False������ *StatusOptions+ �� SelectedItem �� *NewPayment.Status+����  �� 
TargetType" ��.���  �� Property � �� �� Value �#424242��  � ��
 ����  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � �� �#E0F7FA�� $!��Создать платеж��  MaterialDesignRaisedButton#��[ $	��150��$��40��$��Center=����#4CAF50
�������$��0,0,10,0q����� *CreatePaymentCommand+�� $ ��Редактировать��#��[ $	��150��$��40��$��Center=����#FF9800
�������$��0,0,10,0q����� *EditPaymentCommand+{��� *SelectedPayment+  NullToBoolConverter# [ �� $��Удалить��#��[ $	��150��$��40��$��Center=����#F44336
�������$��0,0,10,0q����� *DeletePaymentCommand+{��� *SelectedPayment+# [ �� $��Экспорт в Excel��#��[ $	��150��$��40��$��Center=����#9E9E9E
�������$��0,0,0,0q����� *ExportToExcelCommand+�� $��2��$
 15q����#B0BEC5$��2q�$	 10��
�������$��Center=�._��� $	��400������ *
Payments+ �� *SelectedPayment+ �� View �� .P��� $��ID Платежа�� �� Width$
 Auto�� �� DisplayMemberBinding �� *	PaymentId+�� $��Номер брони��$
 Auto�� �� *	BookingId+�� $��
Сумма��$
 Auto�� �� *Amount+$ {0:C}���� $��Дата��$
 Auto�� �� *PaymentDate+$ {0:dd/MM/yyyy HH:mm}���� $��
Метод��$
 Auto�� �� *PaymentMethod+�� $��Статус��$
 Auto�� �� *Status+���� " ��.���  � ��
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q� P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB