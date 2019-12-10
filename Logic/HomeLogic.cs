using DAL;
using Datamodels;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logic
{
    public class HomeLogic
    {
        private readonly DatabaseCallsHome _databaseCalls = new DatabaseCallsHome(); 
        public List<ProductDataModel> GetAllProducts()
        {
            List<ProductDataModel> result = new List<ProductDataModel>();

            
            foreach(DataRow row in _databaseCalls.GetAllProducts().Rows)
            {
                ProductDataModel product = new ProductDataModel
                {
                    Name = row[0].ToString(),
                    Description = row[1].ToString(),
                    Price = Convert.ToDecimal(row[2]),
                    Image = (byte[])row[3],
                    Stock = Convert.ToInt32(row[4])
                    
                };
                result.Add(product);
            }
            return result;
        }
    }
}
