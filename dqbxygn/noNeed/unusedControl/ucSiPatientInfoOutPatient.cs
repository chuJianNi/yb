using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LiaoChengZYSI.Control
{
    public partial class ucSiPatientInfoOutPatient : UserControl
    {
        public ucSiPatientInfoOutPatient()
        {
            InitializeComponent();
        } 
        #region 变量
        private Neusoft.HISFC.Models.Registration.Register patient = null;
        private string chooseType = string.Empty;
        #endregion
        #region 属性

        /// <summary>
        /// 患者

        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                if (DesignMode) return;
                this.patient = value;
                if (value != null)
                    this.SetPatientInfo();
            }
        }
        #endregion
        protected int SetPatientInfo()
        {
            this.txtName.Text = patient.Name;
            this.txtSex.Text = patient.Sex.Name;
            this.txtSiBegionDate.Text = patient.SIMainInfo.SiBegionDate.ToShortDateString();
            this.txtSSN.Text = this.patient.SSN;
            this.txtMedicalType.Text = patient.SIMainInfo.PersonType.Name;

            this.txtICCardCode.Text = this.patient.SIMainInfo.ICCardCode;
            this.txtBirthday.Text = this.patient.Birthday.ToShortDateString();
            this.txtCorporationID.Text = this.patient.CompanyName;
            this.txtIDCard.Text = this.patient.SIMainInfo.CardOrgID;
            this.txtIndividualBalance.Text = this.patient.SIMainInfo.IndividualBalance.ToString();
            this.txtBirthPlace.Text = this.patient.SIMainInfo.BirthPlace;
            if (this.patient.SIMainInfo.IsOffice)
            {
                this.txtIsGWY.Text = "是";
            }
            else
            {
                this.txtIsGWY.Text = "否";
            }
            //社保局编号
            this.txtSSD.Text = this.patient.SIMainInfo.ProceatePcNo;
            //是否为异地人员

            if (this.patient.SIMainInfo.User01 == "1")
            {
                this.txtOutlander.Text = "是";
            }
            else
            {
                this.txtOutlander.Text = "否";
            }
            //门诊结算类型
            if (this.patient.SIMainInfo.EmplType == "1")
            {
                this.txtBalanceType.Text = "普通门诊";
            }
            else if (this.patient.SIMainInfo.EmplType == "0")
            {
                this.txtBalanceType.Text = "消费个人账户";
            }
            else
            {
                this.txtBalanceType.Text = "";
            }
            //社保结构类型
            this.txtPersonType.Text = patient.SIMainInfo.PersonType.Name;
            //灰名单原因

            this.txtGrayList.Text = this.patient.SIMainInfo.SpecialWorkKind.Name;

            this.txtOutlander.Text = this.patient.SIMainInfo.AnotherCity.ID;//是否为异地人员

            return 1;
        }


    }
}
