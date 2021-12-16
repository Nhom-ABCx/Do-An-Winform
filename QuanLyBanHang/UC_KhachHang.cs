using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BAL;
using BEL;

namespace QuanLyBanHang
{
    public partial class UC_KhachHang : UserControl
    {
        BAL_KhachHang balKH = new BAL_KhachHang();
        BAL_TaiKhoan balTK = new BAL_TaiKhoan();
        public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            frMain.Instance.DangOpenGrid("KH");
            frMain.Instance.Grid.Columns.Clear();
            frMain.Instance.Grid.DataSource = balKH.DocKhachHang();
        }
        public void LoadInfo(int i)
        {
            txtMaKH.Text = frMain.Instance.Grid["MaKh", i].Value.ToString();
            txtHoTenKH.Text = frMain.Instance.Grid["HoTenKh", i].Value.ToString();
            txtDiaChi.Text = frMain.Instance.Grid["DiaChi", i].Value.ToString();
            txtMaTK.Text = frMain.Instance.Grid["MaTK", i].Value.ToString();
            if (frMain.Instance.Grid["TrangThai", i].Value.ToString() == "True")
                radTrangThai1.Checked = true;
            if (frMain.Instance.Grid["TrangThai", i].Value.ToString() == "False")
                radTrangThai0.Checked = true;
        }
        void LayTTDoVaoBELKhachHang(KhachHang kh)
        {
            kh._maKH = txtMaKH.Text;
            kh._hoTenKH = txtHoTenKH.Text;
            kh._diaChi = txtDiaChi.Text;
            kh._maTK = txtMaTK.Text;
            if (radTrangThai0.Checked == true) kh._trangThai = false;
            else kh._trangThai = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in frMain.Instance.Grid.Rows)
            {
                if (row.Cells["MaKh"].Value.ToString() == txtMaKH.Text)
                {
                    MessageBox.Show("Hãy tạo mới Mã KH !", "Có lỗi xảy ra !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (txtHoTenKH.Text != "" && txtMaKH.Text != "")
            {
                frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                frm.ShowDialog();
                KhachHang kh = new KhachHang();
                LayTTDoVaoBELKhachHang(kh);
                kh._maTK = frmTaoTaiKhoan.Instance.tkThemKH._maTK;
                if (balTK.ThemTaiKhoan(frmTaoTaiKhoan.Instance.tkThemKH) > 0)
                    if (balKH.ThemKhachHang(kh) > 0)
                        MessageBox.Show("Thêm khách hàng thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Họ&Tên,Mã KH mới không được để trống !", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            frMain.Instance.Grid.DataSource = balKH.DocKhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = balKH.LayMaKHMoi();
            List<string> NgauNhienTen = new List<string> { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng", "Bùi", "Đỗ", "Hồ", "Ngô", "Dương", "Lý" };
            Random rand = new Random();
            txtHoTenKH.Text = NgauNhienTen[rand.Next(NgauNhienTen.Count)] + " " + NgauNhienTen[rand.Next(NgauNhienTen.Count)];
            radTrangThai0.Checked = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            LayTTDoVaoBELKhachHang(kh);
            if (balKH.CapNhatKhachHang(kh) > 0)
                MessageBox.Show("Cập nhật thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frMain.Instance.Grid.DataSource = balKH.DocKhachHang();
        }
    }
}
