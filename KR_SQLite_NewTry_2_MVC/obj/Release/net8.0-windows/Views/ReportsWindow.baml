   M S B A M L   `   `   `  ����   KR_SQLite_NewTry_2_MVC0    *KR_SQLite_NewTry_2_MVC.Views.ReportsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Окно отчётов��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � Icon$' !pack://application:,,,/logo_1.ico�� � 	Resources  �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow��%�  '��       '  �     '  �    �� " ��.���  � �� �#007ACC��  � ��
 �������  � ��$ Segoe UI)���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 0q���  � ��$
 0,10q� P�  �@J�IsMouseOver$
	 True��. ���  � ��
 �  ���� "  .���  � ��$ Segoe UI)���  � ��$ 16(���  � �� �#007ACC��  � ��$ 1q���  �@ RowHeaderWidth$ 0Q��� "  .���  � �� �� *Color+��  � ��
 �   ���  � ��$ Normal"���  � ��$ 14(���  � ��$ Segoe UI)���  � ��$ 1q���  � ��
 �������  � ��$	 0,2q� P�  �@J�IsMouseOver$
	 True��. ���  � �� �	#FFC0C0C0.��� 
 � RowDefinitions
 �� $��* ��� $
��Auto �.+�  $��0��   AutoGenerateColumns$ False��   SelectionMode$ Single=�   
IsReadOnly$
 True��   GridLinesVisibility$	 All=����� *
LogEntries+   RowStyle �� "   �� BasedOn# [B    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Дата и время��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
DateTime+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��  $ Действие��$ *  �� *Action+