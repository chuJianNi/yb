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
    public partial class frmUploadFeeDetails : Form
    {
        public frmUploadFeeDetails()
        {
            InitializeComponent();
        }

        #region  变量

        Process proManager = new Process();

        LocalManager localManager = new LocalManager();

        private DataTable dtInpatient = null;
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        private List<Neusoft.HISFC.Models.RADT.PatientInfo> inpatientList = null;
        private String errText = "";
        #endregion

        /// <summary>
        /// 未上传
        /// </summary>
        public ArrayList QueryUnuploadInfo(Neusoft.HISFC.Models.RADT.PatientInfo inpatient)
        {
            ArrayList unUploadItemList = new ArrayList();
            ArrayList unUploadMedList = new ArrayList();
            if (inpatient.PVisit.InState.ID.Equals("B"))
            {
                unUploadItemList = this.localManager.QueryFeeItemListsForSIPatient(inpatient.ID, inpatient.PVisit.InTime.AddDays(-20), inpatient.PVisit.OutTime.AddDays(10), "1", "0");
                unUploadMedList = this.localManager.QueryMedicineListsForSIPatient(inpatient.ID, inpatient.PVisit.InTime.AddDays(-20), inpatient.PVisit.OutTime.AddDays(10), "1", "0");

            }
            else
            {
                unUploadItemList = this.localManager.QueryFeeItemListsForSIPatient(inpatient.ID, inpatient.PVisit.InTime.AddDays(-20), Neusoft.FrameWork.Function.NConvert.ToDateTime(this.localManager.GetSysDateTime()), "0", "0");
                unUploadMedList = this.localManager.QueryMedicineListsForSIPatient(inpatient.ID, inpatient.PVisit.InTime.AddDays(-20), Neusoft.FrameWork.Function.NConvert.ToDateTime(this.localManager.GetSysDateTime()), "0", "0");

            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item in unUploadItemList)
            {
                unUploadMedList.Add(item);
            }
            return unUploadMedList;

        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            this.proManager.SourceObject = this;

            this.dtInpatient = new DataTable();

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtBool = System.Type.GetType("System.Boolean");
            System.Type dtdate = System.Type.GetType("System.DateTime");
            this.lblText.Text = "";

            this.dtInpatient.Columns.AddRange(new DataColumn[] { 
                new DataColumn("选择", dtBool),
                new DataColumn("住院号",dtStr),
                new DataColumn("床号",dtStr),
                new DataColumn("姓名",dtStr),
                new DataColumn("性别",dtStr),
                new DataColumn("出生日期",dtStr),
                new DataColumn("身份证号",dtStr),
                new DataColumn("住院科室",dtStr),
                new DataColumn("护士站",dtStr),
                new DataColumn("入院日期",dtdate),
                new DataColumn("出院日期",dtdate),
                new DataColumn("出院情况",dtStr),
                new DataColumn("是否在院",dtStr),
            });

        }

        /// <summary>
        /// 格式化
        /// </summary>
        public void FormatDatatable()
        {
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选择";
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = false;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 40F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "住院号";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "床号";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 40F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "姓名";
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 60F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "性别";
            this.neuSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 30F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "出生日期";
            this.neuSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 65F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "身份证号";
            this.neuSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "住院科室";
            this.neuSpread1_Sheet1.Columns.Get(7).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "护士站";
            this.neuSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "入院日期";
            this.neuSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "出院日期";
            this.neuSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "出院情况";
            this.neuSpread1_Sheet1.Columns.Get(11).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 60F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "是否在院";
            this.neuSpread1_Sheet1.Columns.Get(12).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 60F;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            long returnValue = 0;
            this.errText = "";

            returnValue = this.proManager.Connect();
            for (int j = 0; j < this.neuSpread1_Sheet1.Rows.Count; j++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[j, 0].Value))
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo inpatient = this.radtManager.QueryPatientInfoByInpatientNO(this.neuSpread1_Sheet1.Cells[j, 1].Value.ToString());
                    errText = errText + "正在上传" + inpatient.Name + "的费用信息......" + "\r\n";
                    ArrayList itemlist = this.QueryUnuploadInfo(inpatient);
                    if (itemlist != null)
                    {
                        //foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList list in itemlist)
                        if (itemlist.Count > 0)
                        {
                            this.localManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            this.proManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);


                            if (returnValue != 1)
                            {
                                errText = errText + ("上传" + inpatient.Name + " 信息失败，待遇接口登陆医保服务器失败！" + this.proManager.ErrMsg + "\r\n");
                                continue;
                            }

                            //returnValue = this.proManager.UploadFeeDetailsInpatient(this.Patient, ref this.unUploadMedList);
                            returnValue = this.proManager.SortFeeItemList(inpatient, itemlist);
                            if (returnValue != 1)
                            {
                                errText = errText + ("上传" + inpatient.Name + " 信息失败，待遇接口上传患者费用凭单失败！" + this.proManager.ErrMsg + "\r\n");
                                continue;
                            }

                            #region 更新上传标志
                            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in itemlist)
                            {
                                if (this.localManager.updateUploadFlagInpatient(f) < 0)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    errText = errText + ("上传" + inpatient.Name + " 信息失败，更新本地上传标志出错！！" + this.localManager.Err + "\r\n");
                                    break;
                                    continue;
                                }
                            }

                            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in itemlist)
                            {
                                if (this.localManager.updateUploadFlagInpatient(f) < 0)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    errText = errText + ("上传" + inpatient.Name + " 信息失败，更新本地上传标志出错！！" + this.localManager.Err + "\r\n");
                                    break;
                                    continue;
                                }
                            }
                            #endregion

                            returnValue = this.proManager.Disconnect();
                            if (returnValue != 1)
                            {
                                errText = errText + ("上传" + inpatient.Name + " 信息失败，待遇接口断开登陆医保服务器失败！" + "\r\n");
                                continue;
                            }

                            returnValue = this.proManager.Commit();
                            if (returnValue < 0)
                            {
                                errText = errText + ("上传" + inpatient.Name + " 信息失败，待遇接口提交事务失败！" + "\r\n");
                                continue;
                            }

                            Neusoft.FrameWork.Management.PublicTrans.Commit();

                            errText = errText + ("上传" + inpatient.Name + " 信息成功，费用凭单导入成功！" + "\r\n");
                        }
                        else
                        {
                            errText = errText + "无可上传费用" + "\r\n";
                        }
                    }
                    else
                    {
                        errText = errText + "取上传费用出错" + "\r\n";
                    }



                }
            }
            this.lblText.Text = this.errText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUploadCheckedInfo_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        //选择所有在院患者
        private void neuCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.neuCheckBox1.Checked)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 12].Value.ToString() == "在院")
                    {
                        this.neuSpread1_Sheet1.Cells[i, 0].Value = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 12].Value.ToString() == "在院")
                    {
                        this.neuSpread1_Sheet1.Cells[i, 0].Value = false;
                    }
                }
            }
        }
        //选择或取消选择所有出院患者
        private void neuCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.neuCheckBox3.Checked)
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 12].Value.ToString() != "在院")
                    {
                        this.neuSpread1_Sheet1.Cells[i, 0].Value = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 12].Value.ToString() != "在院")
                    {
                        this.neuSpread1_Sheet1.Cells[i, 0].Value = false;
                    }
                }
            }
        }
        //查询加载患者信息
        private void button1_Click(object sender, EventArgs e)
        {
            this.inpatientList = this.localManager.GetSiInpatientInfo();
            if (this.inpatientList == null)
            {
                return;
            }
            else
            {
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo inpatient in this.inpatientList)
                {
                    this.dtInpatient.Rows.Add(new object[]
                        {
                            false,
                            inpatient.ID,
                            inpatient.PVisit.PatientLocation.Bed.ID,
                            inpatient.Name,
                            inpatient.Sex.Name,
                            inpatient.Birthday ,
                            inpatient.IDCard ,
                            inpatient.PVisit.PatientLocation.Dept.Name ,
                            inpatient.PVisit.PatientLocation.NurseCell.Name,
                            inpatient.PVisit.InTime ,
                            inpatient.PVisit.OutTime ,
                            inpatient.PVisit.ZG.Name ,
                            inpatient.PVisit.InState.Name,

                        });
                }
                this.neuSpread1_Sheet1.DataSource = this.dtInpatient.DefaultView;
                this.FormatDatatable();

                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 12].Value.ToString() == "在院")
                    {
                        this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.PaleGreen;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Rows[i].BackColor = System.Drawing.Color.BurlyWood;
                    }
                }
            }

        }


    }
}
