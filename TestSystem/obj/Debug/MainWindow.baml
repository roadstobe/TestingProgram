   M S B A M L   `   `   `  ����E  ATestSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TestSystem
TestSystem  5   	       TestSystem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TestSystem     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    J� CommandBindings 5E      )  #System.Windows.Input.CommandBinding  5F   
   -   5           Command$
 Open��5F      6R     5G   
   -   5        $ local:MyCommands.Exit��5G      6c     5H   
   -   5        $
 Save��5H      6Q   .��5K      ]� .+�5L   
   o� $	��Top=�6    o� 
IsMainMenu . .@�5M      m� $
��File��6   .@�5N      m�  m� Command$
 Open��6   6,   m� 5O      -   5        $��Create examen��5O      6W   m� 5P      -   5        $��Load sesion��5P      {�. 6e   m� 5Q      $ local:MyCommands.Exit��6   6=   5R      m� 5S      $
��Edit��6   .@�5T      m� $ local:MyCommands.FontSize��6   6A   5U      5V      � 5W   
   -   5        $��
statusGrid��5W   7   $	��Top=�6   
��� ��� � ColumnDefinitions 5X      �� 5Y      �� 5Z      �� 5[      .+�5]      �� -   5        $��markChekBox��5]      6.   �� 5^      -   5        $��numberQuestion��5^   (   $��1��6   $!��Question 5 of 5 (Exam A Q5)��6>   $��14(�6a   $��Center=�6o    �� Padding$ 30, 0, 0, 0q�6�   6�   �� 5_      $��2��6   $��Timer��6$   $��Center=�64   6Q   5`      � 5a   
   $��Bottom=�6   
����� � 5b      �� 5c      $��1* �6#   �� 5d      $
��auto �6#   �� 5e      $
��auto �6$   .+�5g      �� -	   5        $��YourMark��5g      $y�Hidden=�6(   6>   �� 5h      $��1��6   $��Save Sesion��6%   $��Right=�6;   $	��150��6W   $��10q�6c   $
��Save��6o   6�   �� 5i      -
   5        $��EndExamButton��5i   f   $��2��6   $��End Exam��6%   $	��150��68   $��10q�6D   {�.  6�   5j      � 5k   
   $��Bottom=�6   
������� 5l      �� 5m      �� 5n      .+�5p      ��  �� Orientation$ 
Horizontal=�6   .+�5q      �� -   5        $��prevQuestion��5q   ,   $��Previous��6   $	��150��6[   $��10, 0, 10, 0q�6g   6   �� 5r      -   5        $��nextQuestion��5r   (   $
��Next��6   $	��150��6W   6e   5s      �� 5t      $��1��6   $ 
Horizontal=�6)   $��Right=�6B   $��Center=�6^   .+�5u      �� ��5v      9� 5w      $��Review��6#    J� 	AllowDrop . 	 9� ExpandDirection$	 Up=�6D   $��Center=�6Y   6v   5y      �� 5z      $��Show answer��6   $��Center=�62   $��10, 0, 10 ,0q�6M   6e   �� 5{      $��	Show List��6   $��Center=�6/   $��0, 0, 10, 0q�6J   6a   5|      5}      � 5~   
   $��Right=�6   $	��200��6&    5      �� 5�      $��5* �6#   �� 5�      $��1* �6#   .+�5�      �� -   5        $��questionPanel��5�      60   �� 5�      -   5        $��questionMark��5�   )   $��1��6   6@   5�      �� 5�   
   -   5        $��
mainWindow��5�      
�������.+�5�      �� $��Center=�6   $��Center=�60   $��Choose file for testing��6M   $
��Open��6o   $��25(�6~   6�   5�      5�      5�      