using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJobApi.DataModels;
using TestJobApi.Repositories.Interface;

namespace TestJobApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly MyAplicationContext db;
        public ProductRepository(MyAplicationContext _db)
        {
            db = _db;
        }

        public Product InsertProduct(Product model)
        {
            db.Product.Add(model);
            db.SaveChanges();

            return model;
        }

    }
}
