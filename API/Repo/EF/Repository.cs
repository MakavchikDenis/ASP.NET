using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using API.Models;

namespace API.Repo.EF
{
    public class Repository : DbContext, IRepository
    {
        readonly string Connect;

        DbSet<Person> Person { get; set; }
        DbSet<AdressPersons> AdressPersons { get; set; }
        DbSet<Aducation> Aducations { get; set; }



        public Repository(DbContextOptions<Repository> options) : base(options)
        {
           
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Connect);
        //}




        public IEnumerable<T> Get<T>()=>this.Get<T>();

        public void Added<T>(T ob) => this.Added<T>(ob);

        public void Delete<T>(T ob) => this.Delete<T>(ob);


        public void Updata<T>(T ob) => this.Delete<T>(ob);
    }
}
