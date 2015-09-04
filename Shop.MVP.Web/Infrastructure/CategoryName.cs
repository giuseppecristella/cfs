using System.Collections.Generic;
using System.Security.AccessControl;

namespace Shop.Web.Mvp.Infrastructure
{
    public class CategoryName
    {
        private readonly Dictionary<string, string> _categoriesesDictionary;

        public CategoryName(Dictionary<string, string> categoriesDictionary)
        {
            _categoriesesDictionary = categoriesDictionary;
        }

        public string Root
        {
            get
            {
                return "3";
            }
        }

        public string NuoviArrivi
        {
            get
            {
                return _categoriesesDictionary["nuovi-arrivi"];
            }
        }
    }
}
