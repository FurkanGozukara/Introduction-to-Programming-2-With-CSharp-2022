   M S B A M L   `   `   `  ����E  Alecture 10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:lecture_7	lecture_7  5   	       lecture_7.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:lecture_7     5   	     � Title$  
MainWindow��5   	   $	��629��6   $
��1002��6)   .��5	      � .+�5   
   �� .@�5      �� $��Add Single Student��6   .��5      � ���	#FFE5E5E5.+�5      �� -   5        $��btnLoadDataGrid��5   ;   $��load data into grid��6   $
��Left=�6R   $��
30,212,0,0q�6m   $	��Top=�6�   $��51��6�   $	��159��6�   6�   &   System.Windows.Controls.DataGrid  5      -   5        $��
dtStudents��5         CanUserAddRows$ False��61      AutoGenerateColumns$ False��6H   $��30,310,312,28q�6d      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��62   -   5        	StudentId��   Header$ 
Student Id��5   W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6k   �� *	StudentId+   
Foreground 5   "   �� 5   &    �� Color$ 	#FFF12222��66   6J   5        5      -   5        StudentName��$ Student Name��5   F    6\   �� *StudentName+  5      -   5        PhoneNumber��$ Phone Number��5   F    6\   �� *PhoneNumber+  5      -   5        	Email��$ Email��5   @    6O   �� *Email+  5      -   5        	BirthDate��$ 
Birth Date��5   D    6X   �� *	BirthDate+	 �� StringFormat$	 
dd/MM/yyyy��  5      -   5        LastLoginDate��$ Last Login Date��5   I    6b   �� *LastLoginDate+5       �� 5"      -	   5        
 ��Name$
 btnSaveNewStudent��5"      $��save new student��68   $
��Left=�6S   $��
707,51,0,0q�6n   $	��Top=�6�   $��92��6�   $	��108��6�   6�   �� 5#      -
   5         ��Name$ txtStudentId��5#      $
��Left=�64   $��	30,58,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $��
student id��6v   $	��Top=�6�   $	��187��6�   $��23��6�   �� 5$      -   5        $ txtStudentName��5$      $
��Left=�66   $��
247,58,0,0q�6Q   $
 Wrap=�6e   $��student name��6y   $	��Top=�6�   $	��182��6�   $��23��6�   �� 5%      -   5        $ txtPhoneNumber��5%      $
��Left=�66   $��
464,58,0,0q�6Q   $
 Wrap=�6e   $��phone number��6y   $	��Top=�6�   $	��187��6�   $��23��6�   �� 5&      -   5        $ txtEmail��5&      $
��Left=�60   $��
30,104,0,0q�6K   $
 Wrap=�6_   $��email��6s   $	��Top=�6�   $	��187��6�   $��23��6�   (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ 	dateBirth��5'   !   $
��Left=�64   $��224,153,0,0q�6O   $	��Top=�6d   $	��133��6|     5(      -   5        $ 	dateLogin��5(   !   $
��Left=�64   $��464,103,0,0q�6O   $	��Top=�6d   $	��132��6|   �� 5)      $��
birth date��6   $
��Left=�61   $��
30,151,0,0q�6L   $	��Top=�6`   �� 5*      $��
login date��6   $
��Left=�61   $��247,102,0,0q�6L   $	��Top=�6a   �� 5+      -   5        $
 btnDeleteSelected��5+      $��delete selected record��68   $
��Left=�6Y   $��709,153,0,0q�6t   $	��Top=�6�   $��55��6�   $	��154��6�   6�   �� 5,      -   5        $
 btnUpdateRecord��5,      $��update selected record��66   $
��Left=�6W   $��709,228,0,0q�6r   $	��Top=�6�   $��49��6�   $	��154��6�   6�   �� 5.      -   5        $��btnOpenHashSet��5.   ;   $��open hashset window��6   $
��Left=�6Q   $��
836,52,0,0q�6l   $	��Top=�6�   $��80��6�   $	��130��6�   6�   �� 50      -   5        $��cbmPages��50      $
��Left=�6/   $��218,216,0,0q�6J   $	��Top=�6_   $	��191��6w   $��22��6�   �� 51      -   5        $��btnPrev��51      $
��prev��6,   $
��Left=�6;   $��348,262,0,0q�6V   $	��Top=�6k   $	��113��6�   6�   �� 52      -   5        $��btnNext��52      $
��next��6-   $
��Left=�6<   $��573,262,0,0q�6W   $	��Top=�6l   $	��111��6�   6�   �� 53      -   5        $��lblCurrentPage��53      $��Label��62   $��Center=�6B   $
��Left=�6f   $��466,259,0,0q�6�   $	��Top=�6�   $	��102��6�   56      57      �� 58      $��Batch Operations��6   .��59      � ���	#FFE5E5E5.+�5;      �� -   5        $��btnClear��5;      $��clear database��6-   $
��Left=�6F   $��
870,27,0,0q�6a   $	��Top=�6u   $��41��6�   $	��106��6�   6�   �� 5<      -   5        $��btnRandomStudent��5<      $��random student populate��65   $��Center=�6W   $��	0,115,0,0q�6t   $	��Top=�6�   $��62��6�   $	��162��6�   6�   �� 5>      -   5        $��lblProgress��5>      $��Label��6/   $��Center=�6?   $��0,42,0,0q�6\   $	��Top=�6n   $	��224��6�   5?      5A      �� 5C      -   5        $��tabRegister��5C   1   $��User Registration��6   .��5D      � ���	#FFE5E5E5.+�5E      �� -   5        $��txtUserName��5E      $
��Left=�61   $��	25,27,0,0q�6L   $
 Wrap=�6_   $��	user name��6s   $	��Top=�6�   $	��218��6�   $��25��6�   G� 5F      -   5         G�Name$	 pw1��5F   "   $	��120��6/   $��427,21,449,527q�6;   �� 5G      $��enter password��6   $
��Left=�65   $��
331,26,0,0q�6P   $	��Top=�6d   G� 5H      -   5        $	 pw2��5H   "   $	��120��6/   $��695,20,181,527q�6;   �� 5I      $��retype password��6   $
��Left=�66   $��
593,26,0,0q�6Q   $	��Top=�6e   �� 5J      -   5        $��txtRegisterEmail��5J      $
��Left=�66   $��	25,75,0,0q�6Q   $
 Wrap=�6d   $��email��6x   $	��Top=�6�   $	��462��6�   $��29��6�   �� 5K      -   5        $��btnRegister��5K   0   $��Register��6   $
��Left=�6C   $��
593,90,0,0q�6^   $	��Top=�6r   $��67��6�   $��89��6�   6�   5M      5N      5P      5R      5S      