using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.WebManage
{
    public class NewsModel
    {
        [Key]
        public long NID { get; set; }

        [StringLength(500)]
        public string NTitle { get; set; }

        public string NContent { get; set; }

        [StringLength(500)]
        public string NDes { get; set; }

        [StringLength(500)]
        public string NKeyword { get; set; }

        public long? GID { get; set; }

        [StringLength(500)]
        public string NAuthor { get; set; }

        public DateTime? NCreateTime { get; set; }

        public int? NStatus { get; set; }
    }
}
