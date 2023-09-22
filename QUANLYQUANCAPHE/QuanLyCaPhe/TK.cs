using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCaPhe
{
    public class TK
    {
        string userName;
        string passWord;
       // int quyen;

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        //public int Quyen { get => quyen; set => quyen = value; }

        public TK(string userName, string passWord)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            //this.quyen = quyen;
        }
        public TK(DataRow row)
        {
            this.UserName = row["TENTK"].ToString();
            this.PassWord = row["PASS"].ToString();
            //this.quyen = int.Parse(row["QUYEN"].ToString());
        }
    }
}
