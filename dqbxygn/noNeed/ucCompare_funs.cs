using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace noNeed
{
    class ucCompare_funs
    {
        #region 属于“增加下载上传相关业务”中的内容
        /// <summary>
        /// 上传医院项目信息
        /// </summary>
        public void UpLoadHisItem()
        {
            string[] blocks = CailiaoCode.Split(',');
            bool isCailiao = false;
            Compare objCom = new Compare();
            string feeStatCode = "";

            Neusoft.HISFC.BizLogic.Pharmacy.Item phaManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            if (this.proManager.Connect() < 0)
            {
                MessageBox.Show("连接医保数据库失败！ " + this.proManager.ErrMsg);
                return;
            }
            if (isDrug)
            {
                string drugType = string.Empty;
                string itemType = string.Empty;
                Neusoft.HISFC.Models.Pharmacy.Item objHis = new Neusoft.HISFC.Models.Pharmacy.Item();
                for (int i = 0; i < this.fpHisItem_Sheet1.Rows.Count; i++)
                {
                    if (this.fpHisItem_Sheet1.Cells[i, 0].Value.ToString() == "True")
                    {
                        drugType = fpHisItem_Sheet1.Cells[i, 11].Text.Trim();
                        //if (drugType.ToString() == "西药" || drugType.ToString() == "草药" || drugType.ToString() == "中成药")
                        //{
                        itemType = "1";//药品
                        //}
                        //else
                        //{
                        //    itemType = "2";//一次性材料
                        //}

                        objHis.ID = this.fpHisItem_Sheet1.Cells[i, 1].Text.Trim();

                        objHis.Name = this.fpHisItem_Sheet1.Cells[i, 2].Text.Trim();

                        objHis.Specs = this.fpHisItem_Sheet1.Cells[i, 5].Text.Trim();

                        objHis.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpHisItem_Sheet1.Cells[i, 7].Text.Trim());

                        objHis.MinUnit = this.fpHisItem_Sheet1.Cells[i, 10].Text.Trim();

                        objHis.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpHisItem_Sheet1.Cells[i, 9].Text.Trim());

                        objHis.PackUnit = this.fpHisItem_Sheet1.Cells[i, 8].Text.Trim();

                        objHis.Product.Name = this.fpHisItem_Sheet1.Cells[i, 13].Text.Trim();

                        decimal price = objHis.Price / objHis.PackQty;

                        objHis.MinFee.ID = this.fpHisItem_Sheet1.Cells[i, 15].Text.Trim().ToString();
                        if (!string.IsNullOrEmpty(objHis.MinFee.ID))
                        {
                            feeStatCode = this.localManager.QueryFeeStatCodeByMinFeeCode(objHis.MinFee.ID);
                        }
                        else
                        {
                            MessageBox.Show("项目【" + objHis.Name + "】的最小费用代码为空，请检查数据的准确性！");

                            return;
                        }
                        if (string.IsNullOrEmpty(feeStatCode))
                        {
                            feeStatCode = this.localManager.QueryFeeStatCodeByMinFeeCodeMZ(objHis.MinFee.ID);
                            if (string.IsNullOrEmpty(feeStatCode))
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                                MessageBox.Show("获取结算项目编号失败，没有找到最小费用【" + objHis.MinFee.ID + "】对应的医保费用类别" + this.localManager.Err);

                                return;
                            }
                        }

                        int returnValue = this.seiInterfaceProxy.add_yyxm_info_all(objHis.ID, objHis.Name, itemType, (double)price, objHis.MinUnit, (double)objHis.PackQty, "", "", objHis.Product.Name, objHis.PackUnit, "", "", "", "", feeStatCode, feeStatCode, "", 0, "");
                        if (returnValue != 0)
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("上传药品信息出错: \n错误代码：" + returnValue + "\n错误内容：" + this.seiInterfaceProxy.get_errtext());
                            return;
                        }
                    }
                }
            }
            else
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug obj = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                for (int i = 0; i < this.fpHisItem_Sheet1.Rows.Count; i++)
                {
                    if (this.fpHisItem_Sheet1.Cells[i, 0].Value.ToString() == "True")
                    {
                        obj.ID = this.fpHisItem_Sheet1.Cells[i, 1].Text.Trim();

                        obj.Name = this.fpHisItem_Sheet1.Cells[i, 2].Text.Trim();

                        obj.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpHisItem_Sheet1.Cells[i, 5].Text.Trim());

                        obj.PriceUnit = this.fpHisItem_Sheet1.Cells[i, 7].Text.Trim();

                        obj.PackQty = 1;

                        obj.MinFee.ID = this.fpHisItem_Sheet1.Cells[i, 8].Text.Trim();

                        int returnValue = 0;
                        isCailiao = false;
                        for (int k = 0; k < blocks.Length; k++)
                        {
                            if (blocks[k].ToString() == obj.MinFee.ID)
                            {
                                isCailiao = true;
                                break;
                            }
                        }

                        if (!string.IsNullOrEmpty(obj.MinFee.ID))
                        {
                            feeStatCode = this.localManager.QueryFeeStatCodeByMinFeeCode(obj.MinFee.ID);
                        }
                        if (string.IsNullOrEmpty(feeStatCode))
                        {
                            feeStatCode = this.localManager.QueryFeeStatCodeByMinFeeCodeMZ(obj.MinFee.ID);
                            if (string.IsNullOrEmpty(feeStatCode))
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                                MessageBox.Show("获取结算项目编号失败，没有找到最小费用【" + obj.MinFee.ID + "】对应的医保结算类别" + this.localManager.Err);

                                return;
                            }
                        }

                        if (isCailiao)
                        {
                            returnValue = this.seiInterfaceProxy.add_yyxm_info_all(obj.ID, obj.Name, "2", (double)obj.Price, obj.PriceUnit, 1, "", "", "", obj.PriceUnit, "", "", "", "", feeStatCode, feeStatCode, "", 0, "");
                        }
                        else
                        {
                            returnValue = this.seiInterfaceProxy.add_yyxm_info_all(obj.ID, obj.Name, "0", (double)obj.Price, obj.PriceUnit, 1, "", "", "", obj.PriceUnit, "", "", "", "", feeStatCode, feeStatCode, "", 0, "");
                        }
                        if (returnValue != 0)
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("上传诊疗项目信息出错: \n错误代码：" + returnValue + "\n错误内容" + this.seiInterfaceProxy.get_errtext());
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("上传本地项目成功！");
        }
        #endregion
    }
}
