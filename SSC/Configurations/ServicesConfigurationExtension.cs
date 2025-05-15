
    public static class ServicesConfigurationExtension
    {

        public static void Configure(this WebApplicationBuilder builder)
        {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();
        builder.Services.AddMvc();
        builder.Services.AddControllers();
        }

    }

