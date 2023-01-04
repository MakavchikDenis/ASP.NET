using System.Threading.Tasks;

namespace ClientProject.Repository
{
    public interface IContextLogs
    {
        public Task<string> SetToLogsAsync(object ob);
    }
}
