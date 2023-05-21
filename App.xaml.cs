using CalculatorMAUI.MVVM.Views;
namespace CalculatorMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new CalculatorView());
    }
}
