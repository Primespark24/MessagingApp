   M S B A M L   `   `   `  ����B  >chatbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:chatboxchatbox  5   	       chatbox.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:chatbox     5   	     � Title$  ChatBox��5   	   $��548.43��6   $��949.894��6)    � 	Resources 5
         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value	 �� Property
 �� Value��%w  &	        �� 5   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      
������ #��z��5      $ 15��6I   ._�5      �� $ PART_ContentHost��6   5       5      P� 5       � ��$
 Auto��6+   . �5      �� 	 � ��$	
 100��61   5      P� 5       � ��$
 Auto��6,   . �5      �� 	 � ��$
 20��62   5      5      5      ��5      �� 5   
    �� ImageSource$( "istockphoto-1144480943-170667a.jpg��6   .��5       � -   5        $��mainWindowContent��5        J� OpacityMask# � ��6$    � ColumnDefinitions 5!   
   �� 5"      ��5$   
   �� 5%      $) #/istockphoto-1144480943-170667a.jpg��6   .+�5'   
   �� -   5         ��Name$ 	userInput��5'   I   #��[  6   $��226,0,64,13q�6\    �� TextWrapping$
 Wrap=�6q   
������� �� 	IsEnabled . $��18(�6�   $��Segoe UI Semibold)�6�    J� Opacity$
 0.65Q�6�   $��Bottom=�6�   $��  ��6;  $��29��6E  ��6  Z� 6E  �� 5(   
   $�� ��6   $��
193,0,0,15q�6   $��Bottom=�6/    J� RenderTransformOrigin$ 0.026,0.308&�6J   $��27��6n   $
��Left=�6z   $��29��6�   ��5)      �� 5*      $ pics/7760-200.png��6   5,      �� 5-   
   -   5         ��Name$ 	ListUsers��5-      $ 0.585Q�6%   $��white)�6a   ���	#FF101B29$
��Left=�6�   $	��194��6�   $��
-1,-1,0,-1q�6�   $��20(�6�   $
��Bold"�6�   
�������$ �� IsSynchronizedWithCurrentItem$ FalseY�6  ��6�   Z� 6  �� 5.   
   $��Chat Box Users��6   $
��Left=�6)   $	��Top=�6D   $��20(�6\   $��39��6j   $��Segoe UI Semibold)�6v   $	��152��6�   
�������$��21,0,0,0q�6�   $ 1.016,0.699&�6�   �� 5/   
   -   5        $�� ��5/      $��	0,0,19,13q�6   $ 0.026,0.308&�6.   $��27��6j   $��Bottom=�6v   $��Right=�6�   $��28��6�   ��50      �� 51      $ pics/send-o-512.png��6   53      �� 54   
   -   5        $ UserName��54   I   #��[  6   $��	10,0,0,13q�6[   $
 Wrap=�6n   
������� . $��18(�6�   $��Segoe UI Semibold)�6�   $
 0.65Q�6�   $��Bottom=�6�   $��29��68  $
��Left=�6D  $	��163��6_  ��6  Z� 6_  �� 55   
   $��
Your Name:��6   $��	10,0,0,42q�6%   $��20(�68   $��Segoe UI Semibold)�6F   
�������$��39��6x   $��Bottom=�6�   $
��Left=�6�   $	��153��6�   �� 56   
   $�� ��6   $��	0,12,10,0q�6   $ 0.026,0.308&�6.   $��27��6R   $	��Top=�6^   $��Right=�6v   $��29��6�   ��57      �� 58      $ setting-512.png��6   5:      �� 5;   
   -   5        $ MessageView��5;      $��226,12,64,47q�6'   $��20(�6j   $��Segoe UI Semibold)�6x   ��6=   Z� ��6T   Z� .@�5<      �� {�.  6   5=      5>      5?      