using FillStorage.HelperClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FillStorage
{
    public partial class MainForm : Form
    {
        //单位：KB
        private long mAvaliableSize;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AdbHelper.StopServer();
            btnFill.Enabled = false;
        }

        private void ShowInfo(string msg)
        {

            Console.WriteLine(string.Format("ShowInfo {0}", msg));
            this.show_info.Text = msg;
            this.show_info.Refresh();
        }

        private void MainForm_refresh(object sender, MouseEventArgs e)
        {
            ShowInfo("获取设备中...");
            btnRefresh.Enabled = false;
            btnFill.Enabled = false;
            cbbDevices.Items.Clear();
            cbbDevices.Text = "";
            txbDeviceInfo.Text = "";
            //启动服务
            if (!AdbHelper.StartServer())
            {
                ShowInfo("服务启动失败！");
                btnRefresh.Enabled = true;
                return;
            }
            string[] mDevices = AdbHelper.GetDevices();
            if (mDevices.Length == 0)
            {
                ShowInfo("未查找到可用设备！");
                btnRefresh.Enabled = true;
                return;
            }
            cbbDevices.Items.AddRange(mDevices);
            cbbDevices.SelectedIndex = 0;

            btnRefresh.Enabled = true;
            btn_bugreport.Enabled = true;
            btnFill.Enabled = true;
        }

        private void MainForm_fill(object sender, MouseEventArgs e)
        {
            if (mAvaliableSize <= 1024)
            {
                return;
            }
            btnFill.Enabled = false;
            mPushProgressBar.Value = 0;
            mPushProgressText.Text = "0%";
            ShowInfo("生成缓存文件...");
            int reppeat = FileHelper.CreateNewTempFile(mAvaliableSize * 1024);
            mPushProgressBar.Maximum = reppeat;
            mPushProgressBar.Value = 0;
            mPushProgressText.Text = "0%";
            ShowInfo("正在拷贝文件...");
            AdbHelper.CopyToDevice(GetSelectedDeviceNo(), FileHelper.FilePath, AdbHelper.CopyPath, reppeat, mPushProgressBar, mPushProgressText);
            ShowInfo("删除缓存文件");
            FileHelper.DeleteTempFile();
            UpdatePartitionInfo();
            ShowInfo("填充完成！");
            btnFill.Enabled = true;
        }

        private void CbbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("cbbDevices_SelectedIndexChanged");
            var deviceNo = GetSelectedDeviceNo();
            txbDeviceInfo.Text = string.Format("{0} {1}",
                AdbHelper.GetDeviceBrand(deviceNo), 
                AdbHelper.GetDeviceModel(deviceNo));
            UpdatePartitionInfo();
        }

        private void UpdatePartitionInfo()
        {
            Console.WriteLine("GetPartitionInfo begin");
            var partitionInfo = AdbHelper.GetPartitionInfo(GetSelectedDeviceNo(), rb_internal.Checked);
            Console.WriteLine(partitionInfo.Length);
            if (partitionInfo.Length <= 0)
            {
                ShowInfo("获取分区信息失败！");
                Console.WriteLine("获取分区信息失败");
                mAvaliableSize = 0;
                return;
            }
            ShowInfo("");

            try
            {
                mAvaliableSize = long.Parse(partitionInfo[3])/* - (long.Parse(partitionInfo[3]) % 1024)*/;
                Console.WriteLine(mAvaliableSize);
                txb_avail_size.Text = " " + mAvaliableSize / 1024 + " MB";
            }
            catch (Exception)
            {
            }
            if (mAvaliableSize <= (5 * 1024))
            {
                btn_bugreport.Enabled = false;
            }
        }

        private string GetSelectedDeviceNo()
        {
            return Convert.ToString(cbbDevices.SelectedItem);
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            AdbHelper.StopServer();
        }

        private void Rb_Internal_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePartitionInfo();
        }

        private void Rb_Sdcard_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePartitionInfo();
        }

        private void MainForm_Bugreport(object sender, MouseEventArgs e)
        {
            btn_bugreport.Enabled = false;
            ShowInfo("抓取bugreport中，成功后将保存在桌面...");
            AdbHelper.CatchBugreport(GetSelectedDeviceNo());
            ShowInfo("");
        }
    }
}
