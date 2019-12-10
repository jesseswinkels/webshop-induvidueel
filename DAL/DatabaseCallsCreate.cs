using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Datamodels;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DatabaseCallsCreate
    {
        private readonly DatabaseCalls _databaseCalls = new DatabaseCalls();
        public void CreateProduct(ProductDataModel product)
        {
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>();
            string query = @"INSERT INTO products (`name`, `description`, `price`, `image`)VALUES(@name, @description, @price, @image)";

            sqlParameters.Add(new MySqlParameter("@name", product.Name));
            sqlParameters.Add(new MySqlParameter("@description", product.Description));
            sqlParameters.Add(new MySqlParameter("@price", product.Price));
            sqlParameters.Add(new MySqlParameter("@image", product.Image));

            int productid = (int)_databaseCalls.CommandWithLastId(query, sqlParameters);

            sqlParameters.Clear();

            query = @"INSERT INTO `products_stock` (`products_stockid`, `productid`, `stock`) VALUES (NULL, @productid, @stock);";

            sqlParameters.Add(new MySqlParameter("@productid", productid));
            sqlParameters.Add(new MySqlParameter("@stock", product.Stock));

            int stockid = (int)_databaseCalls.CommandWithLastId(query, sqlParameters);

            sqlParameters.Clear();

            query = @"INSERT INTO `variations` (`type`, `value`) VALUES (@type, @value)";
            sqlParameters.Add(new MySqlParameter("@type", product.VariationType));
            sqlParameters.Add(new MySqlParameter("@value", product.VariationValue));

            int variationid = (int)_databaseCalls.CommandWithLastId(query, sqlParameters);

            sqlParameters.Clear();

            query = @"INSERT INTO `products_variations` (`products_variationsid`, `products_stockid`, `variationid`) VALUES (NULL, @stockid, @variationid)";
            sqlParameters.Add(new MySqlParameter("@stockid", stockid));
            sqlParameters.Add(new MySqlParameter("@variationid", variationid));

            _databaseCalls.Command(query, sqlParameters);
        }
    }
}
