using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        //string conn = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (SqlCommand cmd = new SqlCommand("CREATE DATABASE IF NOT EXISTS main", conn))
            //{
            //    // Execute the command and log the # rows affected.
            //    var numberOfActions = await cmd.ExecuteNonQueryAsync();
            //    responseMessage = numberOfActions != 0 ? "ok, main database created" : "main already existed, no changes were made";
            //    return new OkObjectResult(responseMessage);

            //}
            //CheckDatabase("asas");

          
        }


        public IActionResult OkObjectResult()
        {
            var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
            return result;
        }
    }
}