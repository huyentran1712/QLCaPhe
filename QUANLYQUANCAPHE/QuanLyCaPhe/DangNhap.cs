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

namespace QuanLyCaPhe
{
    public partial class frm_dangNhap : Form
    {
        public frm_dangNhap()
        {
            InitializeComponent();
        }

        DB dulieu = new DB();
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string query = "Select*from TK where TENTK ='" + user + "'and PASS='" + pass + "'";
            if (dulieu.listAc(query).Count > 0)
            {
                if(chkNhanVien.Checked)
                {
                    MessageBox.Show("Đăng nhập tài kkhoản nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    this.Hide();
                    QLBH qlcf = new QLBH();
                    qlcf.ShowDialog();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập tài kkhoản khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    this.Hide();
                    QLBHKH qlcf = new QLBHKH();
                    qlcf.ShowDialog();
                }    
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !!!");
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Vui lòng nhập Username !!!");
            else
                this.errorProvider1.Clear();
        }

  
        private void txtPass_Leave(object sender, EventArgs e)
        {
            
            Control ctr = (Control)sender;
            
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider2.SetError(ctr, "Vui lòng nhập Password !!!");
            else
                this.errorProvider2.Clear();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
       
        }

        private void likDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_DangKy dk = new frm_DangKy();
            dk.ShowDialog();
            
        }

        private void frm_dangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
