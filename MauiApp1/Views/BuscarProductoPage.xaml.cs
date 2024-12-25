using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class BuscarProductoPage : ContentPage
{
	public BuscarProductoPage(BuscarProductoVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}