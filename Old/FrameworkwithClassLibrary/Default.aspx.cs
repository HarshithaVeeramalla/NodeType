using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace FrameworkwithClassLibrary
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            class1.UserName = "Hello Harshitha";
            lblUserName.Text = class1.UserName;
        }
    }
}