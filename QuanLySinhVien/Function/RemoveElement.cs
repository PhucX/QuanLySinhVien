using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class RemoveElement
    {
        public void RemoveElementByIndex(List <SinhVien> sinhVien, List <int> indexsToRemove)
        {
            Dictionary<int, SinhVien> myDict = new Dictionary<int, SinhVien>();

            for (int i = 0; i < DanhSachSinhVien.Instance.ListSinhVien.Count; i++)
                myDict[i] = sinhVien[i];

            foreach (int index in indexsToRemove)
                myDict.Remove(index);

            sinhVien.Clear();

            foreach (var value in myDict.Values)
                sinhVien.Add(value);

            DanhSachSinhVien.Instance.ListSinhVien = sinhVien;
        }
    }
    public class UIRemove
    {
        private RemoveElement _removeElement;

        public UIRemove(RemoveElement removeElement)
        {
            _removeElement = removeElement;
        }

        public void RemoveSelectedRows(DataGridView dtgvSinhVien)
        {
            List <int> indexs = new List<int>();

            foreach(DataGridViewRow row in dtgvSinhVien.SelectedRows)
                indexs.Add(row.Index);
            
            _removeElement.RemoveElementByIndex(DanhSachSinhVien.Instance.ListSinhVien, indexs);
        }
    }
}
