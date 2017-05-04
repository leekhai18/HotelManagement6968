using FirstFloor.ModernUI.Presentation;
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
        public void Add(ModernWindow modernWindow, string nameLinkGroup, int numOfLink, List<Link> listLink)
        {
            LinkGroup linkGroup = new LinkGroup();
            linkGroup.DisplayName = nameLinkGroup;

            for (int i = 0; i < numOfLink; i++)
            {
                linkGroup.Links.Add(listLink[i]);
            }

            modernWindow.MenuLinkGroups.Add(linkGroup);
        }

        public void Remove(ModernWindow modernWindow, int index, String contentSource)
        {
            modernWindow.MenuLinkGroups.RemoveAt(index);
            modernWindow.ContentSource = new Uri(contentSource, UriKind.Relative);
        }
    }
}
