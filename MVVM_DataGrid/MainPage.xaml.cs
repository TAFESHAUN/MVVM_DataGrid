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


    private void CalcItem(object sender, EventArgs e)
    {
        //VALIDATE SELECTION OTHER COULD ERROR IF NOTHING PICKED
        var selection = ShopView.SelectedItem as ShopData;
        sumID.Text = selection.shopID.ToString();
        sumName.Text = $"Brand: {selection.brandName}";
        sumType.Text = selection.itemName.ToString();
        sumYN.Text = $"Is 2023 Lineup: {selection.latestCata}.";

        var costP = Convert.ToInt32(selection.costPrice);
        sumCostPrice.Text = $"Cost: {costP}";

        var numTimes = Convert.ToInt32(numberOfItems.Text);
        sumTotalOrder.Text = $"Quantity: {numTimes} items";
        sumTotal.Text = $"Total Cost Of Order: {costP * numTimes}";


        //await DisplayAlert("Selection Price", selection.costPrice.ToString(), "OK");
    }

    //SELECTION OLD CODE
    //private async void CalcItem(object sender, EventArgs e)
    //{
    //    var selection = ShopView.SelectedItem as ShopData;

    //    await DisplayAlert("Selection Price",selection.costPrice.ToString(),"OK");
    //}
}

