   M S B A M L   `   `   `  ����B  >chatbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:chatboxchatbox  5   	       chatbox.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:chatbox     5   	     � Title$  Enter User Name��5   	   $��175.985��6!   $��471.373��62    � 
ResizeMode$ NoResize=�6B    � 	Resources 5
         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property	 P� Value
 �� Property �� Value��%w  &	        �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      
������ #��z��5      $ 15��6I   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � ��$
	 Auto��6+   . �5      �� 
 � ��$	 100��61   5      P� 5       � ��$
	 Auto��6,   . �5      �� 
 � ��$ 20��62   5      5      5      .��5      � $	��147��6   $	��Top=�6   ��5   
   �� 5       �� ImageSource$( "istockphoto-1144480943-170667a.jpg��6   .+�5!   
   �� $*��$Welcome!!! Please enter a user name:��6   $
��Left=�6?   $	��Top=�6Z   $��	21,19,0,0q�6r   $��20(�6�   $
��Bold"�6�   $��Segoe UI Semibold)�6�   �� 5"   
   -   5         ��Name$ 	UserName2��5"      #��[  6%   $��29��6\   $��
21,74,59,0q�6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�    J� Opacity$
 0.65Q�6�   
�������$��18(�6�   $��Segoe UI Semibold)�6	  ��6�   Z�  �� SelectionBrush 6�   Z� 6(  �� 5#   
   -   5         ��Name$ UserNamePromptButton��5#      $�� ��6.   $��	0,0,19,44q�69    J� RenderTransformOrigin$ 0.026,0.308&�6L   $��27��6�   $��Bottom=�6�   $��Right=�6�   $��28��6�   ��5$      �� 5%      $ pics/send-o-512.png��6   5'      5*      5+      