using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class SinhVien
    {
        private string strMaSV;
        private DateTime dInputTime; 
        private DateTime dNgaySinh;
        private string strGioiTinh;
        private string strQueQuan;
        private string strTenSV;

        public DateTime DInputTime { get => dInputTime;  set => dInputTime = value; }
        public string StrMaSV 
        { 
            get => strMaSV; 
            set => strMaSV = value; 
        }
        public string StrTenSV { get => strTenSV; set => strTenSV = value; }
        public string StrGioiTinh { get => strGioiTinh; set => strGioiTinh = value; }
        public DateTime DNgaySinh { get => dNgaySinh; set => dNgaySinh = value; }
        public string StrQueQuan { get => strQueQuan; set => strQueQuan = value; }

        public SinhVien(DateTime dInputTime , string strMaSV, string strTenSV, string strGioiTinh, DateTime dNgaySinh, string strQueQuan)
        {
            StrMaSV = strMaSV;
            DNgaySinh = dNgaySinh;
            StrGioiTinh= strGioiTinh;
            StrQueQuan = strQueQuan;
            StrTenSV = strTenSV;
            DInputTime = dInputTime;
        }
    }
}
