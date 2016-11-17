/****************************************************************************************************************************************************************/
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Data
{
    /// <summary>
    /// EF 数据库连接信息
    /// </summary>
    public class SYSDbContext : DbContext
    {
        public SYSDbContext()
            : base("name=NFineDbContext")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("DataHelper.DLL", "Mapping.DLL").Replace("file:///", "");
            Assembly asm = Assembly.LoadFile(assembleFileName);
            //获取dll中所有符合条件的类 这里寻找的是  继承EntityTypeConfiguration 的类 typeof(EntityTypeConfiguration<>)
            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                //实例化
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
