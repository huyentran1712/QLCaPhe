using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCaPhe
{
    public class DB
    {
        DataSet dt = new DataSet();
        SqlCommand cmd;//dung de truy van cac cau lenh 
        SqlDataReader dtr;//dung de doc du lieu trong bang
        public static string ConnectString = "Data Source=HUYENTRAN;Initial Catalog=QL_QUANCF_CNNET;Integrated Security=True";
        public static SqlConnection GetTK()
        {
            return new SqlConnection(ConnectString);
        }
        static DB ins;



        public static DB Ins
        {
            get { if (ins == null) ins = new DB(); return DB.ins; }
            set => DB.ins = value;
        }

        public List<TK> listAc(string query)
        {

            List<TK> ac = new List<TK>();
            using (SqlConnection sqlConec = GetTK())
            {
                sqlConec.Open();
                cmd = new SqlCommand(query, sqlConec);
                dtr = cmd.ExecuteReader();
                while (dtr.Read())
                {
                    ac.Add(new TK(dtr.GetString(0), dtr.GetString(1)));

                }

                sqlConec.Close();
            }
            return ac;
        }
        public void Comand(string query)
        {
            using (SqlConnection sqlconec = GetTK())
            {
                sqlconec.Open();
                cmd = new SqlCommand(query, sqlconec);
                cmd.ExecuteNonQuery();//thuc thi cau truy van
                sqlconec.Close();
            }
        }
        public DataTable executeQuery(string query, object[] parameter = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectString))
            {
                //Thực hiện kết nối đến DB

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);// Thuc thi cau lenh query

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);//Tao adapter để đổ dữ liệu về DataSource

                sqlDataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }


            return dataTable;
        }

        public int executeNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectString))
            {
                //Thực hiện kết nối đến DB

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);// Thuc thi cau lenh query

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            return data;
        }

        public object executeScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectString))
            {
                //Thực hiện kết nối đến DB

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);// Thuc thi cau lenh query

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteScalar();

                sqlConnection.Close();
            }


            return data;
        }

    }
}
