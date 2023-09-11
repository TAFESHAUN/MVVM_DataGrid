using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM_DataGrid.Data
{
    public class ShopData : ObservableObject
    {
        private int id;
        public int shopID
        {
            get => id;
            set
            {
                if (SetProperty(ref id, value))
                    OnPropertyChanged(nameof(shopID));
            }
        }

        private string brandname;
        public string brandName
        {
            get => brandname;
            set
            {
                if (SetProperty(ref brandname, value))
                    OnPropertyChanged(nameof(brandName));
            }
        }

        private string itemname;
        public string itemName
        {
            get => itemname;
            set
            {
                if (SetProperty(ref itemname, value))
                    OnPropertyChanged(nameof(itemName));
            }
        }

        private string catatype;
        public string cataType
        {
            get => catatype;
            set
            {
                if (SetProperty(ref catatype, value))
                    OnPropertyChanged(nameof(cataType));
            }
        }

        private int costprice;
        public int costPrice
        {
            get => costprice;
            set
            {
                if (SetProperty(ref costprice, value))
                    OnPropertyChanged(nameof(costPrice)); ;
            }
        }

        private string latestcata;
        public string latestCata
        {
            get => latestcata;
            set
            {
                if (SetProperty(ref latestcata, value))
                    OnPropertyChanged(nameof(latestCata));
            }
        }
    }
}
