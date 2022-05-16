public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })

  .AddCookie()
  .AddOpenIdConnect(options =>
  {
      options.SignInScheme = "Cookies";

      options.Authority = "[https://localhost:44352](https://localhost:44352/)";

      options.RequireHttpsMetadata = true;

      options.ClientId = "codeflowpkceclient";

      options.ClientSecret = "codeflow_pkce_client_secret";

      options.ResponseType = "code";

      options.UsePkce = true;

      options.Scope.Add("profile");

      options.Scope.Add("offline_access");

      options.SaveTokens = true;

  });

    services.AddAuthorization();

    services.AddRazorPages();

}

}