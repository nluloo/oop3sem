using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json.Serialization;

namespace lab13
{
    internal interface Ipowerable
    {
        void TurnOn();
        void TurnOff();
        void Show();
    }
    [Serializable]
    [XmlInclude(typeof(PC))]
    [XmlInclude(typeof(Technique))]
    [DataContract]
    public abstract class Product
        {
        [DataMember]
        public int id_department;
        [NonSerialized]
        [XmlIgnore]
        public string name_department;
        [DataMember]
        public int price;
        [DataMember]
        public string name;
            public void set_dep(int id_department, string name_department)
            {
                this.id_department = id_department;
                this.name_department = name_department;
            }

            public int return_id_department()
            {
                return id_department;
            }
            public string return_name_department()
            {
                return name_department;
            }

            public void set_price(int price)
            {
                this.price = price;
            }

            public override string ToString()
            {
                return $"Тип устройства: {this.GetType().Name}, Цена: {this.price} ";
            }

        }
    [Serializable]
    [DataContract]
    public abstract class Technique : Product
    {
        [XmlElement]
        [DataMember]
        public int id_tech;
        [XmlElement]
        [DataMember]
        public string name_tech;

        public Technique()
        {
            set_dep(1, "Техника");
        }

        public void set_tech(int id_tech)
        {
            set_dep(1, "Техника");
            this.id_tech = id_tech;
            this.name_tech = this.GetType().Name;
        }

        public virtual void ShowFeatures()
        {
            Console.WriteLine($"Отдел: Техника, Тип техники: {name_tech}, Номер отдела - 1");
        }

        public abstract void Show();
    }
    [Serializable]
    [DataContract]
    public class PC : Technique, Ipowerable
    {
        [DataMember]
        public int ram_pc;

        static public int count_pc = 0;


        public PC()
        {
           set_price(-1);
            this.name = "default";
            set_tech(2);
            count_pc++;
            this.ram_pc = 0;
        }

        public PC(int price = -1, string name = "(", int ram_pc = 0)
        {
            set_price(price);
            this.name = name;
            set_tech(2);
            count_pc++;
            this.ram_pc = ram_pc;
        }

        public void TurnOff()
        {
            Console.WriteLine("ПК выключен");
        }
        public void TurnOn()
        {
            Console.WriteLine("ПК включен");
        }

        public string return_name_pc()
        {
            return this.name;
        }

        public override void ShowFeatures()
        {
            Console.WriteLine($"ПК: {name}, Оперативная память: {ram_pc} МБ");
        }

        public override string ToString()
        {
            return base.ToString() + $"ПК: {name}, Оперативная память: {ram_pc} МБ";
        }

        public override void Show()
        {
            Console.WriteLine($"Абстрактный метод вывел данное устройство: {name_tech} ");
        }

        void Ipowerable.Show()
        {
            Console.WriteLine($"Интерфейс вывел данное устройство: {name_tech} ");
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("\nВызван переопределенный метод сравнения");
            if (obj == null || GetType() != obj.GetType())
                return false;

            PC other = (PC)obj;
            return this.name == other.name && this.ram_pc == other.ram_pc;
        }

        public override int GetHashCode()
        {
            int hash = (name, ram_pc).GetHashCode();
            return hash;
        }
    }
}
