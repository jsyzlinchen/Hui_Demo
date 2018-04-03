namespace Hui_Demo.Models
{
    using Hui_Demo.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class DataModel : DbContext
    {

        public DataModel() : base("name=DataModel")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
            //或者
            //移除默认约定规则，比如在表名后默认加上“s”
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        public DbSet<User> User { get; set; }

        public DbSet<SysLog> SysLog { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Major> Major { get; set; }

        public DbSet<UserMajorAndPost> UserMajorAndPost { get; set; }


    }
}