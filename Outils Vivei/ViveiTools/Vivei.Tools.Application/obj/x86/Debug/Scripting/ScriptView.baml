   M S B A M L   `   `   `  ����R  NVivei.Tools.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Vivei.Tools.ApplicationVivei.Tools.Application  5      U QICSharpCode.CodeCompletion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:ICSharpCode.CodeCompletion;assembly=ICSharpCode.CodeCompletionICSharpCode.CodeCompletion 5      (    "Vivei.Tools.Application.ScriptView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Vivei.Tools.Application     5      c
AvalonEditLclr-namespace:ICSharpCode.CodeCompletion;assembly=ICSharpCode.CodeCompletion     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��2 �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��ExecuteButton��5   m   $��Executer��6   $��0��6%   
�������$��2q�6H   $��2q�6S   $��75��6_   6�   A� 5   
    A� Columns$ 2��6   $��1��6"   .+�5      �� -   5        $ ��StandardFontsSizesComboBox��5      
�������$��2q�6L   $��2q�6W   $��75��6c   +   %Vivei.Tools.Application.StandardFonts   Sizes#��Z 6q    �� SelectedIndex$ 4��6�   �� 5      -   5        $#��StandardFontsFamiliesComboBox��5      
�������$��2q�6O   $��2q�6Z   $��75��6f      Families#��Z 6u   $ 4��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 67   �� 5      5!      5"      �� 5$   
   $��2��6   $y�	Collapsed=�6#   
�������$��2q�6M   $��2q�6X   �� 5%   
   $��3��6   $y�	Collapsed=�6#   
�������$��2q�6M   $��2q�6X   /  )ICSharpCode.CodeCompletion.CodeTextEditor  5'   
   -   5        $��AvalonEditCodeTextEditor��5'   $   $��1��6D   $��5q�6Q   $��5q�6\   $��4��6h   ��6|   �� 	 �� ElementName$#	 StandardFontsFamiliesComboBox��
 �� Path$
 SelectedItem� �� Mode$ TwoWay=���6�   �� $ 	 StandardFontsSizesComboBox��$
 SelectedItem�$ TwoWay=��� 5)   
   $��Stretch=�6   $��Stretch=�65   $��4��6Q   $��2��6e   �� 5+   
   -   5        $��BottomViewContentControl��5+      $��4��69   $��3��6M   
�������$��Stretch=�6�   $��Stretch=�6�   5-      5.      