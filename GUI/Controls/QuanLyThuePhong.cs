using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.GUI.Controls;
using QLKhachSan.Model;
using System.Data.Entity.Migrations;

namespace QLKhachSan.GUI.Controls
{
    public partial class QuanLyThuePhong :Form
    {
        private QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
        private static List<string> Selected = new List<string>();
      

        public QuanLyThuePhong()
        {
            InitializeComponent();
            setCbbDichVu();
            setCbbKH();
           // HienThiDanhSach();
         
        }
        List<string> getAllLP()
        {
            List<string> lp = new List<string>();
            lp = db.LOAIPHONGs.Select(x => x.TenLoaiPhong).ToList();
            return lp;
        }
        private void setCbbDichVu()
        {
            List<string> dV = getAllLP();
            foreach (string temp in dV)
            {
                comboBoxLP.Items.Add(temp);
            }
        }
        List<string> getKH()
        {
            List<string> KH = new List<string>();
            KH = db.KHACHHANGs.Select(x => x.TenKH).ToList();
            return KH;
        }
        private void setCbbKH()
        {
            List<string> kh = getKH();
            foreach (string temp in kh)
            {
                comboBoxKH.Items.Add(temp);
            }
        }
        public void HienThiDanhSach()
        {
            listViewLP.Items.Clear();
            int stt = 1;
            var lstPhongThue = (from phong in db.PHONGs
                                join lp in db.LOAIPHONGs on phong.MaLoaiPhong equals lp.MaLoaiPhong
                               
                                 where phong.TrangThai.Contains("Trống") && lp.TenLoaiPhong.Contains(comboBoxLP.Text)
                                select new
                                {
                                    MAPHONG=phong.MaPhong,
                                    TENPHONG=phong.SoPhong,
                                    GIA=lp.GiaPhong,
                                    SONGUOI=lp.SoNgToiDa,
                                    
                                }).ToList();
            foreach (var phongThue in lstPhongThue)
            {
                string[] row =
                    {
                            stt.ToString(), phongThue.MAPHONG, phongThue.TENPHONG.ToString(), phongThue.GIA.ToString(),
                            phongThue.SONGUOI.ToString()
                        };
                ListViewItem item = new ListViewItem(row);
                stt++;
                listViewLP.Items.Add(item);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();

        }

        void loadDataToGridView(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from p in db.PHONGs
                             join sd in db.PHIEUTHUEPHONGs on p.MaPhong equals sd.MaPhong
                             join kh in db.KHACHHANGs on sd.MaKH equals kh.MaKH
                            // join hd in db.HOADONs on kh.MaKH equals hd.MaKH
                             where p.TrangThai.Contains("Đã ở")
                             select new
                             {
                                 maPhong = p.MaPhong,
                                 maKH = sd.MaKH,
                                 diaChi = kh.DiaChi,
                                 tenPhong = p.SoPhong,
                                 ngayThue = sd.NgayNhan,
                                 tenKH = kh.TenKH,
                               //  trangThai = p.TrangThai,
                             };
   
                var results = query.ToList();
                dtgv.DataSource = results;



            }
           

        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {

        }

       
       
       
        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            QuanLyKhachHang themKhachHang = new QuanLyKhachHang();
            themKhachHang.ShowDialog();
        }
        string tenKH;
     
       
      
        private void btnThuePhong_Click_1(object sender, EventArgs e)
        {
            tenKH = comboBoxKH.SelectedItem.ToString();
            var result=(from kh in db.KHACHHANGs
                       
                        where kh.TenKH == tenKH
                        select new
                        {
                            mkh = kh.MaKH,
                           

                        }
                       ).FirstOrDefault();
                
            PHIEUTHUEPHONG sd = new PHIEUTHUEPHONG()
                {
                        MaPhieu = textBoxMaPhieu.Text,
                        MaPhong = txtMaPhong.Text,
                        MaKH = result.mkh,
                        NgayNhan = DateTime.Now
                    };
                    db.PHIEUTHUEPHONGs.Add(sd);
            if (db.PHIEUTHUEPHONGs.Select(p => p.MaPhieu).Contains(textBoxMaPhieu.Text))
            {
                MessageBox.Show("Mã phiếu đã tồn tại");
                return;

            }

                   string MaPhong = txtMaPhong.Text;
                   var phong = (from p in db.PHONGs where p.MaPhong.Equals(MaPhong) select p).FirstOrDefault();
                   phong.TrangThai = "Đã ở";
                   db.PHONGs.AddOrUpdate(phong);

            
                       
                       
                    
                   db.SaveChanges();
                   
                    MessageBox.Show("Thêm thành công !");
                    loadDataToGridView(dgvThuePhong);
        }
                
            
        int index;
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuanLyThue_Load(object sender, EventArgs e)
        {
            loadDataToGridView(dgvThuePhong);
        }

        private void dgvThuePhong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvThuePhong.CurrentRow.Index;
           
            comboBoxKH.Text = dgvThuePhong.Rows[index].Cells[1].Value.ToString();

          
            txtMaPhong.Text = dgvThuePhong.Rows[index].Cells[3].Value.ToString();
           
            dateTimePicker1.Text = dgvThuePhong.Rows[index].Cells[5].Value.ToString();
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }

}
