using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class CategoriasPage : ContentPage
{
    public CategoriasPage(CategoriasVM viewmodel)
	{
		InitializeComponent();
        BindingContext = viewmodel;
    }

}