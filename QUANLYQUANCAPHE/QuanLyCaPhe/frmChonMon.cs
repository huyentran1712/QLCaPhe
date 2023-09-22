using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaPhe
{
    public partial class frmChonThucDon : Form
    {
        SqlConnection conn;
 
        bool _chon = false;
        public frmChonThucDon()
        {
            InitializeComponent();
            LoadGrid("");
        }

        public void LoadGrid(string tukhoa)
        {
            conn = new SqlConnection(DB.ConnectString);
            conn.Open();

            gridThucDon.Rows.Clear();
            string sql = "SELECT MATHUCDON, TENTHUCDON, GIA FROM THUCDON WHERE MATHUCDON LIKE N'%" + tukhoa + "%' OR TENTHUCDON LIKE N'%" + tukhoa + "%' OR GIA LIKE N'%" + tukhoa + "%'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = gridThucDon.Rows.Add();
                DataGridViewRow drr = gridThucDon.Rows[i];
                drr.Cells["MATHUCDON"].Value = dr["MATHUCDON"];
                drr.Cells["TENTHUCDON"].Value = dr["TENTHUCDON"];
                drr.Cells["GIA"].Value = dr["GIA"];
            }
            dr.Close();

        }


        private void button4_Click(object sender, EventArgs e)
        {
                Close();
        }
        public DataGridView grid
        {
            get { return gridThucDon; }
            set { gridThucDon = value; }

        }
        public bool chon
        {
            get { return _chon; }
            set { _chon = value; }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            chon = true;
            Close();
        }


        private void txtTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "Bạn muốn tìm gì?")
                txtTim.Text = "";
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            //"Enter"
            if(e.KeyChar == 13)
            {
                LoadGrid(txtTim.Text);

            }
        }
    }
}
