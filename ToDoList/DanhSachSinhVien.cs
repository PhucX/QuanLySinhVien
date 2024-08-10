using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    
    public class DanhSachSinhVien
    {
        private static DanhSachSinhVien instance;
        List<SinhVien> listSinhVien;

        public static DanhSachSinhVien Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new DanhSachSinhVien();
                }
                return instance;
            }
            set => instance = value; 
        }
        public List<SinhVien> ListSinhVien { get => listSinhVien; set => listSinhVien = value; }
        private DanhSachSinhVien()
        {
            listSinhVien = new List<SinhVien>();
        }
    }
}
