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
    public partial class Hướng_dẫn_thanh_toán : Form
    {
        public Hướng_dẫn_thanh_toán()
        {
            InitializeComponent();
            label2.AutoSize = true;
            label2.Text = "Khi khách hàng đến thanh toán nhân viên tiến hành lập hóa đơn" +
               
          " \n Nhân viên sẽ nhập tên khách hàng,phòng khách ở số ngày ở " +
                "\n Tổng tiền cần thanh toán hiện lên và nhập vào tiền khách trả" +
                "\n Sau đó tiến hành in hóa đơn cho khách.";
        }
    }
}
