   M S B A M L   `   `   `  ���� K  GApplicatioStagez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ApplicatioStagezApplicatioStagez  #    ApplicatioStagez.UserControl2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:ApplicatioStagez     -     � Title$
  pfsi��$��516.2��$��883.2�� � 
ResizeMode$ CanMinimize=� � 	Resources    TextBlockStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  SimpleComboBoxItem  MyFocusVisual	 �� 
TargetType
 �� StrokeDashArray � ActualWidth � ActualHeight �� CornerRadius  ShadowStyle  InformButton �� 
StartPoint �� EndPoint � Color � Offset �� Padding T� X T� Y �� Triggers �� 
TargetName��%�  &	        &	 �     &	 �    &	     &	 ?    7  �� " ��.���  � ��$ 11(���  � ��
 �������  � ��
 �   � P�  �@J�IsMouseOver . . ���  � ��
 �   ���  � ��$ 15(���  � ��$ 
Arial Bold)��� " ��.���  � ��$ 14(���  � ��
 �������  � ��
 �   � P�  �@J�IsMouseOver . . ���  � ��
 �   ���  � ��$ 20(���  � ��$ 
Arial Bold)��� .���  � �� �� "	 ��.R�� $	��3 2q�.+��� $��r1��$��1��
���   �$	
 2 2R��� $��border��#��z #��z $ 2��$��1q��� .���  � ��
 ������� " ��.���  �@�OverridesDefaultStyle .  ��  � ��$ 2q���  � ��$ times new roman)���  � ��$
 11px(���  � ��
 �������  � �� �� $	 0,0&�$	 0,1&�.��� $ #000000��$ 1Q�� $ 	#FF5C5858��$
 0.85Q�� $ #000000��$ 1Q���  � �� �� "	 ��.R��� $��border��$��1q�$	 4,2q�
�������$ 3��#��z��._�� .+��� $��contentShadow��$��Center=�$��Center=�8��  z�T� $	 1.0Q�$	 1.0Q��� $��content��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � ��
 �   ���  � ��
 �������  � ��$ 30����  � ��$	 140��P�  � �� .  P�  �@��IsDefaulted . . ��� $ border�� � ��
 �����P�  �@J�	IsFocused . P�  � {� .  . ���  � ��
 �����.��� $��0,0,-26.2,-19.2q�.+��� -   $��
0,0,23,-14q�$	��490��$	��Top=�.@��� $��General��.���� $	��800��$
��Left=� �� Orientation$ 
Horizontal=�.+��� $	��400��$
��Left=�$ Vertical=�.+��� 
�������
���   �$��2q�$��50,20q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $!��Vider fichier temporaires :��$��Center=��� -    ��Name$ button1��#��[ $	��tmp��$��55,10q��� 
�������
�������$��1q�$��50,20q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $��Ouvrir l'assistance :��$��Center=��� -   $ Button2��#��[ $��
Teamviewer��$��55,10q��� 
�������
���   �$��2q�$��50,25q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $��Telecharger adwCleaner :��$��Center=��� -   $ Button5��#��[ $��
adwcleaner��$��55,10q��� $��10��$��10��$��Brawwww��$y�Hidden=��� $	��400��$
��Left=�$ Vertical=�.+��� 
�������
�������$��1q�$��50,20q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $-��'Supprimer historique bureau à distance��$��Center=��� -   $ Button3��#��[ $��Bureau��$��55,10q��� 
�������
�������$��1q�$��50,20q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $-��'Supprimer historique commande Executer:��$��Center=��� -   $ Button4��#��[ $��Executer��$��55,10q��� 
�������
���   �$��2q�$��50,25q�._��� $	��250��$ Vertical=�$
��Left=�$��25q�.+��� $��le site pfsi :��$��Center=��� -   $ Button6��#��[ $
��pfsi��$��55,10q��� $��10��$��50��$y�	Collapsed=��� $��10��$��50��$��Brawwww��$y�Hidden=��� $��Comptes��.���� .+��� $��40���� $��40��$"��Selectionnez un utilisateur:��$��Center=��� $��40��$��15���� -	    ��Name$ cbuser��$��Center=� �� Text$ Is not open��$	��300��$��30��$
��20,0q�$	��Top=��� 
�������
�������$��1q�$��
20,20,20,0q�._�$� $	��200��$	��550�� $� Orientation$ 
Horizontal=�$��center=�$��30.2,30.2,0,29.8q�.+��� .���� -
    ��Name$ 	ListInfor��$��Center=�$
��Wrap=�$	��550���� $��Details��.��� $��0,0,17.8,26.6q�.+��� 
���  ��	 �� Y1$ 0��	 �� X1$	 330��	 �� Y2$	 880��	  �� X2$	  330��$� $	��857��$	��400��$
��Left=�$ 
Horizontal=�$	��800��$	��400��$	��800��$	��400��$��0,18,0,17.2q�.+�$� $	��340��$	��363��$
��Left=�.+�$� $	��340��$	��210��$ Vertical=�$
��Left=�$	��0,0q�.+��� 
�������
�������$��1q�$��20,0,20,-0.4q�._�$� $	��250��$��59��$ Vertical=�$
��Left=�$��25,10q�.+�$� $	��250��$��30��$ 
Horizontal=�$
��Left=�$	��0,0q�.+��� $
��Left=�$��Cpu utilisé(en %):���� -   $
 PCPU��$
��Wrap=�$
��Left=����� *CalculatorOutput+! �� UpdateSourceTrigger$! PropertyChanged=�$� $	��250��$��30��$ 
Horizontal=�$
��Left=�$	��0,0q�.+��� $��ram utilisé(en %):���� -   $
 Pram��#��[  $
��Wrap=����� *CalculatorOutput+$! PropertyChanged=��� 
�������
�������$��1q�$��20,10q�._�$� $	��250��$��40��$ 
Horizontal=�$
��Left=�$
��25,0q�.+��� $��	Windows :���� -   $ OS��#��[  $
��Wrap=�$	��190��$��	0,0,0.4,0q����� *CalculatorOutput+$! PropertyChanged=��� 
�������
�������$��1q�$��20,10q�._�$� $	��250��$��40��$ 
Horizontal=�$
��Left=�$
��25,0q�.+��� $��Processeur :���� -   $
 Proc��#��[  $
��Wrap=�$	��190������ *CalculatorOutput+$! PropertyChanged=��� 
�������
�������$��1q�$��20,31.4,20,41.4q�$ 10q�" J� RenderTransformOrigin$" 0.506,0.768&�._�$� -   $
��braw��.+��� $��ram :��$��
0,0,-0.6,0q��� -   $
 raam��$
��Wrap=�$� $	��487��$	��400��$ Vertical=�$��Right=�$��0,0,-37.4,0q�.+��� $g��aC:\Users\antoine\Documents\Visual Studio 2015\Projects\ApplicatioStagez\ApplicatioStagez\pfsi.png��$��UniformToFill=�$	��305��$	��121��$��0q�$��Right=��� $��40��$��15���� -   $
 cbIp��$ Is not open��$	��300��$��30��$
��20,0q�$
��left=�$	��Top=��� 
�������
�������$��1q�$��
20,20,20,0q�._�$� $	��360��$	��140��$ 
Horizontal=�$
��Left=�$��30.2,30.2,0,29.8q�.+��� .���� -   $ Ipconfig��$
��Wrap=�$	��360��