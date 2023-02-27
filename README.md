# uSync-membership-test

Sample project to test the issue with membership. Set up using the following steps:

    # Ensure we have the latest Umbraco templates
    dotnet new -i Umbraco.Templates::10.4.0

    # Create solution/project
    dotnet new umbraco --force -n "MyProject" --friendly-name "Administrator" --email "admin@test.com" --password "Pa55word!!" --development-database-type LocalDB

    #Add starter kit and uSync
    dotnet add "MyProject" package uSync --version 10.3.2
    dotnet add "MyProject" package clean
        
    # Run the site
    dotnet run --project "MyProject"

Log in to Umbraco and ensure uSync is running


    
## Steps to replicate

Add the Cookie auth middleware in a new class

    public static class UmbracoMemberBuilderExtensions
    {
        public static IUmbracoBuilder AddUserCookieAuthentication(this IUmbracoBuilder builder, string cookieName)
        {
            builder.AddMemberExternalLogins(logins =>
            {
                logins.AddMemberLogin(
                    memberAuthenticationBuilder =>
                    {
                        string strSchemeName = CookieAuthenticationDefaults.AuthenticationScheme;

                        memberAuthenticationBuilder.AddCookie(strSchemeName, objCookieAuthenticationOptions =>
                        {
                            objCookieAuthenticationOptions.Cookie.Name = cookieName;
                            // v10 : Add auth login path to config
                            objCookieAuthenticationOptions.LoginPath = "/login/";
                        });

                        builder.Services.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = strSchemeName;
                        });
                        builder.Services.AddAuthorization();
                    });
            });
            return builder;
        }
    }

Modify the startup.cs to add Cookie authentication



