using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
using Newtonsoft.Json.Linq;

namespace ExamplePacketPlugin
{
    public partial class Main : Form
    {
        public static Main Instance { get; } = new Main();

        public Main()
        {
            InitializeComponent();
        }

        /*public JoinHandler Handler { get; } = new JoinHandler();

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                Handler.MapToJoin = txtMap.Text;
                Proxy.Instance.RegisterHandler(Handler);
            }
            else
            {
                Proxy.Instance.UnregisterHandler(Handler);
            }
        }*/

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        //==========================================================================

        int UID = 0;
        int mapSessionID = 1;
        int bagSlots = 0;

        bool firstLogin = false;

        List<string> loadItemsMsg = new List<string>();

        List<Item> arItems = new List<Item>();
        List<Item> coItems = new List<Item>();
        List<Item> weaponItems = new List<Item>();
        List<Item> heItems = new List<Item>();
        List<Item> baItems = new List<Item>();
        List<Item> peItems = new List<Item>();

        List<string> EquipMsg = new List<string>();
        List<string> EquipmentMsg = new List<string>();
        List<string> bankFromInvtMsg = new List<string>();
        List<string> bankToInvMsg = new List<string>();

        int InvListed = 0;
        int BankListed = 0;

        List<List<Item>> sets = new List<List<Item>>();

        Item currAr = null;
        Item currCo = null;
        Item currWe = null;
        Item currHe = null;
        Item currBa = null;
        Item currPe = null;

        int totalSet = 0;
        int currSetIndex = 0;

        private async void cbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnable.Checked)
            {
                tbTextLogs.Text = string.Empty;
                tbAr.Text = "-";
                tbCo.Text = "-";
                tbWeapon.Text = "-";
                tbHe.Text = "-";
                tbBa.Text = "-";
                tbPe.Text = "-";

                Player.Logout();
                Proxy.Instance.ReceivedFromServer += MapHandler;
                Proxy.Instance.ReceivedFromClient += MapHandler;

                while (cbEnable.Checked)
                {
                    if (loadItemsMsg.Any())
                    {
                        List<string> _loadItemsMsg = new List<string>(loadItemsMsg);
                        this.loadItemsMsg.Clear();

                        listFromChar(_loadItemsMsg);
                        _loadItemsMsg.Clear();

                        if (!sets.Any())
                        {
                            foreach (string msg in EquipmentMsg)
                            {
                                equipItem(getItemByID(getItemID(msg)));
                            }
                        }
                    }

                    if (!Player.IsLoggedIn)
                    {
                        clearLogs();
                        arItems.Clear();
                        coItems.Clear();
                        weaponItems.Clear();
                        heItems.Clear();
                        baItems.Clear();
                        peItems.Clear();
                        bankFromInvtMsg.Clear();
                        bankToInvMsg.Clear();
                        InvListed = 0;
                        BankListed = 0;
                        firstLogin = false;
                    }

                    if (EquipMsg.Any())
                    {
                        List<string> _EquipMsg = new List<string>(EquipMsg);
                        this.EquipMsg.Clear();

                        updEquipment(_EquipMsg);
                        _EquipMsg.Clear();
                    }

                    if (bankFromInvtMsg.Any())
                    {
                        List<string> _bankFromInvtMsg = new List<string>(bankFromInvtMsg);
                        bankFromInvtMsg.Clear();

                        foreach(string msg in _bankFromInvtMsg)
                        {
                            if(getItemByID(getItemID(msg)) != null)
                                getItemByID(getItemID(msg)).BBank = true;
                        }
                        _bankFromInvtMsg.Clear();
                    }

                    if (bankToInvMsg.Any())
                    {
                        List<string> _bankToInvMsg = new List<string>(bankToInvMsg);
                        bankToInvMsg.Clear();

                        foreach (string msg in _bankToInvMsg)
                        {
                            if (getItemByID(getItemID(msg)) != null)
                                getItemByID(getItemID(msg)).BBank = false;
                        }
                        _bankToInvMsg.Clear();
                    }

                    if (firstLogin)
                    {
                        firstLogin = false;
                        await Task.Delay(7000);
                        Proxy.Instance.SendToServer($"%xt%zm%loadBank%{this.mapSessionID}%Sword%Axe%Dagger%Gun%Bow%Mace%Polearm%Staff%Wand%");
                        await Task.Delay(1000);
                        Proxy.Instance.SendToServer($"%xt%zm%loadBank%{this.mapSessionID}%Class%Armor%");
                        await Task.Delay(1000);
                        Proxy.Instance.SendToServer($"%xt%zm%loadBank%{this.mapSessionID}%Helm%Cape%");
                        await Task.Delay(1000);
                        Proxy.Instance.SendToServer($"%xt%zm%loadBank%{this.mapSessionID}%Cape%");
                        await Task.Delay(1000);
                        Proxy.Instance.SendToServer($"%xt%zm%loadBank%{this.mapSessionID}%Pet%");
                    }

                    int bankPercentage = BankListed * 20;
                    bankPercentage = bankPercentage > 100 ?
                        100 : bankPercentage;
                    int sumCo = arItems.Count + coItems.Count;
                    ulong possibleSets = (ulong)sumCo *
                        ((ulong)weaponItems.Count < 1 ? 1 : (ulong)weaponItems.Count) * 
                        ((ulong)heItems.Count < 1 ? 1 : (ulong)heItems.Count) *
                        ((ulong)baItems.Count < 1 ? 1 : (ulong)baItems.Count) *
                        ((ulong)peItems.Count < 1 ? 1 : (ulong)peItems.Count);
                    string _possibleSets = possibleSets.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de"));

                    try { 
                        lbInvStatus.Text = $"(Inventory: {Player.Inventory.Items.Count}/{bagSlots})";
                    } catch { }
                    lbSetIndex.Text = $"({this.currSetIndex})";
                    lbIndexLog.Text = 
                        $"(Listed: Inventory {InvListed * 100}% + Bank {bankPercentage}% = " +
                        $"{arItems.Count + coItems.Count + weaponItems.Count + heItems.Count + baItems.Count + peItems.Count} Items)";
                    lbIndexLog2.Text =
                        $"(Ar: {sumCo}, We: {weaponItems.Count}, He: {heItems.Count}, Ca: {baItems.Count}, Pe: {peItems.Count})";
                    lbIndexLog3.Text =
                        $"You can generate {_possibleSets} possible sets!";
                    await Task.Delay(200);
                }
            }
            else
            {
                clearLogs();
                arItems.Clear();
                coItems.Clear();
                weaponItems.Clear();
                heItems.Clear();
                baItems.Clear();
                peItems.Clear();
                bankFromInvtMsg.Clear();
                bankToInvMsg.Clear();
                InvListed = 0;
                BankListed = 0;
                firstLogin = false;

                Proxy.Instance.ReceivedFromServer -= MapHandler;
                Proxy.Instance.ReceivedFromClient -= MapHandler;
            }
        }

        public void MapHandler(Grimoire.Networking.Message message)
        {
            string msg = message.ToString();

            try
            {
                if (msg.Contains("cmd\":\"loadInventory")
                    || msg.Contains("cmd\":\"loadBank"))
                {
                    this.loadItemsMsg.Add(msg);
                } 
                else if (msg.Contains("%xt%loginResponse%"))
                {
                    this.UID = int.Parse(getBetweenString(msg, "%loginResponse%-1%true%", "%"));
                    firstLogin = true;
                }
                else if (msg.Contains("cmd\":\"bankFromInv"))
                {
                    bankFromInvtMsg.Add(msg);
                }
                else if (msg.Contains("cmd\":\"bankToInv"))
                {
                    bankToInvMsg.Add(msg);
                }
                else if ((msg.Contains("cmd\":\"equipItem")
                    || msg.Contains("cmd\":\"unequipItem"))
                    && msg.Contains($"{UID}"))
                {
                    this.EquipMsg.Add(msg);
                }
                else if (msg.Contains("cmd\":\"moveToArea"))
                {
                    this.mapSessionID = getSessionID(msg);
                }
                else if (msg.Contains("iBagSlots\":"))
                {
                    this.bagSlots = int.Parse(getBetweenString(msg, "iBagSlots\":", ","));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void listFromChar(List<string> loadItemsMsg)
        {
            foreach(string itemsMsg in loadItemsMsg)
            {
                if (itemsMsg.Contains("cmd\":\"loadInventory")) InvListed = 1;
                else BankListed++;

                if (!itemsMsg.Contains("items\":\"undefined"))
                {
                    JObject packet = JObject.Parse(itemsMsg);

                    JArray items = (JArray)packet["b"]["o"]["items"];

                    for (int i = 0; i < items.Count; i++)
                    {
                        int id = int.Parse(items[i]["ItemID"].ToString());
                        if (!isListed(id))
                        {
                            string sName = items[i]["sName"].ToString();
                            int bCoins = int.Parse(items[i]["bCoins"].ToString());
                            int bUpg = int.Parse(items[i]["bUpg"].ToString());
                            string sType = items[i]["sType"].ToString();
                            int iQty = int.Parse(items[i]["iQty"].ToString());

                            string strES = items[i]["sES"].ToString();
                            string sFile = isEquipable(strES) ?
                                items[i]["sFile"].ToString() : string.Empty;
                            string sLink = isEquipable(strES) ?
                                items[i]["sLink"].ToString() : string.Empty;

                            decimal charItemID = Decimal.Parse(items[i]["CharItemID"].ToString(), 
                                NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
                            bool bBank = items[i]["bBank"].ToString().ToLower() == "true" ? true : false;

                            switch (strES)
                            {
                                case "ar":
                                    arItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                                case "co":
                                    coItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                                case "Weapon":
                                    weaponItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                                case "he":
                                    heItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                                case "ba":
                                    baItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                                case "pe":
                                    peItems.Add(new Item(id, sName, bCoins, bUpg, 
                                        sType, iQty, string.Empty,
                                        strES, sFile, sLink, charItemID, bBank));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public bool isListed(int id)
        {
            if (arItems.Any())
            {
                foreach (Item item in arItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            if (coItems.Any())
            {
                foreach (Item item in coItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            if (weaponItems.Any())
            {
                foreach (Item item in weaponItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            if (heItems.Any())
            {
                foreach (Item item in heItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            if (baItems.Any())
            {
                foreach (Item item in baItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            if (peItems.Any())
            {
                foreach (Item item in peItems)
                {
                    if (id == item.ID)
                        return true;
                }
            }

            return false;
        }

        private bool isEquipable(string curr_sES)
        {
            string[] sES_CanEquip =
            {
                "Weapon", "ar", "co", "he", "ba", "pe"
            };

            foreach (string sES in sES_CanEquip)
            {
                if (curr_sES == sES)
                {
                    return true;
                }
            }
            return false;
        }

        private void equipItem(Item item)
        {
            if (item == null)
                return;

            if(item.StrES == "Weapon")
            {
                Proxy.Instance.SendToClient("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"uid\":" + this.UID + ",\"ItemID\":" + item.ID + "," +
                            "\"strES\":\"" + item.StrES + "\",\"cmd\":\"equipItem\",\"sFile\":\"" + item.SFile + "\"," +
                            "\"sLink\":\"" + item.SLink + "\",\"sType\":\"" + item.SType +"\"}}}");
            }
            else
            {
                Proxy.Instance.SendToClient("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"uid\":" + this.UID + ",\"ItemID\":" + item.ID + "," +
                            "\"strES\":\"" + item.StrES + "\",\"cmd\":\"equipItem\",\"sFile\":\"" + item.SFile + "\"," +
                            "\"sLink\":\"" + item.SLink + "\"}}}");
            }

            switch (item.StrES)
            {
                case "ar":
                    tbAr.Text = item.SName;
                    tbAr.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbAr.BackColor = tbAr.BackColor;
                    this.currAr = item;
                    break;
                case "co":
                    tbCo.Text = item.SName;
                    tbCo.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbCo.BackColor = tbCo.BackColor;
                    this.currCo = item;
                    break;
                case "Weapon":
                    tbWeapon.Text = item.SName;
                    tbWeapon.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbWeapon.BackColor = tbWeapon.BackColor;
                    this.currWe = item;
                    break;
                case "he":
                    tbHe.Text = item.SName;
                    tbHe.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbHe.BackColor = tbHe.BackColor;
                    this.currHe = item;
                    break;
                case "ba":
                    tbBa.Text = item.SName;
                    tbBa.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbBa.BackColor = tbBa.BackColor;
                    this.currBa = item;
                    break;
                case "pe":
                    tbPe.Text = item.SName;
                    tbPe.ForeColor = item.BUpg == 1 ?
                        Color.Magenta : Color.Black;
                    tbPe.BackColor = tbPe.BackColor;
                    this.currPe = item;
                    break;
            }

        }

        private void unequipItem(Item item)
        {
            if (item == null)
                return;

            Proxy.Instance.SendToClient("{\"t\":\"xt\",\"b\":{\"r\":-1,\"o\":{\"uid\":" + UID + "," +
                "\"ItemID\":" + item.ID + ",\"strES\":\"" + item.StrES + "\",\"cmd\":\"unequipItem\"}}}");

            switch (item.StrES)
            {
                case "ar":
                    tbAr.Text = "-";
                    tbAr.ForeColor = Color.Black;
                    tbAr.BackColor = tbAr.BackColor;
                    this.currAr = null;
                    break;
                case "co":
                    tbCo.Text = "-";
                    tbCo.ForeColor = Color.Black;
                    tbCo.BackColor = tbCo.BackColor;
                    this.currCo = null;
                    break;
                case "Weapon":
                    tbWeapon.Text = "-";
                    tbWeapon.ForeColor = Color.Black;
                    tbWeapon.BackColor = tbWeapon.BackColor;
                    this.currWe = null;
                    break;
                case "he":
                    tbHe.Text = "-";
                    tbHe.ForeColor = Color.Black;
                    tbHe.BackColor = tbHe.BackColor;
                    this.currHe = null;
                    break;
                case "ba":
                    tbBa.Text = "-";
                    tbBa.ForeColor = Color.Black;
                    tbBa.BackColor = tbBa.BackColor;
                    this.currBa = null;
                    break;
                case "pe":
                    tbPe.Text = "-";
                    tbPe.ForeColor = Color.Black;
                    tbPe.BackColor = tbPe.BackColor;
                    this.currPe = null;
                    break;
            }
        }

        private void equipSet(List<Item> set)
        {
            // index: 0:ar 1:co 2:we 3:he 4:ba 5:pe
            int index = 0;
            foreach(Item item in set)
            {
                if(item != null)
                    equipItem(item);
                else
                {
                    switch (index)
                    {
                        case 0:
                            tbAr.Text = "-";
                            unequipItem(currAr);
                            break;
                        case 1:
                            tbCo.Text = "-";
                            unequipItem(currCo);
                            break;
                        case 2:
                            tbWeapon.Text = "-";
                            unequipItem(currWe);
                            break;
                        case 3:
                            tbHe.Text = "-";
                            unequipItem(currHe);
                            break;
                        case 4:
                            tbBa.Text = "-";
                            unequipItem(currBa);
                            break;
                        case 5:
                            tbPe.Text = "-";
                            unequipItem(currPe);
                            break;
                    }
                }
                index++;
            }
        }

        private void addNewSet(Item ar, Item co, Item we, Item he, Item ba, Item pe)
        {
            List<Item> _set = new List<Item>();

            _set.Add(ar);
            _set.Add(co);
            _set.Add(we);
            _set.Add(he);
            _set.Add(ba);
            _set.Add(pe);

            sets.Add(_set);

            tbTextLogs.Text +=
                $"*** [{this.totalSet}]:\r\n" +
                "Class Armor: " + tbAr.Text + "\r\n" +
                "Armor: " + tbCo.Text + "\r\n" +
                "Weapon: " + tbWeapon.Text + "\r\n" +
                "Helm: " + tbHe.Text + "\r\n" +
                "Cape: " + tbBa.Text + "\r\n" +
                "Pet: " + tbPe.Text + "\r\n";
            currSetIndex = this.totalSet;
            this.totalSet++;
        }

        public void updEquipment(List<string> msgs)
        {
            if (!EquipmentMsg.Any())
            {
                foreach (string msg in msgs)
                {
                    this.EquipmentMsg.Add(msg);
                }
                return;
            }

            foreach (string msg in msgs)
            {
                /* {"t":"xt","b":{"r":-1,"o":{"uid":3694,"ItemID":9198,["strES":"he"]
                 * ,"cmd":"equipItem","sFile":"items/helms/CrimsonHelm.swf","sLink":
                 * "CrimsonHelm","sMeta":"undefined"}}} */

                if (msg.Contains("cmd\":\"equipItem"))
                {
                    JObject jmsg = JObject.Parse(msg);
                    string jmsg_strES = jmsg["b"]["o"]["strES"].ToString();
                    equipItem(getItemByID(getItemID(msg)));

                    for (int i = 0; i < EquipmentMsg.Count(); i++)
                    {
                        JObject jequipment = JObject.Parse(EquipmentMsg[i]);
                        string jequipment_strES = jequipment["b"]["o"]["strES"].ToString();
                        if (jequipment_strES == jmsg_strES)
                        {
                            this.EquipmentMsg[i] = msg;
                            break;
                        }
                        if (i == EquipmentMsg.Count() - 1)
                        {
                            this.EquipmentMsg.Add(msg);
                            break;
                        }
                    }
                }
                else
                {
                    string strES_Type = getBetweenString(msg, ",", ",\"cmd\":\"unequipItem");
                    unequipItem(getItemByID(getItemID(msg)));

                    for (int i = 0; i < EquipmentMsg.Count(); i++)
                    {
                        if (EquipmentMsg[i].Contains(strES_Type))
                        {
                            EquipmentMsg.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private Item getItemByID(int id)
        {
            if (arItems.Any())
            {
                foreach (Item item in arItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            if (coItems.Any())
            {
                foreach (Item item in coItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            if (weaponItems.Any())
            {
                foreach (Item item in weaponItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            if (heItems.Any())
            {
                foreach (Item item in heItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            if (baItems.Any())
            {
                foreach (Item item in baItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            if (peItems.Any())
            {
                foreach (Item item in peItems)
                {
                    if (id == item.ID)
                        return item;
                }
            }

            return null;
        }

        private int getItemID(string msg)
        {
            string sItemID;
            if (msg.Contains("ItemID\":\""))
            {
                sItemID = getBetweenString(msg, "ItemID\":\"", "\"");
            }
            else
            {
                sItemID = getBetweenString(msg, "ItemID\":", ",");
            }

            int itemID = int.Parse(sItemID);
            return itemID;
        }

        public int getSessionID(string msg)
        {
            string sID;
            if (msg.Contains("areaId\":\""))
            {
                sID = getBetweenString(msg, "areaId\":\"", "\"");
            }
            else
            {
                sID = getBetweenString(msg, "areaId\":", ",");
            }

            int iSID = int.Parse(sID);
            return iSID;
        }

        public static string getBetweenString(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                int IndexStart = 0;

                Start = strSource.IndexOf(strStart, IndexStart) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                IndexStart = Start;

                return strSource.Substring(Start, End - Start);
            }
            return null;
        }

        private void btnRandomAll_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int itemNum;

            if (arItems.Any() && !cbArLock.Checked)
            {
                itemNum = random.Next(0, arItems.Count);
                equipItem(arItems[itemNum]);
            }

            if (coItems.Any() && !cbCoLock.Checked)
            {
                itemNum = random.Next(0, coItems.Count);
                equipItem(coItems[itemNum]);
            }

            if (weaponItems.Any() && !cbWeapLock.Checked)
            {
                itemNum = random.Next(0, weaponItems.Count);
                equipItem(weaponItems[itemNum]);
            }

            if (heItems.Any() && !cbHeLock.Checked)
            {
                itemNum = random.Next(0, heItems.Count);
                equipItem(heItems[itemNum]);
            }

            if (baItems.Any() && !cbBaLock.Checked)
            {
                itemNum = random.Next(0, baItems.Count);
                equipItem(baItems[itemNum]);
            }

            if (peItems.Any() && !cbPeLock.Checked)
            {
                itemNum = random.Next(0, peItems.Count);
                equipItem(peItems[itemNum]);
            }

            addNewSet(this.currAr, this.currCo, this.currWe, this.currHe, this.currBa, this.currPe);
        }

        /*private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbAr.Text = saveFileDialog1.FileName;
            }
        }*/

        private void clearLogs()
        {
            tbTextLogs.Text = string.Empty;
            totalSet = 0;
            currSetIndex = 0;
            sets.Clear();

        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            clearLogs();
            if(totalSet == 0)
                addNewSet(this.currAr, this.currCo, this.currWe, 
                    this.currHe, this.currBa, this.currPe);
        }

        private void tbTextLogs_TextChanged(object sender, EventArgs e)
        {
            tbTextLogs.SelectionStart = tbTextLogs.Text.Length;
            tbTextLogs.ScrollToCaret();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (EquipmentMsg.Any())
            {
                btnReset.Enabled = false;

                tbAr.Text = "-";
                tbCo.Text = "-";
                tbWeapon.Text = "-";
                tbHe.Text = "-";
                tbBa.Text = "-";
                tbPe.Text = "-";

                foreach (string msg in EquipmentMsg)
                {
                    equipItem(getItemByID(getItemID(msg)));
                    Proxy.Instance.SendToClient(msg);
                }

                if (tbAr.Text == "-")
                {
                    unequipItem(currAr);
                }
                else if(tbCo.Text == "-")
                {
                    unequipItem(currCo);
                }
                else if (tbWeapon.Text == "-")
                {
                    unequipItem(currWe);
                }
                else if (tbHe.Text == "-")
                {
                    unequipItem(currHe);
                }
                else if (tbBa.Text == "-")
                {
                    unequipItem(currBa);
                }
                else if (tbPe.Text == "-")
                {
                    unequipItem(currPe);
                }

                btnReset.Enabled = true;
            }
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            cbArLock.Checked = false;
            cbCoLock.Checked = false;
            cbWeapLock.Checked = false;
            cbHeLock.Checked = false;
            cbBaLock.Checked = false;
            cbPeLock.Checked = false;

            if (totalSet == 1)
                equipSet(sets[0]);

            if(currSetIndex > 0)
            {
                currSetIndex--;
                equipSet(sets[currSetIndex]);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            cbArLock.Checked = false;
            cbCoLock.Checked = false;
            cbWeapLock.Checked = false;
            cbHeLock.Checked = false;
            cbBaLock.Checked = false;
            cbPeLock.Checked = false;

            if (totalSet == 1)
                equipSet(sets[0]);

            if (currSetIndex < totalSet - 1)
            {
                currSetIndex++;
                equipSet(sets[currSetIndex]);
            }
        }

        private async void btnMoveToInv_Click(object sender, EventArgs e)
        {
            if (sets.Any())
            {
                btnMoveToInv.Enabled = false;
                if(_ReqBagSlot(sets[currSetIndex]) <= _RemainBagSlot())
                {
                    foreach(Item item in sets[currSetIndex])
                    {
                        if(item != null)
                        {
                            if (item.BBank)
                            {
                                // send to inv
                                Proxy.Instance.SendToServer($"%xt%zm%bankToInv%{mapSessionID}%{item.ID}%{item.CharItemID}%");
                                await Task.Delay(1500);
                            }
                        }
                    }
                }
                else
                {
                    MessageBoxEx.Show(this, "Inventory space isn't enough!", "Oops");
                }
                btnMoveToInv.Enabled = true;
            }
        }

        private int _ReqBagSlot(List<Item> set)
        {
            int reqSlot = 0;
            foreach(Item item in set)
            {
                if (item != null && item.BBank)
                    reqSlot++;
            }
            return reqSlot;
        }

        private int _RemainBagSlot()
        {
            if(bagSlots > 0)
                return bagSlots - Player.Inventory.Items.Count;
            return 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, 0);
            this.MaximumSize = new Size(this.Width, Int32.MaxValue);
        }
    }
}
