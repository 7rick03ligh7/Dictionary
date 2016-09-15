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

namespace Dictionary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);         
        }


        public event EventHandler SearchClick = null;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            SearchClick.Invoke(sender, e);
        }
        

        public event EventHandler ClickAlphabet = null;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button10_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button11_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button13_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button14_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button15_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button16_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button17_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button18_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button19_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button20_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button21_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button22_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button23_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button24_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button25_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button26_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button27_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button28_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }
        private void button29_Click(object sender, RoutedEventArgs e)
        {
            ClickAlphabet.Invoke(sender, e);
        }


        public event EventHandler RestoreDef = null;
        private void RestoreDefault_Click(object sender, RoutedEventArgs e)
        {
            RestoreDef.Invoke(sender, e);
        }


        public event EventHandler MakeBackup = null;
        private void Backup1_Click(object sender, RoutedEventArgs e)
        {
            MakeBackup.Invoke(sender, e);
        }
        private void Backup2_Click(object sender, RoutedEventArgs e)
        {
            MakeBackup.Invoke(sender, e);
        }


        public event EventHandler RestoreBackup = null;
        private void Backup3_Click(object sender, RoutedEventArgs e)
        {
            RestoreBackup.Invoke(sender, e);
        }
        private void Backup4_Click(object sender, RoutedEventArgs e)
        {
            RestoreBackup.Invoke(sender, e);
        }


        public event EventHandler ListSelect = null;
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListSelect.Invoke(sender, e);  
        }


        public event EventHandler Edit = null;
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit.Invoke(sender, e);
        }


        public event EventHandler Add = null;
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add.Invoke(sender, e);
        }


        public event EventHandler Remove = null;
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            Remove.Invoke(sender, e);
        }
    }
}
