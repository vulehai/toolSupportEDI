   M S B A M L   `   `   `  ����  Support_EDI    Support_EDI.InItCode   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hDevExpress.Xpf.Grid.v15.2.Extensions, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5   
   $	��650��5   	   $
��1200��6   .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5	      $��15 �6   �� 5
      $��* �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��1��6   $��3��6,   .+�5      �� -   5         ��Name$ FileNameTextBox��5   O   $��32��6   $
��Left=�6"    �� 
IsReadOnly . $	��Top=�5      $	��300��6*   �� 5      -   5         ��Name$ 	btnBrowse��5      $��Browse��5      $��32��6&   $
��Left=�62   $��	310,0,0,0q�6M   $	��Top=�5   $   $��88��6<   6G   5      �� 5   
   -   5        $ 
btnGetData��5   .   $��0��6   $��4��6   $	��100��6B   $��30��6N   $��Get Format Data��6Z   6t   �� 5   
   -   5        $ btnGetObject��5   E   $��0��6   $��5��6   $��60��6.   $��30��69   $��Get Object EDI��6v   � 5   
   -   5         �Name$ grdBody��5      $��0��6    $��3��60   $��2��6E   .+�5      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ grdMain��5   /   $
��1000��6   )  #DevExpress.Xpf.Grid.DataControlBase   AutoPopulateColumns .    View 5      #  DevExpress.Xpf.Grid.TableView  5       -   5        	  Name$	 tbvMain��5    $   
   	AutoWidth
 . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     AllowGrouping .  &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$
 Cell=�6s       UseAnimationWhenExpanding .  6�   5"      5#      �� 5$   
   -   5        $ txtCode��5$      $��4��6#   $��2��63   $
��Auto��6@   $��Stretch=�6N   $
��Auto��6l   $��Stretch=�6y   $��4q�6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . 6�   �� 5%   
   -	   5        $ 	txtKetQua��5%      $��5��6%   $��2��65   $
��Auto��6B   $��Stretch=�6P   $
��Auto��6n   $��Stretch=�6{   $��4q�6�   $
 Wrap=�6�    . 6�   5&      5'      