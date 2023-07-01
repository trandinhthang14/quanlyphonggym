using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTuto
{
    public partial class Billing : Form
    {
        Functions Con;
        public Billing()
        {
            InitializeComponent();
            Con = new Functions();
            ShowBills();
            GetMembers();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void ShowBills()
        {
            string Query = "select * from FinanceTbl";
            BillingList.DataSource = Con.GetData(Query);
        }

        private void GetMembers()
        {
            string Query = "select *from MembersTbl";
            MemberCb.DisplayMember = Con.GetData(Query).Columns["MName"].ToString();
            MemberCb.ValueMember = Con.GetData(Query).Columns["MId"].ToString();
            MemberCb.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberCb.Text == "" || AmountTb.Text == "" )
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    int Agent = Login.UserId;
                    string Member = MemberCb.SelectedValue.ToString();
                    string Period = PeriodTb.Value.Date.Month +"-"+PeriodTb.Value.Date.Year;
                    
                    string BDate = BDateTb.Value.Date.ToString();
                    string Amount = AmountTb.Text;
                    string Query = "insert into FinanceTbl values('{0}', '{1}', '{2}','{3}','{4}' )";
                    Query = string.Format(Query, Agent, Member, Period, BDate, Amount);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Thành công!!!");
                    //Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            AmountTb.Text = "";
            MemberCb.SelectedIndex = -1;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Coachs Obj = new Coachs();
            Obj.Show();
            this.Hide();
        }
        private void SeachBill()
        {
            string Query = "SELECT *  from FinanceTbl Where Member LIKE '%" + SeachBTb.Text + "%' or Agent LIKE '%" + SeachBTb.Text + "%'";
            BillingList.DataSource = Con.GetData(Query);
        }

        private void SeachBTb_TextChanged(object sender, EventArgs e)
        {
            SeachBill();
        }
    }
}
