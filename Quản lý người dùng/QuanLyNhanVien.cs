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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadNV(dataGridView1);
           

        }
        void BindingNV(DataGridView dtgv)
        {
           
            Binding bdMa = new Binding("text", dtgv.DataSource, "MaNV", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaNV.DataBindings.Clear();
            textBoxMaNV.DataBindings.Add(bdMa);

            Binding bdTen = new Binding("text", dtgv.DataSource, "TenNV", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxHoTen.DataBindings.Clear();
            textBoxHoTen.DataBindings.Add(bdTen);

            Binding bdNS = new Binding("text", dtgv.DataSource, "NGAYSINH", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimeNS.DataBindings.Clear();
            
            dateTimeNS.DataBindings.Add(bdNS);

           
            Binding bdGT = new Binding("text", dtgv.DataSource, "GT", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxGT.DataBindings.Clear();
            comboBoxGT.DataBindings.Add(bdGT);

            Binding bdCM = new Binding("text", dtgv.DataSource, "CM", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCMND.DataBindings.Clear();
            textBoxCMND.DataBindings.Add(bdCM);

            Binding bdDC = new Binding("text", dtgv.DataSource, "DC", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDiaChi.DataBindings.Clear();
            textBoxDiaChi.DataBindings.Add(bdDC);

            Binding bdSoDienThoai = new Binding("text", dtgv.DataSource, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxSDT.DataBindings.Clear();
            textBoxSDT.DataBindings.Add(bdSoDienThoai);
           
            Binding bdTenQuyen = new Binding("text", dtgv.DataSource, "TenQuyen", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenQuyen.DataBindings.Clear();
            textBoxTenQuyen.DataBindings.Add(bdTenQuyen);

            Binding bdBoPhan = new Binding("text", dtgv.DataSource, "BoPhan", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenBoPhan.DataBindings.Clear();
            textBoxTenBoPhan.DataBindings.Add(bdBoPhan);

            Binding bdQuyen = new Binding("text", dtgv.DataSource, "Quyen", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenBoPhan.DataBindings.Clear();
            textBoxTenBoPhan.DataBindings.Add(bdQuyen);

            Binding bdChucVu = new Binding("text", dtgv.DataSource, "ChucVu", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenBoPhan.DataBindings.Clear();
            textBoxTenBoPhan.DataBindings.Add(bdBoPhan);





        }
        void LoadNV(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from nv in db.NHANVIENs
                             join q in db.QUYENs on nv.MaQuyen equals q.MaQuyen
                             join bp in db.BOPHANs

                             on nv.IDBoPhan equals bp.IDBoPhan
                             select new
                             {
                                 MANV = nv.MaNV,
                                 TenNV = nv.HoTenNV,
                                 NGAYSINH = nv.NgaySinh,
                                 GT = nv.GioiTinh,
                                 CM = nv.CMND,
                                 DC = nv.DiaChi,
                                 SoDienThoai = nv.SDT,

                                 TenQuyen = q.MaQuyen,
                                 BoPhan = bp.IDBoPhan,

                                 Quyen = q.TenQuyen,
                                 ChucVu=bp.TenBoPhan,
                                
                             };

                var results = query.ToList();
                dtgv.DataSource = results;



            }
            BindingNV(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //QuanLyKhachSan qlks = new QuanLyKhachSan();
            //qlks.ShowDialog();
           
        }
       
        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                NHANVIEN nv = new NHANVIEN()
                {
                    MaNV = textBoxMaNV.Text,
                    

                    HoTenNV = textBoxHoTen.Text,

                    GioiTinh = comboBoxGT.Text,
                    SDT = textBoxSDT.Text,
                    DiaChi = textBoxDiaChi.Text,
                    CMND=textBoxCMND.Text,
                    NgaySinh=System.DateTime.Parse(dateTimeNS.Text),
                    
                    MaQuyen = Int32.Parse(textBoxTenQuyen.Text),
                    IDBoPhan = Int32.Parse(textBoxTenBoPhan.Text),





                };
                if (db.NHANVIENs.Select( p => p.MaNV).Contains(textBoxMaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại");
                    return;

                }
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                MessageBox.Show("Thêm nhân viên thành công !!!");
                LoadNV(dataGridView1);
            }


        }
        int index;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            textBoxMaNV.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            textBoxHoTen.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            dateTimeNS.Text= dataGridView1.Rows[index].Cells[2].Value.ToString();
            comboBoxGT.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBoxCMND.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            textBoxDiaChi.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            textBoxSDT.Text= dataGridView1.Rows[index].Cells[6].Value.ToString();
            textBoxTenQuyen.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            textBoxTenBoPhan.Text= dataGridView1.Rows[index].Cells[8].Value.ToString();
           


        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
               
                string id = textBoxMaNV.Text;
               
                
                db.NHANVIENs.Remove(db.NHANVIENs.Find(id));
                var TK = (from tk in db.TAIKHOANs where tk.MaNV.Equals(id) select tk).FirstOrDefault();
                db.TAIKHOANs.Remove(TK);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadNV(dataGridView1);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                string id = textBoxMaNV.Text;
                NHANVIEN nv = db.NHANVIENs.Find(id);
               
                nv.HoTenNV = textBoxHoTen.Text;

                nv.GioiTinh = comboBoxGT.Text;
                nv.SDT = textBoxSDT.Text;
                nv. DiaChi = textBoxDiaChi.Text;
                nv.CMND = textBoxCMND.Text;
                nv.NgaySinh = System.DateTime.Parse(dateTimeNS.Text);

                nv.MaQuyen = Int32.Parse(textBoxTenQuyen.Text);
                nv.IDBoPhan = Int32.Parse(textBoxTenBoPhan.Text);
                db.SaveChanges();
                MessageBox.Show("Sửa thành công ");
                LoadNV(dataGridView1);

            }
        }
        void LoadTK(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from nv in db.NHANVIENs
                             join q in db.QUYENs on nv.MaQuyen equals q.MaQuyen
                             join bp in db.BOPHANs

                             on nv.IDBoPhan equals bp.IDBoPhan
                             where nv.HoTenNV.Contains(textBoxTK.Text)
                             select new
                             {
                                 MANV = nv.MaNV,
                                 TenNV = nv.HoTenNV,
                                 NGAYSINH = nv.NgaySinh,
                                 GT = nv.GioiTinh,
                                 CM = nv.CMND,
                                 DC = nv.DiaChi,
                                 SoDienThoai = nv.SDT,

                                 TenQuyen = q.MaQuyen,
                                 BoPhan = bp.IDBoPhan,

                                 Quyen = q.TenQuyen,
                                 ChucVu = bp.TenBoPhan,

                             };

                var results = query.ToList();
                dtgv.DataSource = results;



            }
            BindingNV(dataGridView1);
        }
        private void buttonTK_Click(object sender, EventArgs e)
        {
            LoadTK(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxMaNV.Text = "";
            textBoxHoTen.Text = "";
            comboBoxGT.Text = "";
            textBoxCMND.Text = "";
            textBoxDiaChi.Text = "";
            textBoxSDT.Text = "";
            textBoxTenBoPhan.Text = "";
            textBoxTenQuyen.Text = "";
        }
    }
}
