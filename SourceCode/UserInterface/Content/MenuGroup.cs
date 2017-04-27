using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Content
{
    public class MenuGroup
    {
        public static void Add(ModernWindow modernWindow, string groupName, string linkName, String source)
        {
            Presentation.LinkGroup linkGroup = new Presentation.LinkGroup();
            linkGroup.DisplayName = groupName;
            linkGroup.Links.Add(new Presentation.Link() { DisplayName = linkName, Source = new Uri(source, UriKind.Relative) });
            linkGroup.Links.Add(new Presentation.Link() { DisplayName = linkName, Source = new Uri(source, UriKind.Relative) });
            linkGroup.Links.Add(new Presentation.Link() { DisplayName = linkName, Source = new Uri(source, UriKind.Relative) });

            modernWindow.MenuLinkGroups.Add(linkGroup);
        }

        public static void Remove(ModernWindow modernWindow, int index, String contentSource)
        {
            modernWindow.MenuLinkGroups.RemoveAt(index);
            modernWindow.ContentSource = new Uri(contentSource, UriKind.Relative);
        }
    }
}
