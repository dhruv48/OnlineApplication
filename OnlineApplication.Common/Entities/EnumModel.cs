using OnlineApplication.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.Common.Entities
{
    public class EnumModel
    {
        [Required(ErrorMessage="Technical Parameters Required")]
        public TechnicalParameters  TechnicalParameters { get; set; }
        //public int Id { get; set; }
        public  bool IsSelected { get; set; }
    }
}
