using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using QuanLySinhVien;

namespace QuanLySinhVien
{
    public interface IRemoveElement
    {
        void Remove(List<SinhVien> sinhVien, List<int> indexsToRemove, DataGridView dtgvSinhVien);
    }

    public class RemoveElementByIndex : IRemoveElement
    {
        public void Remove(List<SinhVien> sinhVien, List<int> indexsToRemove, DataGridView dtgvSinhVien)
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

    public class RemoveElementByIndexEdit : IRemoveElement
    {
        public void Remove(List<SinhVien> sinhVien, List<int> indexsToRemove, DataGridView dtgvSinhVien)
        {

            Dictionary<int, SinhVien> myDict = new Dictionary<int, SinhVien>();
            SortedSet<int> sortedSet = new SortedSet<int>(indexsToRemove);
            indexsToRemove = new List<int>(sortedSet);

            int cnt = 0;
            var cellValue = dtgvSinhVien.Rows[indexsToRemove[cnt]].Cells[0].Value;
            for (int i = 0; i < DanhSachSinhVien.Instance.ListSinhVien.Count; i++)
            {
                myDict[i] = sinhVien[i];
                if (cnt < indexsToRemove.Count && sinhVien[i].DInputTime.ToString() == cellValue.ToString())
                {
                    indexsToRemove[cnt] = i; cnt++;
                    if(cnt <  indexsToRemove.Count ) cellValue = dtgvSinhVien.Rows[indexsToRemove[cnt]].Cells[0].Value;
                }
            }

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
        private IRemoveElement _removeElement;

        public UIRemove(IRemoveElement removeElement)
        {
            _removeElement = removeElement;
        }

        public void RemoveSelectedRows(ref DataGridView dtgvSinhVien)
        {
            List <int> indexs = new List<int>();

            foreach(DataGridViewRow row in dtgvSinhVien.SelectedRows)
                indexs.Add(row.Index);
            _removeElement.Remove(DanhSachSinhVien.Instance.ListSinhVien, indexs, dtgvSinhVien);
        }

    }
}
