using QuanLySinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class fDangKi : Form
    {
        public fDangKi()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txbDK_MatKhau.Text != txbDK_XnMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu không giống nhau !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txbDK_TaiKhoan.Text == "" || txbDK_MatKhau.Text == "" || txbDK_XnMatKhau.Text == "")
            {
                MessageBox.Show("Tài khoản mật khẩu không hợp lệ !","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Name = txbDK_TaiKhoan.Text;
                string Pass = txbDK_MatKhau.Text;
                DanhSachTaiKhoan.Instance.ListTaiKhoan.Add(new TaiKhoan(Name, Pass));
                this.Hide();
                new fDangNhap().ShowDialog();
                this.Close();
            }
        }
    }
}
