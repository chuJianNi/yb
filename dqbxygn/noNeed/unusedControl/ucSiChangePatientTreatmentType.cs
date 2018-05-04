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
    public partial class ucSiChangePatientTreatmentType : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSiChangePatientTreatmentType()
        {
            InitializeComponent();
        }

        #region 变量

        Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();

        Neusoft.HISFC.BizLogic.Manager.UserManager operManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();

        LocalManager localManager = new LocalManager();

        #endregion


        #region
        /// <summary>
        /// 查询医保患者列表
        /// </summary>
        /// <returns></returns>
        public void InitSIPatientList()
        {
            ArrayList siPatientList = this.localManager.QuerySIPatientListInpatient("%%");

            if (siPatientList == null)
            {
                MessageBox.Show("初始化医保患者列表失败 "+this.localManager.Err);
                return;
            }

            this.tvSIPatientList.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "全院医保患者(省、市)";
            this.tvSIPatientList.Nodes.Add(root);
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in siPatientList)
            {
                TreeNode node = new TreeNode();
                node.Text = p.Name + "-" + p.Pact.Name;
                node.Tag = p;
                root.Nodes.Add(node);
            }

            root.ExpandAll();
        }

        /// <summary>
        /// 初始化治疗方式列表
        /// </summary>
        public void InitTreatmentTypeList()
        {
            this.cmbTreatmentType.AddItems(this.constant.GetList("TreatmentType"));

            this.cmbForeTreatment.AddItems(this.constant.GetList("TreatmentType"));
           
        }

    
        /// <summary>
        /// 设置界面上患者信息
        /// </summary>
        /// <param name="p"></param>
        public void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo p)
        {
            this.txtPatientNo.Text = p.ID;
            this.txtName.Text = p.Name;
            this.txtPactName.Text = p.Pact.Name;
            this.txtDeptName.Text = p.PVisit.PatientLocation.Dept.Name;
            this.txtInDate.Text = p.PVisit.InTime.ToString();
            this.txtTreatLevel.Text = p.ExtendFlag1.ToString();
            if (!string.IsNullOrEmpty(p.ExtendFlag.ToString()))
            {
                this.cmbForeTreatment.Tag = p.ExtendFlag.ToString();
            }
            else
            {
                this.cmbForeTreatment.Tag = "";
            }
        }

        /// <summary>
        /// 查询显示患者治疗方式变更记录
        /// </summary>
        /// <param name="patientNo"></param>
        public void SetSIPatientChangeHistoryInfo(string patientNo)
        {
            try
            {
                int i = 0;

                this.neuFpEnter1_Sheet1.RowCount = 0;

                ArrayList historyList = this.localManager.QuerySIpatientTreatmentChangeHistoryList(patientNo);

                if (historyList == null)
                {
                    MessageBox.Show("获取医保患者治疗方式变更记录出错 " + this.localManager.Err);
                    return;
                }

                foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in historyList)
                {
                    this.neuFpEnter1_Sheet1.Rows.Add(i, 1);
                    this.neuFpEnter1_Sheet1.Cells[i, 0].Text = p.ID;//住院号
                    this.neuFpEnter1_Sheet1.Cells[i, 1].Text = p.Name;//姓名
                    this.neuFpEnter1_Sheet1.Cells[i, 2].Text = p.Sex.Name;//性别
                    this.neuFpEnter1_Sheet1.Cells[i, 3].Text = p.Pact.Name;//合同单位
                    this.neuFpEnter1_Sheet1.Cells[i, 4].Text = p.PVisit.PatientLocation.Dept.Name;//在院科室
                    this.neuFpEnter1_Sheet1.Cells[i, 5].Text = p.PVisit.InTime.ToString();//住院日期
                    this.neuFpEnter1_Sheet1.Cells[i, 6].Text = p.ExtendFlag.ToString();//前治疗方式
                    this.neuFpEnter1_Sheet1.Cells[i, 7].Text = p.ExtendFlag1.ToString();//前限价等级
                    this.neuFpEnter1_Sheet1.Cells[i, 8].Text = p.ExtendFlag2.ToString();//后治疗方式
                    this.neuFpEnter1_Sheet1.Cells[i, 9].Text = p.Kin.ID.ToString();//后限价等级
                    this.neuFpEnter1_Sheet1.Cells[i, 10].Text = p.Kin.Name.ToString();//操作人
                    this.neuFpEnter1_Sheet1.Cells[i, 11].Text = p.Kin.Memo.ToString();//操作日期

                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询医保患者治疗方式变更记录出现异常"+ex.Message,"错误提示");
                return;
            }
        }


        /// <summary>
        /// 修改治疗方式后，增加到下面的显示列表中
        /// </summary>
        public void AddNewTreatmentInfoToFP()
        {
            try
            {
                int count = this.neuFpEnter1_Sheet1.Rows.Count;

                this.neuFpEnter1_Sheet1.Rows.Add(count, 1);

                this.neuFpEnter1_Sheet1.Cells[count, 0].Text = patient.ID;//住院号
                this.neuFpEnter1_Sheet1.Cells[count, 1].Text = patient.Name;//姓名
                this.neuFpEnter1_Sheet1.Cells[count, 2].Text = patient.Sex.Name;//性别
                this.neuFpEnter1_Sheet1.Cells[count, 3].Text = patient.Pact.Name;//合同单位
                this.neuFpEnter1_Sheet1.Cells[count, 4].Text = patient.PVisit.PatientLocation.Dept.Name;//在院科室
                this.neuFpEnter1_Sheet1.Cells[count, 5].Text = patient.PVisit.InTime.ToString();//住院日期
                if (this.cmbForeTreatment.SelectedIndex > -1)
                {
                    this.neuFpEnter1_Sheet1.Cells[count, 6].Text = this.cmbForeTreatment.SelectedItem.Name.ToString();//前治疗方式
                    this.neuFpEnter1_Sheet1.Cells[count, 7].Text = this.cmbForeTreatment.SelectedItem.Memo.ToString();//前限价等级
                }
                else
                {
                    this.neuFpEnter1_Sheet1.Cells[count, 6].Text ="无";//前治疗方式
                    this.neuFpEnter1_Sheet1.Cells[count, 7].Text = "无";//前限价等级
                }
                this.neuFpEnter1_Sheet1.Cells[count, 8].Text = this.cmbTreatmentType.SelectedItem.Name.ToString();//后治疗方式
                this.neuFpEnter1_Sheet1.Cells[count, 9].Text = this.cmbTreatmentType.SelectedItem.Memo.ToString();//后限价等级
                this.neuFpEnter1_Sheet1.Cells[count, 10].Text = this.operManager.Operator.Name.ToString();//操作人
                this.neuFpEnter1_Sheet1.Cells[count, 11].Text = System.DateTime.Now.ToString();//操作日期
            }
            catch (Exception ex)
            {
                MessageBox.Show("给列表赋值出错！"+ex.Message,"错误提示");
                return;
            }
        }

        #endregion


        #region 事件

        private void ucSiChangePatientTreatmentType_Load(object sender, EventArgs e)
        {
            this.InitSIPatientList();
            this.InitTreatmentTypeList();
        }

        /// <summary>
        /// 选择节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSIPatientList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            patient = e.Node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

            ArrayList patientList = this.localManager.QuerySIPatientListInpatient(patient.ID);

            patient = patientList[0] as Neusoft.HISFC.Models.RADT.PatientInfo;

            this.SetPatientInfo(patient);

            this.SetSIPatientChangeHistoryInfo(patient.ID);
        }


        /// <summary>
        /// 单条查询患者时
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo == "")
            {
                MessageBox.Show("此住院号不存在，请确认输入的住院号是否正确","友情提示");
                return;
            }

            this.ucQueryInpatientNo1.Select();
            this.ucQueryInpatientNo1.Focus();

            foreach(TreeNode node in this.tvSIPatientList.Nodes[0].Nodes)
            {

                Neusoft.HISFC.Models.RADT.PatientInfo p = node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                if (p.ID == this.ucQueryInpatientNo1.InpatientNo)
                {
                    this.tvSIPatientList.SelectedNode = node;

                    break;
                }

            }
        }

        /// <summary>
        /// 确认修改保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            int returnValue = 0;

            string oldTreatID = "";
            string oldTreatName = "";
            string oldTreatLevel = "";

            if (this.cmbTreatmentType.SelectedIndex < 0)
            {
                MessageBox.Show("请选择新的治疗方式", "友情提示");
                return;
            }

            if (this.cmbForeTreatment.SelectedIndex >-1)
            {
                oldTreatID = this.cmbForeTreatment.SelectedItem.ID;
                oldTreatName = this.cmbForeTreatment.SelectedItem.Name;
                oldTreatLevel = this.cmbForeTreatment.SelectedItem.Memo;
            }
            string treatmentID=this.cmbTreatmentType.SelectedItem.ID;
            string treatmentName=this.cmbTreatmentType.SelectedItem.Name;
            string treatmemtMemo=this.cmbTreatmentType.SelectedItem.Memo;

            if (this.cmbTreatmentType.SelectedItem.ID == patient.ExtendFlag.ToString())
            {
                MessageBox.Show("新的治疗方式必须和原来的治疗方式不同才可以修改","友情提示");
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.localManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            returnValue = this.localManager.InsertSIpatientTreatmentChangeRecord(patient, oldTreatName, treatmentID, treatmentName, treatmemtMemo,operManager.Operator.ID,operManager.Operator.Name);
            if (returnValue < 0)
            {
                MessageBox.Show("保存治疗方式变更记录时出错", "错误提示");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }

            returnValue=this.localManager.UpdateSIpatientTreatmentInmaininfo(patient.ID, treatmentID, treatmemtMemo);
            if (returnValue < 0)
            {
                MessageBox.Show("更新主表中的治疗方式时出错", "错误提示");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("患者【"+patient.Name+"】的治疗方式修改成功","友情提示");

            this.AddNewTreatmentInfoToFP();

            patient.ExtendFlag = treatmentID;
            patient.ExtendFlag1 = treatmemtMemo;

            this.SetPatientInfo(patient);
        }

        #endregion

    }
}
