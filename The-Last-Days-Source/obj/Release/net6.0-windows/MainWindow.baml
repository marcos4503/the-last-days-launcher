   M S B A M L   `   `   `  ���� Q  MThe Last Days Launcher, Version=1.5.7.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:The_Last_Days_LauncherThe_Last_Days_Launcher  e aMicrosoft.Web.WebView2.Wpf, Version=1.0.2365.46, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf c6clr-namespace:TS3_Dream_Launcher.Controls.BeautyButton(TS3_Dream_Launcher.Controls.BeautyButton  '    !The_Last_Days_Launcher.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:The_Last_Days_Launcher     \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     OBeautyButton6clr-namespace:TS3_Dream_Launcher.Controls.BeautyButton       � Title$  The Last Days - Launcher�� � Icon$# /Resources/mini-icon-32px.png�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=�.��� $
��1000��$	��600��.+��� $$��/Resources/menu-background.png��$��UniformToFill=� J� Opacity$
 0.35Q��  � ColumnDefinitions �� $	��256 ��� .+�� .+��� -    ��Name$ navareaBackground��$��0,0,0,0q�$��8,8,4,8q� �� CornerRadius$ 8,8,8,8������ 	 �� EndPoint$	 0.5,1&�
 �� 
StartPoint$
 0.5,0&�.���  � Color$ 	#FF9A9A9A�� � Offset$ 0Q�� $ 	#FF2F2F2F��$ 1Q��� -    ��Name$ sunBg��$��32��$��32��$��Center=�$��Center=�$ ��/Resources/sun-texture.png��$��128,258,0,0q�$y�	Collapsed=��� -   $ moonBg��$��32��$��32��$��Center=�$��Center=�$!��/Resources/moon-texture.png��$��0,258,116,0q�$y�	Collapsed=��� $��
16,16,12,0q�$	��Top=�.+�� $	��100��$	��Top=�$��16,16,16,32q�.+��� $'��!/Resources/the-last-days-logo.png��$��Center=�$��Uniform=��� $��0,0,0,0q�$��0,8,0,0q�$	��Top=����	#4CFFFFFF$ 8,8,8,8��._��� $��8,8,8,8q�.+�;   5TS3_Dream_Launcher.Controls.BeautyButton.BeautyButton  -     Name$ goHome��$��INÍCIO��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF9E9E9E   HoverBackground �	#FFEFEFEF � Cursor$
 Hand��   	Minecraft#���   $��Normal"�  -   $ goSkin��$��ENVIAR SKIN��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��#���   $��Normal"�$��0,8,0,0q�  -   $ goDocs��$��DOCUMENTAÇÃO��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��$��0,8,0,0q�#���   $��Normal"�  -   $ goPrefs��$��CONFIGURAÇÕES��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��#���   $��Normal"�$��0,8,0,0q�  -   $ goAbout��$��SOBRE��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF9E9E9E �	#FFEFEFEF$
 Hand��$��0,8,0,0q�#���   $��Normal"��� $��0,0,0,0q�$ 8,8,8,8��$��Bottom=�$��80�� �� Padding$ 0,0,0,0q�$��8,0,4,8q�$
}�True��$
 0.75Q�����  j� Stretch$ UniformToFill=� �� ImageSource$+ %/Resources/menu-background-footer.png��� $��8,0,4,8q�$��54��$��Bottom=�.+��� -	    ��Name$ launcherVersion��$
��Wrap=�$��0.0.0��
�������$��Center=�$	��Top=�$��0,2,0,0q���  �� Orientation$ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,6q�.+�  -
   $ goGitHub��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��$��24��$��0,0,8,0q� � ToolTip$% Acessar GitHub do The Last Days��.���� $��/Resources/github.png��$��4,4,4,4q�$
 0.75Q�  -   $ goDonate��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��$��24��$��0,0,8,0q�$# Fazer Doação Para o Projeto��.���� $ ��/Resources/link-donate.png��$��4,4,4,4q�$
 0.75Q�  -   $ 	goDiscord��$��0,0,0,0q�$��24�����	#FFFDFDFD���	#FF585858 �	#FFE4E4E4$
 Hand��$��24��$3 -Acessar Servidor do Discord, do The Last Days��.���� $��/Resources/discord.png��$��4,4,4,4q�$
 0.75Q�� $��1��.+��� $��0,0,0,0q�$��4,8,8,8q�$ 8,8,8,8��
��������� $��0,0,0,0q�$��32��$	��Top=�$��4,8,8,0q����	#FF212121$ 8,8,0,0��._��� -   $ 	pageTitle��$
��Wrap=�$��Título��$��Center=�$��Center=�$
��Bold"�$��16(�
�������$%��Segoe UI Variable Text Semibold)�$��0,0,0,2q�� $��4,40,8,8q�.+�� -    �Name$ pageHome��$y�Visible=�.+��� -   $ backgroundImage��$��0,0,0,0q�$��0,0,0,84q����� $ UniformToFill=�$' !/Resources/background-image-2.png���� $��0,0,0,0q�$ 0,0,8,8�����	#FF212121$��Bottom=�$��84��� $��Bottom=�$	��100��$��0,0,0,8q� �� $��8 ��� �� $	��164 ��� $��8 �.+�� $��Stretch=�$��Stretch=�$��1��$��0,32,0,0q�.+��� -    ��Name$ taskDisplay��$
��Left=�$��Center=�.+��� -   $ taskName��$
��Wrap=�$��Tarefa��$
��Left=�$��Center=�
�������$��10(�$��Normal"�$��Segoe UI Variable Text)�� -    �Name$ taskProgress��$��8��$	��512��$��0,5,0,0q�$��0,0,0,0q�� $	��164��$��Stretch=�$��0,0,0,0q�$��2��$��Stretch=�.+�� $��48��$	��164��$	��Top=�.+�  -   $ 
playButton��$��0,0,0,0q����	#FF00A027���	#FF005B16 �	#FF00C12F$��Stretch=�$
 Hand���� $��Center=�$��Center=�$ 
Horizontal=� J� IsHitTestVisible$ False��.+��� $��16��$��16��$��/Resources/play-icon.png��$
��Left=�$��Center=�$��0,0,8,0q�$ False���� -   $ playBtnText��$
��Wrap=�$��JOGAR��$
��Bold"�$%��Segoe UI Variable Text Semibold)�$��20(�
�������$��Center=�$
��Left=�$��0,-2,0,0q�$ False���� -   $ patchWarnIcon��$��24��$��24��$��/Resources/patch-warn.png��$��Center=�$
��Left=�$��	-32,0,0,0q�$
 Help��$$ Há um ou mais Patches ativos!��� $��24��$	��Top=�$��0,62,0,0q� �� $��24 ��� $��8 ��� �� $��24 �.+�� .+��� -   $ noPlayerIcon��
�������$��1,1,1,1q�$ 24,24,24,24��$
 0.75Q�$y�Visible=����� $! /Resources/profile-icon.png���� -   $ 
playerHead��
�������$��1,1,1,1q�$ 24,24,24,24��$y�	Collapsed=����� $  /Resources/player-skin.png�� �� RelativeTransform V� .~���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterX$	 0.5Q� �� CenterY$	 0.5Q���   �� CenterX$	  0.5Q�! �� CenterY$	! 0.5Q�T� " T� Y$" 0Q��� -   $ playerHeadLayer��
�������$��1,1,1,1q�$ 24,24,24,24��$y�	Collapsed=����� $  /Resources/player-skin.png�� V� .~��� $	 0.5Q�$	 0.5Q�# �� ScaleX$	# 1.2Q�$ �� ScaleY$
$ 1.11Q��� $	 0.5Q�$	 0.5Q��� $	  0.5Q�$	! 0.5Q�T� $" -0.055Q�% T� X$% 0Q��� -   $ profileNick��$
��Wrap=�$��nickname��$��Center=�$
��Left=�$��0,0,0,0q����	#FFD6D6D6$��3��$��2���� -   & ��Name$& editNick��$��0,0,0,0q�$��0,0,0,0q�$��0,0,0,0q�$��Stretch=�$��Stretch=�$��24��$��24��$
 Hand��$��3��$! Alterar Nome de Usuário...����Z� ��Z� ��Z� .���� $��4,4,4,4q�$��/Resources/edit-icon.png��$	 0.5Q�� -   $ 	pageSkins��$y�	Collapsed=�$��0,0,0,8q�.+��� .��� $	��Top=�.+��� $	��Top=�$��64,16,64,32q�.+��� $
��Wrap=�$��Como Enviar Sua Skin��$��Center=�$��Center=�$��Segoe UI)�$��16(�$
��Bold"�$��0,0,0,24q��� $
��Wrap=�$����O The Last Days não utiliza a API de Skins da Mojang, por isso, as Skins definidas no Minecraft.net não serão carregadas in-game. Se você deseja enviar sua Skin, você precisará acessar o servidor do Discord do The Last Days, e enviar sua Skin por lá. No The Last Days, você pode enviar uma Skin padrão, Skin de Capa e Skin de Elytra. Basta enviar suas Skins no servidor do Discord.��$��Segoe UI)�$��Normal"�' �� TextAlignment$' Justify=��� $
��Wrap=�$��Skin de Corpo��$��Center=�$��Center=�$��Segoe UI)�$��16(�$
��Bold"�$��	0,32,0,24q�� $	��Top=� �� �� $��8 ��� $��80 �.+�� .+��� $
��Wrap=�$����As Skins de Corpo precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 64x64 Pixels. Além disso, ao envia-la, você precisa informar se a Skin utiliza o Model 3D da Alex ou do Steve.��$��Segoe UI)�$��Normal"�$' Justify=�$��0,0,0,0q�$��Stretch=�$	��Top=�� $��2��.+��� 
���   �$��0,0,0,0q�$ 4,4,4,4�����	#FFF1F1F1�� $��8,8,8,8q�$&�� /Resources/Player=bskin_alex.png���� $
��Wrap=�$��Skin de Capa��$��Center=�$��Center=�$��Segoe UI)�$��16(�$
��Bold"�$��	0,32,0,24q��  �� �� $��8 ��� $	��160 �.+�� .+��� $
��Wrap=�$����As Skins de Capa precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 64x32 Pixels. Apenas tenha em mente, que se você utilizar uma Capa, seu personagem pode parecer sobrecarregado se você usar Mochila, o que é bem comum no The Last Days.��$��Segoe UI)�$��Normal"�$' Justify=�$��0,0,0,0q�$��Stretch=�$	��Top=�� $��2��$��79��.+��� 
���   �$��0,0,0,0q�$ 4,4,4,4�����	#FFF1F1F1�� $��8,8,8,8q�$ ��/Resources/Player=cape.png���� $
��Wrap=�$ ��Skin de Elytra ou Élitros��$��Center=�$��Center=�$��Segoe UI)�$��16(�$
��Bold"�$��	0,32,0,24q��  �� �� $��8 ��� $	��160 �.+�� .+��� $
��Wrap=�$����As Skins de Elytra precisam ser compatíveis com o Minecraft Java Edition, e devem ter a resolução de 128x64 Pixels. Se você não fornecer uma Skin de Elytra, então a Elytra usará a Skin de sua Capa. Se você não tiver uma Capa, então a Skin padrão de Elytra será usada.��$��Segoe UI)�$��Normal"�$' Justify=�$��0,0,0,0q�$��Stretch=�$	��Top=�� $��2��$��79��.+��� 
���   �$��0,0,0,0q�$ 4,4,4,4�����	#FFF1F1F1�� $��8,8,8,8q�$"��/Resources/Player=elytra.png���� $	��0.5��$��Bottom=�$��0��
���   �$	 0.5Q�� -   $ pageDocs��$y�	Collapsed=�$��0,0,0,8q�.+�� -   $ docsWarn��$��Center=�$��Center=�$	��512��.+��� $
��Wrap=�$���zA Documentação não está carregada, para poupar recursos! Se quiser acessa-la, clique no botão abaixo para carrega-la!��$��Center=�$	��300��$' Center=�$��0,0,0,46q�  -   $ loadDocsButton��$��0,0,0,0q����	#FF00A027���	#FF005B16 �	#FF00C12F$
 Hand��$��0,0,0,0q�$��Bottom=�$��Center=�$��24��$	��100��$��CARREGAR��
�������$
��Bold"�)  #Microsoft.Web.WebView2.Wpf.WebView2  -   (  Name$( webviewDocs��$��0,0,0,1q�$y�	Collapsed=��� $	��0.5��$��Bottom=�$��0��
���   �$	 0.5Q�$��0,0,0,0q�� -    $ 	pagePrefs��$y�	Collapsed=�$��0,0,0,8q�.+��� $��0,1,0,1q�$��0,2,0,2q�$��0,4,0,32q�.@��� $��Patches��.��� 
�������.+��� $	��Top=�$��
16,16,16,0q�.+�]� $��False��$	��Top=�.+��� $J��DAtivar Patch de Método de Renderização Alternativo e Simplificado��$��Center=�$
��Left=�$��0,0,0,0q��� -!   ) ��Name$) pref_patch1��$�� ��$��Right=�$��Right=�$��Center=�$��1,1,1,1q�$��0,-1,0,0q��� $
��Wrap=�$����Tenha em mente que os Patches não foram testados extensivamente e exaustivamente, no Modpack. Por esse motivo, eles só devem ser usados como última opção de correção de algum problema com o Modpack ou com o Jogo.��$��Bottom=�$��Center=�$��0,0,0,16q�
���iii�$' Center=�$	��512���� $	��0.5��$��Bottom=�$��0��
���   �$	 0.5Q�$��0,0,0,0q�  -"   $ savePrefsButton��$��0,0,0,0q����	#FF00A027���	#FF005B16 �	#FF00C12F$
 Hand��$��0,0,0,4q�$��Bottom=�$��Center=�$��24��$	��128��$��SALVAR��
�������$
��Bold"�� -#   $ 	pageAbout��$y�	Collapsed=�$��0,0,0,8q�.+��� $	��Top=�$��
64,16,64,0q�.+��� $
��Wrap=�$��Sobre o The Last Days��$��Center=�$��Center=�$��Segoe UI)�$��16(�$
��Bold"�$��0,0,0,24q�$' Center=��� $
��Wrap=�$����O The Last Days é um Modpack para Minecraft 1.20.1, criado por Marcos Tomaz. O objetivo deste Modpack é basicamente ser um jogo a parte do Minecraft, como se fosse um jogo Standalone, por isso, diversas mecânicas do Minecraft são alteradas ou removidas neste Modpack, e ele também possui este Launcher independente.��$��Segoe UI)�$��Normal"�$' Justify=��� $
��Wrap=�$����Todas essas alterações tem o objetivo de trazer uma experiência de simulação de um mundo pós apocaliptico, focado na sobrevivência e terror, onde o fim da humanidade foi causado por uma doença infecciosa que a contaminou, transformando as pessoas e até animais em Zumbis ou Monstros Mutantes.��$��Segoe UI)�$��Normal"�$��0,16,0,0q�$' Justify=��� $
��Wrap=�$����Pegue suas armas e lute, plante, mate, brigue, roube, explore, construa, aprenda, pesquise, coopere, avance e se proteja! TUDO para sobreviver! Tudo pela vida!��$��Segoe UI)�$��Normal"�$' Justify=�$��0,16,0,0q��� $
��Wrap=�$��Informações de Versão��$��Segoe UI)�$��16(�$
��Bold"�$' Center=�$��	0,24,0,24q��� $
��Wrap=�$g��aEstas são informações de versão de cada módulo do The Last Days instalado no seu computador.��$��Segoe UI)�$��Normal"�$' Justify=�� $	��Top=�$��0,16,0,0q� �� $��8 ��� $��2 ��� $��* �.+��� $��0,0,0,0q�$��4��$��4��$ 8,8,8,8��
���   �$��Center=�$
��Left=�$��0,1,0,0q��� $��2��$��Center=�$ 
Horizontal=�.+��� $
��Wrap=�$��Versão do Atualizador:��$
��Left=�$��Center=�$��0,0,8,0q��� -$   $ aboutUpdaterVers��$
��Wrap=�$��0.0.0��� $��0,8,0,0q�$	��Top=� �� $��8 ��� $��2 ��� $��* �.+��� $��0,0,0,0q�$��4��$��4��$ 8,8,8,8��
���   �$��Center=�$
��Left=�$��0,1,0,0q��� $��2��$��Center=�$ 
Horizontal=�.+��� $
��Wrap=�$��Versão do Launcher:��$
��Left=�$��Center=�$��0,0,8,0q��� -%   $ aboutLauncherVers��$
��Wrap=�$��0.0.0��� $��0,8,0,0q�$	��Top=� �� $��8 ��� $��2 ��� $��* �.+��� $��0,0,0,0q�$��4��$��4��$ 8,8,8,8��
���   �$��Center=�$
��Left=�$��0,1,0,0q��� $��2��$��Center=�$ 
Horizontal=�.+��� $
��Wrap=�$��Versão do Java:��$
��Left=�$��Center=�$��0,0,8,0q��� -&   $ aboutJavaVers��$
��Wrap=�$��0.0.0��� $��0,8,0,0q�$	��Top=� �� $��8 ��� $��2 ��� $��* �.+��� $��0,0,0,0q�$��4��$��4��$ 8,8,8,8��
���   �$��Center=�$
��Left=�$��0,1,0,0q��� $��2��$��Center=�$ 
Horizontal=�.+��� $
��Wrap=�$ ��Versão dos Dados de Jogo:��$
��Left=�$��Center=�$��0,0,8,0q��� -'   $ aboutGameDataVers��$
��Wrap=�$��0.0.0��� $��0,8,0,0q�$	��Top=� �� $��8 ��� $��2 ��� $��* �.+��� $��0,0,0,0q�$��4��$��4��$ 8,8,8,8��
���   �$��Center=�$
��Left=�$��0,1,0,0q��� $��2��$��Center=�$ 
Horizontal=�.+��� $
��Wrap=�$��Versão do Modpack:��$
��Left=�$��Center=�$��0,0,8,0q��� -(   $ aboutModpackVers��$
��Wrap=�$��0.0.0���� $	��0.5��$��Bottom=�$��0��
���   �$	 0.5Q�$��0,0,0,0q�� -)   $ interactionBlocker��$
 0.75Q�
���   �$y�	Collapsed=�