using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.IO.Ports;
using Monitor.Properties;


namespace Monitor
{
    public partial class fmSerialPortSettings : Form
    {
        private Settings settings = new Settings();

        public fmSerialPortSettings()
        {
            InitializeComponent();

            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "76687",
            "117647", });
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            //this.cmbDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDataBits_Validating);
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
        }
        public void InitializePortSettings(ref Settings set)
        {
            this.settings = set;
        }

        public string GetSerialPortSettingsString()
        {
            return ( "Port: " + this.settings.PortName + " | Baud Rate: " + this.settings.BaudRate.ToString() + " | Stop Bits: " + this.settings.StopBits.ToString() + " |  Parity: " + this.settings.Parity.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();

            settings.BaudRate = int.Parse(cmbBaudRate.Text);
            settings.DataBits = int.Parse(cmbDataBits.Text);
            settings.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
            settings.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
            settings.PortName = cmbPortName.Text;
        }
        private void btnCancel_Click(object sender, EventArgs e) 
        {
            this.Hide();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //  这两段 代码 是解决 StopBits 无法更新的 关键.
            cmbStopBits.Items.Clear();
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbBaudRate.Text = settings.BaudRate.ToString();
            cmbDataBits.Text = settings.DataBits.ToString();
            cmbStopBits.Text = settings.StopBits.ToString();
            cmbParity.Text = settings.Parity.ToString();
            cmbPortName.Text = settings.PortName;
        }
    }
}