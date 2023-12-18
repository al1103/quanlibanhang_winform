using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DTO
{
    public class NhaPhanPhoi
    {
        public NhaPhanPhoi(int id, string ten, string diachi, string sdt)
        {
            this.ID = id;
            this.Name = ten;
            this.Diachi = diachi;
            this.Sdt = sdt;
        }

        public NhaPhanPhoi(System.Data.DataRow row)
        {
            this.ID = (int)row[0];
            this.Name = row[1].ToString();
            this.Diachi = row[2].ToString();
            this.Sdt = row[3].ToString();
        }

        private int iD;
        private string ten;
        private string diachi;
        private string sdt;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => ten; set => ten = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
