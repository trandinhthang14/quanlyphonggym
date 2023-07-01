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
    public partial class Memberships : Form
    {
        Functions Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMShips();
        }
        private void ShowMShips()
        {
            string Query = "select * from MembershipsTbl";
            MShipList.DataSource = Con.GetData(Query);
        }

        private void Reset()
        {
            MNameTb.Text = "";
            CostTb.Text = "";
            MDurationTb.Text = "";
            GoalTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);
                    
                    string Query = "insert into MembershipsTbl values('{0}', '{1}', '{2}','{3}' )";
                    Query = string.Format(Query, MName,Duration,Goal,Cost);
                    Con.setData(Query);
                    ShowMShips();
                    MessageBox.Show("Thêm gói thành viên!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void MShipList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MNameTb.Text = MShipList.SelectedRows[0].Cells[1].Value.ToString();
            MDurationTb.Text = MShipList.SelectedRows[0].Cells[2].Value.ToString();
            GoalTb.Text = MShipList.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = MShipList.SelectedRows[0].Cells[4].Value.ToString();
            
            if (MNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MShipList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Chọn gói thành viên!!!");
                }
                else
                {
                    
                    string Query = "delete from MembershipsTbl Where MShipId={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMShips();
                    MessageBox.Show(" Xoá thành viên!!!");
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
                if (MNameTb.Text == "" || MDurationTb.Text == "" || GoalTb.Text == "" || CostTb.Text == "")
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string MName = MNameTb.Text;
                    int Duration = Convert.ToInt32(MDurationTb.Text);
                    string Goal = GoalTb.Text;
                    int Cost = Convert.ToInt32(CostTb.Text);

                    string Query = "update MembershipsTbl set MName='{0}', MDuration={1}, MGoal='{2}',MCost={3} where MShipId={4}";
                    Query = string.Format(Query, MName, Duration, Goal, Cost,Key);
                    Con.setData(Query);
                    ShowMShips();
                    MessageBox.Show("Thêm gói thành viên!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CoachLbl_Click(object sender, EventArgs e)
        {
            Coachs Obj = new Coachs();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
    }
}
