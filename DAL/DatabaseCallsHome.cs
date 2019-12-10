using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DatabaseCallsHome
    {
        private readonly DatabaseCalls _databaseCalls = new DatabaseCalls();
        public DataTable GetAllProducts()
        {
            string query = "SELECT p.name, p.description, p.price, p.image, s.stock, v.type, v.value FROM products p INNER JOIN products_stock s ON p.productid = s.productid INNER JOIN products_variations ON s.products_stockid = products_variations.products_stockid INNER JOIN variations v ON products_variations.variationid = v.variationid";
            //string query = "SELECT * FROM products";
            return _databaseCalls.Select(query, null);
        }

    }
}
