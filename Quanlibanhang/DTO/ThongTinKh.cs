using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DTO
{
    public class ThongTinKh
    {
        public ThongTinKh(int id, string ten, string sodienthoai)
        {
            this.ID = id;
            this.Name = ten;
            this.Sodienthoai = sodienthoai;
        }

        public ThongTinKh(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["ten"].ToString();
            this.Sodienthoai = row["sodienthoai"].ToString();
        }

        private int iD;
        private string ten;
        private string sodienthoai;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => ten; set => ten = value; }
        public string Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
    }

}
