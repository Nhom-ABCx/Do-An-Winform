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
    public partial class UC_NhaCungCap : UserControl
    {
        BAL_NhaCungCap balNCC = new BAL_NhaCungCap();
        public UC_NhaCungCap()
        {
            InitializeComponent();
        }
        private void UC_NhaCungCap_Load(object sender, EventArgs e)
        {
            frMain.Instance.DangOpenGrid("NCC");
            frMain.Instance.Grid.Columns.Clear();
            frMain.Instance.Grid.DataSource = balNCC.DocNhaCungCap();

        }
        public void LoadInfo(int i)
        {
            txtMaNCC.Text = frMain.Instance.Grid["MaNcc", i].Value.ToString();
            txtTenNCC.Text = frMain.Instance.Grid["TenNcc", i].Value.ToString();
            txtDiaChi.Text = frMain.Instance.Grid["Diachi", i].Value.ToString();
            txtPhone.Text = frMain.Instance.Grid["Phone", i].Value.ToString();
            txtEMail.Text = frMain.Instance.Grid["eMail", i].Value.ToString();
        }
        void LayTTDoVaoBELNhaCungCap(NhaCungCap ncc)
        {
            ncc._maNcc = txtMaNCC.Text;
            ncc._tenNcc = txtTenNCC.Text;
            ncc._diaChi = txtDiaChi.Text;
            ncc._phone = txtPhone.Text;
            ncc._email = txtEMail.Text;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in frMain.Instance.Grid.Rows)
            {
                if (row.Cells["MaNcc"].Value.ToString() == txtMaNCC.Text)
                {
                    MessageBox.Show("Hãy tạo mới Mã nhà cung cấp !", "Có lỗi xảy ra !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (txtTenNCC.Text != "" && txtMaNCC.Text != "")
            {
                NhaCungCap ncc = new NhaCungCap();
                LayTTDoVaoBELNhaCungCap(ncc);
                if (balNCC.ThemNhaCungCap(ncc) > 0)
                    MessageBox.Show("Thêm Nhà cung cấp thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Tên SP,Mã SP mới không được để trống !", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            frMain.Instance.Grid.DataSource = balNCC.DocNhaCungCap();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            LayTTDoVaoBELNhaCungCap(ncc);

            if (balNCC.CapNhatNhaCungCap(ncc) > 0)
                MessageBox.Show("Cập nhật thành công !", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frMain.Instance.Grid.DataSource = balNCC.DocNhaCungCap();
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;   //Ép không nhận ký tự gõ vào
        }
    }
}
