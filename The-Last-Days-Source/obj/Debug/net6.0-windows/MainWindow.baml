   M S B A M L   `   `   `  ����Q  MThe Last Days Launcher, Version=1.5.7.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:The_Last_Days_LauncherThe_Last_Days_Launcher  5   	   e aMicrosoft.Web.WebView2.Wpf, Version=1.0.2365.46, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf 5   	   c6clr-namespace:TS3_Dream_Launcher.Controls.BeautyButton(TS3_Dream_Launcher.Controls.BeautyButton  5   	   '    !The_Last_Days_Launcher.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:The_Last_Days_Launcher     5   	   \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5   	   OBeautyButton6clr-namespace:TS3_Dream_Launcher.Controls.BeautyButton     5   	     � Title$  The Last Days - Launcher��5
   	    � Icon$# /Resources/mini-icon-32px.png��6*    � 
ResizeMode$ NoResize=�6O    � SizeToContent$ WidthAndHeight=�6e    � WindowStartupLocation$ CenterScreen=�6�   .��5      � $
��1000��6   $	��600��6   .+�5   
   �� $$��/Resources/menu-background.png��6   $��UniformToFill=�68    J� Opacity$
 0.35Q�6P   � 5   
    � ColumnDefinitions 5      �� 5      $	��256 �6#   �� 5      .+�5      � .+�5      �� -   5         ��Name$ navareaBackground��5      $��0,0,0,0q�64   $��8,8,4,8q�6N    �� CornerRadius$ 8,8,8,8��6_   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6.   
 �� 
StartPoint$
 0.5,0&�6?   .��5      �  � Color$ 	#FF9A9A9A��6+    � Offset$ 0Q�6=   � 5      $ 	#FF2F2F2F��6+   $ 1Q�6=   5      5      �� 5      -   5         ��Name$ sunBg��5      $��32��6'   $��32��63   $��Center=�6>   $��Center=�6[   $ ��/Resources/sun-texture.png��6v   $��128,258,0,0q�6�   $y�	Collapsed=�6�   �� 5      -   5        $ moonBg��5      $��32��6(   $��32��64   $��Center=�6?   $��Center=�6\   $!��/Resources/moon-texture.png��6w   $��0,258,116,0q�6�   $y�	Collapsed=�6�   �� 5      $��
16,16,12,0q�6   $	��Top=�61   .+�5      � $	��100��6   $	��Top=�6(   $��16,16,16,32q�6@   .+�5       �� $'��!/Resources/the-last-days-logo.png��6    $��Center=�6K   $��Uniform=�6f   5!      �� 5"      $��0,0,0,0q�6   $��0,8,0,0q�67   $	��Top=�6H   ���	#4CFFFFFF$ 8,8,8,8��6w   ._�5#      �� $��8,8,8,8q�6%   .+�5$      ;   5TS3_Dream_Launcher.Controls.BeautyButton.BeautyButton  -   5          Name$ goHome��5$   8   $��INÍCIO��6H   $��0,0,0,0q�6Y   $��24��6k   ���	#FFFDFDFD���	#FF9E9E9E   HoverBackground �	#FFEFEFEF � Cursor$
 Hand��6�      	Minecraft#���   6�   $��Normal"�6�     5%      -   5        $ goSkin��5%   8   $��ENVIAR SKIN��6H   $��0,0,0,0q�6^   $��24��6p   ���	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��6�   #���   6�   $��Normal"�6�   $��0,8,0,0q�6    5&      -   5        $ goDocs��5&   8   $��DOCUMENTAÇÃO��6H   $��0,0,0,0q�6_   $��24��6q   ���	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��6�   $��0,8,0,0q�6�   #���   6�   $��Normal"�6    5'      -   5        $ goPrefs��5'   8   $��CONFIGURAÇÕES��6I   $��0,0,0,0q�6a   $��24��6s   ���	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��6�   #���   6�   $��Normal"�6  $��0,8,0,0q�6    5(      -   5        $ goAbout��5(   8   $��SOBRE��6I   $��0,0,0,0q�6Y   $��24��6k   ���	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��6�   $��0,8,0,0q�6�   #���   6�   $��Normal"�6
  5)      5*      5+      �� 5,      $��0,0,0,0q�6   $ 8,8,8,8��63   $��Bottom=�6J   $��80��6e    �� Padding$ 0,0,0,0q�6q   $��8,0,4,8q�6�   $
}�True��6�   $
 0.75Q�6�   ��5-      �� 5.       j� Stretch$ UniformToFill=�6%    �� ImageSource$+ %/Resources/menu-background-footer.png��6=   50      � 51      $��8,0,4,8q�6   $��54��6(   $��Bottom=�64   .+�52      �� -	   5         ��Name$ launcherVersion��52       $
��Wrap=�69   $��0.0.0��6M   
�������$��Center=�6m   $	��Top=�6�   $��0,2,0,0q�6�   �� 53       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Bottom=�6W   $��0,0,0,6q�6r   .+�54        -
   5        $ goGitHub��54   4   $��0,0,0,0q�6F   $��24��6X   ���	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��6�   $��24��6�   $��0,0,8,0q�6�    � ToolTip$% Acessar GitHub do The Last Days��6�   .��55      �� $��/Resources/github.png��6$   $��4,4,4,4q�6C   $
 0.75Q�6T   56        57      -   5        $ goDonate��57   4   $��0,0,0,0q�6F   $��24��6X   ���	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��6�   $��24��6�   $��0,0,8,0q�6�   $# Fazer Doação Para o Projeto��6�   .��58      �� $ ��/Resources/link-donate.png��6$   $��4,4,4,4q�6H   $
 0.75Q�6Y   59        5:      -   5        $ 	goDiscord��5:   4   $��0,0,0,0q�6G   $��24��6Y   ���	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��6�   $��24��6�   $3 -Acessar Servidor do Discord, do The Last Days��6�   .��5;      �� $��/Resources/discord.png��6$   $��4,4,4,4q�6D   $
 0.75Q�6U   5<      5=      5>      5?      � 5@      $��1��6   .+�5A      �� $��0,0,0,0q�6   $��4,8,8,8q�63   $ 8,8,8,8��6D   
�������6[   �� 5B      $��0,0,0,0q�6   $��32��63   $	��Top=�6?   $��4,8,8,0q�6W   ���	#FF212121$ 8,8,0,0��6   ._�5C      �� -   5        $ 	pageTitle��5C       $
��Wrap=�63   $��Título��6G   $��Center=�6U   $��Center=�6r   $
��Bold"�6�   $��16(�6�   
�������$%��Segoe UI Variable Text Semibold)�6�   $��0,0,0,2q�6�   5D      � 5E      $��4,40,8,8q�6   .+�5F      � -   5         �Name$ pageHome��5F      $y�Visible=�6-   .+�5G      �� -   5        $ backgroundImage��5G   !   $��0,0,0,0q�6:   $��0,0,0,84q�6T   ��5H      �� 5I   "   $ UniformToFill=�6-   $' !/Resources/background-image-2.png��6E   5K      �� 5L      $��0,0,0,0q�6!   $ 0,0,8,8��6;   ���	#FF212121$��Bottom=�6i   $��84��6�   � 5M      $��Bottom=�6   $	��100��6:   $��0,0,0,8q�6G    5N      �� 5O   "   $��8 �63   �� 5P   "   �� 5Q   "   $	��164 �63   �� 5R   "   $��8 �63   .+�5T      � $��Stretch=�6#   $��Stretch=�6?   $��1��6]   $��0,32,0,0q�6m   .+�5U   "   �� -   5         ��Name$ taskDisplay��5U   -   $
��Left=�6B   $��Center=�6]   .+�5V   &   �� -   5        $ taskName��5V   0   $
��Wrap=�6B   $��Tarefa��6V   $
��Left=�6d   $��Center=�6   
�������$��10(�6�   $��Normal"�6�   $��Segoe UI Variable Text)�6�   � 5W   &   -   5         �Name$ taskProgress��5W   2   $��8��6H   $	��512��6S   $��0,5,0,0q�6_   $��0,0,0,0q�6p   5X   #   5Y      � 5Z      $	��164��6#   $��Stretch=�6/   $��0,0,0,0q�6M   $��2��6^   $��Stretch=�6n   .+�5[   "   � $��48��6'   $	��164��63   $	��Top=�6?   .+�5\   &     -   5        $ 
playButton��5\   @   $��0,0,0,0q�6T   ���	#FF00A027���	#FF005B16 �	#FF00C12F$��Stretch=�6�   $
 Hand��6�   �� 5]   &   $��Center=�61   $��Center=�6N   $ 
Horizontal=�6i    J� IsHitTestVisible$ False��6�   .+�5^   *   �� $��16��60   $��16��6<   $��/Resources/play-icon.png��6G   $
��Left=�6i   $��Center=�6�   $��0,0,8,0q�6�   $ False��6�   �� 5_   *   -   5        $ playBtnText��5_   4   $
��Wrap=�6I   $��JOGAR��6]   $
��Bold"�6j   $%��Segoe UI Variable Text Semibold)�6|   $��20(�6�   
�������$��Center=�6�   $
��Left=�6�   $��0,-2,0,0q�6   $ False��6  5`   '   �� 5a   &   -   5        $ patchWarnIcon��5a   ,   $��24��6C   $��24��6O   $��/Resources/patch-warn.png��6Z   $��Center=�6}   $
��Left=�6�   $��	-32,0,0,0q�6�   $
 Help��6�   $$ Há um ou mais Patches ativos!��6�   5b   #   � 5c   "   $��24��6'   $	��Top=�63   $��0,62,0,0q�6K    5d   &   �� 5e   *   $��24 �6;   �� 5f   *   $��8 �6;   �� 5g   *   �� 5h   *   $��24 �6;   .+�5j   &   � .+�5k   *   �� -   5        $ noPlayerIcon��5k   1   
�������$��1,1,1,1q�6[   $ 24,24,24,24��6u   $
 0.75Q�6�   $y�Visible=�6�   ��5l   .   �� 5m   2   $! /Resources/profile-icon.png��6=   5o   +   �� 5p   *   -   5        $ 
playerHead��5p   1   
�������$��1,1,1,1q�6Y   $ 24,24,24,24��6s   $y�	Collapsed=�6�   ��5q   .   �� 5r   2   $  /Resources/player-skin.png��6=    �� RelativeTransform 5s   6   V� 5t   :   .~�5u   >   ��  �� CenterY$	 0.5Q�6M    �� CenterX$	 0.5Q�6[   �� 5v   >    �� CenterX$	 0.5Q�6L    �� CenterY$	 0.5Q�6Z   �� 5w   >     �� CenterX$	  0.5Q�6N   ! �� CenterY$	! 0.5Q�6\   T� 5x   >   " T� Y$" 0Q�6Q   5y   ;   5{   3   5}   +   �� 5~   *   -   5        $ playerHeadLayer��5~   1   
�������$��1,1,1,1q�6^   $ 24,24,24,24��6x   $y�	Collapsed=�6�   ��5   .   �� 5�   2   $  /Resources/player-skin.png��6=    5�   6   V� 5�   :   .~�5�   >   �� $	 0.5Q�6M   $	 0.5Q�6[   # �� ScaleX$	# 1.2Q�6i   $ �� ScaleY$
$ 1.11Q�6v   �� 5�   >   $	 0.5Q�6L   $	 0.5Q�6Z   �� 5�   >   $	  0.5Q�6N   $	! 0.5Q�6\   T� 5�   >   $" -0.055Q�6Q   % T� X$% 0Q�6\   5�   ;   5�   3   5�   +   5�   '   �� 5�   &   -   5        $ profileNick��5�   0   $
��Wrap=�6E   $��nickname��6Y   $��Center=�6i   $
��Left=�6�   $��0,0,0,0q�6�   ���	#FFD6D6D6$��3��6�   $��2��6�   �� 5�   &   -   5        & ��Name$& editNick��5�   -   $��0,0,0,0q�6?   $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��Stretch=�6�   $��Stretch=�6�   $��24��6�   $��24��6  $
 Hand��6  $��3��6  $! Alterar Nome de Usuário...��6.  ��6P   Z� ��6f   Z� ��6}   Z� .��5�   *   �� $��4,4,4,4q�60   $��/Resources/edit-icon.png��6A   $	 0.5Q�6c   5�   '   5�   #   5�      5�      5�      � 5�      -   5        $ 	pageSkins��5�      $y�	Collapsed=�6.   $��0,0,0,8q�6E   .+�5�      �� .��5�      � $	��Top=�6#   .+�5�   "   �� $	��Top=�6-   $��64,16,64,32q�6E   .+�5�   &   �� $
��Wrap=�60   $��Como Enviar Sua Skin��6D   $��Center=�6`   $��Center=�6}   $��Segoe UI)�6�   $��16(�6�   $
��Bold"�6�   $��0,0,0,24q�6�   �� 5�   &   $
��Wrap=�60   $����O The Last Days não utiliza a API de Skins da Mojang, por isso, as Skins definidas no Minecraft.net não serão carregadas in-game. Se você deseja enviar sua Skin, você precisará acessar o servidor do Discord do The Last Days, e enviar sua Skin por lá. No The Last Days, você pode enviar uma Skin padrão, Skin de Capa e Skin de Elytra. Basta enviar suas Skins no servidor do Discord.��6D   $��Segoe UI)�6�  $��Normal"�6�  ' �� TextAlignment$' Justify=�6�  �� 5�   &   $
��Wrap=�60   $��Skin de Corpo��6D   $��Center=�6Y   $��Center=�6v   $��Segoe UI)�6�   $��16(�6�   $
��Bold"�6�   $��	0,32,0,24q�6�   � 5�   &   $	��Top=�6+    5�   *   �� 5�   .   �� 5�   .   $��8 �6?   �� 5�   .   $��80 �6?   .+�5�   *   � .+�5�   .   �� $
��Wrap=�68   $����As Skins de Corpo precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 64x64 Pixels. Além disso, ao envia-la, você precisa informar se a Skin utiliza o Model 3D da Alex ou do Steve.��6L   $��Segoe UI)�6&  $��Normal"�6<  $' Justify=�6P  $��0,0,0,0q�6h  $��Stretch=�6y  $	��Top=�6�  5�   +   � 5�   *   $��2��6/   .+�5�   .   �� 
���   �$��0,0,0,0q�6I   $ 4,4,4,4��6c   ���	#FFF1F1F16z   �� 5�   .   $��8,8,8,8q�64   $&�� /Resources/Player=bskin_alex.png��6E   5�   +   5�   '   �� 5�   &   $
��Wrap=�60   $��Skin de Capa��6D   $��Center=�6X   $��Center=�6u   $��Segoe UI)�6�   $��16(�6�   $
��Bold"�6�   $��	0,32,0,24q�6�   � 5�   &    5�   *   �� 5�   .   �� 5�   .   $��8 �6?   �� 5�   .   $	��160 �6?   .+�5�   *   � .+�5�   .   �� $
��Wrap=�68   $����As Skins de Capa precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 64x32 Pixels. Apenas tenha em mente, que se você utilizar uma Capa, seu personagem pode parecer sobrecarregado se você usar Mochila, o que é bem comum no The Last Days.��6L   $��Segoe UI)�6_  $��Normal"�6u  $' Justify=�6�  $��0,0,0,0q�6�  $��Stretch=�6�  $	��Top=�6�  5�   +   � 5�   *   $��2��6/   $��79��6?   .+�5�   .   �� 
���   �$��0,0,0,0q�6I   $ 4,4,4,4��6c   ���	#FFF1F1F16z   �� 5�   .   $��8,8,8,8q�64   $ ��/Resources/Player=cape.png��6E   5�   +   5�   '   �� 5�   &   $
��Wrap=�60   $ ��Skin de Elytra ou Élitros��6D   $��Center=�6e   $��Center=�6�   $��Segoe UI)�6�   $��16(�6�   $
��Bold"�6�   $��	0,32,0,24q�6�   � 5�   &    5�   *   �� 5�   .   �� 5�   .   $��8 �6?   �� 5�   .   $	��160 �6?   .+�5�   *   � .+�5�   .   �� $
��Wrap=�68   $����As Skins de Elytra precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 128x64 Pixels. Se você não fornecer uma Skin de Elytra, então a Elytra usará a Skin de sua Capa. Se você não tiver uma Capa, então a Skin padrão de Elytra será usada.��6L   $��Segoe UI)�6_  $��Normal"�6u  $' Justify=�6�  $��0,0,0,0q�6�  $��Stretch=�6�  $	��Top=�6�  5�   +   � 5�   *   $��2��6/   $��79��6?   .+�5�   .   �� 
���   �$��0,0,0,0q�6I   $ 4,4,4,4��6c   ���	#FFF1F1F16z   �� 5�   .   $��8,8,8,8q�64   $"��/Resources/Player=elytra.png��6E   5�   +   5�   '   5�   #   5�      5�      �� 5�      $	��0.5��6$   $��Bottom=�61   $��0��6L   
���   �$	 0.5Q�6m   5�      � 5�      -   5        $ pageDocs��5�      $y�	Collapsed=�6-   $��0,0,0,8q�6D   .+�5�      � -   5        $ docsWarn��5�      $��Center=�61   $��Center=�6N   $	��512��6i   .+�5�      �� $
��Wrap=�6(   $���zA Documentação não está carregada, para poupar recursos! Se quiser acessa-la, clique no botão abaixo para carrega-la!��6<   $��Center=�6�   $	��300��6�   $' Center=�6�   $��0,0,0,46q�6�     5�      -   5        $ loadDocsButton��5�   8   $��0,0,0,0q�6P   ���	#FF00A027���	#FF005B16 �	#FF00C12F$
 Hand��6�   $��0,0,0,0q�6�   $��Bottom=�6�   $��Center=�6�   $��24��6  $	��100��6  $��CARREGAR��6  
�������$
��Bold"�6B  5�      )  #Microsoft.Web.WebView2.Wpf.WebView2  5�      -   5        (  Name$( webviewDocs��5�   '   $��0,0,0,1q�6<   $y�	Collapsed=�6M   �� 5�      $	��0.5��6$   $��Bottom=�61   $��0��6L   
���   �$	 0.5Q�6m   $��0,0,0,0q�6{   5�      � 5�      -    5        $ 	pagePrefs��5�      $y�	Collapsed=�6.   $��0,0,0,8q�6E   .+�5�      �� $��0,1,0,1q�6%   $��0,2,0,2q�6?   $��0,4,0,32q�6Q   .@�5�      �� $��Patches��6&   .��5�   "   � 
�������.+�5�   &   �� $	��Top=�61   $��
16,16,16,0q�6I   .+�5�   *   ]� $��False��64   $	��Top=�6J   .+�5�   .   �� $J��DAtivar Patch de Método de Renderização Alternativo e Simplificado��64   $��Center=�6�   $
��Left=�6�   $��0,0,0,0q�6�   �� 5�   .   -!   5        ) ��Name$) pref_patch1��5�   7   $�� ��6L   $��Right=�6W   $��Right=�6n   $��Center=�6�   $��1,1,1,1q�6�   $��0,-1,0,0q�6�   5�   +   5�   '   �� 5�   &   $
��Wrap=�60   $����Tenha em mente que os Patches não foram testados extensivamente e exaustivamente, no Modpack. Por esse motivo, eles só devem ser usados como última opção de correção de algum problema com o Modpack ou com o Jogo.��6D   $��Bottom=�6   $��Center=�6;  $��0,0,0,16q�6X  
���iii�$' Center=�6  $	��512��6�  5�   #   5�      5�      �� 5�      $	��0.5��6$   $��Bottom=�61   $��0��6L   
���   �$	 0.5Q�6m   $��0,0,0,0q�6{     5�      -"   5        $ savePrefsButton��5�   4   $��0,0,0,0q�6M   ���	#FF00A027���	#FF005B16 �	#FF00C12F$
 Hand��6�   $��0,0,0,4q�6�   $��Bottom=�6�   $��Center=�6�   $��24��6  $	��128��6  $��SALVAR��6  
�������$
��Bold"�6=  5�      � 5�      -#   5        $ 	pageAbout��5�      $y�	Collapsed=�6.   $��0,0,0,8q�6E   .+�5�      �� $	��Top=�6%   $��
64,16,64,0q�6=   .+�5�      �� $
��Wrap=�6(   $��Sobre o The Last Days��6<   $��Center=�6Y   $��Center=�6v   $��Segoe UI)�6�   $��16(�6�   $
��Bold"�6�   $��0,0,0,24q�6�   $' Center=�6�   �� 5�      $
��Wrap=�6(   $����O The Last Days é um Modpack para Minecraft 1.20.1, criado por Marcos Tomaz. O objetivo deste Modpack é basicamente ser um jogo a parte do Minecraft, como se fosse um jogo Standalone, por isso, diversas mecânicas do Minecraft são alteradas ou removidas neste Modpack, e ele também possui este Launcher independente.��6<   $��Segoe UI)�6  $��Normal"�6�  $' Justify=�6�  �� 5�      $
��Wrap=�6(   $����Todas essas alterações tem o objetivo de trazer uma experiência de simulação de um mundo pós apocaliptico, focado na sobrevivência e terror, onde o fim da humanidade foi causado por uma doença infecciosa que a contaminou, transformando as pessoas e até animais em Zumbis ou Monstros Mutantes.��6<   $��Segoe UI)�6h  $��Normal"�6~  $��0,16,0,0q�6�  $' Justify=�6�  �� 5�      $
��Wrap=�6(   $����Pegue suas armas e lute, plante, mate, brigue, roube, explore, construa, aprenda, pesquise, coopere, avance e se proteja! TUDO para sobreviver! Tudo pela vida!��6<   $��Segoe UI)�6�   $��Normal"�6�   $' Justify=�6  $��0,16,0,0q�6%  �� 5�      $
��Wrap=�6(   $��Informações de Versão��6<   $��Segoe UI)�6Y   $��16(�6o   $
��Bold"�6}   $' Center=�6�   $��	0,24,0,24q�6�   �� 5�      $
��Wrap=�6(   $g��aEstas são informações de versão de cada módulo do The Last Days instalado no seu computador.��6<   $��Segoe UI)�6�   $��Normal"�6�   $' Justify=�6�   � 5�      $	��Top=�6#   $��0,16,0,0q�6;    5�   "   �� 5�   &   $��8 �67   �� 5�   &   $��2 �67   �� 5�   &   $��* �67   .+�5�   "   �� $��0,0,0,0q�6)   $��4��6C   $��4��6N   $ 8,8,8,8��6X   
���   �$��Center=�6�   $
��Left=�6�   $��0,1,0,0q�6�   �� 5�   "   $��2��6-   $��Center=�6=   $ 
Horizontal=�6X   .+�5�   &   �� $
��Wrap=�60   $��Versão do Atualizador:��6D   $
��Left=�6b   $��Center=�6}   $��0,0,8,0q�6�   �� 5�   &   -$   5        $ aboutUpdaterVers��5�   0   $
��Wrap=�6J   $��0.0.0��6^   5�   #   5�      � 5�      $��0,8,0,0q�6#   $	��Top=�64    5�   "   �� 5�   &   $��8 �67   �� 5�   &   $��2 �67   �� 5�   &   $��* �67   .+�5   "   �� $��0,0,0,0q�6)   $��4��6C   $��4��6N   $ 8,8,8,8��6X   
���   �$��Center=�6�   $
��Left=�6�   $��0,1,0,0q�6�   �� 5  "   $��2��6-   $��Center=�6=   $ 
Horizontal=�6X   .+�5  &   �� $
��Wrap=�60   $��Versão do Launcher:��6D   $
��Left=�6_   $��Center=�6z   $��0,0,8,0q�6�   �� 5  &   -%   5        $ aboutLauncherVers��5  0   $
��Wrap=�6K   $��0.0.0��6_   5  #   5     � 5     $��0,8,0,0q�6#   $	��Top=�64    5  "   �� 5  &   $��8 �67   �� 5	  &   $��2 �67   �� 5
  &   $��* �67   .+�5  "   �� $��0,0,0,0q�6)   $��4��6C   $��4��6N   $ 8,8,8,8��6X   
���   �$��Center=�6�   $
��Left=�6�   $��0,1,0,0q�6�   �� 5  "   $��2��6-   $��Center=�6=   $ 
Horizontal=�6X   .+�5  &   �� $
��Wrap=�60   $��Versão do Java:��6D   $
��Left=�6[   $��Center=�6v   $��0,0,8,0q�6�   �� 5  &   -&   5        $ aboutJavaVers��5  0   $
��Wrap=�6G   $��0.0.0��6[   5  #   5     � 5     $��0,8,0,0q�6#   $	��Top=�64    5  "   �� 5  &   $��8 �67   �� 5  &   $��2 �67   �� 5  &   $��* �67   .+�5  "   �� $��0,0,0,0q�6)   $��4��6C   $��4��6N   $ 8,8,8,8��6X   
���   �$��Center=�6�   $
��Left=�6�   $��0,1,0,0q�6�   �� 5  "   $��2��6-   $��Center=�6=   $ 
Horizontal=�6X   .+�5  &   �� $
��Wrap=�60   $ ��Versão dos Dados de Jogo:��6D   $
��Left=�6e   $��Center=�6�   $��0,0,8,0q�6�   �� 5  &   -'   5        $ aboutGameDataVers��5  0   $
��Wrap=�6K   $��0.0.0��6_   5  #   5     � 5     $��0,8,0,0q�6#   $	��Top=�64    5  "   �� 5   &   $��8 �67   �� 5!  &   $��2 �67   �� 5"  &   $��* �67   .+�5$  "   �� $��0,0,0,0q�6)   $��4��6C   $��4��6N   $ 8,8,8,8��6X   
���   �$��Center=�6�   $
��Left=�6�   $��0,1,0,0q�6�   �� 5%  "   $��2��6-   $��Center=�6=   $ 
Horizontal=�6X   .+�5&  &   �� $
��Wrap=�60   $��Versão do Modpack:��6D   $
��Left=�6^   $��Center=�6y   $��0,0,8,0q�6�   �� 5'  &   -(   5        $ aboutModpackVers��5'  0   $
��Wrap=�6J   $��0.0.0��6^   5(  #   5)     5*     �� 5+     $	��0.5��6$   $��Bottom=�61   $��0��6L   
���   �$	 0.5Q�6m   $��0,0,0,0q�6{   5,     5-     5.     5/     � 50  
   -)   5        $ interactionBlocker��50     $
 0.75Q�6+   
���   �$y�	Collapsed=�6M   52     53     