using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.WebManage
{
    public class WebUserModel
    {
        [Key]
        public long UserID { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string UserPassword { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string NickName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(500)]
        public string PhoneNumber { get; set; }

        public bool? Sex { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

    }
}
