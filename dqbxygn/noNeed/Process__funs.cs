using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace noNeed
{
    class Process__funs
    {
        #region Process中的一些旧方法，原版先放在这里
        
        #endregion

        #region 属于“IMedcareTranscation 成员”中的内容

        /// <summary>
        /// 接口连接,初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Connect()
        {
            //this.seiInterfaceProxy = new ei.CoClass_com4hisClass();

            if (!isInit)
            {
                try
                {
                    if (string.IsNullOrEmpty(SSD))  //取接口初始化方法的人员id,医院编码以及密码信息
                    {
                        personID = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "personID", @".\dllinit.ini");
                        hospitalNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "hospitalID", @".\dllinit.ini");
                        passWord = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "passWord", @".\dllinit.ini");
                        SSD = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "SSD", @".\dllinit.ini");
                        doctorNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "DoctorNO", @".\dllinit.ini");
                        DeptNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "DeptNO", @".\dllinit.ini");
                    }
                    //初始化接口连接
                    if (this.connInit() == -1)
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    this.errText = ex.Message;

                    isInit = false;

                    return -1;
                }

                return 1;
            }

            return 1;
        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Disconnect()
        {
            return 1;
        }

        #region 这个region里下面的方法没有用到过

        #endregion

        /// <summary>
        /// 数据库回滚,成功 1 失败 -1
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public long Rollback()
        {
            int returnValue = 0;

            switch (rollbackTypeSI)
            {
                case 11://普通门诊撤销结算
                    {

                    }
                    break;
                case 12://门规撤销结算
                    {
                        returnValue = this.seiInterfaceProxy.init_mzmg(this.regBack.SIMainInfo.ProceatePcNo, this.regBack.SIMainInfo.MedicalType.ID, this.regBack.SIMainInfo.CardOrgID, this.regBack.Name, this.ConvertSex(this.regBack.Sex.ID.ToString()),
                this.regBack.ID, System.DateTime.Now, this.regBack.DoctorInfo.Templet.Doct.ID, this.regBack.SIMainInfo.InDiagnose.ID, this.regBack.SIMainInfo.SpecialCare.ID, this.regBack.SSN, this.regBack.SIMainInfo.SpecialCare.Name, "");
                        if (returnValue != 0)
                        {
                            this.errText = "门诊结算回滚时初始化患者信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                            return -1;
                        }
                        returnValue = this.seiInterfaceProxy.destroy_mzmg(this.regBack.SIMainInfo.BusinessSequence);
                        if (returnValue != 0)
                        {
                            this.errText = "撤销门诊结算信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                            return -1;
                        }
                    }

                    break;
                case 13://急诊患者撤销结算
                    {


                    }
                    break;
                case 14://特殊人员门诊撤销结算
                    {

                    }
                    break;
                case 15://普通门诊退费
                    break;
                case 16://门规退费
                    break;
                case 17://急诊门诊退费
                    break;
                case 21:
                    //初始化住院服务
                    returnValue = this.seiInterfaceProxy.init_zy(this.patientInfoBack.ID);
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时初始化住院登记信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //撤销出院登记
                    returnValue = this.seiInterfaceProxy.destroy_cy();
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时撤销出院登记失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //撤销出院结算
                    returnValue = this.seiInterfaceProxy.destroy_zyjs(this.patientInfoBack.SIMainInfo.BusinessSequence);
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时撤销出院结算失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //撤销所有上传的费用凭单
                    returnValue = this.seiInterfaceProxy.destroy_all_fypd();
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时撤销所有费用凭单失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //作废预交金
                    returnValue = this.seiInterfaceProxy.add_yj(this.patientInfoBack.ID, -(double)this.patientInfoBack.FT.PrepayCost);
                    if (returnValue != 0)
                    {
                        this.errText = "作废押金失败！。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }
                    break;
                case 22:
                    //初始化住院服务
                    returnValue = this.seiInterfaceProxy.init_zy(this.patientInfoBack.ID);
                    if (returnValue != 0)
                    {
                        this.errText = "对住院登记回滚时初始化住院登记信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //撤销住院登记
                    returnValue = this.seiInterfaceProxy.destroy_zydj();
                    if (returnValue != 0)
                    {
                        this.errText = "对住院登记回滚时撤销出院登记失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }
                    break;
                case 23:
                    //初始化住院服务
                    returnValue = this.seiInterfaceProxy.init_zy(this.patientInfoBack.ID);
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时初始化住院登记信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //撤销所有上传的费用凭单
                    returnValue = this.seiInterfaceProxy.destroy_all_zypd(this.patientInfoBack.ID);
                    if (returnValue != 0)
                    {
                        this.errText = "对出院结算回滚时撤销所有费用凭单失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //作废所有上传过的预交金
                    returnValue = this.seiInterfaceProxy.add_yj(this.patientInfoBack.ID, -(double)this.patientInfoBack.FT.PrepayCost);
                    if (returnValue != 0)
                    {
                        this.errText = "作废押金失败！。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }
                    break;
                case 24:
                    break;

                default:
                    break;
            }
            this.rollbackTypeSI = 0;
            this.isNeedPrint = false;
            return 1;
        }

        #endregion

        #region 属于“本地方法”中的内容

        #region 初始化连接
        /// <summary>
        /// 初始化接口连接
        /// </summary>
        /// <returns></returns>
        private int connInit()
        {
            int returnValue = 0;
            if (this.sourceObject.ToString() == "LiaoChengZYSI.Control.ucCompare" || this.sourceObject.ToString() == "LiaoChengZYSI.Control.frmUploadCheckedInfo, Text: 医保费用上传" || this.sourceObject.ToString() == "LiaoChengZYSI.Control.frmUploadFeeDetails, Text: 医保批量上传")
            {
                try
                {
                    //登陆id
                    if (string.IsNullOrEmpty(personID))
                    {
                        personID = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "personID", @".\dllinit.ini");
                    }
                    //医院编码
                    if (string.IsNullOrEmpty(hospitalNO))
                    {
                        hospitalNO = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "hospitalID", @".\dllinit.ini");
                    }
                    //密码
                    if (string.IsNullOrEmpty(passWord))
                    {
                        passWord = Neusoft.FrameWork.WinForms.Classes.Function.ReadPrivateProfile("SDSI", "passWord", @".\dllinit.ini");
                    }
                }
                catch (Exception ex)
                {
                    this.errText = ex.Message + "获取登陆参数出错";
                    return -1;
                }
                if (this.seiInterfaceProxy.icconect == false)
                {
                    //初始化接口连接
                    //personID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                    //if (this.localManager.getPWD(personID, ref passWord) == -1)
                    //{
                    //    this.errText = "获取操作员的登陆密码信息失败！" + this.localManager.Err;
                    //    return -1;
                    //}
                    if (string.IsNullOrEmpty(personID) || string.IsNullOrEmpty(hospitalNO) || string.IsNullOrEmpty(passWord))
                    {
                        this.errText = "获取操作员的登陆信息出错，请确认是否进行维护了相关数据！\n dllinit.ini文件";
                        return -1;
                    }

                    string strConn = "";
                    if (personID.Length > 4)
                    {
                        strConn = "gzrybh#" + personID.Substring(2, 4) + "|yybm#" + hospitalNO + "|passwd#" + passWord + "|syzhlx#3";
                    }
                    else
                    {
                        strConn = "gzrybh#" + personID + "|yybm#" + hospitalNO + "|passwd#" + passWord + "|syzhlx#3";
                    }


                    returnValue = this.seiInterfaceProxy.initialize(strConn);
                    if (returnValue != 0)
                    {
                        this.errText = "登陆医保数据库失败 \n错误代码：" + returnValue + "\n 错误信息：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }
                }
            }

            return 1;
        }
        #endregion

        #region 这个region里下面的方法没有用到过

        #endregion

        #region 查询医保项目自负比例
        /// <summary>
        /// 查询医保项目自负比例
        /// </summary>
        /// <param name="sbjCode">社保局编码</param>
        /// <param name="centerNO">中心项目编码</param>
        /// <param name="date">日期</param>
        /// <param name="al">返回该项目自负比例数组</param>
        /// <returns>成功 0</returns>
        public int QueryCenterItemRate(string sbjCode, string centerNO, DateTime date, ref ArrayList al)
        {
            string tempStr = this.seiInterfaceProxy.get_zfbl(sbjCode, centerNO, date);
            if (string.IsNullOrEmpty(tempStr))
            {
                this.errText = this.seiInterfaceProxy.get_errtext();
                return -1;
            }
            if (tempStr.Trim() == "0")
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = "0";
                obj.Name = "无自负比例";
                al.Add(obj);
                return 1;
            }
            string[] centerItemRates = tempStr.Split('/');
            if (centerItemRates.Length > 1)
            {
                for (int i = 0; i < centerItemRates.Length - 1; i++)
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    char[] cc = { '|' };
                    centerItemRates[i] = centerItemRates[i].Replace("#v", "|");
                    string[] centerItemRate = centerItemRates[i].Split(cc);
                    obj.ID = centerItemRate[0];
                    obj.Name = centerItemRate[1];
                    al.Add(obj);
                }
            }

            return 1;
        }


        #endregion

        #region 根据参数处理登记信息相关
        /// <summary>
        /// 根据参数处理登记信息相关（）
        /// 目前济南医保只有住院登记，其余登记相关信息均返回1
        /// </summary>
        /// <param name="patient">登记类型:0 入院登记1 出院登记</param>
        /// <param name="regType">交易类型:1 正交易 -1  反交易</param>
        /// <param name="transType"></param>
        /// <returns></returns>
        private int processInpatientReg(Neusoft.HISFC.Models.RADT.PatientInfo patient, int regType, int transType)
        {
            try
            {
                int returnValue = 0;
                string bcString = string.Empty;

                if (regType == 0 && transType == 1)
                {
                    #region 处理住院登记
                    if (string.IsNullOrEmpty(patient.SSN))
                    {
                        this.errText = "医保读卡信息为空，请先读卡以后办理入院登记！";
                        return -1;
                    }

                    Control.frmSiPobInpatientInfo frmpob = new Control.frmSiPobInpatientInfo();
                    frmpob.Patient = patient;
                    frmpob.Text = "山东省—住院登记";
                    frmpob.ShowDialog();

                    DialogResult result = frmpob.DialogResult;

                    if (result != DialogResult.OK)
                    {
                        return -1;
                    }

                    //省异地
                    if (patient.SIMainInfo.ProceatePcNo == "370000")
                    {
                        bcString = "cbdsbh#" + patient.SIMainInfo.CivilianGrade.ID + "|" + "cbjgmc#" + patient.SIMainInfo.CivilianGrade.Name;
                    }
                    else
                    {
                        bcString = "";
                    }

                    returnValue = this.seiInterfaceProxy.save_zydj(patient.ID, patient.SIMainInfo.CardOrgID, patient.SSN, patient.Name, this.ConvertSex(patient.Sex.ID.ToString()),
                        patient.SIMainInfo.AppNo.ToString(), patient.SIMainInfo.ProceatePcNo, patient.SIMainInfo.SpecialCare.ID, patient.PVisit.PatientLocation.Dept.ID, frmpob.Patient.PVisit.InTime,
                        "", "", patient.SIMainInfo.EmplType, patient.SIMainInfo.SpecialCare.Name, bcString);

                    if (returnValue != 0)
                    {
                        this.errText = "接口住院登记失败。\n错误代码：" + returnValue + "\n错误信息： " + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    //返回备注信息
                    string memo = this.seiInterfaceProxy.result_s("bz");

                    this.rollbackTypeSI = 22; //入院登记回滚

                    this.patientInfoBack = patient;

                    this.businessSequenceZY = patient.ID;
                    localManager.SetTrans(this.trans);
                    string balanceNO = this.localManager.GetBalNo(patient.ID);
                    bool isModify = false;
                    if (balanceNO == null || balanceNO == string.Empty || balanceNO == "")
                    {
                        //balanceNO = "0";
                        patient.SIMainInfo.BalNo = "1";
                    }
                    else
                    {
                        isModify = true;
                        patient.SIMainInfo.BalNo = balanceNO;
                    }

                    //balanceNO = (Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO) + 1).ToString();
                    //patient.SIMainInfo.BalNo = balanceNO;
                    patient.SIMainInfo.IsValid = true;
                    patient.SIMainInfo.OperDate = patient.PVisit.InTime;
                    patient.SIMainInfo.OperInfo.ID = this.localManager.Operator.ID;//获取当前操作员信息
                    patient.SIMainInfo.BusinessSequence = "";//this.BusinessSequenceZY;

                    if (isModify)
                    {
                        returnValue = this.localManager.UpdateSiMainInfo(patient);
                    }
                    else
                    {
                        returnValue = this.localManager.InsertSIMainInfo(patient);
                    }
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }

                    returnValue = this.localManager.UpdateTreatmentInfoInmaininfo(patient);
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }

                    returnValue = this.localManager.updateTransType("1", patient.ID, patient.SIMainInfo.BalNo);
                    if (returnValue < 0)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }

                    #endregion
                }
            }
            catch (Exception e)
            {
                this.errText = e.Message;

                return -1;
            }

            return 1;
        }
        #endregion
        #endregion

        #region 属于“Imedcare 成员”中的内容
        public bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ModifyUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 调用此方法补打统筹结算单
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="feeDetails"></param>
        /// <returns></returns>
        public int ModifyUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            int returnValue = 0;
            returnValue = this.seiInterfaceProxy.init_zy(patient.ID);
            if (returnValue != 0)
            {
                this.errText = "初始化住院登记信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1; ;
            }

            returnValue = this.seiInterfaceProxy.printdj(patient.SIMainInfo.BusinessSequence, "JSD");
            if (returnValue != 0)
            {
                this.errText = "补打统筹结算单据信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1; ;
            }

            return 1;
        }

        public int ModifyUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 住院预结算
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="feeDetails"></param>
        /// <returns></returns>
        public int PreBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            if (this.sourceObject.ToString() == "Neusoft.HISFC.Components.InpatientFee.Balance.ucBalance")
            {
                Control.frmSIBalanceInfo siBalance = new LiaoChengZYSI.Control.frmSIBalanceInfo();
                siBalance.Patient = patient;
                siBalance.ShowDialog();
                if (siBalance.DialogResult == DialogResult.OK)
                {
                    patient.FT.PubCost = patient.SIMainInfo.PubCost;
                    patient.FT.PayCost = patient.SIMainInfo.PayCost;
                    patient.FT.OwnCost = patient.SIMainInfo.OwnCost;
                }
                else
                {
                    this.errText = "结算已被取消！";
                    return -1;
                }
            }
            return 1; ;
        }

        /// <summary>
        /// 门诊预结算
        /// </summary>
        /// <param name="r"></param>
        /// <param name="feeDetails"></param>
        /// <returns></returns>
        public int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref System.Collections.ArrayList feeDetails)
        {
            if (this.sourceObject.ToString() == "Neusoft.HISFC.Components.OutpatientFee.Controls.ucCharge" || this.sourceObject.ToString() == "Neusoft.HISFC.Components.OutpatientFee.Controls.ucQuitFee")
            {
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList in feeDetails)
                {
                    r.SIMainInfo.TotCost += feeItemList.FT.TotCost;
                    r.SIMainInfo.OwnCost += feeItemList.FT.TotCost;
                    r.SIMainInfo.PayCost = 0;
                    r.SIMainInfo.PubCost = 0;
                }
            }
            return 1;
        }

        public int QueryBlackLists(ref System.Collections.ArrayList blackLists)
        {
            throw new Exception("The method or operation is not implemented.");
        }



        public int QueryDrugLists(ref System.Collections.ArrayList drugLists)
        {
            return 1;
        }

        public int QueryUndrugLists(ref System.Collections.ArrayList comparedList)
        {
            return 1;
        }

        public int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            return 1;
        }

        /// <summary>
        /// 读卡后,设置住院患者基本信息
        /// </summary>
        /// <param name="r">患者挂号信息实体</param>
        /// <param name="readCardType">当前读卡状态</param>
        /// <param name="dataBuffer">读卡返回的信息字符串</param>
        private int SetInpatientRegInfo(Neusoft.HISFC.Models.RADT.PatientInfo p, ReadCardTypes readCardType)
        {
            switch (readCardType)
            {
                case ReadCardTypes.住院读卡:

                    //p.IDCard = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码
                    p.SIMainInfo.CardOrgID = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码
                    p.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.seiInterfaceProxy.result_s("csrq"));//出生日期
                    p.SIMainInfo.ICCardCode = this.seiInterfaceProxy.result_s("ylzbh");
                    p.Card.ICCard.ID = p.SIMainInfo.ICCardCode;//医保卡号
                    p.SSN = p.SIMainInfo.ICCardCode;
                    p.CompanyName = this.seiInterfaceProxy.result_s("dwmc");//工作单位
                    p.SIMainInfo.ProceatePcNo = this.seiInterfaceProxy.result_s("sbjbm");//社保局编码 ,省直为379902
                    p.SIMainInfo.ApplySequence = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    p.SIMainInfo.PersonType.Name = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    p.SIMainInfo.PersonType.ID = this.seiInterfaceProxy.result_s("sbjglx");//社保机构类型：A：职工  B：居民

                    p.SIMainInfo.IndividualBalance = (decimal)this.seiInterfaceProxy.result_n("ye");//余额
                    p.SIMainInfo.SiState = this.seiInterfaceProxy.result_s("zfbz");// *灰白名单标志:0 代表灰名单,1 白名单
                    p.SIMainInfo.SpecialWorkKind.Name = this.seiInterfaceProxy.result_s("zfsm");//灰白名单说明
                    p.SIMainInfo.ApplyType.ID = this.seiInterfaceProxy.result_s("zhzybz");  //有无15(医保参数制)天内的住院记录1:有 ,0 :无
                    p.SIMainInfo.ApplyType.Name = this.seiInterfaceProxy.result_s("zhzysm");//15(医保参数控制)天内的住院记录说明
                    p.SIMainInfo.Name = this.seiInterfaceProxy.result_s("xm");// 姓名
                    p.Name = p.SIMainInfo.Name;
                    p.Sex.ID = this.ConvertSex(this.seiInterfaceProxy.result_s("xb"));//性别
                    //p.SIMainInfo.Fund.ID = this.seiInterfaceProxy.result_s("yfdxbz");//优抚对象标志,’1’为优抚对象
                    //p.SIMainInfo.Fund.Name = this.seiInterfaceProxy.result_s("yfdxlb");//优抚对象人员类别(汉字说明)
                    p.SIMainInfo.AnotherCity.Name = this.seiInterfaceProxy.result_s("zcyymc"); //存储转出医院名称，不为空则代表转院
                    p.SIMainInfo.AnotherCity.ID = this.seiInterfaceProxy.result_s("ydbz");//是否为异地人员
                    p.SIMainInfo.Disease.Name = this.seiInterfaceProxy.result_s("mzdbjbs");//疾病编码
                    //p.Pact.ID = "3";//省医保
                    p.SIMainInfo.CivilianGrade.ID = this.seiInterfaceProxy.result_s("cbdsbh");//参保地市编号
                    p.SIMainInfo.CivilianGrade.Name = this.seiInterfaceProxy.result_s("cbjgmc");//参保地市名称

                    if (p.SIMainInfo.ProceatePcNo == "379902")
                    {
                        p.Pact.ID = "3";//省直医保
                        p.SIMainInfo.CivilianGrade.ID = p.SIMainInfo.ProceatePcNo;//参保地市编号
                        p.SIMainInfo.CivilianGrade.Name = "山东省直";//参保地市名称
                    }
                    else
                    {
                        p.Pact.ID = "7";//省异地医保
                    }
                    break;

                case ReadCardTypes.无卡:
                    //p.IDCard = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码
                    p.SIMainInfo.CardOrgID = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码

                    p.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.seiInterfaceProxy.result_s("csrq"));//出生日期
                    //p.SIMainInfo.ICCardCode = this.seiInterfaceProxy.result_s("ylzbh");
                    p.Card.ICCard.ID = p.SIMainInfo.ICCardCode;//医保卡号
                    p.SSN = p.SIMainInfo.CardOrgID;
                    p.CompanyName = this.seiInterfaceProxy.result_s("dwmc");//工作单位
                    p.SIMainInfo.ProceatePcNo = this.seiInterfaceProxy.result_s("sbjbm");//社保局编码 ,省直为379902
                    p.SIMainInfo.ApplySequence = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    p.SIMainInfo.PersonType.Name = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    p.SIMainInfo.PersonType.ID = this.seiInterfaceProxy.result_s("sbjglx");//社保机构类型：A：职工  B：居民

                    //p.SIMainInfo.IndividualBalance = (decimal)this.seiInterfaceProxy.result_n("ye");//余额
                    p.SIMainInfo.SiState = this.seiInterfaceProxy.result_s("zfbz");// *灰白名单标志:0 代表灰名单,1 白名单
                    p.SIMainInfo.SpecialWorkKind.Name = this.seiInterfaceProxy.result_s("zfsm");//灰白名单说明
                    p.SIMainInfo.ApplyType.ID = this.seiInterfaceProxy.result_s("zhzybz");  //有无15(医保参数制)天内的住院记录1:有 ,0 :无
                    p.SIMainInfo.ApplyType.Name = this.seiInterfaceProxy.result_s("zhzysm");//15(医保参数控制)天内的住院记录说明
                    p.SIMainInfo.Name = this.seiInterfaceProxy.result_s("xm");// 姓名
                    p.Name = p.SIMainInfo.Name;
                    p.Sex.ID = this.ConvertSex(this.seiInterfaceProxy.result_s("xb"));//性别
                    //p.SIMainInfo.Fund.ID = this.seiInterfaceProxy.result_s("yfdxbz");//优抚对象标志,’1’为优抚对象
                    //p.SIMainInfo.Fund.Name = this.seiInterfaceProxy.result_s("yfdxlb");//优抚对象人员类别(汉字说明)
                    p.SIMainInfo.AnotherCity.Name = this.seiInterfaceProxy.result_s("zcyymc"); //存储转出医院名称，不为空则代表转院
                    p.SIMainInfo.AnotherCity.ID = this.seiInterfaceProxy.result_s("ydbz");//是否为异地人员
                    p.SIMainInfo.Disease.Name = this.seiInterfaceProxy.result_s("mzdbjbs");//疾病编码
                    //p.Pact.ID = "3";//省医保

                    p.SIMainInfo.CivilianGrade.ID = this.seiInterfaceProxy.result_s("cbdsbh");//参保地市编号
                    p.SIMainInfo.CivilianGrade.Name = this.seiInterfaceProxy.result_s("cbjgmc");//参保地市名称

                    if (p.SIMainInfo.ProceatePcNo == "379902")
                    {
                        p.Pact.ID = "3";//省直医保
                        p.SIMainInfo.CivilianGrade.ID = p.SIMainInfo.ProceatePcNo;//参保地市编号
                        p.SIMainInfo.CivilianGrade.Name = "山东省直";//参保地市名称
                    }
                    else
                    {
                        p.Pact.ID = "7";//省异地医保
                    }
                    break;
            }

            return 1;
        }

        /// <summary>
        /// 读卡后,设置门诊患者基本信息
        /// </summary>
        /// <param name="r">患者挂号信息实体</param>
        /// <param name="readCardType">当前读卡状态</param>
        /// <returns></returns>
        private int SetOutpatientRegInfo(Neusoft.HISFC.Models.Registration.Register r, ReadCardTypes readCardType)
        {
            string name = string.Empty;
            switch (readCardType)
            {
                case ReadCardTypes.门诊读卡:
                    //r.IDCard = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码
                    r.SIMainInfo.CardOrgID = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码

                    r.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.seiInterfaceProxy.result_s("csrq"));//出生日期
                    r.SIMainInfo.ICCardCode = this.seiInterfaceProxy.result_s("ylzbh");
                    r.Card.ICCard.ID = r.SIMainInfo.ICCardCode;//医保卡号
                    r.SSN = r.SIMainInfo.ICCardCode;
                    r.CompanyName = this.seiInterfaceProxy.result_s("dwmc");//工作单位
                    r.SIMainInfo.ProceatePcNo = this.seiInterfaceProxy.result_s("sbjbm");//社保局编码 ,省直为379902
                    r.SIMainInfo.ApplySequence = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    r.SIMainInfo.PersonType.Name = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    r.SIMainInfo.PersonType.ID = this.seiInterfaceProxy.result_s("sbjglx");//社保机构类型：A：职工  B：居民

                    r.SIMainInfo.IndividualBalance = (decimal)this.seiInterfaceProxy.result_n("ye");//余额
                    r.SIMainInfo.SiState = this.seiInterfaceProxy.result_s("zfbz");// *灰白名单标志:0 代表灰名单,1 白名单
                    r.SIMainInfo.SpecialWorkKind.Name = this.seiInterfaceProxy.result_s("zfsm");//灰白名单说明
                    r.SIMainInfo.ApplyType.ID = this.seiInterfaceProxy.result_s("zhzybz");  //有无15(医保参数制)天内的住院记录1:有 ,0 :无
                    r.SIMainInfo.ApplyType.Name = this.seiInterfaceProxy.result_s("zhzysm");//15(医保参数控制)天内的住院记录说明
                    r.SIMainInfo.Name = this.seiInterfaceProxy.result_s("xm");// 姓名
                    r.Name = r.SIMainInfo.Name;
                    r.Sex.ID = this.ConvertSex(this.seiInterfaceProxy.result_s("xb"));//性别
                    //r.SIMainInfo.Fund.ID = this.seiInterfaceProxy.result_s("yfdxbz");//优抚对象标志,’1’为优抚对象
                    //r.SIMainInfo.Fund.Name = this.seiInterfaceProxy.result_s("yfdxlb");//优抚对象人员类别(汉字说明)
                    r.SIMainInfo.AnotherCity.Name = this.seiInterfaceProxy.result_s("zcyymc"); //存储转出医院名称，不为空则代表转院
                    r.SIMainInfo.AnotherCity.ID = this.seiInterfaceProxy.result_s("ydbz");//是否为异地人员
                    r.SIMainInfo.Disease.Name = this.seiInterfaceProxy.result_s("mzdbjbs");//疾病编码
                    //r.Pact.ID = "3";//省医保

                    r.SIMainInfo.CivilianGrade.ID = this.seiInterfaceProxy.result_s("cbdsbh");//参保地市编号
                    r.SIMainInfo.CivilianGrade.Name = this.seiInterfaceProxy.result_s("cbjgmc");//参保地市名称

                    if (r.SIMainInfo.ProceatePcNo == "379902")
                    {
                        r.Pact.ID = "3";//省直医保
                        r.SIMainInfo.CivilianGrade.ID = r.SIMainInfo.ProceatePcNo;//参保地市编号
                        r.SIMainInfo.CivilianGrade.Name = "山东省直";//参保地市名称
                    }
                    else
                    {
                        r.Pact.ID = "7";//省异地医保
                    }
                    break;


                case ReadCardTypes.无卡:
                    //r.IDCard = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码
                    r.SIMainInfo.CardOrgID = this.seiInterfaceProxy.result_s("shbzhm");//社会保障号码

                    r.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.seiInterfaceProxy.result_s("csrq"));//出生日期
                    r.SIMainInfo.ICCardCode = this.seiInterfaceProxy.result_s("ylzbh");
                    r.Card.ICCard.ID = r.SIMainInfo.ICCardCode;//医保卡号
                    r.SSN = r.SIMainInfo.ICCardCode;
                    r.CompanyName = this.seiInterfaceProxy.result_s("dwmc");//工作单位
                    r.SIMainInfo.ProceatePcNo = this.seiInterfaceProxy.result_s("sbjbm");//社保局编码 ,省直为379902
                    r.SIMainInfo.ApplySequence = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    r.SIMainInfo.PersonType.Name = this.seiInterfaceProxy.result_s("ylrylb");//医疗人员类别

                    r.SIMainInfo.PersonType.ID = this.seiInterfaceProxy.result_s("sbjglx");//社保机构类型：A：职工  B：居民

                    r.SIMainInfo.IndividualBalance = (decimal)this.seiInterfaceProxy.result_n("ye");//余额
                    r.SIMainInfo.SiState = this.seiInterfaceProxy.result_s("zfbz");// *灰白名单标志:0 代表灰名单,1 白名单
                    r.SIMainInfo.SpecialWorkKind.Name = this.seiInterfaceProxy.result_s("zfsm");//灰白名单说明
                    r.SIMainInfo.ApplyType.ID = this.seiInterfaceProxy.result_s("zhzybz");  //有无15(医保参数制)天内的住院记录1:有 ,0 :无
                    r.SIMainInfo.ApplyType.Name = this.seiInterfaceProxy.result_s("zhzysm");//15(医保参数控制)天内的住院记录说明
                    r.SIMainInfo.Name = this.seiInterfaceProxy.result_s("xm");// 姓名
                    r.Name = r.SIMainInfo.Name;
                    r.Sex.ID = this.ConvertSex(this.seiInterfaceProxy.result_s("xb"));//性别
                    //r.SIMainInfo.Fund.ID = this.seiInterfaceProxy.result_s("yfdxbz");//优抚对象标志,’1’为优抚对象
                    //r.SIMainInfo.Fund.Name = this.seiInterfaceProxy.result_s("yfdxlb");//优抚对象人员类别(汉字说明)
                    r.SIMainInfo.AnotherCity.Name = this.seiInterfaceProxy.result_s("zcyymc"); //存储转出医院名称，不为空则代表转院
                    r.SIMainInfo.AnotherCity.ID = this.seiInterfaceProxy.result_s("ydbz");//是否为异地人员
                    r.SIMainInfo.Disease.Name = this.seiInterfaceProxy.result_s("mzdbjbs");//疾病编码
                    //r.Pact.ID = "3";//省医保

                    r.SIMainInfo.CivilianGrade.ID = this.seiInterfaceProxy.result_s("cbdsbh");//参保地市编号
                    r.SIMainInfo.CivilianGrade.Name = this.seiInterfaceProxy.result_s("cbjgmc");//参保地市名称

                    if (r.SIMainInfo.ProceatePcNo == "379902")
                    {
                        r.Pact.ID = "3";//省直医保
                        r.SIMainInfo.CivilianGrade.ID = r.SIMainInfo.ProceatePcNo;//参保地市编号
                        r.SIMainInfo.CivilianGrade.Name = "山东省直";//参保地市名称
                    }
                    else
                    {
                        r.Pact.ID = "7";//省异地医保
                    }
                    break;

            }

            return 1;
        }

        #region 这个region里上面的方法没有用到过

        #endregion

        /// <summary>
        /// 批量上传住院患者费用
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <param name="feeDetails">住院患者费用信息实体集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UploadFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref System.Collections.ArrayList feeDetails)
        {
            int returnValue = 0;

            string transType = string.Empty;
            DateTime dt = DateTime.MinValue;
            string doctCode = string.Empty;

            string centerDeptID = string.Empty;
            if (this.localManager.GetComparedDoctCode(patient.PVisit.PatientLocation.Dept.ID, "1", ref centerDeptID) != 1)
            {
                this.errText = "获取医保对照信息出错！";
                return -1;
            }
            if (string.IsNullOrEmpty(centerDeptID))
            {
                this.errText = "获取科室对照信息出错！" + "【" + patient.PVisit.PatientLocation.Dept.ID + "】未进行科室对照！";
                return -1;
            }
            returnValue = this.seiInterfaceProxy.init_zy(patient.ID);
            if (returnValue != 0)
            {
                this.errText = "初始化住院信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList itemList in feeDetails)
            {
                if (itemList.TransType == Neusoft.HISFC.Models.Base.TransTypes.Negative)
                {
                    transType = "2";
                }
                else
                {
                    transType = "1";
                }
                Neusoft.FrameWork.Models.NeuObject obj = this.localManager.QueryInpatientFeeItemInfo(patient.ID, itemList.RecipeNO, itemList.SequenceNO, transType);
                if ((obj != null && !string.IsNullOrEmpty(obj.ID)) || patient.PVisit.InState.ID.Equals("I"))
                {
                    #region 调用接口上传明细方法,住院


                    returnValue = this.seiInterfaceProxy.new_zy_item();//新增加一条凭单信息
                    if (returnValue != 0)
                    {
                        this.errText = "新增凭单信息失败 \n错误代码：" + returnValue + "错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    #region 参数赋值
                    returnValue = this.seiInterfaceProxy.set_zy_item_string("yyxmbm", itemList.Item.ID);//医院项目编码
                    if (returnValue != 0)
                    {
                        this.errText = "赋值医院项目编码信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    decimal price = itemList.Item.Price / itemList.Item.PackQty;
                    returnValue = this.seiInterfaceProxy.set_zy_item_dec("dj", (double)price);//最小包装单价
                    if (returnValue != 0)
                    {
                        this.errText = "赋值最小包装单价信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }


                    returnValue = this.seiInterfaceProxy.set_zy_item_dec("sl", (double)(itemList.Item.Qty / itemList.Item.PackQty));//大包装数量
                    if (returnValue != 0)
                    {
                        this.errText = "赋值大包装数量信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_dec("bzsl", (double)itemList.Item.PackQty);//大包装中包含小包装的数量
                    if (returnValue != 0)
                    {
                        this.errText = "赋值大包装中含小包装的数量信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    decimal totCost = itemList.Item.Price * itemList.Item.Qty / itemList.Item.PackQty;
                    totCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2));
                    returnValue = this.seiInterfaceProxy.set_zy_item_dec("zje", (double)totCost); //总金额
                    if (returnValue != 0)
                    {
                        this.errText = "赋值总金额信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }


                    returnValue = this.seiInterfaceProxy.set_zy_item_string("ksbm", centerDeptID);//科室编码
                    if (returnValue != 0)
                    {
                        this.errText = "赋值科室信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    string operDeptID = string.Empty;
                    if (this.localManager.GetComparedDoctCode(itemList.ExecOper.Dept.ID, "1", ref operDeptID) != 1)
                    {
                        this.errText = "获取对照的科室信息出错！" + this.localManager.Err;
                        return -1;
                    }
                    if (string.IsNullOrEmpty(operDeptID))
                    {
                        this.errText = "获取科室对照信息出错！" + "【" + itemList.ExecOper.Dept.ID + "】未进行科室对照！";
                        return -1;
                    }
                    returnValue = this.seiInterfaceProxy.set_zy_item_string("kdksbm", operDeptID);//开单科室编码
                    if (returnValue != 0)
                    {
                        this.errText = "赋值开单科室信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    if (itemList.Item.Specs == null)
                    {
                        itemList.Item.Specs = "1" + itemList.Item.PriceUnit + "/" + itemList.Item.PriceUnit;
                    }

                    if (itemList.Item.Specs.Length > 30)
                    {
                        itemList.Item.Specs = itemList.Item.Specs.Substring(0, 30);
                    }
                    returnValue = this.seiInterfaceProxy.set_zy_item_string("gg", itemList.Item.Specs);//规格
                    if (returnValue != 0)
                    {
                        this.errText = "赋值项目规格信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_string("zxksbm", operDeptID);//执行科室
                    if (returnValue != 0)
                    {
                        this.errText = "赋值执行科室信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    decimal rate = 0m;
                    if (!string.IsNullOrEmpty(itemList.User01.ToString()))
                    {
                        ArrayList rateList = this.localManager.QueryComparedItemCenterRate("2", itemList.Item.ID);
                        if (rateList == null)
                        {
                            MessageBox.Show("获取项目【" + itemList.Item.Name + "】的对照信息的中心自付比例失败 " + this.localManager.Err);
                            return -1;
                        }
                        else if (rateList.Count == 0)
                        {
                            MessageBox.Show("项目【" + itemList.Item.Name + "】没有进行对照或是目录外的项目 " + this.localManager.Err);
                            return -1;
                        }
                        else if (rateList.Count == 1)
                        {
                            itemList.User01 = "0";
                        }
                        rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(itemList.User01.ToString());
                    }
                    else
                    {
                        if (patient.PVisit.InState.ID.Equals("I"))
                        {
                            ArrayList rateList = this.localManager.QueryComparedItemCenterRate("2", itemList.Item.ID);
                            if (rateList == null)
                            {
                                continue;
                            }
                            else if (rateList.Count == 0)
                            {
                                continue;
                            }
                            else
                            {
                                rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(((Neusoft.FrameWork.Models.NeuObject)rateList[0]).Name.ToString());
                            }
                        }
                        else
                        {
                            this.errText = "获取项目【" + itemList.Item.Name + "】的自付比例失败，请确定该项目是否已经审核";

                            return -1;
                        }
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_dec("jyzfbl", (double)rate);//自付比例
                    if (returnValue != 0)
                    {
                        this.errText = "赋值自付比例信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_string("yyxmmc", itemList.Item.Name);//医院项目名称
                    if (returnValue != 0)
                    {
                        this.errText = "赋值医院项目名称信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_string("yzlsh", "");//医嘱流水号
                    if (returnValue != 0)
                    {
                        this.errText = "赋值医嘱流水号信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    returnValue = this.seiInterfaceProxy.set_zy_item_string("sfryxm", itemList.FeeOper.Name);//收费员姓名
                    if (returnValue != 0)
                    {
                        this.errText = "赋值收款员信息失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }

                    #endregion

                    returnValue = this.seiInterfaceProxy.save_zy_item();
                    if (returnValue != 0)
                    {
                        this.errText = "保存住院费用信息失败\n参数赋值以后 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                        return -1;
                    }
                    #endregion
                }
                else
                {
                    this.errText = "生成住院费用凭单信息失败！\n" + this.localManager.Err;
                    return -1;
                }

                dt = itemList.FeeOper.OperTime.Date;
                //doctCode = itemList.RecipeOper.ID;//{AD059F22-F8F6-45F1-A74E-9942F651D019}
            }

            if (dt > patient.PVisit.OutTime && patient.PVisit.OutTime > new DateTime(2010, 01, 01))//{4F9D25BE-09A0-4fa3-A339-EC58E5374B8F}
            {
                dt = patient.PVisit.OutTime;
            }

            //判断医师编码是否为空
            string centerDoctID = string.Empty;
            //{AD059F22-F8F6-45F1-A74E-9942F651D019}
            //doctCode = patient.PVisit.AdmittingDoctor.ID;
            doctCode = patient.PVisit.ConsultingDoctor.ID;//主任医师

            if (string.IsNullOrEmpty(doctCode))
            {
                this.errText = "保存住院患者费用凭单信息失败\n医师代码为空值 \n错误代码：01" + "\n错误内容：没有找到开立医师的编码";
                return -1;
            }
            else
            {
                if (this.localManager.GetComparedDoctCode(doctCode, "0", ref centerDoctID) != 1)
                {
                    this.errText = "获取对照的医师信息出错！" + this.localManager.Err;
                    return -1;
                }
            }
            //if (string.IsNullOrEmpty(centerDoctID))
            //{
            //    centerDoctID = doctCode;
            //}
            returnValue = this.seiInterfaceProxy.save_zy_script(centerDoctID, dt);
            if (returnValue != 0)
            {
                this.errText = "保存住院患者费用凭单信息失败\n中心医师代码：" + centerDoctID + "\n费用日期：" + dt.ToString() + "\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 删除已上传的所有费用凭单
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int DeleteUploadedFeeDetailsAllInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            int returnValue = 0;

            returnValue = this.seiInterfaceProxy.init_zy(patient.ID);
            if (returnValue != 0)
            {
                this.errText = "初始化住院登记信息失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }

            returnValue = this.seiInterfaceProxy.destroy_all_fypd();
            if (returnValue != 0)
            {
                this.errText = "撤销医保患者【" + patient.Name + "】已上传的费用凭单失败。\n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 根据需求将此方法征用
        /// 获取中心对照好的目录信息
        /// </summary>
        /// <param name="undrugLists"></param>
        /// <returns></returns>
        public int QueryUndrugLists(ref System.Collections.ArrayList comparedList, string pactCode)
        {
            DateTime sysDate = this.localManager.GetDateTimeFromSysDateTime();

            string filePathZL = Application.StartupPath + "\\DownloadFile\\comparedItemList-s.txt";

            //如果有先删除
            if (System.IO.File.Exists(filePathZL))
            {
                System.IO.File.Delete(filePathZL);
            }

            string logPath = Application.StartupPath + "\\DownloadFile\\ComparedLog.log";
            if (System.IO.File.Exists(logPath))
            {
                System.IO.File.Delete(logPath);
            }

            //int returnValue = this.seiInterfaceProxy.down_yyxm("379902", filePathZL, 1, false);
            int returnValue = this.seiInterfaceProxy.down_yyxm_info("372500", filePathZL, 1, false, "2");

            if (returnValue != 0)
            {
                this.errText = "下载医保已对照完的药品和非药品目录失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }

            #region 目录读取
            System.IO.StreamReader sr = new System.IO.StreamReader(filePathZL, System.Text.Encoding.Default);
            Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();

            try
            {
                string line = "";
                Neusoft.HISFC.Models.SIInterface.Compare compare = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                        continue;
                    char[] v = new char[] { (char)'\t' };
                    string[] vstr = line.Split(v);
                    if (vstr.Length < 17)
                    {
                        continue;
                    }
                    compare = new Neusoft.HISFC.Models.SIInterface.Compare();

                    if (this.localManager.WirteDebugLog(logPath, vstr[0].ToString() + "   " + vstr[1].ToString() + "   " + vstr[4].ToString()) == -1)
                    {
                        this.errText = this.localManager.Err;
                        return -1;
                    }
                    compare.CenterItem.PactCode = pactCode;
                    compare.HisCode = vstr[0];
                    if (compare.HisCode.Substring(0, 1) == "F" || compare.HisCode.Substring(0, 1) == "Y")
                    {
                        compare.Name = vstr[1];
                        compare.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(vstr[2].ToString());
                        compare.CenterItem.Memo = vstr[3];
                        compare.CenterItem.ID = vstr[4];
                        compare.CenterItem.Specs = vstr[5];
                        compare.CenterItem.Unit = vstr[6];
                        compare.CenterItem.MaxPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(vstr[7].ToString());
                        compare.CenterItem.DoseCode = vstr[8];
                        compare.CenterItem.Company = vstr[9];
                        compare.CenterItem.ReceipeFlag = vstr[10];
                        compare.CenterItem.GMPFlag = vstr[11];
                        compare.CenterItem.PackUnit = vstr[12];
                        compare.CenterItem.MaxNumber = Neusoft.FrameWork.Function.NConvert.ToDecimal(vstr[13].ToString());
                        compare.CenterItem.UpdateDate = vstr[14].ToString();
                        compare.CenterItem.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(vstr[15].ToString());
                        compare.CenterItem.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(vstr[16].ToString());
                        compare.CenterItem.OperCode = this.oper.ID;
                        compare.CenterItem.OperDate = sysDate;

                        spell = (Neusoft.HISFC.Models.Base.Spell)this.spellManager.Get(compare.Name.Trim());
                        compare.CenterItem.SpellCode = spell.SpellCode;
                        compare.CenterItem.WBCode = spell.WBCode;

                        if (compare.HisCode.Substring(0, 1) == "F")
                        {
                            compare.CenterItem.SysClass = "2";
                        }
                        else
                        {
                            compare.CenterItem.SysClass = "1";
                        }

                        comparedList.Add(compare);

                    }
                }
            }
            catch (Exception ex)
            {
                this.errText = "解析下载的医保和本地项目的对照目录文档失败 \n" + ex.Message;
                return -1;
            }
            finally
            {
                sr.Close();
            }
            #endregion

            return 1;
        }

        /// <summary>
        /// 获取中心的目录信息
        /// </summary>
        /// <param name="drugLists"></param>
        /// <returns></returns>
        public int QueryDrugLists(ref System.Collections.ArrayList drugLists, string pactCode)
        {
            DateTime sysDate = this.localManager.GetDateTimeFromSysDateTime();

            string filePathZL = Application.StartupPath + "\\DownloadFile\\centerItemList-s.txt";

            //如果有先删除
            if (System.IO.File.Exists(filePathZL))
            {
                System.IO.File.Delete(filePathZL);
            }

            int returnValue = this.seiInterfaceProxy.down_ml("372500", filePathZL, "", 1, false);

            if (returnValue != 0)
            {
                this.errText = "下载医保药品和非药品目录失败 \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext();
                return -1;
            }

            #region 药品目录读取
            System.IO.StreamReader sr = new System.IO.StreamReader(filePathZL, System.Text.Encoding.Default);
            Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();

            try
            {
                string line = "";
                Neusoft.HISFC.Models.SIInterface.Item cenItem = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                        continue;
                    char[] v = new char[] { (char)'\t' };
                    string[] vstr = line.Split(v);
                    if (vstr.Length < 17)
                    {
                        continue;
                    }
                    cenItem = new Neusoft.HISFC.Models.SIInterface.Item();
                    //cenItem.PactCode = "3";
                    cenItem.PactCode = pactCode;
                    cenItem.ID = vstr[0];
                    cenItem.Name = vstr[1];
                    cenItem.Indications = vstr[2];//适用症
                    cenItem.Inhisbition = vstr[3];//禁忌
                    cenItem.Specs = vstr[4];//规格
                    cenItem.Unit = vstr[5];//单位
                    cenItem.MaxPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(vstr[6]);//参考价
                    cenItem.DoseCode = vstr[7];//剂型
                    cenItem.ValidFlag = vstr[8];//注销标志
                    cenItem.Company = vstr[9];//生产企业
                    cenItem.ProdCode = vstr[10];//产地名
                    cenItem.ReceipeFlag = vstr[11];//处方药标志
                    cenItem.GMPFlag = vstr[12];//GMP标志
                    cenItem.PackUnit = vstr[13];//包装单位
                    cenItem.MinSpecs = vstr[14];//中心规格
                    cenItem.MaxNumber = Neusoft.FrameWork.Function.NConvert.ToDecimal(vstr[15]);//恒为1
                    cenItem.UpdateDate = vstr[16];
                    cenItem.OperCode = oper.ID;
                    cenItem.OperDate = sysDate;

                    spell = (Neusoft.HISFC.Models.Base.Spell)this.spellManager.Get(cenItem.Name.Trim());
                    cenItem.SpellCode = spell.SpellCode;
                    cenItem.WBCode = spell.WBCode;

                    drugLists.Add(cenItem);
                }
            }
            catch (Exception ex)
            {
                this.errText = "解析下载的医保目录文档失败 \n" + ex.Message;
                return -1;
            }
            finally
            {
                sr.Close();
            }
            #endregion

            return 1;
        }
        #endregion
    }
}
