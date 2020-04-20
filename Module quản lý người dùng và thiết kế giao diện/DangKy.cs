using QLKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan.GUI.Controls
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            LoadTK(dataGridViewDK);
            
        }
        void LoadTK(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from nv in db.NHANVIENs
                             join q in db.QUYENs on nv.MaQuyen equals q.MaQuyen
                             join tk in db.TAIKHOANs on nv.MaNV equals tk.MaNV
                             join bp in db.BOPHANs

                             on nv.IDBoPhan equals bp.IDBoPhan
                             select new
                             {
                                 ID=tk.ID,
                                 MANV = nv.MaNV,
                                 TenNV = nv.HoTenNV,
                                 Mật_Khẩu =tk.MatKhau,
                                 Quyen = q.TenQuyen,
                                 ChucVu = bp.TenBoPhan,

                             };

                var results = query.ToList();
                dtgv.DataSource = results;



            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                TAIKHOAN nv = new TAIKHOAN()
                {
                    ID=textBoxID.Text,
                    MatKhau=textBoxMK.Text,
                    MaNV=textBoxMaNV.Text,





                };
               
                db.TAIKHOANs.Add(nv);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công !!!");
                LoadTK(dataGridViewDK);
            }

        }

        private void buttonThemNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien a = new QuanLyNhanVien();
            a.ShowDialog();
        }
        int index;
        private void dataGridViewDK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewDK.CurrentRow.Index;
            textBoxID.Text = dataGridViewDK.Rows[index].Cells[0].Value.ToString();
            textBoxMaNV.Text = dataGridViewDK.Rows[index].Cells[1].Value.ToString();
            textBoxMK.Text = dataGridViewDK.Rows[index].Cells[3].Value.ToString();
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                string id = textBoxMaNV.Text;
                TAIKHOAN nv = db.TAIKHOANs.Find(id);
                nv.ID = textBoxID.Text;
                nv.MatKhau = textBoxMK.Text;

               
                db.SaveChanges();
                MessageBox.Show("Sửa thành công ");
                LoadTK(dataGridViewDK);

            }
        }
    }
}
