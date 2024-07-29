using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WindowsFormsApp5
{
    public enum Category
    {
        ColdAppetizers,
        FirstCourses,
        SecondCourses,
        Desserts,
        Drinks
    }

    public class Cook
    {
        protected string firstName;
        protected string lastName;

        public Cook()
        {
            this.firstName = "Unknown";
            this.lastName = "Unknown";
        }

        public Cook(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string GetInfo()
        {
            return $"Cook Full Name: {firstName} {lastName}";
        }
        public override string ToString()
        {
            return $"Full Name: {firstName} {lastName}";
        }

        public static bool operator ==(Cook c1, Cook c2)
        {
            return c1.firstName == c2.firstName && c1.lastName == c2.lastName;
        }

        public static bool operator !=(Cook c1, Cook c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Cook)
            {
                Cook other = (Cook)obj;
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode();
        }
    }

    public class Dish : Cook, ICloneable, IComparable<Dish>
    {
        private string name;
        private int cost;
        private int preparationTime; // minutes
        private Category category;

        public Dish()
        {
            this.name = "Unknown";
            this.cost = 0;
            this.preparationTime = 0;
            this.category = Category.ColdAppetizers;
        }

        public Dish(string name, int cost, int preparationTime, Category category, string cookFirstName, string cookLastName)
            : base(cookFirstName, cookLastName)
        {
            this.name = name;
            this.cost = cost;
            this.preparationTime = preparationTime;
            this.category = category;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int PreparationTime
        {
            get { return preparationTime; }
            set { preparationTime = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\nName: {name}\nCost: {cost}\nPreparation Time: {preparationTime} minutes\nCategory: {category}";
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Name: {name}, Cost: {cost}, Preparation Time: {preparationTime} minutes, Category: {category};";
        }

        public virtual string GetShortInfo()
        {
            return $"Dish: {name}, Cost: {cost}";
        }

        public static bool operator <(Dish d1, Dish d2)
        {
            return d1.cost < d2.cost;
        }

        public static bool operator >(Dish d1, Dish d2)
        {
            return d1.cost > d2.cost;
        }
        public object Clone()
        {
            return new Dish(this.name, this.cost, this.preparationTime, this.category, this.FirstName, this.LastName);
        }
        public int CompareTo(Dish other)
        {
            if (other == null) return 1;
            return this.cost.CompareTo(other.cost);
        }
    }

    public class Order : ICloneable
    {
        private string cafeName;
        private DateTime currentDate;
        private List<Dish> dishes;

        public string CafeName
        {
            get { return cafeName; }
            set { cafeName = value; }
        }

        public DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }

        }

        public List<Dish> Dishes
        {
            get { return dishes; }
            set { dishes = value; }
        }

        public Order()
        {
            this.cafeName = "Unknown cafe";
            this.currentDate = DateTime.Now;
            this.dishes = new List<Dish>();
        }

        public Order(string cafeName)
        {
            this.cafeName = cafeName;
            this.currentDate = DateTime.Now;
            this.dishes = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }

        public bool RemoveDish(string dishName)
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                if (dishes[i].Name == dishName)
                {
                    dishes.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Dish this[int index]
        {
            get
            {
                if (index >= 0 && index < dishes.Count)
                {
                    return dishes[index];
                }
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
        public int Count() { return dishes.Count; }

        public string GetOrderInfo()
        {
            string orderInfo = $"Cafe: {cafeName}\nDate: {currentDate}\nDishes:\n";
            foreach (var dish in dishes)
            {
                orderInfo += $"{dish.GetInfo()}\n";
            }
            return orderInfo;
        }

        public string GetShortOrderInfo()
        {
            string orderInfo = $"Cafe: {cafeName}\nDate: {currentDate}\nDishes:\n";
            foreach (var dish in dishes)
            {
                orderInfo += $"{dish.GetShortInfo()}\n";
            }
            return orderInfo;
        }
        public void SortDishesByCost()
        {
            dishes.Sort((d1, d2) =>
            {
                if (d1 < d2)
                    return -1;
                if (d1 > d2)
                    return 1;
                return 0;
            });
        }

        public Order FilterByCook(Cook cook)
        {
            Order filteredOrder = new Order(this.cafeName);
            foreach (var dish in dishes)
            {
                if (dish.FirstName == cook.FirstName && dish.LastName == cook.LastName)
                {
                    filteredOrder.AddDish(dish);
                }
            }
            return filteredOrder;
        }
        public object Clone()
        {
            Order clonedOrder = new Order(this.cafeName);
            clonedOrder.currentDate = this.currentDate;
            clonedOrder.dishes = new List<Dish>(this.dishes.Count);
            foreach (var dish in this.dishes)
            {
                clonedOrder.dishes.Add((Dish)dish.Clone());
            }
            return clonedOrder;
        }

        public override string ToString()
        {
            string orderInfo = $"Cafe: {cafeName}, Date: {currentDate}, Dishes: [";
            foreach (var dish in dishes)
            {
                orderInfo += $"{dish}, ";
            }
            orderInfo = orderInfo.TrimEnd(',', ' ') + "]";
            return orderInfo;
        }
    }
}
