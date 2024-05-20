using Quanlibanhang.DAO;
using Quanlibanhang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class QuanLi : Form
    {
        public QuanLi()
        {
            InitializeComponent();
            LoadViewNhanVien();
            LoadViewKhachHang();
            LoadNhaPhanPhoi();
            LoadViewHangHoa();
            LoadViewNhaPhanPhoi();
            LoadViewHoaDon();
            LoadNameKH();
            LoadSanPham();
            LoadViewChiTietHoaDon();
            LoadViewNhapDonHang();
            LoadNhaPhanPhoiNhap();
            LoadNhanVienNhap();
            LoadMaSP();
            loadDonHang();
            LoadRandomID();


        }
        int index = -1;
        public void LoadViewNhanVien()
        {
            string query = "select * from NhanVien";
            dtgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);


        }
        public void LoadViewKhachHang()
        {
            string query = "select * from KhachHang";
            dtgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        public void LoadViewHangHoa()
        {
            string query = "select * from HangHoa";
            dtgvHangHoa.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public void LoadViewNhaPhanPhoi()
        {
            string query = "select * from NhaPhanPhoi";
            dtgvNhaPhanPhoi.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public void LoadViewHoaDon()
        {
            List<ThongTinNV> thongTinNVs = ThongTinNVDAO.Instance.GetListThongTinNV();

            cbbTNVHD.DisplayMember = "Name";
            cbbTNVHD.DataSource = thongTinNVs;


        }
        float GiaSPN = 0;
        public void LoadMaSP()
        {
            List<SanPham> thongTinSPs = SanPhamDAO.Instance.GetListSanPham();
            CBBMSPHDN.DisplayMember = "ID";
            CBBMSPHDN.ValueMember = "ID"; // Optional, set ValueMember if you need to get the selected ID
            CBBMSPHDN.DataSource = thongTinSPs;
           

        }

        public void LoadIDNV(int id)
        {
            txtIDNVHD.Text = id.ToString();

        }
        public void LoadSDTKH(int Sodienthoai)
        {
            txtIDKHHD.Text = Sodienthoai.ToString();
        }
        public void LoadNameKH()
        {
            List<ThongTinKh> thongTinKhs = ThongTinKHDAO.Instance.GetListKh();

            cbbTKHHD.DisplayMember = "Name";
            cbbTKHHD.DataSource = thongTinKhs;



        }
        public void LoadSanPham()
        {
            List<SanPham> thongTinSPs = SanPhamDAO.Instance.GetListSanPham();
            CBBMSP.DisplayMember = "ID";
            CBBMSP.DataSource = thongTinSPs;

        }
        public void LoadNameSP(string Name)
        {
            TXTTSPP.Text = Name.ToString();
        }
        public void LoadGiaSP(float Gia)
        {
            TXTGSP.Text = Gia.ToString();
        }
        public void LoadTongTienSP(float Gia)
        {
            TXTTOTALSP.Text = (Gia * float.Parse(TXTSLSP.Text)).ToString();

        }




        public void loadDonHang()
        {
            string query = "select * from DonHang";
            dtgvDonHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }







        public void LoadRandomID()
        {
            string randomId = GenerateRandomString(7); // Adjust the length as needed
            txtIDHDB.Text = randomId;
            txtIDHDN.Text = randomId;
        }

        public void LoadViewChiTietHoaDon()
        {
            // Generate a random string of length less than 8 characters for txtIDHDB


            // Load data from ChiTietDonHang into DataGridView
            string query = "SELECT * FROM ChiTietDonHang";
            dtgvChiTietHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);

            // Calculate total value from the thanhTien column
            string totalQuery = "SELECT SUM(thanhTien) AS TotalValue FROM ChiTietDonHang";
            DataTable totalResult = DataProvider.Instance.ExecuteQuery(totalQuery);

            if (totalResult.Rows.Count > 0 && totalResult.Rows[0]["TotalValue"] != DBNull.Value)
            {
                TXTTOTALALL.Text = totalResult.Rows[0]["TotalValue"].ToString();
            }
            else
            {
                TXTTOTALALL.Text = "0";
            }
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            // Create a random string by selecting characters from the chars string
            string randomString = new string(Enumerable.Range(1, length)
                .Select(_ => chars[random.Next(chars.Length)]).ToArray());

            return randomString;
        }


        public void LoadViewNhapDonHang()
        {
            string query = "select * from ChiTietDonHangNhap";
            dtgvNhapDonHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public void LoadNhaPhanPhoi()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbNhaPhanPhoi.DisplayMember = "Name";
            cbNhaPhanPhoi.DataSource = listCategory;
        }


        private void btnADDNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string query = "INSERT INTO NhanVien VALUES ('" + txtMaNV.Text + "', N'" + txtTenNV.Text + "', N'" + txtDiaChi.Text + "', '" + txtSDT.Text + "')";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewNhanVien();
            }
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNV.Text = dtgvNhanVien.Rows[index].Cells[0].Value.ToString();
                txtTenNV.Text = dtgvNhanVien.Rows[index].Cells[1].Value.ToString();
                txtDiaChi.Text = dtgvNhanVien.Rows[index].Cells[2].Value.ToString();
                txtSDT.Text = dtgvNhanVien.Rows[index].Cells[3].Value.ToString();
            }
        }

        private void btnEDITNV_Click(object sender, EventArgs e)
        {
            index = dtgvNhanVien.CurrentCell.RowIndex + 1;
            if (index >= 0)
            {
                string query = "UPDATE NhanVien SET Ten = N'" + txtTenNV.Text + "', diachi = N'" + txtDiaChi.Text + "', soDienThoai = '" + txtSDT.Text + "' WHERE ID = '" + txtMaNV.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewNhanVien();
            }
        }

        private void btnDELETENV_Click(object sender, EventArgs e)
        {
            index = dtgvNhanVien.CurrentCell.RowIndex + 1;
            if (index >= 0)
            {
                string query = "DELETE FROM NhanVien WHERE ID = '" + txtMaNV.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewNhanVien();
            }
        }

        private void btnADDKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChiKH.Text == "" || txtSDTKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string query = "INSERT INTO KhachHang VALUES ('" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', N'" + txtDiaChiKH.Text + "', '" + txtSDTKH.Text + "')";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewKhachHang();
            }
        }

        private void btnEDITKH_Click(object sender, EventArgs e)
        {
            index = dtgvKhachHang.CurrentCell.RowIndex + 1;
            if (index >= 0)
            {
                string query = "UPDATE KhachHang SET Ten = N'" + txtTenKH.Text + "', diachi = N'" + txtDiaChiKH.Text + "', soDienThoai = '" + txtSDTKH.Text + "' WHERE ID = '" + txtMaKH.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewKhachHang();
            }
        }

        private void btnDELETEKH_Click(object sender, EventArgs e)
        {
            index = dtgvKhachHang.CurrentCell.RowIndex + 1;
            if (index >= 0)
            {
                string query = "DELETE FROM KhachHang WHERE ID = '" + txtMaKH.Text + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewKhachHang();
            }
        }

        private void LoadNhaPhanPhoiNhap()
        {
            List<NhaPhanPhoi> nhaPhanPhois = NhaPhanPhoiDAO.Instance.GetListNhaPhanPhoi();
            cbbTNPPHDN.DisplayMember = "Name";
            cbbTNPPHDN.DataSource = nhaPhanPhois;

        }
        private void LoadNhanVienNhap()
        {
            List<ThongTinNV> thongTinNVs = ThongTinNVDAO.Instance.GetListThongTinNV();
            cbbNVHDN.DisplayMember = "Name";
            cbbNVHDN.DataSource = thongTinNVs;
        }


        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NhanVien WHERE Ten LIKE N'%" + txtSearchNV.Text + "%'";
            dtgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        private void btnSearchKH_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM KhachHang WHERE Ten LIKE N'%" + txtSearchKH.Text + "%'";
            dtgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnSearchHH_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM HangHoa WHERE Ten LIKE N'%" + txtSearchHH.Text + "%'";
            dtgvHangHoa.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void cbbTNVHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            ThongTinNV selected = cb.SelectedItem as ThongTinNV;
            id = selected.ID;
            LoadIDNV(id);
        }

        private void cbbTKHHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ThongTinKh selected = cb.SelectedItem as ThongTinKh;
            int Sodienthoai = selected.ID;
            LoadSDTKH(Sodienthoai);
        }
        float GiaSP = 0;
        private void CBBMSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            SanPham selected = cb.SelectedItem as SanPham;
            string Name = selected.Name;
             GiaSP = selected.Gia;
            LoadNameSP(Name);
            LoadGiaSP(selected.Gia);
            LoadTongTienSP(selected.Gia);
            

        }

        private void TXTSLSP_ValueChanged(object sender, EventArgs e)
        {
            LoadTongTienSP(GiaSP); 
        }

        private void btnAddDSHD_Click(object sender, EventArgs e)
        {
            string dates = dtpHD.Value.ToString("yyyy-MM-dd");
            string query = "INSERT INTO ChiTietDonHang ([donHangID], [NhanVienID], [KhachHangID], [Date], [hangHoaID], [soLuong], [donGia], [thanhTien])" +
               "VALUES ( '" + txtIDHDB.Text + "','" + txtIDNVHD.Text + "', '" + txtIDKHHD.Text + "', '" + dates + "', '" + CBBMSP.Text + "', '" + TXTSLSP.Text + "', '" + TXTGSP.Text + "', '" + TXTTOTALSP.Text + "')";
            dtgvChiTietHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
            LoadViewChiTietHoaDon();

        }

        private void btnDELETESPHH_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM ChiTietDonHang WHERE ID = '" + selectedRowID + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadViewChiTietHoaDon();

        }
        int selectedRowID;
        private void dtgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedRowID = Convert.ToInt32(dtgvChiTietHoaDon.Rows[index].Cells[0].Value.ToString());

                txtIDNVHD.Text = dtgvChiTietHoaDon.Rows[index].Cells[2].Value.ToString();
                txtIDKHHD.Text = dtgvChiTietHoaDon.Rows[index].Cells[3].Value.ToString();

                if (DateTime.TryParse(dtgvChiTietHoaDon.Rows[index].Cells[5].Value.ToString(), out DateTime dateValue))
                {
                    dtpHD.Value = dateValue;
                }
                CBBMSP.Text = dtgvChiTietHoaDon.Rows[index].Cells[5].Value.ToString();
                TXTSLSP.Text = dtgvChiTietHoaDon.Rows[index].Cells[6].Value.ToString();
                TXTGSP.Text = dtgvChiTietHoaDon.Rows[index].Cells[7].Value.ToString();
                TXTTOTALSP.Text = dtgvChiTietHoaDon.Rows[index].Cells[8].Value.ToString();

            }

        }

        private void btnEDITSPHH_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ChiTietDonHang SET donHangID =  NhanVienID = '" + txtIDNVHD.Text + "', KhachHangID = '" + txtIDKHHD.Text + "', Date = '" + dtpHD.Value.ToString("yyyy-MM-dd") + "', hangHoaID = '" + CBBMSP.Text + "', soLuong = '" + TXTSLSP.Text + "', donGia = '" + TXTGSP.Text + "', thanhTien = '" + TXTTOTALSP.Text + "' WHERE ID = '" + selectedRowID + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadViewChiTietHoaDon();

        }

        private void btnREFRESHSPHH_Click(object sender, EventArgs e)
        {
            TXTSLSP.Text = "";
            TXTTOTALSP.Text = "";
            TXTGSP.Text = "";
            TXTTSPP.Text = "";
            CBBMSP.Text = "";

        }

        private void btnEditHDN_Click(object sender, EventArgs e)
        {
            string dates = dtpHD.Value.ToString("yyyy-MM-dd");
            string query = "UPDATE ChiTietDonHangNhap SET donHangID = '" + txtIDHDN.Text + "', NhanVienID = '" + txtIDNVHD.Text + "', NhaPhanPhoiID = '" + txtIDNCC.Text + "', Date = '" + dates + "', hangHoaID = '" + CBBMSP.Text + "', soLuong = '" + TXTSLSP.Text + "', donGia = '" + TXTGSP.Text + "', thanhTien = '" + TXTTOTALSP.Text + "' WHERE ID = '" + selectedRowID + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadViewChiTietHoaDon();
            MessageBox.Show(query);
        }

        private void btnADDHDN_Click(object sender, EventArgs e)
        {
            if (txtIDHDN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            else
            {
                string dates = dtpHDN.Value.ToString("yyyy-MM-dd");
                string query = "INSERT INTO ChiTietDonHangNhap ([donHangID], [NhanVienID], [NhaPhanPhoiID], [Date], [hangHoaID], [soLuong], [donGia], [thanhTien])" +
                   "VALUES ( '" + txtIDHDN.Text + "','" + txtIDNVHDN.Text + "', '" + txtIDNCC.Text + "', '" + dates + "', '" + CBBMSPHDN.Text + "', '" + TXTSLHDN.Text + "', '" + txtDGHDN.Text + "', '" + TXTGHDN.Text + "')";
                DataProvider.Instance.ExecuteNonQuery(query);
                LoadViewNhapDonHang();
            }

        }

        private void cbbTNPPHDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            NhaPhanPhoi selected = cb.SelectedItem as NhaPhanPhoi;
            int id = selected.ID;
            txtIDNCC.Text = id.ToString();

        }

        private void cbbNVHDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ThongTinNV selected = cb.SelectedItem as ThongTinNV;
            int id = selected.ID;
            txtIDNVHDN.Text = id.ToString();

        }
        float GiaSPHDN = 0;
        private void CBBMSPHDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            SanPham selected = cb.SelectedItem as SanPham;
            string Name = selected.Name;
            txtTSP.Text = Name;
            GiaSPHDN = selected.Gia;
            txtDGHDN.Text = selected.Gia.ToString(); 
            LoadTongTienHDN(GiaSPHDN);


        }
        private void LoadTongTienHDN(float Gia)
        {
            TXTGHDN.Text = (Gia * float.Parse(TXTSLHDN.Text)).ToString();
        }

        private void TXTSLHDN_ValueChanged(object sender, EventArgs e)
        {
            LoadTongTienHDN(GiaSP);
        }

        private void btnDELETEHDN_Click(object sender, EventArgs e)
        {


            string query = "DELETE FROM ChiTietDonHangNhap WHERE ID = '" + selectedRowID
 + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadViewNhapDonHang();

        }

        private void dtgvNhapDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedRowID = Convert.ToInt32(dtgvNhapDonHang.Rows[index].Cells[0].Value.ToString());
                txtIDHDN.Text = dtgvNhapDonHang.Rows[index].Cells[1].Value.ToString();
                txtIDNVHDN.Text = dtgvNhapDonHang.Rows[index].Cells[2].Value.ToString();
                txtIDNCC.Text = dtgvNhapDonHang.Rows[index].Cells[3].Value.ToString();

                if (DateTime.TryParse(dtgvNhapDonHang.Rows[index].Cells[5].Value.ToString(), out DateTime dateValue))
                {
                    dtpHDN.Value = dateValue;
                }
                CBBMSPHDN.Text = dtgvNhapDonHang.Rows[index].Cells[5].Value.ToString();
                TXTSLHDN.Text = dtgvNhapDonHang.Rows[index].Cells[6].Value.ToString();
                TXTGHDN.Text = dtgvNhapDonHang.Rows[index].Cells[7].Value.ToString();
                TXTTOTALHDN.Text = dtgvNhapDonHang.Rows[index].Cells[8].Value.ToString();

            }
        }

        private void btnREFRESHHDN_Click(object sender, EventArgs e)
        {
            txtIDHDN.Text = "";
            txtIDNVHDN.Text = "";
            txtIDNCC.Text = "";
            txtTSP.Text = "";
            TXTSLHDN.Text = "";
            TXTGHDN.Text = "";
            TXTTOTALHDN.Text = "";
            CBBMSPHDN.Text = "";
            txtDGHDN.Text = "";
            cbbNVHDN.Text = "";
            cbbTNPPHDN.Text = "";
        }

        private void btnCHECKDT_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpSTART.Value;
            DateTime endDate = dtpEND.Value;

            string queryDonHang = $"SELECT SUM(tongtien) AS TotalTongTien FROM DonHang WHERE [ngayLap] BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}' AND Kieu = 'Bán' GROUP BY MaHD";
            string queryChiTietDonHang = $"SELECT SUM(thanhTien) AS ThanhTien, SUM(soLuong) AS SoLuongSP, COUNT(*) AS SoSp FROM ChiTietDonHang WHERE [Date] BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}'";

            DataTable resultDonHangTable = DataProvider.Instance.ExecuteQuery(queryDonHang);
            DataTable resultChiTietDonHangTable = DataProvider.Instance.ExecuteQuery(queryChiTietDonHang);

            // Handling DonHang data
            if (resultDonHangTable != null && resultDonHangTable.Rows.Count > 0)
            {
                DataRow donHangRow = resultDonHangTable.Rows[0];
                txtTongtienBan.Text = donHangRow["TotalTongTien"].ToString();
            }
            else
            {
                txtTongtienBan.Text = "0";
            }

            // Handling ChiTietDonHang data
            if (resultChiTietDonHangTable != null && resultChiTietDonHangTable.Rows.Count > 0)
            {
                DataRow chiTietDonHangRow = resultChiTietDonHangTable.Rows[0];
                txtTongSP.Text = chiTietDonHangRow["SoLuongSP"].ToString();
                txtSOSP.Text = chiTietDonHangRow["SoSp"].ToString();
            }
            else
            {
                txtTongSP.Text = "0";
                txtSOSP.Text = "0";
            }

            LoadViewChiTietHoaDon();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO DonHang VALUES ('" + txtIDHDB.Text + "', '" + dtpHD.Value.ToString("yyyy-MM-dd") + "', '" + TXTTOTALALL.Text + "', 'Bán')";

            MessageBox.Show(query);
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadRandomID();
            loadDonHang();

        }

        private void btnSaveNHAP_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO DonHang VALUES ('" + txtIDHDN.Text + "', '" + dtpHDN.Value.ToString("yyyy-MM-dd") + "', '" + TXTTOTALHDN.Text + "', 'Nhập')";

            MessageBox.Show(query);
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadRandomID();
            loadDonHang();
        }

        private void btnSearchDH_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM DonHang WHERE MaHD LIKE N'%" + textSearchDH.Text + "%'";
            dtgvDonHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
            loadDonHang();
        }

        private void btnDeleteDH_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM DonHang WHERE MaHD = '" + indexDH.ToString() + "'";
            DataProvider.Instance.ExecuteNonQuery(query);
            loadDonHang();

        }
        int indexDH = -1;
        private void dtgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDH = e.RowIndex;

        }
    }
}
