using DAL;
using Datamodels;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class CreateLogic
    {
        private readonly DatabaseCallsCreate _databaseCalls = new DatabaseCallsCreate();

        public bool CreateNewProduct(ProductDataModel product)
        {
            _databaseCalls.CreateProduct(product);
            return true;
        }
    }
}
