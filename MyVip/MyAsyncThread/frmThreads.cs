using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsyncThread
{

    /// <summary>
    /// 异步方法 
    /// 1、同步方法卡界面，主线程（UI线程）忙于计算 ，
    ///    异步多线程方法不卡界面，主纯种闲置，计算任务交给子线程完成（不卡界面，就改善用户体验）
    ///    Web开发，发短信通知，发个邮件，
    ///    
    /// 2、
    ///    
    /// </summary>
    public partial class frmThreads : Form
    {
        public frmThreads()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                DoSomething($"第{i}次执行");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Action<string> action = DoSomething;
                action.BeginInvoke($"第{i}次执行", null, null);
            }
        }
        void DoSomething(string name)
        {
            Console.WriteLine($"*******执行{name}***ThreadID:{Thread.CurrentThread.ManagedThreadId}***{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}**");


            Thread.Sleep(2000);

            Console.WriteLine($"*******执行{name}********");
        }
    }
}
