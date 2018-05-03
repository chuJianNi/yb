namespace LiaoChengZYSI.Control
{
    partial class frmReadCard
    {
        /// <summary>
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。

        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbReadCardType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btnCancle = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.cmbMedicalType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lblReadCardType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.cmbReadCardType);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.label1);
            this.neuGroupBox1.Controls.Add(this.txtIDCardNo);
            this.neuGroupBox1.Controls.Add(this.btnCancle);
            this.neuGroupBox1.Controls.Add(this.cmbMedicalType);
            this.neuGroupBox1.Controls.Add(this.btnSave);
            this.neuGroupBox1.Controls.Add(this.lblReadCardType);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(570, 240);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "读卡类型选择";
            // 
            // txtName
            // 
            this.txtName.IsEnter2Tab = false;
            this.txtName.Location = new System.Drawing.Point(121, 132);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(139, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 7;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(56, 135);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(59, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 6;
            this.neuLabel2.Text = "姓    名:";
            // 
            // cmbReadCardType
            // 
            this.cmbReadCardType.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbReadCardType.FormattingEnabled = true;
            this.cmbReadCardType.IsEnter2Tab = false;
            this.cmbReadCardType.IsFlat = false;
            this.cmbReadCardType.IsLike = true;
            this.cmbReadCardType.IsListOnly = false;
            this.cmbReadCardType.IsPopForm = true;
            this.cmbReadCardType.IsShowCustomerList = false;
            this.cmbReadCardType.IsShowID = false;
            this.cmbReadCardType.Location = new System.Drawing.Point(121, 58);
            this.cmbReadCardType.Name = "cmbReadCardType";
            this.cmbReadCardType.PopForm = null;
            this.cmbReadCardType.ShowCustomerList = false;
            this.cmbReadCardType.ShowID = false;
            this.cmbReadCardType.Size = new System.Drawing.Size(139, 20);
            this.cmbReadCardType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbReadCardType.TabIndex = 5;
            this.cmbReadCardType.Tag = "";
            this.cmbReadCardType.ToolBarUse = false;
            this.cmbReadCardType.SelectedIndexChanged += new System.EventHandler(this.cmbReadCardType_SelectedIndexChanged);
            this.cmbReadCardType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReadCardType_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(56, 61);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(59, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "读卡类型:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "社会保障号:";
            // 
            // txtIDCardNo
            // 
            this.txtIDCardNo.IsEnter2Tab = false;
            this.txtIDCardNo.Location = new System.Drawing.Point(382, 132);
            this.txtIDCardNo.Name = "txtIDCardNo";
            this.txtIDCardNo.Size = new System.Drawing.Size(139, 21);
            this.txtIDCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtIDCardNo.TabIndex = 2;
            this.txtIDCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDCardNo_KeyDown);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(340, 202);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "取消";
            this.btnCancle.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // cmbMedicalType
            // 
            this.cmbMedicalType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbMedicalType.FormattingEnabled = true;
            this.cmbMedicalType.IsEnter2Tab = false;
            this.cmbMedicalType.IsFlat = false;
            this.cmbMedicalType.IsLike = true;
            this.cmbMedicalType.IsListOnly = false;
            this.cmbMedicalType.IsPopForm = true;
            this.cmbMedicalType.IsShowCustomerList = false;
            this.cmbMedicalType.IsShowID = false;
            this.cmbMedicalType.Location = new System.Drawing.Point(382, 56);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(139, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbMedicalType.TabIndex = 1;
            this.cmbMedicalType.Tag = "";
            this.cmbMedicalType.ToolBarUse = false;
            this.cmbMedicalType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMedicalType_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(172, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "确定";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblReadCardType
            // 
            this.lblReadCardType.AutoSize = true;
            this.lblReadCardType.Location = new System.Drawing.Point(293, 61);
            this.lblReadCardType.Name = "lblReadCardType";
            this.lblReadCardType.Size = new System.Drawing.Size(83, 12);
            this.lblReadCardType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblReadCardType.TabIndex = 0;
            this.lblReadCardType.Text = "医疗统筹类别:";
            // 
            // frmReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 240);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "frmReadCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReadCard";
            this.Load += new System.EventHandler(this.frmReadCard_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMedicalType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblReadCardType;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancle;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private System.Windows.Forms.Label label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtIDCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbReadCardType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
    }
}