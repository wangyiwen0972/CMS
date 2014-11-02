namespace CMS.Module.CardMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Module.CardMachine.Lib;



    public class CardMachine:IDisposable
    {
        private short port;
        private int baud;

        private string version;

        public int icdev
        {
            get;
            internal set;
        }

        public string ProductName
        {
            get;
            internal set;
        }

        public CardMachine(short port, int baud)
        {
            this.port = port;
            this.baud = baud;
            this.ProductName = GetVer();
        }


        #region 公共方法
        public bool Test()
        {
            this.icdev = Libraries.rf_init(this.port, this.baud);

            return this.icdev > 0 ? true : false;

        }

        public string GetVer()
        {
            byte[] ver = new byte[30];
            byte[] status=new byte[30];
            Libraries.lib_ver(ver);
            Libraries.rf_get_status(this.icdev, status);

            return System.Text.Encoding.Default.GetString(status);
        }

        public void Authorize()
        {
        }
        /// <summary>
        /// 读取卡号
        /// </summary>
        /// <returns>返回16进制卡号</returns>
        public string ReadCardNo()
        {
            short st;

            UInt16 tagtype = 0;
            byte size = 0;
            uint snr = 0;
            string cardNo = "";
            try
            {
                mifareone.rf_reset(icdev, 3);
                st = mifareone.rf_request(icdev, 1, out tagtype);
                if (st != 0)
                {
                    throw new Exception("请求失败!");
                }

                st = mifareone.rf_anticoll(icdev, 0, out snr);
                if (st != 0)
                {
                    throw new Exception("读取卡号失败!");
                }
                
                cardNo = snr.ToString("X");

                st = mifareone.rf_select(icdev, snr, out size);
                if (st != 0)
                {
                    throw new Exception("请再刷一次！");
                }
            }
            catch
            {
            }
            finally
            {
                Libraries.rf_exit(icdev);
            }
            return cardNo;
        }

        #endregion

        #region 私有方法

        public bool Connect()
        {
            this.icdev = Libraries.rf_init(this.port, this.baud);

            return this.icdev > 0 ? true : false;
        }

        public bool Close()
        {
            int result = Libraries.rf_exit(this.icdev);
            return result == 0 ? true : false;
        }
        #endregion


        public void Dispose()
        {
            this.Close();
        }
    }
}
