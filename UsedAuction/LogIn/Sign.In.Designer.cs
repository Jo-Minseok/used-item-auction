namespace deal_Program
{
    partial class formSignIn
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSignIn));
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelPw = new System.Windows.Forms.Label();
            this.checkboxModerator = new System.Windows.Forms.CheckBox();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.txtboxPw = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelAlert = new System.Windows.Forms.Label();
            this.statusBottom = new System.Windows.Forms.StatusStrip();
            this.statusMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusInternet = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFindIdPw = new System.Windows.Forms.Label();
            this.timerCheckInternet = new System.Windows.Forms.Timer(this.components);
            this.pictureboxLogo = new System.Windows.Forms.PictureBox();
            this.groupboxLogin = new System.Windows.Forms.GroupBox();
            this.statusBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).BeginInit();
            this.groupboxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSignIn.Location = new System.Drawing.Point(78, 263);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(90, 30);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "로그인";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSignUp.Location = new System.Drawing.Point(174, 263);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(90, 30);
            this.btnSignUp.TabIndex = 5;
            this.btnSignUp.Text = "회원가입";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(44, 24);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(40, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "아이디";
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Location = new System.Drawing.Point(32, 54);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(51, 13);
            this.labelPw.TabIndex = 3;
            this.labelPw.Text = "비밀번호";
            // 
            // checkboxModerator
            // 
            this.checkboxModerator.AutoSize = true;
            this.checkboxModerator.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkboxModerator.Location = new System.Drawing.Point(117, 241);
            this.checkboxModerator.Name = "checkboxModerator";
            this.checkboxModerator.Size = new System.Drawing.Size(84, 17);
            this.checkboxModerator.TabIndex = 2;
            this.checkboxModerator.Text = "관리자 모드";
            this.checkboxModerator.UseVisualStyleBackColor = true;
            this.checkboxModerator.CheckedChanged += new System.EventHandler(this.checkboxModerator_CheckedChanged);
            // 
            // txtboxId
            // 
            this.txtboxId.Location = new System.Drawing.Point(91, 21);
            this.txtboxId.MaxLength = 20;
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.Size = new System.Drawing.Size(124, 21);
            this.txtboxId.TabIndex = 0;
            // 
            // txtboxPw
            // 
            this.txtboxPw.Location = new System.Drawing.Point(91, 51);
            this.txtboxPw.MaxLength = 16;
            this.txtboxPw.Name = "txtboxPw";
            this.txtboxPw.PasswordChar = '●';
            this.txtboxPw.Size = new System.Drawing.Size(124, 21);
            this.txtboxPw.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(270, 263);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelAlert
            // 
            this.labelAlert.AutoSize = true;
            this.labelAlert.ForeColor = System.Drawing.Color.Red;
            this.labelAlert.Location = new System.Drawing.Point(156, 223);
            this.labelAlert.Name = "labelAlert";
            this.labelAlert.Size = new System.Drawing.Size(0, 12);
            this.labelAlert.TabIndex = 8;
            // 
            // statusBottom
            // 
            this.statusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMode,
            this.toolStripStatusInternet});
            this.statusBottom.Location = new System.Drawing.Point(0, 307);
            this.statusBottom.Name = "statusBottom";
            this.statusBottom.Size = new System.Drawing.Size(452, 22);
            this.statusBottom.TabIndex = 9;
            this.statusBottom.Text = "statusStrip1";
            // 
            // statusMode
            // 
            this.statusMode.AutoSize = false;
            this.statusMode.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusMode.Name = "statusMode";
            this.statusMode.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.statusMode.Size = new System.Drawing.Size(65, 17);
            this.statusMode.Text = "유저 모드";
            this.statusMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusInternet
            // 
            this.toolStripStatusInternet.AutoSize = false;
            this.toolStripStatusInternet.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toolStripStatusInternet.Name = "toolStripStatusInternet";
            this.toolStripStatusInternet.Size = new System.Drawing.Size(372, 17);
            this.toolStripStatusInternet.Text = "인터넷 : ";
            this.toolStripStatusInternet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFindIdPw
            // 
            this.labelFindIdPw.AutoSize = true;
            this.labelFindIdPw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFindIdPw.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelFindIdPw.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelFindIdPw.Location = new System.Drawing.Point(207, 242);
            this.labelFindIdPw.Name = "labelFindIdPw";
            this.labelFindIdPw.Size = new System.Drawing.Size(165, 13);
            this.labelFindIdPw.TabIndex = 3;
            this.labelFindIdPw.Text = "아이디, 비밀번호를 잊으셨나요?";
            this.labelFindIdPw.Click += new System.EventHandler(this.labelFindIdPw_Click);
            // 
            // timerCheckInternet
            // 
            this.timerCheckInternet.Interval = 5000;
            this.timerCheckInternet.Tick += new System.EventHandler(this.timerCheckInternet_Tick);
            // 
            // pictureboxLogo
            // 
            this.pictureboxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureboxLogo.Image = global::deal_Program.Properties.Resources.login;
            this.pictureboxLogo.Location = new System.Drawing.Point(49, 26);
            this.pictureboxLogo.Name = "pictureboxLogo";
            this.pictureboxLogo.Size = new System.Drawing.Size(344, 102);
            this.pictureboxLogo.TabIndex = 10;
            this.pictureboxLogo.TabStop = false;
            // 
            // groupboxLogin
            // 
            this.groupboxLogin.Controls.Add(this.txtboxId);
            this.groupboxLogin.Controls.Add(this.labelId);
            this.groupboxLogin.Controls.Add(this.txtboxPw);
            this.groupboxLogin.Controls.Add(this.labelPw);
            this.groupboxLogin.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupboxLogin.Location = new System.Drawing.Point(104, 134);
            this.groupboxLogin.Name = "groupboxLogin";
            this.groupboxLogin.Size = new System.Drawing.Size(239, 86);
            this.groupboxLogin.TabIndex = 11;
            this.groupboxLogin.TabStop = false;
            this.groupboxLogin.Text = "로그인";
            // 
            // formSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 329);
            this.Controls.Add(this.groupboxLogin);
            this.Controls.Add(this.pictureboxLogo);
            this.Controls.Add(this.labelFindIdPw);
            this.Controls.Add(this.statusBottom);
            this.Controls.Add(this.labelAlert);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.checkboxModerator);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formSignIn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSignIn_FormClosing);
            this.Load += new System.EventHandler(this.formSignIn_Load);
            this.statusBottom.ResumeLayout(false);
            this.statusBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogo)).EndInit();
            this.groupboxLogin.ResumeLayout(false);
            this.groupboxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.CheckBox checkboxModerator;
        private System.Windows.Forms.TextBox txtboxId;
        private System.Windows.Forms.TextBox txtboxPw;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelAlert;
        private System.Windows.Forms.StatusStrip statusBottom;
        private System.Windows.Forms.ToolStripStatusLabel statusMode;
        private System.Windows.Forms.Label labelFindIdPw;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusInternet;
        private System.Windows.Forms.Timer timerCheckInternet;
        private System.Windows.Forms.PictureBox pictureboxLogo;
        private System.Windows.Forms.GroupBox groupboxLogin;
    }
}

