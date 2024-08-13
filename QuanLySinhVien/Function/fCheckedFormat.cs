using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLySinhVien
{
    public class fCheckedFormat
    {
        public bool checkedInsideBox(bool isBoy, bool isGirl, string MaSV, string TenSV, string QueQuan)
        {
            if (!MaSV.All(char.IsDigit))
            {
                MessageBox.Show("Mã sinh viên chỉ được chứa các ký tự số", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(!TenSV.All(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Tên sinh viên chỉ được chứa các ký tự chữ cái", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!QueQuan.All(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Quê quán chỉ được chứa các ký tự chữ cái", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (MaSV == "" || TenSV == "" || QueQuan == "")
            {
                MessageBox.Show("Không được bỏ trống thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!isBoy && !isGirl)
            {
                MessageBox.Show("Vui lòng chọn ô giới tính", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
