using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.Field
{
    public class ProductField : Text
    {
       public override void HandleMessage(Sitecore.Web.UI.Sheer.Message message)
        {
            if (message.Name == "FieldCommandPOC:Open")
            {
                Sitecore.Context.ClientPage.Start(this, "BrowseProduct");
            }
            else if (message.Name == "FieldCommandPOC:Clear")
            {
                Value = string.Empty;
            }
            base.HandleMessage(message);

        }

        protected void BrowseProduct(ClientPipelineArgs args)
        {
            if (!args.IsPostBack)
            {
                var url = UIUtil.GetUri("control:ProductBrowser", "product=" + Value);
                SheerResponse.ShowModalDialog(url, true);
                args.WaitForPostBack();
            }
            else
            {
                if (args.HasResult)
                {
                    LoadPostData(args.Result);
                }
            }
        }
    }
}