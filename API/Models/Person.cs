using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

       

        [ForeignKey("AdressId")]
        public Adress AdressPerson { get; set; }

        [ForeignKey("AducationId")]
        public Aducation Course { get; set; }



        public Person() { }

        public Person(string _Name, string _Surname, Adress _Adress) => (Name, Surname, AdressPerson) = (_Name, _Surname, _Adress);

        public Person(string _Name, string _Surname, Adress _Adress, Aducation _Course) : this(_Name, _Surname, _Adress) => this.Course = _Course;




        public void Deconstruct(out string NameOut, out string SurnameOut, out Adress AdressOut, out Aducation Course) =>
            (NameOut, SurnameOut, AdressOut, Course) = (this.Name, this.Surname, this.AdressPerson, this.Course);


    }
}
