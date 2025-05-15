
    public static class WebApplicationConfigurationExtension
    {

        public static void Configure(this WebApplication app) 
        {
        app.UseMvc();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        }

    }

