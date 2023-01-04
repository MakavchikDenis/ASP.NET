using System.Net.Http;
using System;
using System.Net;

namespace ClientProject.ServiceForApi
{
    public class ServiceForApi : IServiceForApi<object>
    {
        readonly string ConnectToAPI;
        readonly HttpClient client;

        public ServiceForApi(string connectToAPI, HttpClient httpClient)
        {
            ConnectToAPI = connectToAPI;
            client = httpClient;
        }

        public void AddedNewPersonForApiAsync(object person)
        {
            throw new System.NotImplementedException();
        }

        public object DeleteForApiAsync(object idPerson)
        {
            throw new System.NotImplementedException();
        }

        public object GetPeopleForApiAsync()
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(ConnectToAPI));
                HttpResponseMessage httpResponse = client.SendAsync(request).Result;
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    string _content = content.ReadAsStringAsync().Result;
                    var resultWithError = String.Concat<string>(new string[] { httpResponse.StatusCode.ToString(), _content });

                    throw new Exception(resultWithError);
                }

                return httpResponse.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                return e;

            }
        }

        public object GetPersonForApiAsync()
        {
            throw new System.NotImplementedException();
        }

        public int UpdataForApiAsync(object idPerson, object surname)
        {
            throw new System.NotImplementedException();
        }
    }
}
