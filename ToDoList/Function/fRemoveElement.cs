using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public class fRemoveElement
    {
        public void removeElement(DataGridView dtgvSinhVien)
        {
            Dictionary<int, SinhVien> myDict = new Dictionary<int, SinhVien>();

            for (int i = 0; i < DanhSachSinhVien.Instance.ListSinhVien.Count; i++)
                myDict[i] = DanhSachSinhVien.Instance.ListSinhVien[i];

            foreach (DataGridViewRow row in dtgvSinhVien.SelectedRows)
                myDict.Remove(row.Index);

            DanhSachSinhVien.Instance.ListSinhVien.Clear();

            foreach (var value in myDict.Values)
                DanhSachSinhVien.Instance.ListSinhVien.Add(value);
            myDict.Clear();
        }
    }
}
