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
                var t = db.TAIKHOANs.Where(p => p.MaNV.Equals(id) && p.MatKhau.Equals(pass));
                TAIKHOAN u = t.Count() == 1 ? t.Single() : null;
                if (u != null)
                {
                    NHANVIEN nv = db.NHANVIENs.Where(p => u.MaNV.Equals(p.MaNV)).Single();
                    Cons.cons.loginNhanVien = nv;
                    QuanLyKhachSan.quyen = (int)nv.QUYEN.MaQuyen;
                    QuanLyKhachSan a = new QuanLyKhachSan();
                    a.ShowDialog();
                    //roll = (int)nv.QUYEN.MaQuyen;
                   // Cons.cons.loginNhanVien = nv;
                    //QuanLyKhachSan a = new QuanLyKhachSan();
                    //a.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                 //   ClearTextBox();
                   //  return null;
                }

            }

            //Form f = nextForm(textBoxName.Text, textBoxPass.Text);
            //if (f == null) return;
            //f.FormClosed += f_FormCLosed;
            //f.StartPosition = FormStartPosition.CenterScreen;
            //f.Show();
            //string id = textBoxName.Text;
            //string pass = textBoxName.Text;
            //int roll = 0;
            //using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
            //{
            //    var t = db.TAIKHOANs.Where(p => p.MaNV.Equals(id) && p.MatKhau.Equals(pass));
            //    TAIKHOAN u = t.Count() == 1 ? t.Single() : null;
            //    if (u != null)
            //    {
            //        NHANVIEN nv = db.NHANVIENs.Where(p => u.MaNV.Equals(p.MaNV)).Single();
            //        roll = (int)nv.QUYEN.MaQuyen;
            //        Cons.cons.loginNhanVien = nv;
            //        //QuanLyKhachSan a = new QuanLyKhachSan();
            //        //a.ShowDialog();


            //    }
            //    else
            //    {
            //        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            //        ClearTextBox();
            //       // return null;
            //    }


            //   this.Hide();


            // ClearTextBox();

        }
    //private void f_FormCLosed(object sender, FormClosedEventArgs e)
    //{
    //    this.Show();
    //}
    //void ClearTextBox()
    //        {
    //            textBoxName.Clear();
    //            textBoxPass.Clear();
    //        }
    ////  public static int  roll = 0;
    //Form nextForm(string id, string pass)
    //{
    //    Form f = new Form();
    //    //int roll = 0;


    //    using (QUANLYKHACHSANEntities db = new QUANLYKHACHSANEntities())
    //    {
    //        var t = db.TAIKHOANs.Where(p => p.MaNV.Equals(id) && p.MatKhau.Equals(pass));
    //        TAIKHOAN u = t.Count() == 1 ? t.Single() : null;
    //        if (u != null)
    //        {
    //            NHANVIEN nv = db.NHANVIENs.Where(p => u.MaNV.Equals(p.MaNV)).Single();
    //            roll = (int)nv.QUYEN.MaQuyen;
    //            Cons.cons.loginNhanVien = nv;


    //        }
    //        else
    //        {
    //            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");

    //            return null;
    //        }
    //    }


        //    //switch (roll)
        //    //{
        //    //    case 1:
        //    //      f = new QuanLyKhachSan();
        //    //        break;
        //    //    case 2:
        //    //     //  f = new QuanLyKhachSan();
        //    //       // f = new QuanLyKhachHang();

        //    //       // quảnLýNgườiDùngToolStripMenuItem
        //    //        QuanLyNhanVien a = new QuanLyNhanVien();
        //    //        a.Enabled=false;
        //    //      //  return;


        //    //        break;

        //    //}
        //    //return f;

        //}

        private void buttonĐK_Click(object sender, EventArgs e)
            {
                DangKy a = new DangKy();
                a.ShowDialog();
            }
        

    }
}

