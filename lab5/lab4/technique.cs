﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public abstract class Technique : Product
    {
        public int id_tech;
        public string name_tech;
        public int max_id_tech = 5;
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

        public override void Set_Defect()
        {
            defect = true;
        }

        public abstract void Show();
    }
}
