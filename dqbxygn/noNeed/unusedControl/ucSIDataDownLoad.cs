using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LiaoChengZYSI.Control
{
    /// <summary>
    /// 医保信息下载
    /// </summary>
    public partial class ucSIDataDownLoad : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSIDataDownLoad()
        {
            InitializeComponent();
        }

        #region 成员变量
        private Process SIManager = new Process();
        private LocalManager localManager = new LocalManager();
        private string typeCode;
        private ArrayList list = new ArrayList(4096);
        private DataTable data = new DataTable();
        private DataView view;
        private Type STR = Type.GetType("System.String");
        private Type dec = typeof(System.Decimal);
        private Type date = typeof(System.DateTime);
        private bool isShowData = true;
        private Dictionary<string, string> typePair = new Dictionary<string, string>();

        private sei.CoClass_com4hisClass Functions = new sei.CoClass_com4hisClass();

        #endregion
        #region 控件属性
        [Category("控件设置"), DefaultValue(true), Description("是否显示下载的数据,默认显示")]
        public bool IsShowData
        {
            get { return isShowData; }
            set { isShowData = value; }
        }
        #endregion

        #region 初始化
        private void ucSIDataDownLoad_Load(object sender, EventArgs e)
        {
            this.initDownLoadType();
            this.initSIManager();
        }

        private void initSIManager()
        {
            if (this.SIManager == null)
            {
                this.SIManager = new Process();
            }
            if (this.SIManager.Connect() == -1)
            {
                MessageBox.Show("初始化医保接口出错！\n" + this.SIManager.ErrMsg, "提示");
                this.btDownLoad.Enabled = false;
                return;
            }
        }

        private void initDownLoadType()
        {
            #region 列表
            ArrayList list = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();
            item = new Neusoft.FrameWork.Models.NeuObject();
            item.ID = "01";
            item.Name = "对照信息下载";
            list.Add(item);
            this.typePair.Add(item.ID, item.Name);
            this.cbType.AddItems(list);
            #endregion
        }

        private void Clear()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
        }
        #endregion

        #region 事件
        private void neuButton1_Click(object sender, EventArgs e)
        {
            //最先获取类别编码的地方
            string typeCode = this.cbType.Tag.ToString();
            if (!string.IsNullOrEmpty(typeCode))
            {
                this.downLoadData(typeCode);
                this.showData();
            }
        }
        #endregion

        #region 下载数据
        private void downLoadData(string typeCode)
        {
            this.typeCode = typeCode;
            this.Clear();
            switch (typeCode)
            {
                case "01":
                    this.downLoadCompareInfo();
                    break;
                case "02":
                    break;
                case "03":
                    break;
                case "04":
                    break;
                case "05":
                    break;
                case "06":
                    break;
                case "07":
                    break;
            }
        }

        private void downLoadCompareInfo()
        {
            #region 对照信息目录下载
            string filePath = Application.StartupPath + "downloadfile\\dzml.txt";
            if (Functions.down_yyxm("379902", filePath,1,false) != 0)
            {
                string err=Functions.get_errtext();
                MessageBox.Show("下载项目对照信息出错:"+err);
                this.typeCode = string.Empty;
                this.list.Clear();
                return ;
            }
            #endregion
            #region 读取文件
            System.IO.StreamReader reader = new System.IO.StreamReader(filePath, Encoding.Default);
            try
            {
                //初始状态
                this.list.Clear();
                Neusoft.HISFC.Models.SIInterface.Compare objCom;
                int n = 0;
                string line = string.Empty;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line == "")
                        continue;
                    string[] items = line.Split(new char[] { (char)',' });
                    objCom = new Neusoft.HISFC.Models.SIInterface.Compare();
                    //objCom.ID = items[0];
                    objCom.HisCode = items[0];//医院项目编码
                    objCom.Name = items[1];//医院项目名称
                    objCom.CenterItem.ID = items[4];//中心项目编码
                    objCom.CenterItem.DoseCode = items[8];//剂型
                    objCom.CenterItem.Specs = items[5];//规格
                    objCom.CenterItem.Price =Neusoft.FrameWork.Function.NConvert.ToDecimal(items[7]);//医保最高价
                    objCom.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(items[2]);//自负比例
                    objCom.CenterItem.Memo = items[3];//存放自负比例说明
                    objCom.Memo = "2";//标识医保合同单位
                    //diease.User01 = items[0];
                    this.list.Add(objCom);
                }
                //MessageBox.Show("共计:" + this.list.Count + "条记录", "提示");
            }
            catch (Exception exp)
            {
                MessageBox.Show("读取下载文件出错!\n" + exp.Message, "提示");
                this.typeCode = string.Empty;
                this.list.Clear();
                return;
            }
            #endregion
        }
        #endregion

        #region 显示数据
        private void showData()
        {
            if (this.isShowData && !string.IsNullOrEmpty(this.typeCode)) //显示数据
            {
                initTable();
                fillDataInTable();
                this.view = this.data.DefaultView;
                this.neuSpread1_Sheet1.DataSource = this.view;
                this.SetFPFormat();
            }
        }

        private void SetFPFormat()
        {
            if (this.typeCode == "01")
            {
                this.initFPSettingForCompareInfo();
            }
            else
            {

            }
        }

        private void initFPSettingForCompareInfo()
        {
            this.neuSpread1_Sheet1.ColumnHeader.Columns[0].Width = 80;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[1].Width = 80;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[2].Width = 80;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[3].Width = 50;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[4].Width = 50;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[5].Width = 50;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[6].Width = 50;
            this.neuSpread1_Sheet1.ColumnHeader.Columns[7].Width = 130;
        }
        private void initTable()
        {
            this.data.Clear();
            this.data.Columns.Clear();
            if (this.typeCode == "01")
            {
                this.data.Columns.AddRange(new DataColumn[] { 
                                                            new DataColumn("医院项目编号", this.STR),
                                                            new DataColumn("医院项目名称", this.STR),
                                                            new DataColumn("中心项目编号", this.STR),
                                                            new DataColumn("中心项目剂型", this.STR),
                                                            new DataColumn("中心项目规格",this.STR),
                                                            new DataColumn("中心项目价格",this.dec),
                                                            new DataColumn("自付比例", this.dec),
                                                            new DataColumn("自付比例说明", this.STR),
                                                            });
            }
            else
            {

            }
        }

        private void fillDataInTable()
        {
            DataRow row;
            if (this.typeCode == "01") //疾病信息
            {
                foreach (Neusoft.HISFC.Models.SIInterface.Compare objCom in this.list)
                {
                    row = this.data.NewRow();
                    row[0] = objCom.HisCode;
                    row[1] = objCom.Name;
                    row[2] = objCom.CenterItem.ID;
                    row[3] = objCom.CenterItem.DoseCode;
                    row[4] = objCom.CenterItem.Specs;
                    row[5] = objCom.CenterItem.Price;
                    row[6] = objCom.CenterItem.Rate;
                    row[7] = objCom.CenterItem.Memo;
                    this.data.Rows.Add(row);
                }
            }
            else
            {
                //继续添加
            }
        }
        #endregion
        private void btExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "Excel文件(*.xls)|*.xls";
            if (dia.ShowDialog() == DialogResult.OK)
            {
                string fileName = dia.FileName;
                this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            }
        }

    }
}
