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

namespace Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random r = new Random();
        private Actions actions = new Actions();
        private Matrix matrix;

        public MainWindow()
        {
            InitializeComponent();
            tbxMatrix.Text = "Matrix is currently empty";
            rbBrightMode.IsChecked = true;
        }

        private void btnGetMatrix_Click(object sender, RoutedEventArgs e)
        {
            String inputString, resultString;
            tbxMatrix.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            tbxMatrix.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            try
            {
                int width = Convert.ToInt32(txtWidth.Text);
                // Throw an exception if width is less than 5
                if (width < 5)
                { throw new ArgumentOutOfRangeException(); }
                else if (width > 30)
                { // Display the scroll bar when width is greater than 30
                    tbxMatrix.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                    tbxMatrix.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                }

                matrix = new Matrix(width);

                tbxMatrix.Text = matrix.GetMatrixDisplay(r);

                inputString = GetUserInput();

                if (inputString == "") { return; }

                resultString = actions.IsStringExist(inputString, matrix.Coordinates);

                MessageBox.Show(resultString);

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter positive number", "Invalid value", MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Width have to be greater than or equal to 5", "Invalid value", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rbDarkMode_Checked(object sender, RoutedEventArgs e)
        {
            DarkMode();
        }

        private void rbBrightMode_Checked(object sender, RoutedEventArgs e)
        {
            BrightMode();
        }

        private String GetUserInput()
        {
            // Prompt user for string input
            InputPrompt promptBox = InputPrompt.Instance;

            do
            {
                promptBox.ShowDialog();
                if (promptBox.inputString == null) 
                {
                    return ""; 
                }
                else if (promptBox.inputString == "")
                {
                    promptBox.inputString = null;
                    MessageBox.Show("Please enter a string to search", "Missing input",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (promptBox.inputString.Length == 1)
                {
                    MessageBox.Show("Please enter a string to search", "Single Character not allowed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    promptBox.inputString = null;
                }

            } while (promptBox.inputString == null || promptBox.inputString == "");

            return promptBox.inputString;
        }

        private void DarkMode()
        {
            Application.Current.Resources["theBtnBackgroundBrush"] = 
                new SolidColorBrush(Color.FromRgb(129, 129, 129));
            Application.Current.Resources["theBackgroundBrush"] = 
                new SolidColorBrush(Color.FromRgb(40, 40, 40));
            Application.Current.Resources["theForegroundBrush"] = 
                new SolidColorBrush(Colors.White);
        }

        private void BrightMode()
        {
            Application.Current.Resources["theBtnBackgroundBrush"] = 
                new SolidColorBrush(Colors.LightGray);
            Application.Current.Resources["theBackgroundBrush"] = 
                new SolidColorBrush(Colors.White);
            Application.Current.Resources["theForegroundBrush"] = 
                new SolidColorBrush(Colors.Black);
        }
    }
}
