using Angular_Evi_Exam_09.Models;
using Angular_Evi_Exam_09.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Evi_Exam_09.Repositories
{
    public interface IRepo
    {
        IList<Product> GetAll();
        IList<ProductVm> GetData();
        Product GetById(int id);
        void Insert(Product p);
        void Update(Product p);
        void Delete(int id);
    }
}
