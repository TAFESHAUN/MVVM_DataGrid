using CsvHelper.Configuration;

namespace MVVM_DataGrid.Data
{
    public sealed class CsvMap : ClassMap<ShopData>
    {
        public CsvMap()
        {
            Map(m => m.shopID).Index(0);
            Map(m => m.brandName).Index(1);
            Map(m => m.itemName).Index(2);
            Map(m => m.cataType).Index(3);
            Map(m => m.costPrice).Index(4);
            Map(m => m.latestCata).Index(5);
        }
    }
}
