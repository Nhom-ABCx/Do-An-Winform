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

using BAL;
using BEL;

namespace QuanLyBanHang
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
            fm = this;
        }
        BAL_HoaDon balHD = new BAL_HoaDon();
        BAL_SanPham balSP = new BAL_SanPham();
        public class DangMoGrid
        {
            public static bool CT_HD { get; set; }
            public static bool NV { get; set; }
            public static bool KH { get; set; }
            public static bool QLSP { get; set; }
            public static bool NCC { get; set; }
        }
        public void DangOpenGrid(string chuoi)
        {
            switch (chuoi)
            {
                case "ThongKe":
                    DangMoGrid.NV = false;
                    DangMoGrid.CT_HD = false;
                    DangMoGrid.KH = false;
                    DangMoGrid.QLSP = false;
                    DangMoGrid.NCC = false;
                    tableLayoutPanel1.Visible = false;
                    dataGridView1.Visible = false;
                    groupBox1.Visible = false;
                    ClosePanelUC(frMain.Instance.pnlUC2);
                    break;
                case "NCC":
                    DangMoGrid.NV = false;
                    DangMoGrid.CT_HD = false;
                    DangMoGrid.KH = false;
                    DangMoGrid.QLSP = false;
                    DangMoGrid.NCC = true;
                    tableLayoutPanel1.Visible = false;
                    dataGridView1.Visible = true;
                    groupBox1.Visible = false;
                    break;
                case "QLSP":
                    DangMoGrid.NV = false;
                    DangMoGrid.CT_HD = false;
                    DangMoGrid.KH = false;
                    DangMoGrid.QLSP = true;
                    DangMoGrid.NCC = false;
                    tableLayoutPanel1.Visible = false;
                    dataGridView1.Visible = true;
                    groupBox1.Visible = false;
                    break;
                case "KH":
                    DangMoGrid.NV = false;
                    DangMoGrid.CT_HD = false;
                    DangMoGrid.KH = true;
                    DangMoGrid.QLSP = false;
                    DangMoGrid.NCC = false;
                    tableLayoutPanel1.Visible = false;
                    dataGridView1.Visible = true;
                    groupBox1.Visible = false;
                    break;
                case "NV":
                    DangMoGrid.NV = true;
                    DangMoGrid.CT_HD = false;
                    DangMoGrid.KH = false;
                    DangMoGrid.QLSP = false;
                    DangMoGrid.NCC = false;
                    tableLayoutPanel1.Visible = false;
                    dataGridView1.Visible = true;
                    groupBox1.Visible = false;
                    break;
                case "CTHD":
                    DangMoGrid.NV = false;
                    DangMoGrid.CT_HD = true;
                    DangMoGrid.KH = false;
                    DangMoGrid.QLSP = false;
                    DangMoGrid.NCC = false;
                    tableLayoutPanel1.Visible = true;
                    dataGridView1.Visible = true;
                    groupBox1.Visible = true;
                    break;
                default:
                    break;
            }
        }
        //get set from de xai` cho UC
        static frMain fm;
        public static frMain Instance
        {
            get
            {
                if (fm == null)
                    fm = new frMain();
                return fm;
            }
        }
        public Panel pnlContain2 { get { return panelContain2; } set { panelContain2 = value; } }
        public Panel pnlUC1
        {
            get { return panelUC; }
            set { panelUC = value; }
        }
        public Panel pnlUC2
        {
            get { return panelUC2; }
            set { panelUC2 = value; }
        }
        public DataGridView Grid
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
        public ComboBox MaHDcbo
        {
            get { return cboMaHD; }
            set { cboMaHD = value; }
        }
        public TextBox TongTientxt
        {
            get { return txtTongTien; }
            set { txtTongTien = value; }
        }
        int gio, phut, giay;

        List<DataGridViewColumn> columnCT_HoaDon = new List<DataGridViewColumn>();
        public void LoadColumnGridCT_HoaDon()
        {
            dataGridView1.Columns.Clear();
            for (int i = 0; i < columnCT_HoaDon.Count; i++)
            {
                dataGridView1.Columns.Add(columnCT_HoaDon[i]);
            }
        }
        private void frMain_Load(object sender, EventArgs e)
        {
            DangOpenGrid("CTHD");
            //lay ra column da tao tu giao dien
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                columnCT_HoaDon.Add(this.dataGridView1.Columns[i].Clone() as DataGridViewColumn);
            }
            timer1.Start();
            timerOnline.Start();

            cboMaHD.Text = "001";
            cboMaHD.DataSource = balHD.DocHoaDon();
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";
            LoadData();
            cboTimKiem.AutoCompleteCustomSource = autoCompleteTenSP();
            cboTimKiem.DataSource = balSP.DocSanPham();
            cboTimKiem.DisplayMember = "TenSp";
            cboTimKiem.ValueMember = "MaSp";

            lblTenNhanVien.Text = Login.Instance.nhanVien._hotenNV.ToString();
            gio = phut = giay = 0;
            //cai nay` la tat' load luc dau`, phai click vo no moi hien
            ClosePanelUC(frMain.Instance.pnlUC2);
            tableLayoutPanel1.Visible = false;
            dataGridView1.Visible = false;
            groupBox1.Visible = false;
        }
        public void LoadData() //load cai chi tiet hoa don
        {
            //load datagridview
            if (this.dataGridView1.DataSource != null)
                this.dataGridView1.DataSource = null;
            else
                this.dataGridView1.Rows.Clear();
            txtTongTien.Text = balHD.LoadTTHoaDon(cboMaHD.Text, dataGridView1, grpHD);
        }

        public void OpenUserControl(UserControl uc, Panel pn)
        {
            if (!pn.Controls.Contains(uc))
            {
                pn.Visible = true;
                pn.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront(); //cho cai usercontrol no xuat hien len dau`
            }
            else
                pn.Controls.Clear(); //cai nay ko bao h duoc chay, cha biet vi sao
        }
        public void ClosePanelUC(Panel pn)
        {
            pn.Controls.Clear();
            pn.Visible = false; //an? UC
        }
        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            UC_QuanLy uc = new UC_QuanLy();
            OpenUserControl(uc, panelUC);
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            UC_TuyChon uc = new UC_TuyChon();
            OpenUserControl(uc, panelUC);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            BAL_TaiKhoan balTK = new BAL_TaiKhoan();
            Login.Instance.ngayLamViec._gioKT = DateTime.Now;
            if (balTK.KetThucNgayLam(Login.Instance.nhanVien, Login.Instance.ngayLamViec) > 0)
                Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //show time
            txtTime.Text = DateTime.Now.ToString("dddd  |  dd/MM/yyyy   |   hh:mm:ss tt");
        }
        private void timerOnline_Tick(object sender, EventArgs e)
        {
            //tinh thoi gian lam viec
            giay += 1;
            if (giay == 60)
            { giay = 0; phut += 1; }
            if (phut == 60)
            { phut = 0; gio += 1; }
            lblOnline.Text = gio.ToString() + ":" + phut.ToString() + ":" + giay.ToString();

        }

        private void btnENTER_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
            UC_HoaDon.Instance.LoadInfo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            if (DangMoGrid.CT_HD)
            {
                UC_SanPham uc = new UC_SanPham();
                OpenUserControl(uc, panelUC2);
                uc.SoLuongBantxt.Text = dataGridView1["SoLuong", i].Value.ToString();
                DataTable dt = balSP.DocSanPham(dataGridView1["MaSanpham", i].Value.ToString());
                //hoac la xai` cach nay
                //DataGridViewRow r = frMain.Instance.Grid.CurrentRow;
                //DataTable dt = balSP.DocMaSP(r.Cells["MaSanpham"].Value.ToString());
                foreach (DataRow row in balHD.DocTTct_HoaDon(cboMaHD.Text).Rows)
                {
                    string[] temp = row["GiaGiam"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length > 0)
                        uc.GiaGiamtxt.Text = temp[0];
                    uc.ChietKhautxt.Text = row["ChietKhau"].ToString();
                }

                uc.LoadInfo(dt);
            }
            if (DangMoGrid.NV)
            {
                UC_NhanVien uc = new UC_NhanVien();
                OpenUserControl(uc, panelUC2);
                uc.LoadInfo(i);
            }
            if (DangMoGrid.KH)
            {
                UC_KhachHang uc = new UC_KhachHang();
                OpenUserControl(uc, panelUC2);
                uc.LoadInfo(i);
            }
            if (DangMoGrid.QLSP)
            {
                UC_QLSanPham uc = new UC_QLSanPham();
                OpenUserControl(uc, panelUC2);
                uc.LoadInfo(i);
            }
            if (DangMoGrid.NCC)
            {
                UC_NhaCungCap uc = new UC_NhaCungCap();
                OpenUserControl(uc, panelUC2);
                uc.LoadInfo(i);
            }
        }
        public AutoCompleteStringCollection autoCompleteTenSP() //tham khao tren mang
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            // use databse
            foreach (DataRow row in balSP.DocTenSanPham().Rows)
            {
                acsc.Add(row[0].ToString());
            }
            return acsc;
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UC_SanPham uc = new UC_SanPham();
            OpenUserControl(uc, panelUC2);
            DataTable dt = balSP.DocSanPham(cboTimKiem.SelectedValue.ToString());
            uc.LoadInfo(dt);

            uc.GiaGiamtxt.Text = "0";
            uc.ChietKhautxt.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (balHD.TrangThaiHD(cboMaHD.Text) == true)
                MessageBox.Show("Hóa đơn này đã được thanh toán không thêm vào được !", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["MaSanpham"].Value.ToString() == cboTimKiem.SelectedValue.ToString())
                    {
                        MessageBox.Show("Thêm sp thất bại, tên sp da có sẵn", "Thất bại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (balHD.ThemCT_HoaDon(cboMaHD.Text, cboTimKiem.SelectedValue.ToString(), int.Parse(UC_SanPham.Instance.SoLuongBantxt.Text), int.Parse(UC_SanPham.Instance.GiaGiamtxt.Text), int.Parse(UC_SanPham.Instance.ChietKhautxt.Text)) > 0)
                    MessageBox.Show("Thêm sp thành công", "Thành công !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
    }
}
