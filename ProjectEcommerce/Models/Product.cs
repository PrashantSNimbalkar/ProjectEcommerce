
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EcommerceProject.Models
{
    [Table("Product_Table")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(true)]
        public int p_id { get; set; }
        [Required]
        public string p_name { get; set; }
        [Required]
        public string p_company { get; set; }
        [Required]
        public int p_price { get; set; }
             

    }

}
