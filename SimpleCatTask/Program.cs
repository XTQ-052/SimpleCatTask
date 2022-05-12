using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleHelp
{
    class Cat
    {
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Energy { get; set; }
        public decimal Price { get; set; }
        public decimal MealQuantity { get; set; }

        public Cat() { }
        public Cat(string nickname, int age, string gender, decimal price, decimal mealQuantity)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Energy = 100;
            Price = price;
            MealQuantity = mealQuantity;
        }

        public void Eat()
        {
            if (Energy != 100) Energy += 10;
            Price += 5;
        }
        public void Sleep()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{Nickname} is Sleeping... ({i} hour)");
                Thread.Sleep(1000);
                if (Energy != 100) Energy += 10;
            }
        }
        public void Play()
        {
            if (Energy != 0) Energy -= 10;
            if (Energy == 0) Sleep();
        }
        public void ShowCat()
        {
            Console.WriteLine($"Nickname : {Nickname}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Energy : {Energy}");
            Console.WriteLine($"Price : {Price} azn");
            Console.WriteLine($"MealQuantity : {MealQuantity}");
        }
    }

    class CatHouse
    {
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; }

        public CatHouse() { }
        public CatHouse(Cat[] cats, int catCount)
        {
            Cats = cats;
            CatCount = catCount;
        }

        public void ShowCats()
        {
            Console.WriteLine($"Cat count : {CatCount}");
            foreach (var cat in Cats)
            {
                Console.WriteLine("====================");
                cat.ShowCat();
            }
        }
        public void AddCat(ref Cat cat)
        {
            var temp = new Cat[Cats.Length + 1];
            for (int i = 0; i < Cats.Length; i++)
            {
                temp[i] = Cats[i];
            }
            temp[Cats.Length] = cat;
            Cats = temp;
        }
        public void RemoveByNickname(string nickname)
        {
            var temp = new Cat[Cats.Length - 1];
            for (int i = 0, j = 0; i < Cats.Length; i++)
            {
                if (Cats[i].Nickname != nickname)
                {
                    temp[j] = Cats[i];
                    j++;
                }
            }
            Cats = temp;
        }
        public decimal GetCatsPrice()
        {
            decimal price = default;
            foreach (var cat in Cats)
            {
                price += cat.Price;
            }
            return price;
        }
        public decimal GetCatsMealQuantity()
        {
            decimal mealQuantity = default;
            foreach (var cat in Cats)
            {
                mealQuantity += cat.MealQuantity;
            }
            return mealQuantity;
        }
    }

    class PetShop
    {
        public CatHouse[] CatHouses { get; set; }
        public int CatHouseCount { get; set; }

        public PetShop() { }
        public PetShop(CatHouse[] catHouses, int catHouseCount)
        {
            CatHouses = catHouses;
            CatHouseCount = catHouseCount;
        }

        public decimal GetCatsPrice()
        {
            decimal price = default;
            foreach (var cathouse in CatHouses)
            {
                price += cathouse.GetCatsPrice();
            }
            return price;
        }
        public decimal GetCatsMealQuantity()
        {
            decimal mealQuantity = default;
            foreach (var cathouse in CatHouses)
            {
                mealQuantity += cathouse.GetCatsMealQuantity();
            }
            return mealQuantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("kity1", 1, "male", 100, 11);
            Cat cat2 = new Cat("kity2", 2, "male", 200, 22);
            Cat cat3 = new Cat("kity3", 3, "male", 300, 33);
            Cat[] cats = new Cat[] { cat1, cat2, cat3 };

            CatHouse cathouse = new CatHouse(cats, 3);
            Cat cat4 = new Cat("kity4", 4, "male", 400, 44);
            cathouse.AddCat(ref cat4);
            cathouse.ShowCats();
            cathouse.RemoveByNickname("kity2");
            cathouse.ShowCats();

            Console.WriteLine();
            Console.WriteLine($"Cats price : {cathouse.GetCatsPrice()} azn");
            Console.WriteLine($"Cats meal quantity : {cathouse.GetCatsMealQuantity()} azn");

            CatHouse[] houses = new CatHouse[] { cathouse };
            PetShop petshop = new PetShop(houses, 1);
            Console.WriteLine();
            Console.WriteLine($"All Cats price : {petshop.GetCatsPrice()} azn");
            Console.WriteLine($"All Cats meal quantity : {petshop.GetCatsMealQuantity()} azn\n");

            Console.ReadKey();
        }
    }
}
