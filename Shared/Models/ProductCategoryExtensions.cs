using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public enum ProductCategory
{
    NoCategory = 0,
    Women = 1,
    Men = 2,
    Kids = 3,
    Shoes = 4,
    Hats = 5,
    Sunglasses = 6,
    Watches = 7
}

public enum WomenSubCategory
{
    NoValue = 0,
    Dresses = 1,
    Tops = 2,
    Pants = 3,
    Skirts = 4,
    Jackets = 5,
    Underwear = 6
}

public enum MenSubCategory
{
    NoValue = 0,
    Shirts = 1,
    Sweaters = 2,
    JacketsAndCoats = 3,
    PantsAndShort = 4,
    Underwear = 5
}

public enum KidsSubCategory
{
    NoValue = 0,
    Tops = 1,
    Sweaters = 2,
    DressesAndSkirts = 3,
    Shirts = 4,
    OutdoorClothes = 5,
    PantsAndShorts = 6,
    SleepWear = 7
}

public enum ShoesSubCategory
{
    NoValue = 0,
    Sneakers = 1,
    Sandals = 2,
    SlipIns = 3,
    HighHeels = 4,
    WalkingShoes = 5,
    TrainingShoes = 6,
    Boots = 7
}

public enum HatsSubCategory
{
    NoValue = 0,
    Beanie = 1,
    Cap = 2,
    FlatCap = 3,
    Beret = 4,
    Fedora = 5,
    Bucket = 6
}

public enum SunGlassesSubCategory
{
    NoValue = 0,
    BrowLine = 1,
    Pilot = 2,
    CatEye = 3,
    Round = 4,
    Square = 5
}

public enum WatchesSubCategory
{
    NoCategory = 0,
    Women = 1,
    Men = 2,
    Kids = 3
}
public static class ProductCategoryExtensions
{
    public static string GetString(this ProductCategory cat)
    {
        switch (cat)
        {
            case ProductCategory.Women:
                return "Women's Fashion";
            case ProductCategory.Men:
                return "Men's Fashion";
            case ProductCategory.Kids:
                return "Kid's Fashion";
            case ProductCategory.Shoes:
                return "Shoes";
            case ProductCategory.Hats:
                return "Hats";
            case ProductCategory.Sunglasses:
                return "Sunglasses";
            case ProductCategory.Watches:
                return "Watches";
            default:
                return "No Category";

        }
    }
}
