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


        #endregion

        #region 属于“Imedcare 成员”中的内容

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
        #endregion
    }
}
