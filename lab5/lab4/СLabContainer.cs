using System;

namespace lab4
{
    internal class CLabContainer
    {
        private object[] items;

        public object[] Items { get { return items; } set { items = value; } }

        public CLabContainer(int capacity)
        {
            items = new object[capacity];
        }

        private void Set_Deffect(int index)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    if (items[i] is Product pr)
                    {
                        pr.Set_Defect();
                    }
                }
            }
        }

        private void Add(object item)
        {

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    return;
                }
            }
            throw new InvalidOperationException("Нет свободного места для добавления нового объекта.");
        }


        private void Remove(int item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (i == item)
                {
                    items[i] = null; 
                    return;
                }
                else
                {
                    return;
                }
            }
            throw new ArgumentException("Указанный объект не найден в контейнере.");
        }

        
        public object Get(int index)
        {
            if (index >= 0 && index < items.Length && items[index] != null)
            {
                return items[index];
            }
            throw new IndexOutOfRangeException("Некорректный индекс или объект не существует.");
        }

        private void Set(int index, object item)
        {
            if (index >= 0 && index < items.Length)
            {
                items[index] = item;
            }
            else
            {
                throw new IndexOutOfRangeException("Некорректный индекс.");
            }
        }

        private void PrintAll()
        {
            Console.WriteLine("Список объектов в контейнере:");
            foreach (var item in items)
            {
                if (item != null)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public int TotalCostItems()
        {
            int sum = 0;
            foreach (var item in items)
            {
                if (item is Product prod)
                {
                    sum += prod.price;
                }
            }
            return sum;
        }

        private int CompareItems(object x, object y)
        {
            if (x is Product productX && y is Product productY)
            {
                return productY.price.CompareTo(productX.price);
            }
            else
            {
                throw new ArgumentException("Оба объекта должны быть одинакового типа");
            }
        }
        public void PrintPrice()
        {
            Array.Sort(items, CompareItems);
            Console.WriteLine("Отсортированный список по цене: ");
            foreach (var item in items)
            {
                if (item is Product prod)
                {
                    Console.WriteLine(prod.ToString());
                }
            }
        }

        public void Del_Defect()
        {
            bool flag = false;
            Console.WriteLine("Бракованная техника, которая подлежит списанию: ");
            foreach (var item in items)
            {
                if (item is Product prod && prod.defect)
                {
                    Console.WriteLine(prod.ToString());
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Бракованный предметов нет!");
            }
        }
        internal class CLabController
        {
            private CLabContainer container;

            public CLabController(CLabContainer container)
            {
                this.container = container;
            }
            public object GetIndex(int index)
            {
                return container.Get(index);
            }

            public void DefectiItems()
            {
                container.Del_Defect();
            }
            public void SetObject(int index, object obj)
            {
                container.Set(index, obj);
                Console.WriteLine($"Изменён объект: {container.Get(index)}");
            }
            public void Set_Def(int index)
            {
                container.Set_Deffect(index);
            }

            public void AddItem(object item)
            {
                container.Add(item);
                Console.WriteLine($"Добавлен объект: {item}");
            }

            public void RemoveItem(int index)
            {
                container.Remove(index);
                Console.WriteLine($"Удален объект: {index}");
            }

            public void PrintAllItems()
            {
                container.PrintAll();
            }

            public void PrintTotalCost()
            {
                int totalCost = container.TotalCostItems();
                Console.WriteLine($"Общая стоимость всех объектов в контейнере: {totalCost}");
            }

            public void SortItemsByPrice()
            {
                container.PrintPrice();
            }

            public void RemoveDefectiveItems()
            {
                container.Del_Defect();
            }
            public void LoadProductsFromFile(string filePath)
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    string productType = parts[0].ToLower().Trim();

                    Product product = null;

                    switch (productType)
                    {
                        case "pc":
                            product = new PC(
                                Convert.ToInt32(parts[1].Trim()),
                                parts[2].Trim(),
                                Convert.ToInt32(parts[3].Trim())
                                );
                            break;

                        case "monitor":
                            product = new Monitor(
                                Convert.ToInt32(parts[1].Trim()),
                                parts[2].Trim(),
                                Convert.ToInt32(parts[3].Trim())
                                );
                            break;

                        case "headphones":
                            product = new Headphones(
                                Convert.ToInt32(parts[1].Trim()),
                                parts[2].Trim(),
                                parts[3].Trim()
                                );
                            break;

                        default:
                            Console.WriteLine($"Неизвестный тип продукта: {productType}");
                            break;
                    }

                    if (product != null)
                    {
                        AddItem(product);
                    }
                }
            }
        }
    }
}
    
