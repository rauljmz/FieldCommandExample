using Sitecore;
using Sitecore.Web.UI.Sheer;

namespace FieldCommandPOC.Commands
{
    using Sitecore.Shell.Framework.Commands;

  
    public class Open : Command
    {
        public override void Execute([NotNull] CommandContext context)
        {
            SheerResponse.Alert("open clicked", false);
        }
    }
}