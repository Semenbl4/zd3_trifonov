using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class ShopManager
    {
        // Создание объектов для двух коллекций
        private List<ShopChain> shopList = new List<ShopChain>();
        private Dictionary<string, ShopChain> shopDict = new Dictionary<string, ShopChain>();

        // Открытие листа для чтения основного списка
        public List<ShopChain> Shops => shopList;

        // Метод добавления магазина
        public void AddShop(ShopChain shop)
        {
            shopList.Add(shop);
            if (!shopDict.ContainsKey(shop.Name))
                shopDict.Add(shop.Name, shop);
        }

        // Метод добавления магазина с перегрузкой (1)
        public void AddShop(string name, string address, int salesCount, double viruchka)
        {
            var shop = new ShopChain(name, address, salesCount, viruchka);
            AddShop(shop);
        }

        // Метод добавления магазина с перегрузкой (2)
        public void AddShop(string name, string address, int salesCount, double viruchka, int p, string region)
        {
            var shop = new DetailedShopChain(name, address, salesCount, viruchka, p, region);
            AddShop(shop);
        }

        // Метод удаления магазина
        public bool RemoveShop(int index)
        {
            if (index >= 0 && index < shopList.Count)
            {
                var shop = shopList[index];
                shopDict.Remove(shop.Name);
                shopList.RemoveAt(index);
                return true;
            }
            return false;
        }

        // Метод удаления магазина с перегрузкой
        public bool RemoveShop(string name)
        {
            if (shopDict.ContainsKey(name))
            {
                var shop = shopDict[name];
                shopDict.Remove(name);
                return shopList.Remove(shop);
            }
            return false;
        }

        // Выручка больше 150к
        public List<ShopChain> GetHighRevenueShops()
        {
            return shopList.Where(s => s.Viruchka > 150000).ToList();
        }

        // Убывание рассчитываемого качества
        public List<ShopChain> GetSortedByQuality()
        {
            return shopList.OrderByDescending(s => s.GetQuality()).ToList();
        }
    }
}
