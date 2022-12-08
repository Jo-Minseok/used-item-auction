namespace deal_Program
{
    partial class formAuctioning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAuctioning));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listViewAuction = new System.Windows.Forms.ListView();
            this.columnEndAuction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHighestPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStartPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUploader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBuyPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radiobtnIng = new System.Windows.Forms.RadioButton();
            this.radiobtnFinal = new System.Windows.Forms.RadioButton();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(632, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(713, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "나가기";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listViewAuction
            // 
            this.listViewAuction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEndAuction,
            this.columnName,
            this.columnCategory,
            this.columnHighestPrice,
            this.columnStartPrice,
            this.columnUploader,
            this.columnBuyPrice});
            this.listViewAuction.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listViewAuction.GridLines = true;
            this.listViewAuction.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAuction.HideSelection = false;
            this.listViewAuction.Location = new System.Drawing.Point(12, 49);
            this.listViewAuction.Name = "listViewAuction";
            this.listViewAuction.Size = new System.Drawing.Size(776, 389);
            this.listViewAuction.TabIndex = 2;
            this.listViewAuction.UseCompatibleStateImageBehavior = false;
            this.listViewAuction.View = System.Windows.Forms.View.Details;
            // 
            // columnEndAuction
            // 
            this.columnEndAuction.Text = "마감일";
            this.columnEndAuction.Width = 155;
            // 
            // columnName
            // 
            this.columnName.Text = "이름";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.Width = 100;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "카테고리";
            this.columnCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCategory.Width = 80;
            // 
            // columnHighestPrice
            // 
            this.columnHighestPrice.Text = "입찰금액";
            this.columnHighestPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHighestPrice.Width = 120;
            // 
            // columnStartPrice
            // 
            this.columnStartPrice.Text = "시작금액";
            this.columnStartPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStartPrice.Width = 120;
            // 
            // columnUploader
            // 
            this.columnUploader.Text = "글쓴이";
            this.columnUploader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUploader.Width = 80;
            // 
            // columnBuyPrice
            // 
            this.columnBuyPrice.Text = "구매당시 가격";
            this.columnBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnBuyPrice.Width = 120;
            // 
            // radiobtnIng
            // 
            this.radiobtnIng.AutoSize = true;
            this.radiobtnIng.Checked = true;
            this.radiobtnIng.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radiobtnIng.Location = new System.Drawing.Point(12, 27);
            this.radiobtnIng.Name = "radiobtnIng";
            this.radiobtnIng.Size = new System.Drawing.Size(58, 17);
            this.radiobtnIng.TabIndex = 0;
            this.radiobtnIng.TabStop = true;
            this.radiobtnIng.Text = "입찰중";
            this.radiobtnIng.UseVisualStyleBackColor = true;
            this.radiobtnIng.CheckedChanged += new System.EventHandler(this.radiobtnIng_CheckedChanged);
            // 
            // radiobtnFinal
            // 
            this.radiobtnFinal.AutoSize = true;
            this.radiobtnFinal.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radiobtnFinal.Location = new System.Drawing.Point(77, 27);
            this.radiobtnFinal.Name = "radiobtnFinal";
            this.radiobtnFinal.Size = new System.Drawing.Size(72, 17);
            this.radiobtnFinal.TabIndex = 1;
            this.radiobtnFinal.Text = "경매 결과";
            this.radiobtnFinal.UseVisualStyleBackColor = true;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // formAuctioning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radiobtnFinal);
            this.Controls.Add(this.radiobtnIng);
            this.Controls.Add(this.listViewAuction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formAuctioning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "현황확인";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAuctioning_FormClosing);
            this.Load += new System.EventHandler(this.formAuctioning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listViewAuction;
        private System.Windows.Forms.ColumnHeader columnEndAuction;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.ColumnHeader columnHighestPrice;
        private System.Windows.Forms.ColumnHeader columnStartPrice;
        private System.Windows.Forms.ColumnHeader columnUploader;
        private System.Windows.Forms.ColumnHeader columnBuyPrice;
        private System.Windows.Forms.RadioButton radiobtnIng;
        private System.Windows.Forms.RadioButton radiobtnFinal;
        private System.Windows.Forms.Timer timerRefresh;
    }
}