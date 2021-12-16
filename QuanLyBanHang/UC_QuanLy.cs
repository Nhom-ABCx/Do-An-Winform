using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

using BAL;
using BEL;

namespace QuanLyBanHang
{
    public partial class UC_QuanLy : UserControl
    {
        BAL_HoaDon balHD = new BAL_HoaDon();
        public UC_QuanLy()
        {
            InitializeComponent();
        }
        private void UC_QuanLy_Load(object sender, EventArgs e)
        {
            switch (Login.Instance.taiKhoan._maLoai)
            {
                case "QLKho":
                    btnKhachHang.Hide();
                    btnNhanVien.Hide();
                    btnHoaDon.Hide();
                    break;
                case "NV":
                    btnNhanVien.Hide();
                    btnSanPham.Hide();
                    btnTonKho.Hide();
                    break;
                case "QLNS":
                    btnKhachHang.Hide();
                    btnSanPham.Hide();
                    btnTonKho.Hide();
                    btnHoaDon.Hide();
                    break;
                default:
                    break;
            }
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            UC_KhachHang uc = new UC_KhachHang();
            frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien uc = new UC_NhanVien();
            frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            UC_QLSanPham uc = new UC_QLSanPham();
            frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
        }
        private void btnTonKho_Click(object sender, EventArgs e)
        {
            UC_NhaCungCap uc = new UC_NhaCungCap();
            frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            UC_HoaDon uc = new UC_HoaDon();
            frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            //phan thong ke ko hieu ro~ lam', nguon` thao khao tu tren mang r ve sua lai
            frMain.Instance.DangOpenGrid("ThongKe");
            ReportViewer rpv = new ReportViewer();
            frMain.Instance.pnlContain2.Controls.Add(rpv);
            rpv.Dock = DockStyle.Fill;
            ReportDataSource rds = new ReportDataSource("HoaDon", balHD.DocHoaDonTrangThai1());
            rpv.LocalReport.ReportPath = @"" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\RP_HoaDon.rdlc";
            rpv.LocalReport.DataSources.Clear();
            rpv.LocalReport.DataSources.Add(rds);
            rpv.RefreshReport();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn thật sự muốn đăng xuất tài khoản ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            { 
                frMain.Instance.Hide(); Login.Instance.Show();
                frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC1);
                frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string mahd = frMain.Instance.MaHDcbo.Text;
            if (balHD.TrangThaiHD(mahd) == true)
                MessageBox.Show("Hóa đơn này đã được thanh toán", "Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                UC_ThanhToan uc = new UC_ThanhToan();
                frMain.Instance.OpenUserControl(uc, frMain.Instance.pnlUC2);
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC1);
        }
    }
}
