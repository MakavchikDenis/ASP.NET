using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace API.Models
{
   
    public class AdressPersons
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Adress { get; set; }

        public AdressPersons() { }
        public AdressPersons(string _Adress) => Adress = _Adress;

        
    }
}
