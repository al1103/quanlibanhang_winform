using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DAO
{
    public class ThongTinKHDAO
    {
        private static ThongTinKHDAO instance;

        public static ThongTinKHDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ThongTinKHDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private ThongTinKHDAO() { }

        public List<DTO.ThongTinKh> GetListKh()
        {
            List<DTO.ThongTinKh> list = new List<DTO.ThongTinKh>();

            string query = "select id , ten , sodienthoai from khachhang";

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (System.Data.DataRow item in data.Rows)
            {
                DTO.ThongTinKh kh = new DTO.ThongTinKh(item);
                list.Add(kh);
            }
            return list;
        }

       
    }
}
