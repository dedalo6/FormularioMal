using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataBindingFormularios
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Alternativa para poner un Event y un Handler en UIElement (textBox) pero esta en App.Resources (Sin probar)
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewKeyDownEvent, new KeyEventHandler(TextBox_PreviewKeyDown));
        //}


        //Indicamos que si la tecla presionada (que nos lo dice el key event) es igual a Key.Tab (tabulador) que no haga nada 
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                e.Handled = true; // Marcar el evento de la tecla como manejada para evitar el cambio de foco
            }
        }
    }
}
