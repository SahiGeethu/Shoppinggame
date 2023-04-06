using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGame.Models;

namespace ShoppingGame.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            CheckoutCal obj = new CheckoutCal();
            obj.scan("atv", 109.50);
            obj.scan("atv", 109.50);
            obj.scan("atv", 109.50);
            obj.scan("vtg", 30);
            obj.Total();
           

            CheckoutCal obj1 = new CheckoutCal();
            obj1.scan("atv", 109.50);
            obj1.scan("ipd", 549.99);
            obj1.scan("ipd", 549.99);
            obj1.scan("atv", 109.50);
            obj1.scan("ipd", 549.99);
            obj1.scan("ipd", 549.99);
            obj1.scan("ipd", 549.99);
            obj1.Total();

            CheckoutCal obj2 = new CheckoutCal();
            obj2.scan("ipd", 549.99);
            obj2.scan("mbp", 1399.99);
            obj2.scan("vtg", 30);
            obj2.Total();

            DataTable dt = new DataTable();

            dt.Columns.Add("SKU", typeof(System.String));
            dt.Columns.Add("Qty", typeof(System.String));
            dt.Columns.Add("Price", typeof(System.Decimal));
            dt.Columns.Add("Total", typeof(System.Decimal));

            DataRow dr;
            foreach (var item in obj.cart_price)
            {

                dr = dt.NewRow();
                dr["SKU"] = item.Key;
                dr["Qty"] = obj.cart_sku[item.Key];
                dr["Price"] = item.Value;
                dr["Total"] = obj.Total();
                dt.Rows.Add(dr);
            }

            DataTable dt1 = new DataTable();

            dt1.Columns.Add("SKU", typeof(System.String));
            dt1.Columns.Add("Qty", typeof(System.String));
            dt1.Columns.Add("Price", typeof(System.Decimal));
            dt1.Columns.Add("Total", typeof(System.Decimal));

            DataRow dr1;
            foreach (var item in obj1.cart_price)
            {

                dr1 = dt1.NewRow();
                dr1["SKU"] = item.Key;
                dr1["Qty"] = obj1.cart_sku[item.Key];
                dr1["Price"] = item.Value;
                dr1["Total"] = obj1.Total();
                dt1.Rows.Add(dr1);
            }

            DataTable dt2 = new DataTable();

            dt2.Columns.Add("SKU", typeof(System.String));
            dt2.Columns.Add("Qty", typeof(System.String));
            dt2.Columns.Add("Price", typeof(System.Decimal));
            dt2.Columns.Add("Total", typeof(System.Decimal));

            DataRow dr2;
            foreach (var item in obj2.cart_price)
            {

                dr2 = dt2.NewRow();
                dr2["SKU"] = item.Key;
                dr2["Qty"] = obj2.cart_sku[item.Key];
                dr2["Price"] = item.Value;
                dr2["Total"] = obj2.Total();
                dt2.Rows.Add(dr2);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);

            Products Objprod = new Products();
            Objprod.dtProducts = ds;

            return View(Objprod);
        }
    }
}