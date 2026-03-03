using Avalonia.Controls;
using Avalonia.Interactivity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace техносервис
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var login = Login.Text;
            var password = Password.Text;

           
            
            
        }
    }
}