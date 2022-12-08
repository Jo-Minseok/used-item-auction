namespace deal_Program
{
    partial class formSignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSignUp));
            this.labelName = new System.Windows.Forms.Label();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPw = new System.Windows.Forms.Label();
            this.labelPh = new System.Windows.Forms.Label();
            this.labelPwc = new System.Windows.Forms.Label();
            this.txtboxEmail = new System.Windows.Forms.TextBox();
            this.txtboxPh = new System.Windows.Forms.TextBox();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.txtboxPw = new System.Windows.Forms.TextBox();
            this.txtboxPwc = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.labelPwcCheck = new System.Windows.Forms.Label();
            this.labelPwCheck = new System.Windows.Forms.Label();
            this.labelNick = new System.Windows.Forms.Label();
            this.txtboxNick = new System.Windows.Forms.TextBox();
            this.labelBR = new System.Windows.Forms.Label();
            this.pictureboxProfile = new System.Windows.Forms.PictureBox();
            this.btnProfileUpload = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.txtboxAddress = new System.Windows.Forms.TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.cbboxGender = new System.Windows.Forms.ComboBox();
            this.dateTimePickerBR = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProfileRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelName.Location = new System.Drawing.Point(225, 57);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(31, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "이름";
            // 
            // txtboxName
            // 
            this.txtboxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxName.Location = new System.Drawing.Point(312, 54);
            this.txtboxName.MaxLength = 10;
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(170, 21);
            this.txtboxName.TabIndex = 3;
            this.txtboxName.TextChanged += new System.EventHandler(this.txtboxName_TextChanged);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelId.Location = new System.Drawing.Point(225, 153);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(43, 15);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "아이디";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelEmail.Location = new System.Drawing.Point(225, 89);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(43, 15);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "이메일";
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPw.Location = new System.Drawing.Point(225, 185);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(55, 15);
            this.labelPw.TabIndex = 4;
            this.labelPw.Text = "비밀번호";
            // 
            // labelPh
            // 
            this.labelPh.AutoSize = true;
            this.labelPh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPh.Location = new System.Drawing.Point(225, 121);
            this.labelPh.Name = "labelPh";
            this.labelPh.Size = new System.Drawing.Size(55, 15);
            this.labelPh.TabIndex = 5;
            this.labelPh.Text = "전화번호";
            // 
            // labelPwc
            // 
            this.labelPwc.AutoSize = true;
            this.labelPwc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPwc.Location = new System.Drawing.Point(225, 224);
            this.labelPwc.Name = "labelPwc";
            this.labelPwc.Size = new System.Drawing.Size(82, 15);
            this.labelPwc.TabIndex = 6;
            this.labelPwc.Text = "비밀번호 확인";
            // 
            // txtboxEmail
            // 
            this.txtboxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxEmail.Location = new System.Drawing.Point(312, 86);
            this.txtboxEmail.Name = "txtboxEmail";
            this.txtboxEmail.Size = new System.Drawing.Size(170, 21);
            this.txtboxEmail.TabIndex = 4;
            this.txtboxEmail.TextChanged += new System.EventHandler(this.txtboxEmail_TextChanged);
            // 
            // txtboxPh
            // 
            this.txtboxPh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxPh.Location = new System.Drawing.Point(312, 118);
            this.txtboxPh.MaxLength = 13;
            this.txtboxPh.Name = "txtboxPh";
            this.txtboxPh.Size = new System.Drawing.Size(170, 21);
            this.txtboxPh.TabIndex = 5;
            this.txtboxPh.TextChanged += new System.EventHandler(this.txtboxPh_TextChanged);
            // 
            // txtboxId
            // 
            this.txtboxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxId.Location = new System.Drawing.Point(312, 150);
            this.txtboxId.MaxLength = 20;
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.Size = new System.Drawing.Size(170, 21);
            this.txtboxId.TabIndex = 6;
            this.txtboxId.TextChanged += new System.EventHandler(this.txtboxId_TextChanged);
            // 
            // txtboxPw
            // 
            this.txtboxPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxPw.Location = new System.Drawing.Point(312, 182);
            this.txtboxPw.MaxLength = 16;
            this.txtboxPw.Name = "txtboxPw";
            this.txtboxPw.PasswordChar = '●';
            this.txtboxPw.Size = new System.Drawing.Size(170, 21);
            this.txtboxPw.TabIndex = 7;
            this.txtboxPw.TextChanged += new System.EventHandler(this.txtboxPw_TextChanged);
            // 
            // txtboxPwc
            // 
            this.txtboxPwc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxPwc.Location = new System.Drawing.Point(312, 221);
            this.txtboxPwc.MaxLength = 16;
            this.txtboxPwc.Name = "txtboxPwc";
            this.txtboxPwc.PasswordChar = '●';
            this.txtboxPwc.Size = new System.Drawing.Size(170, 21);
            this.txtboxPwc.TabIndex = 8;
            this.txtboxPwc.TextChanged += new System.EventHandler(this.txtboxPwc_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(125, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegister.Location = new System.Drawing.Point(407, 443);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "회원가입";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // labelPwcCheck
            // 
            this.labelPwcCheck.AutoSize = true;
            this.labelPwcCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPwcCheck.ForeColor = System.Drawing.Color.Red;
            this.labelPwcCheck.Location = new System.Drawing.Point(310, 244);
            this.labelPwcCheck.Name = "labelPwcCheck";
            this.labelPwcCheck.Size = new System.Drawing.Size(175, 15);
            this.labelPwcCheck.TabIndex = 14;
            this.labelPwcCheck.Text = "비밀번호와 일치하지 않습니다!";
            this.labelPwcCheck.Visible = false;
            // 
            // labelPwCheck
            // 
            this.labelPwCheck.AutoSize = true;
            this.labelPwCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPwCheck.ForeColor = System.Drawing.Color.Red;
            this.labelPwCheck.Location = new System.Drawing.Point(310, 205);
            this.labelPwCheck.Name = "labelPwCheck";
            this.labelPwCheck.Size = new System.Drawing.Size(422, 15);
            this.labelPwCheck.TabIndex = 15;
            this.labelPwCheck.Text = "특수문자(`,!,@,#,$,%,^,&,*), 알파벳, 숫자가 포함되어야 합니다.(8자~16자)";
            this.labelPwCheck.Visible = false;
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelNick.Location = new System.Drawing.Point(225, 25);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(43, 15);
            this.labelNick.TabIndex = 0;
            this.labelNick.Text = "닉네임";
            // 
            // txtboxNick
            // 
            this.txtboxNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxNick.Location = new System.Drawing.Point(312, 22);
            this.txtboxNick.MaxLength = 10;
            this.txtboxNick.Name = "txtboxNick";
            this.txtboxNick.Size = new System.Drawing.Size(170, 21);
            this.txtboxNick.TabIndex = 2;
            this.txtboxNick.TextChanged += new System.EventHandler(this.txtboxNick_TextChanged);
            // 
            // labelBR
            // 
            this.labelBR.AutoSize = true;
            this.labelBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelBR.Location = new System.Drawing.Point(225, 298);
            this.labelBR.Name = "labelBR";
            this.labelBR.Size = new System.Drawing.Size(55, 15);
            this.labelBR.TabIndex = 16;
            this.labelBR.Text = "생년월일";
            // 
            // pictureboxProfile
            // 
            this.pictureboxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureboxProfile.Image = global::deal_Program.Properties.Resources.unknown;
            this.pictureboxProfile.Location = new System.Drawing.Point(29, 39);
            this.pictureboxProfile.Name = "pictureboxProfile";
            this.pictureboxProfile.Size = new System.Drawing.Size(171, 189);
            this.pictureboxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxProfile.TabIndex = 18;
            this.pictureboxProfile.TabStop = false;
            // 
            // btnProfileUpload
            // 
            this.btnProfileUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProfileUpload.Location = new System.Drawing.Point(29, 234);
            this.btnProfileUpload.Name = "btnProfileUpload";
            this.btnProfileUpload.Size = new System.Drawing.Size(81, 28);
            this.btnProfileUpload.TabIndex = 12;
            this.btnProfileUpload.Text = "업로드";
            this.btnProfileUpload.UseVisualStyleBackColor = true;
            this.btnProfileUpload.Click += new System.EventHandler(this.btnProfileUpload_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAddress.Location = new System.Drawing.Point(225, 335);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(31, 15);
            this.labelAddress.TabIndex = 20;
            this.labelAddress.Text = "주소";
            // 
            // txtboxAddress
            // 
            this.txtboxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxAddress.Location = new System.Drawing.Point(312, 332);
            this.txtboxAddress.MaxLength = 50;
            this.txtboxAddress.Multiline = true;
            this.txtboxAddress.Name = "txtboxAddress";
            this.txtboxAddress.Size = new System.Drawing.Size(220, 102);
            this.txtboxAddress.TabIndex = 11;
            this.txtboxAddress.TextChanged += new System.EventHandler(this.txtboxAddress_TextChanged);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelGender.Location = new System.Drawing.Point(225, 263);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(31, 15);
            this.labelGender.TabIndex = 22;
            this.labelGender.Text = "성별";
            // 
            // cbboxGender
            // 
            this.cbboxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxGender.FormattingEnabled = true;
            this.cbboxGender.Items.AddRange(new object[] {
            "남",
            "여"});
            this.cbboxGender.Location = new System.Drawing.Point(312, 260);
            this.cbboxGender.Name = "cbboxGender";
            this.cbboxGender.Size = new System.Drawing.Size(100, 23);
            this.cbboxGender.TabIndex = 9;
            this.cbboxGender.SelectedValueChanged += new System.EventHandler(this.cbboxGender_SelectedValueChanged);
            // 
            // dateTimePickerBR
            // 
            this.dateTimePickerBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePickerBR.Location = new System.Drawing.Point(312, 292);
            this.dateTimePickerBR.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBR.Name = "dateTimePickerBR";
            this.dateTimePickerBR.Size = new System.Drawing.Size(170, 21);
            this.dateTimePickerBR.TabIndex = 10;
            this.dateTimePickerBR.ValueChanged += new System.EventHandler(this.dateTimePickerBR_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "이미지 파일(*.png,*.jpg)|*.png;*.jpg|모든 파일(*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowHelp = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(91, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "프로필";
            // 
            // btnProfileRemove
            // 
            this.btnProfileRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProfileRemove.Location = new System.Drawing.Point(119, 234);
            this.btnProfileRemove.Name = "btnProfileRemove";
            this.btnProfileRemove.Size = new System.Drawing.Size(81, 28);
            this.btnProfileRemove.TabIndex = 26;
            this.btnProfileRemove.Text = "삭제";
            this.btnProfileRemove.UseVisualStyleBackColor = true;
            this.btnProfileRemove.Click += new System.EventHandler(this.btnProfileRemove_Click);
            // 
            // formSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 478);
            this.Controls.Add(this.btnProfileRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerBR);
            this.Controls.Add(this.cbboxGender);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.txtboxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.btnProfileUpload);
            this.Controls.Add(this.pictureboxProfile);
            this.Controls.Add(this.labelBR);
            this.Controls.Add(this.labelPwCheck);
            this.Controls.Add(this.labelPwcCheck);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtboxPwc);
            this.Controls.Add(this.txtboxPw);
            this.Controls.Add(this.txtboxId);
            this.Controls.Add(this.txtboxPh);
            this.Controls.Add(this.txtboxEmail);
            this.Controls.Add(this.labelPwc);
            this.Controls.Add(this.labelPh);
            this.Controls.Add(this.labelPw);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.txtboxNick);
            this.Controls.Add(this.txtboxName);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.formSignUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.Label labelPh;
        private System.Windows.Forms.Label labelPwc;
        private System.Windows.Forms.TextBox txtboxEmail;
        private System.Windows.Forms.TextBox txtboxPh;
        private System.Windows.Forms.TextBox txtboxId;
        private System.Windows.Forms.TextBox txtboxPw;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtboxPwc;
        private System.Windows.Forms.Label labelPwcCheck;
        private System.Windows.Forms.Label labelPwCheck;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.TextBox txtboxNick;
        private System.Windows.Forms.Label labelBR;
        private System.Windows.Forms.PictureBox pictureboxProfile;
        private System.Windows.Forms.Button btnProfileUpload;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox txtboxAddress;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox cbboxGender;
        private System.Windows.Forms.DateTimePicker dateTimePickerBR;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfileRemove;
    }
}