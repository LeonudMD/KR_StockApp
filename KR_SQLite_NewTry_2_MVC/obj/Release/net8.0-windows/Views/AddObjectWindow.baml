   M S B A M L   `   `   `  ����   KR_SQLite_NewTry_2_MVC2    ,KR_SQLite_NewTry_2_MVC.Views.AddObjectWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ���#5C3D54$	��400��$	��350��  � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Icon$' !pack://application:,,,/logo_1.ico�� � 	Resources  �� 
TargetType �� Property �� Value �� 
StartPoint �� EndPoint	 � Color
 � Offset �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%�  '��       '�� i     '�� �    �� " ��.���  � ��
 �������  � ��$ 8q���  � ��$ Arial)���  � ��$ 16(��� " ��.���  � ��
 �������  � ��$ 8q���  � ��$ Arial)���  � ��$ 14(���  � ��$ 10q���  � �� �#806491��  � ��$ 1q���  � �� �� $	 0,0&�$	 1,1&�.��� $	 #B9848C��$	
 0.0Q�� $	 #806491��$	
 1.0Q��� " ��.���  � �� �#B9848C��  � ��
 �������  � ��$ 0q���  � ��$ 10q���  � ��$ 8q���  � ��$ Segoe UI)���  � ��$ 16(���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#806491P�  � ��$
 True��. ���  � �� �#5C3D54P�  � {�$ False��. ���  � �� �#B9848C��  � �� �#E0E0E0��  � �� �#B9848C.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� .+��� $��Название��$��1���� $��1��$��1������ *MyMyItem.Name+ �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=��� $��Категория��$��2���� $��1��$��2������ *MyMyItem.Category+$
 True��$ PropertyChanged=��� $��Количество��$��3���� $��1��$��3������ *MyMyItem.Quantity+$
 True��$ PropertyChanged=��� $%��Срок хранения до:��$��4��(  "System.Windows.Controls.DatePicker  $��1��$��4��$��8q�   SelectedDate �� *MyMyItem.ExpiryDate+$
 True��$ PropertyChanged=�   DisplayDateStart �� *	MinDate+ �� RelativeSource ��  �� AncestorType
 Window�� $��Center=� �� Orientation$ 
Horizontal=�$��5��$��1��.+��� -   $	��120��$��50�� �� 	IsDefault$
 True��$��OK����  �� IsCancel$
 True��$	��120��$��50��$��Отмена��