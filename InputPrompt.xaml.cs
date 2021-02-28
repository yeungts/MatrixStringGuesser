using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test1
{
    /// <summary>
    /// Interaction logic for InputPrompt.xaml
    /// </summary>
    public partial class InputPrompt : Window
    {
        public String inputString { get; set; }
        private static InputPrompt instance = null;
        private InputPrompt() 
        { 
            InitializeComponent(); 
        }

        public static InputPrompt Instance
        {
            get
            {
                if (instance == null)
                { instance = new InputPrompt(); }
                else
                { instance.txtInputString.Text = null; }
                return instance;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            inputString = txtInputString.Text;
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
