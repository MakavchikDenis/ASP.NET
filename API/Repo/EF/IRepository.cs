using System.Collections.Generic;

namespace API.Repo.EF
{
    public interface IRepository
    {

        public IEnumerable<T> Get<T>() where T : class;

        public void Added<T>(T ob) where T : class;

        public void Updata<T>(T ob) where T : class;

        public void Delete<T>(T ob) where T : class;

    }
}
