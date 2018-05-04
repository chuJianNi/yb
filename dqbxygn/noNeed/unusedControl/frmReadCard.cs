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


        #region ����

        private Neusoft.HISFC.Models.Registration.Register patient = null;
        private Neusoft.HISFC.Models.RADT.PatientInfo pInfo = null;
        //
        LocalManager lm = new LocalManager();
        //��ʼ��Ϊ����--0
        private string hostType = "0";

        #endregion

        #region ����

        /// <summary>
        /// �Һ�ʵ��
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
        /// סԺʵ��
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
        /// ����--0 or סԺ--1 
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

        #region ˽�з���

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void Init()
        {
            this.InitReadCardType();

            this.InitMedicalType();
        }

        /// <summary>
        /// ��ʼ��ҽ��ͳ�����
        /// </summary>
        private int InitMedicalType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "0";
            obj.Name = "ȡ��Ƭ������Ϣ";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "ס    Ժ";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "4";
            obj.Name = "�����";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "5";
            obj.Name = "�����˺�";
            al.Add(obj);

            obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "6";
            obj.Name = "��ͨ����";
            al.Add(obj);

            this.cmbMedicalType.AddItems(al);

        
            return 1;
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        /// <returns></returns>
        private int InitReadCardType()
        {
            ArrayList al = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "1";
            obj1.Name = "�п�����";
            al.Add(obj1);

            obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "2";
            obj1.Name = "�޿�����";
            al.Add(obj1);

            this.cmbReadCardType.AddItems(al);

            return 1;
        }
        /// <summary>
        /// У��
        /// </summary>
        /// <returns></returns>
        public int Valid()
        {
            //ҽ�������Ϊ��
            if (this.cmbMedicalType.SelectedIndex<0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("��ѡ��ҽ�����"));
                this.cmbMedicalType.Focus();
                return -1;
            }

            if (this.cmbReadCardType.SelectedIndex < 0)
            {
                MessageBox.Show("��ѡ�������ʽ��ѡ���п������޿�");
                return -1;
            }

            if (this.cmbReadCardType.SelectedItem.ID == "2")
            {
                if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                {
                    MessageBox.Show("�޿���Ա�������������������������ҽ���Ǽ�ʱ��һ�£�");
                    return -1;
                }

                if(string.IsNullOrEmpty(this.txtIDCardNo.Text.Trim()))
                {
                    MessageBox.Show("�޿���Ա����������ᱣ�Ϻţ��������֤�ţ�");
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// ��ֵ
        /// </summary>
        /// <returns></returns>
        private void GetValue()
        {
            if (this.cmbReadCardType.SelectedItem.ID == "2")
            {
                if (this.hostType == "0")//����
                {
                    this.patient.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;//�洢������ʽ 1���п� 2���޿�

                    this.Patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                    this.patient.IDCard = this.txtIDCardNo.Text.Trim();
                    this.patient.Name = this.txtName.Text.Trim();
                }
                else//סԺ
                {
                    this.pInfo.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;//�洢������ʽ 1���п� 2���޿�

                    this.pInfo.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                    this.pInfo.IDCard = this.txtIDCardNo.Text.Trim();
                    this.pInfo.Name = this.txtName.Text.Trim();
                }
            }
            else
            {
                if (this.hostType == "0")//����
                {
                    this.patient.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;
                    this.Patient.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                }
                else//סԺ
                {
                    this.pInfo.SIMainInfo.Duty = this.cmbReadCardType.SelectedItem.ID;
                    this.pInfo.SIMainInfo.MedicalType.ID = this.cmbMedicalType.SelectedItem.ID;
                }
            }
        }
        #endregion

        #region �¼�

        private void frmReadCard_Load(object sender, EventArgs e)
        {
            //��ʼ��
            this.Init();

            this.cmbReadCardType.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //У��
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
        /// ѡ���������ʱ����
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

                    if (this.hostType == "0")//����
                    {
                        this.txtName.Text = this.patient.Name;
                    }
                    else//סԺ
                    {
                        this.txtName.Text = this.pInfo.Name;
                    }
                }
            }
        }

        #region �س���ת�¼�
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