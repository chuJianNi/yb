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
    public partial class frmSiPob : Form
    {
        #region 变量
        private Neusoft.HISFC.Models.Registration.Register patient =null;
        public string medicalType = string.Empty;
        LocalManager localManager = new LocalManager();
        public Boolean isInDiagnose = true;//是否门诊挂号诊断
        #endregion

        #region 属性

        public Neusoft.HISFC.Models.Registration.Register Patient
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

                    this.ucSiPatientInfoOutPatient2.Patient = patient;
                }
            }
        }
        #endregion

        #region 方法
        public frmSiPob()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化医疗类别

        /// </summary>
        /// <returns></returns>
        protected int InitMedicalType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "0";
            obj.Name = "取卡片基本信息";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "住    院";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "4";
            obj.Name = "门诊大病";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "5";
            obj.Name = "意外伤害";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "6";
            obj.Name = "普通门诊";
            al.Add(obj);

            this.cmbMedicalType.AddItems(al);

            if (this.patient.SIMainInfo.MedicalType.ID != null && this.patient.SIMainInfo.MedicalType.ID != "")
            {
                this.cmbMedicalType.Tag = this.patient.SIMainInfo.MedicalType.ID;
            }
          
            return 1;
        }

        /// <summary>
        /// 初始化使用医保卡类型
        /// </summary>
        /// <returns></returns>
        public int  initUsercardType()
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
        /// 添加诊断信息
        /// </summary>
        /// <returns></returns>
        protected int InitDiagnose()
        {
            ArrayList diagnoseList = new ArrayList();
            if (this.Patient.SIMainInfo.MedicalType.ID == "2" || this.Patient.SIMainInfo.MedicalType.ID == "4")
            {
                if (this.localManager.DisjoinChar(patient.SIMainInfo.Disease.Name, ref diagnoseList) == -1)
                {
                    MessageBox.Show("拆分门诊诊断失败 " + this.localManager.Err, "错误提示");
                    return -1;
                }
                if (diagnoseList.Count == 0 || diagnoseList == null)
                {
                    MessageBox.Show("获取门诊诊断失败", "错误提示" + this.localManager.Err);
                    return -1;
                }
                this.cmbDiagNose.AddItems(diagnoseList);
            }


            if (diagnoseList != null && diagnoseList.Count > 0)
            {
                this.cmbDiagNose.AddItems(diagnoseList);
            }
            return 1;
        }
        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //医疗类别不能为空
            if (this.cmbMedicalType.SelectedIndex<0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别") );
                this.cmbMedicalType.Focus();
                return -1;
            }
         
            if (this.cmbUseCardType.Tag.ToString() == "" || this.cmbUseCardType.Tag == null)
            {
                MessageBox.Show("请选择医保卡类型");
                this.cmbUseCardType.Focus();
                return -1;
            }

            if (this.cmbXianZhong.SelectedIndex < 0)
            {
                MessageBox.Show("请选择医疗险种类别");
                this.cmbXianZhong.Focus();
                return -1;
            }

            if(this.cmbMedicalType.SelectedItem.ID=="4"&&this.cmbDiagNose.SelectedIndex<0)
            {
                MessageBox.Show("门诊大病患者请选择病种！");
                return -1;
            }

            if (this.cmbMedicalType.SelectedItem.ID == "5" || this.cmbMedicalType.SelectedItem.ID == "6")
            {
                if (this.cmbXianZhong.SelectedItem.ID == "D"||this.cmbXianZhong.SelectedItem.ID=="E")
                {
                    if (this.cmbDiagNose.SelectedIndex < 0)
                    {
                        MessageBox.Show("工商或生育患者必须选择病种");
                        return -1;
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 赋值

        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            this.patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.Tag.ToString();


            this.patient.SIMainInfo.InDiagnose.ID = this.cmbDiagNose.Tag.ToString();
            this.patient.SIMainInfo.InDiagnose.Name = this.cmbDiagNose.Text.Trim();
            this.patient.SIMainInfo.OutDiagnose.ID = this.cmbDiagNose.Tag.ToString();
            this.patient.SIMainInfo.OutDiagnose.Name = this.cmbDiagNose.Text.ToString();
           

            this.patient.SIMainInfo.SpecialCare.ID = this.cmbUseCardType.Tag.ToString();//使用医保卡类型

            this.patient.SIMainInfo.SpecialCare.Name = this.cmbXianZhong.SelectedItem.ID.ToString();//险种标志

            return 1;

        }
        #endregion

        #region 事件
        private void frmSiPob_Load(object sender, EventArgs e)
        {
            if (this.InitMedicalType() == -1)
            {
                MessageBox.Show("初始化医疗统筹类别失败");
                return;
            }
            if (this.InitDiagnose() == -1)
            {
                MessageBox.Show("初始化疾病列表失败");
                return;
            }
            if (this.InitXianZhong() == -1)
            {
                MessageBox.Show("初始化险种标志失败");
                return;
            }
            if (this.initUsercardType() == -1)
            {
                MessageBox.Show("初始化使用医保卡类型失败");
                return;
            }
        }


        private void neuButton1_Click(object sender, EventArgs e)
        {
            //校验
            if (this.Valid() == 1)
            {
                if (this.GetValue() == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }      
        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

     

        private void cmbMedicalType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (cmbDiagNose.Enabled)
                {
                    cmbDiagNose.Focus();
                }
                else
                {
                    btnOK.Focus();
                }
            }
        }

        private void cmbDiagNose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                btnOK.Focus();
            }
        }
    }
        
}