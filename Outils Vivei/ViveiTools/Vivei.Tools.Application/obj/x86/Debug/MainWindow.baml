   M S B A M L   `   `   `  ����N  JVivei.Tools.Core.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:Vivei.Tools.Core.UI;assembly=Vivei.Tools.Core.UIVivei.Tools.Core.UI  5   	   R NVivei.Tools.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Vivei.Tools.ApplicationVivei.Tools.Application 5      (   "Vivei.Tools.Application.MainWindow   5   	   ICoreUI>clr-namespace:Vivei.Tools.Core.UI;assembly=Vivei.Tools.Core.UI  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7local%clr-namespace:Vivei.Tools.Application     5      [ WXceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4=
avalonDock,http://schemas.xceed.com/wpf/xaml/avalondock  5        � Title$  
MainWindow��5      $	��350��6   $	��825��6%    � WindowState$ 	Maximized=�61   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $	��150��6�   $��50��6�   ��6   �� -  'Vivei.Tools.Application.DynamicSettings   Instance �� Source# Z  �� Path$ ToolBarTopHeight� �� Mode$ TwoWay=�6�   �� 5      ��6   �� # Z $ ToolBarBottomHeight�$ TwoWay=��� 5      $
��Auto �6   .+�5   
   �� 
�������$��3��6(   $��0,0,0,1q�6<   
���   �._�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��
20,10,0,10q�6M   '  !Vivei.Tools.Application.UIService   Instance	 � DataContext#	 Z 6a   .+�5      ��    ToolBarButtonStyle#���   6   $��0,0,20,0q�6G   ��6Y   �� $ HomeMenuItem���5      �� 5      
 �� ImageSource$
 Icones/Home.png��6%   5      �� 5      #���   6   $��0,0,20,0q�6G   ��6Y   �� $ BackMenuItem���5      �� 5      $
 Icones/left34.png��6%   5      �� 5      #���   6   $��0,0,20,0q�6H   ��6Z   �� $ ForwardMenuItem���5      �� 5      $
 Icones/right32.png��6%   5      �� 5!      
�������$��2��6,   $��0,0,20,0q�66   �� 5#      #���   6   $��0,0,20,0q�6G   ��6Y   �� $ UndoMenuItem� � ToolTip 6   �� $ LastToken.Message�-  'Vivei.Tools.Application.UndoRedoService   Instance# Z ��5$      �� 5%      $
 Icones/appbar.undo.png��6%   5'      �� 5(      #���   6   $��0,0,20,0q�6H   ��6Z   �� $ RedoMenuItem� 6�   �� $ LastUndoToken.Message�# Z ��5)      �� 5*      $
 Icones/appbar.redo.png��6%   5,      �� 5.      
�������$��2��6,   $��0,0,20,0q�66   �� 50      #���   6   $��0,0,20,0q�6H   ��6Z   �� $ WindowsMenuItem���51      �� 52      $
 Icones/squares6.png��6%   54      �� 55      #���   6   $��0,0,20,0q�6H   ��6Z   �� $ OptionsMenuItem���56      �� 57      $
 Icones/appbar.tools.png��6%   59      �� 5:      #���   6   $��0,0,20,0q�6H   ��6Z   �� $ HelpMenuItem���5;      �� 5<      $
 Icones/qmark.png��6%   5>      5?      5@      �� 5A   
   $��Stretch=�6   
������ $��2��6N   $��Bottom=�6Y   )  #Xceed.Wpf.AvalonDock.DockingManager  5C   
   -   5        $��DockingManager��5E         AllowMixedOrientation . $��1��5F      
�������#	 Z 5H         DocumentsSource 5I      �� $ 	Documents�   AnchorablesSource 5J      �� $ Tools� � 	Resources 5L      ��%    5P         DocumentHeaderTemplate 5R      �� 5S      .R�5T      �� ��6    �� *Content.Caption+5U         AnchorableHeaderTemplate 5X      �� 5Y      .R�5Z      �� ��6    �� *Content.Caption+5[         LayoutItemTemplate 5^      �� 5_      .R�5`      �� ��6'   �� *View+5a         DocumentTitleTemplate 5d      �� 5e      .R�5f      �� ��6    �� *Content.Caption+5g         AnchorableTitleTemplate 5j      �� 5k      .R�5l      �� ��6    �� *Content.Caption+5m         LayoutItemContainerStyle 5p      �� 5q      .�5r      �� .  (Xceed.Wpf.AvalonDock.Controls.LayoutItem �� Property �@ 
IsSelected �� Value 6G   �� *Model.IsActive+$ TwoWay=��� 5t       � y� 6=   �� *Model.Visibility+$ TwoWay=�5u         Layout. 5z      ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RootPanel. 5{      -  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=�6)   �  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5|      6	  0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane	   	  Name$ 	ToolsPane��66   �
  �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]] 
  	DockWidth$	 200 �6G   5}      4  .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane  5�      -   5        DocumentsPane��5�      5�      5�      5�      �� 5�   
   $��2��6   $��1q�6   ._�5�      �� $��Statut��6    �� Padding$ 2q�6&   
�������62   5�      5�      5�      