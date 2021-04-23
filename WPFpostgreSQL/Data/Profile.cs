using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WPFpostgreSQL.Data
{
    [Table("Profiles")]
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Info")]
        public string Info { get; set; }
        [ForeignKey("UserId")]
        public User ProfileOf { get; set; }
    }
}
