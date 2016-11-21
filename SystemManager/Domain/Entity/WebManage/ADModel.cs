using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.WebManage
{
   public class ADModel
    {
        [Key]
        public long AID { get; set; }

        [StringLength(500)]
        public string AName { get; set; }

        public bool? AStatus { get; set; }

        public DateTime ACreatetime { get; set; }

        public int? AItems { get; set; }

        public int? GID { get; set; }

        public long APID { get; set; }

        public string ACreateUser { get; set; }

        public DateTime AeditTime { get; set; }

        public int ASort { get; set; }

        public string ARemark { get; set; }


    }
   public  class ADItemModel
    {
        [Key]
        public long IID { get; set; }

        [StringLength(500)]
        public string IName { get; set; }

        [StringLength(500)]
        public string IPath { get; set; }

        public long AID { get; set; }

        public long? GID { get; set; }

        public DateTime? IStartTime { get; set; }

        public DateTime? IEndTime { get; set; }

        [StringLength(500)]
        public string IAddress { get; set; }

        public bool? IStatus { get; set; }

        public DateTime? ICreatetime { get; set; }

        [StringLength(500)]
        public string ICreateName { get; set; }

        public long? UserID { get; set; }

        public string IDesc { get; set; }
    }
}
