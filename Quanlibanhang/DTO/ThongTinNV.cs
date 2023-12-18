using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DTO
{
    public class ThongTinNV
    {
        public ThongTinNV(int id, string ten)
        {
            this.ID = id;
            this.Name = ten;
        }

        public ThongTinNV(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["ten"].ToString();
        }

        private int iD;
        private string ten;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => ten; set => ten = value; }
    }
}
