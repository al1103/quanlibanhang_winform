using Quanlibanhang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlibanhang.DAO
{
    public class NhaPhanPhoiDAO
    {
        private static NhaPhanPhoiDAO instance;

        public static NhaPhanPhoiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhaPhanPhoiDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private NhaPhanPhoiDAO() { }

        public List<NhaPhanPhoi> GetListNhaPhanPhoi()
        {
            List<NhaPhanPhoi> list = new List<NhaPhanPhoi>();

            string query = "select * from NhaPhanPhoi";

            System.Data.DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (System.Data.DataRow item in data.Rows)
            {
                NhaPhanPhoi npp = new NhaPhanPhoi(item);
                list.Add(npp);
            }
            return list;
        }
    }
}
