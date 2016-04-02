using System;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using Shop.Core.BusinessDelegate;
using Shop.Web.Mvp.Infrastructure;
using Shop.Web.Mvp.UserControls;

namespace Shop.Web.Mvp.Catalog
{
    public partial class SingleProduct : System.Web.UI.Page
    {
        private static string _productId;
        private readonly BusinessDelegate _businessDelegate;
        public SingleProduct()
        {
            _businessDelegate = new BusinessDelegate();
        }

        public static Product ProductViewModel { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (RouteData.Values["ProductId"] == null) Response.Redirect("~/");
            _productId = RouteData.Values["ProductId"].ToString();

            int id;
            if (!int.TryParse(_productId, out id)) Response.Redirect("~/"); 

            ProductViewModel = _businessDelegate.GetProduct(_productId);
            SetBreadcrumbs();
            BindProductImage();
            BindSizes();
        }

        private void BindSizes()
        {
            var sizes = new List<Sizes>();
            var sizeProperties = ProductViewModel.GetType().GetProperties().Where(p => p.Name.Contains("tg_")).ToList();

            foreach (var size in sizeProperties)
            {
                if (size.GetValue(ProductViewModel) == null) continue;
                if (int.Parse(size.GetValue(ProductViewModel).ToString()) <= 0) continue;
                sizes.Add(new Sizes { Name = size.Name, Value = size.GetValue(ProductViewModel).ToString() });
            }
            rptSizes.DataSource = sizes;
            rptSizes.DataBind();
        }

        #region Private Methods
        private void BindProductImage()
        {
            var productImages = _businessDelegate.GetProductImages(_productId);
            if (productImages.FirstOrDefault(p => p.exclude == "1") == default(ProductImage)) return;
            ProductViewModel.imageurl = productImages.First(p => p.exclude == "1").url;
        }

        private void SetBreadcrumbs()
        {
            var mainLevelCategories = _businessDelegate.GetMainLevelCategories(App.CategoryName.Root);

            var productMainCategory = GetProductMainCategory(mainLevelCategories);
            SetMainLevelBreadcrumb(productMainCategory);

            var secondLevel = GetProductSecondLevelCategory(productMainCategory);
            SetSecondLevelBreadcrumb(secondLevel, productMainCategory);

            SetDetailBreadcrumb();
        }

        private void SetDetailBreadcrumb()
        {
            UCBreadcrumbs.Detail = (ProductViewModel != null)
                ? new BreadCrumb { Name = ProductViewModel.name, Url = string.Empty }
                : new BreadCrumb();
        }

        private static void SetSecondLevelBreadcrumb(XmlRpcStruct secondLevel, XmlRpcStruct productMainCategory)
        {
            UCBreadcrumbs.SecondLevel = (secondLevel != null)
                ? new BreadCrumb
                {
                    Name = secondLevel["name"].ToString().ToLower(),
                    Url = string.Format("/{0}-{1}", productMainCategory["name"].ToString().ToLower(), secondLevel["name"].ToString().ToLower())
                }
                : new BreadCrumb();
        }

        private static void SetMainLevelBreadcrumb(XmlRpcStruct productMainCategory)
        {
            UCBreadcrumbs.MainLevel = new BreadCrumb
            {
                Name = productMainCategory["name"].ToString().ToLower(),
                Url = string.Format("/{0}", productMainCategory["name"])
            };
        }

        private XmlRpcStruct GetProductSecondLevelCategory(XmlRpcStruct productMainCategory)
        {
            var secondLevelCategories = (productMainCategory["children"] as object[]).ToList();
            var secondLevel =
                secondLevelCategories.Select(sc => sc as XmlRpcStruct)
                    .FirstOrDefault(a => ProductViewModel.categories.Contains(a["category_id"].ToString()));
            return secondLevel;
        }

        private XmlRpcStruct GetProductMainCategory(IEnumerable<XmlRpcStruct> mainLevelCategories)
        {
            // ToDO:Recuperare solo le categorie che non hanno figli
            // Tra le categorie del prodotto, recupero quella di primo livello
            var mainLevel =
                mainLevelCategories.Select(sc => sc)
                    .FirstOrDefault(a => ProductViewModel.categories.Contains(a["category_id"].ToString()));
            return mainLevel;
        }

        #endregion

        //protected void rptSizes_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    var item = e.Item;
        //    if (item == null) return;
        //    var rbSize = item.FindControl("rbSize") as RadioButton;
        //    if (rbSize == null) return;
        //    rbSize.InputAttributes.Add("class", "attribute-radio");
        //}

        protected void rbSize_OnCheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void rptSizes_OnPreRender(object sender, EventArgs e)
        {
            //foreach (var rbSize in from RepeaterItem item in rptSizes.Items select item.FindControl("rbSize") as RadioButton)
            //{
            //    if (rbSize == null) return;
            //    rbSize.GroupName = "groupSize";
            //    rbSize.InputAttributes.Add("class", "attribute-radio");
            //}
        }
    }

    public class Sizes
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}