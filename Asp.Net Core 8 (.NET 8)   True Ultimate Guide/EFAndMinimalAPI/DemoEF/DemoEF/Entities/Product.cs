﻿namespace DemoEF.Entities
{
    public class Product
    {
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductLine { get; set; }
        public string? ProductScale { get; set; }
        public string? ProductVendor { get; set; }
        public string? ProductDescription { get; set; }
        public Int16 QuantityInStock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal MSRP { get; set; }
        public virtual ProductLines ProductLines { get; set; }

    }
}
