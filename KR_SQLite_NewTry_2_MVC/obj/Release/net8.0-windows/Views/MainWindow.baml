   M S B A M L   `   `   `  ����   KR_SQLite_NewTry_2_MVC-    'KR_SQLite_NewTry_2_MVC.Views.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  Главное окно��$	��860��$
��1000�� � WindowStartupLocation$ CenterScreen=� � Icon$' !pack://application:,,,/logo_1.ico������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF02315E�� � Offset$ 0.468Q�� $ 	#FF2F70AF��$ 0.833Q� � 	Resources    ModernButtonStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  DataGridContextMenu K� IsItemsHost&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Triggers*  $System.Windows.Controls.DataGridCell  EmptyDataTemplate   BooleanToVisibilityConverter��%�  &	        &	 O    '  �    &	 5    &	 �    �� " ��.��� 	 � ��
 �#B9848C�� 	 � ��

 ������� 	 � ��$
 0q��� 	 � ��$
 10q��� 	 � ��$
 4q��� 	 � ��$
 27���� 	 � ��$	
 180���� 	 � ��$
 Segoe UI)��� 	 � ��$
 14(��� 	 �@�Cursor$

 Hand���� 	 � ��
 �� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� 	 � ��
 �#59146eP�  � ��$
 True��. ��� 	 � ��
 �#360440P�  � {�$ False��. ��� 	 � ��
 �#B9848C�� 	 � ��
 �#E0E0E0�� 	 � ��
 �#B9848C�� ���� " ��.��� 	 �@�OverridesDefaultStyle$

 True���� 	 � ��$
 0,10,0,0q��� 	 �@��	Placement$
 
MousePoint=��� 	 �@��HasDropShadow$

 True���� 	 �@J�SnapsToDevicePixels$

 True���� 	 � ��
 �� " ��.R��� ���#FFFFFF���#B9848C$��1q�$ 5��._��� $
 True��.@�m� -   $ ��Редактировать��m� -   $��Удалить���� "  .���  	 �@ AlternatingRowBackground
 �#f2f2f2�� 	 �@ RowBackground

 ������� 	 �@ HeadersVisibility$
 Column=��� 	 �@ ColumnHeaderStyle
 �� "  .��� 	 � ��
 �	#FF806491�� 	 � ��

 ������� 	 � ��$
 Center=��� 	 � ��$
 16(� P�  �@ SortDirection 	Ascending. ��� 	 � ��
 �#0a7ec7P�  �@ SortDirection 
Descending. ��� 	 � ��
 �#0a7ec7�� 	 �@ 	CellStyle
 �� "  .��� 	 � ��$
 14(� P�  �@ 
IsSelected$
 True��. ��� 	 � ��
 �#0a7ec7�� 	 � ��

 �   ��� .R��� $&�� Объектов пока нет��$��Center=�$��Center=�
�������$��16(��� .��� $��9q� � RowDefinitions �� $��* ��� $��10 ��� $��12 ��� $��40 �.+�]� $��0��.+��� $
��Auto=�$
��Auto=�$
��Left=�.���� -    ��Name$ 	ToolPanel��$	��230��$��5q����	#FF806491$��Center=�$
}�True�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  .+�9� $+��%Управление записями�����	#FF806491 � Cursor$
 Hand��.���� $��5q�.+��� -   $��Добавить��#��[  {��� *IsDatabaseCreated+�� -   $+��%Генерировать данные��#��[  {��� *IsDatabaseCreated+9� $��Статистика�����	#FF806491$
 Hand��.���� $��5q�.+��� -   $��Отчёты��#��[  {��� *IsDatabaseCreated+�� -   $'��!Открыть аналитику��#��[  {��� *IsDatabaseCreated+9� $��База данных�����	#FF806491$
 Hand��.���� $��5q�.+��� -	    ��Name$ ButtonDbCreate��$*��$Создать базу данных��#��[  {��� *_isNotDataBAseCreated+�� -
   $*��$Удалить базу данных��#��[  $
 Hand��{��� *IsDatabaseCreated+�� -   $��Открыть из JSON��#��[  {��� *IsDatabaseCreated+9� $$��Работа с данными�����	#FF806491$
 Hand��.���� $��5q�.+��� .��Фильтрация:�� -    ��Name$ FiltCheckBox��$��Показать всё�� d� 	IsChecked �� *IsAllSelected+ �� Mode$ TwoWay=�{��� *IsDatabaseCreated+�� .��&$Выберите категорию:�� -    ��Name$ FiltComboBox�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$
 Name������ *
Categories+ �� SelectedItem �� *SelectedCategory+{��� *IsDatabaseCreated+���� $	 0,1&�.��� $ 	#FFF0F0F0��� $ 	#FF9E9797��$ 1Q��� .��Поиск товара по:�� .��" Выберите столбец:�� -   $ columnComboBox��{��� *IsDatabaseCreated+.@��� $��Наименование��
 � Tag$
 Name���� $��Артикул��$ Id���� $��Категория��$ Category���� $��Количество��$ Quantity���� $$��Срок хранения до��$ 
ExpiryDate���� .��%#Введите для поиска:�� -    ��Name$ searchTextBox��$��21��$	��141�����	#FFB7B4B4$��Center=�{��� *IsDatabaseCreated+�� $��2��$��	0,10,0,10q�.+��� 	  �� X1$  0��	! �� Y1$! 1��	" �� X2$	" 230��	# �� Y2$# 1��
���   �$��2���� -   $��Сохранить как��#��[  {��� *IsDatabaseCreated+�� .��CAВыдача товара. Укажите колличество:�� -   $ quantityTextBox�����	#FFB7B4B4$��21��$	��141��$��Center=�{��� *IsDatabaseCreated+�� -   $��Выдать товар��#��[  {��� *IsDatabaseCreated+�� -   $��
Выход��#��[  ���	#FFFF0026]� .+�  -   $  Name$$ objDataGrid��$��0��%   AutoGenerateColumns$% False��&   CanUserAddRows$& False��'   
IsReadOnly$
' True��$��5q�$
��Auto��$
��Auto��( � ContextMenu#( [ ���� *	StockView+)   Columns) 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn*   Header$* Наименование��+   Width5  /System.Windows.Controls.DataGridLengthConverter$+ * ,   CanUserSort$
, True��1  +System.Windows.Controls.DataGridBoundColumn-   Binding- �� *Name+  $* Артикул��$+ * $
, True��- �� *Id+  $* Категория��$+ * $
, True��- �� *
Category+  $* Количество��$+ * $
, True��- �� *
Quantity+  $$* Срок хранения до��$+ * $
, True��- �� *
ExpiryDate+. �� StringFormat$. 
dd.MM.yyyy���� #��[ y��� / �� ElementName$/ objDataGrid��0 �� Path$0 HasItems�1 �� 	Converter#1 [ 2 �� ConverterParameter$2 False���� $	��150��$
��Left=�$��	10,2,0,10q�$��2��$��2�����	#FF806491.���� 3 �� Orientation$3 
Horizontal=�.+��� $��Статус БД: ���� ���� *DatabaseStatus+