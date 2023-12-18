using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DTO
{
    public class SanPham
    {
        public SanPham(int id, string ten, float gia)
        {
            this.ID = id;
            this.Name = ten;
            this.Gia = gia;
        }

        public SanPham(System.Data.DataRow row)
        {
            this.ID = (int)row[0];
            this.Name = row[2].ToString();
            this.Gia = (float)Convert.ToDouble(row[6].ToString());
        }

        private int iD;
        private string ten;
        private float gia;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => ten; set => ten = value; }
        public float Gia { get => gia; set => gia = value; }
    }
}
