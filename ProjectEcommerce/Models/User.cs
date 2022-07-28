using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    [Table("User_Table")]
    public class User
    {
        [Key]
        [ScaffoldColumn(true)]
        public int u_id { get; set; }
        [Required]
        public string u_name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string u_email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string u_password { get; set; }
        public int u_roleid { get; }

      

    }



}
