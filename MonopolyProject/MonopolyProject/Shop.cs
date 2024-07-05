using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MonopolyProject
{
    internal class Shop
    {
        private int shopCost;
        private int shopWorth;
        private string shopName;
        private bool alreadyBuy = false;
        private int whoOwnsTheShop = -1;
        private bool SpeaialShop = false;

        public Shop(int shopCost, int shopWorth, string shopName)
        {
            this.shopCost = shopCost;
            this.shopWorth = shopWorth;
            this.shopName = shopName;

        }

        public void SetSpecialShop()
        {
            SpeaialShop = true;
        }
        public bool GetSpecialShop()
        {
            return SpeaialShop;
        }
        public int GetShopCost()
        {
            return shopCost;
        }
        public int GetShopWorth()
        {
            return shopWorth;
        }
        public string GetShopName()
        {
            return shopName;
        }
        public bool GetShopStatus()
        {
            return alreadyBuy;
        }
        public void SetShopStatus()
        {
            alreadyBuy = true;
        }
        public void SetShopOwner(int owner)
        {
            if(owner == 1)
            {
                whoOwnsTheShop = 1;
            }
            if(owner == 2)
            {
                whoOwnsTheShop = 2;
            }
        }
        public int GetShopOwner()
        {
            return whoOwnsTheShop;
        }

    }
}
