using System;
namespace ClashCards.Context
{
    public static class Constants
    {
        public static string BaseAddress = "http://www.clashapi.xyz";
        public static string CardsUrl = BaseAddress + "/api/cards/{0}";
        public static string CardsImageUrl = BaseAddress + "/images/cards/{0}.png";
    }
}
