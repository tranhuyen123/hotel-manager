using QLKhachSan.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLKhachSan.GUI.Controls
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities();
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string id = textBoxName.Text.Trim();
            string pass = textBoxPass.Text.Trim();
            if(id !=""|| pass !="")
            {
                var t = db.TAIKHOANs.Where(p => p.TenDangNhap.Equals(id) && p.MatKhau.Equals(pass));
                TAIKHOAN u = t.Count() == 1 ? t.Single() : null;
                if (u != null)
                {
                    NHANVIEN nv = db.NHANVIENs.Where(p => u.MaNV.Equals(p.MaNV)).Single();
                    Cons.cons.loginNhanVien = nv;
                    QuanLyKhachSan.quyen = (int)nv.QUYEN.MaQuyen;
                    QuanLyKhachSan a = new QuanLyKhachSan();
                    a.ShowDialog();
                  


                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                 
                }

            }

     
    

       
        

    }
}

