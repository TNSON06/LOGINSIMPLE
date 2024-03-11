using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class LOGIN : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBLL TaiKhoanBLL = new TaiKhoanBLL();
        public LOGIN()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.sTaiKhoan = txtTaiKhoan.Text;
            taikhoan.sMatKhau = txtMatKhau.Text;
            string getuser = TaiKhoanBLL.CheckLogin(taikhoan);
            switch (getuser)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Tai khoan khong duoc de trong");
                    return;
                case "requeid_password":
                    MessageBox.Show("Mat khau khong duoc de trong");
                    return;
                case "Tai khoan hoặc mật khẩu không chính xác":
                    MessageBox.Show("Tai khoan hoặc mật khẩu không chính xác");
                    return;

            }
            MessageBox.Show("Xin chuc mung ban da dang nhap thanh cong");
        }
    }
}
