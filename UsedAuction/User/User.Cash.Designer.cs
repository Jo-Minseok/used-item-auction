namespace deal_Program
{
    partial class formUScash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formUScash));
            this.labelLeftMoney = new System.Windows.Forms.Label();
            this.txtboxAvaMoney = new System.Windows.Forms.TextBox();
            this.btnInCash = new System.Windows.Forms.Button();
            this.btnOutCash = new System.Windows.Forms.Button();
            this.labelAuctionMoney = new System.Windows.Forms.Label();
            this.labelTotalMoney = new System.Windows.Forms.Label();
            this.txtboxAuctionMoney = new System.Windows.Forms.TextBox();
            this.txtboxTotalMoney = new System.Windows.Forms.TextBox();
            this.labelMoney = new System.Windows.Forms.Label();
            this.txtboxCharge = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelBank = new System.Windows.Forms.Label();
            this.cbboxBank = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelLeftMoney
            // 
            this.labelLeftMoney.AutoSize = true;
            this.labelLeftMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelLeftMoney.Location = new System.Drawing.Point(75, 87);
            this.labelLeftMoney.Name = "labelLeftMoney";
            this.labelLeftMoney.Size = new System.Drawing.Size(79, 13);
            this.labelLeftMoney.TabIndex = 0;
            this.labelLeftMoney.Text = "입찰 가능 금액";
            // 
            // txtboxAvaMoney
            // 
            this.txtboxAvaMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxAvaMoney.Location = new System.Drawing.Point(166, 84);
            this.txtboxAvaMoney.Name = "txtboxAvaMoney";
            this.txtboxAvaMoney.ReadOnly = true;
            this.txtboxAvaMoney.Size = new System.Drawing.Size(234, 21);
            this.txtboxAvaMoney.TabIndex = 1;
            this.txtboxAvaMoney.TabStop = false;
            this.txtboxAvaMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxAvaMoney.TextChanged += new System.EventHandler(this.txtboxAvaMoney_TextChanged);
            // 
            // btnInCash
            // 
            this.btnInCash.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInCash.Location = new System.Drawing.Point(19, 173);
            this.btnInCash.Name = "btnInCash";
            this.btnInCash.Size = new System.Drawing.Size(141, 32);
            this.btnInCash.TabIndex = 3;
            this.btnInCash.Text = "입금";
            this.btnInCash.UseVisualStyleBackColor = true;
            this.btnInCash.Click += new System.EventHandler(this.btnInCash_Click);
            // 
            // btnOutCash
            // 
            this.btnOutCash.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOutCash.Location = new System.Drawing.Point(166, 173);
            this.btnOutCash.Name = "btnOutCash";
            this.btnOutCash.Size = new System.Drawing.Size(141, 32);
            this.btnOutCash.TabIndex = 4;
            this.btnOutCash.Text = "출금";
            this.btnOutCash.UseVisualStyleBackColor = true;
            this.btnOutCash.Click += new System.EventHandler(this.btnOutCash_Click);
            // 
            // labelAuctionMoney
            // 
            this.labelAuctionMoney.AutoSize = true;
            this.labelAuctionMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAuctionMoney.Location = new System.Drawing.Point(91, 60);
            this.labelAuctionMoney.Name = "labelAuctionMoney";
            this.labelAuctionMoney.Size = new System.Drawing.Size(65, 13);
            this.labelAuctionMoney.TabIndex = 4;
            this.labelAuctionMoney.Text = "입찰중 금액";
            // 
            // labelTotalMoney
            // 
            this.labelTotalMoney.AutoSize = true;
            this.labelTotalMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTotalMoney.Location = new System.Drawing.Point(115, 33);
            this.labelTotalMoney.Name = "labelTotalMoney";
            this.labelTotalMoney.Size = new System.Drawing.Size(43, 13);
            this.labelTotalMoney.TabIndex = 5;
            this.labelTotalMoney.Text = "총 금액";
            // 
            // txtboxAuctionMoney
            // 
            this.txtboxAuctionMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxAuctionMoney.Location = new System.Drawing.Point(166, 57);
            this.txtboxAuctionMoney.Name = "txtboxAuctionMoney";
            this.txtboxAuctionMoney.ReadOnly = true;
            this.txtboxAuctionMoney.Size = new System.Drawing.Size(234, 21);
            this.txtboxAuctionMoney.TabIndex = 6;
            this.txtboxAuctionMoney.TabStop = false;
            this.txtboxAuctionMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxAuctionMoney.TextChanged += new System.EventHandler(this.txtboxAuctionMoney_TextChanged);
            // 
            // txtboxTotalMoney
            // 
            this.txtboxTotalMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxTotalMoney.Location = new System.Drawing.Point(166, 30);
            this.txtboxTotalMoney.Name = "txtboxTotalMoney";
            this.txtboxTotalMoney.ReadOnly = true;
            this.txtboxTotalMoney.Size = new System.Drawing.Size(234, 21);
            this.txtboxTotalMoney.TabIndex = 7;
            this.txtboxTotalMoney.TabStop = false;
            this.txtboxTotalMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxTotalMoney.TextChanged += new System.EventHandler(this.txtboxTotalMoney_TextChanged);
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMoney.Location = new System.Drawing.Point(131, 141);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(29, 13);
            this.labelMoney.TabIndex = 8;
            this.labelMoney.Text = "금액";
            // 
            // txtboxCharge
            // 
            this.txtboxCharge.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtboxCharge.Location = new System.Drawing.Point(166, 138);
            this.txtboxCharge.MaxLength = 15;
            this.txtboxCharge.Name = "txtboxCharge";
            this.txtboxCharge.Size = new System.Drawing.Size(234, 21);
            this.txtboxCharge.TabIndex = 2;
            this.txtboxCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxCharge.TextChanged += new System.EventHandler(this.txtboxCharge_TextChanged);
            this.txtboxCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtboxCharge_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(313, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "나가기";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelBank.Location = new System.Drawing.Point(103, 114);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(54, 13);
            this.labelBank.TabIndex = 11;
            this.labelBank.Text = "은행 선택";
            // 
            // cbboxBank
            // 
            this.cbboxBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbboxBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbboxBank.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxBank.FormattingEnabled = true;
            this.cbboxBank.Items.AddRange(new object[] {
            "KB국민은행",
            "우리은행",
            "신한은행",
            "하나은행",
            "SC제일은행",
            "씨티은행",
            "경남은행",
            "부산은행",
            "대구은행",
            "광주은행",
            "전북은행",
            "제주은행",
            "카카오뱅크",
            "K뱅크"});
            this.cbboxBank.Location = new System.Drawing.Point(166, 111);
            this.cbboxBank.Name = "cbboxBank";
            this.cbboxBank.Size = new System.Drawing.Size(121, 21);
            this.cbboxBank.TabIndex = 1;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // formUScash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 218);
            this.Controls.Add(this.cbboxBank);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtboxCharge);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.txtboxTotalMoney);
            this.Controls.Add(this.txtboxAuctionMoney);
            this.Controls.Add(this.labelTotalMoney);
            this.Controls.Add(this.labelAuctionMoney);
            this.Controls.Add(this.btnOutCash);
            this.Controls.Add(this.btnInCash);
            this.Controls.Add(this.txtboxAvaMoney);
            this.Controls.Add(this.labelLeftMoney);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formUScash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [계좌]";
            this.Load += new System.EventHandler(this.formUScash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLeftMoney;
        private System.Windows.Forms.TextBox txtboxAvaMoney;
        private System.Windows.Forms.Button btnInCash;
        private System.Windows.Forms.Button btnOutCash;
        private System.Windows.Forms.Label labelAuctionMoney;
        private System.Windows.Forms.Label labelTotalMoney;
        private System.Windows.Forms.TextBox txtboxAuctionMoney;
        private System.Windows.Forms.TextBox txtboxTotalMoney;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.TextBox txtboxCharge;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.ComboBox cbboxBank;
        private System.Windows.Forms.Timer timerRefresh;
    }
}