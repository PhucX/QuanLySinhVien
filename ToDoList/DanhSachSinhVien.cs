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
            listSinhVien.Add(new SinhVien("23110288", new DateTime(2005,3,23), "Nam", "Long An", "Nguyễn Trọng Phúc"));
            listSinhVien.Add(new SinhVien("23110277", new DateTime(2005,4,12), "Nam", "Tiền Giang", "Võ Thanh Nhã"));

        }
    }
}
