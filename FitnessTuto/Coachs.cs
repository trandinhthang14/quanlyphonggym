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
    public partial class Coachs : Form
    {
        Functions Con;
        public Coachs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCoach();
        }
        private void SeachCoach() {
            string Query = "SELECT *  from CoachsTbl Where CName LIKE '%" + SeachCTb.Text + "%' or IdC LIKE '%" + SeachCTb.Text + "%' or CPhone LIKE '%" + SeachCTb.Text + "%'";
            CoachsList.DataSource = Con.GetData(Query);
        }
        private void ShowCoach()
        {
            string Query = "select * from CoachsTbl";
            CoachsList.DataSource = Con.GetData(Query);
        }
        private void Reset()
        {
            ChNameTb.Text = ""; ExpTb.Text = ""; IDCTb.Text = ""; AddTb.Text = "";IDCTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || ExpTb.Text == "" || IDCTb.Text == "" || GenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string IDC = IDCTb.Text;
                    string Query = "insert into CoachsTbl values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}' )";
                    Query = string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, IDC);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Thêm PT!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key =0;
        

        private void CoachsList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            ChNameTb.Text = CoachsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = CoachsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = CoachsList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = CoachsList.SelectedRows[0].Cells[4].Value.ToString();
            ExpTb.Text = CoachsList.SelectedRows[0].Cells[5].Value.ToString();
            AddTb.Text = CoachsList.SelectedRows[0].Cells[6].Value.ToString();
            IDCTb.Text = CoachsList.SelectedRows[0].Cells[7].Value.ToString();
            if (ChNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CoachsList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Chọn PT!!!");
                }
                else
                {
                    
                    string Query = "delete from CoachsTbl Where CId={0}";
                    Query = string.Format(Query,Key);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Xoá PT!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChNameTb.Text == "" || ExpTb.Text == "" || IDCTb.Text == "" || GenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string CName = ChNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    int experience = Convert.ToInt32(ExpTb.Text);
                    string Add = AddTb.Text;
                    string IDC = IDCTb.Text;


                    //values('{0}', '  {1}',   '{2}', '  {3}',   '{4}', '   {5}', '{6}')";
                    //Query =  CName, Gender,   DOBTb,   Phone, experience, Add, Password);
                    string Query = "update CoachsTbl set CName='{0}', CGen='{1}', CDOB='{2}',CPhone='{3}',CExperience={4},CAddress='{5}',IdC='{6}' where CId='{7}'";
                    Query = string.Format(Query, CName, Gender, DOBTb.Value.Date, Phone, experience, Add, IDC,Key);
                    Con.setData(Query);
                    ShowCoach();
                    MessageBox.Show("Cập nhập PT!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void RecepLbl_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SeachCTb_TextChanged(object sender, EventArgs e)
        {
            SeachCoach();

        }
    }
}
