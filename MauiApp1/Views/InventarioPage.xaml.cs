using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class InventarioPage : ContentPage
{
	public InventarioPage(InventarioVM viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}