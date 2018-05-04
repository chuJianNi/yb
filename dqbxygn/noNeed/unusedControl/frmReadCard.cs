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
    public partial class frmReadCard : Form
    {
        public frmReadCard()
        {
            InitializeComponent();
        }


        #region 变量

        private Neusoft.HISFC.Models.Registration.Register patient = null;
        private Neusoft.HISFC.Models.RADT.PatientInfo pInfo = null;
        //
        LocalManager lm = new LocalManager();
        //初始化为门诊--0
        private string hostType = "0";

        #endregion

        #region 属性

        /// <summary>
        /// 挂号实体
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }
        /// <summary>
        /// 住院实体
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PInfo
        {
            get
            {
                return pInfo;
            }
            set
            {
                pInfo = value;
            }
        }
        /// <summary>
        /// 门诊--0 or 住院--1 
        /// </summary>
        public string HostType
        {
            get
            {
                return this.hostType;
            }
            set
            {
                this.hostType = value;
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.InitReadCardType();

            this.InitMedicalType();
        }

        /// <summary>
        /// 初始化医疗统筹类别
        /// </summary>
        private int InitMedicalType()
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

        
            return 1;
        }

        /// <summary>
        /// 初始化读卡方法
        /// </summary>
        /// <returns></returns>
        private int InitReadCardType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "1";
            obj1.Name = "有卡办理";
            al.Add(obj1);

            obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "2";
            obj1.Name = "无卡办理";
            al.Add(obj1);

            this.cmbReadCardType.AddItems(al);

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
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择医疗类别"));
                this.cmbMedicalType.Focus();
                return -1;
            }

            if (this.cmbReadCardType.SelectedIndex < 0)
            {
                MessageBox.Show("请选择读卡方式，选择有卡或者无卡");
                return -1;
            }

            if (this.cmbReadCardType.SelectedItem.ID == "2")
            {
                if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                {
                    MessageBox.Show("无卡人员必须输入姓名，此姓名必须和医保登记时的一致！");
                    return -1;
                }

                if(string.IsNullOrEmpty(this.txtIDCardNo.Text.Trim()))
                {
                    MessageBox.Show("无卡人员必须输入社会保障号，或者身份证号！");
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 赋值
        /// </summary>
        /// <returns></returns>
        private void GetValue()
        {
            if (this.cmbReadCardType.SelectedItem.ID == "2")
            {
                if (this.hostType == "0")//门诊
                {
                    this.patient.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;//存储读卡方式 1是有卡 2是无卡

                    this.Patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                    this.patient.IDCard = this.txtIDCardNo.Text.Trim();
                    this.patient.Name = this.txtName.Text.Trim();
                }
                else//住院
                {
                    this.pInfo.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;//存储读卡方式 1是有卡 2是无卡

                    this.pInfo.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                    this.pInfo.IDCard = this.txtIDCardNo.Text.Trim();
                    this.pInfo.Name = this.txtName.Text.Trim();
                }
            }
            else
            {
                if (this.hostType == "0")//门诊
                {
                    this.patient.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;
                    this.Patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                }
                else//住院
                {
                    this.pInfo.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;
                    this.pInfo.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                }
            }
        }
        #endregion

        #region 事件

        private void frmReadCard_Load(object sender, EventArgs e)
        {
            //初始化
            this.Init();

            this.cmbReadCardType.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //校验
            if (this.Valid() == 1)
            {
                this.GetValue();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        #endregion

        /// <summary>
        /// 选择读卡类型时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbReadCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbReadCardType.SelectedIndex > -1)
            {
                if (this.cmbReadCardType.SelectedItem.ID == "1")
                {
                    this.txtName.Enabled = false;
                    this.txtIDCardNo.Enabled = false;
                }
                else
                {
                    this.txtName.Enabled = true;
                    this.txtIDCardNo.Enabled = true;

                    if (this.hostType == "0")//门诊
                    {
                        this.txtName.Text = this.patient.Name;
                    }
                    else//住院
                    {
                        this.txtName.Text = this.pInfo.Name;
                    }
                }
            }
        }

        #region 回车跳转事件
        private void cmbReadCardType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbMedicalType.Focus();
            }
        }

        private void cmbMedicalType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtName.Enabled == true)
                {
                    this.txtName.Focus();
                }
                else
                {
                    this.btnSave.Focus();
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtIDCardNo.Enabled == true)
                {
                    this.txtIDCardNo.Focus();
                }
                else
                {
                    this.btnSave.Focus();
                }
            }
        }

        private void txtIDCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSave.Focus();
            }
        }

        #endregion
    }
}