   M S B A M L   `   `   `  ���� B  >PaintFP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PaintFPPaintFP      PaintFP.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:PaintFP     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     �Name$  MyPaint�� � Title$ PaintFP��$	��350��$��670.267��
�������$	��350��$	��670�� � WindowStartupLocation$ CenterScreen=�.��� $��
0,0,0,-0.2q� � RowDefinitions �� $��9* ��� $	��98* �.+�� $��0,27,0,-0.2q�$��2��.+��� -    ��Name$ canvas��$��
0,0,0,-0.2q�
������� J� RenderTransformOrigin$ 20,20&�o� -    o�Name$
 menu��$��27��$	��Top=�$
��Left=�$	��155��.@�m� $��Files��$��27��$��42�����	#FFF0F0F0.@�m� -   $
��Open��$
��Left=�$��139.2��m� -   $
��Save��$
��Left=�$��139.2��m� -   $
��Exit��$
��Left=�$��139.2��m� $
��View��.@�m� -   $��Vertical/Horizontal��$��0,0,-48.8,0q�m� $
��Edit��.@�m� -   $��90 left arc��$
��Left=�$��139.2��m� -	   $��90 right arc��$
��Left=�$��139.2��m� -
   $��180 arc��$
��Left=�$��139.2��m� $
��Help��.@�m� -   $��About��$
��Left=�$��139.2��`� $��27��$��	155,0,0,0q�$	��Top=� `� 
Background �	#FFF0F0F0.�c� -    c�Name$ toolBar��$��0,0,-499,-14.2q����	#FFF0F0F0$��27��$	��Top=�.@��� -   	 ��Name$	 	btnPencil��$��Stretch=�$��32��$��	0,0,0,0.4q����� 
 j� Stretch$

 None=� �� ImageSource$ Resourses/pencil.png���� -   $	 btnLine��$��Stretch=�$��30��$��	0,0,0,0.4q����� $# Resourses/stock_draw_line.png���� -   $	 	btnCirlce��$��Stretch=�$��28��$��	0,0,0,0.4q�$ 0.5,0.5&�z�V� .~��� �� T� ���� $. (Resourses/stock_draw_circle_unfilled.png��$

 None=��� -   $	 btnRectangle��$��22��$	��Top=�$��37������ $1 +Resourses/stock_draw_rectangle_unfilled.png��$

 None=�#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ colorPicker��$��22��$	��Top=�$��66��
���   ��� -   $	 btnUndo��$��22��$	��Top=�$��35������ $ Resourses/edit_undo.png���� -   $	 btnRedo��$��27��$	��Top=�$��34��$��
0,0,0,-4.6q����� $  Resourses/edit_redo(1).png�� �� RelativeTransform V� .~���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T� �� -   $	 btnFill��$�� ��$��Stretch=�$��26��$��	0,0,0,0.4q����� $ Resourses/fill.png��$

 None=��� -   $	 btnErase��$��Stretch=�$��32��$��	0,0,0,0.4q����� $ Resourses/erase.png���� -   $	 	btnSelect��$��Stretch=�$��34��$��
0,0,0,-4.6q����� $ Resourses/select.png��$

 None=� V� .~��� $	 0.5Q�$	 0.5Q� �� ScaleX$	 0.8Q� �� ScaleY$	 0.8Q��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q�T� �� -   $	 btnNew��$��Stretch=�$��30��$��0,-10,0,-13.6q����� $ Resourses/new(1).png��$

 None=� V� .~��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q��� $	 0.5Q�$	 0.5Q�T� 