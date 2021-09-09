using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VictoryTransportApp.Model
{
    public class Load
    {
        public int Uid { get; set; }
        public string LoadNo { get; set; }
        public string Status { get; set; }
        public string TruckNo { get; set; }
        public string DriverName { get; set; }
        public string BrokerName { get; set; }
        public string DispatcherName { get; set; }
        public double LoadPrice { get; set; }
        public double DriverFee { get; set; }
        public string CustomerTitle { get; set; }
        public string PickCompany { get; set; }
        public string PickAddressFirstLine { get; set; }
        public string PickAddressSecondLine { get; set; }
        public DateTime PickDateStart { get; set; }
        public DateTime? PickDateEnd { get; set; }
        public string DelCompany { get; set; }
        public string DelAddressFirstLine { get; set; }
        public string DelAddressSecondLine { get; set; }
        public DateTime DelDateStart { get; set; }
        public DateTime? DelDateEnd { get; set; }
        public string Note { get; set; }
        public double TollCost { get; set; }
        public double FuelCost { get; set; }
        public double TotalCost { get; set; }
        public double Mile { get; set; }
        public double MilePrice { get; set; }
        public string RateNo { get; set; }
        public string Billed { get; set; }
    }
}