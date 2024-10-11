using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public abstract class Furniture : Product
    {
        public int id_furn;
        public string name_furn;

        public Furniture()
        {
            set_dep(2, "Мебель");
        }

        public void set_furn(int id_furn)
        {
            set_dep(2, "Мебель");
            this.id_furn = id_furn;
            this.name_furn = this.GetType().Name;
        }

        public virtual void ShowFeatures()
        {
            Console.WriteLine($"Отдел: Мебель, Вид мебели: {name_furn}, Номер отдела - 2");
        }

        public override void Set_Defect()
        {
            defect = true;
        }

        public abstract void Show();
    }
}
