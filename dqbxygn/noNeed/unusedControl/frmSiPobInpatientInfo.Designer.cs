namespace LiaoChengZYSI.Control
{
    partial class frmSiPobInpatientInfo
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
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lblType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtInDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbXianZhong = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbTreatmentType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbUseCardType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbInType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbMedicalType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lblDiagnose = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.ucSiPatientInfoInPatient2 = new LiaoChengZYSI.Control.ucSiPatientInfoInPatient();
            this.neuPanel2.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btnCancel);
            this.neuPanel2.Controls.Add(this.btnOK);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 450);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(797, 43);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(411, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(241, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(127, 38);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 12);
            this.lblType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblType.TabIndex = 0;
            this.lblType.Text = "住院类别";
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.neuLabel5);
            this.neuGroupBox2.Controls.Add(this.dtInDate);
            this.neuGroupBox2.Controls.Add(this.neuLabel4);
            this.neuGroupBox2.Controls.Add(this.cmbXianZhong);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Controls.Add(this.cmbTreatmentType);
            this.neuGroupBox2.Controls.Add(this.cmbUseCardType);
            this.neuGroupBox2.Controls.Add(this.neuLabel1);
            this.neuGroupBox2.Controls.Add(this.cmbInType);
            this.neuGroupBox2.Controls.Add(this.cmbMedicalType);
            this.neuGroupBox2.Controls.Add(this.lblDiagnose);
            this.neuGroupBox2.Controls.Add(this.lblType);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 291);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(797, 202);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 5;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "输入信息";
            // 
            // neuLabel5
            // 
            this.neuLabel5.ForeColor = System.Drawing.Color.Red;
            this.neuLabel5.Location = new System.Drawing.Point(340, 127);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(402, 29);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 11;
            this.neuLabel5.Text = "注：如果有现金中途结算的话，请将入院日期填写为中途结算的终止日期；若没有，则不用修改！";
            // 
            // dtInDate
            // 
            this.dtInDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInDate.IsEnter2Tab = false;
            this.dtInDate.Location = new System.Drawing.Point(186, 127);
            this.dtInDate.Name = "dtInDate";
            this.dtInDate.Size = new System.Drawing.Size(138, 21);
            this.dtInDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtInDate.TabIndex = 10;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(127, 133);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 9;
            this.neuLabel4.Text = "住院日期";
            // 
            // cmbXianZhong
            // 
            this.cmbXianZhong.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbXianZhong.FormattingEnabled = true;
            this.cmbXianZhong.IsEnter2Tab = false;
            this.cmbXianZhong.IsFlat = false;
            this.cmbXianZhong.IsLike = true;
            this.cmbXianZhong.IsListOnly = false;
            this.cmbXianZhong.IsPopForm = true;
            this.cmbXianZhong.IsShowCustomerList = false;
            this.cmbXianZhong.IsShowID = false;
            this.cmbXianZhong.Location = new System.Drawing.Point(186, 102);
            this.cmbXianZhong.Name = "cmbXianZhong";
            this.cmbXianZhong.PopForm = null;
            this.cmbXianZhong.ShowCustomerList = false;
            this.cmbXianZhong.ShowID = false;
            this.cmbXianZhong.Size = new System.Drawing.Size(130, 20);
            this.cmbXianZhong.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbXianZhong.TabIndex = 8;
            this.cmbXianZhong.Tag = "";
            this.cmbXianZhong.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(103, 105);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(77, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 7;
            this.neuLabel3.Text = "医疗险种标志";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(398, 71);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 6;
            this.neuLabel2.Text = "治疗方式";
            // 
            // cmbTreatmentType
            // 
            this.cmbTreatmentType.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbTreatmentType.FormattingEnabled = true;
            this.cmbTreatmentType.IsEnter2Tab = false;
            this.cmbTreatmentType.IsFlat = false;
            this.cmbTreatmentType.IsLike = true;
            this.cmbTreatmentType.IsListOnly = false;
            this.cmbTreatmentType.IsPopForm = true;
            this.cmbTreatmentType.IsShowCustomerList = false;
            this.cmbTreatmentType.IsShowID = false;
            this.cmbTreatmentType.Location = new System.Drawing.Point(457, 68);
            this.cmbTreatmentType.Name = "cmbTreatmentType";
            this.cmbTreatmentType.PopForm = null;
            this.cmbTreatmentType.ShowCustomerList = false;
            this.cmbTreatmentType.ShowID = false;
            this.cmbTreatmentType.Size = new System.Drawing.Size(140, 20);
            this.cmbTreatmentType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbTreatmentType.TabIndex = 5;
            this.cmbTreatmentType.Tag = "";
            this.cmbTreatmentType.ToolBarUse = false;
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
            this.cmbUseCardType.Location = new System.Drawing.Point(186, 68);
            this.cmbUseCardType.Name = "cmbUseCardType";
            this.cmbUseCardType.PopForm = null;
            this.cmbUseCardType.ShowCustomerList = false;
            this.cmbUseCardType.ShowID = false;
            this.cmbUseCardType.Size = new System.Drawing.Size(130, 20);
            this.cmbUseCardType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbUseCardType.TabIndex = 4;
            this.cmbUseCardType.Tag = "";
            this.cmbUseCardType.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(91, 71);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(89, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "使用医保卡类型";
            // 
            // cmbInType
            // 
            this.cmbInType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInType.FormattingEnabled = true;
            this.cmbInType.IsEnter2Tab = false;
            this.cmbInType.IsFlat = false;
            this.cmbInType.IsLike = true;
            this.cmbInType.IsListOnly = false;
            this.cmbInType.IsPopForm = true;
            this.cmbInType.IsShowCustomerList = false;
            this.cmbInType.IsShowID = false;
            this.cmbInType.Location = new System.Drawing.Point(457, 35);
            this.cmbInType.Name = "cmbInType";
            this.cmbInType.PopForm = null;
            this.cmbInType.ShowCustomerList = false;
            this.cmbInType.ShowID = false;
            this.cmbInType.Size = new System.Drawing.Size(140, 20);
            this.cmbInType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbInType.TabIndex = 1;
            this.cmbInType.Tag = "";
            this.cmbInType.ToolBarUse = false;
            this.cmbInType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInType_KeyDown);
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
            this.cmbMedicalType.Location = new System.Drawing.Point(186, 35);
            this.cmbMedicalType.Name = "cmbMedicalType";
            this.cmbMedicalType.PopForm = null;
            this.cmbMedicalType.ShowCustomerList = false;
            this.cmbMedicalType.ShowID = false;
            this.cmbMedicalType.Size = new System.Drawing.Size(130, 20);
            this.cmbMedicalType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbMedicalType.TabIndex = 0;
            this.cmbMedicalType.Tag = "";
            this.cmbMedicalType.ToolBarUse = false;
            this.cmbMedicalType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMedicalType_KeyDown);
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Location = new System.Drawing.Point(398, 38);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(53, 12);
            this.lblDiagnose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDiagnose.TabIndex = 2;
            this.lblDiagnose.Text = "住院方式";
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuGroupBox1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(797, 291);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.ucSiPatientInfoInPatient2);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(797, 291);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "患者信息";
            // 
            // ucSiPatientInfoInPatient2
            // 
            this.ucSiPatientInfoInPatient2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSiPatientInfoInPatient2.Location = new System.Drawing.Point(3, 17);
            this.ucSiPatientInfoInPatient2.Name = "ucSiPatientInfoInPatient2";
            this.ucSiPatientInfoInPatient2.Patient = null;
            this.ucSiPatientInfoInPatient2.Size = new System.Drawing.Size(791, 271);
            this.ucSiPatientInfoInPatient2.TabIndex = 0;
            // 
            // frmSiPobInpatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 493);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSiPobInpatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSiPobInpatientInfo";
            this.Load += new System.EventHandler(this.frmSiPobInpatientInfo_Load);
            this.neuPanel2.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblType;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMedicalType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDiagnose;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbUseCardType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTreatmentType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbXianZhong;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private ucSiPatientInfoInPatient ucSiPatientInfoInPatient2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtInDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;

    }
}