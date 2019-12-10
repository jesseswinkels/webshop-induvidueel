using System;

namespace Datamodels
{
    public class ProductDataModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Stock { get; set; }
        public string VariationType { get; set; }
        public string VariationValue { get; set; }
    }
}
