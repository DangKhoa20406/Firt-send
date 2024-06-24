using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22204003_VoLeDangKhoa
{
        public static class thongtinNgDung
        {
            public static string vaitro { get; set; }
        }
    public partial class frmLogin : Form
    {
        Connection conn = new Connection();
        public frmLogin()
        {
            InitializeComponent();
        }


        public void DangNhap()
        {
            string phanQuyen = $"select Quyen from TaiKhoan where TenDangNhap = '{txtuserName.Text}' and MatKhau = '{txtpassword.Text}'";
            object rs = conn.CheckedQuery(phanQuyen);
            if (rs != null)
            {
                string vaitro = rs.ToString();
                if (vaitro == "Admin")
                {
                    thongtinNgDung.vaitro = vaitro;
                    if (conn.ExcuteQuery(phanQuyen) < 0)
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền Admin");
                        frmQLLKDT qLLKDT = new frmQLLKDT();
                        qLLKDT.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show($"Đăng nhập thành công với quyền {vaitro}");
                    // Xử lý cho các vai trò khác
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }

        }

        private void thongtinNguoiDUng(string vaitro)
        {
            throw new NotImplementedException();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string pass = $"select COUNT(*) from TaiKhoan where MatKhau = '{txtpassword.Text}'";
            int rs = (int)conn.CheckedQuery(pass);
            bool flag = false;
            if (txtuserName.Text == "")
            {
                lblwarring.Text = "User name đang trống";
                flag = false;
            }if(txtpassword.Text == "")
            {
                lblwarring.Text = "Password đang trống";
                flag = false;
            }
            else
            {
                if (rs > 0)
                {
                    DangNhap();
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc tài khoản không đúng");
                    flag = false;
                }
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(null, null);
            }
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
     }
}

