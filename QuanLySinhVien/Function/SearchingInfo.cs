using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLySinhVien
{
    public interface ISearchStrategy
    {
        List<SinhVien> Search(List<SinhVien> sinhVien, string keyword);
    }

    public class SearchByName : ISearchStrategy
    {
        public List<SinhVien> Search(List<SinhVien> sinhVien, string keyword)
        {
            return sinhVien.Where(sv => sv.StrTenSV.ToLower().Contains(keyword)).ToList();
        }
    }
    public class SearchByID : ISearchStrategy
    {
        public List<SinhVien> Search(List<SinhVien> sinhVien, string keyword)
        {
            return sinhVien.Where(sv => sv.StrMaSV.Contains(keyword)).ToList();
        }
    }
    public class SearchingInfo
    { 
        private ISearchStrategy _searchStrategy;

        public SearchingInfo(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public List<SinhVien> Search(List<SinhVien> sinhVien, string keyword)
        {
            return _searchStrategy.Search(sinhVien, keyword);
        }
    }
}
