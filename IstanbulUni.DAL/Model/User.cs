using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulUni.DAL.Model
{
    public class User
    {
        public User()
        {
            //this.WebMasters = new HashSet<WebMaster>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime lastActivity { get; set; }
        
        public virtual List<WebMaster> WebMasters { get; set; }
    }
}
