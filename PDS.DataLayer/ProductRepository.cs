using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDS.DomainModel;

namespace PDS.DataLayer
{
    public class ProductRepository
    {
        List<Product> _products = new List<Product>() {
                                               new Product{ Id=200000, Name="Prozac", NDC = "123324234234", DrugClass=0},
                                               new Product{  Id=200001,Name="Amoxicillin", NDC= "34343434", DrugClass=1}
                                                };

        public Product Load(int productId)
        {
            var product = _products.SingleOrDefault(p => p.Id == productId);

            if (product == null)
            {
                product = new Product { Id = productId, DrugClass = 0, Name = "NO PRODUCT", NDC = "0000000000" };
            }
            return product;
        }

        public List<Product> SearchForProducts(string drugName, string NDC)
        {
            return _products;
        }
           
    }

   
}
