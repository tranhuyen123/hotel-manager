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
    }
}
