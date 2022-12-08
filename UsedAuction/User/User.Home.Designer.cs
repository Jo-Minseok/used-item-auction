namespace deal_Program
{
    partial class formUShome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formUShome));
            this.cbboxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelNickname = new System.Windows.Forms.Label();
            this.labelInAuction = new System.Windows.Forms.Label();
            this.labelSuccessAuction = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelAuctionMoney = new System.Windows.Forms.Label();
            this.labelAvaAuctionMoney = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnNewAuction = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnCheckAuction = new System.Windows.Forms.Button();
            this.gouprbxUserFunction = new System.Windows.Forms.GroupBox();
            this.btnMyAuction = new System.Windows.Forms.Button();
            this.groupbxUserInformation = new System.Windows.Forms.GroupBox();
            this.groupbxCash = new System.Windows.Forms.GroupBox();
            this.labelLeftMoney = new System.Windows.Forms.Label();
            this.labelAuctioningMoney = new System.Windows.Forms.Label();
            this.labelTotalMoeny = new System.Windows.Forms.Label();
            this.btnModifyCategory = new System.Windows.Forms.Button();
            this.flowLayoutPanelHome = new System.Windows.Forms.FlowLayoutPanel();
            this.labelIsObj = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.gouprbxUserFunction.SuspendLayout();
            this.groupbxUserInformation.SuspendLayout();
            this.groupbxCash.SuspendLayout();
            this.flowLayoutPanelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // cbboxCategory
            // 
            this.cbboxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbboxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbboxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxCategory.FormattingEnabled = true;
            this.cbboxCategory.Location = new System.Drawing.Point(348, 137);
            this.cbboxCategory.Name = "cbboxCategory";
            this.cbboxCategory.Size = new System.Drawing.Size(121, 23);
            this.cbboxCategory.TabIndex = 0;
            this.cbboxCategory.SelectedIndexChanged += new System.EventHandler(this.cbboxCategory_SelectedIndexChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCategory.Location = new System.Drawing.Point(295, 142);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(55, 15);
            this.labelCategory.TabIndex = 1;
            this.labelCategory.Text = "카테고리";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(6, 17);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(58, 15);
            this.labelMoney.TabIndex = 4;
            this.labelMoney.Text = "총 자산 : ";
            // 
            // labelNickname
            // 
            this.labelNickname.AutoSize = true;
            this.labelNickname.Location = new System.Drawing.Point(6, 17);
            this.labelNickname.Name = "labelNickname";
            this.labelNickname.Size = new System.Drawing.Size(49, 15);
            this.labelNickname.TabIndex = 13;
            this.labelNickname.Text = "닉네임: ";
            // 
            // labelInAuction
            // 
            this.labelInAuction.AutoSize = true;
            this.labelInAuction.Location = new System.Drawing.Point(6, 53);
            this.labelInAuction.Name = "labelInAuction";
            this.labelInAuction.Size = new System.Drawing.Size(64, 15);
            this.labelInAuction.TabIndex = 14;
            this.labelInAuction.Text = "입찰 횟수: ";
            // 
            // labelSuccessAuction
            // 
            this.labelSuccessAuction.AutoSize = true;
            this.labelSuccessAuction.Location = new System.Drawing.Point(6, 72);
            this.labelSuccessAuction.Name = "labelSuccessAuction";
            this.labelSuccessAuction.Size = new System.Drawing.Size(64, 15);
            this.labelSuccessAuction.TabIndex = 15;
            this.labelSuccessAuction.Text = "낙찰 횟수: ";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(9, 20);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(104, 25);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "정보 수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(6, 36);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(49, 15);
            this.labelId.TabIndex = 19;
            this.labelId.Text = "아이디: ";
            // 
            // labelAuctionMoney
            // 
            this.labelAuctionMoney.AutoSize = true;
            this.labelAuctionMoney.Location = new System.Drawing.Point(6, 59);
            this.labelAuctionMoney.Name = "labelAuctionMoney";
            this.labelAuctionMoney.Size = new System.Drawing.Size(73, 15);
            this.labelAuctionMoney.TabIndex = 20;
            this.labelAuctionMoney.Text = "입찰중 금액:";
            // 
            // labelAvaAuctionMoney
            // 
            this.labelAvaAuctionMoney.AutoSize = true;
            this.labelAvaAuctionMoney.Location = new System.Drawing.Point(6, 100);
            this.labelAvaAuctionMoney.Name = "labelAvaAuctionMoney";
            this.labelAvaAuctionMoney.Size = new System.Drawing.Size(88, 15);
            this.labelAvaAuctionMoney.TabIndex = 22;
            this.labelAvaAuctionMoney.Text = "입찰 가능 금액:";
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(9, 111);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(104, 25);
            this.btnAccount.TabIndex = 7;
            this.btnAccount.Text = "계좌";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnNewAuction
            // 
            this.btnNewAuction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNewAuction.Location = new System.Drawing.Point(978, 135);
            this.btnNewAuction.Name = "btnNewAuction";
            this.btnNewAuction.Size = new System.Drawing.Size(75, 23);
            this.btnNewAuction.TabIndex = 3;
            this.btnNewAuction.Text = "경매 등록";
            this.btnNewAuction.UseVisualStyleBackColor = true;
            this.btnNewAuction.Click += new System.EventHandler(this.btnNewAuction_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(9, 142);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(104, 25);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "종료";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnCheckAuction
            // 
            this.btnCheckAuction.Location = new System.Drawing.Point(9, 80);
            this.btnCheckAuction.Name = "btnCheckAuction";
            this.btnCheckAuction.Size = new System.Drawing.Size(104, 25);
            this.btnCheckAuction.TabIndex = 6;
            this.btnCheckAuction.Text = "경매 입찰 확인";
            this.btnCheckAuction.UseVisualStyleBackColor = true;
            this.btnCheckAuction.Click += new System.EventHandler(this.btnCheckAuction_Click);
            // 
            // gouprbxUserFunction
            // 
            this.gouprbxUserFunction.Controls.Add(this.btnMyAuction);
            this.gouprbxUserFunction.Controls.Add(this.btnModify);
            this.gouprbxUserFunction.Controls.Add(this.btnCheckAuction);
            this.gouprbxUserFunction.Controls.Add(this.btnAccount);
            this.gouprbxUserFunction.Controls.Add(this.btnLogOut);
            this.gouprbxUserFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gouprbxUserFunction.Location = new System.Drawing.Point(15, 379);
            this.gouprbxUserFunction.Name = "gouprbxUserFunction";
            this.gouprbxUserFunction.Size = new System.Drawing.Size(124, 178);
            this.gouprbxUserFunction.TabIndex = 38;
            this.gouprbxUserFunction.TabStop = false;
            this.gouprbxUserFunction.Text = "사용자 기능";
            // 
            // btnMyAuction
            // 
            this.btnMyAuction.Location = new System.Drawing.Point(9, 51);
            this.btnMyAuction.Name = "btnMyAuction";
            this.btnMyAuction.Size = new System.Drawing.Size(104, 23);
            this.btnMyAuction.TabIndex = 5;
            this.btnMyAuction.Text = "내 경매글 관리";
            this.btnMyAuction.UseVisualStyleBackColor = true;
            this.btnMyAuction.Click += new System.EventHandler(this.btnMyAuction_Click);
            // 
            // groupbxUserInformation
            // 
            this.groupbxUserInformation.Controls.Add(this.labelNickname);
            this.groupbxUserInformation.Controls.Add(this.labelId);
            this.groupbxUserInformation.Controls.Add(this.labelInAuction);
            this.groupbxUserInformation.Controls.Add(this.labelSuccessAuction);
            this.groupbxUserInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupbxUserInformation.Location = new System.Drawing.Point(16, 279);
            this.groupbxUserInformation.Name = "groupbxUserInformation";
            this.groupbxUserInformation.Size = new System.Drawing.Size(123, 94);
            this.groupbxUserInformation.TabIndex = 30;
            this.groupbxUserInformation.TabStop = false;
            this.groupbxUserInformation.Text = "사용자 정보";
            // 
            // groupbxCash
            // 
            this.groupbxCash.Controls.Add(this.labelLeftMoney);
            this.groupbxCash.Controls.Add(this.labelAuctioningMoney);
            this.groupbxCash.Controls.Add(this.labelTotalMoeny);
            this.groupbxCash.Controls.Add(this.labelMoney);
            this.groupbxCash.Controls.Add(this.labelAuctionMoney);
            this.groupbxCash.Controls.Add(this.labelAvaAuctionMoney);
            this.groupbxCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupbxCash.Location = new System.Drawing.Point(143, 140);
            this.groupbxCash.Name = "groupbxCash";
            this.groupbxCash.Size = new System.Drawing.Size(140, 133);
            this.groupbxCash.TabIndex = 39;
            this.groupbxCash.TabStop = false;
            this.groupbxCash.Text = "자산";
            // 
            // labelLeftMoney
            // 
            this.labelLeftMoney.AutoSize = true;
            this.labelLeftMoney.Location = new System.Drawing.Point(6, 116);
            this.labelLeftMoney.Name = "labelLeftMoney";
            this.labelLeftMoney.Size = new System.Drawing.Size(0, 15);
            this.labelLeftMoney.TabIndex = 23;
            // 
            // labelAuctioningMoney
            // 
            this.labelAuctioningMoney.AutoSize = true;
            this.labelAuctioningMoney.Location = new System.Drawing.Point(6, 76);
            this.labelAuctioningMoney.Name = "labelAuctioningMoney";
            this.labelAuctioningMoney.Size = new System.Drawing.Size(0, 15);
            this.labelAuctioningMoney.TabIndex = 23;
            // 
            // labelTotalMoeny
            // 
            this.labelTotalMoeny.AutoSize = true;
            this.labelTotalMoeny.Location = new System.Drawing.Point(6, 30);
            this.labelTotalMoeny.Name = "labelTotalMoeny";
            this.labelTotalMoeny.Size = new System.Drawing.Size(0, 15);
            this.labelTotalMoeny.TabIndex = 23;
            // 
            // btnModifyCategory
            // 
            this.btnModifyCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModifyCategory.Location = new System.Drawing.Point(475, 138);
            this.btnModifyCategory.Name = "btnModifyCategory";
            this.btnModifyCategory.Size = new System.Drawing.Size(42, 20);
            this.btnModifyCategory.TabIndex = 1;
            this.btnModifyCategory.Text = "수정";
            this.btnModifyCategory.UseVisualStyleBackColor = true;
            this.btnModifyCategory.Visible = false;
            this.btnModifyCategory.Click += new System.EventHandler(this.btnModifyCategory_Click);
            // 
            // flowLayoutPanelHome
            // 
            this.flowLayoutPanelHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelHome.AutoSize = true;
            this.flowLayoutPanelHome.Controls.Add(this.labelIsObj);
            this.flowLayoutPanelHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flowLayoutPanelHome.Location = new System.Drawing.Point(291, 170);
            this.flowLayoutPanelHome.Name = "flowLayoutPanelHome";
            this.flowLayoutPanelHome.Size = new System.Drawing.Size(803, 571);
            this.flowLayoutPanelHome.TabIndex = 41;
            // 
            // labelIsObj
            // 
            this.labelIsObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelIsObj.Location = new System.Drawing.Point(3, 0);
            this.labelIsObj.Name = "labelIsObj";
            this.labelIsObj.Size = new System.Drawing.Size(797, 571);
            this.labelIsObj.TabIndex = 42;
            this.labelIsObj.Text = "매물이 존재하지 않습니다.";
            this.labelIsObj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIsObj.Visible = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImage = global::deal_Program.Properties.Resources.로고;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxLogo.Location = new System.Drawing.Point(16, 13);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(1037, 117);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 28;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::deal_Program.Properties.Resources.unknown;
            this.pictureBoxProfile.Location = new System.Drawing.Point(16, 138);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(121, 135);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 3;
            this.pictureBoxProfile.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(897, 135);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 15000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // formUShome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1132, 753);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.flowLayoutPanelHome);
            this.Controls.Add(this.btnModifyCategory);
            this.Controls.Add(this.groupbxCash);
            this.Controls.Add(this.groupbxUserInformation);
            this.Controls.Add(this.gouprbxUserFunction);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnNewAuction);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.cbboxCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formUShome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [홈]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formUShome_FormClosing);
            this.Load += new System.EventHandler(this.formUShome_Load);
            this.gouprbxUserFunction.ResumeLayout(false);
            this.groupbxUserInformation.ResumeLayout(false);
            this.groupbxUserInformation.PerformLayout();
            this.groupbxCash.ResumeLayout(false);
            this.groupbxCash.PerformLayout();
            this.flowLayoutPanelHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbboxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Label labelNickname;
        private System.Windows.Forms.Label labelInAuction;
        private System.Windows.Forms.Label labelSuccessAuction;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelAuctionMoney;
        private System.Windows.Forms.Label labelAvaAuctionMoney;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnNewAuction;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnCheckAuction;
        private System.Windows.Forms.GroupBox gouprbxUserFunction;
        private System.Windows.Forms.GroupBox groupbxUserInformation;
        private System.Windows.Forms.GroupBox groupbxCash;
        private System.Windows.Forms.Label labelLeftMoney;
        private System.Windows.Forms.Label labelAuctioningMoney;
        private System.Windows.Forms.Label labelTotalMoeny;
        private System.Windows.Forms.Button btnModifyCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHome;
        private System.Windows.Forms.Label labelIsObj;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMyAuction;
        public System.Windows.Forms.Timer timerRefresh;
    }
}