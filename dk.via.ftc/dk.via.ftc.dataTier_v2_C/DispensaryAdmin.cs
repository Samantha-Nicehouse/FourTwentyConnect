using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dk.via.ftc.dataTier_v2_C

{
    [Table("dispensary_admin",Schema = "SEP3")]
    public partial class DispensaryAdmin
    {
        public string Username { get; set; }
        public string DispensaryId { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual Dispensary Dispensary { get; set; }
    }
}
