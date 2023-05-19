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
////////////////////////////////////////////////////
namespace CvViewerProject
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            txtMail.Text = this.Text;
            grpList.Text = "Accounts";
            this.Text = "Search Account";
            lstbxAccount.SelectedIndexChanged += LstbxAccount_SelectedIndexChanged;
        }

        private void LstbxAccount_SelectedIndexChanged(object? sender, EventArgs e)
        {
            grpList.Visible = false;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lstbxAccount.Items.Clear();
            CvViewerContext db = new CvViewerContext();
            var people = await db.people.Join(db.accounts, p => p.person_id, a => a.account_id, (person, account) => new
            {
                Person = person,
                Account = account,
            }).Where(p => p.Person.name.Substring(0, txtAccount.Text.Length) == txtAccount.Text).AsNoTracking().ToListAsync();
            var companies = await db.companies.Where(c => c.company_name.Substring(0, txtAccount.Text.Length) == txtAccount.Text).Join(db.accounts, c => c.company_id, a => a.account_id, (company, account) => new
            {
                Company = company,
                Account = account
            }).AsNoTracking().ToListAsync();
            foreach (var item in people)
            {
                var country = await db.countries.Where(c => c.country_id == item.Account.country_id).Select(c=>c.country_name).AsNoTracking().FirstAsync();
                var city = await db.cities.Where(c => c.city_id == item.Account.city_id).Select(c=>c.city_name).AsNoTracking().FirstAsync();
                lstbxAccount.Items.Add(item.Person.name + " - " +"Person Account -"+ country +" - " + city + " - " + item.Person.level);
            }
            foreach (var item in companies)
            {
                var country = await db.countries.Where(c => c.country_id == item.Account.country_id).Select(c=>c.country_name).AsNoTracking().FirstAsync();
                var city = await db.cities.Where(c => c.city_id == item.Account.city_id).Select(c=>c.city_name).AsNoTracking().FirstAsync();
                lstbxAccount.Items.Add(item.Company.company_name + " - " + "Company Account -" + country + " - " + city);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PersonMenu person = new PersonMenu();
            person.Text = txtMail.Text;
            this.Hide();
            person.Show();
        }
    }
}
