using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{

    public class Programmer
    {
        public delegate void CLang(string message);
        public delegate void CProp(string name);

        private string Language;
        private string Version;
        List<string> Properties = new List<string>();

        public event CLang Lang;
        public event CProp Prop;

        public void ChangeLanguage(string name)
        {
            this.Language = name;
            Lang?.Invoke($"Имя переименовано на '{name}'");
        }

        public void ChangeVersion(string version)
        {
            this.Version = version;
            Lang?.Invoke($"Версия изменена на '{version}'");
        }

        public string GetLanguage() => this.Language;
        public string GetVersion() => this.Version;

        public void AddProp(string name)
        {
            if (!Properties.Contains(name))
            {
                Properties.Add(name);
                Prop?.Invoke($"Добавлено новое свойство '{name}'");
            }
            else
            {
                Console.WriteLine("Данное свойство уже присутствует в списке");
            }
        }

        public Programmer(string name, string version)
        {
            this.Language = name;
            this.Version = version;
        }
    }
}
