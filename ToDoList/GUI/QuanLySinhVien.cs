using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace QuanLySinhVien
{
    public partial class fQuanLySinhVien : Form
    {
        string status = "";
        int index = -1, sort_order = 1;
       
        #region Method
        void CreateForColumnDataGridView()
        {
            var colInputTime = new DataGridViewTextBoxColumn();
            var colMaSV = new DataGridViewTextBoxColumn();
            var colTenSV = new DataGridViewTextBoxColumn();
            var colGioiTinh = new DataGridViewTextBoxColumn();
            var colNgaySinh = new DataGridViewTextBoxColumn();
            var colQueQuan = new DataGridViewTextBoxColumn();

            colInputTime.HeaderText = "Thời gian nhập";
            colTenSV.HeaderText = "TÊN SINH VIÊN";
            colMaSV.HeaderText = "MÃ SINH VIÊN";
            colGioiTinh.HeaderText = "GIỚI TÍNH";
            colNgaySinh.HeaderText = "NGÀY SINH";
            colQueQuan.HeaderText = "QUÊ QUÁN";

            colInputTime.DataPropertyName = "DInputTime";
            colMaSV.DataPropertyName = "StrMaSV";
            colTenSV.DataPropertyName = "StrTenSV";
            colGioiTinh.DataPropertyName = "StrGioiTinh";
            colNgaySinh.DataPropertyName = "DNgaySinh";
            colQueQuan.DataPropertyName = "StrQueQuan";

            colInputTime.Width = 140;
            colGioiTinh.Width = 120;
            colQueQuan.Width = 120;
            colMaSV.Width = 145;
            colTenSV.Width = 145;
            colNgaySinh.Width = 120;

            dtgvSinhVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            dtgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colInputTime, colMaSV, colTenSV, colGioiTinh, colNgaySinh, colQueQuan });
        }
        void LoadlistSinhVien()
        {
            dtgvSinhVien.DataSource = null;
            dtgvSinhVien.Rows.Clear();
            dtgvSinhVien.Columns.Clear();
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
                MessageBox.Show("Vui lòng chọn sinh viên muốn xoá !", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa ?", "Cảnh báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new fRemoveElement().removeElement(dtgvSinhVien);
                    LoadlistSinhVien();
                }
            }
        }
        private void fQuanLySinhVien_Load(object sender, EventArgs e)
        {
            EnablePanel2(true, true, true, false, false);
            EnableControls(false,true);
            CreateForColumnDataGridView();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            EnablePanel2(true, true, true, true,true);
            string TenSV = txbTenSV.Text.ToString();
            string QueQuan = txbQueQuan.Text.ToString();
            string MaSV = txbMaSV.Text.ToString();
            DateTime NgaySinh = dateTimePicker1.Value;
            DateTime InputTime = DateTime.Now;
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
                DanhSachSinhVien.Instance.ListSinhVien.Add(new SinhVien(InputTime, MaSV, QueQuan, GioiTinh, NgaySinh, GioiTinh));
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
            btnThem.Enabled = false;
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
        private void xuấtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save an Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new fExportData().ExportData(dtgvSinhVien, saveFileDialog.FileName);
            }
        }

        private void thêmDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Select an Excel File"
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                new fImportData().ImportData(openFileDialog.FileName);
                LoadlistSinhVien();
            }
        }

        public void dtgvSinhVien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DanhSachSinhVien.Instance.ListSinhVien.Count > 0)
            {
                fFilter filterData = new fFilter();
                if (e.ColumnIndex == 0)
                    DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(time => time.DInputTime).ToList();
                else
                {
                    if (sort_order == 1)
                    {
                        filterData.Sorted_Increase(sender, e);
                        sort_order = 2;
                    }
                    else if (sort_order == 2)
                    {
                        filterData.Sorted_Decrease(sender, e);
                        sort_order = 0;
                    }
                    else if (sort_order == 0)
                    {
                        sort_order = 1;
                        DanhSachSinhVien.Instance.ListSinhVien = DanhSachSinhVien.Instance.ListSinhVien.OrderBy(time => time.DInputTime).ToList();
                    }
                }
                LoadlistSinhVien();
            }
            else
                MessageBox.Show("Không có dữ liệu", "Cảnh báo");
        }
    }
            #endregion
}
