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
    public partial class Receptionists : Form
    {
        Functions Con;
        public Receptionists()
        {
            InitializeComponent();
            Con = new Functions();
            ShowReceptionist();
        }
        private void ShowReceptionist()
        {
            string Query = "select * from ReceptionistTbl";
            RecepList.DataSource = Con.GetData(Query);
        }
        private void Reset()
        {
            RecepNameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
            RecepAddTb.Text = "";
            GenCb.Text = "";
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || GenCb.SelectedIndex == -1|| PasswordTb.Text=="")
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.ToString();
                    string Phone = PhoneTb.Text;
                    string Add = RecepAddTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "insert into ReceptionistTbl values('{0}', '{1}', '{2}','{3}','{4}','{5}' )";
                    Query = string.Format(Query, RName, Gender, DOB,  Add, Phone, Password);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Thêm thu ngân!!!");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void RecepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecepNameTb.Text = RecepList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = RecepList.SelectedRows[0].Cells[2].Value.ToString();
            RecepDOBTb.Text = RecepList.SelectedRows[0].Cells[3].Value.ToString();
            RecepAddTb.Text = RecepList.SelectedRows[0].Cells[4].Value.ToString();
            PhoneTb.Text = RecepList.SelectedRows[0].Cells[5].Value.ToString(); 
            PasswordTb.Text = RecepList.SelectedRows[0].Cells[6].Value.ToString();
            if (RecepNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(RecepList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Chọn thu ngân!!!");
                }
                else
                {
                    
                    string Query = "delete from ReceptionistTbl Where ReceptId={0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Xoá thu ngân!!!");
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
                if (RecepNameTb.Text == "" || PhoneTb.Text == "" || RecepAddTb.Text == "" || GenCb.SelectedIndex == -1 || PasswordTb.Text == "")
                {
                    MessageBox.Show("Không có dữ liệu!!!");
                }
                else
                {
                    string RName = RecepNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string DOB = RecepDOBTb.Value.ToString();
                    string Phone = PhoneTb.Text;
                    string Add = RecepAddTb.Text;
                    string Password = PasswordTb.Text;
                    string Query = "update ReceptionistTbl set RecepName='{0}', Recepgen='{1}', RecepDOB='{2}',RecepAdd='{3}',RecepPhone={4},RecepPass='{5}' where ReceptId={6}";
                    Query = string.Format(Query, RName, Gender, DOB, Add, Phone, Password,Key);
                    Con.setData(Query);
                    ShowReceptionist();
                    MessageBox.Show("Cập nhập thu ngân!!!");
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

        private void label15_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
