using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.Utilidades
{
    public class BarcodeScannedMessage : ValueChangedMessage<BarcodeResult>
    {
        public BarcodeScannedMessage(BarcodeResult value) : base(value)
        {
        }
    }
}
