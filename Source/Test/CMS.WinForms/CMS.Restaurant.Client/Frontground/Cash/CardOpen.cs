namespace CMS.Restaurant.Client.Cash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CMS.Module.Shell.Core;
    using ViewResultBase = CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;
    using ModelBase = CMS.Common.Model.Base;
    using CMS.Common.Model;
    using CMS.Module.CardMachine;
    using CMS.Common.Controller.Core;

    public partial class CardOpen : CMSForm
    {
        private CardController cardController = null;

        private CMS.Common.Model.Base.CardBase card = null;

        public const string CARD_STATUS_ACTIVE = "active";
        public const string CARD_STATUS_INACTIVE = "inactive";

        public CardOpen()
        {
            InitializeComponent();

            this.cardController = this.ControllerManager[typeof(CardController)] as CardController;
        }

        public CMS.Common.Model.Base.CardBase Card
        {
            get { return card; }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("50");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("100");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("200");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("500");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("50");

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("100");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("200");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            txtbRechargeMoney.Focus();
            txtbRechargeMoney.Text = "";
            SendKeys.SendWait("500");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CardTypes tempCard = cardController.getCardType(CardController.CARD_TYPE_TEMPORARY);
            CardTypes vipCard = cardController.getCardType(CardController.CARD_TYPE_VIP);

            CardStatus status = cardController.getCardStatus(CardController.CARD_STATUS_ACTIVE);
            try
            {
                if (!Convert.ToBoolean(this.cardController.IsExists().Result))
                {
                    try
                    {
                        string cardNo = this.cardController.ReadCardNo().Result;

                        TemporaryCard card = new TemporaryCard()
                        {
                            CardType = tempCard,
                            Cost = tempCard.Cost,
                            CreatedBy = Login,
                            Discount = tempCard.Discount,
                            StartDate = DateTime.Now,
                            ID = Guid.NewGuid(),
                            SeriesNumber = cardNo,
                            Status = status,
                            Type = Common.Model.Emun.Card.CardType.TemporaryCard,
                            ValidDate = tempCard.ValidDate,
                            Amount = Convert.ToDecimal(txtbRechargeMoney.Text),
                            EndDate = DateTime.Now.AddDays(tempCard.ValidDate)
                        };

                        this.cardController.CreateCard(card);

                        this.card = card;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建卡片信息失败！错误原因:" + ex.Message);
                    }
                }
                else
                {
                    CMS.Common.Model.Base.CardBase card = this.cardController.ReadCardInfo().Model as CMS.Common.Model.Base.CardBase;

                    try
                    {
                        this.cardController.AdjustMoney(card, decimal.Parse(txtbRechargeMoney.Text));

                        this.card = card;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
    }
}
