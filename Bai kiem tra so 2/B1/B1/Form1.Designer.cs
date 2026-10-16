namespace B1
{
    partial class frmDeviceManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtDeviceId = new TextBox();
            label1 = new Label();
            txtDeviceName = new TextBox();
            cboCategory = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            numQuantity = new NumericUpDown();
            label5 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvDevices = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtDeviceId
            // 
            txtDeviceId.Location = new Point(130, 38);
            txtDeviceId.Name = "txtDeviceId";
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(151, 27);
            txtDeviceId.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 45);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã thiết bị: ";
            // 
            // txtDeviceName
            // 
            txtDeviceName.Location = new Point(130, 93);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.Size = new Size(151, 27);
            txtDeviceName.TabIndex = 2;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(130, 153);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(151, 28);
            cboCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 100);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên thiết bị: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 156);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 5;
            label3.Text = "Loại: ";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 207);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(151, 27);
            txtPrice.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 218);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 7;
            label4.Text = "Giá: ";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(131, 261);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(150, 27);
            numQuantity.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 268);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 9;
            label5.Text = "Tổng số lượng:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(40, 325);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(158, 325);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(158, 380);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 12;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(40, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvDevices
            // 
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(402, 53);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.Size = new Size(726, 393);
            dgvDevices.TabIndex = 14;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmDeviceManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1153, 529);
            Controls.Add(dgvDevices);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(numQuantity);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboCategory);
            Controls.Add(txtDeviceName);
            Controls.Add(label1);
            Controls.Add(txtDeviceId);
            Name = "frmDeviceManager";
            Text = "Form1";
            Load += frmDeviceManager_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDeviceId;
        private Label label1;
        private TextBox txtDeviceName;
        private ComboBox cboCategory;
        private Label label2;
        private Label label3;
        private TextBox txtPrice;
        private Label label4;
        private NumericUpDown numQuantity;
        private Label label5;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvDevices;
        private ErrorProvider errorProvider1;
    }
}
