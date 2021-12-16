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

namespace QuanLyBanHang
{
    public partial class UC_ThanhToan : UserControl
    {
        public UC_ThanhToan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frMain.Instance.ClosePanelUC(frMain.Instance.pnlUC2);
        }

        private void UC_ThanhToan_Load(object sender, EventArgs e)
        {
            txtTongTT.Text = frMain.Instance.TongTientxt.Text;
            cboHinhThucTT.Items.Add("Tiền mặt");
            cboHinhThucTT.Items.Add("MOMO");
            cboHinhThucTT.Items.Add("Viettel Pay");
            cboHinhThucTT.Items.Add("Internet Banking");
            cboHinhThucTT.SelectedIndex = 0;
            cboLoaiTien.Items.Add("VNĐ");
            cboLoaiTien.Items.Add("USD");
            cboLoaiTien.SelectedIndex = 0;
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhachDua.Text == "")
                txtTienKhachDua.Text = "0";
            txtTienTraLai.Text = (long.Parse(txtTongTT.Text.Replace(",", string.Empty)) - long.Parse(txtTienKhachDua.Text)).ToString();
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;   //Ép không nhận ký tự gõ vào
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAL_HoaDon balHD = new BAL_HoaDon();
            if (txtTongTT.Text == "0")
                MessageBox.Show("Không có sản phẩm, hãy thêm SP !", "Có lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (balHD.ThanhToanHD(frMain.Instance.MaHDcbo.Text) > 0)
            {
                MessageBox.Show("Thanh toán thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frMain.Instance.MaHDcbo.DataSource = balHD.DocHoaDon();
            }
        }
    }
}
