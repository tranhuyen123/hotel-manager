using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;
namespace QLKhachSan.GUI.Controls
{
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        void LoadKH(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from kh in db.KHACHHANGs
                            select new
                            {
                                Mã_KH = kh.MaKH,
                                Tên_KH = kh.TenKH,
                                SĐT = kh.SDT,
                                CMND = kh.CMND,
                                Địa_Chỉ = kh.DiaChi,
                                Giới_Tính = kh.GioiTinh,

                            };
                var result = query.ToList();
                dtgv.DataSource = result;

            }
            BindingKH(dataGridViewKH);
           
        }
        void BindingKH(DataGridView dtgv)
        {
            Binding bdMa = new Binding("text", dtgv.DataSource, "Mã_KH", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaKH.DataBindings.Clear();
            textBoxMaKH.DataBindings.Add(bdMa);

            Binding bdTen = new Binding("text", dtgv.DataSource, "Tên_KH", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenKH.DataBindings.Clear();
            textBoxTenKH.DataBindings.Add(bdTen);

            Binding bdSDT = new Binding("text", dtgv.DataSource, "SĐT", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxSDT.DataBindings.Clear();
            textBoxSDT.DataBindings.Add(bdSDT);

            Binding bdCMND = new Binding("text", dtgv.DataSource, "CMND", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCMND.DataBindings.Clear();
            textBoxCMND.DataBindings.Add(bdCMND);
            Binding bdGT = new Binding("text", dtgv.DataSource, "Giới_Tính", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxGT.DataBindings.Clear();
            comboBoxGT.DataBindings.Add(bdGT);

            Binding bdDC = new Binding("text", dtgv.DataSource, "Địa_Chỉ", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDC.DataBindings.Clear();
            textBoxDC.DataBindings.Add(bdDC);
        
            
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadKH(dataGridViewKH);
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                //var maKH = dataGridViewKH.Rows[index].Cells[0].Value.ToString();
                string maKH = textBoxMaKH.Text;

                var dv = db.KHACHHANGs.Where(x => x.MaKH == maKH).FirstOrDefault();
                var tk = (from a in db.KHACHHANGs
                          join b in db.HOADONs
                          on a.MaKH equals b.MaKH
                          select new
                          {
                              mnv = a.MaKH
                          }).FirstOrDefault();
                if (tk.mnv == maKH)
                {
                    var phong = (from p in db.HOADONs where p.MaKH.Equals(maKH) select p).FirstOrDefault();
                    phong.MaKH = "KH00";
                    db.HOADONs.AddOrUpdate(phong);
                }
                var tk1 = (from a in db.KHACHHANGs
                          join b in db.PHIEUTHUEPHONGs
                          on a.MaKH equals b.MaKH
                          select new
                          {
                              mnv = a.MaKH
                          }).FirstOrDefault();
                if (tk1.mnv == maKH)
                {
                    var phong1 = (from p in db.PHIEUTHUEPHONGs where p.MaKH.Equals(maKH) select p).FirstOrDefault();
                    phong1.MaKH = "KH00";
                    db.PHIEUTHUEPHONGs.AddOrUpdate(phong1);
                }
               
                db.KHACHHANGs.Remove(dv);
               


                db.SaveChanges();


                MessageBox.Show("Xóa thành công");

                LoadKH(dataGridViewKH);
            }


        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                KHACHHANG kh = new KHACHHANG()
                {
                    MaKH = textBoxMaKH.Text,
                    TenKH = textBoxTenKH.Text,
                    SDT = textBoxSDT.Text,
                    CMND = textBoxCMND.Text,
                    GioiTinh = comboBoxGT.Text,
                    DiaChi = textBoxDC.Text,





                };
                db.KHACHHANGs.Add(kh);
                MessageBox.Show("Thêm thành công");
                db.SaveChanges();
                LoadKH(dataGridViewKH);

            }

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                KHACHHANG kh = db.KHACHHANGs.Find(Int32.Parse(textBoxMaKH.Text));
                kh.TenKH = textBoxTenKH.Text;
                kh.SDT = textBoxSDT.Text;
                kh.CMND = textBoxCMND.Text;
                kh.GioiTinh = comboBoxGT.Text;
                kh.DiaChi = textBoxDC.Text;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadKH(dataGridViewKH);

            }

        }
        int index;
        private void dataGridViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewKH.CurrentRow.Index;
            textBoxMaKH.Text = dataGridViewKH.Rows[index].Cells[0].Value.ToString();
            textBoxTenKH.Text= dataGridViewKH.Rows[index].Cells[1].Value.ToString();
            textBoxSDT.Text= dataGridViewKH.Rows[index].Cells[2].Value.ToString();
            textBoxCMND.Text= dataGridViewKH.Rows[index].Cells[3].Value.ToString();
            comboBoxGT.Text= dataGridViewKH.Rows[index].Cells[4].Value.ToString();
            textBoxDC.Text= dataGridViewKH.Rows[index].Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMaKH.Text = "";
            textBoxTenKH.Text = "";
            textBoxSDT.Text = "";
            textBoxCMND.Text = "";
            textBoxDC.Text = "";
        }
        void LoadTK(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from kh in db.KHACHHANGs
                            where kh.TenKH.Contains(textBoxTK.Text)
                            select new
                            {
                                Mã_KH = kh.MaKH,
                                Tên_KH = kh.TenKH,
                                SĐT = kh.SDT,
                                CMND = kh.CMND,
                                Địa_Chỉ = kh.DiaChi,
                                Giới_Tính = kh.GioiTinh,

                            };
                var result = query.ToList();
                dtgv.DataSource = result;

            }
            BindingKH(dataGridViewKH);
        }
        private void buttonTK_Click(object sender, EventArgs e)
        {
            LoadTK(dataGridViewKH);
        }
    }
}
