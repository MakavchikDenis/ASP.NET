using System.Collections.Generic;

namespace API.Repo.EF
{
    public interface IRepository
    {

        public IEnumerable<T> Get<T>();

        public void Added<T>(T ob);

        public void Updata<T>(T ob);

        public void Delete<T>(T ob);

    }
}
