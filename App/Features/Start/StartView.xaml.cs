namespace App.Features.Start;

public partial class StartView : ContentPage
{
	public StartView(StartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
