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
    public partial class DangKy : Form
    {
        public DangKy()
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
                              MANV = nv.MaNV,
                              TenNV = nv.HoTenNV,
                              MATKHAU = tk.MatKhau,
                              TENQUYEN = q.TenQuyen,
                              TENDN = tk.TenDangNhap,

                          }).ToList();
            int j = 1;
            foreach (var temp in result)
            {
                dataGridViewQLND.Rows.Add((j++).ToString(), temp.Ma, temp.MANV, temp.TenNV, temp.MATKHAU, temp.TENDN, temp.TENQUYEN);

            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            dataGridViewQLND.Rows.Clear();
            var newTK = new TAIKHOAN()
            {
                ID = textBoxID.Text,
                MatKhau = textBoxMK.Text,
                MaNV = textBoxMaNV.Text,
                TenDangNhap = textBoxTenDN.Text,
            };
            if (db.TAIKHOANs.Select(p => p.ID).Contains(textBoxID.Text))
            {
                MessageBox.Show("Mã đã tồn tại");
                return;

            }
            db.TAIKHOANs.Add(newTK);
            db.SaveChanges();
            HienThiDS();
            MessageBox.Show("Thêm thành công");
        }

       
        int index;
        private void dataGridViewQLND_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewQLND.CurrentRow.Index;
            textBoxID.Text = dataGridViewQLND.Rows[index].Cells[1].Value.ToString();
            textBoxMaNV.Text = dataGridViewQLND.Rows[index].Cells[2].Value.ToString();
            textBoxMK.Text = dataGridViewQLND.Rows[index].Cells[4].Value.ToString();
            textBoxTenDN.Text = dataGridViewQLND.Rows[index].Cells[5].Value.ToString();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            HienThiDS();
        }
    }
}
