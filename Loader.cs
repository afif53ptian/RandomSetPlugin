using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools.Plugins;

namespace ExamplePacketPlugin
{
    [GrimoirePluginEntry]
    public class Loader : IGrimoirePlugin
    {
        public string Author => "Afif_Sapi";

        public string Description => "Random Sets Generator.\r\n\r\n" +
            "Any Bugs?\r\n" +
            "Send me message on:\r\n" +
            "www.fb.com/afif.septian.35";

        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("Randomize");
            menuItem.Click += MenuStripItem_Click;
        }

        public void Unload() // In this method you need to clean everything up
        {
            //Proxy.Instance.UnregisterHandler(Main.Instance.Handler);
            Proxy.Instance.ReceivedFromServer -= Main.Instance.MapHandler;
            Proxy.Instance.ReceivedFromClient -= Main.Instance.MapHandler;
            menuItem.Click -= MenuStripItem_Click;
            Grimoire.UI.Root.Instance.MenuMain.Items.Remove(menuItem);
            Main.Instance.Dispose();
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            if (Main.Instance.Visible)
            {
                Main.Instance.Hide();
            }
            else
            {
                Main.Instance.Show();
                Main.Instance.BringToFront();
            }
        }
    }
}
