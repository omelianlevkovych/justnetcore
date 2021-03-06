using Microsoft.AspNetCore.Builder;

namespace HoldingPage
{
    public class Startup
    {        
        /* We can remove IWebHostEnvironment default parameter, as IHostBuilder use reflection and retrieves
         * the method based on its name only: Configure.
         * WelcomePage middleware is designed to quickly provide an example page when you just started developing.
         */
        /* Flow: the request from user goes (directly or through reverse-proxy) to .NET Core web server (Kestrel in our case),
         * which build a representation of the request and passes it to the middleware pipeline. As it is first and only
         * middleware used, WelcomePageMiddleware recieves the request and must decide how to handle it.
         * It respond by generating an HTML response, no matter what request it receives.
         */
        public void Configure(IApplicationBuilder app)
        {
            // Do not use in production env!
            app.UseWelcomePage();
        }
    }
}
