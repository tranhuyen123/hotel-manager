using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.Model;

namespace QLKhachSan.GUI.Controls
{
    public partial class Quanlytaikhoan : Form
    {
        public Quanlytaikhoan()
        {
            InitializeComponent();
        }
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
       
            private void HienThiDS()
        {
            dataGridViewQLND.Rows.Clear();
            var result = (from tk in db.TAIKHOANs
                          join nv in db.NHANVIENs on tk.MaNV equals nv.MaNV
                          join q in db.QUYENs on nv.MaQuyen equals q.MaQuyen

                          select new
                          {
                              Ma = tk.ID,
                              MANV= nv.MaNV,
                              TenNV=nv.HoTenNV,
                              MATKHAU=tk.MatKhau,
                              TENQUYEN=q.TenQuyen,
                           
                       }).ToList();
            int j = 1;
            foreach (var temp in result)
            {
                dataGridViewQLND.Rows.Add((j++).ToString(), temp.Ma, temp.MANV, temp.TenNV, temp.MATKHAU, temp.TENQUYEN);

            }
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quanlytaikhoan_Load(object sender, EventArgs e)
        {
            HienThiDS();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            var newTK = new TAIKHOAN()
            {
                ID=textBoxID.Text,
                MatKhau=textBoxMK.Text,
                MaNV=textBoxMaNV.Text,
            };
            db.TAIKHOANs.Add(newTK);
            db.SaveChanges();
            HienThiDS();
            MessageBox.Show("Thêm thành công");
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            var dv = db.TAIKHOANs.Where(x => x.MaNV == textBoxMaNV.Text).FirstOrDefault();
            dv.MatKhau = textBoxMK.Text;
            dv.ID = textBoxID.Text;


            db.TAIKHOANs.AddOrUpdate(dv);
          
           
            db.SaveChanges();
            HienThiDS();
            MessageBox.Show("Sửa thành công");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            db.TAIKHOANs.Remove(db.TAIKHOANs.Find(id));
            db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            HienThiDS();
        }
        int index;
        private void dataGridViewQLND_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewQLND.CurrentRow.Index;
            textBoxID.Text = dataGridViewQLND.Rows[index].Cells[1].Value.ToString();
            textBoxMaNV.Text = dataGridViewQLND.Rows[index].Cells[2].Value.ToString();
            textBoxMK.Text= dataGridViewQLND.Rows[index].Cells[4].Value.ToString();
        }
    }
}
