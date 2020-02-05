using System;
using System.Collections.Generic;

namespace DrillDownChart.Models {
    public class DevAVDataItem {
        public static DevAVDataItem CreateByNameProductCategoryRegionSales(DateTime date, string productName, string productCategory, string region, decimal sales) {
            DevAVDataItem item = new DevAVDataItem();
            item.SaleDate = date;
            item.ProductName = productName;
            item.ProductCategory = productCategory;
            item.Region = region;
            item.Sales = sales;
            return item;
        }
        public string Region { get; private set; }
        public decimal Sales { get; private set; }
        public string ProductCategory { get; private set; }
        public string ProductName { get; private set; }
        public DateTime SaleDate { get; private set; }
        public DevAVDataItem() { }
    }

    public class DevAV {
        readonly static string[] regions = new string[] { "DevAV North", "DevAV South", "DevAV West", "DevAV East", "DevAV Central" };
        static Dictionary<string, List<string>> categorizedProducts;

        public static Dictionary<string, List<string>> CategorizedProducts {
            get {
                if (categorizedProducts == null) {
                    categorizedProducts = new Dictionary<string, List<string>>();
                    categorizedProducts["Cameras"] = new List<string>() { "Camera", "Camcorder", "Binoculars", "Flash", "Tripod" };
                    categorizedProducts["Cell Phones"] = new List<string>() { "Smartphone", "Mobile Phone", "Smart Watch", "Sim Card" };
                    categorizedProducts["Computers"] = new List<string>() { "Desktop", "Laptop", "Tablet", "Printer" };
                    categorizedProducts["TV, Audio"] = new List<string>() { "Television", "Home Audio", "Headphone", "DVD Player" };
                    categorizedProducts["Vehicle Electronics"] = new List<string>() { "GPS Unit", "Radar", "Car Alarm", "Car Accessories" };
                    categorizedProducts["Multipurpose Batteries"] = new List<string>() { "Battery", "Charger", "Converter", "Tester", "AC/DC Adapter" };
                }
                return categorizedProducts;
            }
        }

        static List<DevAVDataItem> totalSales;
        public static List<DevAVDataItem> GetTotalSales() {
            if (totalSales == null) {
                Random rnd = new Random(DateTime.Now.Millisecond);
                DateTime now = DateTime.Now;
                DateTime endDate = new DateTime(now.Year, now.Month, 1);
                List<DevAVDataItem> items = new List<DevAVDataItem>();
                foreach (string region in regions) {
                    double companyFactor = rnd.NextDouble() * 0.6 + 1;
                    foreach (string productCategory in CategorizedProducts.Keys) {
                        double categoryFactor = rnd.NextDouble() * 0.6 + 1;
                        foreach (string productName in CategorizedProducts[productCategory]) {
                            int maxSales = rnd.Next(60, 140);
                            for (int i = 0; i < 1000; i++) {
                                if (i % 100 == 0)
                                    maxSales = Math.Max(40, rnd.Next(maxSales - 20, maxSales + 20));
                                DateTime date = endDate.AddDays(-i - 1);
                                decimal sales = Convert.ToDecimal(rnd.Next(20, maxSales) * companyFactor * categoryFactor);
                                items.Add(DevAVDataItem.CreateByNameProductCategoryRegionSales(date, productName, productCategory, region, sales));
                            }
                        }
                    }
                }
                totalSales = items;
            }
            return totalSales;
        }
    }
}