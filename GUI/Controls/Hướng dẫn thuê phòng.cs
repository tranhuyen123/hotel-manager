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
    public partial class Hướng_dẫn_thuê_phòng : Form
    {
        public Hướng_dẫn_thuê_phòng()
        {
            InitializeComponent();
            label2.AutoSize = true;
            label2.Text = "Sau khi khách hàng đến thuê phòng, nhân viên khách sạn sẽ \n nhập thông tin khách hàng vào quản lý khách hàng " +
                " \n Trong mục quản lý phòng,khách hàng yêu cầu loại phòng nào \n thì nhân viên sẽ chọn mục tìm kiếm để hiển thị ra phòng phù\n hợp. " +
                "\n Nhập tên khách hàng nhập mã phòng khách chọn,\n mã phiếu và lập phiếu thuê phòng." 
                ;
        }
    }
}
