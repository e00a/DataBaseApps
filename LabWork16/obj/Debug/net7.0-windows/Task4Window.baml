   M S B A M L   `   `   `  ����D  @LabWork16, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LabWork16	LabWork16  5   	       LabWork16.Task4Window   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LabWork16     5   	     � Title$  Task4Window��5      $	��600��6!   $	��800��6.   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��400 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $	��200��6"   .+�5      �� $8��2Введите количество записей��6   �� 5      -   5         ��Name$ pageSizeTextBlock��5      �� 5      $%��Введите страницу��6   �� 5      -   5        $ pageTextBlock��5      �� 5      -   5         ��Name$ 
loadButton��5   $   $
��Load��6   5   	   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ productsDataGrid��5      $��1��5      �� 5   
   -   5         ��Name$ buttonsStackPanel��5       �� Orientation$ 
Horizontal=�5      $��3��5      $��Center=�5      5       5!      5"      