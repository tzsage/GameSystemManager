using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper.DBContext
{
    public class SystemDBContext: DbContext
    {
        public SystemDBContext()
            : base("name=SystemFrameworkDbContext")
        {
          
        }

        public DbSet<TestEntiry> Users { get; set; }

        /// <summary>
        /// 配置实体类通过map对应到数据库表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DataHelper.DLL", "Mapping.DLL").Replace("file:///", "");
            Assembly asm = Assembly.LoadFile(assembleFileName);
            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }


    public class TestEntiry
    {
       public long MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public string MenuStatus { get; set; }
    }
  

}
