using Microsoft.Extensions.Logging;

namespace PM2E160851
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Comentado temporalmente: si faltan los archivos de fuente esto puede provocar errores en tiempo de ejecución.
                    // Añade los archivos OpenSans-Regular.ttf y OpenSans-Semibold.ttf en Resources/Fonts o descomenta estas líneas.
                    // fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    // fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
