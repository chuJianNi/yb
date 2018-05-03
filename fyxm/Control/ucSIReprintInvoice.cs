using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LiaoChengZYSI.Control
{
    public partial class ucSIReprintInvoice : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSIReprintInvoice()
        {
            InitializeComponent();
        }
        #region
        private LocalManager localManager = new LocalManager();
        /// <summary>
        /// ��Ա���
        /// </summary>
        private static string personID = string.Empty;

        /// <summary>
        /// ҽԺ����
        /// </summary>
        private static string hospitalNO = string.Empty;

        /// <summary>
        /// ����
        /// </summary>
        private static string passWord = string.Empty;

        /// <summary>
        /// ҽ������
        /// </summary>
        private static string doctorNO = string.Empty;

        /// <summary>
        /// Social Security Department
        /// </summary>
        private static string SSD = string.Empty;

        /// <summary>
        /// ���˱�ʶ�����ҽ�����ţ�סԺ��������
        /// </summary>
        private string MCardNo = string.Empty;

        /// <summary>
        /// ��������
        /// </summary>
        private static string DeptNO = string.Empty;
        /// <summary>
        /// ��������--������Ⱥ��
        /// </summary>
        private string tsrqDeptNO = string.Empty;
        /// <summary>
        /// ��ǰ����Ա
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject oper = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;

        #endregion
        private sei.CoClass_com4hisClass seiInterfaceProxy = new sei.CoClass_com4hisClass();

        private int connInit()
        {
            try
            {
                //��½id
                if (string.IsNullOrEmpty(personID))
                {
                    personID = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "personID", @".\dllinit.ini");
                }
                //ҽԺ����
                if (string.IsNullOrEmpty(hospitalNO))
                {
                    hospitalNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "hospitalID", @".\dllinit.ini");
                }
                //����
                if (string.IsNullOrEmpty(passWord))
                {
                    passWord = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "passWord", @".\dllinit.ini");
                }
                //�籣�ֱ���
                if (string.IsNullOrEmpty(SSD))
                {
                    SSD = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "SSD", @".\dllinit.ini");
                }
                //ҽ������
                if (string.IsNullOrEmpty(doctorNO))
                {
                    doctorNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "DoctorNO", @".\dllinit.ini");
                }
                //����
                if (string.IsNullOrEmpty(DeptNO))
                {
                    DeptNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "DeptNO", @".\dllinit.ini");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
                return -1;
            }
            if (seiInterfaceProxy.icconect == false)
            {
                if (string.IsNullOrEmpty(personID))
                {
                    #region ��ȡ��ǰ����Ա��Ϣ
                    Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
                    if (string.IsNullOrEmpty(passWord))
                    {
                        if (this.localManager.getPWD(userManager.Operator.ID, ref passWord) == -1)
                        {
                            MessageBox.Show( "��ȡ������Ϣ����");
                            return -1;
                        }
                    }
                    personID = userManager.Operator.ID.Substring(2);
                    #endregion
                }
                //��ʼ���ӿ�����
                if (seiInterfaceProxy.init(personID, hospitalNO, passWord) != 0)
                {
                    MessageBox.Show ( "��ʼ���ӿ�ʧ��!");
                    return -1;
                }
            }
            return 1;
        }
        private void neuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string balanceno = this.neuTextBox1.Text.Trim();
            if (e.KeyChar == (char)Keys.Enter&&!string.IsNullOrEmpty(balanceno))
            {
                this.connInit();
                if (seiInterfaceProxy.print_mzdj(balanceno) != 0)
                {
                    MessageBox.Show("��ӡ��Ʊʧ�ܣ�\n"+seiInterfaceProxy.get_errtext());
                    return;
                }
            }
        }

    }
}
