namespace deal_Program
{
    partial class formMDhome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMDhome));
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.cbboxSearch = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMDPlus = new System.Windows.Forms.Button();
            this.btnObjManage = new System.Windows.Forms.Button();
            this.pictureboxProfile = new System.Windows.Forms.PictureBox();
            this.btnRefix = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNick = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPh = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelBR = new System.Windows.Forms.Label();
            this.labelPw = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.txtboxNick = new System.Windows.Forms.TextBox();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.txtboxPh = new System.Windows.Forms.TextBox();
            this.txtboxAddress = new System.Windows.Forms.TextBox();
            this.txtboxBR = new System.Windows.Forms.TextBox();
            this.txtboxPw = new System.Windows.Forms.TextBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.labelProfile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDBCheck = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbboxGender = new System.Windows.Forms.ComboBox();
            this.txtboxCash = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearchUser.Location = new System.Drawing.Point(53, 19);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(75, 25);
            this.btnSearchUser.TabIndex = 2;
            this.btnSearchUser.Text = "검색";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxSearch.Location = new System.Drawing.Point(203, 21);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(230, 21);
            this.txtboxSearch.TabIndex = 0;
            // 
            // cbboxSearch
            // 
            this.cbboxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxSearch.FormattingEnabled = true;
            this.cbboxSearch.Items.AddRange(new object[] {
            "ID",
            "닉네임",
            "이메일"});
            this.cbboxSearch.Location = new System.Drawing.Point(134, 21);
            this.cbboxSearch.Name = "cbboxSearch";
            this.cbboxSearch.Size = new System.Drawing.Size(63, 23);
            this.cbboxSearch.Sorted = true;
            this.cbboxSearch.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(554, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMDPlus
            // 
            this.btnMDPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMDPlus.Location = new System.Drawing.Point(473, 48);
            this.btnMDPlus.Name = "btnMDPlus";
            this.btnMDPlus.Size = new System.Drawing.Size(156, 23);
            this.btnMDPlus.TabIndex = 8;
            this.btnMDPlus.Text = "관리자 계정 추가";
            this.btnMDPlus.UseVisualStyleBackColor = true;
            this.btnMDPlus.Click += new System.EventHandler(this.btnMDPlus_Click);
            // 
            // btnObjManage
            // 
            this.btnObjManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnObjManage.Location = new System.Drawing.Point(473, 77);
            this.btnObjManage.Name = "btnObjManage";
            this.btnObjManage.Size = new System.Drawing.Size(156, 23);
            this.btnObjManage.TabIndex = 9;
            this.btnObjManage.Text = "경매 물건 관리";
            this.btnObjManage.UseVisualStyleBackColor = true;
            this.btnObjManage.Click += new System.EventHandler(this.btnObjManage_Click);
            // 
            // pictureboxProfile
            // 
            this.pictureboxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureboxProfile.ErrorImage = null;
            this.pictureboxProfile.Image = global::deal_Program.Properties.Resources.unknown;
            this.pictureboxProfile.InitialImage = null;
            this.pictureboxProfile.Location = new System.Drawing.Point(23, 92);
            this.pictureboxProfile.Name = "pictureboxProfile";
            this.pictureboxProfile.Size = new System.Drawing.Size(135, 146);
            this.pictureboxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxProfile.TabIndex = 7;
            this.pictureboxProfile.TabStop = false;
            // 
            // btnRefix
            // 
            this.btnRefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefix.Location = new System.Drawing.Point(23, 244);
            this.btnRefix.Name = "btnRefix";
            this.btnRefix.Size = new System.Drawing.Size(135, 24);
            this.btnRefix.TabIndex = 4;
            this.btnRefix.Text = "수정";
            this.btnRefix.UseVisualStyleBackColor = true;
            this.btnRefix.Click += new System.EventHandler(this.btnRefix_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(3, 168);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(43, 15);
            this.labelId.TabIndex = 9;
            this.labelId.Text = "아이디";
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Location = new System.Drawing.Point(3, 0);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(43, 15);
            this.labelNick.TabIndex = 9;
            this.labelNick.Text = "닉네임";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 84);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(43, 15);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "이메일";
            // 
            // labelPh
            // 
            this.labelPh.AutoSize = true;
            this.labelPh.Location = new System.Drawing.Point(3, 126);
            this.labelPh.Name = "labelPh";
            this.labelPh.Size = new System.Drawing.Size(55, 15);
            this.labelPh.TabIndex = 9;
            this.labelPh.Text = "전화번호";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(3, 252);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(31, 15);
            this.labelGender.TabIndex = 9;
            this.labelGender.Text = "성별";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(3, 380);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(31, 15);
            this.labelAddress.TabIndex = 9;
            this.labelAddress.Text = "주소";
            // 
            // labelBR
            // 
            this.labelBR.AutoSize = true;
            this.labelBR.Location = new System.Drawing.Point(3, 296);
            this.labelBR.Name = "labelBR";
            this.labelBR.Size = new System.Drawing.Size(55, 15);
            this.labelBR.TabIndex = 9;
            this.labelBR.Text = "생년월일";
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Location = new System.Drawing.Point(3, 210);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(55, 15);
            this.labelPw.TabIndex = 9;
            this.labelPw.Text = "비밀번호";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(3, 338);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(55, 15);
            this.labelMoney.TabIndex = 9;
            this.labelMoney.Text = "계좌잔고";
            // 
            // txtboxId
            // 
            this.txtboxId.Location = new System.Drawing.Point(3, 186);
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.ReadOnly = true;
            this.txtboxId.Size = new System.Drawing.Size(230, 21);
            this.txtboxId.TabIndex = 5;
            // 
            // txtboxNick
            // 
            this.txtboxNick.Location = new System.Drawing.Point(3, 18);
            this.txtboxNick.MaxLength = 10;
            this.txtboxNick.Name = "txtboxNick";
            this.txtboxNick.Size = new System.Drawing.Size(230, 21);
            this.txtboxNick.TabIndex = 1;
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Location = new System.Drawing.Point(3, 102);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(230, 21);
            this.txtBoxEmail.TabIndex = 3;
            // 
            // txtboxPh
            // 
            this.txtboxPh.Location = new System.Drawing.Point(3, 144);
            this.txtboxPh.MaxLength = 13;
            this.txtboxPh.Name = "txtboxPh";
            this.txtboxPh.Size = new System.Drawing.Size(230, 21);
            this.txtboxPh.TabIndex = 4;
            // 
            // txtboxAddress
            // 
            this.txtboxAddress.Location = new System.Drawing.Point(3, 398);
            this.txtboxAddress.MaxLength = 50;
            this.txtboxAddress.Multiline = true;
            this.txtboxAddress.Name = "txtboxAddress";
            this.txtboxAddress.Size = new System.Drawing.Size(230, 61);
            this.txtboxAddress.TabIndex = 10;
            // 
            // txtboxBR
            // 
            this.txtboxBR.Location = new System.Drawing.Point(3, 314);
            this.txtboxBR.Name = "txtboxBR";
            this.txtboxBR.Size = new System.Drawing.Size(230, 21);
            this.txtboxBR.TabIndex = 8;
            // 
            // txtboxPw
            // 
            this.txtboxPw.Location = new System.Drawing.Point(3, 228);
            this.txtboxPw.MaxLength = 16;
            this.txtboxPw.Name = "txtboxPw";
            this.txtboxPw.Size = new System.Drawing.Size(230, 21);
            this.txtboxPw.TabIndex = 6;
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModify.Location = new System.Drawing.Point(473, 19);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(31, 15);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "이름";
            // 
            // txtboxName
            // 
            this.txtboxName.Location = new System.Drawing.Point(3, 60);
            this.txtboxName.MaxLength = 10;
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(230, 21);
            this.txtboxName.TabIndex = 2;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelProfile.Location = new System.Drawing.Point(70, 77);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(43, 15);
            this.labelProfile.TabIndex = 14;
            this.labelProfile.Text = "프로필";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "이미지 파일(*.png,*.jpg)|*.png;*.jpg|모든 파일(*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // btnDBCheck
            // 
            this.btnDBCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDBCheck.Location = new System.Drawing.Point(473, 106);
            this.btnDBCheck.Name = "btnDBCheck";
            this.btnDBCheck.Size = new System.Drawing.Size(156, 23);
            this.btnDBCheck.TabIndex = 10;
            this.btnDBCheck.Text = "DB 확인";
            this.btnDBCheck.UseVisualStyleBackColor = true;
            this.btnDBCheck.Click += new System.EventHandler(this.btnDBCheck_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel1.Controls.Add(this.labelNick);
            this.flowLayoutPanel1.Controls.Add(this.txtboxNick);
            this.flowLayoutPanel1.Controls.Add(this.labelName);
            this.flowLayoutPanel1.Controls.Add(this.txtboxName);
            this.flowLayoutPanel1.Controls.Add(this.labelEmail);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxEmail);
            this.flowLayoutPanel1.Controls.Add(this.labelPh);
            this.flowLayoutPanel1.Controls.Add(this.txtboxPh);
            this.flowLayoutPanel1.Controls.Add(this.labelId);
            this.flowLayoutPanel1.Controls.Add(this.txtboxId);
            this.flowLayoutPanel1.Controls.Add(this.labelPw);
            this.flowLayoutPanel1.Controls.Add(this.txtboxPw);
            this.flowLayoutPanel1.Controls.Add(this.labelGender);
            this.flowLayoutPanel1.Controls.Add(this.cbboxGender);
            this.flowLayoutPanel1.Controls.Add(this.labelBR);
            this.flowLayoutPanel1.Controls.Add(this.txtboxBR);
            this.flowLayoutPanel1.Controls.Add(this.labelMoney);
            this.flowLayoutPanel1.Controls.Add(this.txtboxCash);
            this.flowLayoutPanel1.Controls.Add(this.labelAddress);
            this.flowLayoutPanel1.Controls.Add(this.txtboxAddress);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(203, 77);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 473);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // cbboxGender
            // 
            this.cbboxGender.FormattingEnabled = true;
            this.cbboxGender.Items.AddRange(new object[] {
            "남",
            "여"});
            this.cbboxGender.Location = new System.Drawing.Point(3, 270);
            this.cbboxGender.Name = "cbboxGender";
            this.cbboxGender.Size = new System.Drawing.Size(53, 23);
            this.cbboxGender.TabIndex = 7;
            // 
            // txtboxCash
            // 
            this.txtboxCash.Location = new System.Drawing.Point(3, 356);
            this.txtboxCash.MaxLength = 15;
            this.txtboxCash.Name = "txtboxCash";
            this.txtboxCash.Size = new System.Drawing.Size(230, 21);
            this.txtboxCash.TabIndex = 9;
            this.txtboxCash.TextChanged += new System.EventHandler(this.txtboxCash_TextChanged);
            this.txtboxCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtboxCash_KeyPress);
            // 
            // formMDhome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(650, 562);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnDBCheck);
            this.Controls.Add(this.labelProfile);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnRefix);
            this.Controls.Add(this.pictureboxProfile);
            this.Controls.Add(this.btnObjManage);
            this.Controls.Add(this.btnMDPlus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbboxSearch);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.btnSearchUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMDhome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [관리자 홈]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMDhome_FormClosing);
            this.Load += new System.EventHandler(this.formMDhome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.ComboBox cbboxSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMDPlus;
        private System.Windows.Forms.Button btnObjManage;
        private System.Windows.Forms.PictureBox pictureboxProfile;
        private System.Windows.Forms.Button btnRefix;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPh;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelBR;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.TextBox txtboxId;
        private System.Windows.Forms.TextBox txtboxNick;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.TextBox txtboxPh;
        private System.Windows.Forms.TextBox txtboxAddress;
        private System.Windows.Forms.TextBox txtboxBR;
        private System.Windows.Forms.TextBox txtboxPw;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDBCheck;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbboxGender;
        private System.Windows.Forms.TextBox txtboxCash;
    }
}