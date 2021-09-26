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
using System.Windows.Shapes;

namespace TicTacToeServer {
    /// <summary>
    /// Логика взаимодействия для ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window {

        public string IpAddress { get; set; }
        public int Port { get; set; }

        public ConfigWindow() {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void okButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(ipAddressTextBox.Text)) {
                MessageBox.Show(
                    "Введите IP адресс сервера!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            if (string.IsNullOrEmpty(ipAddressTextBox.Text)) {
                MessageBox.Show(
                    "Введите порт сервера!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }

            IpAddress = ipAddressTextBox.Text;
            try {
                Port = int.Parse(portTextBox.Text);
            }
            catch (FormatException) {

                MessageBox.Show(
                    "Номер порта может состоять только из чисел!",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            DialogResult = true;
        }
    }
}
