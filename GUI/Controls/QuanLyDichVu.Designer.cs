namespace QLKhachSan.GUI.Controls
{
    partial class QuanLyDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSDDV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Thoát = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttoSua = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDG = new System.Windows.Forms.TextBox();
            this.textBoxTenDV = new System.Windows.Forms.TextBox();
            this.textBoxMaDV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSDDV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý dịch vụ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.dataGridViewSDDV);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(36, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 367);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin các dịch vụ";
            // 
            // dataGridViewSDDV
            // 
            this.dataGridViewSDDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSDDV.Location = new System.Drawing.Point(21, 176);
            this.dataGridViewSDDV.Name = "dataGridViewSDDV";
            this.dataGridViewSDDV.Size = new System.Drawing.Size(642, 186);
            this.dataGridViewSDDV.TabIndex = 5;
            this.dataGridViewSDDV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSDDV_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Thoát);
            this.panel2.Controls.Add(this.buttonXoa);
            this.panel2.Controls.Add(this.buttoSua);
            this.panel2.Controls.Add(this.buttonThem);
            this.panel2.Location = new System.Drawing.Point(21, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 40);
            this.panel2.TabIndex = 4;
            // 
            // Thoát
            // 
            this.Thoát.Location = new System.Drawing.Point(485, 14);
            this.Thoát.Name = "Thoát";
            this.Thoát.Size = new System.Drawing.Size(75, 23);
            this.Thoát.TabIndex = 3;
            this.Thoát.Text = "Thoát";
            this.Thoát.UseVisualStyleBackColor = true;
            this.Thoát.Click += new System.EventHandler(this.Thoát_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Location = new System.Drawing.Point(342, 14);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(75, 23);
            this.buttonXoa.TabIndex = 2;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttoSua
            // 
            this.buttoSua.Location = new System.Drawing.Point(209, 14);
            this.buttoSua.Name = "buttoSua";
            this.buttoSua.Size = new System.Drawing.Size(75, 23);
            this.buttoSua.TabIndex = 1;
            this.buttoSua.Text = "Sửa";
            this.buttoSua.UseVisualStyleBackColor = true;
            this.buttoSua.Click += new System.EventHandler(this.buttoSua_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(42, 14);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 23);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxDG);
            this.panel1.Controls.Add(this.textBoxTenDV);
            this.panel1.Controls.Add(this.textBoxMaDV);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(21, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 66);
            this.panel1.TabIndex = 3;
            // 
            // textBoxDG
            // 
            this.textBoxDG.Location = new System.Drawing.Point(517, 11);
            this.textBoxDG.Name = "textBoxDG";
            this.textBoxDG.Size = new System.Drawing.Size(100, 20);
            this.textBoxDG.TabIndex = 5;
            // 
            // textBoxTenDV
            // 
            this.textBoxTenDV.Location = new System.Drawing.Point(267, 11);
            this.textBoxTenDV.Name = "textBoxTenDV";
            this.textBoxTenDV.Size = new System.Drawing.Size(100, 20);
            this.textBoxTenDV.TabIndex = 4;
            // 
            // textBoxMaDV
            // 
            this.textBoxMaDV.Location = new System.Drawing.Point(79, 11);
            this.textBoxMaDV.Name = "textBoxMaDV";
            this.textBoxMaDV.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaDV.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã dịch vụ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên dịch vụ";
            // 
            // QuanLyDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(856, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyDichVu";
            this.Text = "QuanLyDichVu";
            this.Load += new System.EventHandler(this.QuanLyDichVu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSDDV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Thoát;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttoSua;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.TextBox textBoxDG;
        private System.Windows.Forms.TextBox textBoxTenDV;
        private System.Windows.Forms.TextBox textBoxMaDV;
        private System.Windows.Forms.DataGridView dataGridViewSDDV;
    }
}