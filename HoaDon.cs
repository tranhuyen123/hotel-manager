using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;
using System.Globalization;
using System.IO;
using System.Drawing.Printing;

namespace QLKhachSan.GUI.Controls
{
    public partial class HoaDon : Form
    {
        private static object _savelock = new object();
        private QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
        private List<string> lstDV = new List<string>();
        private List<string> lstPhong = new List<string>();
        private List<decimal> lstGiaDV = new List<decimal>();
        private List<decimal> lstGiaPhong = new List<decimal>();
        private double sum = 0;
        public HoaDon()
        {
            InitializeComponent();
        }

        private KHACHHANG checkExist(string sdt)
        {
            var isExist = db.KHACHHANGs.Where(x => x.SDT.Equals(sdt)).FirstOrDefault();
            if (isExist != null)
                return isExist;
            return null;
        }

        private void search(KHACHHANG data)
        {
            dgvThongTinThanhToan.Rows.Clear();
            dgvThongTinThanhToan.Refresh();
            lblTenKhach.Text = data.TenKH;
            lblDiaChi.Text = data.DiaChi;
            var result1 = (from sdp in db.PHIEUTHUEPHONGs
                           join p in db.PHONGs on sdp.MaPhong equals p.MaPhong
                           join lp in db.LOAIPHONGs on p.MaLoaiPhong equals lp.MaLoaiPhong
                           where sdp.MaKH == data.MaKH && p.TrangThai.Contains("Trống")
                           select new
                           {
                               MaPhong = p.MaPhong,
                               LoaiPhong = lp.TenLoaiPhong,
                               NgaySD = sdp.NgayNhan,
                               GiaPhong =lp.GiaPhong
                               ,
                           }
                          ).ToList();
            var result2 = (from sdv in db.DICHVU_SD
                           join dv in db.DICHVUs on sdv.MaDV equals dv.MaDV
                           join tp in db.PHIEUTHUEPHONGs on sdv.MaPhong equals tp.MaPhong
                           where tp.MaKH == data.MaKH 
                           select new
                           {
                               MaDichVu = dv.MaDV,
                               TenDichVu = dv.TenDV,
                               //NgaySD = tp.NgayNhan,
                               GiaDV = sdv.TongTien,
                           }
                           ).ToList();
            int i = 0;
            foreach (var temp in result1)
            {
                lstPhong.Add((temp.MaPhong).ToString());
                lstGiaPhong.Add(Convert.ToDecimal(temp.GiaPhong));
                dgvThongTinThanhToan.Rows.Add(++i, null, null, temp.MaPhong, temp.LoaiPhong, temp.NgaySD.Value.ToString
                    ("dd/M/yyyy", CultureInfo.InvariantCulture), temp.GiaPhong);
                sum += Convert.ToDouble(temp.GiaPhong);
            }
            i = 0;
            foreach (var temp in result2)
            {
                lstDV.Add(temp.TenDichVu);
                lstGiaDV.Add(Convert.ToDecimal(temp.GiaDV));
                dgvThongTinThanhToan.Rows.Add(++i, temp.MaDichVu, temp.TenDichVu, null, null, null, temp.GiaDV);
                sum += Convert.ToDouble(temp.GiaDV);
            }
            lblTongTien.Text = _DoiSoSangDonViTienTe(sum);
        }

        public static string _DoiSoSangDonViTienTe(object _object)
        {
            try
            {
                if (_object.ToString().Trim().Length == 0)
                { return " "; }

                if (_object.ToString() == "0")
                {
                    return "0,000";
                }

                decimal dThanhTien = Convert.ToDecimal(_object);
                string strThanhTien = string.Format("{0:#,#.}", dThanhTien);
                return strThanhTien;
            }
            catch (Exception)
            {

            }
            return "0.000";
        }

       

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10)
            {
                string sdt = txtSDT.Text.Trim();
                KHACHHANG data = checkExist(sdt);
                if (data != null)
                {
                    lblTenKhach.Text = data.TenKH;
                    lblDiaChi.Text = data.DiaChi;
                    search(data);
                }
                else
                {
                    MessageBox.Show("Không có khách hàng này !");
                    ActiveControl = txtSDT;
                }
            }
        }

       
        
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            KHACHHANG data = checkExist(sdt);
            if (data != null)
            {
                search(data);
            }
            else
            {
                MessageBox.Show("Không có khách hàng này !");
                ActiveControl = txtSDT;
            }
        }

       
    }
}