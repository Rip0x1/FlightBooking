   M S B A M L   `   `   `  ����   FlightBooking#    FlightBooking.Pages.UsersPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  Клиенты��.��� $��20q����#F5F6FA � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��20q�$��0,0,0,20q����#9C27B0$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 2Q�   Color$ 	#66000000��.���� $��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountMultiple=�$��30��$��30��
��������� $��Клиенты��$��28(�$
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
 True��. ��� $ ContentSite�� � �� �#9C27B0��  � �� �#E3F2FDP�  �@J�IsMouseOver$
 True��. ���  � �� �#BBDEFB.@��� $-��'Управление клиентами��.���  �� $
��Auto ��� $��* �.+��� $��0��$��0,0,0,20q����#B0BEC5$��2q�$ 15q�
�������   $ 5Q�$ 1Q�$ 	#33000000��._��  � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��.+��� $%��Добавить клиента��$��16(�$��Center=�$��0,0,0,10q��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ФИО�� % !MaterialDesignFloatingHintTextBox#��[ $	��250��$��0,0,0,10q����� *NewUserFullName+�� $ Email��#��[ $	��250��$��0,0,0,10q����� *NewUserEmail+�� $ Телефон��#��[ $	��250��$��0,0,0,10q����� *NewUserPhone+��   MaterialDesignRaisedButton#��[ $	��250��$��40�����#9C27B0
����������� *AddUserCommand+.���� $ 
Horizontal=�$��Center=�.+�  $
 Plus=�$��16��$��16��$��0,0,5,0q��� $��Добавить���� $��1��$��20,0,0,0q�.+��� $/��)Редактировать клиента��$��16(�$��Center=�$��0,0,0,10q���  �� DisplayMemberPath$ FullName��  MaterialDesignComboBox#��[ $	��250��$��40�� �� 
IsEditable$ False�� �� 
IsReadOnly$ False�� �� SelectedIndex$ 0������ *Users+ �� SelectedItem �� *SelectedUser+�� $ ФИО��#��[ $	��250��$��	0,10,0,10q����� *EditUserFullName+�� $ Email��#��[ $	��250��$��0,0,0,10q����� *EditUserEmail+�� $ Телефон��#��[ $	��250��$��0,0,0,10q����� *EditUserPhone+�� $ 
Horizontal=�$��Center=�.+��� #��[ $	��150��$��40�����#2196F3
�������$��0,0,10,0q����� *EditUserCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ Pencil=�$��16��$��16��$��0,0,5,0q��� $ ��Редактировать���� #��[ $	��150��$��40�����#F44336
����������� *DeleteUserCommand+.���� $ 
Horizontal=�$��Center=�.+�  $ Delete=�$��16��$��16��$��0,0,5,0q��� $��Удалить���� $��1��$ 15q����#B0BEC5$��2q�
�������$��Center=�   $ 5Q�$ 1Q�$ 	#33000000��._��� $	��400������ *Users+ �� *SelectedUser+ � Triggers :�  :� RoutedEvent$ Loaded��.[��� .���� .��W�  �� TargetProperty$ (UIElement.Opacity)� W� From 0	 W� To 1  g� Duration$  0:0:0.5D�! �� View! �� .P��� $��ID��" �� Width$
" Auto��# �� DisplayMemberBinding# �� *UserId+�� $��ФИО��$
" Auto��# �� *
FullName+�� $��Email��$
" Auto��# �� *Email+�� $��Телефон��$
" Auto��# �� *Phone+���� "
 ��.���  � ��
 �������  � �� �#E0E0E0��  � ��$ 0,0,0,1q�$ �� Triggers$ P�  �@J�IsMouseOver$
 True��. ���  � �� �#E3F2FDP�  �@��
IsSelected$
 True��. ���  � �� �#BBDEFB