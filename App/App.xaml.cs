using App.Services.Navigation;

namespace App;

public partial class App : Application
{
    INavigationService _navigationService;
    public App(INavigationService navigationService)
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIyMTI4NkAzMjMxMmUzMDJlMzBJUFFWT2dWN0dCeTdsQy85VFZIbVJvNmRiYVU3cHJLaVE3VTNYdDRaRC9FPQ==");
		InitializeComponent();

        MainPage = new AppShell(navigationService);
    }
}
