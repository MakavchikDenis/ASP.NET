
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace API.Models
{
    [Table(name: "Aducation", Schema = "ApiBase")]
    public class Aducation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NameCourse { get; set; }

        public IEnumerable<Person> Persons{get;set;}

        public Aducation() => Persons = new List<Person>();
    }
}
