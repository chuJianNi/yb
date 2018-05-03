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
    public partial class frmSiPobInpatientInfo : Form
    {
        public frmSiPobInpatientInfo()
        {
            InitializeComponent();
        }

        #region 变量
        private Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        public string medicalType = string.Empty;
        LocalManager lm = new LocalManager();
        #endregion

        #region 属性

        /// <summary>
        /// 住院患者基本信息

        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
                if (!DesignMode)
                {
                    this.ucSiPatientInfoInPatient2.Patient = patient;
                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化住院类别

        /// </summary>
        /// <returns></returns>
        protected int InitMedicalType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "住院";
            al.Add(obj);
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "2";
            obj1.Name = "家床";
            al.Add(obj1);
            this.cmbMedicalType.AddItems(al);
            this.cmbMedicalType.SelectedIndex = 0;
            //this.cmbMedicalType.Tag = "1";
            return 1;
        }

        /// <summary>
        /// 初始化使用医保卡类型
        /// </summary>
        public int InitUsecardType()
        {
            try
            {
                ArrayList useCardList = new ArrayList();
                Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
                obj1.ID = "0";
                obj1.Name = "不使用医保卡";
                useCardList.Add(obj1);

                Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
                obj2.ID = "1";
                obj2.Name = "银行卡";
                useCardList.Add(obj2);

                Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
                obj3.ID = "2";
                obj3.Name = "CPU卡";
                useCardList.Add(obj3);

                Neusoft.FrameWork.Models.NeuObject obj4 = new Neusoft.FrameWork.Models.NeuObject();
                obj4.ID = "3";
                obj4.Name = "济南医保卡";
                useCardList.Add(obj4);

                this.cmbUseCardType.AddItems(useCardList);

                this.cmbUseCardType.SelectedIndex = useCardList.Count - 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("初始化医保卡类型列表失败 " + e.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 初始化险种类别
        /// </summary>
        /// <returns></returns>
        public int InitXianZhong()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "C";
            obj.Name = "医疗";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "D";
            obj.Name = "工商";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "E";
            obj.Name = "生育";
            al.Add(obj);

            this.cmbXianZhong.AddItems(al);

            return 1;
        }
        /// <summary>
        /// 初始化住院方式
        /// </summary>
        /// <returns></returns>
        protected int InitInType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "普通住院";
            al.Add(obj);
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "6";
            obj1.Name = "市内转院";
            al.Add(obj1);
            this.cmbInType.AddItems(al);
            if (string.IsNullOrEmpty(this.Patient.SIMainInfo.AnotherCity.Name)||this.patient.SIMainInfo.AnotherCity.Name.Equals("*"))
            {
                this.cmbInType.SelectedIndex = 0;
            }
            else
            {
                this.cmbInType.SelectedIndex = 1;
            }
            //this.cmbInType.Tag = "1";
            return 1;
        }


        public int InitTreatmentType()
        {
            this.cmbTreatmentType.AddItems(this.constantManager.GetList("TreatmentType"));

            return 1;
        }

        /// <summary>
        /// 输入值校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //住院类别
            if (this.cmbMedicalType.SelectedIndex <0)
            {
                MessageBox.Show("请为患者【" + this.Patient.Name + "】 选择住院类别");
                return -1;
            }

            //住院方式
            if (this.cmbInType.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(this.Patient.SIMainInfo.AnotherCity.Name)&&!this.patient.SIMainInfo.AnotherCity.Name.Equals("*"))
                {
                    if (this.cmbInType.SelectedItem.ID != "6")
                    {
                        MessageBox.Show("患者【" + this.Patient.Name + "】 由【" + this.Patient.SIMainInfo.AnotherCity.Name + "】医院转出，住院方式请选择【市内转院】");
                        return -1;
                    }
                }
                else
                {
                    if (this.cmbInType.SelectedItem.ID != "1")
                    {
                        MessageBox.Show("患者【" + this.Patient.Name + "】 不是转院患者，住院方式请选择【普通住院】");
                        return -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("请为患者【" + this.Patient.Name + "】 选择住院方式");
                return -1;
            }

            //使用医保卡类型
            if (this.cmbUseCardType.SelectedIndex < 0)
            {
                MessageBox.Show("请为患者【" + this.Patient.Name + "】 选择使用医保卡类型");
                return -1;
            }

            //治疗方式
            if (this.cmbTreatmentType.SelectedIndex < 0)
            {
                MessageBox.Show("请为患者【" + this.Patient.Name + "】 选择在院治疗方式");
                return -1;
            }

            if (this.cmbXianZhong.SelectedIndex < 0)
            {
                MessageBox.Show("请为患者【" + this.Patient.Name + "】 选择险种类别");
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 赋值

        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            this.patient.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.cmbMedicalType.Tag.ToString());//住院类别
            this.patient.SIMainInfo.EmplType = this.cmbInType.Tag.ToString();//住院方式
            this.patient.SIMainInfo.SpecialCare.ID = this.cmbUseCardType.SelectedItem.ID;//使用医保卡类型
            this.patient.SIMainInfo.SpecialCare.Name = this.cmbXianZhong.SelectedItem.ID;//医疗险种标志

            this.patient.ExtendFlag = ((Neusoft.HISFC.Models.Base.Const)(this.cmbTreatmentType.SelectedItem)).ID;//治疗方式编码

            this.patient.ExtendFlag1 = ((Neusoft.HISFC.Models.Base.Const)(this.cmbTreatmentType.SelectedItem)).Name;//治疗方式描述
            this.patient.ExtendFlag2 = ((Neusoft.HISFC.Models.Base.Const)(this.cmbTreatmentType.SelectedItem)).Memo;//限价价格
            this.patient.PVisit.InTime = dtInDate.Value;

            return 1;
        }

        private void frmSiPobInpatientInfo_Load(object sender, EventArgs e)
        {
            if (this.InitMedicalType() == -1)
            {
                MessageBox.Show("初始化医疗统筹类别失败");
                return;
            }
            if (this.InitInType() == -1)
            {
                MessageBox.Show("初始化住院类别失败");
                return;
            }
            if (this.InitUsecardType() == -1)
            {
                MessageBox.Show("初始化使用医保卡类型失败");
                return;
            }
            if (this.InitTreatmentType() == -1)
            {
                MessageBox.Show("初始化治疗方式列表失败");
                return;
            }
            this.dtInDate.Value = this.patient.PVisit.InTime;
            this.cmbMedicalType.Focus();
            if (this.InitXianZhong() == -1)
            {
                MessageBox.Show("初始化险种列表失败");
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Valid() == 1)
            {
                if (this.GetValue() == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbMedicalType_KeyDown(object sender, KeyEventArgs e)
        {
            this.cmbInType.Focus();
        }

        private void cmbInType_KeyDown(object sender, KeyEventArgs e)
        {
            this.btnOK.Focus();
        }
    }
}