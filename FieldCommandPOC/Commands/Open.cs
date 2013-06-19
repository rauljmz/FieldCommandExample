using Sitecore;
using Sitecore.Web;
using Sitecore.Web.UI;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.Commands
{
    using Sitecore.Shell.Framework.Commands;


    public class Open : Sitecore.Shell.Applications.WebEdit.Commands.WebEditCommand
    {
        public override void Execute([NotNull] CommandContext context)
        {
            string formValue = WebUtil.GetFormValue("scPlainValue");           
            context.Parameters.Add("fieldValue",formValue);
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        public void Run(ClientPipelineArgs args)
        {
           
            string fieldValue = args.Parameters["fieldValue"];

            if (!args.IsPostBack)
            {                
                var url = UIUtil.GetUri("control:ProductBrowser", "product=" + fieldValue);
                SheerResponse.ShowModalDialog(url,true);
                args.WaitForPostBack();
            }
            else
            {
                if (args.HasResult)
                {
                    var result = args.Result;
                    SheerResponse.SetAttribute("scHtmlValue", "value", result);
                    SheerResponse.SetAttribute("scPlainValue", "value", result);
                    var builder = new ScriptInvokationBuilder("scSetHtmlValue");
                    builder.AddString(args.Parameters["controlid"], new object[0]);
                    if (string.IsNullOrEmpty(result))
                    {
                        builder.Add("true");
                    }
                    SheerResponse.Eval(builder.ToString());
                }
            }

        }
    }
}