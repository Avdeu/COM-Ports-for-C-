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
using System.IO.Ports;

namespace ComPort
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort sport = new SerialPort();
        SerialPort sport1 = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                sport.DiscardInBuffer();
                sport.Write(TextBox3.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                var str = sport1.ReadExisting();
                TextBox4.Text = str;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                sport.PortName = cboPort.Text;
                sport.Open();
                txtSt.Text = "Подключено";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                sport1.PortName = cboPort_1.Text;
                sport1.Open();
                txtSt_1.Text = "Подключено";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                sport.Close();
                txtSt.Text = "Отключено";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try // Открываем порт
            {
                sport1.Close();
                txtSt_1.Text = "Отключено";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports != null)
                foreach (var i in ports) cboPort.Items.Add(i);
            cboPort.SelectedIndex = -1;

            if (ports != null)
                foreach (var i in ports) cboPort_1.Items.Add(i);
            cboPort_1.SelectedIndex = -1;
        }
    }
}
