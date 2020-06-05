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
                           where sdp.MaKH == data.MaKH && p.TrangThai.Contains("Đã ở")
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
                               SOLUONG=sdv.SoLuong,
                               GiaDV = dv.GiaDV,
                           }
                           ).ToList();
          
            int i = 0;
            foreach (var temp in result1)
            {
                lstPhong.Add((temp.MaPhong).ToString());
                lstGiaPhong.Add(Convert.ToDecimal(temp.GiaPhong));
                dgvThongTinThanhToan.Rows.Add(++i, null, null,null,null, temp.MaPhong, temp.LoaiPhong, temp.NgaySD.Value.ToString
                    ("dd/M/yyyy", CultureInfo.InvariantCulture), temp.GiaPhong);
                sum += Convert.ToDouble(temp.GiaPhong);
            }
            i = 0;
            foreach (var temp in result2)
            {
                lstDV.Add(temp.TenDichVu);
                lstGiaDV.Add(Convert.ToDecimal(temp.GiaDV));
                dgvThongTinThanhToan.Rows.Add(++i, temp.MaDichVu, temp.TenDichVu, temp.SOLUONG,temp.GiaDV, null,null,null,temp.GiaDV *temp.SOLUONG);
                sum += Convert.ToDouble(temp.GiaDV*temp.SOLUONG);
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

       
        private void _CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12);
            float FontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Hóa đơn thanh toán", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            int index = 0;
            if (lstPhong.Count >= 1)
            {
                string top = "Mã phòng".PadRight(24) + "Thành Tiền";
                graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)FontHeight; //make the spacing consistent
                graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)FontHeight + 5; //make the spacing consistent

                foreach (string item in lstPhong)
                {
                    graphic.DrawString(item, font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(lstGiaPhong[index++].ToString(), font, new SolidBrush(Color.Black), startX + 250, startY + offset);
                    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
                }

                offset = offset + 20; //make some room so that the total stands out.
            }

            if (lstDV.Count >= 1)
            {
                string top1 = "Tên dịch vụ".PadRight(24) + "Thành Tiền";
                graphic.DrawString(top1, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)FontHeight; //make the spacing consistent
                graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)FontHeight + 5; //make the spacing consistent

                index = 0;
                foreach (string item in lstDV)
                {
                    graphic.DrawString(item, font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(lstGiaDV[index++].ToString(), font, new SolidBrush(Color.Black), startX + 250, startY + offset);
                    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
                }

                offset = offset + 20; //make some room so that the total stands out.
            }

            graphic.DrawString("TỔNG TIỀN TRẢ ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(_DoiSoSangDonViTienTe(sum), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("TIỀN MẶT ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(_DoiSoSangDonViTienTe(txtTienTra.Text.Trim()), font, new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("TIỀN DƯ ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(_DoiSoSangDonViTienTe((sum - Convert.ToDouble(txtTienTra.Text.Trim()))), font, new SolidBrush(Color.Black), startX + 250, startY + offset);

            offset = offset + 20; //make some room so that the total stands out.

            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString(" CẢM ƠN BẠN ĐÃ GHÉ THĂM!,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("HI VỌNG BẠN SẼ GHÉ THĂM LẠI!", font, new SolidBrush(Color.Black), startX, startY + offset);
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

        private void btnInHoaDon_Click_1(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var isExist = db.KHACHHANGs.Where(x => x.SDT.Equals(txtSDT.Text.Trim())).FirstOrDefault();

                    var sdp = db.PHIEUTHUEPHONGs.Where(x => x.MaKH.Equals(isExist.MaKH)).FirstOrDefault();

                    if (sdp != null)
                    {
                        var phong = db.PHONGs.Where(x => x.MaPhong.Equals(sdp.MaPhong)).FirstOrDefault();
                        phong.TrangThai = "Trống";
                    }

                    //var sdv = db.PHIEUTHUEPHONGs.Where(x => x.MaKH.Equals(isExist.MaKH)).FirstOrDefault();
                    //if (sdv != null)
                    //    sdv.TRANGTHAI = 1;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                PrintDialog _PrintDialog = new PrintDialog();
                PrintDocument _PrintDocument = new PrintDocument();

                _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

                _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                DialogResult result = _PrintDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _PrintDocument.Print();
                }
            }
            catch (Exception)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTienTra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}