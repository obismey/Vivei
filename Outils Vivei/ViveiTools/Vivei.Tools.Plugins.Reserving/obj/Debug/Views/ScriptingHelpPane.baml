   M S B A M L   `   `   `  ����X  TVivei.Tools.Plugins.Reserving, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Vivei.Tools.Plugins.ReservingVivei.Tools.Plugins.Reserving  5      5    /Vivei.Tools.Plugins.Reserving.ScriptingHelpPane   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Vivei.Tools.Plugins.Reserving     5      .��5
      �� $	��100��6   3   -Vivei.Tools.Plugins.Reserving.ReservingPlugin    Instance � DataContext# Z  6!   .@�5   
   �� $��Champs��6    6"   �� *CurrentProject+.��5      A�  A� Columns$ 2��6   .+�5      �� .+�5      �� $��Sources��6   $��2q�60   $��2q�6;   .��5      �� -   5        $��NameSourcesComboBox��5   �    �� DisplayMemberPath$
 Name��6G    �� SelectedValuePath$
 Name��6a   
�������$��2q�6�   $��2q�6�   ��6#   �� *DataSources+6�   5      �� 5      $��Nom des Champs��6   $��2q�67   $��2q�6B   .��5      �� -   5        $��NameColumnsComboBox��5   X   $
 Name��6#   $
 Name��6<   
�������$��2q�6�   $��2q�6�   ��6�   ��  �� ElementName$ NameSourcesComboBox�� �� Path$ SelectedItem.Model�5      �� 5      -   5        $��InsererNomColonneButton��5      $��Inserer��6<   $��2q�6N   $��2q�6Y   
�������$
��Left=�6y   5      �� 5      .+�5      �� $��Sources��6   $��2q�60   $��2q�6;   .��5      �� -   5        $��UsageSourcesComboBox��5   G   $
 Name��6c   $
 Name��6|   
�������$��2q�6�   $��2q�6�   ��6#   �� *DataSources+6�   5      �� 5      $��Utilisation des Champs��6   $��2q�6?   $��2q�6J   .��5      �� -   5        $��UsageColumnsComboBox��5   \   $ Usage��6%   $ Usage��6?   
�������$��2q�6�   $��2q�6�   ��6�   �� $ UsageSourcesComboBox��$ SelectedItem.Model�5       �� 5"      -   5        $��InsererUsageColonneButton��5"      $��Inserer��6f   $��2q�6x   $��2q�6�   
�������$
��Left=�6�   5#      5$      5&      �� 5'   
   $��	Fonctions��6   5)      �� 5*   
   $��Sortie��6   5,      5-      5.      