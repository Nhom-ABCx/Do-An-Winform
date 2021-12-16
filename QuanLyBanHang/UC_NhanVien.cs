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
    public partial class UC_NhanVien : UserControl
    {
        BAL_NhanVien balNV = new BAL_NhanVien();
        BAL_TaiKhoan balTK = new BAL_TaiKhoan();
        public UC_NhanVien()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            frMain.Instance.DangOpenGrid("NV");
            frMain.Instance.Grid.Columns.Clear();
            frMain.Instance.Grid.DataSource = balNV.DocNhanVien();
        }
        public void LoadInfo(int i)
        {
            txtMaNV.Text = frMain.Instance.Grid["MaNV", i].Value.ToString();
            txtHoTenNV.Text = frMain.Instance.Grid["HoTenNV", i].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(frMain.Instance.Grid["NgaySinh", i].Value.ToString());
            if (frMain.Instance.Grid["GioiTinh", i].Value.ToString() == "Nam")
                radNam.Checked = true;
            else radNu.Checked = true;
            txtDiaChi.Text = frMain.Instance.Grid["DiaChi", i].Value.ToString();
            txtMaTK.Text = frMain.Instance.Grid["MaTK", i].Value.ToString();
            string[] temp = frMain.Instance.Grid["LuongCB", i].Value.ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 0)
                txtLuongCB.Text = temp[0];
            txtTongGioLam.Text = frMain.Instance.Grid["TongGioLam", i].Value.ToString();
            if (frMain.Instance.Grid["TrangThai", i].Value.ToString() == "True")
                radTrangThai1.Checked = true;
            else radTrangThai0.Checked = true;
            txtURL.Text = frMain.Instance.Grid["URL", i].Value.ToString();
            //2 cach deu dc
            //pictureBox1.Image = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\"+txtURL.Text);
            pictureBox1.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\NhanVien\\" + txtURL.Text);
        }
        void LayTTDoVaoBELNHanVien(NhanVien nv)
        {
            nv._maNV = txtMaNV.Text;
            nv._hotenNV = txtHoTenNV.Text;
            nv._ngaySinh = dtpNgaySinh.Value;
            if (radNam.Checked == true) nv._gioiTinh = "Nam";
            else nv._gioiTinh = "Nữ";
            nv._diaChi = txtDiaChi.Text;
            nv._maTK = txtMaTK.Text;
            nv._luongCB = int.Parse(txtLuongCB.Text);
            if (radTrangThai0.Checked == true) nv._trangThai = false;
            else nv._trangThai = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in frMain.Instance.Grid.Rows)
            {
                if (row.Cells["MaNV"].Value.ToString() == txtMaNV.Text)
                {
                    MessageBox.Show("Hãy tạo mới Mã NV !", "Có lỗi xảy ra !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int soTuoi = int.Parse(DateTime.Today.ToString("yyyy")) - int.Parse(dtpNgaySinh.Value.ToString("yyyy"));
            if (soTuoi <= 18)
                MessageBox.Show("Tuổi của nhân viên phải lớn hơn 18 !", "Có lỗi xảy ra !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtHoTenNV.Text != "" && txtMaNV.Text != "")
            {
                frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                frm.ShowDialog();
                NhanVien nv = new NhanVien();
                LayTTDoVaoBELNHanVien(nv);
                nv._maTK = frmTaoTaiKhoan.Instance.tkThemNV._maTK;
                if (balTK.ThemTaiKhoan(frmTaoTaiKhoan.Instance.tkThemNV) > 0)
                    if (balNV.ThemNhanVien(nv) > 0)
                        MessageBox.Show("Thêm nhân viên thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Họ&Tên,Mã NV mới không được để trống !", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            frMain.Instance.Grid.DataSource = balNV.DocNhanVien();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = balNV.LayMaNVMoi();
            List<string> NgauNhienTen = new List<string> { "Nguyễn","Trần","Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng", "Bùi", "Đỗ", "Hồ", "Ngô", "Dương", "Lý" };
            Random rand = new Random();
            txtHoTenNV.Text = NgauNhienTen[rand.Next(NgauNhienTen.Count)] +" "+ NgauNhienTen[rand.Next(NgauNhienTen.Count)];
            dtpNgaySinh.Value = new DateTime(rand.Next(1950,int.Parse(DateTime.Today.ToString("yyyy"))-18),1,1);
            radNu.Checked = true;
        }

        private void txtLuongCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;   //Ép không nhận ký tự gõ vào
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            LayTTDoVaoBELNHanVien(nv);
            if (balNV.CapNhatNhanVien(nv) > 0)
            {
                MessageBox.Show("Cập nhật thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lay hinh anh copy vo trong thu muc, nguon` o phia duoi'
                if (fileUpload.FileName != "")
                    File.Copy(fileUpload.FileName, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\NhanVien\\" + txtURL.Text);
            }
            frMain.Instance.Grid.DataSource = balNV.DocNhanVien();
        }

        OpenFileDialog fileUpload = new OpenFileDialog();
        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                fileUpload.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                if (fileUpload.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = fileUpload.FileName;
                    txtURL.Text = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf('\\')).Replace("\\", string.Empty);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
