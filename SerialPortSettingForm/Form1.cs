using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;
using System.IO;

namespace SerialPortSettingForm
{
    public partial class SerialPortSettings : Form
    {
        private SerialPort  comport ;
        public SerialPortSettings()
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
            "115200", });
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
        public void InitialzeSerialPort( ref SerialPort serialport)
        {
            this.comport = serialport;
        }

        public string GetSerialPortSettingsString()
        {
            return ("Baud Rate: " + this.comport.BaudRate.ToString() + " | Stop Bits: " + this.comport.StopBits.ToString() + " |  Parity: " + this.comport.Parity.ToString());
        }
        public void InitialzeSerialPortSettings( int baudrate , int databits , StopBits stopbits , Parity parity , string COM ) 
        {
            cmbBaudRate.Text = baudrate.ToString();
            cmbDataBits.Text = databits.ToString();
            cmbStopBits.Text = stopbits.ToString();
            cmbParity.Text = parity.ToString();
            cmbPortName.Text = COM;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();

            comport.BaudRate = int.Parse(cmbBaudRate.Text);
            comport.DataBits = int.Parse(cmbDataBits.Text);
            comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
            comport.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
            comport.PortName = cmbPortName.Text;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
     }
}

//private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
//{
//    // Create a new return report to populate
//    string selected = null;

//    // Retrieve the list of ports currently mounted by the operating system (sorted by name)
//    string[] ports = SerialPort.GetPortNames();

//    // First determain if there was a change (any additions or removals)
//    bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

//    // If there was a change, then select an appropriate default port
//    if (updated)
//    {
//        // Use the correctly ordered set of port names
//        ports = OrderedPortNames();

//        // Find newest port if one or more were added
//        string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

//        // If the port was already open... (see logic notes and reasoning in Notes.txt)
//        if (PortOpen)
//        {
//            if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
//            else if (!String.IsNullOrEmpty(newest)) selected = newest;
//            else selected = ports.LastOrDefault();
//        }
//        else
//        {
//            if (!String.IsNullOrEmpty(newest)) selected = newest;
//            else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
//            else selected = ports.LastOrDefault();
//        }
//    }

//    // If there was a change to the port list, return the recommended default selection
//    return selected;
//}

//private void RefreshComPortList()
//{
//    // Determain if the list of com port names has changed since last checked
//    string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

//    // If there was an update, then update the control showing the user the list of port names
//    if (!String.IsNullOrEmpty(selected))
//    {
//        cmbPortName.Items.Clear();
//        cmbPortName.Items.AddRange(OrderedPortNames());
//        cmbPortName.SelectedItem = selected;
//    }
//}

//private string[] OrderedPortNames()
//{
//    // Just a placeholder for a successful parsing of a string to an integer
//    int num;

//    // Order the serial port names in numberic order (if possible)
//    return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();