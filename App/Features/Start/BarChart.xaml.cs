namespace App.Features.Start;

public partial class BarChart : ContentPage
{
	public BarChart(BarChartViewModel barChartViewModel)
	{
		InitializeComponent();
		BindingContext = barChartViewModel;
	}
}