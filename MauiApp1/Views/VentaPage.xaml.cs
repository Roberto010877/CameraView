using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class VentaPage : ContentPage
{
	public VentaPage(VentaVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}