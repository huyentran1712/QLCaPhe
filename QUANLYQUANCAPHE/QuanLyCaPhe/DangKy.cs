using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace QuanLyCaPhe
{
    public partial class frm_DangKy : Form
    {
        public frm_DangKy()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)
        {
            if (ac.Length <= 4)
                return false;
            return true;
        }
        DB db = new DB();

        private void btnSignUn_Click(object sender, EventArgs e)
        {
            string user = txtUser_DK.Text;
            string pass = txtPass_DK.Text;
            string cfp = txtCfP_DK.Text;
            if (checkAccount(user) == false)
            {
                MessageBox.Show("Tên tài khoản không được ít hơn 4 ký tự");
                return;
            }
            if (checkAccount(pass) == false)
            {
                MessageBox.Show("Tên mật khẩu không được ít hơn 4 ký tự");
                return;
            }
            if (cfp != pass)
            {
                MessageBox.Show("Mật khẩu không khớp!!!");
                return;
            }
            try
            {
                string query = "Insert into TK values ('" + user + "','" + pass + "')";
                db.Comand(query);
                MessageBox.Show("Đăng ký thành công");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tài khoản này đã được đăng ký", "Thông báo");
            }
        }
    }
}
