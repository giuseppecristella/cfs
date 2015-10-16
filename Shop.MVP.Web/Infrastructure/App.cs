using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;
using Shop.Core.BusinessDelegate;

namespace Shop.Web.Mvp.Infrastructure
{
    public class App
    {
        public static Configuration Configuration { get; set; }
        public static CategoryName CategoryName { get; set; }

        public static Dictionary<string, string> PaymentMethods { get; set; }

        public static Dictionary<string, string> CategoriesDictionary { get; private set; }

        static App()
        {
            // instanzio un oggetto e lo assegno ad una proprietà statica, così posso lavorare su un singleton
            // es. App.Configuration
            //CacheManager = new AspnetCacheManager();
            CategoriesDictionary = CreateCategoriesDictionary();
            Configuration = new Configuration();
            CategoryName = new CategoryName(CategoriesDictionary);
            PaymentMethods = new Dictionary<string, string>
            {
                {"cashondelivery" , "Contrassegno"},
                {"banktransfer" ,"Bonifico"},
                {"ccsave", "Paypal"},
            };
        }

        private static Dictionary<string, string> CreateCategoriesDictionary()
        {
            CategoriesDictionary = new Dictionary<string, string>();

            var businessDelegate = new BusinessDelegate();
            var mainLevelCategories = businessDelegate.GetMainLevelCategories("3");

            foreach (var c in mainLevelCategories)
            {
                var secondlevelCategories = (c["children"] as object[]).ToList();
                if (!secondlevelCategories.Any())
                {
                    CategoriesDictionary.Add(c["name"].ToString().ToLower().Replace(" ", "-"), c["category_id"].ToString());
                    continue;
                }
                foreach (XmlRpcStruct secondlevelCat in secondlevelCategories)
                {
                    CategoriesDictionary.Add(string.Format("{0}-{1}", c["name"].ToString().ToLower(), secondlevelCat["name"].ToString().ToLower().Replace(" ", "-"))
                        , secondlevelCat["category_id"].ToString());
                }
            }
            return CategoriesDictionary;
        }
    }
}
