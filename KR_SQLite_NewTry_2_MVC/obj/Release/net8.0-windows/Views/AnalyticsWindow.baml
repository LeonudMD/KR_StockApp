   M S B A M L   `   `   `  ����   KR_SQLite_NewTry_2_MVC2    ,KR_SQLite_NewTry_2_MVC.Views.AnalyticsWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Аналитика��$	��800��$
��1200�� � WindowStartupLocation$ CenterScreen=�
������� � Icon$' !pack://application:,,,/logo_1.ico�� � 	Resources  �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow �� Triggers P� Property	 P� Value��%�  '��       '  �     '  @    �� " ��.���  � �� �#007ACC��  � ��
 �   ���  � ��$ Segoe UI)���  � ��$ 14(���  � ��$ 0q���  � ��$
 10,5q��� "  .���  � ��$ Segoe UI)���  � ��$ 16(���  � �� �#007ACC��  � ��$ 1q���  �@ RowHeaderWidth$ 0Q���  � ��$ Stretch=���  � ��$ Stretch=���  �@ 
IsReadOnly$
 True����  �@J�IsHitTestVisible$ False����  �@ CanUserSortColumns$ False����  �@ CanUserReorderColumns$ False����  �@ CanUserResizeColumns$ False���� "  .���  � ��$ 40����  � �� �� *Color+��  � ��
 �   ���  � ��$ Normal"���  � ��$ 14(���  � ��$ Segoe UI)���  � ��$ 1q���  � ��
 �������  � ��$	 0,2q� P�  �@J�IsMouseOver$
	 True��. ���  � �� �	#FFC0C0C0.��� 
 � RowDefinitions
 �� $��* ��� $
��Auto �.+��� .@��� $+��%Просроченные товары��.��� 
 �� $
��Auto ��� $��* �.+��� $��16(�$
��Bold"�$��10q����� *ExpiredItemsCountText+�� $��1��$
��Auto=�.��  ���#F44242   AutoGenerateColumns$ False������ *ExpiredItems+   RowStyle �� "   �� BasedOn# [B    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Название��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $% Дата поступления��$ *  �� *CreationDate+  $ Дата выдачи��$ *  �� *
ExpiryDate+  $> 8Колличество просроченных дней��$ *  �� *AbsoluteRemainingDays+�� $*��$С истекающим сроком��.��� 
 �� $
��Auto ��� $��* �.+��� $��16(�$
��Bold"�$��10q����� *ExpiringItemsCountText+�� $��1��$
��Auto=�.��  ���#F4A742$ False������ *ExpiringItems+ �� "  # [B    $ Название��$ *  �� *Name+  $% Дата поступления��$ *  �� *CreationDate+  $ Дата выдачи��$ *  �� *
ExpiryDate+  $! Оставшиеся дни��$ *  �� *RemainingDays+�� $#��Нормальный срок��.��� 
 �� $
��Auto ��� $��* �.+��� $��16(�$
��Bold"�$��10q����� *NormalItemsCountText+�� $��1��$
��Auto=�.��  ���#5EF442$ False������ *NormalItems+ �� "  # [B    $ Название��$ *  �� *Name+  $% Дата поступления��$ *  �� *CreationDate+  $ Дата выдачи��$ *  �� *
ExpiryDate+  $! Оставшиеся дни��$ *  �� *RemainingDays+