using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class DanhSachTaiKhoan
    {
        private static DanhSachTaiKhoan instance;
        List<TaiKhoan> listTaiKhoan;
        public static DanhSachTaiKhoan Instance
        {
            get { 
                if (instance == null)
                {
                    instance = new DanhSachTaiKhoan();
                }
                return instance; }
            set => instance = value;
        }
        public List<TaiKhoan> ListTaiKhoan { get => listTaiKhoan; set => listTaiKhoan = value; }
        private DanhSachTaiKhoan()
        {
            listTaiKhoan = new List<TaiKhoan>();
            listTaiKhoan.Add(new TaiKhoan("trongphuc", "trongphuc123"));
        }
    }
}
