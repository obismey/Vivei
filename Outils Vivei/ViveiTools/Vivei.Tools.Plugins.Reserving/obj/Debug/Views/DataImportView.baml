   M S B A M L   `   `   `  ����X  TVivei.Tools.Plugins.Reserving, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Vivei.Tools.Plugins.Reserving.Model#Vivei.Tools.Plugins.Reserving.Model  5      M+clr-namespace:Vivei.Tools.Plugins.ReservingVivei.Tools.Plugins.Reserving  5      2    ,Vivei.Tools.Plugins.Reserving.DataImportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H
localmodel1clr-namespace:Vivei.Tools.Plugins.Reserving.Model     5      =local+clr-namespace:Vivei.Tools.Plugins.Reserving     5        � 	Resources  5          BooleanToVisibilityConverter �� 
TargetType  LargeButtonRadioButtonStyle �� Property �� Value �� 
TargetType �� Padding �� CornerRadius �� Triggers P� Property	 P� Value
 �� ScaleX �� ScaleY �� 
TargetName��%k  &	        &	      �� 5   
   6'   �� 5   
   " 	�6   .�5      ��  �@J�RenderTransformOrigin$ 0.5,0.5&�66   �� 5       � ��$ 0q�60   �� 5       � ��$ 0q�6'   �� 5       � �� 5      �� 5      " 	�6&   .R�5      �� $��Border��6!   $ 10q�6/   $ 0��6<   #��z��5      #��z��5      #��z��5      ._�5      �� $��Center=�60   5       5      P� 5       �@d�	IsChecked$
	 TrueY�6;   . �5   "   ��  � ��
 �   �6?   �� 5   "    � ��
 �����6?   �� 5   "    � ��$
 Bold"�6?   5       P� 5!       �@J�IsMouseOver	 . . �5"   "   ��  � z� 5#   &   �� 5$   *   $

 0.95Q�69   $
 0.95Q�6G   5&   #   �� 5'   "    � ��$ 2q�6D   �� 5(   "   $ Border��6K    �@��CornerRadius$ 5��6A   6K   5)      5+      5-      5.      5/      .��50      �  � RowDefinitions 51   
   �� 52      $
��Auto �6   �� 53      $��2 �6   �� 54      $
��Auto �6   �� 55      $��* �6   .+�58   
   �� $��Center=�6   .+�59      A�  A� Columns$ 4��6   $��10q�6(   .+�5:      	� -   5        $��CSVRadioButton��5:      $��CSV/TXT��64    	� 	GroupName$  DataSourceRadioButtonGroup��6F   #��[ 6m   6�   	� 5;      -   5        $��EXCELRadioButton��5;      $��EXCEL��66   $  DataSourceRadioButtonGroup��6F   #��[ 6m   6�   	� 5<      -   5        $��SASRadioButton��5<      $	��SAS��64   $  DataSourceRadioButtonGroup��6B   #��[ 6j   6�   	� 5=      -   5        $��SQLRadioButton��5=      $	��SQL��64   $  DataSourceRadioButtonGroup��6B   #��[ 6j   6�   5>      � 5?       � ColumnDefinitions 5@      �� 5A      �� 5B      $
��Auto �6'   .+�5D      �� $ 5��6   $��10q�6*   $��1q�66   
���   �._�5E      �� -   5        $��FileTextBlock��5E   F   $��Center=�6    $��1q�6;   6F   5F      �� 5G      -   5        $��ImporterButton��5G   U   $��1��6   $��Importer��6)   $��5q�6<   $��10q�6H   6U   5H      5I      �� 5K   
   $��Stretch=�6   $��Stretch=�65   $��1��6Q   A� 5M   
   $��2��6   $ 2��6#   $��10q�60   .+�5N      	� -   5        $��DataPreviewRadioButton��5N   +    d� 	IsChecked$
 TrueY�6   $$��Prévisualisation des données��6I   $. (DataSourcePreviewMappingRadioButtonGroup��6p   #��[ 6�   6  	� 5O      -   5        $��DataMappingRadioButton��5O      $��Mappage des données��68   $. (DataSourcePreviewMappingRadioButtonGroup��6V   #��[ 6�   6�   5P      � 5R   
   $��3��6   y�5S      ��  �� ElementName$ DataPreviewRadioButton�� �� Path$ 	IsChecked� �� 	Converter# [   5T      �� 5U      $��* �6    �� 5V      $
��Auto �6    .+�5\      �� -	   5        $��PreviewListView��5\       �� View 5]      �� 5^       �� AllowsColumnReorder .  ! �� ColumnHeaderContainerStyle 5_      �� 5`      " ��6$   .�5a   "   -
   5        5b      5d      5f      �� 5h      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��2q�6\   .+�5i      �� -   5        $��BeginButton��5i   j   $
�� << ��6   
�������$��1q�6A   $��1q�6L   $
��Bold"�6X   6j   �� 5j      -   5        $��PreviousButton��5j   f   $	�� < ��6   
�������$��1q�6=   $��1q�6H   $
��Bold"�6T   6f   �� 5k      -   5        $��PageComboBox��5k   E   
�������$��1q�6.   $��2q�69   6E   �� 5l      -   5        $��
NextButton��5l   d   $	�� > ��6   
�������$��1q�6:   $��1q�6E   $
��Bold"�6R   6d   �� 5m      -   5        $��	EndButton��5m   e   $
�� >> ��6   
�������$��1q�6;   $��1q�6F   $
��Bold"�6S   6e   5n      5o      � 5q   
   $��3��6   y�5r      �� $ DataMappingRadioButton��$ 	IsChecked�# [  .+�5s      �  5t      �� 5u      $
��Auto �6$   �� 5v      $��* �6$   .+�5y      �� $ 
Horizontal=�6   .+�5z      �� -   5        $��SaveMappingModelButton��5z   g   $��5q�6   $��5q�6(   
�������$��Enregistrer le modele��6G   6�   �� 5{      -   5        $��LoadMappingModelButton��5{   c   $��5q�6   $��5q�6(   
�������$��Charger un modele��6G   6�   �� 5|      -   5        $'��!ValidateChangesMappingModelButton��5|   k   $��5q�6   $��5q�6(   
�������$��Valider les modifications��6G   6�   5}      &   System.Windows.Controls.DataGrid  5~      -   5        $��DataModelEditingDataGrid��5      $��1��5~         SelectionMode$ Extended=�5�         SelectionUnit$ FullRow=�5�         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5�         	RowHeight$ 30Q�5�         AlternatingRowBackground
 �����   AutoGenerateColumns .     CanUserReorderColumns .      CanUserSortColumns  .  !   CanUserAddRows! . "   CanUserDeleteRows" . #   Columns# 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn$   Header$$ Colonne du Modele��6-   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 6I   �� *Name+4  .System.Windows.Controls.DataGridComboBoxColumn  5�      -   5        UsageDataGridComboBoxColumn��$$ Utilisation��5�   W   &   SelectedItemBinding& 6l   �� $ Usage�  5�      -   5        '#ColonneSourceDataGridComboBoxColumn��$$ Colonne Source��5�   ^   '   DisplayMemberPath$' 
ColumnName��6v   & 6�   �� *SourceColumn+  5�      (   
IsReadOnly( . % 6@   �� *SourceColumn.DataType+  5�      -   5        TypeDataGridComboBoxColumn��$
$ Type��5�   V   & 6e   �� *Type+  5�      -   5        '#ConvertisseurDataGridComboBoxColumn��$$ Convertisseur��5�   ^   & 6u   �� $ ConverterType�  5�      $$ Formule��6-   % 6?   �� $ Formula�) �� Mode$) TwoWay=�  5�      $$ Priorite��6-   % 6@   �� $ Priority�$) TwoWay=�5�      5�      5�      5�      5�      