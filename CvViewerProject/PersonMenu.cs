using Cv_Viewer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
    public partial class PersonMenu : Form
    {

        ComboBox cmbAbility = new ComboBox();
        GroupBox grpAddAbility = new GroupBox();
        GroupBox grpAddExp = new GroupBox();
        GroupBox grpAddEdu = new GroupBox();
        ComboBox cmbCompany = new ComboBox();
        ComboBox cmbPosition = new ComboBox();

        ComboBox cmbSchool = new ComboBox();
        ComboBox cmbDepartment = new ComboBox();

        DateTimePicker finishDate = new DateTimePicker();
        DateTimePicker startDate = new DateTimePicker();


        DateTimePicker schoolFinishDate = new DateTimePicker();
        DateTimePicker SchoolStartDate = new DateTimePicker();
        public PersonMenu()
        {
            InitializeComponent();
        }

        private async void PersonMenu_Load(object sender, EventArgs e)
        {
            CvViewerContext db = new CvViewerContext();
            var person = await db.accounts.Join(db.people, account => account.account_id, person => person.person_id, (account, person) => new
            {
                Account = account,
                Person = person
            }).Where(a => a.Account.e_mail == this.Text).AsNoTracking().FirstAsync();
            txtMail.Text = this.Text;
            this.Text = person.Person.name;
            imgProfile.ImageLocation = @person.Account.picture_path;
            lblName.Text = person.Person.name;
            lblCountry.Text = await db.countries.Where(c => c.country_id == person.Account.country_id).Select(c => c.country_name).AsNoTracking().FirstAsync();
            LblCity.Text = await db.cities.Where(c => c.city_id == person.Account.city_id).Select(c => c.city_name).AsNoTracking().FirstAsync();
            listAbility(db);
            listExperiences();
            listEdu();
            try
            {
                var communication =  db.communications.Where(c => c.communication_id == person.Account.account_id).FirstOrDefault();
                Label phone = new Label();
                phone.Text = communication.phone_number;
                phone.Font = lblCom.Font;
                phone.AutoSize = true;
                LinkLabel lnklbl1 = new LinkLabel();
                lnklbl1.Font = lblCom.Font;
                lnklbl1.AutoSize = true;
                lnklbl1.Text = communication.linked_in;
                LinkLabel lnklbl2 = new LinkLabel();
                lnklbl2.Font = lblCom.Font;
                lnklbl2.AutoSize = true;
                lnklbl2.Text = communication.twitter;
                LinkLabel lnklbl3 = new LinkLabel();
                lnklbl3.Font = lblCom.Font;
                lnklbl3.AutoSize = true;
                lnklbl3.Text = communication.facebook;
                if (communication.phone_number != "")
                {
                    phone.Location = new Point(85, 530);
                    grpInformation.Controls.Add(phone);

                    if (communication.linked_in != "")
                    {
                        lnklbl1.Location = new Point(85, 560);
                        grpInformation.Controls.Add(lnklbl1);
                        if (communication.twitter != "")
                        {
                            lnklbl2.Location = new Point(85, 590);
                            grpInformation.Controls.Add(lnklbl2);
                            if (communication.facebook != "")
                            {
                                lnklbl3.Location = new Point(85, 620);
                                grpInformation.Controls.Add(lnklbl3);
                            }
                        }
                        else if (communication.facebook != "")
                        {
                            lnklbl3.Location = new Point(85, 560);
                            grpInformation.Controls.Add(lnklbl3);
                        }
                    }
                    else if (communication.twitter != "")
                    {
                        lnklbl2.Location = new Point(85, 560);
                        grpInformation.Controls.Add(lnklbl2);
                        if (communication.facebook != "")
                        {
                            lnklbl3.Location = new Point(85, 590);
                            grpInformation.Controls.Add(lnklbl3);
                        }
                    }
                    else if (communication.facebook != "")
                    {
                        lnklbl3.Location = new Point(85, 560);
                        grpInformation.Controls.Add(lnklbl3);
                    }
                }
                else
                {
                    if (communication.linked_in != "")
                    {
                        lnklbl1.Location = new Point(85, 530);
                        grpInformation.Controls.Add(lnklbl1);
                        if (communication.twitter != "")
                        {
                            lnklbl2.Location = new Point(85, 560);
                            grpInformation.Controls.Add(lnklbl2);
                            if (communication.facebook != "")
                            {
                                lnklbl3.Location = new Point(85, 590);
                                grpInformation.Controls.Add(lnklbl3);
                            }
                        }
                        else if (communication.facebook != "")
                        {
                            lnklbl3.Location = new Point(85, 560);
                            grpInformation.Controls.Add(lnklbl3);
                        }
                    }
                    else if (communication.twitter != "")
                    {
                        lnklbl2.Location = new Point(85, 530);
                        grpInformation.Controls.Add(lnklbl2);
                        if (communication.facebook != "")
                        {
                            lnklbl3.Location = new Point(85, 560);
                            grpInformation.Controls.Add(lnklbl3);
                        }
                    }
                    else if (communication.facebook != "")
                    {
                        lnklbl3.Location = new Point(85, 530);
                        grpInformation.Controls.Add(lnklbl3);
                    }
                }
            }
            catch
            {
                Button btnAddCom = new Button();
                btnAddCom.Text = "Add Communication";
                btnAddCom.AutoSize = true;
                btnAddCom.Font = grpInformation.Font;
                btnAddCom.Location = new Point(83, 530);
                btnAddCom.Click += BtnAddCom_Click;
                grpInformation.Controls.Add(btnAddCom);
            }
        }

        private void BtnAddCom_Click(object? sender, EventArgs e)
        {
            this.Hide();
            CvViewerContext db = new CvViewerContext();
            CommunicationAdd add = new CommunicationAdd();
            add.Text = txtMail.Text;
            add.Show();
        }
        private async void listAbility(CvViewerContext db)
        {
            lstAbilities.Items.Clear();
            var personA = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
            {
                account = account,
                person = person
            }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
            var abilities = await db.people.Where(p => p.person_id == personA.person.person_id).Join(db.person_abilities, p => p.person_id, a => a.person_id, (person, ability) => new
            {
                person = person,
                ability = ability
            }).Join(db.abilities, t => t.ability.ability_id, a => a.ability_id, (total, ability) => new
            {
                total = total,
                ability = ability
            }).AsNoTracking().ToListAsync();
            foreach (var item in abilities)
            {
                lstAbilities.Items.Add(item.ability.ability_name);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            this.Hide();
            search.Text = txtMail.Text;
            search.Show();
        }

        private async void deleteAccount_Click(object sender, EventArgs e)
        {
            CvViewerContext db = new CvViewerContext();
            Account deleteAccount = await db.accounts.Where(a => a.e_mail == txtMail.Text).FirstAsync();
            //if(deleteAccount != null)
            //{
            //    db.communications.Remove(deleteAccount.communication);
            //}
            try
            {
                var person = await db.people.Where(p => p.person_id == deleteAccount.account_id).FirstAsync();
                db.people.Remove(person);
            }
            catch
            {
                var company = await db.companies.Where(c => c.company_id == deleteAccount.account_id).FirstAsync();
                db.companies.Remove(company);
            }

            //var personEdus = await db.person_educations.Where(e => e.person_id == person.person_id).ToListAsync();
            //foreach (var item in personEdus)
            //{
            //    db.person_educations.Remove(item);
            //}

            //var deleteAccount = await db.accounts.Where(a => a.e_mail == txtMail.Text).FirstAsync();

            //var company = await db.companies.Where(c => c.company_id == deleteAccount.account_id).FirstAsync();
            try
            {
                Communication communicate = await db.communications.Where(c => c.communication_id == deleteAccount.account_id).FirstAsync();
                if (deleteAccount != null)
                {
                    db.communications.Remove(communicate);
                }
            }
            catch
            {

            }
            //var personsEdu = await db.person_educations.Where(p =>p.person_id==deleteAccount.account_id).FirstAsync();
            //var personsAbility = await db.person_abilities.Where(db => db.person_id==deleteAccount.account_id).FirstAsync();
            //var 
            db.accounts.Remove(deleteAccount);
            await db.SaveChangesAsync();
            this.Hide();
            LogIn login = new LogIn();
            login.Show();

        }

        private async void addAbility_Click(object sender, EventArgs e)
        {
            CvViewerContext db = new CvViewerContext();
            grpAbilities.Visible = false;
            grpAddAbility.Text = "Add Ability";
            grpAddAbility.Visible = true;
            grpAddAbility.Location = grpAbilities.Location;
            grpAddAbility.Font = grpAbilities.Font;
            grpAddAbility.Size = grpAbilities.Size;
            grpAddAbility.BackColor = grpAbilities.BackColor;
            grpAddAbility.ForeColor = grpAbilities.ForeColor;
            this.Controls.Add(grpAddAbility);
            //global variable
            cmbAbility.ForeColor = lblCom.BackColor;
            cmbAbility.Location = new Point(150, 100);
            var abilities = await db.abilities.Select(a => a.ability_name).AsNoTracking().ToListAsync();
            cmbAbility.Items.Clear();
            foreach (var item in abilities)
            {
                cmbAbility.Items.Add(item);
            }
            cmbAbility.SelectedIndex = 0;
            Button btnAdd = new Button();
            btnAdd.BackColor = btnSearch.BackColor;
            btnAdd.ForeColor = btnSearch.ForeColor;
            btnAdd.Text = "ADD";
            btnAdd.AutoSize = true;
            btnAdd.Click += BtnAdd_Click;
            btnAdd.Location = new Point(300, 100);
            grpAddAbility.Controls.Add(cmbAbility);
            grpAddAbility.Controls.Add(btnAdd);
            Button btnBack = new Button();
            btnBack.BackColor = btnSearch.BackColor;
            btnBack.ForeColor = btnSearch.ForeColor;
            btnBack.Text = "Back";
            btnBack.AutoSize = true;
            btnBack.Click += BtnBack_Click;
            btnBack.Location = new Point(20, 25);
            grpAddAbility.Controls.Add(btnBack);

        }

        private async void BtnBack_Click(object? sender, EventArgs e)
        {
            grpAddAbility.Visible = false;
            grpAbilities.Visible = true;
            CvViewerContext db = new CvViewerContext();
            listAbility(db);
        }

        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            try
            {
                CvViewerContext db = new CvViewerContext();
                var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
                {
                    account = account,
                    person = person
                }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
                Ability ability = await db.abilities.Where(a => a.ability_name == cmbAbility.Text).FirstAsync();
                Person p = person.person;
                p.person_ability = new List<PersonAbility>()
                {
                    new()
                    {
                        ability_id = ability.ability_id
                    }
                };
                await db.SaveChangesAsync();
                MessageBox.Show("Register is succefful");
            }
            catch
            {
                MessageBox.Show("This ability is already exist");
            }
        }

        private async void deleteAbility_Click(object sender, EventArgs e)
        {
            try
            {
                CvViewerContext db = new CvViewerContext();
                var personA = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
                {
                    account = account,
                    person = person
                }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
                Ability? ability = await db.abilities.Include(a => a.person_abilities).FirstOrDefaultAsync(a => a.ability_name == lstAbilities.SelectedItem.ToString());
                personA.person.person_ability.Remove(personA.person.person_ability.Where(x => x.ability_id == ability.ability_id).FirstOrDefault());
                await db.SaveChangesAsync();
                listAbility(db);
            }
            catch
            {
                MessageBox.Show("Please choose an ability");
            }
        }

        private async void addExp_Click(object sender, EventArgs e)
        {
            grpExperiences.Visible = false;
            cmbCompany.Items.Clear();
            cmbPosition.Items.Clear();
            cmbPosition.Items.Clear();
            CvViewerContext db = new CvViewerContext();
            grpAddExp.Text = "Add Experience";
            grpAddExp.Visible = true;
            grpAddExp.Location = grpExperiences.Location;
            grpAddExp.Font = grpExperiences.Font;
            grpAddExp.Size = grpExperiences.Size;
            grpAddExp.BackColor = grpExperiences.BackColor;
            grpAddExp.ForeColor = grpExperiences.ForeColor;
            this.Controls.Add(grpAddExp);

            Label lblComp = new Label();
            lblComp.Text = "Choose Company";
            lblComp.Location = new Point(95, 45);
            lblComp.Font = btnSearch.Font;
            lblComp.ForeColor = lblCom.ForeColor;
            lblComp.BackColor = lblCom.BackColor;
            lblComp.AutoSize = true;
            grpAddExp.Controls.Add(lblComp);

            cmbCompany.ForeColor = lblCom.BackColor;
            cmbCompany.Width = lblComp.Width;
            cmbCompany.Location = new Point(95, 85);
            cmbCompany.TextChanged += CmbCompany_TextChanged;
            CmbCompany_TextChanged(sender, e);
            var companies = await db.companies.AsNoTracking().ToListAsync();
            foreach (var item in companies)
            {
                cmbCompany.Items.Add(item.company_name);
            }
            cmbCompany.SelectedIndex = 0;
            grpAddExp.Controls.Add(cmbCompany);

            Label lblPosition = new Label();
            lblPosition.Text = "Choose Position";
            lblPosition.Location = new Point(295, 45);
            lblPosition.Font = btnSearch.Font;
            lblPosition.ForeColor = lblCom.ForeColor;
            lblPosition.BackColor = lblCom.BackColor;
            lblPosition.AutoSize = true;
            grpAddExp.Controls.Add(lblPosition);

            cmbPosition.ForeColor = lblCom.BackColor;
            cmbPosition.Location = new Point(295, 85);
            cmbPosition.Width = lblPosition.Width;
            grpAddExp.Controls.Add(cmbPosition);

            Label lblStart = new Label();
            lblStart.Text = "Start Date";
            lblStart.Location = new Point(130, 130);
            lblStart.Font = btnSearch.Font;
            lblStart.ForeColor = lblCom.ForeColor;
            lblStart.BackColor = lblCom.BackColor;
            lblStart.AutoSize = true;
            grpAddExp.Controls.Add(lblStart);

            DateTime aMonthAgo = DateTime.Today;
            aMonthAgo.AddMonths(-1);
            startDate.MaxDate = aMonthAgo;
            startDate.Location = new Point(75, 165);
            grpAddExp.Controls.Add(startDate);

            Label lblFinish = new Label();
            lblFinish.Text = "Finish Date";
            lblFinish.Location = new Point(335, 130);
            lblFinish.Font = btnSearch.Font;
            lblFinish.ForeColor = lblCom.ForeColor;
            lblFinish.BackColor = lblCom.BackColor;
            lblFinish.AutoSize = true;
            grpAddExp.Controls.Add(lblFinish);

            DateTime faMonthAgo = DateTime.Today;
            faMonthAgo.AddMonths(-1);
            finishDate.MaxDate = aMonthAgo;
            finishDate.Location = new Point(290, 165);
            grpAddExp.Controls.Add(finishDate);

            Button btnAddExp = new Button();
            btnAddExp.BackColor = btnSearch.BackColor;
            btnAddExp.ForeColor = btnSearch.ForeColor;
            btnAddExp.Text = "ADD";
            btnAddExp.AutoSize = true;
            btnAddExp.Click += BtnAddExp_Click;
            btnAddExp.Location = new Point(240, 215);
            grpAddExp.Controls.Add(btnAddExp);

            Button btnBack = new Button();
            btnBack.BackColor = btnSearch.BackColor;
            btnBack.ForeColor = btnSearch.ForeColor;
            btnBack.Text = "BACK";
            btnBack.AutoSize = true;
            btnBack.Click += BtnBack_Click1;
            btnBack.Location = new Point(240, 265);
            grpAddExp.Controls.Add(btnBack);
        }

        private async void BtnBack_Click1(object? sender, EventArgs e)
        {
            grpAddExp.Visible = false;
            grpExperiences.Visible = true;
            listExperiences();
        }
        private async void listExperiences()
        {
            CvViewerContext db = new CvViewerContext();
            lstExperiences.Items.Clear();
            var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
            {
                account = account,
                person = person
            }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
            var experiences = await db.people.Join(db.experiences, p => p.person_id, e => e.person_id, (person, exp) => new
            {
                person = person,
                exp = exp
            }).Join(db.positions, t => t.exp.position_id, p => p.position_id, (total, position) => new
            {
                total = total,
                position = position
            }).Join(db.companies, nt => nt.total.exp.company_id, c => c.company_id, (newTotal, company) => new
            {
                newTotal = newTotal,
                company = company
            }).AsNoTracking().ToListAsync();
            foreach (var item in experiences)
            {
                lstExperiences.Items.Add(item.newTotal.total.exp.experience_id + " - " + item.newTotal.position.position_name + " - " + item.company.company_name + " - " + item.newTotal.total.exp.start_date.Split(" ")[0] + " - " + item.newTotal.total.exp.end_date.Split(" ")[0]);
            }
        }
        private async void BtnAddExp_Click(object? sender, EventArgs e)
        {
            if (finishDate.Value > startDate.Value)
            {
                int nextValue;
                CvViewerContext db = new CvViewerContext();
                try
                {
                    nextValue = db.experiences.Select(ex => ex.experience_id).Max() + 1;
                }
                catch
                {
                    nextValue = 1;
                }
                Experience newExp = new Experience();
                newExp.experience_id = nextValue;
                newExp.end_date = finishDate.Value.ToString();
                newExp.start_date = startDate.Value.ToString();
                var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
                {
                    account = account,
                    person = person
                }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
                newExp.person = person.person;
                Position position = await db.positions.Where(p => p.position_name == cmbPosition.Text).FirstAsync();
                newExp.position = position;
                Company company = await db.companies.Where(c => c.company_name == cmbCompany.Text).FirstAsync();
                newExp.company = company;
                db.Add(newExp);
                db.SaveChanges();
                MessageBox.Show("Register is succefful");
            }
            else
            {
                MessageBox.Show("please check the dates");
            }
        }

        private async void CmbCompany_TextChanged(object? sender, EventArgs e)
        {
            cmbPosition.Items.Clear();
            cmbPosition.Text = "";
            CvViewerContext db = new CvViewerContext();
            var position = await db.companies.Where(c => c.company_name == cmbCompany.Text).Join(db.company_positions, p => p.company_id, a => a.company_id, (company, position) => new
            {
                company = company,
                position = position
            }).Join(db.positions, t => t.position.position_id, a => a.position_id, (total, positions) => new
            {
                total = total,
                position = positions
            }).AsNoTracking().ToListAsync();
            foreach (var item in position)
            {
                cmbPosition.Items.Add(item.position.position_name);
            }
        }

        private async void deleteExp_Click(object sender, EventArgs e)////////////////////////////////////////////////////////////////////
        {
            CvViewerContext db = new CvViewerContext();
            lstExperiences.Items.Clear();
            var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
            {
                account = account,
                person = person
            }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
            //try
            //{
                int selected;
                string[] array = lstExperiences.Items[lstExperiences.SelectedIndex].ToString().Split("-");
                selected = Convert.ToInt32(array[0].Substring(0, array[0].Length - 1));
                var experience = await db.experiences.Where(e => e.experience_id == selected).FirstAsync();
                person.person.experiences.Remove(experience);
                await db.SaveChangesAsync();
                listExperiences();
            //}
            //catch
            //{
            //    MessageBox.Show("Please choose an experience");
            //}
        }

        private void updateExp_Click(object sender, EventArgs e)
        {

        }

        private async void addEdu_Click(object sender, EventArgs e)
        {
            CvViewerContext db = new CvViewerContext();
            grpAddEdu.Text = "Add Education";
            grpAddEdu.Visible = true;
            grpAddEdu.Location = grpEdu.Location;
            grpAddEdu.Font = grpExperiences.Font;
            grpAddEdu.Size = grpEdu.Size;
            grpAddEdu.BackColor = grpExperiences.BackColor;
            grpAddEdu.ForeColor = grpExperiences.ForeColor;
            this.Controls.Add(grpAddEdu);

            grpEdu.Visible = false;
            Label lblSchool = new Label();
            lblSchool.Text = "Choose School";
            lblSchool.Location = new Point(35, 45);
            lblSchool.Font = btnSearch.Font;
            lblSchool.ForeColor = lblCom.ForeColor;
            lblSchool.BackColor = lblCom.BackColor;
            lblSchool.AutoSize = true;
            grpAddEdu.Controls.Add(lblSchool);

            cmbSchool.ForeColor = lblCom.BackColor;
            cmbSchool.Width = lblSchool.Width+10;
            cmbSchool.Location = new Point(30, 80);
            cmbSchool.TextChanged += CmbSchool_TextChanged;
            cmbSchool.Items.Clear();
            var schools = await db.schools.AsNoTracking().ToListAsync();
            foreach (var item in schools)
            {
                cmbSchool.Items.Add(item.school_name);
            }
            cmbSchool.SelectedIndex = 0;
            CmbSchool_TextChanged(sender, e);
            grpAddEdu.Controls.Add(cmbSchool);

            Label lblDepartment = new Label();
            lblDepartment.Text = "Choose Department";
            lblDepartment.Location = new Point(35, 130);
            lblDepartment.Font = btnSearch.Font;
            lblDepartment.ForeColor = lblCom.ForeColor;
            lblDepartment.BackColor = lblCom.BackColor;
            lblDepartment.AutoSize = true;
            grpAddEdu.Controls.Add(lblDepartment);

            cmbDepartment.ForeColor = lblCom.BackColor;
            cmbDepartment.Width = lblDepartment.Width + 10;
            cmbDepartment.Location = new Point(30, 170);
            cmbDepartment.Items.Clear();
            grpAddEdu.Controls.Add(cmbDepartment);

            Label lblStart = new Label();
            lblStart.Text = "Start Date";
            lblStart.Location = new Point(265, 45);
            lblStart.Font = btnSearch.Font;
            lblStart.ForeColor = lblCom.ForeColor;
            lblStart.BackColor = lblCom.BackColor;
            lblStart.AutoSize = true;
            grpAddEdu.Controls.Add(lblStart);

            DateTime aMonthAgo = DateTime.Today;
            aMonthAgo.AddMonths(-1);
            SchoolStartDate.MaxDate = aMonthAgo;
            SchoolStartDate.Location = new Point(260, 80);
            grpAddEdu.Controls.Add(SchoolStartDate);

            Label lblFinish = new Label();
            lblFinish.Text = "Finish Date";
            lblFinish.Location = new Point(265, 130);
            lblFinish.Font = btnSearch.Font;
            lblFinish.ForeColor = lblCom.ForeColor;
            lblFinish.BackColor = lblCom.BackColor;
            lblFinish.AutoSize = true;
            grpAddEdu.Controls.Add(lblFinish);

            schoolFinishDate.Location = new Point(260, 170);
            grpAddEdu.Controls.Add(schoolFinishDate);

            Button btnAddEdu = new Button();
            btnAddEdu.BackColor = btnSearch.BackColor;
            btnAddEdu.ForeColor = btnSearch.ForeColor;
            btnAddEdu.Text = "ADD EDUCATION";
            btnAddEdu.AutoSize = true;
            btnAddEdu.Click += BtnAddEdu_Click;
            btnAddEdu.Location = new Point(470, 120);
            grpAddEdu.Controls.Add(btnAddEdu);
        }
        private async void listEdu()
        {
            lstExperiences.Items.Clear();
            CvViewerContext db = new CvViewerContext();
            var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
            {
                account = account,
                person = person
            }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
            Person p = person.person;
            var educations = db.people.Join(db.person_educations, p => p.person_id, pe => pe.person_id, (person, personEdu) => new
            {
                person = person,
                personEdu = personEdu
            }).Join(db.educations, pe => pe.personEdu.edu_id, e => e.edu_id, (personEdu, educations) => new
            {
                personEdu = personEdu,
                educations = educations
            }).AsNoTracking().ToList();

            foreach (var item in educations)
            {
                var school =await db.schools.Where(s => s.school_id == item.educations.university_id).AsNoTracking().FirstAsync();
                var department = await db.departments.Where(d => d.department_id == item.educations.department_id).AsNoTracking().FirstAsync();
                lstEdu.Items.Add(school.school_name + " - " + department.department_name + " - " + item.personEdu.personEdu.start_date.Split()[0] + " || " + item.personEdu.personEdu.end_date.Split()[0]);
            }
        }
        private async void BtnAddEdu_Click(object? sender, EventArgs e)
        {
            CvViewerContext db = new CvViewerContext();
            var person = await db.accounts.Join(db.people, a => a.account_id, p => p.person_id, (account, person) => new
            {
                account = account,
                person = person
            }).Where(a => a.account.e_mail == txtMail.Text).FirstAsync();
            int schoolId =  await db.schools.Where(s=>s.school_name == cmbSchool.Text).Select(s=>s.school_id).FirstOrDefaultAsync();
            int departmentId =await db.departments.Where(d => d.department_name == cmbDepartment.Text).Select(d => d.department_id).FirstOrDefaultAsync();
            Education edu = await db.educations.Where(e => e.university_id == schoolId).Where(e => e.department_id == departmentId).FirstOrDefaultAsync();
            Person p = person.person;
            p.person_educations = new List<PersonEdu>()
            {
                new()
                {
                    edu_id =edu.edu_id,
                    start_date = SchoolStartDate.Value.ToString(),
                    end_date = schoolFinishDate.Value.ToString()
                }
            };
             db.SaveChanges();
            listEdu();
            MessageBox.Show("Succesfull");
        }

        private async void CmbSchool_TextChanged(object? sender, EventArgs e)
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Text = "";
            CvViewerContext db = new CvViewerContext();
            var department = await db.schools.Where(s=> s.school_name == cmbSchool.Text ).Join(db.school_departments, s => s.school_id, sd =>sd.school_id, (school, schoolDep) => new
            {
                school = school,
                schoolDep = schoolDep
            }).Join(db.departments, t=>t.schoolDep.department_id, d=>d.department_id , (total, departments) => new
            {
                total = total,
                department = departments
            }).AsNoTracking().ToListAsync();
            foreach (var item in department)
            {
                cmbDepartment.Items.Add(item.department.department_name.ToString());
            }
        }

        private void lstEdu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
