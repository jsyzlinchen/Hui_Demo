using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Hui_Demo.Models.Entities
{
    public class User
    {
        [Key]
        public int ID { set; get; }
        [StringLength(16)]
        [Required]
        public string UserName { set; get; }      //帐号
        [StringLength(64)]
        [Required]
        public string UserPassword { set; get; }    //密码
        [StringLength(64)]
        [Required]
        public string ConfirmPassword { set; get; }  //确认密码
        [StringLength(50)]
        [Required]
        public string Name { set; get; }        //姓名
        [StringLength(16)]
        public string Phone { set; get; }           //手机
        [StringLength(100)]
        public string Portrait { set; get; }           //头像
        public int Gender { set; get; }         //性别
        public int Age { set; get; }            //年龄       
        [StringLength(32)]
        public string Mail { get; set; }        //Email
        [StringLength(32)]
        public string  Company { set; get; }    //公司
        [Required]
        [DefaultValue(false)]//默认为false
        public bool DeleteFlag { set; get; }     //删除flag
        [Required]
        [DefaultValue(0)]//默认为0 内部
        public int TypeFlag { get; set; }          //帐号类型
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime LogTime { set; get; }    //记录时间
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime LastTime { set; get; }    //最后登陆时间
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatTime { set; get; }   //建立时间
    }
}