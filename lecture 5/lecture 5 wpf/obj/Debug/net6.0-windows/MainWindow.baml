   M S B A M L   `   `   `  ����H  Dlecture 5 wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lecture_5_wpflecture_5_wpf  5   	       lecture_5_wpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:lecture_5_wpf     5   	     � Title$  	Lecture 5��5   	   $	��592��6   $	��800��6(    � 
ResizeMode$ NoResize=�64    � Icon$ 	/bird.png��6J    � WindowStartupLocation$ CenterScreen=�6[    � Cursor$
 Wait��6�    � WindowStyle$ ThreeDBorderWindow=�6�   ���	#FBFF7A7A$��Center=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��8* �6   �� 5      $	��14* �6   �� 5      $
��429* �6   �� 5      $
��187* �6   �� 5      $	��92* �6   �� 5      $	��70* �6   .+�5   
   �� -   5        $��txtFirstName��5      $
��Left=�6&   $��8,28,0,0q�6A    �� TextWrapping$
 Wrap=�6S   $��
first name��6g   $	��Top=�6y   $	��231��6�   $��36��6�   $��Bahnschrift SemiBold)�6�   $��15(�6�    �� TextAlignment$ Center=�6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 txtLastName��5      $
��Left=�6'   $��
278,28,0,0q�6B   $
 Wrap=�6V   $��	last name��6j   $	��Top=�6{   $	��231��6�   $��36��6�   $��Bahnschrift SemiBold)�6�   $��15(�6�   $ Center=�6�   $��2��6�   $��2��6  �� 5   
   -   5        
 ��Name$
 btnAddNames��5      $��Add Name��6&   $
��Left=�69   $��
121,26,0,0q�6T   $	��Top=�6h   $��38��6�   $��84��6�   $��3��6�   $��2��6�   �� 5   
   -   5         ��Name$ lstBoxNames��5      $��8,83,18,379q�6(   $��4��6=   $��2��6Q   5      �� 5   
   -   5        $
 btnInsertName��5      $��insert name��6(   $
��Left=�6>   $��178,217,0,0q�6Y   $	��Top=�6n   $��38��6�   $��84��6�   $��3��6�   $��2��6�   �� 5   
   -   5        $	 txtinserindex��5      $
��Left=�6)   $��
14,218,0,0q�6D   $
 Wrap=�6X   $��insert index��6l   $	��Top=�6�   $	��130��6�   $��37��6�   $��3��6�   �� 5   
   -   5         ��Name$ cmbSortOptions��5      $
��Left=�6+   $��	8,257,0,0q�6F   $	��Top=�6Y   $	��120��6q   $��2��6}   �� 5   
   -   5        $
 btnSort��5      $��sort listbox��6"   $
��Left=�69   $��159,248,0,0q�6T   $	��Top=�6i   $��55��6�   $��80��6�   $��2��6�   �� 5   
   -	   5        $��btnSaveListBoxContent��5      $��save listbox to a file��6.   $
��Left=�6O   $��
14,288,0,0q�6j   $	��Top=�6~   $��32��6�   $	��164��6�   $��3��6�   �� 5   
   -
   5        $��btnLoadFromFile��5   *   $��load from file��6   $
��Left=�6A   $��
14,338,0,0q�6\   $	��Top=�6p   $��47��6�   $	��164��6�   $��3��6�   �� 5   
   -   5        $��lstBoxGrades��5      $	��300��6'   $��8,362,121,126q�63   $��2��6J   �� 5   
   -   5        $��btnClear��5      $��clear listbox��6!   $
��Left=�69   $��
14,404,0,0q�6T   $	��Top=�6h   $	��130��6�   $��3��6�   �� 5    
   -   5        $��btnSelectFile��5    3   $��select file for loading��6   $
��Left=�6H   $��
14,481,0,0q�6c   $	��Top=�6w   $��38��6�   $	��164��6�   $��3��6�   �� 5!   
   -   5        $��txtReadFilePath��5!      $
��Left=�6)   $��	2,463,0,0q�6D   $
 Wrap=�6W   $
��null��6k   $	��Top=�6w   $	��429��6�   $��68��6�   $��2��6�   $��1��6�   5#      5$      