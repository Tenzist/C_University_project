   M S B A M L   `   `   `  ����>  :ex1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfBookshelfAppWpfBookshelfApp  5   	        WpfBookshelfApp.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfBookshelfApp     5   	     � Title$  Teams��5   	   $	��450��6   $	��685��6$   .��5	      ]� .+�5
   
   � $��54��6   $	��Top=�6   $	��Top=�60   .+�5      �� -   5        $��
ButtonOpen��5      $��Upload��5      $��42��6&   $
��Left=�62   $��5,6,0,0q�6M   $	��Top=�5   '   $	��103��6?   6K   �� 5      -   5        $��ButtonSortByTitle��5      $��42��5      $
��Left=�6!   $��	115,6,0,0q�6<   $	��Top=�5   .   $	��103��6F   .��5      � .+�5      �� $��Sort by Team name��6    $
��Wrap=�69    �� TextAlignment$ Center=�6M   5      5      �� 5      -   5        $��ButtonSortByAuthorsCount��5      $��42��5      $
��Left=�6!   $��	225,6,0,0q�6<   $	��Top=�5   5   $	��103��6M   .��5      � .+�5      �� $��Sort by Members��6    $
��Wrap=�67   $ Center=�5       5      5      �� 5      -   5        $��TextBoxSearch��5      $��24��5      $
��Left=�6"   $��
335,14,0,0q�6=   $	��Top=�5   +   $	��109��6C   �� 5      -   5        $��ButtonSearch��5      $
��Find��5      $��42��6$   $
��Left=�60   $��	450,6,0,0q�6K   $	��Top=�5   )   $	��103��6A   6M   �� 5      -   5        $��
ButtonSave��5      $
��Save��5      $��42��6$   $
��Left=�60   $��	560,6,0,0q�6K   $	��Top=�5   '   $	��103��6?   6K   5       &   System.Windows.Controls.DataGrid  5!   
   -   5        $��DataGridAuthors��5!   <      AutoGenerateColumns$ False��6   $	��130��6/   $��Bottom=�5"      $��Bottom=�6+      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Names��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 64   -   5        
ColumnName��5$   @    � ContextMenu 5&      �� 5'      .@�5(      m� -	   5        $��MenuAuthorAdd��5(   0   $��Add row��6   6E   5)      5+        5,   
   -
   5        $��DataGridBooks��5,   /   $ False��6    5-        5.      $ 	Team Name��6%   $	 350 68   -   5        ColumnTitle��5.   D     5/      $ Creation Year��6%   -   5        
ColumnYear��5/   <    51      �� 52      .@�53      m� -   5        $��MenuItemAdd��53   0   $��Add row��6   6C   m� 54      -   5        $��MenuItemRemove��54   3   $��
Remove row��6   6I   55      57      58      59      