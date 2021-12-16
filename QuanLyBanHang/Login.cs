using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using BEL;
using BAL;

namespace QuanLyBanHang
{
    public partial class Login : Form
    {
        static Login _opj;
        BAL_TaiKhoan balTK = new BAL_TaiKhoan();

        public TaiKhoan taiKhoan = new TaiKhoan();
        public NhanVien nhanVien = new NhanVien();
        public NgayLamViec ngayLamViec = new NgayLamViec();
        public static Login Instance
        {
            get
            {
                if (_opj == null)
                {
                    _opj = new Login();
                }

                return _opj;
            }
        }

        public ComboBox ChucVucb
        {
            get { return cbChucVu; }
            set { cbChucVu = value; }
        }

        public Login()
        {
            InitializeComponent();
             _opj = this;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            cbChucVu.DataSource = balTK.DocDSLoaiNV();
            cbChucVu.DisplayMember = "TenLoai";
            cbChucVu.ValueMember = "MaLoai";

            txtTaiKhoan.Text = "Admin@gmail.com";
            txtMatKhau.Text = "Msyeszv9";

            //txtTaiKhoan.Text = "nv001@gmail.com";
            //txtMatKhau.Text = "Rcsvono0";
            //cbChucVu.SelectedValue = "NV";

            //txtTaiKhoan.Text = "qlkho001@gmail.com";
            //txtMatKhau.Text = "Dnapxkq5";
            //cbChucVu.SelectedValue = "QLKho";

            //txtTaiKhoan.Text = "qlns001@gmail.com";
            //txtMatKhau.Text = "Tdmweis3";
            //cbChucVu.SelectedValue = "QLNS";
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            bool ktTK = false;
            bool ktQuyen = false;
            bool ktTinhNgayLamViec = false;
            taiKhoan = new TaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);

            if (balTK.DocTK(taiKhoan, nhanVien, ngayLamViec).Rows.Count>0) //neu co du~ lieu
                ktTK = true;
            if (taiKhoan._maLoai == cbChucVu.SelectedValue.ToString())
                ktQuyen = true;
            //if (balTK.TinhNgayLam(nhanVien, ngayLamViec) > 0) //bat dau tinh' ngay lam viec
                ktTinhNgayLamViec = true;

            if ((ktQuyen == true) && (ktTK == true) && (ktTinhNgayLamViec == true))
            {
                this.Hide();
                frMain.Instance.Show();
            }
            else
            {
                if ((ktQuyen == false) || (ktTK == false))
                    MessageBox.Show("Đăng nhập thất bại ,vui lòng kiểm tra lại!\nHoặc đã bị khóa( Vui lòng liên hệ quản trị viên để mở lại)");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
