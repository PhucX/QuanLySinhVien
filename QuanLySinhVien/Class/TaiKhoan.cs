using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TaiKhoan
    {
        private string name;
        private string pass;

        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
        public TaiKhoan(string name, string pass) 
        {
            Name = name;
            Pass = pass;
        }
    }
}
