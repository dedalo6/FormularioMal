   M S B A M L   `   `   `  ���� Q  MDataBindingFormularios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DataBindingFormulariosDataBindingFormularios  '    !DataBindingFormularios.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:DataBindingFormularios       � Title$  FormulariosS.A.��$	��900��$	��800�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���� $��Hidden=�$	��700��$	��800��.��� -    �Name$ myGrid��$	��700��$
��1048��$	��Top=� � ColumnDefinitions �� $	��50* ��� $	��50* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �$��27���� $
��Auto �$	��179���� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �$��68���� $
��Auto �$��51���� $
��Auto �.+��� $��0��$��0��$��2��$)��#Introducción de Datos de Empleados��$��Black"� �� TextAlignment$ Center=�$��20(�� $��1��$��0��$
��10,0q� �� $	��20* ��� $	��80* �.+��� -   $��label_nombre��$��Nombre*��$��0��
��������� -    ��Name$ textBox_nombre��$��12��$��1��$��9(�$��90,4,-190,23q�
��� d �$��Center=�� $��2��$��0��$
��10,0q� �� $	��20* ��� $	��80* �.+��� -   $��label_apellidos��$��
Apellidos*��$��0���� -   $ textBox_apellidos��$��1��$��20��� $��3��$��0��$
��10,0q� �� $	��20* ��� $	��80* �.+��� -   $��label_email��$��E-mail*��$��0���� -   $ textBox_email��$��1��$��20��$��	0,4,-19,4q�.�� � Triggers :� 	 :� RoutedEvent$	 GotFocus��.[��� .���� .��T� 
 �� TargetProperty$
 (UIElement.Visibility)� �� 
TargetName$ textBlockEmailInfo��..�i�  R� KeyTime$ 0��  System.Windows.Visibility   Visible R� Value# Z .��� $��4��$��0��$
��10,0q� �� $	��20* ��� $	��80* �.+��� -   $��label_telefono��$��
Teléfono*��$��0���� -	   $ textBox_telefono��$��1��$��20��$	��150��$	��150��$
��Left=�� $��5��$��0��$
��10,0q� �� $	��38* ��� $	��62* �.+��� -
   $��label_fecha��$��Fecha de nacimiento��$��0��(  "System.Windows.Controls.DatePicker  -     Name$ fecha_nacimiento��$��1��$	��0,2q�   DisplayDate$ 
1700-01-01��� $��6��$��0��$
��15,0q� �� $	��15* ��� $	��85* �.+��� -   $��	label_dni��$
��DNI*��$��0���� -   $ textBox_dni��$��1��$��20��$	��200��$	��200��$
��Left=��� -   $ textBox_direccion��$��7��$��1��$�� ��$��
0,114,0,41q�.������  �� 
TargetType" ��.���  �� Property � �� �� Value$ 0,0,0,1q���  � ��
 ���� .��� $��7��$��0��$
��15,0q� �� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��
label_foto��$��Bottom=�$��Adjuntar fotografía��$��0���� -   
��� ���$��Bottom=�$��1��$
��10,0q�$��60��$��80��$
��Left=� � 	Resources ��%<   '��       �� " ��.���  �@��CornerRadius$
 1000������ $��Foton��$
��Bold"�$��20(��� -    ��Name$ Image��$��2��$��1��$��4��$	��120��$	��120���� -    ��Name$ textBlock_image��$��1��$��1��$	��330��$��20��$��Bottom=�$��Center=�$ Center=�$��30,0,0,0q�$
��Wrap=�$?��9POV: Vuelves de fiesta un Sabado. Y saludas a tus padres.��$y�	Collapsed=�� $��8��$��0��$
��10,0q� �� $	��20* ��� $	��80* � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��label_domicilio��$��	Domicilio��$��0��$��0���� -   $ textBox_ciudad��$��1��$��1��$��20��$�� ��$��0,3,0,3q��� -   $ textBox_provincia��$��2��$��1��$��20��$�� ��$��0,3,0,3q��� -   $ textBox_codigo��$��3��$��1��$��20��$�� ��$��0,3,0,3q��� -   $ textBox_pais��$��4��$��1��$��20��$�� ��$��0,3,0,3q��� $��/Images/companyLogo.jpg��$��1��$��8��$	��131��$��Bottom=�$��124,0,116,0q�� $��0��$��2��$��9��$
��10,0q� �� $	��15* ��� $	��85* �.+��� -   $��label_social��$��Enlace a red social��$��0��$��0���� -   $ textBox_redsocial��$��0,0,40,0q�$��20��$��0��$��1��� $��0��$��2��$��10��$
��15,0q� �� $	��15* ��� $	��40* ��� $	��55* �.+��� -   $��	label_rol��$��
Rol actual��$��0��$��0���� -    ��Name$ 	combo_rol��$��1��$��20��.@��� .��Desarrollador�� .��
Analista � ToolTip _� $o��iSelecciona el rol al que perteneces dentro de la empresa. ¿Perteneces a la empresa? No selecciones si no���� $��20,10q�$��11��$.��(Descripcion del puesto de trabajo actual���� -   $ textBox_trabajo��$��12��$��0��$��2��$��	20,0,40,1q��� -    ��Name$ myCanvas��$��0��$��0��$��2��$��16��.+��� -   $ textBlockEmailInfo�� �� Left$ 17��
 �� Top$	 125��$	��200��$��30��$O��IIntroduzca un email valido, no se admiten caracteres especiales excepto @��$��WrapWithOverflow=�$
��None=�$y�	Collapsed=��� 
���� ��
��� d �$ 0��$	 230��$	��700��$	��100�� K� ZIndex$ 1��$ Center=�$��Center=� �� 
LineHeight$ 98�� �� LineStackingStrategy$ BlockLineHeight=�$��62(�$
��Bold"�$��Old English Text MT)�$��   ¡Contratando ahora!���� -   $ textBlock_InstrucApelli��$ 60��$ 80��$	��280��$��50��$ 1��$
 Left=�$��WrapWithOverflow=�$����Para rellenar este campo solo debe poner sus dos apellidos. Recuerde no poner comas, solo un espacio, y deben empezar por mayúscula��$y�	Collapsed=��� -     ��Name$ textBlock_InstrucFecha��$	 120��$	 150��$	��200��$��40��$ 1��$
��Auto=�$y�	Collapsed=�.���� $
��Auto��$
��Auto��$
 Left=�$6��0Contratamos solo personas de entre 18 y 65 años���� -!     ��Name$  boton_guardar��$��0��$��13��$��Guardar��$��Right=�$��40��$	��100��$	 230��$	 643��
��� d �$��3q�
������ _� .��,*Clica¡oh, sí! Clica justo ahi ¡Sííí!�� -"   $  boton_reset��$��1��$��13��$��Corregir��$
��Left=�$��	5,11,0,10q�$��40��$	��100��
��� d �$��3q�
������&   System.Windows.Controls.DataGrid  -#   !  Name$! dataGrid��$��14��$��2��"   AutoGenerateColumns" . $
��20,0q�#   SelectionMode$# Extended=�$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Header$% Nombre��&   Width5  /System.Windows.Controls.DataGridLengthConverter$	& 10* 1  +System.Windows.Controls.DataGridBoundColumn'   Binding' �� ( �� ElementName$( textBox_nombre��) �� Path$
) Text�  $% 	Apellidos��$	& 40* ' �� $( textBox_apellidos��$
) Text�  $% Email��$	& 20* ' �� $( textBox_email��$
) Text�  $% 	Teléfono��$	& 10* ' �� $( textBox_telefono��$
) Text��� -$   $ textBlock_instrucciones��$��15��$��2��$��0,50,0,0q�$	��670��$	��240��$y�	Collapsed=�" Instrucciones, leer atentamente:�� �� $"No puede haber ningun campo vacio.�� ><Se comprueba que las letras de apellidos esten en mayuscula.�� Dos apellidos son necesarios.�� El email debe ser valido.�� 86El telefono móvil debe incluir el prefijo de España.�� )'La edad debe estar entre 18 y 65 años.�� ,*El DNI debe incluir la letra y ser valido.�� Hay que poner foto.�� (&No te olvides de incluir la direccion!�� 64El codigo postal debe pertenecer al pais que elijas.�� KIEl pais del prefijo del telefono debe coincidir con el nombre de tu pais.�� RPSi no estas en la empresa no tienes un rol actual, no deberias elegir ese campo.�� PNDescribenos tu trabajo actual, numero de palabras entre 61 y 63, no incluidos.�� 