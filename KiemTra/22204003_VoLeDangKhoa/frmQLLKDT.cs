using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22204003_VoLeDangKhoa
{
    public partial class frmQLLKDT : Form
    {
        Connection conn = new Connection();
        public frmQLLKDT()
        {
            InitializeComponent();
            this.Load += frmQLLKDT_Load;
        }

        private void frmQLLKDT_Load(object sender, EventArgs e)
        {
            string combox = "select MaNCC, TenNCC from NhaCungCap";
            DataTable dt = conn.GetData(combox);
            cboNhaCC.DataSource = dt;
            cboNhaCC.ValueMember = "MaNCC";
            cboNhaCC.DisplayMember = "TenNCC";

            string query = "select MaLK[Mã linh kiện],TenLK[Tên linh kiện], ThongSoKyThuat[Thông số kỹ thuật], DonGia[Đơn giá], MaNCC[Nhà cung cấp] from LinhKien";
            dgvDanhSachLKDT.DataSource = conn.GetData(query);

            lblXinChao.Text = $"Xin chào {thongtinNgDung.vaitro}";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void frmQLLKDT_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel);
            if (e.KeyCode == Keys.Escape)
            {
                if (rs == DialogResult.OK)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        btnThoat_Click(null, null);
                    }
                }
            }
        }

        private void dgvDanhSachLKDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaLK.Text = dgvDanhSachLKDT.Rows[i].Cells[0].Value.ToString().Trim();
            txtTenLK.Text = dgvDanhSachLKDT.Rows[i].Cells[1].Value.ToString().Trim();
            txtDonGia.Text = dgvDanhSachLKDT.Rows[i].Cells[2].Value.ToString().Trim();
            txtThongSoKT.Text = dgvDanhSachLKDT.Rows[i].Cells[3].Value.ToString().Trim();
            cboNhaCC.SelectedValue = dgvDanhSachLKDT.Rows[i].Cells[4].Value.ToString().Trim();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDonGia.Text = txtMaLK.Text = txtTenLK.Text = txtThongSoKT.Text = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string Malk = txtMaLK.Text;
            string tenlk = txtTenLK.Text;
            string ttkt = txtThongSoKT.Text;
            string mancc = cboNhaCC.SelectedValue.ToString();
            string donGia = txtDonGia.Text;
            string query = $"insert into LinhKien (MaLK,TenLK,ThongSoKyThuat,DonGia,MaNCC) values ({Malk},N'{tenlk}',N'{ttkt}',{donGia}, {mancc})";
            if(conn.ExcuteQuery(query)  >0)
            {
                MessageBox.Show("Thêm thành công");
                frmQLLKDT_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void frmQLLKDT_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String malk = txtMaLK.Text;
            string query = $"delete from LinhKien where MaLK = {malk}";
            if(conn.ExcuteQuery(query) > 0)
            {

                MessageBox.Show("Thành công");
                frmQLLKDT_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Malk = txtMaLK.Text;
            string tenlk = txtTenLK.Text;
            string ttkt = txtThongSoKT.Text;
            string mancc = cboNhaCC.SelectedValue.ToString();
            string donGia = txtDonGia.Text;
            string query = $"update LinhKien set MaLK = {Malk},TenLK = N'{tenlk}',ThongSoKyThuat = N'{ttkt}' ,DonGia = {donGia} ,MaNCC = {mancc} where MaLK = {Malk}";
            if (conn.ExcuteQuery(query) > 0)
            {

                MessageBox.Show("Thành công");
                frmQLLKDT_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void btnThoat_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel);
            if (rs == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
