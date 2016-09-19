using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCalcChargeApp
{
    class RunCalculation: INotifyPropertyChanged
    {
        //vars
        private string startPriceVal = string.Empty;
        private string tipVal = string.Empty;
        private string taxVal = string.Empty;
        private string totalVal = string.Empty;

        //properties
        
        //input price value
        public string StartPriceVal
        {
            get { return startPriceVal; }
            set { startPriceVal = value; }
        }
        //output Tip amount
        public string TipVal
        {
            get { return tipVal; }
            set { tipVal = value; OnPropertyChanged(); }
        }
        //output Tax amount     
        public string TaxVal
        {
            get { return taxVal; }
            set { taxVal = value; OnPropertyChanged(); }
        }
        //output Total amount
        public string TotalVal
        {
            get { return totalVal; }
            set { totalVal = value; OnPropertyChanged(); }
        }

        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
