using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Evi_Exam_09.Models.ViewModels
{
    public class UserModel
    {
        [Required,StringLength(20,MinimumLength =6)]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password), StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
