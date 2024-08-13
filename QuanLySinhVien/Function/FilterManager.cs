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
    public interface ISortStrategy
    {
        void SortAscending(ref List<SinhVien> sinhVien);
        void SortDescending(ref List<SinhVien> sinhVien);
    }

    public class SortByInputTime : ISortStrategy
    {
        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderBy(inputTime => inputTime.DInputTime).ToList();
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderByDescending(inputTime => inputTime.DInputTime).ToList();
        }
    }
    public class SortByID : ISortStrategy
    {
        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderBy(maSv => maSv.StrMaSV).ToList();
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderByDescending(maSv => maSv.StrMaSV).ToList();
        }
    }

    public class SortByBirthday : ISortStrategy
    {
        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderBy(ngaySinh => ngaySinh.DNgaySinh).ToList();
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderByDescending(ngaySinh => ngaySinh.DNgaySinh).ToList();
        }
    }

    public class SortByGender : ISortStrategy
    {
        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderBy(gioiTinh => gioiTinh.StrGioiTinh).ToList();
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            sinhVien = sinhVien.OrderByDescending(gioiTinh => gioiTinh.StrGioiTinh).ToList();
        }
    }

    public class SortByName : ISortStrategy
    {
        private StringComparer comparer = StringComparer.Create(new CultureInfo("vi-VN"), true);

        private string GetFirstName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return parts[parts.Length - 1];
        }

        private string GetLastName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return parts[0];
        }

        private string GetCountMiddleName(string fullname)
        {
            string[] parts = fullname.Split(' ');
            return (fullname.Length - parts[0].Length - parts[parts.Length - 1].Length).ToString();
        }

        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            sinhVien =
                sinhVien.OrderBy(fullname => GetFirstName(fullname.StrTenSV), comparer)
                        .ThenBy(fullname => GetLastName(fullname.StrTenSV), comparer)
                        .ThenBy(fullname => GetCountMiddleName(fullname.StrTenSV), comparer)
                        .ToList();
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            sinhVien =
                sinhVien.OrderByDescending(fullname => GetFirstName(fullname.StrTenSV), comparer)
                        .ThenBy(fullname => GetLastName(fullname.StrTenSV), comparer)
                        .ThenBy(fullname => GetCountMiddleName(fullname.StrTenSV), comparer)
                        .ToList();
        }
    }
    public class FilterManager
    {
        private ISortStrategy _sortStrategy;

        public void SetFilterManager(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void SortAscending(ref List<SinhVien> sinhVien)
        {
            _sortStrategy.SortAscending(ref sinhVien);
        }

        public void SortDescending(ref List<SinhVien> sinhVien)
        {
            _sortStrategy.SortDescending(ref sinhVien);
        }
    }
}
