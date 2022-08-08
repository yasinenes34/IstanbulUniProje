﻿using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.BAL.Model
{
   public class WebMasterViewModel
    {
        public int webMasterID { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public DateTime createTime { get; set; } = DateTime.Now;
    }
}
