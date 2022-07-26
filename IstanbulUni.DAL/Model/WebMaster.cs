﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.DAL.Model
{
    public class WebMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int webMasterID { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string  Phone{ get; set; }
        public string Department { get; set; }

        public DateTime createTime { get; set; }
        public bool IsActive { get; set; } = true;
        public int userID { get; set; }
        public virtual User User { get; set; }

    }
}
