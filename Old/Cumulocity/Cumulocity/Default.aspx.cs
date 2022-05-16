using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cumulocity.SDK.Client;
using Cumulocity.SDK.Client.Rest;
using Cumulocity.SDK.Client.Rest.API.Inventory;
using Cumulocity.SDK.Client.Rest.Model;
using Cumulocity.SDK.Client.Rest.Model.Authentication;
using Cumulocity.SDK.Client.Rest.Model.C8Y;
using Cumulocity.SDK.Client.Rest.Representation.Inventory;
namespace Cumulocity
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Console.WriteLine("REST API client!");

			IPlatform platform = new PlatformImpl(" https://myurl.cumulocity.com",
				 new CumulocityCredentials("v-harshithav@microsoft.com", "Cumulocity@1620"));
			IInventoryApi inventory = platform.InventoryApi;

			var mo = new ManagedObjectRepresentation();
			mo.Name = "Hello, world!";
			mo.Set(new IsDevice());
			mo = inventory.Create(mo);
			Console.WriteLine($"Url: {mo.Self}");
			Console.ReadKey();
		}
    }
}