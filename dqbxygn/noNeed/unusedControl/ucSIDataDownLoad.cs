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
    /// ҽ����Ϣ����
    /// </summary>
    public partial class ucSIDataDownLoad : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSIDataDownLoad()
        {
            InitializeComponent();
        }

        #region ��Ա����
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
        #region �ؼ�����
        [Category("�ؼ�����"), DefaultValue(true), Description("�Ƿ���ʾ���ص�����,Ĭ����ʾ")]
        public bool IsShowData
        {
            get { return isShowData; }
            set { isShowData = value; }
        }
        #endregion

        #region ��ʼ��
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
                MessageBox.Show("��ʼ��ҽ���ӿڳ���\n" + this.SIManager.ErrMsg, "��ʾ");
                this.btDownLoad.Enabled = false;
                return;
            }
        }

        private void initDownLoadType()
        {
            #region �б�
            ArrayList list = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();
            item = new Neusoft.FrameWork.Models.NeuObject();
            item.ID = "01";
            item.Name = "������Ϣ����";
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

        #region �¼�
        private void neuButton1_Click(object sender, EventArgs e)
        {
            //���Ȼ�ȡ������ĵط�
            string typeCode = this.cbType.Tag.ToString();
            if (!string.IsNullOrEmpty(typeCode))
            {
                this.downLoadData(typeCode);
                this.showData();
            }
        }
        #endregion

        #region ��������
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
            #region ������ϢĿ¼����
            string filePath = Application.StartupPath + "downloadfile\\dzml.txt";
            if (Functions.down_yyxm("379902", filePath,1,false) != 0)
            {
                string err=Functions.get_errtext();
                MessageBox.Show("������Ŀ������Ϣ����:"+err);
                this.typeCode = string.Empty;
                this.list.Clear();
                return ;
            }
            #endregion
            #region ��ȡ�ļ�
            System.IO.StreamReader reader = new System.IO.StreamReader(filePath, Encoding.Default);
            try
            {
                //��ʼ״̬
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
                    objCom.HisCode = items[0];//ҽԺ��Ŀ����
                    objCom.Name = items[1];//ҽԺ��Ŀ����
                    objCom.CenterItem.ID = items[4];//������Ŀ����
                    objCom.CenterItem.DoseCode = items[8];//����
                    objCom.CenterItem.Specs = items[5];//���
                    objCom.CenterItem.Price =Neusoft.FrameWork.Function.NConvert.ToDecimal(items[7]);//ҽ����߼�
                    objCom.CenterItem.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(items[2]);//�Ը�����
                    objCom.CenterItem.Memo = items[3];//����Ը�����˵��
                    objCom.Memo = "2";//��ʶҽ����ͬ��λ
                    //diease.User01 = items[0];
                    this.list.Add(objCom);
                }
                //MessageBox.Show("����:" + this.list.Count + "����¼", "��ʾ");
            }
            catch (Exception exp)
            {
                MessageBox.Show("��ȡ�����ļ�����!\n" + exp.Message, "��ʾ");
                this.typeCode = string.Empty;
                this.list.Clear();
                return;
            }
            #endregion
        }
        #endregion

        #region ��ʾ����
        private void showData()
        {
            if (this.isShowData && !string.IsNullOrEmpty(this.typeCode)) //��ʾ����
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
                                                            new DataColumn("ҽԺ��Ŀ���", this.STR),
                                                            new DataColumn("ҽԺ��Ŀ����", this.STR),
                                                            new DataColumn("������Ŀ���", this.STR),
                                                            new DataColumn("������Ŀ����", this.STR),
                                                            new DataColumn("������Ŀ���",this.STR),
                                                            new DataColumn("������Ŀ�۸�",this.dec),
                                                            new DataColumn("�Ը�����", this.dec),
                                                            new DataColumn("�Ը�����˵��", this.STR),
                                                            });
            }
            else
            {

            }
        }

        private void fillDataInTable()
        {
            DataRow row;
            if (this.typeCode == "01") //������Ϣ
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
                //�������
            }
        }
        #endregion
        private void btExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "Excel�ļ�(*.xls)|*.xls";
            if (dia.ShowDialog() == DialogResult.OK)
            {
                string fileName = dia.FileName;
                this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            }
        }

    }
}
