   M S B A M L   `   `   `  ����H  Dlecture 4 wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:lecture_4_wpflecture_4_wpf  5   	       lecture_4_wpf.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:lecture_4_wpf     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��txtFirstName��5
      $
��Left=�6&   $��	30,28,0,0q�6A    �� TextWrapping$
 Wrap=�6T   $��
first name��6h   $	��Top=�6z   $	��231��6�   $��36��6�   $��Bahnschrift SemiBold)�6�   $��15(�6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5         ��Name$ txtLastName��5      $
��Left=�6'   $��
300,28,0,0q�6B   $
 Wrap=�6V   $��	last name��6j   $	��Top=�6{   $	��231��6�   $��36��6�   $��Bahnschrift SemiBold)�6�   $��15(�6�   $ Center=�6�   �� 5   
   -   5         ��Name$ btnAddNames��5      $��Add Name��6&   $
��Left=�69   $��
572,26,0,0q�6T   $	��Top=�6h   $��38��6�   $��84��6�   6�   �� 5   
   -   5         ��Name$ lstNames��5      $��30,83,87,232q�6%   5      �� 5   
   -   5        $ btnInsertName��5      $��insert name��6(   $
��Left=�6>   $��629,217,0,0q�6Y   $	��Top=�6n   $��38��6�   $��84��6�   6�   �� 5   
   -   5        $ txtinserindex��5      $
��Left=�6)   $��465,218,0,0q�6D   $
 Wrap=�6Y   $��insert index��6m   $	��Top=�6�   $	��130��6�   $��37��6�   �� 5   
   -   5         ��Name$ cmbSortOptions��5      $
��Left=�6+   $��
30,257,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 5   
   -   5        $ btnSort��5      $��sort listbox��6"   $
��Left=�69   $��181,248,0,0q�6T   $	��Top=�6i   $��55��6�   $��80��6�   6�   5      5      