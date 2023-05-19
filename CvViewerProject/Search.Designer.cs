namespace CvViewerProject
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lstbxAccount = new System.Windows.Forms.ListBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.grpList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(530, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "CV VIEWER";
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.btnBack);
            this.grpList.Controls.Add(this.lstbxAccount);
            this.grpList.Controls.Add(this.txtAccount);
            this.grpList.Controls.Add(this.btnSearch);
            this.grpList.ForeColor = System.Drawing.Color.White;
            this.grpList.Location = new System.Drawing.Point(178, 77);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(872, 416);
            this.grpList.TabIndex = 5;
            this.grpList.TabStop = false;
            this.grpList.Text = "groupBox1";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.SkyBlue;
            this.btnBack.Location = new System.Drawing.Point(36, 30);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 33);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "<-BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lstbxAccount
            // 
            this.lstbxAccount.FormattingEnabled = true;
            this.lstbxAccount.ItemHeight = 23;
            this.lstbxAccount.Location = new System.Drawing.Point(36, 81);
            this.lstbxAccount.Name = "lstbxAccount";
            this.lstbxAccount.Size = new System.Drawing.Size(777, 326);
            this.lstbxAccount.TabIndex = 5;
            // 
            // txtAccount
            // 
            this.txtAccount.ForeColor = System.Drawing.Color.SkyBlue;
            this.txtAccount.Location = new System.Drawing.Point(261, 27);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(195, 31);
            this.txtAccount.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.Location = new System.Drawing.Point(491, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 33);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMail
            // 
            this.txtMail.ForeColor = System.Drawing.Color.SkyBlue;
            this.txtMail.Location = new System.Drawing.Point(1082, 475);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(106, 31);
            this.txtMail.TabIndex = 6;
            this.txtMail.Visible = false;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1200, 518);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.grpList.ResumeLayout(false);
            this.grpList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private GroupBox grpList;
        private ListBox lstbxAccount;
        private TextBox txtAccount;
        private Button btnSearch;
        private Button btnBack;
        private TextBox txtMail;
    }
}