using MVVM_DataGrid.Data;
using MVVM_DataGrid.ViewModel;

namespace MVVM_DataGrid;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        //use discard task -> voids the need to await and just loads records
        _ = viewModel.ImportSomeRecords();
    }

    /// <summary>
    /// UPDATE THIS TO CALC AND SHOW ON SUMMARY 
    /// NEED x:name on labels
    /// Currently this just shows the selected item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void CalcItem(object sender, EventArgs e)
    {
        var selection = ShopView.SelectedItem as ShopData;

        await DisplayAlert("Selection",selection.itemName.ToString(),"OK");
    }
}

