using Cv_Viewer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CvViewerProject
{
    public partial class CommunicationAdd : Form
    {
        public CommunicationAdd()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(txtFacebook.Text!=""||txtLinkedIn.Text !="" || txtPhone.Text !=""||txtTwitter.Text != "")
            {
                CvViewerContext db = new CvViewerContext();
                var account = await db.accounts.Where(a => a.e_mail == txtMail.Text).AsNoTracking().FirstAsync();
                Communication communication = new Communication();
                communication.communication_id = account.account_id;
                communication.facebook = txtFacebook.Text;
                communication.twitter = txtTwitter.Text;
                communication.phone_number = txtPhone.Text;
                communication.linked_in = txtLinkedIn.Text;
                db.communications.Add(communication);
                db.SaveChangesAsync();
                PersonMenu person = new PersonMenu();
                person.Text = txtMail.Text;
                this.Hide();
                person.Show();
            }
        }

        private void Communication_Load(object sender, EventArgs e)
        {
            txtMail.Text = this.Text;
            this.Text = "Add comminucation";
        }
    }
}
