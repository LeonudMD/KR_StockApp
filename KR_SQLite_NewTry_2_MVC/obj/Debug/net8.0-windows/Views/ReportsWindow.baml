   M S B A M L   `   `   `  ����  KR_SQLite_NewTry_2_MVC0    *KR_SQLite_NewTry_2_MVC.Views.ReportsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Окно отчётов��5   	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$' !pack://application:,,,/logo_1.ico��5   	    � 	Resources 5	       �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow��%�  '��       '  �    '  �    �� 5   
   " ��6   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$
 0,10q�6'    5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      ��  � ��
 �  ��63   5      5      �� 5   
   "  6   .�5      ��  � ��$ Segoe UI)�6+   �� 5       � ��$ 16(�6)   �� 5       � �� �#007ACC6,   �� 5       � ��$ 1q�60   �� 5        �@ RowHeaderWidth$ 0Q�6/   5!      �� 5#   
   "  6   .�5$      ��  � �� 6+   �� *Color+�� 5%       � ��
 �   �6+   �� 5&       � ��$ Normal"�6+   �� 5'       � ��$ 14(�6)   �� 5(       � ��$ Segoe UI)�6+   �� 5)       � ��$ 1q�60   �� 5*       � ��
 �����6,   �� 5+       � ��$	 0,2q�6'    5,      P� 5.       �@J�IsMouseOver$
	 True��61   . �5/      ��  � �� �	#FFC0C0C063   50      52      53      .��54      � 
 � RowDefinitions
 55   
   �� 56      $��* �6   �� 57      $
��Auto �6   .+�5;   
     $��0��6      AutoGenerateColumns$ False��6C      SelectionMode$ Single=�5<         
IsReadOnly$
 True��6*      GridLinesVisibility$	 All=�6<   ��5;       �� *
LogEntries+   RowStyle 5=      �� 5>      "  6    �� BasedOn# [B 61      Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата и время��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
DateTime+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��6     5D      $ Действие��6%   $ * 6R    67   �� *Action+6R   5F      5G      5H      