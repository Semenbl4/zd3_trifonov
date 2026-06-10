using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class DetailedShopChain : ShopChain
    {
        // Доп. поле P
        public int P { get; set; } 

        // 2 доп свойства
        public string Region { get; set; }

        public bool IsHighlyProfitable => Viruchka > 250000;

        // Конструктор класса
        public DetailedShopChain(string name, string address, int salesCount, double viruchka, int p, string region)
            : base(name, address, salesCount, viruchka)
        {
            P = p;
            Region = region;
        }

        // Расчет Qp
        public override double GetQuality()
        {
            double q = base.GetQuality();

            
            if (P > 50000)
                return 2 * q;
            else
                return 0.5 * q;
        }

        // Вывод информации
        public override string GetDisplayInfo()
        {
            return $"{Name} ({Region}, {Address}) | Покупатели (P): {P:N0} | Выручка: {Viruchka:N0} руб. | Qp: {GetQuality():F2}";
        }
    }
}
