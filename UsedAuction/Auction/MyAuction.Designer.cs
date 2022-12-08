namespace deal_Program
{
    partial class formMyAuction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMyAuction));
            this.btnCancel = new System.Windows.Forms.Button();
            this.listViewMyAuction = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStartPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHighestPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHighestUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUserPh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEndAuction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelAuctioning = new System.Windows.Forms.Label();
            this.labelEndAuction = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(899, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "나가기";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listViewMyAuction
            // 
            this.listViewMyAuction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnStartPrice,
            this.columnHighestPrice,
            this.columnHighestUser,
            this.columnUserAddress,
            this.columnUserPh,
            this.columnEndAuction});
            this.listViewMyAuction.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listViewMyAuction.GridLines = true;
            this.listViewMyAuction.HideSelection = false;
            this.listViewMyAuction.Location = new System.Drawing.Point(14, 41);
            this.listViewMyAuction.Name = "listViewMyAuction";
            this.listViewMyAuction.Size = new System.Drawing.Size(960, 397);
            this.listViewMyAuction.TabIndex = 0;
            this.listViewMyAuction.UseCompatibleStateImageBehavior = false;
            this.listViewMyAuction.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "제품명";
            this.columnName.Width = 180;
            // 
            // columnStartPrice
            // 
            this.columnStartPrice.Text = "시작 가격";
            this.columnStartPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStartPrice.Width = 100;
            // 
            // columnHighestPrice
            // 
            this.columnHighestPrice.Text = "최고가";
            this.columnHighestPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHighestPrice.Width = 105;
            // 
            // columnHighestUser
            // 
            this.columnHighestUser.Text = "입찰자";
            this.columnHighestUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHighestUser.Width = 100;
            // 
            // columnUserAddress
            // 
            this.columnUserAddress.Text = "입찰자 주소";
            this.columnUserAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserAddress.Width = 190;
            // 
            // columnUserPh
            // 
            this.columnUserPh.Text = "입찰자 전화번호";
            this.columnUserPh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUserPh.Width = 130;
            // 
            // columnEndAuction
            // 
            this.columnEndAuction.Text = "경매 마감일";
            this.columnEndAuction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnEndAuction.Width = 150;
            // 
            // labelAuctioning
            // 
            this.labelAuctioning.AutoSize = true;
            this.labelAuctioning.BackColor = System.Drawing.SystemColors.Control;
            this.labelAuctioning.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAuctioning.ForeColor = System.Drawing.Color.Green;
            this.labelAuctioning.Location = new System.Drawing.Point(12, 25);
            this.labelAuctioning.Name = "labelAuctioning";
            this.labelAuctioning.Size = new System.Drawing.Size(122, 13);
            this.labelAuctioning.TabIndex = 2;
            this.labelAuctioning.Text = "■ : 현재 진행중인 경매";
            // 
            // labelEndAuction
            // 
            this.labelEndAuction.AutoSize = true;
            this.labelEndAuction.BackColor = System.Drawing.SystemColors.Control;
            this.labelEndAuction.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelEndAuction.Location = new System.Drawing.Point(185, 25);
            this.labelEndAuction.Name = "labelEndAuction";
            this.labelEndAuction.Size = new System.Drawing.Size(86, 13);
            this.labelEndAuction.TabIndex = 3;
            this.labelEndAuction.Text = "■ : 종료된 경매";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(818, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // formMyAuction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.labelEndAuction);
            this.Controls.Add(this.labelAuctioning);
            this.Controls.Add(this.listViewMyAuction);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMyAuction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [내 경매 관리]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMyAuction_FormClosing);
            this.Load += new System.EventHandler(this.formMyAuction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listViewMyAuction;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnStartPrice;
        private System.Windows.Forms.ColumnHeader columnHighestPrice;
        private System.Windows.Forms.ColumnHeader columnHighestUser;
        private System.Windows.Forms.ColumnHeader columnUserAddress;
        private System.Windows.Forms.ColumnHeader columnUserPh;
        private System.Windows.Forms.ColumnHeader columnEndAuction;
        private System.Windows.Forms.Label labelAuctioning;
        private System.Windows.Forms.Label labelEndAuction;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btnRefresh;
    }
}