using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan.GUI.Controls
{
    public partial class LapHoaDon : Form
    {
        public LapHoaDon()
        {
            InitializeComponent();
            setCbbPhong();
            setKH();
            setNV();
        }
        private static object _savelock = new object();
        private List<string> lstDV = new List<string>();
        private List<string> lstPhong = new List<string>();
        private List<decimal> lstGiaDV = new List<decimal>();
        private List<decimal> lstGiaPhong = new List<decimal>();
        private double sum = 0;
        string tenphong;
        string tenKH;
        string tenNV;
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();

        List<string> getAllPhong()
        {
            List<string> p = new List<string>();
            p = db.PHONGs.Where(x => x.TrangThai.Contains("Đã ở")).Select(x => x.SoPhong).ToList();
            return p;
        }
        private void setCbbPhong()
        {
            List<string> P = getAllPhong();
            foreach (string temp1 in P)
            {
                comboBoxPhong.Items.Add(temp1);
            }
        }
        List<string> getKH()
        {
            List<string> p = new List<string>();
            p = db.KHACHHANGs.Select(x => x.TenKH).ToList();
            return p;
        }
        private void setKH()
        {
            List<string> P = getKH();
            foreach (string temp1 in P)
            {
                comboBoxKH.Items.Add(temp1);
            }
        }
        List<string> getNV()
        {
            List<string> p = new List<string>();
            p = db.NHANVIENs.Select(x => x.HoTenNV).ToList() ;
            return p;
        }
        private void setNV()
        {
            List<string> P = getNV();
            foreach (string temp1 in P)
            {
                comboBoxNV.Items.Add(temp1);
            }
        }
        private void themHD()
        {
            tenphong = comboBoxPhong.SelectedItem.ToString();
            var result = (from sdp in db.PHIEUTHUEPHONGs
                          join p in db.PHONGs on sdp.MaPhong equals p.MaPhong
                          where p.SoPhong == tenphong
                          select new
                          {
                              mp = sdp.MaPhong,
                          }
                          ).FirstOrDefault();
            tenKH = comboBoxKH.SelectedItem.ToString();
            var ABC = (from kh in db.KHACHHANGs
                       join sdp in db.PHIEUTHUEPHONGs on kh.MaKH equals sdp.MaKH
                       where kh.TenKH==tenKH
                       select new
                       {
                           mkh = sdp.MaKH,
                           ptp=sdp.NgayNhan,
                          
                       }
                       ).FirstOrDefault();
            tenNV = comboBoxNV.SelectedItem.ToString();
            var result1 = (from nv in db.NHANVIENs
                      
                       where nv.HoTenNV == tenNV
                       select new
                       {
                           mnv = nv.MaNV,

                       }
                       ).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(comboBoxPhong.ValueMember))
            {
                var newHD = new HOADON()
                {
                    MaHD = textBoxMaHD.Text,
                    MaKH = ABC.mkh,
                    MaNV = result1.mnv,
                    NgayLap = DateTime.Now,
                   // TongTien = Convert.ToDecimal(_DoiSoSangDonViTienTe(sum)),



                };
                db.HOADONs.AddOrUpdate(newHD);
                var newCTHD = new CHITIETHD()
                {
                    MaHD=textBoxMaHD.Text,
                    MaPhong=result.mp,
                    GiamGia=Int32.Parse(textBoxGG.Text),
                    NgayNhan=ABC.ptp,
                    NgayTra=DateTime.Now,
                    SoNgay=Int32.Parse(textBoxSoNgay.Text),
                 //   ThanhTien= Convert.ToDecimal(_DoiSoSangDonViTienTe(sum)),

                };
               
                db.CHITIETHDs.AddOrUpdate(newCTHD);

                db.SaveChanges();
            }

        }
        private void inHD()
        {
            tenphong = comboBoxPhong.SelectedItem.ToString();
            tenKH = comboBoxKH.SelectedItem.ToString();
            tenNV = comboBoxNV.SelectedItem.ToString();
            var ASD = (from sdp in db.PHIEUTHUEPHONGs
                      
                    
                       join hd in db.HOADONs on sdp.MaKH equals hd.MaKH
                       join nv in db.NHANVIENs on hd.MaNV equals nv.MaNV
                       join kh in db.KHACHHANGs on hd.MaKH equals kh.MaKH

                       join cthd in db.CHITIETHDs on hd.MaHD equals cthd.MaHD
                       join p in db.PHONGs on sdp.MaPhong equals p.MaPhong
                       join lp in db.LOAIPHONGs on p.MaLoaiPhong equals lp.MaLoaiPhong
                       where p.TrangThai.Contains("Đã ở")  && kh.TenKH==tenKH
                       select new
                       {
                           mhd=hd.MaHD,
                           giamgia=cthd.GiamGia,
                           maphong = p.MaPhong,
                          
                        
                           SoNgay= cthd.SoNgay,
                           GiaPhong = lp.GiaPhong
                       }).ToList();
            var result2 = (from sdv in db.DICHVU_SD
                           join dv in db.DICHVUs on sdv.MaDV equals dv.MaDV
                           join tp in db.PHIEUTHUEPHONGs on sdv.MaPhong equals tp.MaPhong
                           join kh in db.KHACHHANGs on tp.MaKH equals kh.MaKH
                          
                           join p in db.PHONGs on tp.MaPhong equals p.MaPhong 
                           where  p.TrangThai.Contains("Đã ở") && kh.TenKH == tenKH
                           select new
                           {
                              
                               TenDichVu = dv.TenDV,
                               madv=sdv.MaDV,
                               
                               SOLUONG = sdv.SoLuong,
                               GiaDV = dv.GiaDV,
                           }
                          ).ToList();
            int j = 1;
            foreach (var temp in ASD)
            {
                lstPhong.Add((tenphong).ToString());
                lstGiaPhong.Add(Convert.ToDecimal(temp.GiaPhong));
                dataGridViewThongKe.Rows.Add((j++).ToString(),temp.maphong,null,temp.mhd,tenNV,tenKH,tenphong,temp.giamgia,null,null,null,temp.SoNgay,temp.GiaPhong,(temp.SoNgay * temp.GiaPhong ) - Convert.ToDecimal(temp.giamgia));
                sum += Convert.ToDouble((temp.SoNgay * temp.GiaPhong) - Convert.ToDecimal(temp.giamgia));
            }
            j = 1;
            foreach (var temp in result2)
            {
                lstDV.Add(temp.TenDichVu);
                lstGiaDV.Add(Convert.ToDecimal(temp.GiaDV));
                dataGridViewThongKe.Rows.Add(++j,null,temp.madv,null,null,null,null,null, temp.TenDichVu, temp.SOLUONG, temp.GiaDV, null, null,  temp.GiaDV * temp.SOLUONG);
                sum += Convert.ToDouble(temp.GiaDV * temp.SOLUONG);
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

        private void button1_Click(object sender, EventArgs e)
        {
           dataGridViewThongKe.Rows.Clear();
            themHD();
            inHD();
           

            comboBoxPhong.SelectedIndex = -1;
            comboBoxNV.SelectedIndex = -1;
            comboBoxKH.SelectedIndex = -1;
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
                string top = "Tên phòng".PadRight(24) + "Thành Tiền";
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

        private void buttonInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    tenphong = comboBoxPhong.SelectedItem.ToString();
                    var phong = (from p in db.PHONGs where p.SoPhong.Equals(tenphong) select p).FirstOrDefault();
                    phong.TrangThai = "Trống";
                    string id = labelMP.Text;
                    string id1 = labelDV.Text;
                    db.DICHVU_SD.Remove(db.DICHVU_SD.Find(id, id1));
                    

                    var newHD = new HOADON()
                    {

                        TongTien = Convert.ToDecimal(_DoiSoSangDonViTienTe(sum)),



                    };
                    db.HOADONs.AddOrUpdate(newHD);


                



                    db.SaveChanges();
                }
                catch(Exception)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LapHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerNS_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        int index;
        private void dataGridViewThongKe_Clicl(object sender, EventArgs e)
        {

        }

        private void dataGridViewThongKe_Click(object sender, EventArgs e)
        {
            index = dataGridViewThongKe.CurrentRow.Index;

            string mp = dataGridViewThongKe.Rows[index].Cells[1].Value.ToString();
            var dv = (from p in db.DICHVU_SD where p.MaPhong.Equals(mp) select p).FirstOrDefault();
            labelMP.Text = dv.MaPhong.ToString();

            string mdv = dataGridViewThongKe.Rows[index].Cells[2].Value.ToString();
            var dv1 = (from p in db.DICHVU_SD where p.MaDV.Equals(mdv) select p).FirstOrDefault();
            labelDV.Text = dv.MaDV.ToString();

            


        }
    }
}
