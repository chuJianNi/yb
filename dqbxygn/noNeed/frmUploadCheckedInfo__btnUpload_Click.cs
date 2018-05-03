using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace noNeed
{
    public class frmUploadCheckedInfo__btnUpload_Click
    {
        //这是原 “上传方法” 我把旧的内容放到这里，重新写我需要的

        #region 这是原 “上传方法” 我把旧的内容放到这里，重新写我需要的
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            long returnValue = 0;

            if (this.tabControl1.SelectedIndex == 0)
            {
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item in this.unUploadItemList)
                {
                    this.unUploadMedList.Add(item);
                }
                this.localManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.proManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                returnValue = this.proManager.Connect();
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口登陆医保服务器失败！" + this.proManager.ErrMsg, "错误提示");
                    return;
                }

                //returnValue = this.proManager.UploadFeeDetailsInpatient(this.Patient, ref this.unUploadMedList);
                returnValue = this.proManager.SortFeeItemList(this.Patient, this.unUploadMedList);
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口上传患者费用凭单失败！" + this.proManager.ErrMsg, "错误提示");
                    return;
                }

                //returnValue = this.proManager.UploadFeeDetailsInpatient(this.Patient, ref this.unUploadItemList);
                //returnValue = this.proManager.SortFeeItemList(this.Patient, this.unUploadItemList);
                //if (returnValue != 1)
                //{
                //    MessageBox.Show("待遇接口上传患者费用凭单失败！" + this.proManager.ErrMsg, "错误提示");
                //    return;
                //}

                #region 更新上传标志
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in this.unUploadItemList)
                {
                    if (this.localManager.updateUploadFlagInpatient(f) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新本地上传标志出错！！" + this.localManager.Err, "错误提示");
                        break;
                        return;
                    }
                }

                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in this.unUploadMedList)
                {
                    if (this.localManager.updateUploadFlagInpatient(f) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新本地上传标志出错！！" + this.localManager.Err, "错误提示");
                        break;
                        return;
                    }
                }
                #endregion

                returnValue = this.proManager.Disconnect();
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口断开登陆医保服务器失败！", "错误提示");
                    return;
                }

                returnValue = this.proManager.Commit();
                if (returnValue < 0)
                {
                    MessageBox.Show("待遇接口提交事务失败！", "错误提示");
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show("费用凭单导入成功！", "友情提示");
            }
            else
            {
                this.proManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.localManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                returnValue = this.proManager.Connect();
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口登陆医保服务器失败！" + this.proManager.ErrMsg, "错误提示");
                    return;
                }

                returnValue = this.proManager.DeleteUploadedFeeDetailsAllInpatient(this.Patient);
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口上传患者费用凭单失败！" + this.proManager.ErrMsg, "错误提示");
                    return;
                }



                returnValue = this.proManager.Disconnect();
                if (returnValue != 1)
                {
                    MessageBox.Show("待遇接口断开登陆医保服务器失败！", "错误提示");
                    return;
                }

                #region 更新上传标志

                if (this.localManager.updateUploadFlagInpatientItem(this.Patient) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新本地上传标志出错！！" + this.localManager.Err, "错误提示");
                    return;
                }

                if (this.localManager.updateUploadFlagInpatientMedicine(this.Patient) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新本地上传标志出错！！" + this.localManager.Err, "错误提示");
                    return;
                }

                #endregion

                returnValue = this.proManager.Commit();
                if (returnValue < 0)
                {
                    MessageBox.Show("待遇接口提交事务失败！", "错误提示");
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show("撤销已上传费用凭单成功！", "友情提示");
            }
        }
        #endregion
        

    }
}
