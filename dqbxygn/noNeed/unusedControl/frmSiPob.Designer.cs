namespace LiaoChengZYSI.Control
{
    partial class frmSiPob
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbMedicalType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDiagNose = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.gbPatient = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.gbInput = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbXianZhong = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbUseCardType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucSiPatientInfoOutPatient2 = new LiaoChengZYSI.Control.ucSiPatientInfoOutPatient();
            this.gbPatient.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(139, 23);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "医保类别";
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
            this.cmbMedicalType.Location = new System.Drawing.Point(198, 20);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(121, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbMedicalType.TabIndex = 0;
            this.cmbMedicalType.Tag = "";
            this.cmbMedicalType.ToolBarUse = false;
            this.cmbMedicalType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMedicalType_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(377, 23);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "诊断名称";
            // 
            // cmbDiagNose
            // 
            this.cmbDiagNose.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDiagNose.FormattingEnabled = true;
            this.cmbDiagNose.IsEnter2Tab = false;
            this.cmbDiagNose.IsFlat = false;
            this.cmbDiagNose.IsLike = true;
            this.cmbDiagNose.IsListOnly = false;
            this.cmbDiagNose.IsPopForm = true;
            this.cmbDiagNose.IsShowCustomerList = false;
            this.cmbDiagNose.IsShowID = false;
            this.cmbDiagNose.Location = new System.Drawing.Point(436, 20);
            this.cmbDiagNose.Name = "cmbDiagNose";
            this.cmbDiagNose.PopForm = null;
            this.cmbDiagNose.ShowCustomerList = false;
            this.cmbDiagNose.ShowID = false;
            this.cmbDiagNose.Size = new System.Drawing.Size(126, 20);
            this.cmbDiagNose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDiagNose.TabIndex = 1;
            this.cmbDiagNose.Tag = "";
            this.cmbDiagNose.ToolBarUse = false;
            this.cmbDiagNose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDiagNose_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(442, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.neuButton2_Click);
            // 
            // gbPatient
            // 
            this.gbPatient.Controls.Add(this.ucSiPatientInfoOutPatient2);
            this.gbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPatient.Location = new System.Drawing.Point(0, 0);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Size = new System.Drawing.Size(756, 275);
            this.gbPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbPatient.TabIndex = 0;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "医保患者信息";
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.cmbXianZhong);
            this.gbInput.Controls.Add(this.neuLabel3);
            this.gbInput.Controls.Add(this.cmbUseCardType);
            this.gbInput.Controls.Add(this.label1);
            this.gbInput.Controls.Add(this.cmbMedicalType);
            this.gbInput.Controls.Add(this.cmbDiagNose);
            this.gbInput.Controls.Add(this.neuLabel1);
            this.gbInput.Controls.Add(this.neuLabel2);
            this.gbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(753, 93);
            this.gbInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "输入信息";
            // 
            // cmbXianZhong
            // 
            this.cmbXianZhong.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbXianZhong.FormattingEnabled = true;
            this.cmbXianZhong.IsEnter2Tab = false;
            this.cmbXianZhong.IsFlat = false;
            this.cmbXianZhong.IsLike = true;
            this.cmbXianZhong.IsListOnly = false;
            this.cmbXianZhong.IsPopForm = true;
            this.cmbXianZhong.IsShowCustomerList = false;
            this.cmbXianZhong.IsShowID = false;
            this.cmbXianZhong.Location = new System.Drawing.Point(198, 59);
            this.cmbXianZhong.Name = "cmbXianZhong";
            this.cmbXianZhong.PopForm = null;
            this.cmbXianZhong.ShowCustomerList = false;
            this.cmbXianZhong.ShowID = false;
            this.cmbXianZhong.Size = new System.Drawing.Size(121, 20);
            this.cmbXianZhong.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbXianZhong.TabIndex = 6;
            this.cmbXianZhong.Tag = "";
            this.cmbXianZhong.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(139, 62);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "险种标志";
            // 
            // cmbUseCardType
            // 
            this.cmbUseCardType.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbUseCardType.FormattingEnabled = true;
            this.cmbUseCardType.IsEnter2Tab = false;
            this.cmbUseCardType.IsFlat = false;
            this.cmbUseCardType.IsLike = true;
            this.cmbUseCardType.IsListOnly = false;
            this.cmbUseCardType.IsPopForm = true;
            this.cmbUseCardType.IsShowCustomerList = false;
            this.cmbUseCardType.IsShowID = false;
            this.cmbUseCardType.Location = new System.Drawing.Point(436, 59);
            this.cmbUseCardType.Name = "cmbUseCardType";
            this.cmbUseCardType.PopForm = null;
            this.cmbUseCardType.ShowCustomerList = false;
            this.cmbUseCardType.ShowID = false;
            this.cmbUseCardType.Size = new System.Drawing.Size(126, 20);
            this.cmbUseCardType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbUseCardType.TabIndex = 4;
            this.cmbUseCardType.Tag = "";
            this.cmbUseCardType.ToolBarUse = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "使用医保卡类型";
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.gbPatient);
            this.neuPanel1.Location = new System.Drawing.Point(3, 5);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(756, 275);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 6;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.gbInput);
            this.neuPanel2.Location = new System.Drawing.Point(6, 295);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(753, 93);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.btnOK);
            this.neuPanel3.Controls.Add(this.btnCancel);
            this.neuPanel3.Location = new System.Drawing.Point(6, 394);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(753, 42);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 0;
            // 
            // ucSiPatientInfoOutPatient2
            // 
            this.ucSiPatientInfoOutPatient2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSiPatientInfoOutPatient2.Location = new System.Drawing.Point(3, 17);
            this.ucSiPatientInfoOutPatient2.Name = "ucSiPatientInfoOutPatient2";
            this.ucSiPatientInfoOutPatient2.Patient = null;
            this.ucSiPatientInfoOutPatient2.Size = new System.Drawing.Size(750, 255);
            this.ucSiPatientInfoOutPatient2.TabIndex = 0;
            // 
            // frmSiPob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 444);
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSiPob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择医疗类别";
            this.Load += new System.EventHandler(this.frmSiPob_Load);
            this.gbPatient.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMedicalType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDiagNose;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbUseCardType;
        private System.Windows.Forms.Label label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbXianZhong;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private ucSiPatientInfoOutPatient ucSiPatientInfoOutPatient2;
    }
}