using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using MVVM_DataGrid.Data;
using System.Collections.ObjectModel;
using System.Globalization;


namespace MVVM_DataGrid.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            Cataloge = new ObservableCollection<ShopData>();
        }

        [ObservableProperty]
        ObservableCollection<ShopData> cataloge = new ObservableCollection<ShopData>();

        #region CsvImporter
        [RelayCommand]
        public async Task ImportSomeRecords()
        {
            string fileName = "ShopData.csv";
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);

            using (var reader = new StreamReader(fileStream))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvMap>();


                    int shopID;
                    string brandName;
                    string itemName;
                    string typeCataloge;
                    int costPrice;
                    string latestCataloge;


                    while (csv.Read())
                    {
                        shopID = csv.GetField<int>(0);
                        brandName = csv.GetField<string>(1);
                        itemName = csv.GetField<string>(2);
                        typeCataloge = csv.GetField<string>(3);
                        costPrice = csv.GetField<int>(4);
                        latestCataloge = csv.GetField<string>(5);
                        Cataloge.Add(CreateRecord(shopID, brandName, itemName, typeCataloge, costPrice, latestCataloge));

                    }

                }

            }
        }

        public static ShopData CreateRecord(int shopID, string brandName, string itemName, string typeCataloge, int costPrice, string latestCataloge)
        {
            ShopData record = new ShopData();

            record.shopID = shopID;
            record.brandName = brandName;
            record.itemName = itemName;
            record.cataType= typeCataloge;
            record.costPrice = costPrice;
            record.latestCata = latestCataloge;

            return record;
        }
        #endregion

        //NAVIGATE -> CALL TASK1 -> TASK1 DONE -> CALL TASK2, NAVIGATE AGAIN
        //TASKS CAN HAPPEN SYMILTANIOUSLY -> WITH EACH OTHER AND KNOW OF EACH OTHER
        //NAVITAGE -> LOGIC CHECK -> DO FUCNTION1 -> CHECK IF DONE -> ANOTHER LOGIC CHECK/TRYCATCH -> DO FUNCTION2 -> ANOTHER CHECK ->NAVIAGATE.
    }
}
