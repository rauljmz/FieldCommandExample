using System;
using System.Web;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.sitecore_modules.shell
{
    public class ProductBrowserForm:DialogForm
    {
        public Edit Product;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
            if (!IsEvent)
            {
                var product = WebUtil.GetQueryString("product");
                if (!string.IsNullOrEmpty(product)) Product.Value = product; 
            }
        }
        protected override void OnOK(object sender, EventArgs args)
        {
            SheerResponse.SetDialogValue(Product.Value);         
            base.OnOK(sender, args);
        }

        public bool IsEvent { get { return HttpContext.Current.Request.Form["__ISEVENT"] == "1"; } }
    }
}