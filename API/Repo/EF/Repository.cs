using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using API.Models;
using System.Collections.Generic;

namespace API.Repo.EF
{
    public class Repository : DbContext, IRepository
    {
       

        public DbSet<Person> Person { get; set; }
        public DbSet<AdressPersons> AdressPersons { get; set; }
        public DbSet<Aducation> Aducations { get; set; }



        public Repository(DbContextOptions<Repository> options) : base(options)
        {

        }






        public IEnumerable<T> Get<T>() where T : class => this.Set<T>();


        public void Added<T>(T ob) where T:class
        {
            this.Add<T>(ob);
            this.SaveChanges();
        }

        public void Delete<T>(T ob) where T : class {
            this.Remove<T>(ob);
            this.SaveChanges();

        }


        public void Updata<T>(T ob) where T : class {
            this.Update<T>(ob);
            this.SaveChanges();
        }
    }
}
