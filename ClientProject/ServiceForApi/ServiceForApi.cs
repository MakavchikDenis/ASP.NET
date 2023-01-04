namespace ClientProject.ServiceForApi
{
    public class ServiceForApi : IServiceForApi<string>
    {
        readonly string ConnectToAPI;

        public ServiceForApi(string connectToAPI)
        {
            ConnectToAPI = connectToAPI;
        }

        public void AddedNewPersonForApiAsync(string person)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteForApiAsync(string idPerson)
        {
            throw new System.NotImplementedException();
        }

        public string GetPeopleForApiAsync()
        {
            throw new System.NotImplementedException();
        }

        public string GetPersonForApiAsync()
        {
            throw new System.NotImplementedException();
        }

        public int UpdataForApiAsync(string idPerson, string surname)
        {
            throw new System.NotImplementedException();
        }
    }
}
