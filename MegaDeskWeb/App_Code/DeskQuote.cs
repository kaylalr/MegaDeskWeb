using System;
using System.IO;

namespace MegaDesk
{
    public class DeskQuote
    {

        // constants
        const decimal BASE_DESK_PRICE = 200.00M;
        const decimal SURFACE_AREA_COST = 1.00M;
        const decimal DRAWER_COST = 50.00M;
        const decimal OAK_COST = 200.00M;
        const decimal LAMINATE_COST = 100.00M;
        const decimal PINE_COST = 50.00M;
        const decimal ROSEWOOD_COST = 300.00M;
        const decimal VENEER_COST = 125.00M;

        // enums
        public enum Delivery
        {
            Rush3Days,
            Rush5Days,
            Rush7Days,
            Normal14Days
        }

        public Desk Desk { get; set; }
        public string Shipping { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int[,] rushOrder = new int[3, 3];

        public DeskQuote(Desk desk, string time, string name, DateTime date)
        {
            Desk = desk;
            Shipping = time;
            Customer = name;
            Date = date;
            Price = GetQuote(desk, time);
        }

        public decimal GetQuote(Desk desk, string time)
        {
            decimal totalQuote = BASE_DESK_PRICE;
            decimal surfaceArea = desk.Width * desk.Depth;

            if (surfaceArea > 1000)
            {
                totalQuote += (surfaceArea - 1000);
            }

            if (desk.Drawers != 0)
            {
                totalQuote += (desk.Drawers * 50);
            }

            var db = WebMatrix.Data.Database.Open("MegaDeskWeb");

            var surfaceQuery = db.Query("SELECT Cost FROM SurfaceMaterial WHERE SurfaceMaterial = @0", desk.Material);
            foreach (var row in surfaceQuery)
            {
                totalQuote += row;
            }

            var shippingQuery = db.Query("SELECT * FROM Shipping WHERE NumOfDays = @0");
            foreach (var row in shippingQuery)
            {
                if (surfaceArea < 1000)
                {
                    totalQuote += row.CostLess1000;
                }
                else if (surfaceArea > 2000)
                {
                    totalQuote += row.CostGreater2000;
                }
                else
                {
                    totalQuote += row.Cost1000to2000;
                }
            }
            
            return totalQuote;
        }
    }
}
