using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WPFpostgreSQL.Data
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserInfo { get; set; }
        [Required]
        public Profile Profile { get; set; }
    }
}
