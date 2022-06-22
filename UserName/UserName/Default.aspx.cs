using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserName
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var displayName = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == "name").FirstOrDefault().Value;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                var identity = HttpContext.Current.User.Identity.Name;
                lblUserInfo.Text = $"Found User -- > {identity}";
                return;
            }
            else
            {

                lblUserInfo.Text = "Name Unknown!";

            }

        }
    }
}