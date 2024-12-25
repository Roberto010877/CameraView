using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class HistoriaVentaPage : ContentPage
{
	public HistoriaVentaPage(HistorialVentaVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}