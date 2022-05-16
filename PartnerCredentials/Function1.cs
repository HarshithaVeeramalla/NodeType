using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace PartnerCredentials
{
    public static class Function1
    {
        //[FunctionName("Function1")]
        //public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        //{
        //    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        //}

        [FunctionName("cspTest")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            IPartnerCredentials partnerCredentials =
                PartnerCredentials.Instance.GenerateByApplicationCredentials(secret, secret, login.microsoftonline.com");

            //  Create operations instance with partnerCredentials.
            return PartnerService.Instance.CreatePartnerOperations(partnerCredentials);
            _sqlDataReader = _sqlCommand.ExecuteReader();
            var employeemodellist = new ObservableCollection<EmployeeModel>();

            while (_sqlDataReader.Read())
            {
                var employeeModel = new EmployeeModel
                {
                    Eno = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("Empno")),
                    Ename = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("Ename")),
                    Job = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("Job")),
                    Salary = _sqlDataReader.GetDecimal(_sqlDataReader.GetOrdinal("Sal"))
                };
                employeemodellist.Add(employeeModel);
            }

            EmployeeList = employeemodellist;
            _sqlConnection.Close();
        }


    }
}
