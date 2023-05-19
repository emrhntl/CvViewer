using Cv_Viewer.Models;
using Microsoft.EntityFrameworkCore;

namespace CvViewerProject
{
    public partial class LogIn : Form
    {
        CvViewerContext db = new CvViewerContext();
        public LogIn()
        {
            InitializeComponent();
        }
        private void LogIn_Load_1(object sender, EventArgs e)
        {
            this.Text = "Log In";
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp sign = new SignUp();
            sign.Show();
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            var eMails = await db.accounts.Select(a => a.e_mail).AsNoTracking().ToListAsync();
            if (eMails.Contains(txtEmail.Text))
            {
                var account = await db.accounts.Where(a => a.e_mail == txtEmail.Text).FirstAsync();
                if(account.password == txtPassword.Text)
                {
                    this.Hide();
                    if(account.account_type == "p")
                    {
                        PersonMenu newPerson = new PersonMenu();
                        var result = await db.accounts.Where(a => a.e_mail == txtEmail.Text).Select(a => a.e_mail).AsNoTracking().FirstAsync();
                        newPerson.Text = result;
                        newPerson.Show();
                    }
                    else
                    {
                        CompanyMenu  companyMenu = new CompanyMenu();
                        companyMenu.Show();
                    }
                    //var account = await db.accounts.Where(a=>a.e_mail == tx)
                }
                else
                {
                    MessageBox.Show("your password is wrong");
                }
            }
            else
            {
                MessageBox.Show("Account registered to this e-mail not found","Error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}