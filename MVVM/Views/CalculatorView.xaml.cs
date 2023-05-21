using CalculatorMAUI.MVVM.ViewModels;

namespace CalculatorMAUI.MVVM.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
        InitializeComponent();
        BindingContext = new CalculatorViewModel();
    }
    private void Clear_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is CalculatorViewModel viewModel)
        {
            viewModel.Display = "0";
            viewModel.model.Operator = null;
            viewModel.model.FirstNumber = 0;
            viewModel.model.SecondNumber = 0;
            viewModel.model.Result = 0;
        }
    }


}