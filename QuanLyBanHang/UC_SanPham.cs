using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BAL;
using BEL;

namespace QuanLyBanHang
{
    public partial class UC_SanPham : UserControl
    {
        BAL_SanPham balSP = new BAL_SanPham();
        BAL_HoaDon balHD = new BAL_HoaDon();
        public UC_SanPham()
        {
            InitializeComponent();
            UC_ = this;
        }
        static UC_SanPham UC_;
        public static UC_SanPham Instance
        {
            get
            {
                if (UC_ == null)
                    UC_ = new UC_SanPham();
                return UC_;
            }
        }
        public TextBox MaSPtxt
        {
            get { return txtMaSP; }
            set { txtMaSP = value; }
        }
        public NumericUpDown SoLuongBantxt
        {
            get { return txtSoLuongBan; }
            set { txtSoLuongBan = value; }
        }
        public TextBox GiaGiamtxt
        {
            get { return txtGiaGiam; }
            set { txtGiaGiam = value; }
        }
        public TextBox ChietKhautxt
        {
            get { return txtChietKhau; }
            set { txtChietKhau = value; }
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            cboTenSP.AutoCompleteCustomSource = frMain.Instance.autoCompleteTenSP();
            cboTenSP.DataSource = balSP.DocSanPham();
            cboTenSP.DisplayMember = "TenSp";
            cboTenSP.ValueMember = "MaSp";
        }
        public void LoadInfo(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                txtMaSP.Text = row["MaSp"].ToString();
                cboTenSP.Text = row["TenSp"].ToString();
                txtSoLuongTon.Text = row["SoLuong"].ToString();
                //tach'ra cho mat con so' 0 cua kieu Money
                string[] temp = row["GiaNhap"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length > 0)
                    txtGiaNhap.Text = temp[0];

                temp = row["GiaBan"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length > 0)
                    txtGiaXuat.Text = temp[0];

                txtMoTaSp.Text = row["MoTa"].ToString();

                //2 cach deu dc
                //pictureBox1.Image = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\"+row["URL"].ToString());
                pictureBox1.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\" + row["URL"].ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void cboTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = balSP.DocSanPham(cboTenSP.SelectedValue.ToString());
            LoadInfo(dt);
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (balHD.TrangThaiHD(frMain.Instance.MaHDcbo.Text) == true)
                MessageBox.Show("Hóa đơn này đã được thanh toán không cập nhật được !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (int.Parse(txtSoLuongBan.Text) > int.Parse(txtSoLuongTon.Text))
                        MessageBox.Show("So luong ban phai nho hon so luong Ton`!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (balHD.CapNhatCT_HoaDon(frMain.Instance.Grid, frMain.Instance.MaHDcbo.Text, txtMaSP.Text, int.Parse(txtSoLuongBan.Text), int.Parse(txtGiaGiam.Text), int.Parse(txtChietKhau.Text)) > 0)
                    MessageBox.Show("Cập nhật thành công", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cập nhật Số lượng thì hãy chọn Tên SP cho đúng !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frMain.Instance.LoadData();
                LoadInfo(balSP.DocSanPham(cboTenSP.SelectedValue.ToString()));
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (balHD.TrangThaiHD(frMain.Instance.MaHDcbo.Text) == true)
                MessageBox.Show("Hóa đơn này đã được thanh toán không thể xóa SP được !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (balHD.XoaCT_HoaDon(frMain.Instance.Grid, frMain.Instance.MaHDcbo.Text, txtMaSP.Text) > 0)
                    MessageBox.Show("Xóa sp thành công", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frMain.Instance.LoadData();
            }
        }
    }
}
