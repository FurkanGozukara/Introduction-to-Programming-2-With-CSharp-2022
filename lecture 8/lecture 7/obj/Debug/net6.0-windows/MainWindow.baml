   M S B A M L   `   `   `  ����D  @lecture 8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:lecture_7	lecture_7  5   	       lecture_7.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:lecture_7     5   	     � Title$  
MainWindow��5   	   $	��602��6   $
��1002��6)   .��5	      � .+�5
   
   �� -   5        $��btnLoadDataGrid��5
   /   $��load data into grid��6   $
��Left=�6F   $��
30,212,0,0q�6a   $	��Top=�6u   $��51��6�   $	��159��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtStudents��5      $��30,293,187,42q�6%   �� 5   
   -   5         ��Name$ btnSaveNewStudent��5      $��save new student��6,   $
��Left=�6G   $��
707,51,0,0q�6b   $	��Top=�6v   $��92��6�   $	��108��6�   6�   �� 5   
   -   5         ��Name$ txtStudentId��5      $
��Left=�6(   $��	30,58,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $��
student id��6j   $	��Top=�6|   $	��187��6�   $��23��6�   �� 5   
   -   5        $ txtStudentName��5      $
��Left=�6*   $��
247,58,0,0q�6E   $
 Wrap=�6Y   $��student name��6m   $	��Top=�6�   $	��182��6�   $��23��6�   �� 5   
   -   5        $ txtPhoneNumber��5      $
��Left=�6*   $��
464,58,0,0q�6E   $
 Wrap=�6Y   $��phone number��6m   $	��Top=�6�   $	��187��6�   $��23��6�   �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��
30,104,0,0q�6?   $
 Wrap=�6S   $��email��6g   $	��Top=�6t   $	��187��6�   $��23��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dateBirth��5      $
��Left=�6(   $��224,153,0,0q�6C   $	��Top=�6X   $	��133��6p     5   
   -	   5        $ 	dateLogin��5      $
��Left=�6(   $��464,103,0,0q�6C   $	��Top=�6X   $	��132��6p   �� 5   
   $��
birth date��6   $
��Left=�6%   $��
30,151,0,0q�6@   $	��Top=�6T   �� 5   
   $��
login date��6   $
��Left=�6%   $��247,102,0,0q�6@   $	��Top=�6U   �� 5   
   -
   5        $ btnDeleteSelected��5      $��delete selected record��6,   $
��Left=�6M   $��709,153,0,0q�6h   $	��Top=�6}   $��55��6�   $	��154��6�   6�   �� 5   
   -   5        $ btnUpdateRecord��5      $��update selected record��6*   $
��Left=�6K   $��709,228,0,0q�6f   $	��Top=�6{   $��49��6�   $	��154��6�   6�   �� 5   
   -   5        $��btnRandomStudent��5      $��random student populate��6)   $
��Left=�6K   $��820,306,0,0q�6f   $	��Top=�6{   $��62��6�   $	��162��6�   6�   �� 5   
   -   5        $��btnOpenHashSet��5   /   $��open hashset window��6   $
��Left=�6E   $��
852,35,0,0q�6`   $	��Top=�6t   $��80��6�   $	��130��6�   6�   5      5      