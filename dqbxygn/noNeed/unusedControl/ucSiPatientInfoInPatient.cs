using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LiaoChengZYSI.Control
{
    public partial class ucSiPatientInfoInPatient : UserControl
    {
        public ucSiPatientInfoInPatient()
        {
            InitializeComponent();
        }

        #region 变量
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        #endregion
        #region 属性

        /// <summary>
        /// 患者

        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
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
            if (patient.Sex.ID == "F")
            {
                this.txtSex.Text = "女";
            }
            else
            {
                this.txtSex.Text = "男";
            }
            this.txtSiBegionDate.Text = patient.SIMainInfo.SiBegionDate.ToShortDateString();
            this.txtRegNo.Text = this.patient.SSN;
            this.txtSSD.Text = patient.SIMainInfo.ProceatePcNo;
            this.txtICCardCode.Text = this.patient.SSN;
            this.txtBirthday.Text = this.patient.Birthday.ToShortDateString();
            this.txtIDCard.Text = this.patient.SIMainInfo.CardOrgID;
            this.txtIndividualBalance.Text = this.patient.SIMainInfo.IndividualBalance.ToString();
            this.txtCorporationID.Text = this.patient.CompanyName;
            this.txtBirthPlace.Text = this.patient.SIMainInfo.BirthPlace;
            if (this.patient.SIMainInfo.IsOffice)
            {
                this.txtIsGWY.Text = "是";
            }
            else
            {
                this.txtIsGWY.Text = "否";
            }
            txtGrayList.Text = this.patient.SIMainInfo.SpecialWorkKind.Name;
            this.txtMedicalType.Text = this.patient.SIMainInfo.ApplySequence;
            this.txtSupportType.Text = this.patient.SIMainInfo.Fund.Name;

            this.txtPersonType.Text = this.patient.SIMainInfo.PersonType.Name;

            if(this.patient.SIMainInfo.ApplyType.ID=="1")
            {
                this.txtInHos15.Text="有";
            }
            else
            {
                this.txtInHos15.Text="无";
            }

            this.txtOutlander.Text = this.patient.SIMainInfo.AnotherCity.ID;

            return 1;
        }


    }
}
