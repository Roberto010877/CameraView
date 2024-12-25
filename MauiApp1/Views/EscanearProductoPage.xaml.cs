using MauiApp1.DataAccess;
using MauiApp1.DTOs;
using MauiApp1.Models;
using MauiApp1.Utilidades;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;

using ZXing.Net.Maui;
namespace MauiApp1.Views;

public partial class EscanearProductoPage : ContentPage
{
    private readonly VentaDbContext _context;
    public EscanearProductoPage(VentaDbContext context)
    {
        InitializeComponent();

        cameraView.BarCodeOptions = new ZXing.Net.Maui.BarcodeDecodeOptions()
        {
            TryHarder = true,
            PossibleFormats = { ZXing.BarcodeFormat.All_1D }
        };
        _context = context;
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(new Action(async () =>
            {

                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            }));
        }
    }

    private async void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            string codigo = args.Result[0].Text;
            Producto dbProducto = await _context.Productos.Include(c => c.RefCategoria).FirstOrDefaultAsync(p => p.Codigo == codigo);
            ProductoDTO producto = new ProductoDTO()
            {
                IdProducto = dbProducto.IdProducto,
                Codigo = dbProducto.Codigo,
                Nombre = dbProducto.Nombre,
                Categoria = new CategoriaDTO()
                {
                    IdCategoria = dbProducto.IdCategoria,
                    Nombre = dbProducto.RefCategoria.Nombre
                },
                Cantidad = dbProducto.Cantidad,
                Precio = dbProducto.Precio
            };
            WeakReferenceMessenger.Default.Send(new ProductoVentaMessage(producto));
        });

        await Shell.Current.Navigation.PopModalAsync();
    }
}