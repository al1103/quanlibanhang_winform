using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }

        private SanPhamDAO() { }

        public List<DTO.SanPham> GetListSanPham()
        {
            List<DTO.SanPham> list = new List<DTO.SanPham>();

            string query = "SELECT * FROM HangHoa";

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (System.Data.DataRow item in data.Rows)
            {
                DTO.SanPham sanpham = new DTO.SanPham(item);
                list.Add(sanpham);
            }

            return list;
        }

        public bool InsertSanPham(string ten, int idloai, int soluong, float gia)
        {
            string query = string.Format("INSERT INTO HangHoa (ten, idloai, soluong, gia) VALUES (N'{0}', {1}, {2}, {3})", ten, idloai, soluong, gia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateSanPham(int id, string ten, int idloai, int soluong, float gia)
        {
            string query = string.Format("UPDATE HangHoa SET ten = N'{0}', idloai = {1}, soluong = {2}, gia = {3} WHERE id = {4}", ten, idloai, soluong, gia, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteSanPham(int id)
        {
            string query = string.Format("DELETE FROM HangHoa WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        
    }
}
