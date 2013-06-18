using Sitecore;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.Commands
{
    using Sitecore.Shell.Framework.Commands;

  
    public class Open : Command
    {
        public override void Execute([NotNull] CommandContext context)
        {
            Sitecore.Context.ClientPage.Start(this, "Run");
        }

        public void Run(ClientPipelineArgs args)
        {
            if (!args.IsPostBack)
            {
                SheerResponse.ShowModalDialog("/ProductIntegration/ProductBrowser.aspx");
                args.WaitForPostBack();
            }
            else
            {
                if (args.HasResult)
                {
                    
                }
            }

        }
    }
}