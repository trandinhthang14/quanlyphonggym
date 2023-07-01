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
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
           
            InitializeComponent();
            Con = new Functions();
        }
        public static int UserId;
        private void AdminLbl_Click(object sender, EventArgs e)
        {
            Receptionists Obj = new Receptionists();
            Obj.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu ");
            }
            else
            {
                try
                {
                    string Query = "select * from ReceptionistTbl where RecepName= '{0}'and RecepPass = '{1}'";
                    Query = string.Format(Query, UNameTb.Text, PasswordTb.Text);
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không hợp lệ!!!");

                    }
                    else
                    {
                        UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Members Obj = new Members();
                        Obj.Show();
                        this.Hide();
                    }
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
