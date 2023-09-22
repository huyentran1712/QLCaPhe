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
    
    public partial class FormPhieuXuat : Form
    {

        public FormPhieuXuat()
        {
            InitializeComponent();
        }
        public void load()
        {
            SqlConnection conn = new SqlConnection(DB.ConnectString);
            try
            {
                conn.Open();
                string sql = "Select * from PHIEUXUAT";
                SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
        }
        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DB.ConnectString);
            conn.Open();
            string sqlThem = "insert  into PHIEUXUAT values (@MaPX ,@NgayXuat ,@MaNV ,@MaKH ,@TongTien)";
            SqlCommand cmd = new SqlCommand(sqlThem, conn);
            cmd.Parameters.AddWithValue("MAPX", txtMaPX.Text);
            cmd.Parameters.AddWithValue("NGAYXUAT", txtNgayXuat.Text);
            cmd.Parameters.AddWithValue("MANV", txtMaNV.Text);
            cmd.Parameters.AddWithValue("MAKH", txtMaKH.Text);
            cmd.Parameters.AddWithValue("TONGTIEN", txtTongTien.Text);
            int kp = (int)cmd.ExecuteNonQuery();
            if (kp > 0)
            {
                MessageBox.Show("Thêm thành công");
                load();
            }
            else
                MessageBox.Show("Thêm thất bại");
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(DB.ConnectString);

                conn.Open();
                string sql = "delete from PHIEUXUAT where MAPX='" + txtMaPX.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                load();
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DB.ConnectString);
            try
            {
                conn.Open();
                string sql = "Update PHIEUXUAT set NGAYXUAT= '" + txtNgayXuat.Text + "' , MANV=N'" + txtMaNV.Text + "', MAKH=N'" + txtMaKH.Text + "', TONGTIEN='" + txtTongTien.Text + "' where MAPX= '" + txtMaPX.Text + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kp = (int)cmd.ExecuteNonQuery();
                if (kp > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    load();
                }
                else
                    MessageBox.Show("Sửa thất bại");

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            txtMaPX.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNgayXuat.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMaNV.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMaKH.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
