using Sitecore;
using Sitecore.Shell.Applications.WebEdit.Commands;
using Sitecore.Web.UI;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.Commands
{
    using Sitecore.Shell.Framework.Commands;

    public class Clear : WebEditCommand
    {
        public override void Execute([NotNullAttribute] CommandContext context)
        {
            Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        public void Run(ClientPipelineArgs args)
        {            
            if (!args.IsPostBack)
            {
                SheerResponse.Confirm("Clear this product?");
                args.WaitForPostBack();
            }
            else
            {
                if (args.HasResult && args.Result == "yes")
                {
                    var result = string.Empty;
                    SheerResponse.SetAttribute("scHtmlValue", "value", result);
                    SheerResponse.SetAttribute("scPlainValue", "value", result);
                    var builder = new ScriptInvokationBuilder("scSetHtmlValue");
                    builder.AddString(args.Parameters["controlid"], new object[0]);
                  //  builder.Add("true");                    
                    SheerResponse.Eval(builder.ToString());
                }
            }
        }
    }
}