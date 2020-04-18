using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;

namespace QLKhachSan.GUI.Controls
{
    public partial class Quanlyphong : Form
    {
        public Quanlyphong()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        void BindingPhong(DataGridView dtgv)
        {

            Binding bdMa = new Binding("text", dtgv.DataSource, "Mã_Phòng", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaPhong.DataBindings.Clear();
            textBoxMaPhong.DataBindings.Add(bdMa);

            Binding bdTen = new Binding("text", dtgv.DataSource, "Tên_Phòng", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenPhong.DataBindings.Clear();
            textBoxTenPhong.DataBindings.Add(bdTen);

            Binding bdTrangThai = new Binding("text", dtgv.DataSource, "Trạng_Thái", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxTrangThai.DataBindings.Clear();
            comboBoxTrangThai.DataBindings.Add(bdTrangThai);

            Binding bdMaLoai = new Binding("text", dtgv.DataSource, "Mã_Loại_Phòng", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaLoaiPhong.DataBindings.Clear();
            textBoxMaLoaiPhong.DataBindings.Add(bdMaLoai);

            

        }

            void LoadPhong(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from p in db.PHONGs
                            join lp in db.LOAIPHONGs on p.MaLoaiPhong equals lp.MaLoaiPhong
                            select new
                            {
                                Mã_Phòng = p.MaPhong,
                                Tên_Phòng = p.SoPhong,
                                Trạng_Thái = p.TrangThai,
                                Mã_Loại_Phòng = lp.MaLoaiPhong,
                                Tên_Loai_Phòng= lp.TenLoaiPhong,
                                Giá=lp.GiaPhong,


                            };
                var result = query.ToList();
                dtgv.DataSource = result;
            }
            BindingPhong(dataGridViewPhong);
        }

        private void Quanlyphong_Load(object sender, EventArgs e)
        {
            LoadPhong(dataGridViewPhong);
        }
        int index;
        private void dataGridViewPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewPhong.CurrentRow.Index;
            textBoxMaPhong.Text = dataGridViewPhong.Rows[index].Cells[0].Value.ToString();
            textBoxTenPhong.Text = dataGridViewPhong.Rows[index].Cells[1].Value.ToString();
            comboBoxTrangThai.Text = dataGridViewPhong.Rows[index].Cells[2].Value.ToString();
            textBoxMaLoaiPhong.Text = dataGridViewPhong.Rows[index].Cells[3].Value.ToString();
            


        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                PHONG phong = new PHONG()
                {
                    MaPhong = textBoxMaPhong.Text,
                    SoPhong = textBoxTenPhong.Text,
                    TrangThai = comboBoxTrangThai.Text,
                    MaLoaiPhong = textBoxMaLoaiPhong.Text,


                };
                if(db.PHONGs.Select(p =>p.MaPhong).Contains(textBoxMaPhong.Text))
                {
                    MessageBox.Show("Mã phòng đã tồn tại!!!");
                    return;

                }
                if (db.PHONGs.Select(p => p.SoPhong).Contains(textBoxTenPhong.Text))
                {
                    MessageBox.Show(" Phòng đã tồn tại!!!");
                    return;

                }
                db.PHONGs.Add(phong);
                db.SaveChanges();
                MessageBox.Show("Thêm phòng thành công");
                LoadPhong(dataGridViewPhong);
            }

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {

                 
                db.PHONGs.Remove(db.PHONGs.Find(Int32.Parse(textBoxMaPhong.Text)));
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadPhong(dataGridViewPhong);
            }
        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {

                PHONG p = db.PHONGs.Find(Int32.Parse(textBoxMaPhong.Text));
                p.SoPhong = textBoxTenPhong.Text;
                p.TrangThai = comboBoxTrangThai.Text;
                p.MaLoaiPhong = textBoxMaLoaiPhong.Text;

                db.SaveChanges();

                MessageBox.Show("Sửa thành công ");
                LoadPhong(dataGridViewPhong);

            }

        }

        void LoadPhongTK(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from p in db.PHONGs
                            join lp in db.LOAIPHONGs on p.MaLoaiPhong equals lp.MaLoaiPhong
                            where p.SoPhong.Contains(textBoxTK.Text)
                            select new
                            {
                                Mã_Phòng = p.MaPhong,
                                Tên_Phòng = p.SoPhong,
                                Trạng_Thái = p.TrangThai,
                                Mã_Loại_Phòng = lp.MaLoaiPhong,
                                Tên_Loai_Phòng = lp.TenLoaiPhong,
                                Giá = lp.GiaPhong,


                            };
                var result = query.ToList();
                dtgv.DataSource = result;
            }
            BindingPhong(dataGridViewPhong);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadPhongTK(dataGridViewPhong);
        }
    }
}
