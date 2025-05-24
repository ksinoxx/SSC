
    public static class WebApplicationConfigurationExtension
    {

        public static void Configure(this WebApplication app) 
        {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        app.UseSession();
        app.UseRouting();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();
    }

    }

