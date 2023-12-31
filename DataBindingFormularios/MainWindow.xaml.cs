using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DataBindingFormularios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool haPuestoFoto = false;
        
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;

        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                e.Handled = true; // Marco la tecla Tab como manejada para evitar el cambio de foco
            }
        }

        private void button_Imagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = System.IO.Path.GetFullPath("..\\..\\Images");  

            openFileDialog.FilterIndex = 1;
           
            openFileDialog.Multiselect = false;

            openFileDialog.Filter = "Todo lo que quieras guapi|*.*"; 
            
            if ((bool)openFileDialog.ShowDialog())
            
            {
                haPuestoFoto = true;
                string rutaImagen = openFileDialog.FileName;
                //
                // Resumen:
                //     Obtiene una matriz que contiene un nombre de archivo seguro de cada archivo seleccionado.
                //
                // Devuelve:
                //     Una matriz de System.String que contiene un nombre de archivo seguro de cada
                //     archivo seleccionado. El valor predeterminado es una matriz con un elemento único
                //     cuyo valor es System.String.Empty.



                //BitmapImage imagenBitmap = new BitmapImage(new Uri(rutaImagen), new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheOnly));
                
                BitmapImage imagenBitmap = new BitmapImage();
                imagenBitmap.BeginInit(); //Pedimos que pare el inicio para que nos deje establecer la uri
                imagenBitmap.UriSource = new Uri(rutaImagen); // Le indicamos la ruta hacia la imagen que hemos conseguido con openFileDialog.FileName
                imagenBitmap.DecodePixelWidth = 95;// Con esto la imagen no se deformara por minimizarla
                imagenBitmap.DecodePixelHeight = 120;
                imagenBitmap.EndInit(); //Le decimos que termine el inicio
                Image.Source = imagenBitmap;

                //Muestro texto superior a la imagen
                textBlock_image.Visibility = Visibility.Visible;
                    
            }
        }

        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nuevaVentana = new MainWindow();
            this.Close();
            nuevaVentana.Show();
            
        }

        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            
            bool cumpleapellidos = cumpleApellidos();

            bool emailCumple = emailCumpleConRequisitos(textBox_email.Text);

            bool fechacumple = fechaCumple();

            bool telefonocumple = telefonoCumple();

            bool dniCumple = ValidarDNI(textBox_dni.Text);

            bool descripTrabajoCumple = ContarPalabras(textBox_trabajo.Text) == 62;
            bool cumplepais = cumplePais();
            bool cumpleCodigopostal = cumpleCodigoPostal();
            bool cumpleCombobox = cumpleComboBox();
            bool camposSimplesrellenos = camposSimplesRellenos();



            if (textBox_nombre.Text == "" || !cumpleapellidos
               || !emailCumple || !telefonocumple || !fechacumple || !dniCumple || !haPuestoFoto || !descripTrabajoCumple || !cumplepais || !cumpleCodigopostal || !cumpleCombobox || !camposSimplesrellenos)
            {
                textBlock_instrucciones.Visibility = Visibility.Visible;
            }
            else
            {
                Empleado nuevoEmpleado = new Empleado(textBox_nombre.Text, textBox_apellidos.Text, textBox_email.Text, textBox_telefono.Text);
                dataGrid.Items.Add(nuevoEmpleado);

                textBlock_instrucciones.Visibility = Visibility.Visible;
                textBlock_instrucciones.Text = "¡Congratulations!";
                textBlock_instrucciones.FontSize = 90;
                textBlock_instrucciones.FontFamily = new FontFamily("Old English Text MT");
                textBlock_instrucciones.Foreground = Brushes.Yellow;
            }

        }




        public class Empleado
        {
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }

            public Empleado(string nombre, string apellidos, string email, string telefono)
            {
                this.nombre = nombre;
                this.apellidos = apellidos;
                this.email = email;
                this.telefono = telefono;
            }
        }
        private void onMouseEnter_fecha(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                if (datePicker.Name == "fecha_nacimiento")
                {
                    textBlock_InstrucFecha.Visibility = Visibility.Visible;
                }
            }
        }
        private void gotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Name == "textBox_apellidos") 
                {
                    textBox.Text = "primerapellido segundoapellido";
                    textBlock_InstrucApelli.Visibility = Visibility.Visible;
                }
                else if (textBox.Name == "textBox_email") //Este no funcionara, el evento GotFocus ha sido sobrescrito en el codigo de etiquetas
                    textBox.Text = "País";
                else if (textBox.Name == "textBox_telefono")
                    textBox.Text = "Ponga el prefijo de su pais";
                else if (textBox.Name == "textBox_dni")
                    textBox.Text = "Real y con letra por favor ;D";
                else if (textBox.Name == "textBox_redsocial")
                    textBox.Text = "Animo ya casi estas!";
                else if (textBox.Name == "textBox_trabajo")
                    textBox.Text = "Nos interesa mucho lo que tenga que decir, por favor, escriba entre 61 y 63 palabras ;D";

                if (!String.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Name == "textBox_direccion")
                    {
                        textBox.Text = "Dirección";
                    }
                    else if (textBox.Name == "textBox_ciudad")
                    {
                        textBox.Text = "Ciudad";
                    }
                    else if (textBox.Name == "textBox_provincia")
                        textBox.Text = "Provincia";
                    else if (textBox.Name == "textBox_codigo")
                        textBox.Text = "Código Postal";
                    else if (textBox.Name == "textBox_pais")
                        textBox.Text = "País";
                    
                }

            }
        }

        private void lostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (String.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Name == "textBox_direccion")
                    {
                        textBox.Text = "Dirección";
                    }
                    else if (textBox.Name == "textBox_ciudad")
                    {
                        textBox.Text = "Ciudad";
                    }
                    else if (textBox.Name == "textBox_provincia")
                        textBox.Text = "Provincia";
                    else if (textBox.Name == "textBox_codigo")
                        textBox.Text = "Código Postal";
                    else if (textBox.Name == "textBox_pais")
                        textBox.Text = "País";
                }
            }
        }

        private void onMouseMoveGrid(object sender, MouseEventArgs e)
        {
            if (sender is UIElement uiElement)
            {
                // Obtén las coordenadas del ratón en relación con el Grid
                Point ratonPosition = e.GetPosition(myCanvas);

                Point botonPosition = boton_guardar.TransformToAncestor(myGrid).Transform(new Point(0, 0));

                Point newPosition = moverElBoton(botonPosition, ratonPosition, boton_guardar.Width, boton_guardar.Height);

                Canvas.SetLeft(boton_guardar, newPosition.X);
                Canvas.SetTop(boton_guardar, newPosition.Y);

                
                //Pruebas para ver que hacia en realidad el  cursor, el boton, el grid etc

               // Point centroBoton = new Point(botonPosition.X + boton_guardar.Width, botonPosition.Y + boton_guardar.Height);

               // double diferenciaX = centroBoton.X - ratonPosition.X;
               // double diferenciaY = centroBoton.Y - ratonPosition.Y;
               // myTextBlock.Text =
               //"X: " + ratonX + "\n" +
               //"Y: " + ratonY + "\n" +
               //"posicionBotonX " + botonPosition.X + "\n" +
               //"posicionBotonY " + botonPosition.Y + "\n" +
               //"gridAncho " + myGrid.Width + "\n" +
               //"gridAlto " + myGrid.Height + "\n" +
               //"diferenciaX " + diferenciaX + "\n" +
               //"diferenciaY " + diferenciaY;

            }
        }
        //Dadas la posicion en coordenadas del raton, el boton, y su altura y anchura, calcula como se movera el boton al hacercarse el cursor
        private Point moverElBoton(Point botonPosition, Point ratonPosition, Double botonWidth, Double botonHeight)
        {
            Point newPosition = new Point(botonPosition.X, botonPosition.Y);
            Double sumandoX;
            Double sumandoY;
            //Todo lo haremos respecto al centro del boton, por lo que habra que sumar Width/2 y Heigth/2 a las coordenadoas
            Point centroBoton = new Point(botonPosition.X + botonWidth / 2, botonPosition.Y + botonHeight / 2);

            //Distancia al centro del boton
            double diferenciaX = centroBoton.X - ratonPosition.X;
            double diferenciaY = centroBoton.Y - ratonPosition.Y;


            if ((Math.Abs(diferenciaX) < (botonWidth / 2 + 10)) && (Math.Abs(diferenciaY) < (botonHeight / 2 + 10))) // Si el raton esta cerca del boton
            {
                sumandoX = centroBoton.X - ratonPosition.X;
                sumandoY = centroBoton.Y - ratonPosition.Y;

                newPosition = new Point(botonPosition.X + sumandoX, botonPosition.Y + sumandoY);

                //Limite izquierda
                if (newPosition.X < 12) newPosition = new Point(1, newPosition.Y);
                //Limite derecha
                if (newPosition.X + botonWidth > myGrid.Width - 12) newPosition = new Point(myGrid.Width - botonWidth - 1, newPosition.Y);
                //Limite top
                if (newPosition.Y < 12) newPosition = new Point(newPosition.X, 1);
                //Limite bottom
                if (newPosition.Y + botonHeight > myGrid.Height - 12) newPosition = new Point(newPosition.X, myGrid.Height - botonHeight - 1);

                if ((newPosition.Y + botonHeight > myGrid.Height - 12) && (newPosition.X < 12) || (newPosition.Y + botonHeight > myGrid.Height - 12) && (newPosition.X + botonWidth > myGrid.Width - 12))
                {
                    newPosition = new Point(600, 228);
                    Thread.Sleep(1500);
                }

            }

            return newPosition;

        }

        /**
         * Metodos auxiliares de verificacion de campos
         */
        private bool cumpleApellidos()
        {
            if (String.IsNullOrEmpty(textBox_apellidos.Text))
            {
                return false;
            }
            if(textBox_apellidos.Text == "Primerapellido Segundoapellido")
            {
                return false;
            }

            //Split guay
            string[] palabras = textBox_apellidos.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            
            int cantidadPalabras = palabras.Length;
            if(cantidadPalabras >= 2)//Para que no de indexOutOfBounds error
            {
                if (char.IsUpper(palabras[0][0]) && char.IsUpper(palabras[1][0]))
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }  
        }

        private int ContarPalabras(string texto)
        {
            
            string[] palabras = texto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            
            int cantidadPalabras = palabras.Length;

            return cantidadPalabras;
        }

        private bool emailCumpleConRequisitos(string cadena)
        {
            // Verificar si la cadena es nula o vacía
            if (string.IsNullOrEmpty(cadena))
            {
                return false;
            }

            // Contar el número de @ y "."
            int contadorArroba = cadena.Count(c => c == '@');
            int contadorPunto = cadena.Count(c => c == '.');

            return contadorArroba == 1 && contadorPunto >= 1;
        }

        private bool fechaCumple()
        {
            DateTime? fechaSeleccionada = fecha_nacimiento.SelectedDate as DateTime?;
            if (fecha_nacimiento.SelectedDate.HasValue)
            {
                return 2024 - fecha_nacimiento.SelectedDate.Value.Year < 65;
            }
            else
            {
                return false;
            }
            
        }

        private bool telefonoCumple()
        {
            if (!String.IsNullOrEmpty(textBox_telefono.Text) && textBox_telefono.Text.Length == 12)
            {
                return textBox_telefono.Text[0] == "+"[0] && textBox_telefono.Text[1] == "3"[0] && textBox_telefono.Text[2] == "4"[0] && textBox_telefono.Text[3] == "6"[0];
            }
            else
            {
                return false;
            }
        }

        private bool ValidarDNI(string dni)
        {
            if (string.IsNullOrEmpty(dni) || dni.Length != 9)
            {
                return false;
            }

            string numeros = dni.Substring(0, 8);
            char letraOriginal = dni.ToUpper()[8];

            if (int.TryParse(numeros, out int numero))
            {
                int resto = numero % 23;
                char letraCalculada = ObtenerLetraDNI(resto);

                return letraCalculada == letraOriginal;
            }

            return false;
        }

        private char ObtenerLetraDNI(int resto)
        {
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            return letras[resto];
        }

        private bool cumplePais()
        {
            if (!String.IsNullOrEmpty(textBox_pais.Text))
            {
                return textBox_pais.Text.Equals("España");
            }
            else
            {
                return false;
            }
        }

        private bool cumpleCodigoPostal()
        {
            if (!String.IsNullOrEmpty(textBox_pais.Text))
            {
                return textBox_codigo.Text.Length == 5;
            }
            else
            {
                return false;
            }
        }

        private bool cumpleComboBox()
        {
            return combo_rol.SelectedItem == null;
        }

        private bool camposSimplesRellenos()
        {
            return !(String.IsNullOrEmpty(textBox_nombre.Text) || String.IsNullOrEmpty(textBox_direccion.Text) || String.IsNullOrEmpty(textBox_provincia.Text) || String.IsNullOrEmpty(textBox_ciudad.Text) || String.IsNullOrEmpty(textBox_redsocial.Text));
        }

        
       
    }
}
