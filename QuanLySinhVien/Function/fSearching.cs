using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class fSearching
    {
        public void searchingInfo(ref DataGridView dtgvSinhVien, string filterText)
        {
            if(filterText == null)
                dtgvSinhVien.DataSource = DanhSachSinhVien.Instance.ListSinhVien;
            else
            {
                List<SinhVien> filteredList = DanhSachSinhVien.Instance.ListSinhVien
                       .Where(p => p.StrTenSV.ToLower().Contains(filterText)
                              || p.StrMaSV.Contains(filterText))
                       .ToList();
                dtgvSinhVien.DataSource = filteredList;
            }
        }
    }
}
