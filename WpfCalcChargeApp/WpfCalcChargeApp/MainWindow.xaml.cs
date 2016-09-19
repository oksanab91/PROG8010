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
using System.ComponentModel;

namespace WpfCalcChargeApp
{
    /// <summary>
    /// ===========================================================================================
    /// Created by Group #2 on 2016-09-18.
    /// Assignment #2:
    /// Create an application that lets the user enter the food charge for a meal at a restaurant. 
    /// When a button is clicked, the application should calculate and display: 
    /// the amount of a 15 percent tip, 
    /// 7 percent sales tax 
    /// and the total of all three amounts.
    /// ===========================================================================================
    /// </summary>
    public partial class CalcAmount : Window
    {
        RunCalculation runCalcObj = new RunCalculation();
        
        public CalcAmount()
        {
            InitializeComponent();            
            DataContext = runCalcObj;
        }

        //Calculates amount and sets results into the class object
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal priceNum = 0;
                decimal tipNum = 0;
                decimal taxNum = 0;
                decimal totalNum = 0;

                //Clears the controls
                tblTipAmount.Text = string.Empty;
                tblTaxAmount.Text = string.Empty;
                tblTotalAmount.Text = string.Empty;
                
                //Validates input
                if (decimal.TryParse(tbFoodPrice.Text, out priceNum))
                {
                    if (priceNum > 0)
                    {
                        //performs calculation & rounding
                        priceNum = decimal.Round(priceNum, 2, MidpointRounding.AwayFromZero);
                        tipNum = decimal.Round(priceNum * 0.15m, 2, MidpointRounding.AwayFromZero);
                        taxNum = decimal.Round(priceNum * 0.07m, 2, MidpointRounding.AwayFromZero);
                        totalNum = decimal.Round((priceNum + tipNum + taxNum), 2, MidpointRounding.AwayFromZero);
                        

                        //assigns results into the class object
                        runCalcObj.TipVal = tipNum.ToString();
                        runCalcObj.TaxVal = taxNum.ToString();
                        runCalcObj.TotalVal = totalNum.ToString(); //totalNum.ToString(N2)
                        runCalcObj.StartPriceVal = priceNum.ToString();
                        tbFoodPrice.Text= runCalcObj.StartPriceVal;
                    }
                }             
            }
            catch { }           
            finally
            {
                //if object is empty, there is invalid input
                if (runCalcObj.StartPriceVal == string.Empty)
                {
                    MessageBox.Show("Please enter a valid meal charge.");
                }
                runCalcObj.StartPriceVal = string.Empty;
                //runCalcObj.TipVal = string.Empty;
                //runCalcObj.TaxVal = string.Empty;
                //runCalcObj.TotalVal = string.Empty;
            }
        }
    }
}
