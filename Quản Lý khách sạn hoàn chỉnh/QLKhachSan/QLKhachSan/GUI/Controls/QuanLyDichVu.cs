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
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
        }
        

        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
           
            LoadDVP(dataGridViewSDDV);
        }
      
        
       
        void BindingDVP(DataGridView dtgv)
        {

            Binding bdMa = new Binding("text", dtgv.DataSource, "Mã_DV", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMaDV.DataBindings.Clear();
            textBoxMaDV.DataBindings.Add(bdMa);

            Binding bdTen = new Binding("text", dtgv.DataSource, "Tên_DV", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTenDV.DataBindings.Clear();
            textBoxTenDV.DataBindings.Add(bdTen);

            Binding bdNS = new Binding("text", dtgv.DataSource, "Đơn_Giá", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDG.DataBindings.Clear();

            textBoxDG.DataBindings.Add(bdNS);


           
        }
        void LoadDVP(DataGridView dtgv)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {


                var query =
                             from dv in db.DICHVUs
                            
                             select new
                             {
                                 Mã_DV=dv.MaDV,
                                 Tên_DV=dv.TenDV,
                                 Đơn_Giá = dv.GiaDV,
                                 

                             };

                var results = query.ToList();
                dtgv.DataSource = results;



            }
            BindingDVP(dataGridViewSDDV);
        }
        public static string _DoiSoSangDonViTienTe(object _object)
        {
            try
            {
                if (_object.ToString().Trim().Length == 0)
                { return " "; }

                if (_object.ToString() == "0")
                {
                    return "0,000";
                }

                decimal dThanhTien = Convert.ToDecimal(_object);
                string strThanhTien = string.Format("{0:#,#.}", dThanhTien);
                return strThanhTien;
            }
            catch (Exception)
            {

            }
            return "0.000";
        }


        private void buttonThem_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                DICHVU dv = new DICHVU()
                {
                    MaDV=textBoxMaDV.Text,
                    TenDV=textBoxTenDV.Text,
                    GiaDV=Int32.Parse(textBoxDG.Text),






                };
                _DoiSoSangDonViTienTe(textBoxDG.Text);
                if (db.DICHVUs.Select(p => p.MaDV).Contains(textBoxMaDV.Text))
                {
                    MessageBox.Show("Mã dịch vụ đã tồn tại");
                    return;

                }
                if (db.DICHVUs.Select(p => p.TenDV).Contains(textBoxTenDV.Text))
                {
                    MessageBox.Show("Mã dịch vụ đã tồn tại");
                    return;
                }


                    db.DICHVUs.Add(dv);
                db.SaveChanges();
                MessageBox.Show("Thêm dịch vụ thành công !!!");
                LoadDVP(dataGridViewSDDV);
            }


        }

        private void buttoSua_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {
                string id = textBoxMaDV.Text;
                DICHVU nv = db.DICHVUs.Find(id);

                nv.TenDV = textBoxTenDV.Text;

                nv.GiaDV = Int32.Parse(textBoxDG.Text);
                _DoiSoSangDonViTienTe(textBoxDG.Text);


                db.SaveChanges();
                MessageBox.Show("Sửa thành công ");
                LoadDVP(dataGridViewSDDV);

            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            {

                string id = textBoxMaDV.Text;


                db.DICHVUs.Remove(db.DICHVUs.Find(id));
                var TK = (from tk in db.DICHVU_SD where tk.MaDV.Equals(id) select tk).FirstOrDefault();
                db.DICHVU_SD.Remove(TK);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadDVP(dataGridViewSDDV);
            }
        }

        private void Thoát_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int index;
        private void dataGridViewSDDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridViewSDDV.CurrentRow.Index;
            textBoxMaDV.Text = dataGridViewSDDV.Rows[index].Cells[0].Value.ToString();
            textBoxTenDV.Text= dataGridViewSDDV.Rows[index].Cells[1].Value.ToString();
            textBoxDG.Text= dataGridViewSDDV.Rows[index].Cells[2].Value.ToString();

        }
    }
}
