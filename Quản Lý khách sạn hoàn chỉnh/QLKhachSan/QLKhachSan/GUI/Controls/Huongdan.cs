using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan.GUI.Controls
{
    public partial class Huongdan : Form
    {
        public Huongdan()
        {
            InitializeComponent();
            label4.AutoSize = true;
            label4.Text = "  Khi nhân viên có tài khoản được cấp, nhân viên đăng nhập bằng tài \nkhoản của mình " +
                "và thực hiện các chức năng. Nếu chưa có tài khoản \nthì ấn đăng ký và đăng ký tài khoản cho riêng mình\n" +
                "  Không đăng nhập thì nhân viên không \nthực hiện được công việc chuyên môn !!";
            label5.AutoSize = true;
            label5.Text = "  Khi đăng ý tài khoản, nhân viên sẽ được quản lý cấp mã để đăng \nký tài khoản. " +
                " \nHãy ghi nhớ username và password của mình" +
                "\n Nếu quên hoặc k đăng nhập được thì phải báo ngay cho chủ " +
                "\nkhách sạn " +
                "để lấy lại password";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Huongdan_Load(object sender, EventArgs e)
        {

        }
    }
}
