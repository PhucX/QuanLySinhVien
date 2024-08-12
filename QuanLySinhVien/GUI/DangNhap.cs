using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void bntDangNhap_Click(object sender, EventArgs e)
        {
            if (txbMatKhau.Text != "123456" || txbTaiKhoan.Text != "nhom13")
            {
                MessageBox.Show("Tài khoản hay mật khẩu không hợp lệ" +
                " !","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công" + " ! ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                new fQuanLySinhVien().ShowDialog();
                this.Close();
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
