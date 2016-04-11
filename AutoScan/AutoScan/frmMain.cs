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
        private string DIST_COMMAND_END = "ROUNDEND";
        private string DIST_COMMAND_D = "DT:";
        private string DIST_COMMAND_A = "AG:";
        private string DIST_COMMAND = "DIST;";//测量命令
        private string RESET_COMMAND = "RESET;"; //复位命令，复位到0
        private string CLOSE_COMMAND = "CLOSE;"; //关闭命令
        public string AUTO_COMMAND = "AUTO;";// 自动转动
        public string A_ANGLE_COMMAND = "AANGLE:{0};";// 指定角度，必须带一个0-180的参数
        private Bitmap m_bitmap = null;

        private List<PointF> m_points = new List<PointF>();
        public frmMain()
        {
            InitializeComponent();
            m_bitmap = new Bitmap(this.picCurve.Width, this.picCurve.Height);
            this.DoubleBuffered = true;
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();
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
                txtResponse.Text = cnt + txtResponse.Text;
                ParseResponse(cnt);
            }
        }

        private void ParseResponse(string cmdResponse)
        {
            if (cmdResponse.Contains(DIST_COMMAND_END))
            {
                using (Graphics g = Graphics.FromImage(m_bitmap))
                {
                    g.FillRectangle(SystemBrushes.ControlDark, picCurve.Bounds);
                    this.picCurve.Image = m_bitmap;
                }
            }
            else if (cmdResponse.Contains(DIST_COMMAND_D))
            {
                string subString = cmdResponse.TrimEnd('\r').Substring(cmdResponse.LastIndexOf(DIST_COMMAND_D) + DIST_COMMAND_D.Length);
                if (subString.Contains(DIST_COMMAND_A))
                {
                    int angleIndex = subString.LastIndexOf(DIST_COMMAND_A);
                    PointF p = new PointF();
                    p.X=Convert.ToInt32(subString.Substring(angleIndex+DIST_COMMAND_A.Length));
                    p.Y=Convert.ToSingle(subString.Substring(0,angleIndex));

                    using (Graphics g = Graphics.FromImage(m_bitmap))
                    {
                        g.TranslateTransform(10, 10);
                        g.FillEllipse(Brushes.Red, p.X - 1, p.Y - 1, 2, 2);
                        this.picCurve.Image = m_bitmap;
                    }
                }
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

        private void btnDistance_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                SendCommand(DIST_COMMAND);
            }
            catch (Exception ex)
            {
                MessageBox.Show("测量距离失败，错误消息为：" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }         
        }

        private void picCurve_Paint(object sender, PaintEventArgs e)
        {

        }        
    }
}
