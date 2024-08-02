using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public class SinhVien
    {
        private string strMaSV;
        private DateTime dNgaySinh;
        private string strGioiTinh;
        private string strQueQuan;
        private string strTenSV;
        public string StrMaSV 
        { 
            get => strMaSV; 
            set => strMaSV = value; 
        }
        
        
        
        public string StrTenSV { get => strTenSV; set => strTenSV = value; }
        public DateTime DNgaySinh { get => dNgaySinh; set => dNgaySinh = value; }
        public string StrGioiTinh { get => strGioiTinh; set => strGioiTinh = value; }
        public string StrQueQuan { get => strQueQuan; set => strQueQuan = value; }

        public SinhVien(string strMaSV, DateTime dNgaySinh, string strGioiTinh, string strQueQuan, string strTenSV)
        {
            StrMaSV = strMaSV;
            DNgaySinh = dNgaySinh;
            StrGioiTinh= strGioiTinh;
            StrQueQuan = strQueQuan;
            StrTenSV = strTenSV;
        }
        
        
    }

   
}
