using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_Evi_Exam_09.Models;
using Angular_Evi_Exam_09.Models.ViewModels;

namespace Angular_Evi_Exam_09.Repositories
{
    public class ProductRepo : IRepo
    {
        private ApplicationDbContext db=null;
        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
            this.db.Database.EnsureCreated();
        }
        public void Delete(int id)
        {
            var p = new Product { Id = id };
            db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.First(x=>x.Id==id);
        }

        public IList<ProductVm> GetData()
        {
            return db.Products.Select(x => new ProductVm
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Discount = x.Discount
            }).OrderBy(x => x.Id).ToList();
        }

        public void Insert(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void Update(Product p)
        {
            db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

           
        }
    }
}
