using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.WebManage
{
    public class GameModel
    {
        [Key]
        public long GID { get; set; }

        [StringLength(500)]
        public string GName { get; set; }

        [StringLength(500)]
        public string GIcon { get; set; }

        [StringLength(500)]
        public string GPath { get; set; }

        public string GDes { get; set; }

        public long? GCategory { get; set; }

        [StringLength(500)]
        public string GAddress { get; set; }

        public DateTime? GCreatetime { get; set; }

        public bool? GStatus { get; set; }

        public int GSorce { get; set; }

    }

    public class GameCategoryModel
    {

        [Key]
        public long CID { get; set; }

        public long? PID { get; set; }

        [StringLength(500)]
        public string CName { get; set; }

        [StringLength(500)]
        public string CPath { get; set; }

        public bool? CStatus { get; set; }

        public DateTime? Createtime { get; set; }


    }

}
