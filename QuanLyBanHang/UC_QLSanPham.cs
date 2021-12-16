using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BAL;
using BEL;

namespace QuanLyBanHang
{
    public partial class UC_QLSanPham : UserControl
    {
        BAL_SanPham balSP = new BAL_SanPham();
        public UC_QLSanPham()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void UC_QLSanPham_Load(object sender, EventArgs e)
        {
            frMain.Instance.DangOpenGrid("QLSP");
            frMain.Instance.Grid.Columns.Clear();
            frMain.Instance.Grid.DataSource = balSP.DocSanPham();
            cboMaLoai.DataSource = balSP.DocLoaiSanPham();
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.SelectedIndex = 1;
            cboMaNCC.DataSource = balSP.DocNhaCungCap();
            cboMaNCC.DisplayMember = "TenNcc";
            cboMaNCC.ValueMember = "MaNcc";
            cboMaNCC.SelectedIndex = 6;
        }
        public void LoadInfo(int i)
        {
            txtMaSP.Text = frMain.Instance.Grid["MaSp", i].Value.ToString();
            txtTenSP.Text = frMain.Instance.Grid["TenSp", i].Value.ToString();
            txtMoTa.Text = frMain.Instance.Grid["MoTa", i].Value.ToString();
            txtSoLuong.Text = frMain.Instance.Grid["SoLuong", i].Value.ToString();
            string[] temp = frMain.Instance.Grid["GiaNhap", i].Value.ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 0)
                txtGiaNhap.Text = temp[0];
            temp = frMain.Instance.Grid["GiaBan", i].Value.ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 0)
                txtGiaBan.Text = temp[0];
            dtpNgayNhap.Value = DateTime.Parse(frMain.Instance.Grid["NgayNhap", i].Value.ToString());
            cboMaNCC.SelectedValue = frMain.Instance.Grid["MaNcc", i].Value.ToString();
            cboMaLoai.SelectedValue = frMain.Instance.Grid["Loai", i].Value.ToString();
            if (frMain.Instance.Grid["TrangThai", i].Value.ToString() == "True")
                radTrangThai1.Checked = true;
            if (frMain.Instance.Grid["TrangThai", i].Value.ToString() == "False")
                radTrangThai0.Checked = true;
            txtURL.Text = frMain.Instance.Grid["URL", i].Value.ToString();
            //2 cach deu dc
            //pictureBox1.Image = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\"+txtURL.Text);
            pictureBox1.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\" + txtURL.Text);
        }
        void LayTTDoVaoBELSanPham(SanPham sp)
        {
            sp._maSP = txtMaSP.Text;
            sp._tenSP = txtTenSP.Text;
            sp._moTa = txtMoTa.Text;
            sp._soLuong = int.Parse(txtSoLuong.Text);
            sp._giaNhap = int.Parse(txtGiaNhap.Text);
            sp._giaBan = int.Parse(txtGiaBan.Text);
            sp._ngayNhap = dtpNgayNhap.Value;
            sp._maNCC = cboMaNCC.SelectedValue.ToString();
            sp._loai = cboMaLoai.SelectedValue.ToString();
            if (radTrangThai0.Checked == true) sp._trangThai = false;
            else sp._trangThai = true;
            sp._uRL = txtURL.Text;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in frMain.Instance.Grid.Rows)
            {
                if (row.Cells["MaSp"].Value.ToString() == txtMaSP.Text)
                {
                    MessageBox.Show("Hãy tạo mới Mã SP !", "Có lỗi xảy ra !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (txtTenSP.Text != "" && txtMaSP.Text != "")
            {
                SanPham sp = new SanPham();
                LayTTDoVaoBELSanPham(sp);
                if (balSP.ThemSanPham(sp) > 0)
                    MessageBox.Show("Thêm Sản phẩm thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Tên SP,Mã SP mới không được để trống !", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            frMain.Instance.Grid.DataSource = balSP.DocSanPham();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            string maLoai = cboMaLoai.SelectedValue.ToString();
            string maNCC = cboMaNCC.SelectedValue.ToString();
            string stt = balSP.LayMaSPMoi(maLoai, maNCC);
            txtMaSP.Text = maLoai + "-" + maNCC + "-" + stt;
            txtTenSP.Text = cboMaLoai.Text + " " + cboMaNCC.Text + " " + stt;
            txtMoTa.Text = rand.Next(10).ToString() + " Năm";
            txtSoLuong.Text = rand.Next(100).ToString();
            txtGiaNhap.Text = rand.Next(1000000, 10000000).ToString();
            txtGiaBan.Text = rand.Next(int.Parse(txtGiaNhap.Text), int.Parse(txtGiaNhap.Text)+2000000).ToString();
            dtpNgayNhap.Value = new DateTime(rand.Next(1990, int.Parse(DateTime.Today.ToString("yyyy"))), 1, 1);
            radTrangThai0.Checked = true;
            List<string> urlArray = new List<string>();
            foreach (DataRow row in balSP.DocSanPham().Rows)
            {
                urlArray.Add(row["URL"].ToString());
            }
            txtURL.Text = urlArray[rand.Next(urlArray.Count)];
            //2 cach deu dc
            //pictureBox1.Image = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\"+txtURL.Text);
            pictureBox1.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\" + txtURL.Text);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            LayTTDoVaoBELSanPham(sp);

            if (balSP.CapNhatSanPham(sp) > 0)
            {
                MessageBox.Show("Cập nhật thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lay hinh anh copy vo trong thu muc, nguon` o phia duoi'
                if (fileUpload.FileName!="")
                File.Copy(fileUpload.FileName, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\image\\" + txtURL.Text);
            }
            frMain.Instance.Grid.DataSource = balSP.DocSanPham();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;   //Ép không nhận ký tự gõ vào
        }

        OpenFileDialog fileUpload = new OpenFileDialog();
        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                fileUpload.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                if (fileUpload.ShowDialog()==DialogResult.OK)
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
