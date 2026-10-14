namespace bai5
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLoaiVanChuyen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.ColTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTrongLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTongSoLuong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTongTrongLuong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTongTien = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1092, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý đơn giao hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpKhachHang);
            this.splitContainer1.Panel1MinSize = 280;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvHangHoa);
            this.splitContainer1.Size = new System.Drawing.Size(1086, 525);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(this.textBox2);
            this.grpKhachHang.Controls.Add(this.label5);
            this.grpKhachHang.Controls.Add(this.textBox1);
            this.grpKhachHang.Controls.Add(this.label4);
            this.grpKhachHang.Controls.Add(this.label3);
            this.grpKhachHang.Controls.Add(this.cboLoaiVanChuyen);
            this.grpKhachHang.Controls.Add(this.label2);
            this.grpKhachHang.Controls.Add(this.txtTenKhachHang);
            this.grpKhachHang.Controls.Add(this.label1);
            this.grpKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKhachHang.Location = new System.Drawing.Point(0, 0);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(340, 525);
            this.grpKhachHang.TabIndex = 0;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "Thông tin khách hàng & vận chuyển";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(27, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gợi ý: Nhấn F2 để thêm dòng mới\r\nNhấn Delete để xóa dòng đang chọn";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cboLoaiVanChuyen
            // 
            this.cboLoaiVanChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiVanChuyen.FormattingEnabled = true;
            this.cboLoaiVanChuyen.Items.AddRange(new object[] {
            "Giao hàng tiêu chuẩn",
            "Giao hàng nhanh",
            "Giao hàng tiết kiệm",
            "Giao hàng nội thành",
            "Giao hàng liên tỉnh"});
            this.cboLoaiVanChuyen.Location = new System.Drawing.Point(21, 90);
            this.cboLoaiVanChuyen.Name = "cboLoaiVanChuyen";
            this.cboLoaiVanChuyen.Size = new System.Drawing.Size(290, 26);
            this.cboLoaiVanChuyen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại vận chuyển";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(21, 43);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(290, 24);
            this.txtTenKhachHang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng";
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTenHang,
            this.ColSoLuong,
            this.ColTrongLuong,
            this.ColDonGia,
            this.ColThanhTien});
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(0, 0);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RowHeadersWidth = 51;
            this.dgvHangHoa.RowTemplate.Height = 28;
            this.dgvHangHoa.Size = new System.Drawing.Size(742, 525);
            this.dgvHangHoa.TabIndex = 0;
            this.dgvHangHoa.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvHangHoa_CellValidating);
            this.dgvHangHoa.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellValueChanged);
            this.dgvHangHoa.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvHangHoa_UserDeletedRow);
            // 
            // ColTenHang
            // 
            this.ColTenHang.HeaderText = "Tên hàng";
            this.ColTenHang.MinimumWidth = 6;
            this.ColTenHang.Name = "ColTenHang";
            this.ColTenHang.Width = 160;
            // 
            // ColSoLuong
            // 
            this.ColSoLuong.HeaderText = "Số lượng";
            this.ColSoLuong.MinimumWidth = 6;
            this.ColSoLuong.Name = "ColSoLuong";
            // 
            // ColTrongLuong
            // 
            this.ColTrongLuong.HeaderText = "Trọng lượng (kg)";
            this.ColTrongLuong.MinimumWidth = 6;
            this.ColTrongLuong.Name = "ColTrongLuong";
            this.ColTrongLuong.Width = 120;
            // 
            // ColDonGia
            // 
            this.ColDonGia.HeaderText = "Đơn giá";
            this.ColDonGia.MinimumWidth = 6;
            this.ColDonGia.Name = "ColDonGia";
            this.ColDonGia.Width = 120;
            // 
            // ColThanhTien
            // 
            this.ColThanhTien.HeaderText = "Thành tiền";
            this.ColThanhTien.MinimumWidth = 6;
            this.ColThanhTien.Name = "ColThanhTien";
            this.ColThanhTien.ReadOnly = true;
            this.ColThanhTien.Width = 130;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblThoiGian,
            this.toolStripStatusLabelSpring,
            this.lblTongSoLuong,
            this.lblTongTrongLuong,
            this.lblTongTien});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(74, 20);
            this.lblThoiGian.Text = "Thời gian:";
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(608, 20);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(120, 20);
            this.lblTongSoLuong.Text = "Tổng số lượng: 0";
            // 
            // lblTongTrongLuong
            // 
            this.lblTongTrongLuong.Name = "lblTongTrongLuong";
            this.lblTongTrongLuong.Size = new System.Drawing.Size(161, 20);
            this.lblTongTrongLuong.Text = "Tổng trọng lượng: 0 kg";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(122, 20);
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số lượng";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 24);
            this.textBox1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Đơn giá";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 245);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(290, 24);
            this.textBox2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 560);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điều khiển Quản lý Đơn giao hàng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLoaiVanChuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTrongLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThanhTien;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblThoiGian;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSoLuong;
        private System.Windows.Forms.ToolStripStatusLabel lblTongTrongLuong;
        private System.Windows.Forms.ToolStripStatusLabel lblTongTien;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}
