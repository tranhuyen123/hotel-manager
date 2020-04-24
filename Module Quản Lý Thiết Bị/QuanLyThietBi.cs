using QLKhachSan.Model;
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

namespace QLKhachSan.GUI.Controls
{
    public partial class QuanLyThietBi : Form
    {
        public QuanLyThietBi()
        {
            InitializeComponent();
            setCbbPhong();
        }
        string tenphong;
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
        List<string> getAllPhong()
        {
            List<string> p = new List<string>();
            p = db.PHONGs.Select(x => x.SoPhong).ToList();
            return p;
        }
        private void setCbbPhong()
        {
            List<string> P = getAllPhong();
            foreach (string temp1 in P)
            {
                comboBoxTB.Items.Add(temp1);
            }
        }
        /// <summary>
        /// /bảng thiết bị
        /// </summary>
        /// <param name="dtgv"></param>
        void BindingTB(DataGridView dtgv)
        {

            Binding bdMa = new Binding("text", dtgv.DataSource, "Mã_TB", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaTB.DataBindings.Clear();
            textBoxMaTB.DataBindings.Add(bdMa);

            Binding bdTen = new Binding("text", dtgv.DataSource, "Tên_TB", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenTB.DataBindings.Clear();
            textBoxTenTB.DataBindings.Add(bdTen);

            Binding bdGhiChu = new Binding("text", dtgv.DataSource, "Ghi_Chú", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxGhiChu.DataBindings.Clear();
            textBoxGhiChu.DataBindings.Add(bdGhiChu);

            



        }

        void LoadTB(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from p in db.THIETBIs
                         
                            
                            select new
                            {
                                Mã_TB= p.MaTB,
                                Tên_TB=p.TenTB,
                                Ghi_Chú=p.GhiChu,
                              
                                


                            };
                var result = query.ToList();
                dtgv.DataSource = result;
            }
            BindingTB(dataGridViewTBP);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                THIETBI tb = new THIETBI
                {
                    MaTB = textBoxMaTB.Text,
                    TenTB = textBoxTenTB.Text,
                    GhiChu = textBoxGhiChu.Text,


                };
                if (db.THIETBIs.Select(p => p.MaTB).Contains(textBoxMaTB.Text))
                {
                    MessageBox.Show("Mã thiết bị đã tồn tại");
                    return;
                }
                if (db.THIETBIs.Select(p => p.TenTB).Contains(textBoxTenTB.Text))
                {
                    MessageBox.Show("Tên thiết bị đã tồn tại");
                    return;
                }
                db.THIETBIs.Add(tb);
                MessageBox.Show("Thêm thiết bị thành công");
                db.SaveChanges();

                LoadTB(dataGridViewTBP);
            }

        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                THIETBI tb = db.THIETBIs.Find(Int32.Parse(textBoxMaTB.Text));

                tb.TenTB = textBoxTenTB.Text;
                tb.GhiChu = textBoxGhiChu.Text;

                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadTB(dataGridViewTBP);

            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                string id = textBoxMaTB.Text;
                db.THIETBIs.Remove(db.THIETBIs.Find(id));

                var matb = dataGridViewTBP.Rows[index].Cells[0].Value.ToString();
                var lstSdtb = db.THIETBI_SD.Where(x => x.MaTB == matb).ToList();
                foreach (var sddv in lstSdtb)
                {
                    db.THIETBI_SD.Remove(sddv);
                }
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadTB(dataGridViewTBP);
            }
        }

        //bảng tbi sd
        void BindingTBSD(DataGridView dtgv)
        {

            Binding bdMa = new Binding("text", dtgv.DataSource, "Mã_Phòng", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxTB.DataBindings.Clear();
            comboBoxTB.DataBindings.Add(bdMa);

            Binding bdMaTB = new Binding("text", dtgv.DataSource, "Mã_TB", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMa.DataBindings.Clear();
            textBoxMa.DataBindings.Add(bdMaTB);

            Binding bdSL = new Binding("text", dtgv.DataSource, "Số_Lượng", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxSL.DataBindings.Clear();
            textBoxSL.DataBindings.Add(bdSL);





        }

        void LoadTBSD(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from p in db.THIETBIs
                            join tbsd in db.THIETBI_SD on p.MaTB equals tbsd.MaTB
                            join ph in db.PHONGs on tbsd.MaPhong equals ph.MaPhong

                            select new
                            {
                                Mã_TB = p.MaTB,
                                Tên_TB = p.TenTB,
                                Ghi_Chú = p.GhiChu,
                                Mã_Phòng = tbsd.MaPhong,
                                Tên_Phòng = ph.SoPhong,
                                Số_Lượng = tbsd.SoLuong,



                            };
                var result = query.ToList();
                dtgv.DataSource = result;
            }
            BindingTBSD(dataGridViewTB);
        }

       
        private void QuanLyThietBi_Load(object sender, EventArgs e)
        {
            LoadTB(dataGridViewTBP);
            LoadTBSD(dataGridViewTB);
        }

       
        int index;
        private void dataGridViewTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewTB.CurrentRow.Index;
            textBoxMa.Text = dataGridViewTB.Rows[index].Cells[0].Value.ToString();
            comboBoxTB.Text = dataGridViewTB.Rows[index].Cells[3].Value.ToString();
            textBoxSL.Text = dataGridViewTB.Rows[index].Cells[5].Value.ToString();


        }

       
        int Index;
        private void dataGridViewTBP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = dataGridViewTBP.CurrentRow.Index;
            textBoxMaTB.Text = dataGridViewTBP.Rows[Index].Cells[0].Value.ToString();
            textBoxTenTB.Text = dataGridViewTBP.Rows[Index].Cells[1].Value.ToString();
          //  textBoxGhiChu.Text = dataGridViewTBP.Rows[Index].Cells[2].Value.ToString();
           // textBoxGhiChu.Text = "";
        }
        void LoadTBSDTK(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var query = from p in db.THIETBIs
                            join tbsd in db.THIETBI_SD on p.MaTB equals tbsd.MaTB
                            join ph in db.PHONGs on tbsd.MaPhong equals ph.MaPhong
                            where ph.SoPhong.Contains(textBox1.Text)

                            select new
                            {
                                Mã_TB = p.MaTB,
                                Tên_TB = p.TenTB,
                                Ghi_Chú = p.GhiChu,
                                Mã_Phòng = tbsd.MaPhong,
                                Tên_Phòng = ph.SoPhong,
                                Số_Lượng = tbsd.SoLuong,



                            };
                var result = query.ToList();
                dtgv.DataSource = result;
            }
            BindingTBSD(dataGridViewTB);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadTBSDTK(dataGridViewTB);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonThemTBP_Click(object sender, EventArgs e)
        {
            tenphong = comboBoxTB.SelectedItem.ToString();
            var ABC = (from p in db.PHONGs
                       where p.SoPhong==tenphong
                       select new
                       {
                           mdv = p.MaPhong
                       }
                       ).FirstOrDefault();
           
                THIETBI_SD tb = new THIETBI_SD
                {
                    MaTB = textBoxMa.Text,
                    MaPhong=ABC.mdv,
                    SoLuong = Int32.Parse(textBoxSL.Text),


                };
               
               
                db.THIETBI_SD.Add(tb);
             
               

                db.SaveChanges();
                MessageBox.Show("Thêm thiết bị thành công");

                LoadTBSD(dataGridViewTB);
            

        }

        private void textBoxSL_TextChanged(object sender, EventArgs e)
        {

        }
        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                var dv = db.THIETBI_SD.Where(x => x.MaTB == textBoxMa.Text).FirstOrDefault();
                dv.MaPhong= comboBoxTB.Text;
                dv.SoLuong = Int32.Parse(textBoxSL.Text);
               
                db.THIETBI_SD.AddOrUpdate(dv);
                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadTBSD(dataGridViewTB);
            }
        }
        //xóa
        private void button3_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var maTB = dataGridViewTB.Rows[Index].Cells[0].Value.ToString(); ;
                var dv = db.THIETBI_SD.Where(x => x.MaTB== maTB).FirstOrDefault();
                db.THIETBI_SD.Remove(dv);
                var lstSddv = db.THIETBIs.Where(x => x.MaTB == maTB).ToList();
                foreach (var sddv in lstSddv)
                {
                    db.THIETBIs.Remove(sddv);
                }
              //  db.THIETBI_SD.Remove(dv);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadTBSD(dataGridViewTB);
            }
        }
    }
}
