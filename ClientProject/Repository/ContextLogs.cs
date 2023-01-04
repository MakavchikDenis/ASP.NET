using NLog;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using ClientProject.Models.Logs;
using System.Threading.Tasks;

namespace ClientProject.Repository
{
    public class ContextLogs : IContextLogs
    {
        readonly string connectToDb;
        readonly Logger logger;

        public ContextLogs(string _connectToDb, Logger _logger) => (connectToDb, logger) = (_connectToDb, _logger);

        /// <summary>
        /// Добавляем в таблицу Logs через процедуру, если завершается с ошибкой=> ошибку логируем через NLog
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<string> SetToLogsAsync(object ob)
        {
            try
            {
                InsertToLogs toLogs = (InsertToLogs)ob;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@User","new");
                parameters.Add("@ActionType", toLogs.ActionType);
                parameters.Add("@ActionDetails", toLogs.ActionDetails);
                parameters.Add("@Details", toLogs.Details);
                parameters.Add("@Error",value:String.Empty, DbType.String, ParameterDirection.Output, 100);



                using (IDbConnection dbConnection = new SqlConnection(connectToDb))
                {
                    await dbConnection.ExecuteAsync("InsertToLogs", parameters, commandType: CommandType.StoredProcedure);

                };

                string Error = parameters.Get<string>("@Error");
                if (Error != "Ok") { throw new Exception(Error); }
                
                return Error;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return e.Message;

            }
        }
    }
}
