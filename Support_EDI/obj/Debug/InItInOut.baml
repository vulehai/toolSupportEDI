   M S B A M L   `   `   `  ����  Support_EDI    Support_EDI.InItInOut   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hDevExpress.Xpf.Grid.v15.2.Extensions, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5   
   $	��650��5   	   $
��1200��6   .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5	      $��50 �6   �� 5
      $��* �6   �� 5      $��30 �6   6*   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $��5 �6#   �� 5      $
��Auto �6#   �� 5      $��5 �6#   �� 5      $
��Auto �6#   �� 5      $��5 �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   .+�5      	� -   5         	�Name$ EDI_FF��5   .    	� 	GroupName$	 rdo��6   $��
EDI To F/F��6>    d� 	IsChecked$
 TrueY�6S   	� 5      -   5        $ FF_EDI��5   C   $	 rdo��6   $��
F/F To EDI��6.   6C   5      � 5      $��0��6   $��1��6    .+�5      �� -   5         ��Name$ FileNameTextBox��5   S   $��32��6   $
��Left=�6&    �� 
IsReadOnly . $	��Top=�5      $	��300��6*   �� 5      -   5         ��Name$ 	btnBrowse��5       $��Browse��5      $��32��6*   $
��Left=�66   $��	310,0,0,0q�6Q   $	��Top=�5    $   $��88��6<   6G   5!      �� 5"      -   5        $ btnStart��5"   I   $��0��6   $��3��6"   $��60��62   $��30��6=   $��Start��6[   6k   �� 5#      -   5        $ btnExcel��5#   J   $��0��6   $��5��6"   $	��120��62   $��30��6>   $��Import From Excel��6\   6x   �� 5$      -   5        $ btnRollback��5$   J   $��0��6   $��7��6"   $	��120��62   $��30��6>   $��	Roll Back��6_   6s   5%      � 5I   
   -   5         �Name$ grdBody��5I      $��0��6    $��3��60   $��2��6E   .+�5J      %  DevExpress.Xpf.Grid.GridControl  -	   5        	  Name$	 grdMain��5J   /   $
��1000��6   )  #DevExpress.Xpf.Grid.DataControlBase
   AutoPopulateColumns
 .    View 5K      #  DevExpress.Xpf.Grid.TableView  5L      -
   5          Name$ tbvMain��5L   $      	AutoWidth . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase   AllowSorting .     AllowGrouping .     NavigationStyle$
 Cell=�6�       UseAnimationWhenExpanding .  6�   5N      5O      5P      5Q      