namespace ClientProject.ServiceForApi
{
    public interface IServiceForApi<T> where T : class 
    {
        public  T GetPeopleForApiAsync();
        public T GetPersonForApiAsync();
        public void AddedNewPersonForApiAsync(T person);
        public int UpdataForApiAsync(T idPerson, T surname);
        public T DeleteForApiAsync (T idPerson);


    }
}
