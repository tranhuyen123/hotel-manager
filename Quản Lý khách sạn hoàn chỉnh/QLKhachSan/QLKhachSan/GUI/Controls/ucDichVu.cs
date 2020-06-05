using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using QLKhachSan.Model;
using System.Data.Entity.Migrations;

namespace QLKhachSan.GUI.Controls
{
    public partial class ucDichVu : Form
    {
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();

        string tenphong;
        string tendv;

        public ucDichVu()
        {
            InitializeComponent();
            setCbbPhong();
            setCbbSoLuong();
            setCbbDichVu();

        }

        List<string> getAllPhong()
        {
            List<string> p = new List<string>();
            p = db.PHONGs.Where(x => x.TrangThai.Equals("Đã ở")).Select(x => x.SoPhong).ToList();
            return p;
        }
        private void setCbbPhong()
        {
            List<string> P = getAllPhong();
            foreach (string temp1 in P)
            {
                cbbPhong.Items.Add(temp1);
            }
        }

        List<string> getAllDichVu()
        {
            List<string> dv = new List<string>();
            dv = db.DICHVUs.Select(x => x.TenDV).ToList();
            return dv;
        }
        private void setCbbDichVu()
        {
            List<string> dV = getAllDichVu();
            foreach (string temp in dV)
            {
                cbbDichVu.Items.Add(temp);
            }
        }

        private void setCbbSoLuong()
        {
            int i = 1;
            for (; i < 10; i++)
            {
                cbbSoLuong.Items.Add(i.ToString());
            }
        }

        private void themDV()
        {
            tenphong = cbbPhong.SelectedItem.ToString();
            var result = (from sdp in db.PHIEUTHUEPHONGs
                          join p in db.PHONGs on sdp.MaPhong equals p.MaPhong
                          where p.SoPhong == tenphong
                          select new
                          {
                              mkh = sdp.MaPhong
                          }
                          ).FirstOrDefault();
            tendv = cbbDichVu.SelectedItem.ToString();
            var ABC = (from dv in db.DICHVUs
                       where dv.TenDV == tendv
                       select new
                       {
                           mdv = dv.MaDV
                       }
                       ).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(cbbPhong.ValueMember))
            {
                var newSDDV = new DICHVU_SD()
                {
                    MaDV = ABC.mdv,
                    MaPhong= result.mkh,
                   
                    SoLuong = Convert.ToInt16(cbbSoLuong.SelectedItem),

                };
                db.DICHVU_SD.AddOrUpdate(newSDDV);
               
                db.SaveChanges();
            }
        }

        private void inDichVu()
        {
            tenphong = cbbPhong.SelectedItem.ToString();
            tendv = cbbDichVu.SelectedItem.ToString();
            var ASD = (from dv in db.DICHVUs
                       join sddv in db.DICHVU_SD on dv.MaDV equals sddv.MaDV
                       where dv.TenDV == tendv
                       select new
                       {
                           sl = sddv.SoLuong,
                           giadv = dv.GiaDV
                       }).ToList();
            int j = 1;
            foreach (var temp in ASD)
            {
                dgvThongKe.Rows.Add((j++).ToString(), tenphong, tendv, temp.sl, temp.giadv * temp.sl);
            }
        }

        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            dgvThongKe.Rows.Clear();
            themDV();
            inDichVu();
            cbbPhong.SelectedIndex = -1;
            cbbDichVu.SelectedIndex = -1;
            cbbSoLuong.SelectedIndex = -1;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            tenphong = cbbPhong.SelectedItem.ToString();
            var result = (from sdp in db.PHIEUTHUEPHONGs
                          join p in db.PHONGs on sdp.MaPhong equals p.MaPhong
                          where p.SoPhong == tenphong
                          select new
                          {
                              mkh = sdp.MaPhong
                          }
                          ).FirstOrDefault();
            var newSDDV = new DICHVU_SD()
            {
               
                MaPhong = result.mkh,

                

            };
            db.DICHVU_SD.Remove(newSDDV);

            db.SaveChanges();
        }
        void LoadNV(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from p in db.DICHVU_SD
                             join dv in db.DICHVUs on p.MaDV equals dv.MaDV
                           
                             join lp in db.PHONGs on p.MaPhong equals lp.MaPhong
                           
                             select new
                             {
                                SoPhong = lp.SoPhong,
                                TenDV = dv.TenDV,
                                SoLuong = p.SoLuong,
                                giaDV= dv.GiaDV,
                                

                             };

                var results = query.ToList();
                dtgv.DataSource = results;



            }
            
        }
        private void ucDichVu_Load(object sender, EventArgs e)
        {
            //LoadNV(dgvThongKe);
        }

        private void dgvThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int index;
        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvThongKe.CurrentRow.Index;
            cbbPhong.Text = dgvThongKe.Rows[index].Cells[1].Value.ToString();
            cbbDichVu.Text = dgvThongKe.Rows[index].Cells[2].Value.ToString();
            cbbSoLuong.Text = dgvThongKe.Rows[index].Cells[3].Value.ToString();
           

        }
    }
}
