using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class fFilter
    {
        StringComparer comparer;
        private string GetFirstName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return parts[parts.Count() - 1];
        }

        private string GetLastName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return parts[0];
        }

        private string GetCountMiddleName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return (fullname.Count() - parts[0].Count() - parts[parts.Count() - 1].Count()) + "";
        }
        public void Sorted_Increase(object sender, DataGridViewCellMouseEventArgs e)
        {
            comparer = StringComparer.Create(new CultureInfo("vi-VN"), false);
            if (e.ColumnIndex == 1)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(maSv => maSv.StrMaSV).ToList();
            }
            else if(e.ColumnIndex == 2)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(tenSv => GetFirstName(tenSv.StrTenSV), comparer)
                                                                                               .ThenBy(tenSv => GetLastName(tenSv.StrTenSV), comparer)
                                                                                               .ThenBy(tenSv => GetCountMiddleName(tenSv.StrTenSV), comparer)
                                                                                               .ToList();
            }
            else if (e.ColumnIndex == 3)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(gioiTinh => gioiTinh.StrGioiTinh, comparer).ToList();
            }
            else if (e.ColumnIndex == 4)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(ngaySinh => ngaySinh.DNgaySinh).ToList();
            }
        }

        public void Sorted_Decrease(object sender, DataGridViewCellMouseEventArgs e)
        {
            comparer = StringComparer.Create(new CultureInfo("vi-VN"), false);
            if (e.ColumnIndex == 1)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderByDescending(maSv => maSv.StrMaSV).ToList();
            }
            else if (e.ColumnIndex == 2)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderByDescending(tenSv => GetFirstName(tenSv.StrTenSV), comparer)
                                                                                               .ThenBy(tenSv => GetLastName(tenSv.StrTenSV), comparer)
                                                                                               .ThenBy(tenSv => GetCountMiddleName(tenSv.StrTenSV), comparer)
                                                                                               .ToList();
            }
            else if (e.ColumnIndex == 3)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderByDescending(gioiTinh => gioiTinh.StrGioiTinh, comparer).ToList();
            }
            else if (e.ColumnIndex == 4)
            {
                DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderByDescending(ngaySinh => ngaySinh.DNgaySinh).ToList();
            }
        }
    }
}
