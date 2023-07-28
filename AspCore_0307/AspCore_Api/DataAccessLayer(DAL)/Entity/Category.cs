using System.ComponentModel.DataAnnotations;

namespace AspCore_Api.DataAccessLayer_DAL_.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
