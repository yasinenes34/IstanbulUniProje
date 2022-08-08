using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.DAL.Model
{
    public class WebMasterHistory
    {
        
        public int webMasterHistoryID { get; set; }
        public string DomainName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public DateTime createTime { get; set; }
        public DateTime deleteTime { get; set; }
        public string serviceTime { get; set; }

    }
}
