using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoScan
{
    public partial class frmMain : Form
    {
        private SerialPort m_sp = null;
        private string RESET_COMMAND = "RESET;"; //复位命令，复位到0
        private string CLOSE_COMMAND = "CLOSE;"; //关闭命令
        public string AUTO_COMMAND = "AUTO;";// 自动转动
        public string A_ANGLE_COMMAND = "AANGLE:{0};";// 指定角度，必须带一个0-180的参数

        public frmMain()
        {
            InitializeComponent();
            /*SerialPort sp = null;
            string inputStr = string.Empty;

            Console.WriteLine("input cmd to port,input exit to exit");
            inputStr = Console.ReadLine();

            try
            {
                sp = new SerialPort("COM3", 9600);
                sp.Open();

                while (!string.Equals(inputStr.ToUpper(), "EXIT"))
                {
                    sp.WriteLine(inputStr);
                    Console.WriteLine("input cmd to port,input exit to exit");
                    inputStr = Console.ReadLine();
                }       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (sp != null)
                {
                    sp.Close();
                    sp.Dispose();
                }
            }                

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();  */          
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            UpdateSerialPortData(indata);
        }

        private delegate void UpdateSerialPortDataHandler(string cnt);
        private void UpdateSerialPortData(string cnt)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateSerialPortDataHandler(UpdateSerialPortData),cnt);
            }
            else
            {
                txtResponse.Text += cnt;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void RefreshPorts()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.comboComs.SuspendLayout();
                this.comboComs.Items.Clear();

                this.comboComs.Items.AddRange(SerialPort.GetPortNames());

                if (this.comboComs.Items.Count > 0)
                {
                    this.comboComs.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新串口失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.comboComs.ResumeLayout();
                this.Cursor = Cursors.Default;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void SendCommand(string cmd)
        {
            try
            {
                if ((m_sp == null) || (!m_sp.IsOpen))
                {
                    throw new Exception("串口还未打开，请先打开串口再发送命令");
                }

                m_sp.Write(cmd);                
            }
            catch (Exception ex)
            {
                throw new Exception("串口操作失败，错误消息为：" + ex.Message,ex);
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (m_sp!=null && m_sp.IsOpen)
                {
                    SendCommand(CLOSE_COMMAND);

                    m_sp.Close();
                    m_sp.Dispose();
                    m_sp = null;

                    this.btnOpenCom.Text = "打开串口";
                    this.groupDJ.Enabled = false;
                }
                else
                {
                    m_sp = new SerialPort(this.comboComs.Text, 9600);
                    m_sp.Parity = Parity.None;
                    m_sp.StopBits = StopBits.One;
                    m_sp.DataBits = 8;
                    m_sp.Handshake = Handshake.None;
                    m_sp.RtsEnable = true;

                    m_sp.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);

                    m_sp.Open();

                    SendCommand(RESET_COMMAND);

                    this.btnOpenCom.Text = "关闭串口";
                    this.groupDJ.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口操作失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }          
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                SendCommand(RESET_COMMAND);
            }
            catch (Exception ex)
            {
                MessageBox.Show("复位失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }          
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                SendCommand(AUTO_COMMAND);
            }
            catch (Exception ex)
            {
                MessageBox.Show("自动转动失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }         
        }

        private void btnAAngle_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                SendCommand(string.Format(A_ANGLE_COMMAND,Convert.ToInt32(nudAngle.Value)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("转动到{0}失败，错误消息为：{1}", Convert.ToInt32(nudAngle.Value),ex.Message));
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }      
        }
    }
}
