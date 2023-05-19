using Cv_Viewer.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CvViewerProject
{
    public partial class SignUp : Form
    {
        CvViewerContext db = new CvViewerContext();
        public SignUp()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private async void SignUp_Load(object sender, EventArgs e)
        {
            grpSignUp.Text = "Sign Up";
            txtPath.Visible = false;
            var countries = await db.countries.Select(x => x.country_name).OrderBy(c => c).AsNoTracking().ToListAsync();
            cmbCountry.DataSource = countries;
            rdbtnPerson.CheckedChanged += RdbtnPerson_CheckedChanged;
            rdbtnCompany.CheckedChanged += RdbtnCompany_CheckedChanged;
            cmbCountry.TextChanged += CmbCountry_TextChanged;
            CmbCountry_TextChanged(sender, e);
            cmbCountry.SelectedIndex = 0;
        }

        private async void CmbCountry_TextChanged(object? sender, EventArgs e)
        {
            cmbCity.Text = "";
            var cities = await db.countries.Join(db.cities, country => country.country_id, city => city.country_id, (country, city) => new
            {
                Country = country,
                City = city
            }).Where(Country => Country.Country.country_name == cmbCountry.Text).Select(cities => cities.City.city_name).OrderBy(c => c).AsNoTracking().ToListAsync();
            cmbCity.DataSource = cities;
            cmbCity.SelectedIndex = 0;
        }

        private void RdbtnPerson_CheckedChanged(object? sender, EventArgs e)
        {
            lblName.Text = "Name Surname";
        }

        private void RdbtnCompany_CheckedChanged(object? sender, EventArgs e)
        {
            lblName.Text = "Company Name";
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog newOfd = new OpenFileDialog();
            newOfd.Title = "Select İmage";
            newOfd.Filter = "Image Files(*.jpg; *.png) | *.jpg; *.png";
            newOfd.FilterIndex = 1;
            newOfd.ShowDialog();
            txtPath.Text = newOfd.FileName;
        }
        private void ExecuteProcedure(int id, char type, string name)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Database=CvViewerDb;Username=postgres;Password=123"))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("call inheritance('" + type + "','" + name + "');", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                    cmd.Parameters.Add("@type", NpgsqlDbType.Varchar).Value = type;
                    cmd.Parameters.Add("@name", NpgsqlDbType.Varchar).Value =name;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com"))
            {
                if (txtPassword.Text.Length >= 8)
                {
                    if (txtName.Text != "")
                    {

                        try
                        {
                            Account newAccount = new Account();
                            int accountId;
                            try
                            {
                                accountId = db.accounts.Select(a => a.account_id).Max() + 1;
                            }
                            catch (Exception)
                            {
                                accountId = 1;
                            }
                            newAccount.account_id = accountId;
                            newAccount.picture_path = txtPath.Text;
                            newAccount.e_mail = txtEmail.Text;
                            newAccount.password = txtPassword.Text;
                            if (rdbtnCompany.Checked)
                            {
                                newAccount.account_type = "c";

                            }
                            else
                            {
                                newAccount.account_type = "p";
                            }
                            var country = db.countries.Where(c => c.country_name == cmbCountry.Text).ToList();
                            newAccount.country = country[0];
                            var city = db.cities.Where(c => c.city_name == cmbCity.Text).ToList();
                            newAccount.city = city[0];
                            db.accounts.Add(newAccount);
                            db.SaveChanges();/////////////////////bunu silmeyi dene
                            try
                            {
                                //ExecuteProcedure(accountId, newAccount.account_type , txtName.Text);
                                if (rdbtnCompany.Checked)
                                {
                                    Company cmp = new Company();
                                    cmp.company_id = accountId;
                                    cmp.company_name = txtName.Text;
                                    db.companies.Add(cmp);
                                    db.SaveChanges();
                                }
                                else if(rdbtnPerson.Checked)
                                {
                                    Person person = new Person();
                                    person.person_id = accountId;
                                    person.name = txtName.Text;
                                    db.people.Add(person);
                                    db.SaveChanges();
                                }
                                txtEmail.Text = "";
                                txtName.Text = "";
                                txtPassword.Text = "";
                                txtPath.Text = "";
                                MessageBox.Show("Registration successfully created");
                            }
                            catch (Exception)
                            {
                                //////////////////////////////////////////////////////////////////////////hesabı sil
                                MessageBox.Show("Check your informations", "ERROR");
                            }

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Check your informations", "ERROR");
                        }
                    }
                    else
                    {
                        if (rdbtnCompany.Checked)
                        {
                            MessageBox.Show("Company Name can't be empty", "ERROR");
                        }
                        else
                        {
                            MessageBox.Show("Name Surname can't be empty", "ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Your password must be 8 characters or more", "ERROR");
                }
            }
            else
            {
                MessageBox.Show("Please enter a suitable e-mail", "ERROR");

            }
        }
    }
}
