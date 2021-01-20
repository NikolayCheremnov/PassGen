using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace PassGen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // событие нажатия кнопки генерации пароля
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            // make domain for pass
            string domain = "";
            if (CheckLowercaseLetters.IsChecked == true)
                domain += "abcdefghijklmnopqrstuvwxyz";
            if (CheckUppercaseLetters.IsChecked == true)
                domain += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (CheckDigits.IsChecked == true)
                domain += "0123456789";
            if (CheckPunctuationMarks.IsChecked == true)
                domain += "!\"$%&\'()+,-./;:<=>?@[]^_{|}`~\\/";
            domain += Added.Text;

            // make pass
            Random rnd = new Random();
            int length = Convert.ToInt32(PassLen.Text);
            string pass = "";
            for (int i = 0; i < length; i++)
                pass += domain[rnd.Next(1, domain.Length - 1)];
            Result.Text = pass;

            // post-actions
            if (CheckCopy.IsChecked == true)
                Clipboard.SetData(DataFormats.Text, (Object)pass);
        }
    }
}
