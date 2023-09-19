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
        viewModel.ImportStoreDBRecord();
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

/*
 *             <dg:DataGrid.Columns>
                <dg:DataGridColumn Title="Id" PropertyName="shopID" Width="50"><!--ItemsSource.PropertyName = Cataloge.shopID-->
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate>
                            <ContentView>
                                <Grid>
                                    <Label Text="{Binding ., FallbackValue='id'}" FontSize="Medium" TextColor="Black"/>
                                </Grid>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
                <dg:DataGridColumn Title="Brand" PropertyName="brandName" ><!--Cataloge.brandName-->
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate >
                            <ContentView>
                                <Label Text="{Binding ., FallbackValue='Missing Brand Name'}" FontAttributes="Bold" TextColor="Black" HorizontalTextAlignment="Center"/>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
                <dg:DataGridColumn Title="Item Name" PropertyName="itemName" >
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate>
                            <ContentView>
                                <Label Text="{Binding ., FallbackValue='Item Name'}" FontAttributes="Bold" TextColor="Black" HorizontalTextAlignment="Center"/>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
                <dg:DataGridColumn Title="In Cataloge" PropertyName="cataType" >
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate>
                            <ContentView>
                                <Label Text="{Binding ., FallbackValue='In Cataloge'}" FontAttributes="Bold" TextColor="Black" HorizontalTextAlignment="Center"/>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
                <dg:DataGridColumn Title="Price" PropertyName="costPrice" >
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate>
                            <ContentView>
                                <Label Text="{Binding ., FallbackValue='Cost Price'}" FontAttributes="Bold" TextColor="Black" HorizontalTextAlignment="Center"/>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
                <dg:DataGridColumn Title="2023 Cataloge Item" PropertyName="latestCata" >
                    <dg:DataGridColumn.CellTemplate>
                        <DataTemplate>
                            <ContentView>
                                <Label Text="{Binding ., FallbackValue='Latest Cataloge Y/N'}" FontAttributes="Bold" TextColor="Black" HorizontalTextAlignment="Center"/>
                            </ContentView>
                        </DataTemplate>
                    </dg:DataGridColumn.CellTemplate>
                </dg:DataGridColumn>
            </dg:DataGrid.Columns>
 */

