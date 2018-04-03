using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hui_Demo.Models.Entities
{
    public class Major
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public int Sort { get; set; }
        public bool IsSystem { get; set; }
    }
}