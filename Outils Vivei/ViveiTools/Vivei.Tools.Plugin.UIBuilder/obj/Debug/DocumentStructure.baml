   M S B A M L   `   `   `  ����W  SVivei.Tools.Plugin.UIBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Vivei.Tools.Plugin.UIBuilderVivei.Tools.Plugin.UIBuilder  5      4    .Vivei.Tools.Plugin.UIBuilder.DocumentStructure   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Vivei.Tools.Plugin.UIBuilder     5      .��5	      � .+�5
   
   R� .@�5      Q� $��Document��6   *   $Vivei.Tools.Plugin.UIBuilder.Project    Current � DataContext# Z  6\    Q� 
IsExpanded 6-   �� *
IsExpanded+ �� Mode$ TwoWay=���6�   �� *ActiveDocument.RootNodes+��5      �� 5       �� ItemsSource 6/   �� *
Children+ �� ItemContainerStyle 5      �� 5       �� 
TargetType" Q�6$   .�5   "   ��  �� Property �@Q�
IsSelected �� Value 6?   �� *
IsSelected+$ TwoWay=��� 5   "    �@Q�
IsExpanded 6?   �� *
IsExpanded+$ TwoWay=�5      .R�5      ]� .+�5      �� 	 �� Padding$	 2q�6(   $��2q�64   $��Center=�6?   ��6Z   �� *	Caption+
 � ContextMenu
 5   "   �� 5   &   ��62   �� *
Commands+��5   *   �� 5   .   .R�5   2   �� ��6<   �� *	Caption+5   /   5   '   5       5!      5"      ��5$      �� 5%      " Q�6   .�5&      ��  �@Q�
IsExpanded 67   �� *
IsExpanded+$ TwoWay=�5'      5)      5*      5,      5-      