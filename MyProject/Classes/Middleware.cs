using Microsoft.AspNetCore.Authentication.Cookies;

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