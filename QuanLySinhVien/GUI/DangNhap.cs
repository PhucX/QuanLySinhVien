using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ToDoList;

namespace QuanLySinhVien
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        int oke = 1;
        private void bntDangNhap_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < DanhSachTaiKhoan.Instance.ListTaiKhoan.Count; i++)
            {
                if (txbMatKhau.Text == DanhSachTaiKhoan.Instance.ListTaiKhoan[i].Pass   &&  txbTaiKhoan.Text == DanhSachTaiKhoan.Instance.ListTaiKhoan[i].Name )
                {
                    oke = 0;
                    this.Hide();
                    new fQuanLySinhVien().ShowDialog();
                    this.Close();
                }
            }
            if (oke == 1)
            {
                MessageBox.Show("Tài khoản hay mật khẩu không hợp lệ" +
                   " !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llbDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new fDangKi().ShowDialog();
            this.Close();
        }

        
    }
}
