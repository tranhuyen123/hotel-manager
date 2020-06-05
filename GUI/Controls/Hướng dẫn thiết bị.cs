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
    public partial class Hướng_dẫn_thiết_bị : Form
    {
        public Hướng_dẫn_thiết_bị()
        {
            InitializeComponent();
            label2.AutoSize = true;
            label2.Text = "Nhân viên quản lý thiết bị  có thể thêm sử xóa thiết bị " +
                "\n Thêm sửa xóa thiết bị vào các phòng có thể tìm kiếm phòng  "
               ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
