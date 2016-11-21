using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.WebManage
{
    public  class ExpModel
    {
        [Key]
        public long EID { get; set; }

        public long? GID { get; set; }

        [StringLength(500)]
        public string ETitle { get; set; }

        [StringLength(500)]
        public string EKeyword { get; set; }

        [StringLength(500)]
        public string EDes { get; set; }

        public string EContent { get; set; }

        [StringLength(500)]
        public string EAuthor { get; set; }

        public DateTime? ECreatetime { get; set; }

        public int? EStatus { get; set; }

        [StringLength(500)]
        public string EAddress { get; set; }
    }
}
