using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Evi_Exam_09.Models.ViewModels
{
    public class ProductVm
    {
        public int Id { get; set; }
        [Required, StringLength(44)]
        public string Name { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        public decimal Discount { get; set; }
        public decimal CurrentPrice
        {
            get
            {
                return this.Price * (1 - this.Discount);
            }
        }
    }
}
