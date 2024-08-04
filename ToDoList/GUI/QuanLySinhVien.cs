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
    public partial class fQuanLySinhVien : Form
    {
        string status = "";
        int index = -1;

       
        #region Method
        void CreateForColumnDataGridView()
        {
            var colTenSV = new DataGridViewTextBoxColumn();
            var colMaSV = new DataGridViewTextBoxColumn();
            var colQueQuan = new DataGridViewTextBoxColumn();
            var colGioiTinh = new DataGridViewTextBoxColumn();
            var colNgaySinh = new DataGridViewTextBoxColumn();

            colTenSV.HeaderText = "TÊN SINH VIÊN";
            colMaSV.HeaderText = "MÃ SINH VIÊN";
            colQueQuan.HeaderText = "QUÊ QUÁN";
            colGioiTinh.HeaderText = "GIỚI TÍNH";
            colNgaySinh.HeaderText = "NGÀY SINH";

            colMaSV.DataPropertyName = "StrMaSV";
            colTenSV.DataPropertyName = "StrTenSV";
            colNgaySinh.DataPropertyName = "DNgaySinh";
            colQueQuan.DataPropertyName = "StrQueQuan";
            colGioiTinh.DataPropertyName = "StrGioiTinh";

            colGioiTinh.Width = 120;
            colQueQuan.Width = 120;
            colMaSV.Width = 145;
            colTenSV.Width = 145;
            colNgaySinh.Width = 120;

            dtgvSinhVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            dtgvSinhVien.Columns.AddRange(new DataGridViewColumn[] {colMaSV,colTenSV,colGioiTinh,colNgaySinh,colQueQuan});


        }
        void LoadlistSinhVien()
        {
            dtgvSinhVien.DataSource = null;
            CreateForColumnDataGridView();
            dtgvSinhVien.DataSource = DanhSachSinhVien.Instance.ListSinhVien;
            dtgvSinhVien.Refresh();
        }
        public fQuanLySinhVien()
        {
            InitializeComponent();

        }
        void EnablePanel2(bool them, bool xoa, bool sua, bool luu, bool huy)
        {
            btnThem.Enabled = them;
            btnXoa.Enabled = xoa;
            btnSua.Enabled = sua;
            btnLuu.Enabled = luu;
            btnHuy.Enabled = huy;
        }

        void EnableControls(bool isEnablePanel, bool isEnableDataGridView)
        {
            txbMaSV.Enabled = txbTenSV.Enabled = txbQueQuan.Enabled = radioButton2.Enabled = radioButton3.Enabled = dateTimePicker1.Enabled = isEnablePanel;
            dtgvSinhVien.Enabled = isEnableDataGridView;
        }
        #endregion

        #region Event
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn xoá !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Bạn có chắc chắn xóa ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            DanhSachSinhVien.Instance.ListSinhVien.RemoveAt(index);
            LoadlistSinhVien();
        }
        private void fQuanLySinhVien_Load(object sender, EventArgs e)
        {
            EnablePanel2(true, true, true, false, false);
            EnableControls(false,true);
            LoadlistSinhVien();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            EnablePanel2(true, true, true, true,true);
            string TenSV = txbTenSV.Text;
            string QueQuan = txbQueQuan.Text;
            string MaSV = txbMaSV.Text;
            DateTime NgaySinh = dateTimePicker1.Value;
            string GioiTinh = "";
            if (radioButton2.Checked)
            {
                GioiTinh = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                GioiTinh = radioButton3.Text;
            }

            if (status == "them")
            {
                DanhSachSinhVien.Instance.ListSinhVien.Add(new SinhVien(MaSV, NgaySinh, GioiTinh, QueQuan, TenSV));
            }

            if (status == "sua")
            {
                
                if (radioButton2.Checked)
                {
                    GioiTinh = "Nam";
                }
                else if (radioButton3.Checked)
                {
                    GioiTinh = "Nữ";
                }
                DanhSachSinhVien.Instance.ListSinhVien[index].StrMaSV = txbMaSV.Text;
                DanhSachSinhVien.Instance.ListSinhVien[index].StrTenSV = txbTenSV.Text;
                DanhSachSinhVien.Instance.ListSinhVien[index].DNgaySinh = dateTimePicker1.Value;
                DanhSachSinhVien.Instance.ListSinhVien[index].StrQueQuan = txbQueQuan.Text;
                DanhSachSinhVien.Instance.ListSinhVien[index].StrGioiTinh = GioiTinh;
            }
            txbMaSV.Text = "";
            txbQueQuan.Text = "";
            txbTenSV.Text = "";
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            EnablePanel2(true,true,true,false,false);
            EnableControls(false, true);
            LoadlistSinhVien();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            EnablePanel2(false, false, true, true, true);
            
           
            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn thay đổi !", "Cảnh báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioitinh = "";
            txbMaSV.Text = DanhSachSinhVien.Instance.ListSinhVien[index].StrMaSV;
            txbTenSV.Text = DanhSachSinhVien.Instance.ListSinhVien[index].StrTenSV;
            txbQueQuan.Text = DanhSachSinhVien.Instance.ListSinhVien[index].StrQueQuan;
            dateTimePicker1.Value = DanhSachSinhVien.Instance.ListSinhVien[index].DNgaySinh;
            gioitinh = DanhSachSinhVien.Instance.ListSinhVien[index].StrGioiTinh;
            if (gioitinh == "Nam")
            {
                radioButton2.Checked = true;
                radioButton3.Checked = false;
            }

            if (gioitinh == "Nữ")
            {
                radioButton3.Checked = true;
                radioButton2.Checked = false;
            }
            
            EnableControls(true, false);
            status = "sua";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txbMaSV.Text = "";
            txbQueQuan.Text = "";
            txbTenSV.Text = "";
            EnablePanel2(true, false, false, true, true) ;
            EnableControls(true, false);
            status = "them";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txbMaSV.Text = "";
            txbQueQuan.Text = "";
            txbTenSV.Text = "";
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            EnableControls(false, true);
            EnablePanel2(true, true, true, false,false) ;
        }
        private void dtgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }










        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
