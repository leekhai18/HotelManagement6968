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
            modernWindow.MenuLinkGroups.Add(new FirstFloor.ModernUI.Presentation.LinkGroup() { DisplayName = groupName, Links = { new FirstFloor.ModernUI.Presentation.Link() { DisplayName = linkName, Source = new Uri(source, UriKind.Relative) } } });
        }

        public static void Remove(ModernWindow modernWindow, int index, String contentSource)
        {
            modernWindow.MenuLinkGroups.RemoveAt(index);
            modernWindow.ContentSource = new Uri(contentSource, UriKind.Relative);
        }
    }
}
