using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table(name: "Persons", Schema = "ApiBase")]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(name: "NamePerson", TypeName = "varchar(max)")]
        [ConcurrencyCheck]
        public string Name { get; set; }
        [Required]
        [Column(name: "SurnamePerson", TypeName = "varchar(max)")]
        [ConcurrencyCheck]
        public string Surname { get; set; }

        public AdressPersons? Adresses { get; set; }

        public Aducation? Kurses { get; set; }



        public Person() { }

        public Person(string _Name, string _Surname, string _Adress) => (Name, Surname, Adresses) = (_Name, _Surname, new AdressPersons { Adress=_Adress});

        public void Deconstruct(out string NameOut, out string SurnameOut, out string AdressOut) =>
            (NameOut, SurnameOut, AdressOut) = (this.Name, this.Surname, this.Adresses.Adress);


    }
}
