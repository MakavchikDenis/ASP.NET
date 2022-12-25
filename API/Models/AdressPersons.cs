using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace API.Models
{
    [Table(name: "Adress", Schema = "ApiBase")]
    public class Adress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Details{ get; set; }

        public Adress() { }
        public Adress(string _Details) => Details = Details;

        
    }
}
