namespace LiaoChengZYSI.Control
{
    partial class frmSIBalanceInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtPubCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtPayCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtOwnCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtHosCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOfficialCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBalanceSeq = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPatientType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "总 金 额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "统筹金额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(274, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "医保卡支付金额：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(325, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "自费金额：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(329, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "医院担负：";
            this.label8.Visible = false;
            // 
            // txtTotCost
            // 
            this.txtTotCost.AllowNegative = false;
            this.txtTotCost.Enabled = false;
            this.txtTotCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTotCost.Interval = 1500;
            this.txtTotCost.IsAutoRemoveDecimalZero = false;
            this.txtTotCost.IsEnter2Tab = true;
            this.txtTotCost.IsStopPaste = false;
            this.txtTotCost.IsTimerDel = false;
            this.txtTotCost.IsUseTimer = false;
            this.txtTotCost.Location = new System.Drawing.Point(121, 127);
            this.txtTotCost.Name = "txtTotCost";
            this.txtTotCost.NumericPrecision = 10;
            this.txtTotCost.NumericScaleOnFocus = 2;
            this.txtTotCost.NumericScaleOnLostFocus = 2;
            this.txtTotCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtTotCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtTotCost.Size = new System.Drawing.Size(146, 26);
            this.txtTotCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtTotCost.TabIndex = 1;
            this.txtTotCost.Text = "0.00";
            this.txtTotCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotCost.UseGroupSeperator = true;
            this.txtTotCost.ZeroIsValid = true;
            // 
            // txtPubCost
            // 
            this.txtPubCost.AllowNegative = false;
            this.txtPubCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPubCost.Interval = 1500;
            this.txtPubCost.IsAutoRemoveDecimalZero = false;
            this.txtPubCost.IsEnter2Tab = true;
            this.txtPubCost.IsStopPaste = false;
            this.txtPubCost.IsTimerDel = false;
            this.txtPubCost.IsUseTimer = false;
            this.txtPubCost.Location = new System.Drawing.Point(121, 176);
            this.txtPubCost.Name = "txtPubCost";
            this.txtPubCost.NumericPrecision = 10;
            this.txtPubCost.NumericScaleOnFocus = 2;
            this.txtPubCost.NumericScaleOnLostFocus = 2;
            this.txtPubCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPubCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtPubCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPubCost.Size = new System.Drawing.Size(146, 26);
            this.txtPubCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPubCost.TabIndex = 3;
            this.txtPubCost.Text = "0.00";
            this.txtPubCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPubCost.UseGroupSeperator = true;
            this.txtPubCost.ZeroIsValid = true;
            this.txtPubCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPubCost_KeyUp);
            // 
            // txtPayCost
            // 
            this.txtPayCost.AllowNegative = false;
            this.txtPayCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPayCost.Interval = 1500;
            this.txtPayCost.IsAutoRemoveDecimalZero = false;
            this.txtPayCost.IsEnter2Tab = true;
            this.txtPayCost.IsStopPaste = false;
            this.txtPayCost.IsTimerDel = false;
            this.txtPayCost.IsUseTimer = false;
            this.txtPayCost.Location = new System.Drawing.Point(412, 176);
            this.txtPayCost.Name = "txtPayCost";
            this.txtPayCost.NumericPrecision = 10;
            this.txtPayCost.NumericScaleOnFocus = 2;
            this.txtPayCost.NumericScaleOnLostFocus = 2;
            this.txtPayCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPayCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtPayCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPayCost.Size = new System.Drawing.Size(146, 26);
            this.txtPayCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPayCost.TabIndex = 4;
            this.txtPayCost.Text = "0.00";
            this.txtPayCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayCost.UseGroupSeperator = true;
            this.txtPayCost.ZeroIsValid = true;
            this.txtPayCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPayCost_KeyUp);
            // 
            // txtOwnCost
            // 
            this.txtOwnCost.AllowNegative = false;
            this.txtOwnCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOwnCost.Interval = 1500;
            this.txtOwnCost.IsAutoRemoveDecimalZero = false;
            this.txtOwnCost.IsEnter2Tab = true;
            this.txtOwnCost.IsStopPaste = false;
            this.txtOwnCost.IsTimerDel = false;
            this.txtOwnCost.IsUseTimer = false;
            this.txtOwnCost.Location = new System.Drawing.Point(412, 129);
            this.txtOwnCost.Name = "txtOwnCost";
            this.txtOwnCost.NumericPrecision = 10;
            this.txtOwnCost.NumericScaleOnFocus = 2;
            this.txtOwnCost.NumericScaleOnLostFocus = 2;
            this.txtOwnCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOwnCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtOwnCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtOwnCost.Size = new System.Drawing.Size(146, 26);
            this.txtOwnCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOwnCost.TabIndex = 2;
            this.txtOwnCost.Text = "0.00";
            this.txtOwnCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOwnCost.UseGroupSeperator = true;
            this.txtOwnCost.ZeroIsValid = true;
            this.txtOwnCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOwnCost_KeyUp);
            // 
            // txtHosCost
            // 
            this.txtHosCost.AllowNegative = false;
            this.txtHosCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHosCost.Interval = 1500;
            this.txtHosCost.IsAutoRemoveDecimalZero = false;
            this.txtHosCost.IsEnter2Tab = true;
            this.txtHosCost.IsStopPaste = false;
            this.txtHosCost.IsTimerDel = false;
            this.txtHosCost.IsUseTimer = false;
            this.txtHosCost.Location = new System.Drawing.Point(400, 242);
            this.txtHosCost.Name = "txtHosCost";
            this.txtHosCost.NumericPrecision = 10;
            this.txtHosCost.NumericScaleOnFocus = 2;
            this.txtHosCost.NumericScaleOnLostFocus = 2;
            this.txtHosCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHosCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtHosCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtHosCost.Size = new System.Drawing.Size(146, 26);
            this.txtHosCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtHosCost.TabIndex = 6;
            this.txtHosCost.Text = "0.00";
            this.txtHosCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHosCost.UseGroupSeperator = true;
            this.txtHosCost.Visible = false;
            this.txtHosCost.ZeroIsValid = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(26, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "请准确录入医保的结算信息！";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(29, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(512, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "录入的总金额=自费金额+统筹金额+医保卡支付金额  不允许出现负金额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "大病支付额:";
            // 
            // txtOfficialCost
            // 
            this.txtOfficialCost.AllowNegative = false;
            this.txtOfficialCost.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOfficialCost.Interval = 1500;
            this.txtOfficialCost.IsAutoRemoveDecimalZero = false;
            this.txtOfficialCost.IsEnter2Tab = true;
            this.txtOfficialCost.IsStopPaste = false;
            this.txtOfficialCost.IsTimerDel = false;
            this.txtOfficialCost.IsUseTimer = false;
            this.txtOfficialCost.Location = new System.Drawing.Point(121, 225);
            this.txtOfficialCost.Name = "txtOfficialCost";
            this.txtOfficialCost.NumericPrecision = 10;
            this.txtOfficialCost.NumericScaleOnFocus = 2;
            this.txtOfficialCost.NumericScaleOnLostFocus = 2;
            this.txtOfficialCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOfficialCost.SendKey = System.Windows.Forms.Keys.Return;
            this.txtOfficialCost.SetRange = new System.Drawing.Size(-1, -1);
            this.txtOfficialCost.Size = new System.Drawing.Size(146, 26);
            this.txtOfficialCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOfficialCost.TabIndex = 5;
            this.txtOfficialCost.Text = "0.00";
            this.txtOfficialCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOfficialCost.UseGroupSeperator = true;
            this.txtOfficialCost.ZeroIsValid = true;
            this.txtOfficialCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOfficialCost_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "医保结算流水号：";
            this.label9.Visible = false;
            // 
            // txtBalanceSeq
            // 
            this.txtBalanceSeq.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBalanceSeq.Interval = 1500;
            this.txtBalanceSeq.IsEnter2Tab = false;
            this.txtBalanceSeq.IsStopPaste = false;
            this.txtBalanceSeq.IsTimerDel = false;
            this.txtBalanceSeq.IsUseTimer = false;
            this.txtBalanceSeq.Location = new System.Drawing.Point(137, 269);
            this.txtBalanceSeq.Name = "txtBalanceSeq";
            this.txtBalanceSeq.SendKey = System.Windows.Forms.Keys.Return;
            this.txtBalanceSeq.Size = new System.Drawing.Size(238, 26);
            this.txtBalanceSeq.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBalanceSeq.TabIndex = 7;
            this.txtBalanceSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceSeq.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确  定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取  消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(12, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "患者类型：";
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbPatientType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.IsEnter2Tab = false;
            this.cmbPatientType.IsFlat = false;
            this.cmbPatientType.IsLeftPad = false;
            this.cmbPatientType.IsLike = true;
            this.cmbPatientType.IsListOnly = false;
            this.cmbPatientType.IsPopForm = true;
            this.cmbPatientType.IsShowCustomerList = false;
            this.cmbPatientType.IsShowID = false;
            this.cmbPatientType.Location = new System.Drawing.Point(121, 76);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.PopForm = null;
            this.cmbPatientType.ShowCustomerList = false;
            this.cmbPatientType.ShowID = false;
            this.cmbPatientType.Size = new System.Drawing.Size(146, 24);
            this.cmbPatientType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbPatientType.TabIndex = 20;
            this.cmbPatientType.Tag = "";
            this.cmbPatientType.ToolBarUse = false;
            // 
            // frmSIBalanceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 316);
            this.Controls.Add(this.cmbPatientType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBalanceSeq);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtOfficialCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHosCost);
            this.Controls.Add(this.txtOwnCost);
            this.Controls.Add(this.txtPayCost);
            this.Controls.Add(this.txtPubCost);
            this.Controls.Add(this.txtTotCost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSIBalanceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医保结算信息录入";
            this.Load += new System.EventHandler(this.frmSIBalanceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtTotCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPubCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPayCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtOwnCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtHosCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtOfficialCost;
        private System.Windows.Forms.Label label9;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBalanceSeq;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPatientType;
    }
}