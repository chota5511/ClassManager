   M S B A M L   `   `   `  ���� G  CClassManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ClassManagerClassManager      ClassManager.Collect   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ClassManager       � Title$  Collect��$	��232��$	��585��.��� .+��� -   $��lbTitle��$��Tiêu đề��$	��100��$��25��$
��Left=�$	��Top=�$��	10,10,0,0q��� -   $��txtTitle��$	��140��$��25��$
��Left=�$	��Top=�$��Center=�$��
110,10,0,0q��� -   $��lbMoney��$��Số tiền��$	��100��$��25��$
��Left=�$	��Top=�$��	10,40,0,0q��� -   $��txtMoney��$	��140��$��25��$
��Left=�$	��Top=�$��Center=�$��
110,40,0,0q�(  "System.Windows.Controls.DatePicker  -   $��dpStartDate��$	��110��$��25��$
��Left=�$	��Top=�$��Center=�$��	10,70,0,0q� � 	Resources :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%=   '        �� "  .���  � ��$ Ngày bắt đầu���� $��-��$��20��$��25��$
��Left=�$��Center=�$	��Top=�$��
120,70,0,0q�  -   $��	dpOutDate��$	��110��$��25��$
��Left=�$	��Top=�$��Center=�$��
140,70,0,0q� ��%<   '        �� "  .���  � ��$ Ngày kết thúc���� -   $��lbStatus��$��Trạng thái��$	��100��$��25��$
��Left=�$	��Top=�$��
10,100,0,0q��� -   $��	cbStartus��$	��140��$��25��$
��Left=�$	��Top=�$��Center=�$��110,100,0,0q�.@��� -	   $��cbiOpen��$
��Mở���� -
   $��cbiClose��$��Đóng���� -   $��lvNotCollected�� �� SelectionMode$ Multiple=�$	��300��$	��175��$��Right=�$	��Top=�$��	0,10,10,0q� �� View �� .P��� $��Mã số sinh viên�� �� DisplayMemberBinding �� *ID+�� $��Họ và tên�� �� *Name+�� -   $��lbCount��$��Số lượng: ��$	��120��$��25��$
��Left=�$	��Top=�$��
10,130,0,0q��� -   $��lbTotal��$��Tổng cộng: ��$	��130��$��25��$
��Left=�$	��Top=�$��130,130,0,0q��� -   $��btSave��$
��Lưu��$��70��$��25��$
��Left=�$��Bottom=�$��	10,0,0,10q��� -   $��btCancel��$��Thoát��$��70��$��25��$
��Left=�$��Bottom=�$��
180,0,0,10q�