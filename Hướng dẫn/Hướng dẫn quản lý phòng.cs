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
    public partial class Hướng_dẫn_quản_lý_phòng : Form
    {
        public Hướng_dẫn_quản_lý_phòng()
        {
            InitializeComponent();
            label2.AutoSize = true;
            label2.Text= " Khi nhân viên nhập mã phòng vào ô sẽ có 2 trường \nhợp xảy ra:\n" +
                "   TH1: Nhân viên nhập tên phòng có trong CSDL và \nấn nút thêm hệ thống sẽ báo đã tồn tại phòng đó," +
                " \n nhân viên sẽ được thực hiện tác vụ sửa và \nxóa trên form.\n" +
                "   TH2: Nhân viên nhập tên phòng chưa có trong \nCDSL nhân viên sẽ được thực hiện tác vụ \n thêm phòng mới trên form."; 
        }

        private void Hướng_dẫn_quản_lý_phòng_Load(object sender, EventArgs e)
        {

        }
    }
}
