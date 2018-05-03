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
        /// 人员编号
        /// </summary>
        private static string personID = string.Empty;

        /// <summary>
        /// 医院编码
        /// </summary>
        private static string hospitalNO = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        private static string passWord = string.Empty;

        /// <summary>
        /// 医生编码
        /// </summary>
        private static string doctorNO = string.Empty;

        /// <summary>
        /// Social Security Department
        /// </summary>
        private static string SSD = string.Empty;

        /// <summary>
        /// 病人标识，门诊：医保卡号，住院：病例号
        /// </summary>
        private string MCardNo = string.Empty;

        /// <summary>
        /// 开方科室
        /// </summary>
        private static string DeptNO = string.Empty;
        /// <summary>
        /// 开方科室--特殊人群用
        /// </summary>
        private string tsrqDeptNO = string.Empty;
        /// <summary>
        /// 当前操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject oper = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;

        #endregion
        private sei.CoClass_com4hisClass seiInterfaceProxy = new sei.CoClass_com4hisClass();

        private int connInit()
        {
            try
            {
                //登陆id
                if (string.IsNullOrEmpty(personID))
                {
                    personID = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "personID", @".\dllinit.ini");
                }
                //医院编码
                if (string.IsNullOrEmpty(hospitalNO))
                {
                    hospitalNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "hospitalID", @".\dllinit.ini");
                }
                //密码
                if (string.IsNullOrEmpty(passWord))
                {
                    passWord = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "passWord", @".\dllinit.ini");
                }
                //社保局编码
                if (string.IsNullOrEmpty(SSD))
                {
                    SSD = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "SSD", @".\dllinit.ini");
                }
                //医生编码
                if (string.IsNullOrEmpty(doctorNO))
                {
                    doctorNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("JNSI", "DoctorNO", @".\dllinit.ini");
                }
                //科室
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
                    #region 获取当前操作员信息
                    Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
                    if (string.IsNullOrEmpty(passWord))
                    {
                        if (this.localManager.getPWD(userManager.Operator.ID, ref passWord) == -1)
                        {
                            MessageBox.Show( "获取密码信息出错！");
                            return -1;
                        }
                    }
                    personID = userManager.Operator.ID.Substring(2);
                    #endregion
                }
                //初始化接口连接
                if (seiInterfaceProxy.init(personID, hospitalNO, passWord) != 0)
                {
                    MessageBox.Show ( "初始化接口失败!");
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
                    MessageBox.Show("打印发票失败！\n"+seiInterfaceProxy.get_errtext());
                    return;
                }
            }
        }

    }
}
