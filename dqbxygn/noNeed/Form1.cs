using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private sei3.CoClass_sei4hisClass seiInterfaceProxy_new = new sei3.CoClass_sei4hisClass();
        //private sei3.CoClass_sei4his ss = new sei3.CoClass_sei4hisClass();
        
        public Form1()
        {
            InitializeComponent();
            //seiInterfaceProxy_new = new sei3.CoClass_sei4hisClass();
            
        }

        

        #region 连接接口
        private void button1_Click(object sender, EventArgs e)
        {
            #region new codes
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("yybm", "300774");
            seiInterfaceProxy_new.putvarstring("gzrybh", "0001");
            seiInterfaceProxy_new.putvarstring("pwd", "1234");
            short vi = seiInterfaceProxy_new.request_service("init");

            if (vi == -800)
            {
                MessageBox.Show("接口需要升级。" + vi);
                //return -1;
            }

            if (vi != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show(YBerrText + "S");
                //return -1;
            }
            else
            {
                MessageBox.Show("地纬接口登陆成功。");
                //isInit = true;
                //return 1;
            }

            #endregion
        }
        #endregion           

        #region 住院登记
        private void button3_Click_1(object sender, EventArgs e)
        {
            //住院登记
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("blh", "cs001");
            seiInterfaceProxy_new.putvarstring("grbh", "371502198810122036");
            seiInterfaceProxy_new.putvarstring("kh", "cs001");
            seiInterfaceProxy_new.putvarstring("xm", "测试人员");
            seiInterfaceProxy_new.putvarstring("xb", "cs001");
            seiInterfaceProxy_new.putvarstring("yltclb", "1");
            seiInterfaceProxy_new.putvarstring("yltclbmx", "101");
            seiInterfaceProxy_new.putvarstring("sbjgbh", "37150205");//37150205
            seiInterfaceProxy_new.putvarstring("mzks", "001");
            seiInterfaceProxy_new.putvarstring("ksbm", "001");
            seiInterfaceProxy_new.putvarstring("qzys", "1234");
            //seiInterfaceProxy_new.putvarstring("ryzd", "cs001");
            seiInterfaceProxy_new.putvarstring("xzbz", "C");
            seiInterfaceProxy_new.putvarstring("zyfs", "");
            //seiInterfaceProxy_new.putvarstring("cw", "cs001");
            //seiInterfaceProxy_new.putvarstring("fj", "cs001");
            //seiInterfaceProxy_new.putvarstring("bqsm", "cs001");
            seiInterfaceProxy_new.putvardatetime("zyrq", DateTime.Now);

            short res = seiInterfaceProxy_new.request_service("save_zydj");

            if (res != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("住院登记失败." + YBerrText);
                return;
            }
            else
            {
                MessageBox.Show("住院登记成功。");
                //isInit = true;
                //return 1;
            }

        }
        #endregion

        #region 住院初始化
        private void button6_Click_1(object sender, EventArgs e)
        {
            //住院初始化
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("blh", "cs001");
            short res = seiInterfaceProxy_new.request_service("init_zy");

            if (res != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("住院初始化失败." + YBerrText);
                return;
            }
            else
            {
                MessageBox.Show("住院初始化成功。");
                //isInit = true;
                //return 1;
            }
        }
        #endregion

        #region 将费用明细暂存到系统内存中
        private void button2_Click_1(object sender, EventArgs e)
        {
            //将费用明细暂存到系统内存中
            #region new codes
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("yyxmbm", "YP22221111");
            seiInterfaceProxy_new.putvarstring("yyxmmc", "达克宁");
            seiInterfaceProxy_new.putvardec("dj", 1);
            seiInterfaceProxy_new.putvardec("sl", 10);
            seiInterfaceProxy_new.putvardec("bzsl", 1);
            seiInterfaceProxy_new.putvardec("zje", 11);
            seiInterfaceProxy_new.putvarstring("gg", "");
            seiInterfaceProxy_new.putvardec("sxzfbl", 0.1);
            seiInterfaceProxy_new.putvardatetime("fyfssj", DateTime.Now);
            seiInterfaceProxy_new.putvarstring("zxksbm", "001");
            seiInterfaceProxy_new.putvarstring("kdksbm", "001");
            seiInterfaceProxy_new.putvarstring("sm", "");
            seiInterfaceProxy_new.putvarstring("yzlsh", "");
            seiInterfaceProxy_new.putvarstring("sfryxm", "0009");
            short vi = seiInterfaceProxy_new.request_service("put_fymx");



            if (vi != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("录入费用失败." + YBerrText);
                //return -1;
            }
            else
            {
                MessageBox.Show("住院put_fymx成功。");
                //isInit = true;
                //return 1;
            }


            #endregion
        }
        #endregion
           
        #region 保存费用
        private void button7_Click(object sender, EventArgs e)
        {
            //保存住院费用信息
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("ysbm", "1234");
            seiInterfaceProxy_new.putvardatetime("date", DateTime.Now);

            short reslt = seiInterfaceProxy_new.request_service("save_zy_script");

            if (reslt != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("保存费用失败." + YBerrText);
                //return -1;
            }
            else
            {
                MessageBox.Show("保存住院信息成功。");
                //isInit = true;
                //return 1;
            }
        }              
        #endregion

        #region 删除所有住院费用
        private void button8_Click(object sender, EventArgs e)
        {
            seiInterfaceProxy_new.resetvar();

            short reslt = seiInterfaceProxy_new.request_service("delete_all_fypd");

            if (reslt != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("删除住院费用失败." + YBerrText);
                //return -1;
            }
            else
            {
                MessageBox.Show("删除住院费用成功。");
                //isInit = true;
                //return 1;
            }
        }
        #endregion
       


        
        

        #region 下载医师
        private void button4_Click_1(object sender, EventArgs e)
        {
            //下载医师
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("yybm", "300774");
            seiInterfaceProxy_new.putvarstring("sbjgbh", "37150205");
            seiInterfaceProxy_new.putvarstring("filename", "F:\\ys.txt");
            seiInterfaceProxy_new.putvardec("filetype", 1);
            seiInterfaceProxy_new.putvardec("has_head", 1);
            short res = seiInterfaceProxy_new.request_service("down_ys");

            if (res != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("下载医师失败." + YBerrText);
                return;
            }
            else
            {
                MessageBox.Show("下载医师成功。");
                //isInit = true;
                //return 1;
            }

        }
        #endregion
        

        #region 增加医师
        private void button5_Click_1(object sender, EventArgs e)
        {
            //调用增加医师的服务
            seiInterfaceProxy_new.resetvar();
            seiInterfaceProxy_new.putvarstring("flag", "1");
            seiInterfaceProxy_new.putvarstring("ysbh", "1234");
            seiInterfaceProxy_new.putvarstring("xm", "his测试医师");
            seiInterfaceProxy_new.putvarstring("sfzh", "111");
            seiInterfaceProxy_new.putvarstring("ksbm", "001");
            seiInterfaceProxy_new.putvarstring("bz", "测试");
            seiInterfaceProxy_new.putvarstring("xb", "1");
            seiInterfaceProxy_new.putvarstring("zw", "医师");
            seiInterfaceProxy_new.putvarstring("zyyszbh", "0221");
            seiInterfaceProxy_new.putvarstring("zcyszbh", "1224");
            seiInterfaceProxy_new.putvarstring("yszc", "高级医师");
            seiInterfaceProxy_new.putvarstring("zylb", "001");
            seiInterfaceProxy_new.putvarstring("zyfw", "01");
            seiInterfaceProxy_new.putvarstring("zydd", "山大");
            seiInterfaceProxy_new.putvarstring("bgxx", "");
            seiInterfaceProxy_new.putvarstring("yszt", "1");
            seiInterfaceProxy_new.putvarstring("sbjgbh", "37150205");
            seiInterfaceProxy_new.putvardatetime("csrq", DateTime.Now);

            short res = seiInterfaceProxy_new.request_service("add_ys");

            if (res != 0)
            {
                string YBerrText = seiInterfaceProxy_new.get_errtext();
                MessageBox.Show("增加医师失败." + YBerrText);
                return;
            }
            else
            {
                MessageBox.Show("增加医师成功。");
                //isInit = true;
                //return 1;
            }


        }        
        #endregion        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(seiInterfaceProxy_new);
        }
  
        
    }
}
