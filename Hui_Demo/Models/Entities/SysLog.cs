using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Hui_Demo.Models.Entities
{
    public partial class SysLog
    {
        [Key]
        public int ID { get; set; }
        [StringLength(16)]
        public string Name { get; set; }
        [StringLength(32)]
        public string UserName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LogTime { get; set; }
        [StringLength(200)]
        public string Content { get; set; }
        [StringLength(32)]
        public string Title { get; set; }
        public int Level { get; set; }
        public int TypeFlag { get; set; }
    }
}