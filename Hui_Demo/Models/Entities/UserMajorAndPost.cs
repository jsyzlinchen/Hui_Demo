using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hui_Demo.Models.Entities
{
    public class UserMajorAndPost
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MajorID { get; set; }
        public int PostID { get; set; }
        public virtual Major Major { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}