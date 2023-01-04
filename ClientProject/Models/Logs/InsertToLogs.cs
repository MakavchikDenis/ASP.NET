namespace ClientProject.Models.Logs
{
    public class InsertToLogs
    {
        // Исправить при написании авторизации
        // На процедуре сейчас дефолтное значение ='new'
        public string User { get; set; }
        public string ActionType { get; set; }
        public string ActionDetails { get; set; }
        public string Details { get; set; }
    }
}
