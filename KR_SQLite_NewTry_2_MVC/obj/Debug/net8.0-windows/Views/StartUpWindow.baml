   M S B A M L   `   `   `  ����Q  MKR_SQLite_NewTry_2_MVC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:KR_SQLite_NewTry_2_MVC.ViewsKR_SQLite_NewTry_2_MVC.Views  5   	   0    *KR_SQLite_NewTry_2_MVC.Views.StartUpWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   <local*clr-namespace:KR_SQLite_NewTry_2_MVC.Views     5   	     � Title$  StartUpWindow��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$' !pack://application:,,,/logo_1.ico��5
   	   .��5      � ���#242829 � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��
Склад��6!   
�������$��30(�5    '   $
��Bold"�65   $��Center=�5!      $��Center=�61   �� 5#   
   $��1��6   $��10q�6!   �� 5%   
   $��2��6   $#��Зиновьев Леонид��6!   
�������$��20(�5&   '   $��Medium"�65   $��Center=�5'      $��Center=�61   $��5q�6L   �� 5)   
   $��3��6   $��22ВП2��6!   
�������$��18(�5*   '   $��Center=�5+      $��Center=�61   $��5q�6L   �� 5-   
   -   5        $
��Load��5.      $��4��5-      $�� ��6!   $
��Bold"�5.       
��� E��$��20(�5/   +   $��Center=�50      $��Center=�61   $��20q�6L   �� 52   
   $��5��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   $��59��53      $	��210��6!   $��10q�6-   .+�54      �� -   5        $��Работать��54      $��2,2,20,2q�56      $	��101��5;      ��57      �� *StartWorkCommand+��58      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" ���5<      �� 5=       �� 
TargetType" ��6   .�5>      ��  �� Property � ��	 �� Value	 �	#FF00CC4767   �� 5?       � ��
	 �����67   �� 5@       � ��$	 16(�65   �� 5A       � ��$
	 10,5q�64   �� 5B       � ��$	 0q�6<   
 �� Triggers
 5C      P� 5D       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5E   "   ��  � ��	 �	#FF00A8396?   5F      P� 5G       � ��$
 True��6;   . �5H   "   ��  � ��	 �	#FF007F2B6?   5I      5K      5M      �� 5N      -   5        $��
Выход��5N      $��82��5P      ��5Q      �� 5R      " ��6   .�5S      ��  � ��	 �	#FFCC004A67   �� 5T       � ��
	 �����67   �� 5U       � ��$	 16(�65   �� 5V       � ��$
	 10,5q�64   �� 5W       � ��$	 0q�6<   
 5X      P� 5Y       �@J�IsMouseOver$
 True��6=   . �5Z   "   ��  � ��	 �	#FFA8003A6?   5[      P� 5\       � ��$
 True��6;   . �5]   "   ��  � ��	 �	#FF80002B6?   5^      5`      5b      5c      5d      5e      