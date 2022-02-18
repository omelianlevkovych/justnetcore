using Microsoft.AspNetCore.Builder;

namespace StaticFilePage
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
    }
}
