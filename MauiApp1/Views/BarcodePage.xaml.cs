using MauiApp1.Utilidades;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
//using ZXing.Net.Maui;
using ZXing.Net.Maui;
using Camera.MAUI;
namespace MauiApp1.Views;
 
public partial class BarcodePage : ContentPage
{
    public BarcodePage()
    {
        InitializeComponent();

        cameraView.BarCodeOptions = new Camera.MAUI.ZXingHelper.BarcodeDecodeOptions()
        {
            TryHarder = true,
            PossibleFormats = { ZXing.BarcodeFormat.All_1D }
        };
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

    private void cameraView_BarcodeDetected(object sender, BarcodeDetectionEventArgs args)
    {
        Utilidades.BarcodeResult barcodeResult = new Utilidades.BarcodeResult { BarcodeValue = args.Results[0].Value };
        WeakReferenceMessenger.Default.Send(new BarcodeScannedMessage(barcodeResult));

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.Navigation.PopModalAsync();
        });

        //MainThread.BeginInvokeOnMainThread(() =>
        //{
        //    barcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
        //});
    }
}
