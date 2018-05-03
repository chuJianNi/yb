using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.FrameWork.WinForms.Classes;
using Neusoft.HISFC.Components.InpatientFee.Controls;

namespace LiaoChengZYSI.Control
{
    /// <summary>
    /// ucPrepay<br></br>
    /// [功能描述: 结算控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>

    public partial class ucPrepaySI : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucPrepaySI()
        {
            this.InitializeComponent();
        }

        #region "变量"
        /// <summary>
        /// 患者基本信息综合实体

        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 银行表{68EAA727-3B06-470b-A7E1-1B5001755A9C}
        /// </summary>
        protected ArrayList alBanks = new ArrayList();
        /// <summary>
        /// 入出转integrate层

        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        
        /// <summary>
        /// 住院费用业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        
        /// <summary>
        /// 住院费用组合业务层


        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
 
        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 控制参数业务层{68EAA727-3B06-470b-A7E1-1B5001755A9C}
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        //控制参数判断
        /// <summary>
        /// 是否打印冲红发票
        /// </summary>
        bool IsPrintReturn = false;

        /// <summary>
        /// 负发票是否走新票号
        /// </summary>
        bool IsReturnNewInvoice = false;

        /// <summary>
        /// 是否可以作废，重打隔天票据
        /// </summary>
        private bool isCanDealBefore = true;

        /// <summary>
        /// 是否可以交叉退预交金
        /// </summary>
        private bool isCanQuitOtherOper = true;

        /// <summary>
        /// 是否打印预交金发票
        /// </summary>
        private bool isPrintInvoice = true;
        /// <summary>
        /// 是否显示预交金票据号
        /// </summary>
        private bool isShowInoice = true;

        /// <summary>
        /// 发票打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint prepayPrint = null;
        /// <summary>
        /// 银行列表查询
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper helpBank = new Neusoft.FrameWork.Public.ObjectHelper();
        #region 银联接口
        #region {68EAA727-3B06-470b-A7E1-1B5001755A9C}

        private bool isAutoBankTrans = false;
        public bool IsAutoBankTrans
        {
            set { isAutoBankTrans = value; }
        }

        #endregion
        #region {68EAA727-3B06-470b-A7E1-1B5001755A9C}
        /// <summary>
        /// 银联接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBankTrans bankTrans = null;
        #endregion
        #region {68EAA727-3B06-470b-A7E1-1B5001755A9C}
        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBankTrans BankTrans
        {
            get { return bankTrans; }
            set { bankTrans = value; }
        }
        #endregion
        #endregion
        #endregion "属性"

        //hedj{D685C1D1-4101-49c4-9309-7562F1FA5D30}
        /// <summary>
        /// 按机器取发票
        /// </summary>
        public string operID = string.Empty;

        public bool isRegister = false;       
        //end hedj

        LocalManager localManager = new LocalManager();
        TdInterface.TdFunction tdfunction = new TdInterface.TdFunction();

        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                //{68EAA727-3B06-470b-A7E1-1B5001755A9C}
                Type[] type = new Type[2];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint);
                //{68EAA727-3B06-470b-A7E1-1B5001755A9C}
                type[1] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBankTrans);
                return type;
            }
        }

        #endregion
      
        #region "属性"
        //{318AC21F-DDD4-4256-A4E4-4FAE95E5E262}
        /// <summary>
        /// 是否显示按钮
        /// </summary>
        public bool IsShowButton
        {
            set
            {
                neuPanel1.Visible = value;
                this.ucQueryInpatientNo.IsShowButton = !value;
            }
        }

        public Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint PrepayPrint 
        {
            set 
            {
                this.prepayPrint = value;
            }
        }

        //{78577E37-C1C7-459e-84CD-67CE1CC25A4F}
        [Category("控件设置"), Description("是否显示预交金票据号")]
        public bool IsShowInoice
        {
            get
            {
                return isShowInoice;
            }
            set
            {
                isShowInoice = value;
            }
        }
        /// <summary>
        /// 是否允许补打以前的发票

        /// </summary>
        [Category("控件设置"),Description("是否可以作废，重打隔天票据")]
        public bool IsCanDealBefore
        {
            get
            {
                return isCanDealBefore;
            }
            set
            {
                isCanDealBefore = value;
            }
        }


        [Category("控件设置"), Description("是否可以交叉退预交金")]
        public bool IsCanQuitOtherOper
        {
            get { return isCanQuitOtherOper; }
            set { isCanQuitOtherOper = value; }
        }

        [Category("控件设置"),Description("是否打印预交金收据")]
        public bool IsPrintInvoice
        {
            get
            {
                return isPrintInvoice;
            }
            set
            {
                isPrintInvoice = value;
            }
        }

        /// <summary>
        /// 是否弹出对话框来选择返还的支付方式
        /// //{497085F6-BD60-40b1-97F9-10170026B312} JiangShuai 2012-08-24
        /// </summary>
        [Category("控件设置"), Description("是否弹出对话框来选择返还的支付方式")]
        private bool isShowReplayDiaLog = false;
        public bool 是否弹出对话框来选择返还的支付方式
        {
            get
            {
                return isShowReplayDiaLog;
            }
            set
            {
                isShowReplayDiaLog = value;
            }
        }
        #endregion

        #region "方法"
        /// <summary>
        /// 初始化控件信息

        /// </summary>
        public virtual void initControl()
        {
            //初始化默认现金方式

            this.cmbPayType.Tag = "CA";
            this.cmbPayType.Text = "现金";

            //确定选择方式
            this.cmbPayType.IsListOnly = true;
            //初始化farpoint属性

            this.fpPrepay_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpPrepay_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            //初始化住院号控件
            this.ucQueryInpatientNo.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucQueryInpatientNo.TextBox.Size = new System.Drawing.Size(116, 21);
            this.ucQueryInpatientNo.TextBox.Location = new System.Drawing.Point(52, 5);
            this.ucQueryInpatientNo.TextBox.BringToFront();
            //添加支付方式控件事件
            this.cmbPayType.KeyDown += new KeyEventHandler(cmbPayType_KeyDown);
            #region {68EAA727-3B06-470b-A7E1-1B5001755A9C}
            //是否系统处理银联交
            this.isAutoBankTrans = this.controlParamIntegrate.GetControlParam<bool>("MZ9001", true, false);

            //银联接口
            bankTrans = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject<
                Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBankTrans>(this.GetType());
            if (bankTrans == null)
            {
                bankTrans = new frmBankTrans();
            }
            alBanks = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            if (alBanks == null || alBanks.Count <= 0)
            {
                MessageBox.Show("获取银行列表失败!");

                return ;
            }
            helpBank.ArrayObject = alBanks;
            #endregion
            //{78577E37-C1C7-459e-84CD-67CE1CC25A4F}
            if (this.neuLabel1.Text == "000000000")
            {
                this.neuLabel1.Text = string.Empty;
            }

            if (isShowInoice)
            {
                neuLabel1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                neuLabel1.Visible = false;
                label1.Visible = false;
            }
        }

	    /// <summary>
		/// 读取控制类信息
		/// </summary>
        private int ReadControlInfo()
        {
            Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
            try
            {
                this.IsPrintReturn = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100015"));
                this.IsReturnNewInvoice = Neusoft.FrameWork.Function.NConvert.ToBoolean(controlParm.QueryControlerInfo("100016"));
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("读取控制类信息出错!",211);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 查询患者预交金信息
        /// </summary>
        /// <param name="patientInfo">住院患者基本信息实体</param>
        /// <returns>1 成功 －1失败</returns>
        protected virtual int QueryPatientPrepay(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            //添加行
            ArrayList al = new ArrayList();

            try
            {
                //根据住院号提取患者预交金信息到ArrayList
                al = this.feeInpatient.QueryPrepays(patientInfo.ID);
                if (al == null) return 0;
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message,211);
                return -1;
            }
            this.fpPrepay_Sheet1.RowCount = 0;
            this.fpPrepay_Sheet1.RowCount = al.Count;
            //交款次数
            int PayCount = 0;
            //返款次数
            int WasteCount = 0;

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)al[i];

                string PrepayState = "";
                if (prepay.FT.PrepayCost > 0)
                {
                    PayCount++;
                    PrepayState = "收取";
                }
                else
                {
                    WasteCount++;
                    switch (prepay.PrepayState)
                    {
                        case "1":
                            PrepayState = "返还";

                            break;
                        case "2":
                            PrepayState = "补打";
                            break;
                        default:
                            PrepayState = "收取";
                            break;
                    }
                }
                //更新一些没有的字段()
                string PrepaySource = "";
                if (prepay.TransferPrepayState == "0")
                {
                    PrepaySource = "预交金";
                }
                else
                {
                    PrepaySource = "转押金";
                }
                //结算标记
                string BalanceFlag = "";
                if (prepay.BalanceState == "0")
                {
                    BalanceFlag = "未结算";
                }
                else
                {
                    BalanceFlag = "已结算";
                }
                //收款员姓名


                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee empl = new Neusoft.HISFC.Models.Base.Employee();
                empl = managerIntergrate.GetEmployeeInfo(prepay.PrepayOper.ID);

                if (empl == null)
                { prepay.PrepayOper.Name = ""; }
                else
                {
                    prepay.PrepayOper.Name = empl.Name;
                }
                //支付方式

                Neusoft.FrameWork.Models.NeuObject payObj = this.managerIntegrate.GetConstant("住院PAYMODES", prepay.PayType.ID);
                if (payObj == null) 
                {
                    MessageBox.Show("获得支付方式定义信息出错!" + this.managerIntegrate.Err);

                    return -1;
                }

               //添加farpoint显示内容
                //{4E569A30-8655-4461-86B8-450BD5D245D4}
                //Object[] o = new Object[] { prepay.RecipeNO, PrepayState, prepay.FT.PrepayCost, payObj.Name, PrepaySource, BalanceFlag, prepay.PrepayOper.Name, prepay.PrepayOper.OperTime.ToString() };
                Object[] o = new Object[] { prepay.RecipeNO, PrepayState, prepay.FT.PrepayCost, payObj.Name, PrepaySource, BalanceFlag, prepay.PrepayOper.Name, prepay.OrgInvoice.ID, prepay.PrepayOper.OperTime.ToString() };

                for (int j = 0; j <= o.GetUpperBound(0); j++)
                {
                    try
                    {
                        fpPrepay_Sheet1.Cells[i, j].Value = o[j];
                    }
                    catch (Exception ex)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg(ex.Message,211);
                        return -1;
                    }
                }
                if (prepay.PrepayState != "0") this.fpPrepay_Sheet1.Cells[i, 1].ForeColor = System.Drawing.Color.Red;
                fpPrepay_Sheet1.Rows[i].Tag = prepay;
            }
            //返还交款次数
            this.txtPayNum.Text = PayCount.ToString();
            this.txtBackNum.Text = WasteCount.ToString();
            //余额
            if (Neusoft.FrameWork.Public.String.FormatNumber(decimal.Parse(this.txtFreeCost.Text), 2) < 0)
            {
                this.txtFreeCost.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                this.txtFreeCost.ForeColor = System.Drawing.Color.Black;
            }
            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected virtual void Clear()
        {
                 
            this.patientInfo = null;
            txtSumPreCost.Text = "";
            this.txtTotCost.Text = "";
            this.txtName.Text = "";
            this.txtDept.Text = "";
            this.txtPact.Text = "";
            this.txtBedNo.Text = "";
            this.txtOwnCost.Text = "";
            txtFreeCost.Text = "";
            txtBirthday.Text = "";
            txtNurseStation.Text = "";
            txtDateIn.Text = "";
            txtDoctor.Text = "";
            this.cmbPayType.Tag = "CA";
            this.cmbPayType.Text = "现金";
            this.cmbPayType.bank = new Neusoft.HISFC.Models.Base.Bank();
            this.fpPrepay_Sheet1.RowCount = 0;
            this.txtPayNum.Text = "";
            this.txtBackNum.Text = "";
            this.txtPreCost.Text = "";//预交金额清空
            this.neuLabel1.Text = string.Empty;
        }

        /// <summary>
        /// 利用患者信息实体进行控件赋值
        /// </summary>
        /// <param name="patientInfo">患者基本信息实体</param>
        protected virtual void EvaluteByPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            }
            //预交金总额
            this.txtSumPreCost.Text = patientInfo.FT.PrepayCost.ToString();
            //费用金额
            this.txtTotCost.Text = patientInfo.FT.TotCost.ToString();
            // 姓名
            this.txtName.Text = patientInfo.Name;
            // 科室
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            // 合同单位
            this.txtPact.Text = patientInfo.Pact.Name;
            //床号
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
            //自费金额
            this.txtOwnCost.Text = patientInfo.FT.OwnCost.ToString();
            //余额
            txtFreeCost.Text = patientInfo.FT.LeftCost.ToString();
            //生日
            txtBirthday.Text = patientInfo.Birthday.ToString("yyyy-MM-dd");
            //所属病区
            txtNurseStation.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;
            //入院日期
            txtDateIn.Text = patientInfo.PVisit.InTime.ToString("yyyy-MM-dd");
            // 医生
            txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            //住院号
            this.ucQueryInpatientNo.TextBox.Text = patientInfo.PID.PatientNO;

            this.txtPubCost.Text = patientInfo.FT.PubCost.ToString();
            this.txtPayCost.Text = patientInfo.FT.PayCost.ToString();
            
        }

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("收取", "收取患者的预交金",(int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借入,true, false, null);
            toolBarService.AddToolButton("返还", "返还患者预交金", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.J借出, true, false, null);
            toolBarService.AddToolButton("清屏", "清空信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("补打", "预交金发票补打", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C重打, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);

            //hedj 按机器取发票{D685C1D1-4101-49c4-9309-7562F1FA5D30}
            toolBarService.AddToolButton("选择发票", "选择发票", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, null);
            //end

            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ButtonClicked(e.ClickedItem.Text);

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 响应键盘、鼠标事件
        /// </summary>
        /// <param name="tempText">工具栏按钮名称</param>
        private void ButtonClicked(string tempText)
        {
            switch (tempText)
            {
                case "收取":

                    this.ReceivePrepay();
                    break;
                case "返还":

                    break;
                case "清屏":

                    this.Clear();
                    this.ucQueryInpatientNo.Text = "";
                    this.ucQueryInpatientNo.Focus();
                    break;
                case "补打":
                    break;
                case "帮助":
                    break;
                case "退出":
                    {
                        this.FindForm().Close();
                        break;
                    }
                case "选择发票":
                    {
                        //hedj 按机器取发票{D685C1D1-4101-49c4-9309-7562F1FA5D30}
                        string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", false, "0");
                        if (isChooseEmployee == "1")
                        {
                            Neusoft.HISFC.Components.Common.Controls.ucChooseEmployee ucChooseEmployee = new Neusoft.HISFC.Components.Common.Controls.ucChooseEmployee();
                            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucChooseEmployee);
                            operID = ucChooseEmployee.operID;
                        }
                        break;
                        //end 
                    }

            }
        }

        /// <summary>
        /// 打印预交金
        /// 王宇修改， 控制冲红票打印负数，并且注明作废字样
        /// 增加了[bool]isReturn参数，如果是冲红票为True,正常收取票为False
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="prepay"></param>
        /// <param name="isReturn"></param>
        protected virtual void PrintPrepayInvoice(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay, bool isReturn)
        {
            if (patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.prepayPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IPrepayPrint;

            if (this.prepayPrint == null)
            {

                return;
            }
           

            this.prepayPrint.SetValue(patientInfo, prepay);
            this.prepayPrint.Print();


        }

        /// <summary>
        /// 预交金收取
        /// </summary>
        protected virtual void ReceivePrepay()
        {
            //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
            string errText = string.Empty;
            if (!feeIntegrate.AfterDayBalanceCanFee(this.feeInpatient.Operator.ID, true, ref errText))
            {
                MessageBox.Show(errText);
                return;
            }

            //判断患者
            if (this.patientInfo == null)
            {
                return;
            }
            else
            {
                if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "") return;
            }
            //金额判断
            decimal prepayCost = 0m;
            try
            {
                prepayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPreCost.Text.Trim());
                if (this.neuLabel4.Text == "返还押金")
                {
                    prepayCost = -prepayCost;
                }
                else
                {
                    prepayCost = prepayCost;
                }
            }
            catch
            {
                prepayCost = 0;
                this.txtPreCost.Text = "0.00";
            }

            if (prepayCost == 0)
            {
                return;
            }

            if (prepayCost > 0)
            {
                if (MessageBox.Show("是否收取 "+prepayCost+" 押金？","提示",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            else if (prepayCost < 0)
            {
                if (MessageBox.Show("是否返还 " + prepayCost + " 押金？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            //判断支付方式
            if (this.cmbPayType.Tag == null || this.cmbPayType.Tag.ToString() == string.Empty)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请选择支付方式！", 111);
                this.cmbPayType.Focus();
                return;
            }
            //判断回车确认住院号


            if (this.patientInfo.PID.PatientNO != this.ucQueryInpatientNo.Text.Trim())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请回车确认住院号",111);
                return;
            }
            //判断封帐
            if ((this.feeInpatient.GetStopAccount(this.patientInfo.ID)) == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者处于封帐状态,可能正在结算,请稍后再做此操作!",111);
                return;
            }
            #region 天津的需求，不应该在核心内实现，应该在本地化里面，此处屏蔽 BY SUNM 2011-02-09
            //if (prepayCost > 10000)
            //{
            //    if (MessageBox.Show("预交金金额超过10000，确认是否继续收取？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        return;
            //    }
            //} 
            #endregion
            //事务连接
            //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.localManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //建立新插入预交金实体
            Neusoft.HISFC.Models.Fee.Inpatient.Prepay newPrepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
           
            //提取发票号码
            //发票类型-预交金


            string InvoiceNo = "";
            //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
            //{D685C1D1-4101-49c4-9309-7562F1FA5D30}
            string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", false, "0");
            if (isChooseEmployee == "1")
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P", operID);
            }
            else
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
            }
            //end {D685C1D1-4101-49c4-9309-7562F1FA5D30}
            if (InvoiceNo == null || InvoiceNo.Trim() == "")
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("请领取发票!",111);
                return;
            }
            //财务组


            Neusoft.FrameWork.Models.NeuObject finGroup = new Neusoft.FrameWork.Models.NeuObject();
            finGroup = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID);

            newPrepay.RecipeNO = InvoiceNo;

            //实体赋值
            newPrepay.Name = this.patientInfo.Name;
            newPrepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
            newPrepay.PrepayOper.Name = this.feeInpatient.Operator.Name;
            newPrepay.FT.PrepayCost = prepayCost;
            newPrepay.Bank = this.cmbPayType.bank.Clone();
            newPrepay.PayType.ID = this.cmbPayType.Tag.ToString();
            newPrepay.Dept = this.patientInfo.PVisit.PatientLocation.Dept.Clone();
            newPrepay.BalanceState = "0";
            newPrepay.BalanceNO = 0;
            newPrepay.PrepayState = "0";
            newPrepay.IsTurnIn = false;
            newPrepay.FinGroup.ID = finGroup.ID;
            newPrepay.PrepayOper.OperTime = DateTime.Parse(this.feeInpatient.GetSysDateTime());
            newPrepay.TransferPrepayState = "0";

            //正常收或退预交金 ext_falg = "1";与结算召回区分，用字段 User01  By Maokb 060804
            newPrepay.User01 = "1";

            #region 返还时可以选择返还的支付方式
            //{497085F6-BD60-40b1-97F9-10170026B312} JiangShuai 2012-08-24
            if (isShowReplayDiaLog)//弹出对话框选择返还的支付方式
            {
                Neusoft.HISFC.Components.InpatientFee.Prepay.frmPrepaySelect fp = new Neusoft.HISFC.Components.InpatientFee.Prepay.frmPrepaySelect();
                DialogResult dialogResult = fp.ShowDialog();

                if (dialogResult != DialogResult.Cancel)
                {
                    newPrepay.PayType = fp.ObjPayType;
                }
                else
                {
                    return;
                }
            }
            #endregion


            #region {68EAA727-3B06-470b-A7E1-1B5001755A9C}
            if (isAutoBankTrans == true)
            {
                bool needBankTran = false;
                if (newPrepay.PayType.ID == "CD" || newPrepay.PayType.ID == "DB")
                {
                    needBankTran = true;
                }
                if (needBankTran == true)
                {
                    decimal bankTransTot = 0m;
                    bankTransTot = NConvert.ToDecimal(newPrepay.FT.PrepayCost);
                    if (bankTransTot > 0)
                    {
                        bool isBankTransOK = false;
                        try
                        {
                            bankTrans.InputListInfo.Clear();
                            bankTrans.OutputListInfo.Clear();
                            /// 0:交易类型，1：交易金额
                            bankTrans.InputListInfo.Add("0");
                            bankTrans.InputListInfo.Add(bankTransTot);
                            isBankTransOK = bankTrans.Do();
                        }
                        catch (Exception ex)
                        {
                            isBankTransOK = false;
                        }
                        if (isBankTransOK == false)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
              
                            MessageBox.Show("交易失败！交易信息" + bankTrans.OutputListInfo[0].ToString());
                            return;
                        }
                        else
                        {
                            if (bankTrans.OutputListInfo.Count >= 4)
                            {
                                if (bankTransTot != NConvert.ToDecimal(bankTrans.OutputListInfo[4]))
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();              
                                       MessageBox.Show("交易请求金额" + bankTransTot.ToString() + "不等于交易金额" + NConvert.ToDecimal(bankTrans.OutputListInfo[4]) + ",交易失败！");
                                       return;
                                }
                                else
                                {
                                    MessageBox.Show("交易成功！金额" + bankTransTot.ToString());
                                    //0：银行信用卡系统传回的交易回应BankResponse
                                    //1:银行 2：账号 3：pos号 4：金额 5：系统参考号(交易主键)
                                    newPrepay.Bank.Name = bankTrans.OutputListInfo[1].ToString();
                                    newPrepay.Bank.ID = helpBank.GetID(newPrepay.Bank.Name);
                                    newPrepay.Bank.Account = bankTrans.OutputListInfo[2].ToString();
                                    newPrepay.Bank.InvoiceNO = bankTrans.OutputListInfo[5].ToString();
                                    newPrepay.Bank.Memo = bankTrans.OutputListInfo[0].ToString();                                 
                                }
                            }
                        }
                    }        
                }
            }
            #endregion
            //调用业务层组合业务


            if (this.feeInpatient.PrepayManager(this.patientInfo, newPrepay) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("收取失败!"+feeInpatient.Err,211 );
                return;

            }

            this.patientInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text.Trim());
            this.patientInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOwnCost.Text.Trim());
            this.patientInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPayCost.Text.Trim());
            //{A014D12B-4AA0-4122-BC2D-3BA68C28C53E}
            tdfunction.ClearScreen();
            tdfunction.ShowReturnCost(Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text.Trim()), this.patientInfo.FT.PubCost, this.patientInfo.FT.OwnCost);
            //tdfunction.ShowYJCost(Neusoft.FrameWork.Function.NConvert.ToDecimal(txtSumPreCost.Text.Trim()));
            tdfunction.ShowReturnCostIn(this.patientInfo.FT.OwnCost,Neusoft.FrameWork.Function.NConvert.ToDecimal(txtSumPreCost.Text.Trim()));
            if (MessageBox.Show("是否保存此患者的医保结算信息？", "信息确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {
                int returnValue = this.localManager.UpdateInpatientSIBalanceInfo(this.patientInfo);
                if (returnValue < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新患者的医保结算信息出错！" + this.localManager.Err, "错误提示");
                    return;
                }
            }

            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);

            this.EvaluteByPatientInfo(this.patientInfo);

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("预交金操作成功!", 111);
            //打印预交金发票


            //重新检索预交金记录
            this.QueryPatientPrepay(this.patientInfo);
            if (isPrintInvoice)
            {
                this.PrintPrepayInvoice(this.patientInfo, newPrepay, false);
            }
            //
            this.txtPreCost.Text = "";
            this.ucQueryInpatientNo.Focus();

            this.DisplayInvoiceNo();
        }

        //{40F60131-7A18-4867-B91D-F611BCA326BA}mbyxl
        /// <summary>
        /// 显示发票号 
        /// </summary>
        private void DisplayInvoiceNo()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            string InvoiceNo_temp = "";
            //{D685C1D1-4101-49c4-9309-7562F1FA5D30}
            string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", false, "0");
            if (isChooseEmployee == "1")
            {
                InvoiceNo_temp = this.feeIntegrate.GetNewInvoiceNO("P", operID);
            }
            else
            {
                InvoiceNo_temp = this.feeIntegrate.GetNewInvoiceNO("P");
            }
            //end {D685C1D1-4101-49c4-9309-7562F1FA5D30}
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            neuLabel1.Text = InvoiceNo_temp;
        }

        /// <summary>
        /// 预交金返还判断
        /// </summary>
        /// <param name="prepay"></param>
        /// <returns></returns>
        private bool ValidReturnPrepay(Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay)
        {
            //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
            string errText = string.Empty;
            if (!feeIntegrate.AfterDayBalanceCanFee(this.feeInpatient.Operator.ID, true, ref errText))
            {
                MessageBox.Show(errText);
                return false;
            }

            if (prepay.PrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经返还!不能进行再次作废操作!", 111);
                return false;
            }
            if (prepay.PrepayState == "2")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金已经进行过补打操作,已经成为作废发票,不能再作废!", 111);
                return false;
            }
            if (prepay.BalanceState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该票据已经结算过不能作废!!", 111);
                return false;
            }

            if (prepay.TransferPrepayState == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该预交金为结算的转押金还没有进行正常打印操作,不能作废!", 111);
                return false;
            }
            if (!isCanDealBefore)
            {
                if (prepay.PrepayOper.OperTime < feeInpatient.GetDateTimeFromSysDateTime().Date)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("不能作废当天前的预交金!", 111);
                    return false;
                }
            }

            if (!isCanQuitOtherOper)
            {
                if (prepay.PrepayOper.ID != feeInpatient.Operator.ID)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("该发票为操作员" + prepay.PrepayOper.ID + "收取,您没有权限作废！", 111);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region "事件"

        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPrepay_Load(object sender, EventArgs e)
        {
            #region 按机器取发票
            if (!isRegister)
            {
                //hedj 按机器取发票{D685C1D1-4101-49c4-9309-7562F1FA5D30}
                string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", true, "0");
                if (isChooseEmployee == "1")
                {
                    Neusoft.HISFC.Components.Common.Controls.ucChooseEmployee ucChooseEmployee = new Neusoft.HISFC.Components.Common.Controls.ucChooseEmployee();
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucChooseEmployee);
                    operID = ucChooseEmployee.operID;
                }
                //end 
            }
            #endregion

            //初始化控件

            this.initControl();
            //重新初始化工具栏
            //try
            //{
            //    Function.RefreshToolBar(this.hsToolBar, ((Neusoft.FrameWork.WinForms.Forms.frmBaseForm)this.ParentForm).toolBar1, "预交金管理");
            //}
            //catch { }

            //设置窗体控件的输入法状态为半角
            if (String.IsNullOrEmpty(this.ucQueryInpatientNo.InpatientNo) == false)
            {
                this.txtPreCost.Focus();
            }


            Neusoft.HISFC.Components.Common.Classes.Function.SetIme(this);
        }


        void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                this.txtPubCost.Focus();
                this.txtPubCost.SelectAll();
            }
		
        }

        private void ucQueryInpatientNo_myEvent()
        {
            //清空
            this.Clear();
            this.fpPrepay_Sheet1.RowCount = 0;

            //判断是否有该患者
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo.Err == "")
                {
                    ucQueryInpatientNo.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo.Err,211);

                this.ucQueryInpatientNo.Focus();
                return;
            }
            
            //{78577E37-C1C7-459e-84CD-67CE1CC25A4F}
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string InvoiceNo = "";

            //{D685C1D1-4101-49c4-9309-7562F1FA5D30}
            string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", false, "0");
            if (isChooseEmployee == "1")
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P", operID);
            }
            else
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
            }
            //end {D685C1D1-4101-49c4-9309-7562F1FA5D30}

            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            neuLabel1.Text = InvoiceNo;


            //获取住院号赋值给实体
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
            //{A014D12B-4AA0-4122-BC2D-3BA68C28C53E}
            tdfunction.ClearScreen();
            tdfunction.ShowInfo("姓名："+this.patientInfo.Name);

            if (this.patientInfo == null) MessageBox.Show(this.radtIntegrate.Err);

            if (this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || this.patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!",111);

                this.patientInfo.ID = null;

                return;
            }
            
            //是否是出院登记状态
            if (this.patientInfo.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.B.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者不是出院登记状态，无法办理", 111);

                this.patientInfo.ID = null;

                return;
            }
            else
            {
                if (this.patientInfo.Pact.PayKind.ID == "01")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("自费患者无需处理医保农合结算押金！", 111);

                    this.patientInfo.ID = null;

                    return;
                }
            }

            //控件赋值患者信息
            this.EvaluteByPatientInfo(this.patientInfo);


         
            //读取控制类参数

            if (this.ReadControlInfo() == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("提取控制信息出错!",211);
                this.Clear();
                return;
            }

            //判断未打印的转押金
            ArrayList alForegift = new ArrayList();
            //判断是否存在未打印转押金
             alForegift = this.feeInpatient.QueryForegif(this.patientInfo.ID);
            if (alForegift == null)
            {
               Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                this.Clear();
                return;
            }
            //{64BD57CE-9361-41f6-AE91-2618CBA5047A}
            ArrayList alCallBacePrepay = feeInpatient.QueryCallBackPrePay(this.patientInfo.ID);
            if (alCallBacePrepay == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err, 211);
                this.Clear();
                return;
            }

            if (!IsPrintReturn)
            {
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay p in alCallBacePrepay)
                {
                    if (p.PrepayState != "0")
                    {
                        alCallBacePrepay.Remove(p);
                    }
                }
            }

            int count = alCallBacePrepay.Count + alForegift.Count;

            if (count > 0)
            {
                //{64BD57CE-9361-41f6-AE91-2618CBA5047A}
                DialogResult r =MessageBox.Show("患者有" + count.ToString() + "笔预交金没有打印,是否打印?","提示",MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {

                    string errText = string.Empty;
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay in alForegift)
                    {
                        //提取发票号码
                        //发票类型-预交金
                        //string InvoiceNo = "";
                        //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");

                        //if (InvoiceNo == null || InvoiceNo == "")
                        //{
                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //    Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                        //    return;
                        //}
                        ////					
                        //prepay.RecipeNO = InvoiceNo;
                        //prepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
                        //prepay.PrepayOper.Name = this.feeInpatient.Operator.Name;

                        ////打印转押金发票
                        //this.PrintPrepayInvoice(this.patientInfo, prepay, false);

                        if (PrintForgift(prepay, ref errText) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(errText, 211);
                            return;
                        }
                        //更新转押金发票号码和状态
                        if (feeInpatient.UpdateForgift(this.patientInfo, prepay) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err,211);
                            return;
                        }

                    }

                    foreach (Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay in alCallBacePrepay)
                    {
                        if (PrintForgift(prepay, ref errText) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(errText, 211);
                            return;
                        }

                        if (feeInpatient.UpdateCallBackPrePay(patientInfo, prepay) <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.feeInpatient.Err, 211);
                            return;
                        }
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                   
                    
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg("发票打印完毕!",111);
                }

            }

            if (this.QueryPatientPrepay(this.patientInfo) == -1)
            {
                this.Clear();
                this.fpPrepay_Sheet1.Rows.Count = 0;
                return;
            }
            this.cmbPayType.Focus();
        }

        /// <summary>
        /// 打印转押金和召回发票
        /// </summary>
        /// <param name="prepay"></param>
        /// <param name="errText"></param>
        private int PrintForgift(Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay, ref string errText)
        {
            string InvoiceNo = "";
            //{D685C1D1-4101-49c4-9309-7562F1FA5D30}
            string isChooseEmployee = this.controlParamIntegrate.GetControlParam<string>("MZFP24", false, "0");
            if (isChooseEmployee == "1")
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P", operID);
            }
            else
            {
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
            }
            //end {D685C1D1-4101-49c4-9309-7562F1FA5D30}

            if (InvoiceNo == null || InvoiceNo == "")
            {
                errText = this.feeInpatient.Err;
                return -1;
            }
            //					
            prepay.RecipeNO = InvoiceNo;
            prepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
            prepay.PrepayOper.Name = this.feeInpatient.Operator.Name;

            //打印转押金发票
            this.PrintPrepayInvoice(this.patientInfo, prepay, false);
            return 1;
        }
        #endregion

        #region 快捷键


        /// <summary>
        /// toolBar映射
        /// </summary>
        protected Hashtable hsToolBar = new Hashtable();

        /// <summary>
        /// 按键设置
        /// </summary>
        /// <param name="keyData">当前按键</param>
        /// <returns>继续执行True False 当前处理结束</returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (!this.ExecuteShotCut(keyData))
            //{
            //    return false;
            //}
            //{CF1B7CCF-C271-43ec-A7CF-B1D06DEB3786}
            if (keyData.GetHashCode() == Keys.F12.GetHashCode())
            {
                //关闭
                this.ParentForm.Close();
            }

            return base.ProcessDialogKey(keyData);
        }


        /// <summary>
        /// 执行快捷键

        /// </summary>
        /// <param name="key">当前按键</param>
        private bool ExecuteShotCut(Keys key)
        {
            string opName = Neusoft.HISFC.Components.InpatientFee.Function.GetOperationName("预交金管理",key.GetHashCode().ToString());

            if (opName == "") return false;

            ButtonClicked(opName);

            return true;

        }

        #endregion

        /// <summary>
        /// 单击时全选

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPreCost_Click(object sender, EventArgs e)
        {
            this.txtPreCost.SelectAll();
            txtPreCost.Focus();
        }

        #region 318AC21F-DDD4-4256-A4E4-4FAE95E5E262}

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        } 
        #endregion

        #region {E548E446-805F-4944-9D9A-7635FC69E7AE}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private string inpatientNo;
        public string InpatientNo
        {
            set 
            {
                ucQueryInpatientNo.InpatientNo = value;
                this.ucQueryInpatientNo_myEvent();                
            }
            get
            {
                return inpatientNo;
            }
        }
 
        private void txtPreCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.ReceivePrepay();
            }
        }
        #endregion

        private void txtPubCost_KeyDown(object sender, KeyEventArgs e)
        {
            decimal pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text.Trim());
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text.Trim());
            decimal sumPreCost=Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSumPreCost.Text.Trim());
            decimal cost=sumPreCost-totCost+pubCost;
            this.txtOwnCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString((totCost - pubCost), 2);

            if(cost>0)
            {
                this.neuLabel4.Text="返还押金";
                this.txtPreCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(cost, 2);
            }
            else
            {
                this.neuLabel4.Text="收取押金";
                this.txtPreCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(-cost, 2);
            }
        }

        private void txtOwnCost_KeyDown(object sender, KeyEventArgs e)
        {
            decimal pubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPubCost.Text.Trim());
            decimal totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTotCost.Text.Trim());
            decimal ownCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtOwnCost.Text.Trim());
            decimal sumPreCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSumPreCost.Text.Trim());

            this.txtPayCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost - pubCost - ownCost, 2);

            decimal cost = sumPreCost - ownCost;

            if (cost > 0)
            {
                this.neuLabel4.Text = "返还押金";
                this.txtPreCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(cost, 2);
            }
            else
            {
                this.neuLabel4.Text = "收取押金";
                this.txtPreCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(-cost, 2);
            }
        }

        private void txtPubCost_Click(object sender, EventArgs e)
        {
            this.txtPubCost.Focus();
            this.txtPubCost.SelectAll();
        }

        private void txtOwnCost_Click(object sender, EventArgs e)
        {
            this.txtOwnCost.Focus();
            this.txtOwnCost.SelectAll();
        }

        private void txtPayCost_Click(object sender, EventArgs e)
        {
            this.txtPayCost.Focus();
            this.txtPayCost.SelectAll();
        }
    }
}
