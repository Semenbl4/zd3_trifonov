namespace ShopLibrary
{
    public class ShopChain
    {
        // Поля класса
        public string Name { get; set; }
        public string Address { get; set; }
        public int SalesCount { get; set; }
        public double Viruchka { get; set; }

        // Конструктор
        public ShopChain(string name, string address, int salesCount, double viruchka)
        {
            Name = name;
            Address = address;
            SalesCount = salesCount;
            Viruchka = viruchka;
        }

        // Расчет q
        public virtual double GetQuality()
        {
            // Проверка чтоб не делилось на 0
            if (SalesCount == 0) return 0;
            // Выручка на продажи
            return Viruchka / SalesCount;
        }

        // Вывод информации
        public virtual string GetDisplayInfo()
        {
            return $"{Name} ({Address}) | Продаж: {SalesCount} | Выручка: {Viruchka:N0} руб. | Q: {GetQuality():F2}";
        }
    }
}