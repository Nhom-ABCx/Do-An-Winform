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
    public partial class UC_HoaDon : UserControl
    {
        BAL_HoaDon balHD = new BAL_HoaDon();
        BAL_KhachHang balKH = new BAL_KhachHang();
        static UC_HoaDon fm;
        public static UC_HoaDon Instance
        {
            get
            {
                if (fm == null)
                    fm = new UC_HoaDon();
                return fm;
            }
        }
        public UC_HoaDon()
        {
            InitializeComponent();
            fm = this;
        }
        private void UC_HoaDon_Load(object sender, EventArgs e)
        {
            frMain.Instance.DangOpenGrid("CTHD");
            frMain.Instance.LoadColumnGridCT_HoaDon();
            frMain.Instance.LoadData();
            
            LoadInfo();
            cboTenKH.AutoCompleteCustomSource = autoCompleteTenKH();
            cboTenKH.DataSource = balKH.DocKhachHang();
            cboTenKH.DisplayMember = "HoTenKh";
            cboTenKH.ValueMember = "MaKh";
        }
        public void LoadInfo()
        {
            foreach (DataRow row in balHD.DocTTHoaDon(frMain.Instance.MaHDcbo.Text).Rows)
            {
                if (row["TrangThai"].ToString() == "True")
                    radDaTT.Checked = true;
                if (row["TrangThai"].ToString() == "False")
                    radChuaTT.Checked = true;

                txtMaHD.Text = frMain.Instance.MaHDcbo.Text;
                txtNgayLapHD.Text = DateTime.Parse(row["NgayLapHD"].ToString()).ToString("dd/MM/yyyy");
                txtTenNVLapHD.Text = row["HoTenNV"].ToString();
                cboTenKH.Text = row["HoTenKh"].ToString();
                txtDChiGiao.Text = row["DChiGiao"].ToString();
            }
        }
        void LoadcboMaHD()
        {
            if (radChuaTT.Checked)
                frMain.Instance.MaHDcbo.DataSource = balHD.DocHoaDonTrangThai0();
            else if (radDaTT.Checked)
                frMain.Instance.MaHDcbo.DataSource = balHD.DocHoaDonTrangThai1();
            frMain.Instance.MaHDcbo.DisplayMember = "MaHD";
            frMain.Instance.MaHDcbo.ValueMember = "MaHD";
        }
        private void radChuaTT_CheckedChanged(object sender, EventArgs e)
        {
            LoadcboMaHD();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void cboTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public AutoCompleteStringCollection autoCompleteTenKH() //tham khao tren mang
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            // use databse
            foreach (DataRow row in balKH.DocKhachHang().Rows)
            {
                acsc.Add(row[1].ToString()); //lay ten KH
            }
            return acsc;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            NhanVien nv = Login.Instance.nhanVien;
            HoaDon hd = new HoaDon(DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss"), DateTime.Today, nv._maNV, cboTenKH.SelectedValue.ToString(), txtDChiGiao.Text, null, false);
            if (balHD.ThemHoaDon(hd) > 0)
            {
                MessageBox.Show("Tạo mới HĐ thành công, hãy thêm sản phẩm vào hóa đơn !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadcboMaHD();
                frMain.Instance.MaHDcbo.Text = hd._maHD;
                frMain.Instance.LoadData();
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (radDaTT.Checked)
                MessageBox.Show("Hóa đơn này đã được thanh toán không thể Chỉnh sửa được !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (balHD.CapNhatHoaDon(new HoaDon(txtMaHD.Text,DateTime.Today,null,cboTenKH.SelectedValue.ToString(),txtDChiGiao.Text,null,false))>0)
                    MessageBox.Show("Cập nhật HĐ thành công", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //frMain.Instance.MaHDcbo.SelectedIndex = 0;
                //frMain.Instance.LoadData();
                //LoadcboMaHD();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHDDangChon = frMain.Instance.MaHDcbo.Text;
            if (balHD.TrangThaiHD(maHDDangChon) == true)
                MessageBox.Show("Hóa đơn này đã được thanh toán không thể xóa được !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (balHD.XoaHoaDon(maHDDangChon) > 0)
                    MessageBox.Show("Xóa HĐ thành công", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frMain.Instance.MaHDcbo.SelectedIndex = 0;
                frMain.Instance.LoadData();
                LoadcboMaHD();
            }
        }
    }
}
