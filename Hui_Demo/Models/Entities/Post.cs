using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hui_Demo.Models.Entities
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        [StringLength(16)]
        public string Title { get; set; }
        public int Sort { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int TypeFlag { get; set; }
        public int SFFZY { get; set; }
        public int IsSystem { get; set; }
        public bool DeleteFlag { get; set; }
    }
}