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
    public partial class Members : Form
    {
        Functions Con;
        public Members()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMembers();
            GetCoaches();
            GetMships();
        }
        private void SeachMember()
        {
            string Query = "SELECT *  from CoachsTbl Where MName LIKE '%" + SeachMTb.Text + "%' or MPhone LIKE '%" + SeachMTb.Text + "%'";
            MembersList.DataSource = Con.GetData(Query);
        }
        private void ShowMembers()
        {
            string Query = "select * from MembersTbl";
            MembersList.DataSource = Con.GetData(Query);
        }
        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Coachs Obj = new Coachs();
            Obj.Show();
            this.Hide();
        }
        private void GetCoaches()
        {
            string Query = "select *from CoachsTbl";
            CoachCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CoachCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CoachCb.DataSource = Con.GetData(Query);
        }
        private void GetMships()
        {
            string Query = "select *from MembershipsTbl";
            MShipCb.DisplayMember = Con.GetData(Query).Columns["MName"].ToString();
            MShipCb.ValueMember = Con.GetData(Query).Columns["MShipId"].ToString();
            MShipCb.DataSource = Con.GetData(Query);
        }
        private void Reset()
        {
            MNameTb.Text="";
            PhoneTb.Text = "";
            CoachCb.SelectedIndex = -1;
            GenCb.SelectedIndex = -1;
            MShipCb.SelectedIndex = -1;
            StatusCb.SelectedIndex = -1;
            TimingCb.SelectedIndex = -1;
        }
        int Key = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MShipCb.SelectedIndex == -1|| StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    
                    string DOB = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int MShip = Convert.ToInt32(MShipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32(CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedItem.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "insert into MembersTbl values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}' )";
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, MShip,Coach, Phone, Timing,Status);
                    Con.setData(Query);
                    ShowMembers();
                    Reset();
                    MessageBox.Show("Thêm thành viên!!!");
                    //Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MembersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MembersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = MembersList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = MembersList.SelectedRows[0].Cells[3].Value.ToString();
            JDateTb.Text = MembersList.SelectedRows[0].Cells[4].Value.ToString();
            MShipCb.Text = MembersList.SelectedRows[0].Cells[5].Value.ToString();
            CoachCb.Text = MembersList.SelectedRows[0].Cells[6].Value.ToString();
            PhoneTb.Text = MembersList.SelectedRows[0].Cells[7].Value.ToString();
            TimingCb.Text = MembersList.SelectedRows[0].Cells[8].Value.ToString();
            StatusCb.Text = MembersList.SelectedRows[0].Cells[9].Value.ToString();

            if (MNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MembersList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || PhoneTb.Text == "" || CoachCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 || MShipCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;

                    string DOB = DOBTb.Value.Date.ToString();
                    string MJDate = JDateTb.Value.Date.ToString();
                    int MShip = Convert.ToInt32(MShipCb.SelectedValue.ToString());
                    int Coach = Convert.ToInt32(CoachCb.SelectedValue.ToString());
                    string Timing = TimingCb.SelectedItem.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "Update MembersTbl set MName='{0}', MGen='{1}', MDOB='{2}',MDate='{3}',MMembership='{4}',MCoach='{5}',MPhone='{6}',MTiming='{7}',MStatus='{8}' where MId={9}";
                    Query = string.Format(Query, MName, Gender, DOBTb.Value.Date, JDateTb.Value.Date, MShip, Coach, Phone, Timing, Status,Key);
                    Con.setData(Query);
                    ShowMembers();
                    Reset();
                    MessageBox.Show(" Cập nhập thành viên!!!");
                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Chọn thành viên!!!");
                }
                else
                {

                    string Query = "delete from MembersTbl Where MId={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMembers();
                    MessageBox.Show("Xoá thành viên!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void SeachMTb_TextChanged(object sender, EventArgs e)
        {
            SeachMember();
        }
    }
}
