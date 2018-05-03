using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiaoChengZYSI.Control
{
    public partial class frmShowSIInfo : Form
    {
        //�ӿ���
        Process process = new Process();
        //�Һ�ʵ��
        Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();

        public frmShowSIInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���ڼ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShowSIInfo_Load(object sender, EventArgs e)
        {
            //����
            //this.Clear();
            //������û�����Ϣ
            this.ReadCard();
            //���뻼����Ϣ
            this.ucSiPatientInfoOutPatient1.Patient = register;
        }
        /// <summary>
        /// �������ҽ��������Ϣ

        /// </summary>
        /// <returns></returns>
        private void ReadCard()
        {
            long returnValue = process.Connect();
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg);
                return;
            }
            returnValue = process.GetRegInfoOutpatient(register);
            if (returnValue < 0)
            {
                MessageBox.Show(process.ErrMsg); 
                return;
            }
           // this.SetPatientInfo(register);
            process.Disconnect();

        }
    }
}