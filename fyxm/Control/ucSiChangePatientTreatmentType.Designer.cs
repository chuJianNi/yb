namespace LiaoChengZYSI.Control
{
    partial class ucSiChangePatientTreatmentType
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvSIPatientList = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuFpEnter1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuFpEnter1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbForeTreatment = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtTreatLevel = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.Label();
            this.txtInDate = new System.Windows.Forms.Label();
            this.txtPactName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtPatientNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTreatmentType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).BeginInit();
            this.neuPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.tvSIPatientList);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(200, 484);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // tvSIPatientList
            // 
            this.tvSIPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSIPatientList.HideSelection = false;
            this.tvSIPatientList.Location = new System.Drawing.Point(0, 0);
            this.tvSIPatientList.Name = "tvSIPatientList";
            this.tvSIPatientList.Size = new System.Drawing.Size(200, 484);
            this.tvSIPatientList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvSIPatientList.TabIndex = 0;
            this.tvSIPatientList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSIPatientList_AfterSelect);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuPanel4);
            this.neuPanel2.Controls.Add(this.neuPanel3);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(200, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(825, 484);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.neuFpEnter1);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel4.Location = new System.Drawing.Point(0, 211);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(825, 273);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 1;
            // 
            // neuFpEnter1
            // 
            this.neuFpEnter1.About = "3.0.2004.2005";
            this.neuFpEnter1.AccessibleDescription = "neuFpEnter1, Sheet1, Row 0, Column 0, ";
            this.neuFpEnter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(213)))));
            this.neuFpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuFpEnter1.EditModePermanent = true;
            this.neuFpEnter1.EditModeReplace = true;
            this.neuFpEnter1.Location = new System.Drawing.Point(0, 0);
            this.neuFpEnter1.Name = "neuFpEnter1";
            this.neuFpEnter1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuFpEnter1.SelectNone = false;
            this.neuFpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuFpEnter1_Sheet1});
            this.neuFpEnter1.ShowListWhenOfFocus = false;
            this.neuFpEnter1.Size = new System.Drawing.Size(825, 273);
            this.neuFpEnter1.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuFpEnter1.TextTipAppearance = tipAppearance3;
            // 
            // neuFpEnter1_Sheet1
            // 
            this.neuFpEnter1_Sheet1.Reset();
            this.neuFpEnter1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuFpEnter1_Sheet1.ColumnCount = 12;
            this.neuFpEnter1_Sheet1.RowCount = 0;
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "住院流水号";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "合同单位";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "住院科室";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "住院日期";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "前治疗方式";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "前限价等级";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "后治疗方式";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "后限价等级";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "变更确认人";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "变更确认日期";
            this.neuFpEnter1_Sheet1.Columns.Get(0).Label = "住院流水号";
            this.neuFpEnter1_Sheet1.Columns.Get(0).Width = 104F;
            this.neuFpEnter1_Sheet1.Columns.Get(2).Label = "性别";
            this.neuFpEnter1_Sheet1.Columns.Get(2).Width = 44F;
            this.neuFpEnter1_Sheet1.Columns.Get(4).Label = "住院科室";
            this.neuFpEnter1_Sheet1.Columns.Get(4).Width = 110F;
            this.neuFpEnter1_Sheet1.Columns.Get(5).CellType = textCellType9;
            this.neuFpEnter1_Sheet1.Columns.Get(5).Label = "住院日期";
            this.neuFpEnter1_Sheet1.Columns.Get(5).Width = 99F;
            this.neuFpEnter1_Sheet1.Columns.Get(6).Label = "前治疗方式";
            this.neuFpEnter1_Sheet1.Columns.Get(6).Width = 140F;
            this.neuFpEnter1_Sheet1.Columns.Get(7).CellType = textCellType10;
            this.neuFpEnter1_Sheet1.Columns.Get(7).Label = "前限价等级";
            this.neuFpEnter1_Sheet1.Columns.Get(7).Width = 75F;
            this.neuFpEnter1_Sheet1.Columns.Get(8).Label = "后治疗方式";
            this.neuFpEnter1_Sheet1.Columns.Get(8).Width = 124F;
            this.neuFpEnter1_Sheet1.Columns.Get(9).CellType = textCellType11;
            this.neuFpEnter1_Sheet1.Columns.Get(9).Label = "后限价等级";
            this.neuFpEnter1_Sheet1.Columns.Get(9).Width = 75F;
            this.neuFpEnter1_Sheet1.Columns.Get(10).Label = "变更确认人";
            this.neuFpEnter1_Sheet1.Columns.Get(10).Width = 75F;
            this.neuFpEnter1_Sheet1.Columns.Get(11).CellType = textCellType12;
            this.neuFpEnter1_Sheet1.Columns.Get(11).Label = "变更确认日期";
            this.neuFpEnter1_Sheet1.Columns.Get(11).Width = 114F;
            this.neuFpEnter1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuFpEnter1.SetActiveViewport(0, 1, 0);
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.cmbForeTreatment);
            this.neuPanel3.Controls.Add(this.txtTreatLevel);
            this.neuPanel3.Controls.Add(this.txtDeptName);
            this.neuPanel3.Controls.Add(this.txtInDate);
            this.neuPanel3.Controls.Add(this.txtPactName);
            this.neuPanel3.Controls.Add(this.txtName);
            this.neuPanel3.Controls.Add(this.txtPatientNo);
            this.neuPanel3.Controls.Add(this.label2);
            this.neuPanel3.Controls.Add(this.label1);
            this.neuPanel3.Controls.Add(this.groupBox2);
            this.neuPanel3.Controls.Add(this.groupBox1);
            this.neuPanel3.Controls.Add(this.neuLabel7);
            this.neuPanel3.Controls.Add(this.neuLabel6);
            this.neuPanel3.Controls.Add(this.neuLabel5);
            this.neuPanel3.Controls.Add(this.neuLabel4);
            this.neuPanel3.Controls.Add(this.neuLabel1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel3.Location = new System.Drawing.Point(0, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(825, 211);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 0;
            // 
            // cmbForeTreatment
            // 
            this.cmbForeTreatment.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbForeTreatment.Enabled = false;
            this.cmbForeTreatment.FormattingEnabled = true;
            this.cmbForeTreatment.IsEnter2Tab = false;
            this.cmbForeTreatment.IsFlat = false;
            this.cmbForeTreatment.IsLike = true;
            this.cmbForeTreatment.IsListOnly = false;
            this.cmbForeTreatment.IsPopForm = true;
            this.cmbForeTreatment.IsShowCustomerList = false;
            this.cmbForeTreatment.IsShowID = false;
            this.cmbForeTreatment.Location = new System.Drawing.Point(311, 105);
            this.cmbForeTreatment.Name = "cmbForeTreatment";
            this.cmbForeTreatment.PopForm = null;
            this.cmbForeTreatment.ShowCustomerList = false;
            this.cmbForeTreatment.ShowID = false;
            this.cmbForeTreatment.Size = new System.Drawing.Size(210, 20);
            this.cmbForeTreatment.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbForeTreatment.TabIndex = 22;
            this.cmbForeTreatment.Tag = "";
            this.cmbForeTreatment.ToolBarUse = false;
            // 
            // txtTreatLevel
            // 
            this.txtTreatLevel.AutoSize = true;
            this.txtTreatLevel.Location = new System.Drawing.Point(671, 108);
            this.txtTreatLevel.Name = "txtTreatLevel";
            this.txtTreatLevel.Size = new System.Drawing.Size(0, 12);
            this.txtTreatLevel.TabIndex = 21;
            // 
            // txtDeptName
            // 
            this.txtDeptName.AutoSize = true;
            this.txtDeptName.Location = new System.Drawing.Point(671, 71);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(0, 12);
            this.txtDeptName.TabIndex = 20;
            // 
            // txtInDate
            // 
            this.txtInDate.AutoSize = true;
            this.txtInDate.Location = new System.Drawing.Point(79, 108);
            this.txtInDate.Name = "txtInDate";
            this.txtInDate.Size = new System.Drawing.Size(0, 12);
            this.txtInDate.TabIndex = 18;
            // 
            // txtPactName
            // 
            this.txtPactName.AutoSize = true;
            this.txtPactName.Location = new System.Drawing.Point(480, 71);
            this.txtPactName.Name = "txtPactName";
            this.txtPactName.Size = new System.Drawing.Size(0, 12);
            this.txtPactName.TabIndex = 17;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(311, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 12);
            this.txtName.TabIndex = 16;
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.AutoSize = true;
            this.txtPatientNo.Location = new System.Drawing.Point(79, 71);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.Size = new System.Drawing.Size(0, 12);
            this.txtPatientNo.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "限价等级：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "治疗方式：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbTreatmentType);
            this.groupBox2.Controls.Add(this.neuLabel2);
            this.groupBox2.Controls.Add(this.btOK);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 79);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "治疗方式的修改";
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
            this.cmbTreatmentType.Location = new System.Drawing.Point(96, 38);
            this.cmbTreatmentType.Name = "cmbTreatmentType";
            this.cmbTreatmentType.PopForm = null;
            this.cmbTreatmentType.ShowCustomerList = false;
            this.cmbTreatmentType.ShowID = false;
            this.cmbTreatmentType.Size = new System.Drawing.Size(177, 20);
            this.cmbTreatmentType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbTreatmentType.TabIndex = 10;
            this.cmbTreatmentType.Tag = "";
            this.cmbTreatmentType.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(25, 41);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 8;
            this.neuLabel2.Text = "治疗方式：";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(370, 36);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 9;
            this.btOK.Text = "确  定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucQueryInpatientNo1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 59);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(16, 20);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(198, 27);
            this.ucQueryInpatientNo1.TabIndex = 0;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(600, 71);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(65, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 6;
            this.neuLabel7.Text = "住院科室：";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(409, 71);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(65, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 5;
            this.neuLabel6.Text = "合同单位：";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(264, 71);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 4;
            this.neuLabel5.Text = "姓名：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(8, 108);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 3;
            this.neuLabel4.Text = "住院日期：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(20, 71);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "住院号：";
            // 
            // ucSiChangePatientTreatmentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucSiChangePatientTreatmentType";
            this.Size = new System.Drawing.Size(1025, 484);
            this.Load += new System.EventHandler(this.ucSiChangePatientTreatmentType_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).EndInit();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvSIPatientList;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuFpEnter1;
        private FarPoint.Win.Spread.SheetView neuFpEnter1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private System.Windows.Forms.Button btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtPatientNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
        private System.Windows.Forms.Label txtTreatLevel;
        private System.Windows.Forms.Label txtDeptName;
        private System.Windows.Forms.Label txtInDate;
        private System.Windows.Forms.Label txtPactName;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTreatmentType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbForeTreatment;

    }
}