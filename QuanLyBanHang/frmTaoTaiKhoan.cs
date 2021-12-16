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
    public partial class frmTaoTaiKhoan : Form
    {
        public TaiKhoan tkThemNV = new TaiKhoan();
        public TaiKhoan tkThemKH = new TaiKhoan();
        BAL_TaiKhoan balTK = new BAL_TaiKhoan();
        static frmTaoTaiKhoan fm;
        public static frmTaoTaiKhoan Instance
        {
            get
            {
                if (fm == null)
                    fm = new frmTaoTaiKhoan();
                return fm;
            }
        }
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
            fm = this;
        }
        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            if (frMain.DangMoGrid.NV)
            {
                cboLoaiTK.DataSource = balTK.DocDSLoaiNV();
                cboLoaiTK.SelectedIndex = 1;
            }
            if (frMain.DangMoGrid.KH)
            {
                cboLoaiTK.DataSource = balTK.DocDSLoaiKH();
                cboLoaiTK.SelectedIndex = 0;
            }
            cboLoaiTK.DisplayMember = "TenLoai";
            cboLoaiTK.ValueMember = "MaLoai";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtMK.Text == "" || txtPhone.Text == "" || cboLoaiTK.Text == "")
                MessageBox.Show("Không được bỏ trống các thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtMK.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu không khớp, hãy nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMK.Clear();
                txtXacNhanMK.Clear();
                txtMK.Focus();
            }
            else if (txtEmail.Text == txtMK.Text)
            {
                MessageBox.Show("Email và mật khẩu không được trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Clear();
                txtMK.Clear();
                txtXacNhanMK.Clear();
                txtEmail.Focus();
            }
            else if (frMain.DangMoGrid.NV)
            {
                BAL_NhanVien balNV = new BAL_NhanVien();
                if (ktTrungEmail(txtEmail.Text))
                {
                    MessageBox.Show("EMail đã tồn tại, vui lòng thêm vào eMail khác !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    tkThemNV._maLoai = cboLoaiTK.SelectedValue.ToString();
                    tkThemNV._maTK = balTK.TaoMaTaiKhoanMoi(tkThemNV._maLoai, balNV.LayMaNVMoi());
                    tkThemNV._email = txtEmail.Text;
                    //mahoa
                    tkThemNV._matKhau = Encryption.Encrypt(txtMK.Text);
                    tkThemNV._phone = txtPhone.Text;
                    tkThemNV._ngayTao = DateTime.Today;
                    tkThemNV._trangThai = true;
                    this.Close();
                }
            }
            else if (frMain.DangMoGrid.KH)
            {
                BAL_KhachHang balKH = new BAL_KhachHang();
                if (ktTrungEmail(txtEmail.Text))
                {
                    MessageBox.Show("EMail đã tồn tại, vui lòng thêm vào eMail khác !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    tkThemKH._maLoai = cboLoaiTK.SelectedValue.ToString();
                    tkThemKH._maTK = balTK.TaoMaTaiKhoanMoi(tkThemKH._maLoai, balKH.LayMaKHMoi());
                    tkThemKH._email = txtEmail.Text;
                    //mahoa
                    tkThemKH._matKhau = Encryption.Encrypt(txtMK.Text);
                    tkThemKH._phone = txtPhone.Text;
                    tkThemKH._ngayTao = DateTime.Today;
                    tkThemKH._trangThai = true;
                    this.Close();
                }
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;   //Ép không nhận ký tự gõ vào
        }
        bool ktTrungEmail(string eMail)
        {
            foreach (DataRow row in balTK.DocDSTaiKhoan().Rows)
            {
                if (row["eMail"].ToString() == eMail)
                    return true;
            }
            return false;
        }
    }
}
