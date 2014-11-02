using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Runtime.InteropServices;
using System.Text;

namespace mwrf_test
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Label lbPort;
		private System.Windows.Forms.Label lbBaud;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbHardVer;
		private System.Windows.Forms.Label lbSoftVer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnBeep;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbResult;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbSnr;
		private System.Windows.Forms.Button btnSeekCard;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnAuth;
		private System.Windows.Forms.Button btnReadData;
		private System.Windows.Forms.Button btnWriteData;
		private System.Windows.Forms.Button btnValueOp;
		private System.Windows.Forms.ComboBox comboPort;
		private System.Windows.Forms.ComboBox comboBaud;
		private System.Windows.Forms.TextBox textKey;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textSec;
		private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.TextBox textData;
        private Label label10;
        private Label label9;
        private GroupBox groupBox3;
        private TextBox textKeyB;
        private TextBox textKeyA;
        private Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			comboPort.Items.Add("COM1");
			comboPort.Items.Add("COM2");
			comboPort.Items.Add("COM3");
			comboPort.Items.Add("COM4");
			comboBaud.Items.Add("9600");
			comboBaud.Items.Add("19200");
			comboBaud.Items.Add("38400");
			comboBaud.Items.Add("57600");
			comboBaud.Items.Add("115200");
			comboPort.SelectedIndex=0;
			comboBaud.SelectedIndex=4;

			textSec.Text="1";
			textKey.Text="ffffffffffff";
			textData.Text="00112233445566778899aabbccddeeff";
			textValue.Text="10000";

		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.comboBaud = new System.Windows.Forms.ComboBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbBaud = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbHardVer = new System.Windows.Forms.Label();
            this.lbSoftVer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBeep = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnValueOp = new System.Windows.Forms.Button();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnAuth = new System.Windows.Forms.Button();
            this.textData = new System.Windows.Forms.TextBox();
            this.textValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textSec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSeekCard = new System.Windows.Forms.Button();
            this.lbSnr = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textKeyA = new System.Windows.Forms.TextBox();
            this.textKeyB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(312, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(312, 72);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // comboPort
            // 
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.Location = new System.Drawing.Point(120, 32);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(121, 20);
            this.comboPort.TabIndex = 2;
            // 
            // comboBaud
            // 
            this.comboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBaud.Location = new System.Drawing.Point(120, 72);
            this.comboBaud.Name = "comboBaud";
            this.comboBaud.Size = new System.Drawing.Size(121, 20);
            this.comboBaud.TabIndex = 3;
            // 
            // lbPort
            // 
            this.lbPort.Location = new System.Drawing.Point(24, 32);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(72, 20);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "COM";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBaud
            // 
            this.lbBaud.Location = new System.Drawing.Point(24, 72);
            this.lbBaud.Name = "lbBaud";
            this.lbBaud.Size = new System.Drawing.Size(72, 20);
            this.lbBaud.TabIndex = 5;
            this.lbBaud.Text = "baud";
            this.lbBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "FirmwareVer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "API Ver";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHardVer
            // 
            this.lbHardVer.Location = new System.Drawing.Point(120, 112);
            this.lbHardVer.Name = "lbHardVer";
            this.lbHardVer.Size = new System.Drawing.Size(121, 20);
            this.lbHardVer.TabIndex = 8;
            this.lbHardVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSoftVer
            // 
            this.lbSoftVer.Location = new System.Drawing.Point(120, 144);
            this.lbSoftVer.Name = "lbSoftVer";
            this.lbSoftVer.Size = new System.Drawing.Size(121, 20);
            this.lbSoftVer.TabIndex = 9;
            this.lbSoftVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBeep);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 176);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial COM";
            // 
            // btnBeep
            // 
            this.btnBeep.Location = new System.Drawing.Point(304, 104);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(75, 23);
            this.btnBeep.TabIndex = 0;
            this.btnBeep.Text = "Beep";
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnValueOp);
            this.groupBox2.Controls.Add(this.btnWriteData);
            this.groupBox2.Controls.Add(this.btnReadData);
            this.groupBox2.Controls.Add(this.btnAuth);
            this.groupBox2.Controls.Add(this.textData);
            this.groupBox2.Controls.Add(this.textValue);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textSec);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textKey);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSeekCard);
            this.groupBox2.Controls.Add(this.lbSnr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 272);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "mifareone Oper";
            // 
            // btnValueOp
            // 
            this.btnValueOp.Location = new System.Drawing.Point(304, 160);
            this.btnValueOp.Name = "btnValueOp";
            this.btnValueOp.Size = new System.Drawing.Size(75, 23);
            this.btnValueOp.TabIndex = 14;
            this.btnValueOp.Text = "value Oper";
            this.btnValueOp.Click += new System.EventHandler(this.btnValueOp_Click);
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(304, 128);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(75, 23);
            this.btnWriteData.TabIndex = 13;
            this.btnWriteData.Text = "write";
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(304, 96);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 23);
            this.btnReadData.TabIndex = 12;
            this.btnReadData.Text = "read";
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(304, 64);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(75, 23);
            this.btnAuth.TabIndex = 11;
            this.btnAuth.Text = "authention";
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // textData
            // 
            this.textData.Location = new System.Drawing.Point(96, 128);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(200, 21);
            this.textData.TabIndex = 10;
            // 
            // textValue
            // 
            this.textValue.Location = new System.Drawing.Point(96, 160);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(136, 21);
            this.textValue.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Value";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSec
            // 
            this.textSec.Location = new System.Drawing.Point(96, 64);
            this.textSec.Name = "textSec";
            this.textSec.Size = new System.Drawing.Size(136, 21);
            this.textSec.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "sector";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Data";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(96, 96);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(136, 21);
            this.textKey.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Key";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSeekCard
            // 
            this.btnSeekCard.Location = new System.Drawing.Point(304, 32);
            this.btnSeekCard.Name = "btnSeekCard";
            this.btnSeekCard.Size = new System.Drawing.Size(75, 23);
            this.btnSeekCard.TabIndex = 2;
            this.btnSeekCard.Text = "request";
            this.btnSeekCard.Click += new System.EventHandler(this.btnSeekCard_Click);
            // 
            // lbSnr
            // 
            this.lbSnr.Location = new System.Drawing.Point(104, 32);
            this.lbSnr.Name = "lbSnr";
            this.lbSnr.Size = new System.Drawing.Size(121, 20);
            this.lbSnr.TabIndex = 1;
            this.lbSnr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "卡片序列号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "hints:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbResult
            // 
            this.lbResult.Location = new System.Drawing.Point(74, 475);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(288, 23);
            this.lbResult.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "KeyA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "KeyB";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "changekey";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textKeyA
            // 
            this.textKeyA.Location = new System.Drawing.Point(92, 19);
            this.textKeyA.Name = "textKeyA";
            this.textKeyA.Size = new System.Drawing.Size(136, 21);
            this.textKeyA.TabIndex = 16;
            // 
            // textKeyB
            // 
            this.textKeyB.Location = new System.Drawing.Point(91, 49);
            this.textKeyB.Name = "textKeyB";
            this.textKeyB.Size = new System.Drawing.Size(136, 21);
            this.textKeyB.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textKeyB);
            this.groupBox3.Controls.Add(this.textKeyA);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(5, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 77);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(432, 523);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbSoftVer);
            this.Controls.Add(this.lbHardVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbBaud);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.comboBaud);
            this.Controls.Add(this.comboPort);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		public int icdev ; // 通讯设备标识符
		public Int16 st;
		public int sec;
		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			st=0;
			byte[] ver=new byte[30];
			int[] baudarray=new int[5];
		    baudarray[0]=9600;
			baudarray[1]=19200;
			baudarray[2]=38400;
			baudarray[3]=57600;
			baudarray[4]=115200;
				
			st = common.lib_ver(ver);
			string sver=System.Text.Encoding.ASCII.GetString(ver);
			lbSoftVer.Text=sver;

			Int16 port=0;
			int baud=9600;
			port=(Int16)comboPort.SelectedIndex;
			int nitem=comboBaud.SelectedIndex;
			baud = baudarray[nitem];

		    icdev = common.rf_init(port, baud);
			if(icdev>0)
			{
				lbResult.Text="Com Connect success!";
				byte[] status=new byte[30];
				st = common.rf_get_status(icdev, status);
				lbHardVer.Text=System.Text.Encoding.Default.GetString(status);
			}
			else
				lbResult.Text="Com Connect failed!";	
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
		    st = common.rf_exit(icdev);
			if(st==0)
				lbResult.Text="Disconnect success!";
			else
				lbResult.Text="Disconnect failed!";
		}

		private void btnBeep_Click(object sender, System.EventArgs e)
		{
		    st = common.rf_beep(icdev, 10);
			if(st==0)
				lbResult.Text="Beep OK!";
			else
				lbResult.Text="Beep failed!";
		}

		private void btnSeekCard_Click(object sender, System.EventArgs e)
		{			
			UInt16 tagtype=0;
			byte size=0;
			uint snr=0;
			
			mifareone.rf_reset(icdev, 3);
			st = mifareone.rf_request(icdev,1,out tagtype);
			if(st!=0)
			{
				lbResult.Text="request error!";
				return;
			}
			
			st = mifareone.rf_anticoll(icdev,0,out snr);
			if(st!=0)
			{
				lbResult.Text="anticoll error!";
				return;
			}
			string snrstr="";
			snrstr=snr.ToString("X");
			lbSnr.Text=snrstr;
			
			st = mifareone.rf_select(icdev,snr,out size);
			if(st!=0)
			{
				lbResult.Text="select error!";
				return;
			}
			lbResult.Text="request success!";
		}

		private void btnAuth_Click(object sender, System.EventArgs e)
		{
			byte[] key1=new byte[17];
			byte[] key2=new byte[7];
			int i=0;
			string skey=textKey.Text;
			int keylen=textKey.TextLength;
			if(keylen!=12)
			{
				lbResult.Text="please input key,key length error!";
				return;
			}
			if(textSec.TextLength<1)
			{
				lbResult.Text="please input sector!";
				return;
			}
			
			sec=Convert.ToInt32(textSec.Text,10);
			if(sec<1||sec>15)
			{
				lbResult.Text="sector error!";
				return;
			}
			
			for( i=0;i<keylen;i++)
			{
				if(skey[i]>='0'&&skey[i]<='9')
					continue;
				if(skey[i]<='a'&&skey[i]<='f')
					continue;
				if(skey[i]<='A'&&skey[i]<='F')
					continue;
			}
			if(i!=keylen)
			{
				lbResult.Text="please input hex key!";
				return;
											  
			}
			key1=Encoding.ASCII.GetBytes(skey);
			common.a_hex(key1,key2,12);
			st = common.rf_load_key(icdev, 0, sec, key2);
			if(st!=0)
			{
				lbResult.Text="load key failed!";
				return;
			}
			st = mifareone.rf_authentication(icdev,0,sec);
			if(st!=0)
				lbResult.Text="authentication failed!";
			else
				lbResult.Text="authentication success!";
		}

		private void btnReadData_Click(object sender, System.EventArgs e)
		{
			int i=0;
			byte[] data=new byte[17];
			byte[] buff=new byte[34];
			
			for(i=0;i<16;i++)
				data[i]=0;
			for(i=0;i<32;i++)
				buff[i]=0;
			st = mifareone.rf_read(icdev,sec*4+1,data);
			if(st==0)
			{
				//common.hex_a(data,buff,16);
                textData.Text = System.Text.Encoding.Default.GetString(data);
				lbResult.Text="read data success!";
			}
			else
				lbResult.Text="read data failed!";
		}

		private void btnWriteData_Click(object sender, System.EventArgs e)
		{
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];

			/*if(textData.TextLength<32)
			{
				lbResult.Text="please input data lenght";
				return;
			}
			string data=textData.Text;
			for( i=0;i<data.Length;i++)
			{
				if(data[i]>='0'&&data[i]<='9')
					continue;
				if(data[i]<='a'&&data[i]<='f')
					continue;
				if(data[i]<='A'&&data[i]<='F')
					continue;
			}
			if(i!=data.Length)
			{
				lbResult.Text="data is hex data!";
				return;
											  
			}*/

            buff = Encoding.Default.GetBytes("张三张三张三张三");
			//common.a_hex(buff,databuff,32);
            st = mifareone.rf_write(icdev, sec * 4 + 1, buff);
			if(st==0)
				lbResult.Text="write data success!";
			else
				lbResult.Text="write data failed!";
		} 

		private void btnValueOp_Click(object sender, System.EventArgs e)
		{
		    uint cvalue=0;
			uint val=0;
			
			if(textValue.TextLength<1)
			{
				lbResult.Text="input value!";
				return;
			}
			
			cvalue=Convert.ToUInt32(textValue.Text,10);
			if(cvalue<1||cvalue>4294966000)
			{
				lbResult.Text="inputed value error!";
				return;
			}
			
			st = mifareone.rf_initval(icdev,sec*4+2,cvalue);
			if(st!=0)
			{
				lbResult.Text="initial value operator failed!";
				return;
			}
			st = mifareone.rf_increment(icdev,sec*4+2,1000);
			if(st!=0)
			{
				lbResult.Text="increase operator failed!";
				return;
			}
			st = mifareone.rf_decrement(icdev,sec*4+2,100);
			if(st!=0)
			{
				lbResult.Text="decrease oper failed!";
				return;
			}
            st = mifareone.rf_readval(icdev,sec*4+2,out val);
			if(st!=0)
			{
				lbResult.Text="read value failed!";
				return;
			}
			textValue.Text=val.ToString();
			lbResult.Text="value oper success!";
		}

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] keyA1 = new byte[17]; 
            byte[] keyA2 = new byte[7];

            byte[] keyB1 = new byte[17];
            byte[] keyB2 = new byte[7];

            if (textKeyA.TextLength != 12)
            {
                lbResult.Text = "please input keyA,keyA length error!";
                return;
            }

            if (textKeyB.TextLength != 12)
            {
                lbResult.Text = "please input keyB,keyB length error!";
                return;
            }
            sec = Convert.ToInt32(textSec.Text, 10);

            keyA1 = Encoding.ASCII.GetBytes(textKeyA.Text);
            common.a_hex(keyA1, keyA2, 12);

            keyB1 = Encoding.ASCII.GetBytes(textKeyB.Text);
            common.a_hex(keyB1, keyB2, 12);            

            st = mifareone.rf_changeb3(icdev, sec, keyA2, 0x00, 0x00, 0x00, 0x01, 0, keyB2);
            if (st != 0)
                lbResult.Text = "rf_changeb3 failed!";
            else
                lbResult.Text = "第四扇区密码被修改 success!";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
	}
}
