   M S B A M L   `   `   `  ����G  CClassManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ClassManagerClassManager  5   	   #    ClassManager.NotificationForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ClassManager     5   	     � Title$  Notification��5   	   $	��360��6   $	��275��6+   .��5	      � .+�5
   
   �� -   5        $��lbTitle��5
      $��Tiêu đề��6   $	��100��61   $��25��6=   $
��Left=�6I   $	��Top=�6d   $��	10,10,0,0q�6|   �� 5   
   -   5        $��txtTitle��5      $	��140��6"   $��25��6.   $
��Left=�6:   $	��Top=�6U   $��Center=�6m   $��
110,10,0,0q�6�   �� 5   
   -   5        $��lbType��5      $��Loại��6   $	��100��6-   $��25��69   $
��Left=�6E   $	��Top=�6`   $��Center=�6x   $��	10,40,0,0q�6�   �� 5   
   -   5        $��cbType��5      $	��140��6!   $��25��6-   $
��Left=�69   $	��Top=�6T   $��Center=�6l   $��
110,40,0,0q�6�   .@�5      �� -   5        $��cbiNotification��5      $��Thông báo��62   $��Center=�6F   �� 5      -   5        $��cbiImportant��5      $��Quan trọng��6/   $��Center=�6D   �� 5      -   5        $��cbiFree��5      $��Tự do��6*   $��Center=�6:   5      (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDate��5      $	��240��6#   $��25��6/   $
��Left=�6;   $	��Top=�6V   $��	10,70,0,0q�6n    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%a   '        �� 5      "  6   .�5      ��  � ��$ Ngày thông báo��6-   5      5      5      �� 5   
   -	   5        $��	lbContent��5      $��Nội dung: ��6!   $	��100��66   $��25��6B   $
��Left=�6N   $	��Top=�6i   $��
10,100,0,0q�6�   �� 5   
   -
   5        $��
txtContent��5      $	��240��6$   $	��150��60   $
��Left=�6=   $	��Top=�6X   $��
10,130,0,0q�6p   �� 5   
   -   5        $��btSave��5       �� 	IsDefault . $
��Lưu��6E   $��70��6S   $��25��6^   $
��Left=�6j   $��Bottom=�6�   $��	10,0,0,10q�6�   �� 5   
   -   5        $��btCancel��5       �� IsCancel . $��Thoát��6H   $��70��6X   $��25��6c   $��Right=�6o   $��Bottom=�6�   $��	0,0,10,10q�6�   5      5      