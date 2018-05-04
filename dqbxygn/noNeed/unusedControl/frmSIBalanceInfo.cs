using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LiaoChengZYSI.Control
{
    public partial class frmSIBalanceInfo : Form
    {
        public frmSIBalanceInfo()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 总金额
        /// </summary>
        private decimal totCost = 0m;
        /// <summary>
        /// 统筹金额
        /// </summary>
        private decimal pubCost = 0m;
        /// <summary>
        /// 自费金额
        /// </summary>
        private decimal ownCost = 0m;
        /// <summary>
        /// 账户金额
        /// </summary>
        private decimal payCost = 0m;
        /// <summary>
        /// 医疗补助
        /// </summary>
        private decimal officalCost = 0m;
        /// <summary>
        /// 医院担负
        /// </summary>
        private decimal hosCost = 0m;
        /// <summary>
        /// 结算流水号
        /// </summary>
        private string balanceSeq = "";
        /// <summary>
        /// 患者实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        private Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();

        private LiaoChengZYSI.LocalManager localMgr = new LocalManager();
        #endregion

        #region 属性
        /// <summary>
        /// 患者实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            set
            {
                this.patient = value;
            }
            get
            {
                return this.patient;
            }
        }
        #endregion
        /// <summary>
        /// 确认信息录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.CheckValue() != 1)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else if (this.SetValue() != 1)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            //lyk
            else if (this.CheckPubCost() != 1)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            //增加人员类型

            else if (this.localMgr.UpdatePatientMedicalType(this.patient.ID, this.cmbPatientType.SelectedItem.ID) < 0)

            {
                this.DialogResult = DialogResult.Cancel;
            }
            //lyk
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();        
        }
        /// <summary>
        /// 取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 赋值
        /// </summary>
        public int SetValue()
        {
            try
            {
                this.patient.SIMainInfo.TotCost = this.totCost;
                this.patient.SIMainInfo.PubCost = this.pubCost;
                this.patient.SIMainInfo.OwnCost = this.ownCost;
                this.patient.SIMainInfo.PayCost = this.payCost;
                this.patient.SIMainInfo.OfficalCost = this.officalCost;
                this.patient.SIMainInfo.MedicalType.ID = this.cmbPatientType.SelectedItem.ID;
            }
            catch (Exception e)
            {
                MessageBox.Show("赋值出现异常  " + e.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 检查数据的合法性
        /// </summary>
        public int CheckValue()
        {
            this.totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text.Trim());
            this.pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text.Trim());
            this.ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOwnCost.Text.Trim());
            this.payCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPayCost.Text.Trim());
            this.officalCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOfficialCost.Text.Trim());
            this.hosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtHosCost.Text.Trim());
            this.balanceSeq = this.txtBalanceSeq.Text.Trim();

            if (this.totCost != this.pubCost + this.ownCost + this.payCost || this.totCost <= 0 || this.ownCost < 0)
            {
                MessageBox.Show("录入的费用明细和总费用不等！请检查录入的费用信息是否有误！", "友情提示");

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 加载界面获取光标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSIBalanceInfo_Load(object sender, EventArgs e)
        {
            ArrayList alType = this.consMgr.GetList("INPATIENT_SITYPE");
            if (alType != null && alType.Count > 0)
            {
                this.cmbPatientType.AddItems(alType);
            }
            if (string.IsNullOrEmpty(patient.PVisit.MedicalType.ID))
            {
                this.cmbPatientType.Tag = patient.PVisit.MedicalType.ID;
            }
            else
            {
                this.cmbPatientType.SelectedIndex = 0;
            }

            //this.txtTotCost.Focus();
            this.txtTotCost.Text = this.patient.FT.TotCost.ToString();
            this.txtOwnCost.Text = this.patient.FT.TotCost.ToString();
            this.txtTotCost.Enabled = false;
            this.txtOwnCost.Enabled = false;
            this.txtPubCost.Focus();
        }

        private void txtOwnCost_KeyUp(object sender, KeyEventArgs e)
        {
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text);
            decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOwnCost.Text);

            if (e.KeyCode != Keys.Enter)
            {
                this.txtPubCost.Text = (totCost - ownCost).ToString();
            }
        }

        /// <summary>
        /// 检查数据的合法性
        /// </summary>
        /// 
        //lyk
        public int CheckPubCost()
        {
            this.pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text.Trim());

            if (this.pubCost == 0)
            {
                if (MessageBox.Show("录入医保统筹金额为0，是否继续？", "友情提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return -1;
                }
            }
            return 1;
        }

        private void txtPubCost_KeyUp(object sender, KeyEventArgs e)
        {
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text);
            decimal pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text);
            if (e.KeyCode != Keys.Enter)
            {
                this.txtOwnCost.Text = (totCost - pubCost).ToString();
            }

        }

        private void txtPayCost_KeyUp(object sender, KeyEventArgs e)
        {
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text);
            decimal pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text);
            decimal payCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPayCost.Text);
            if (e.KeyCode != Keys.Enter)
            {
                this.txtOwnCost.Text = (totCost - pubCost - payCost).ToString();
            }
        }

        private void txtOfficialCost_KeyUp(object sender, KeyEventArgs e)
        {
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text);
            decimal pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text);
            decimal payCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPayCost.Text);
            decimal officialCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOfficialCost.Text);
            if (e.KeyCode != Keys.Enter)
            {
                this.txtOwnCost.Text = (totCost - pubCost - payCost - officalCost).ToString();
            }
        }
    }
}
