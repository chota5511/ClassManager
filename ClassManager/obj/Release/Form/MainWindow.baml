   M S B A M L   `   `   `  ���� G  CClassManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ClassManagerClassManager      ClassManager.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ClassManager     -     � Title$  
MainWindow��$	��495��$	��640��.��� .+�o� -   $��menuQuickMenu��$��25��$��0,0,0,0q�$	��Top=�.@�m� -   $��miOption��$��Tùy chọn��$��25��$��Center=�.@�m� -   $��	miRefresh��$��Cập nhật��$��25��$
��Left=�m� -   $��miPreferance��$��Tinh chỉnh��$��25��$
��Left=�m� -   $��miLogout��$��Đăng xuất��$��25��$	��140��$
��Left=�m� -   $��miExit��$��Thoát��$��25��$	��140��$
��Left=�m� -   $��miHelp��$��Trợ giúp��$��25��$��Center=�.@�m� -	   $��miEmer��$��Khẩn cấp��$��25��$	��140��$
��Left=�m� -
   $��miInfo��$��
Thông tin��$��25��$	��140��$
��Left=��� $	��Top=�$	��410��$��0,25,0,0q�.@��� -   $��tabInfo��$��
Thông tin��$��25��$��Center=�.��� .+��� -   $��lbName��$��Họ và tên��$��25��$	��100��$��Center=�$��Center=�$��-165,-165,0,0q��� -   $��txtName�� �� 
IsReadOnly . $	��140��$��25�� �� TextAlignment$ Center=�$��Center=�$��Center=�$��Center=�$��80,-165,0,0q��� -   $
��lbID��$	��100��$��25��$��Mã số sinh viên��$��Center=�$��Center=�$��-165,-110,0,0q��� -   $��txtID�� . $	��140��$��25��$ Center=�$��Center=�$��Center=�$��Center=�$��80,-110,0,0q��� -   $��lbEmail��$	��100��$��25��$��Email��$��Center=�$��Center=�$��-165,-55,0,0q��� -   $��txtEmail�� . $	��140��$��25��$ Center=�$��Center=�$��Center=�$��Center=�$��
80,-55,0,0q��� -   $��lbPhoneNumber��$��Số điện thoại��$	��100��$��25��$��Center=�$��Center=�$��
-165,0,0,0q��� -   $��txtPhoneNumber�� . $	��140��$��25��$ Center=�$��Center=�$��Center=�$��Center=�$��80,0,0,0q��� -   $��lbEmer��$	��100��$��25��$��Khẩn cấp��$��Center=�$��Center=�$��-165,55,0,0q��� -   $��txtEmer��$	��140�� . $��25��$ Center=�$��Center=�$��Center=�$��Center=�$��	80,55,0,0q��� -   $��
lbPosition��$	��100��$��25��$��Chức vụ��$��Center=�$��Center=�$��-165,110,0,0q��� -   $��txtPosition�� . $	��140��$��25��$ Center=�$��Center=�$��Center=�$��Center=�$��
80,110,0,0q��� -   $��tabStudentList��$��Danh sách sinh viên��$��25��$��Center=�.���  � ColumnDefinitions �� $	��25* ��� $
��603* �.+��� -   $��lvStudentList��$	��500��$	��355��$
��Left=�$	��Top=�$��	10,10,0,0q� �� SelectionMode$ Extended=�$��2�� �� View �� .P��� $��Họ và tên�� �� DisplayMemberBinding �� *Name+�� $��Mã số sinh viên�� �� *ID+�� $��Email�� �� *Email+�� $��Số điện thoại�� �� *PhoneNumber+�� $��Khẩn cấp�� �� *Emer+�� $��Chức vụ�� �� *
Position+�� -   $��btAddStudent��$��Thêm��$��90��$��90��$��Right=�$	��Top=�$��	0,10,10,0q�$��1���� -   $��btEditStudent��$��Sửa��$��90��$��90��$��Right=�$��Center=�$��0,143,10,143.8q�$��1���� -   $��btDelStudent��$
��Xóa��$��90��$��90��$��Right=�$��Bottom=�$��0,0,10,11.8q�$��1���� -   $��tabNotification��$ ��Thông báo và thông tin��$��25��$��Center=�.��� .+��� $	��370��$��0,3,0,0q�.@��� -   $��tabAll��$��
Tất cả��.���� -   $��lvAll��$ Extended=� �� .P��� $��Tiêu đề�� �� *Title+�� $��Tên người đăng�� �� *Name+�� $��Ngày đăng�� �� *
DateString+�� $��Loại�� �� *Type+�� $��
Nội dung�� �� *Info+�� -    $��	tabNotifi��$��Thông báo��.���� -!   $��lvNotification��$ Extended=� �� .P��� $��Tiêu đề�� �� *Title+�� $��Tên người đăng�� �� *Name+�� $��Ngày đăng�� �� *
DateString+�� $��Loại�� �� *Type+�� $��
Nội dung�� �� *Info+�� -"   $��tabImportant��$��Thông báo quan trọng��.���� -#   $��lvImportant��$ Extended=� �� .P��� $��Tiêu đề�� �� *Title+�� $��Tên người đăng�� �� *Name+�� $��Ngày đăng�� �� *
DateString+�� $��Loại�� �� *Type+�� $��
Nội dung�� �� *Info+�� -$   $��tabFree��$��Tự do��.���� -%   $��lvFree��$ Extended=� �� .P��� $��Tiêu đề�� �� *Title+�� $��Tên người đăng�� �� *Name+�� $��Ngày đăng�� �� *
DateString+�� $��Loại�� �� *Type+�� $��
Nội dung�� �� *Info+�� -&   $��btAddNotification��$��Thêm��$	��100��$��25��$��Right=�$	��Top=�$��	0,0,102,0q��� -'   $��btDelNotification��$
��Xóa��$	��100��$��25��$��Right=�$	��Top=��� -(   $��tabChat��$��
Lớp chat��$��25��$��Center=�.��� .+��� -)   $��txtData��$	��350�� . $	��Top=��� -*   $��txtSent��$	��525��$��25��$��Bottom=�$
��Left=�$��Center=��� -+   $��btSent��$	��100��$��25��$��Right=�$��Bottom=�.��� .+��� $��Gửi��$��Center=�$��5,0,0,0q��� $0��*/ClassManager;component/Image/sent1600.png��$��20��$��Center=�$��25,0,0,0q��� -,   $��tabFund��$��Quỹ��$��25��$��Center=�.���� $	��370��$��0,3,0,0q�.@��� --   $��
tabCollect��$	��Thu��.��� .+��� -.   $��	lvCollect��$	��500��$	��320��$
��Left=�$	��Top=�$��	10,10,0,0q�$ Extended=� �� .P��� $��Mã thu�� �� *ID+�� $��Tiêu đề�� �� *Title+�� $��Trạng thái�� �� *Status+�� $��Số tiền�� �� *Fund+�� $��Ngày bắt đầu thu�� �� *StartDateString+�� $��Ngày kết thúc�� �� *OutDateString+�� $��Tổng cộng�� �� *Total+�� -/   $��btAddCollect��$��Thêm��$��90��$��90��$��Right=�$	��Top=�$��	0,10,10,0q��� -0   $��btEditCollect��$��Sửa��$��90��$��90��$��Right=�$��Center=�$��0,-0.6,10,0q��� -1   $��btDelCollect��$
��Xóa��$��90��$��90��$��Right=�$��Bottom=�$��0,0,10,11.8q��� -2   $��tabUsed��$	��Chi��.��� .+��� -3   $��
lvUsedList��$	��500��$	��320��$
��Left=�$	��Top=�$��	10,10,0,0q�$ Extended=� �� .P��� $��Mã thu�� �� *ID+�� $��Tiêu đề�� �� *Title+�� $��	Ngày chi�� �� *
DateString+�� $��Số tiền�� �� *Fund+�� -4   $��	btAddUsed��$��Thêm��$��90��$��90��$��Right=�$	��Top=�$��	0,10,10,0q��� -5   $��	btDelUsed��$
��Xóa��$��90��$��90��$��Right=�$��Bottom=�$��0,0,10,11.8q��� -6   $��tabOwe��$$��Danh sách sinh viên nợ thu��.��� .+��� -7   $��lvOwe��$	��595��$	��325��$
��Left=�$	��Top=�$��	10,10,0,0q�$ Extended=� �� .P��� $��Mã thu�� �� *FundID+�� $��Tên sinh viên�� �� *Name+�� -8   $��tabVote��$��Bỏ phiếu��$��25��$��Center=��� -9   $��lbClock��$��25��$��
Clock here��$��Bottom=�$��Center=��� -:   $��lbFundStatus��$��25��$��Fund Status here��$��Bottom=�$��Right=�