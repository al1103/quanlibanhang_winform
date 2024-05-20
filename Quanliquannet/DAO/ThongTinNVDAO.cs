using Quanlibanhang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DAO
{
    public class ThongTinNVDAO
    {
        private static ThongTinNVDAO instance;

        public static ThongTinNVDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThongTinNVDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private ThongTinNVDAO() { }
        public List<ThongTinNV> GetListThongTinNV()
        {
            List<ThongTinNV> list = new List<ThongTinNV>();
            string query = "SELECT id, ten FROM NhanVien";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinNV thongTinNV = new ThongTinNV(item);
                list.Add(thongTinNV);
            }
            return list;
        }
    }
}
