namespace deal_Program
{
    partial class formFindIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFindIP));
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.btnIdFind = new System.Windows.Forms.Button();
            this.labelResultID = new System.Windows.Forms.Label();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.txtboxEmail = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.btnPwFind = new System.Windows.Forms.Button();
            this.labelResultPW = new System.Windows.Forms.Label();
            this.labelPh = new System.Windows.Forms.Label();
            this.txtboxPh = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.checkboxModerator = new System.Windows.Forms.CheckBox();
            this.groupboxId = new System.Windows.Forms.GroupBox();
            this.groupboxPW = new System.Windows.Forms.GroupBox();
            this.groupboxId.SuspendLayout();
            this.groupboxPW.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(16, 74);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(40, 13);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "이메일";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(28, 45);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "이름";
            // 
            // btnIdFind
            // 
            this.btnIdFind.Location = new System.Drawing.Point(7, 102);
            this.btnIdFind.Name = "btnIdFind";
            this.btnIdFind.Size = new System.Drawing.Size(50, 23);
            this.btnIdFind.TabIndex = 3;
            this.btnIdFind.Text = "검색";
            this.btnIdFind.UseVisualStyleBackColor = true;
            this.btnIdFind.Click += new System.EventHandler(this.btnIdFind_Click);
            // 
            // labelResultID
            // 
            this.labelResultID.AutoSize = true;
            this.labelResultID.Location = new System.Drawing.Point(63, 107);
            this.labelResultID.Name = "labelResultID";
            this.labelResultID.Size = new System.Drawing.Size(0, 13);
            this.labelResultID.TabIndex = 3;
            // 
            // txtboxName
            // 
            this.txtboxName.Location = new System.Drawing.Point(70, 42);
            this.txtboxName.MaxLength = 10;
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(293, 21);
            this.txtboxName.TabIndex = 1;
            // 
            // txtboxEmail
            // 
            this.txtboxEmail.Location = new System.Drawing.Point(70, 65);
            this.txtboxEmail.Name = "txtboxEmail";
            this.txtboxEmail.Size = new System.Drawing.Size(293, 21);
            this.txtboxEmail.TabIndex = 2;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(16, 21);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(40, 13);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "아이디";
            // 
            // txtboxId
            // 
            this.txtboxId.Location = new System.Drawing.Point(70, 17);
            this.txtboxId.MaxLength = 20;
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.Size = new System.Drawing.Size(293, 21);
            this.txtboxId.TabIndex = 4;
            // 
            // btnPwFind
            // 
            this.btnPwFind.Location = new System.Drawing.Point(6, 77);
            this.btnPwFind.Name = "btnPwFind";
            this.btnPwFind.Size = new System.Drawing.Size(50, 23);
            this.btnPwFind.TabIndex = 6;
            this.btnPwFind.Text = "검색";
            this.btnPwFind.UseVisualStyleBackColor = true;
            this.btnPwFind.Click += new System.EventHandler(this.btnPwFind_Click);
            // 
            // labelResultPW
            // 
            this.labelResultPW.AutoSize = true;
            this.labelResultPW.Location = new System.Drawing.Point(62, 82);
            this.labelResultPW.Name = "labelResultPW";
            this.labelResultPW.Size = new System.Drawing.Size(0, 13);
            this.labelResultPW.TabIndex = 11;
            // 
            // labelPh
            // 
            this.labelPh.AutoSize = true;
            this.labelPh.Location = new System.Drawing.Point(4, 45);
            this.labelPh.Name = "labelPh";
            this.labelPh.Size = new System.Drawing.Size(51, 13);
            this.labelPh.TabIndex = 12;
            this.labelPh.Text = "전화번호";
            // 
            // txtboxPh
            // 
            this.txtboxPh.Location = new System.Drawing.Point(70, 42);
            this.txtboxPh.MaxLength = 13;
            this.txtboxPh.Name = "txtboxPh";
            this.txtboxPh.Size = new System.Drawing.Size(293, 21);
            this.txtboxPh.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(179, 307);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "취소";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // checkboxModerator
            // 
            this.checkboxModerator.AutoSize = true;
            this.checkboxModerator.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkboxModerator.Location = new System.Drawing.Point(334, 294);
            this.checkboxModerator.Name = "checkboxModerator";
            this.checkboxModerator.Size = new System.Drawing.Size(84, 17);
            this.checkboxModerator.TabIndex = 7;
            this.checkboxModerator.Text = "관리자 계정";
            this.checkboxModerator.UseVisualStyleBackColor = true;
            // 
            // groupboxId
            // 
            this.groupboxId.Controls.Add(this.txtboxEmail);
            this.groupboxId.Controls.Add(this.labelEmail);
            this.groupboxId.Controls.Add(this.labelName);
            this.groupboxId.Controls.Add(this.btnIdFind);
            this.groupboxId.Controls.Add(this.txtboxName);
            this.groupboxId.Controls.Add(this.labelResultID);
            this.groupboxId.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupboxId.Location = new System.Drawing.Point(14, 12);
            this.groupboxId.Name = "groupboxId";
            this.groupboxId.Size = new System.Drawing.Size(408, 138);
            this.groupboxId.TabIndex = 16;
            this.groupboxId.TabStop = false;
            this.groupboxId.Text = "아이디 찾기";
            // 
            // groupboxPW
            // 
            this.groupboxPW.Controls.Add(this.txtboxPh);
            this.groupboxPW.Controls.Add(this.labelId);
            this.groupboxPW.Controls.Add(this.txtboxId);
            this.groupboxPW.Controls.Add(this.btnPwFind);
            this.groupboxPW.Controls.Add(this.labelResultPW);
            this.groupboxPW.Controls.Add(this.labelPh);
            this.groupboxPW.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupboxPW.Location = new System.Drawing.Point(14, 172);
            this.groupboxPW.Name = "groupboxPW";
            this.groupboxPW.Size = new System.Drawing.Size(408, 116);
            this.groupboxPW.TabIndex = 17;
            this.groupboxPW.TabStop = false;
            this.groupboxPW.Text = "비밀번호 찾기";
            // 
            // formFindIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 337);
            this.Controls.Add(this.groupboxPW);
            this.Controls.Add(this.groupboxId);
            this.Controls.Add(this.checkboxModerator);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formFindIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "아이디, 비밀번호 찾기";
            this.Load += new System.EventHandler(this.formFindIP_Load);
            this.groupboxId.ResumeLayout(false);
            this.groupboxId.PerformLayout();
            this.groupboxPW.ResumeLayout(false);
            this.groupboxPW.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnIdFind;
        private System.Windows.Forms.Label labelResultID;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.TextBox txtboxEmail;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtboxId;
        private System.Windows.Forms.Button btnPwFind;
        private System.Windows.Forms.Label labelResultPW;
        private System.Windows.Forms.Label labelPh;
        private System.Windows.Forms.TextBox txtboxPh;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox checkboxModerator;
        private System.Windows.Forms.GroupBox groupboxId;
        private System.Windows.Forms.GroupBox groupboxPW;
    }
}