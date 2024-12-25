using Microsoft.Extensions.Logging;
using MauiApp1.DataAccess;
using MauiApp1.ViewModels;
using CommunityToolkit.Maui;
using MauiApp1.Views;
using Camera.MAUI;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCameraView()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                });

            builder.Services.AddDbContext<VentaDbContext>();

            builder.Services.AddTransient<CategoriasPage>();
            builder.Services.AddTransient<CategoriasVM>();

            builder.Services.AddTransient<InventarioPage>();
            builder.Services.AddTransient<InventarioVM>();

            builder.Services.AddTransient<ProductoPage>();
            builder.Services.AddTransient<ProductoVM>();

            builder.Services.AddTransient<VentaPage>();
            builder.Services.AddTransient<VentaVM>();

            builder.Services.AddTransient<BuscarProductoPage>();
            builder.Services.AddTransient<BuscarProductoVM>();

            builder.Services.AddTransient<HistoriaVentaPage>();
            builder.Services.AddTransient<HistorialVentaVM>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainVM>();

            var dbContext = new VentaDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
