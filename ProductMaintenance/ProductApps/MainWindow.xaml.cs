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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        // Added Constant Decimal for Delivery Charge
        const decimal DELIVERY_CHARGE = 25m;

        // Added Constant Decimal for Wrap Charge
        const decimal WRAP_CHARGE = 5m;

        // Added Constant Decimal for Wrap Charge
        const decimal GST_CHARGE = 0.1m;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();

                // Output the total payment
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                // Calculate and display the total charge including delivery
                decimal totalDeliveryCharge = cProduct.TotalPayment + DELIVERY_CHARGE;
                totalDeliveryChargeTextBlock.Text = totalDeliveryCharge.ToString("C");

                // Calculate and display the total charge including wrap
                decimal totalWrapCharge = totalDeliveryCharge + WRAP_CHARGE;
                totalWrapChargeTextBlock.Text = totalWrapCharge.ToString("C");

                // Calculate and display the total charge including GST
                decimal totalGSTCharge = totalWrapCharge + (totalWrapCharge * GST_CHARGE);
                totalGSTChargeTextBlock.Text = totalGSTCharge.ToString("C");

            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalDeliveryChargeTextBlock.Text = "";
            totalWrapChargeTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
