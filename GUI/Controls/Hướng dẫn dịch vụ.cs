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
    public partial class Hướng_dẫn_dịch_vụ : Form
    {
        public Hướng_dẫn_dịch_vụ()
        {
            InitializeComponent();
            label2.AutoSize = true;
            label2.Text= "Sau khi khách hàng gọi đồ qua lễ tân, nhân viên \nkhách sạn sẽ nhập dịch vụ " +
                "vào phần mềm để lưu " +
                "\n lại. \n Trong danh sách phòng đang được thuê, nhân \n viên chọn phòng vừa gọi và chọn dịch vụ vừa \nkèm theo số lượng" +
                "\nSau khi thêm, các thông tin vừa nhập sẽ hiển thị \ntrong bảng thông kê." +
                "\nĐể cập nhật các dịch vụ vào trang quản lý dịch vụ."; 
        }
    }
}
