namespace deal_Program
{
    partial class formDBCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDBCheck));
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridDB = new System.Windows.Forms.DataGridView();
            this.cbboxMenu = new System.Windows.Forms.ComboBox();
            this.labelMenu = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDB)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(1058, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "나가기";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dataGridDB
            // 
            this.dataGridDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridDB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridDB.Location = new System.Drawing.Point(0, 31);
            this.dataGridDB.Name = "dataGridDB";
            this.dataGridDB.ReadOnly = true;
            this.dataGridDB.RowHeadersWidth = 20;
            this.dataGridDB.RowTemplate.Height = 23;
            this.dataGridDB.Size = new System.Drawing.Size(1145, 500);
            this.dataGridDB.TabIndex = 2;
            this.dataGridDB.TabStop = false;
            // 
            // cbboxMenu
            // 
            this.cbboxMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxMenu.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbboxMenu.FormattingEnabled = true;
            this.cbboxMenu.Items.AddRange(new object[] {
            "카테고리",
            "관리자 계정",
            "경매물건",
            "유저 계정"});
            this.cbboxMenu.Location = new System.Drawing.Point(67, 6);
            this.cbboxMenu.Name = "cbboxMenu";
            this.cbboxMenu.Size = new System.Drawing.Size(121, 21);
            this.cbboxMenu.TabIndex = 1;
            this.cbboxMenu.SelectedValueChanged += new System.EventHandler(this.cbboxMenu_SelectedValueChanged);
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMenu.Location = new System.Drawing.Point(12, 9);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(49, 13);
            this.labelMenu.TabIndex = 3;
            this.labelMenu.Text = "DB 선택";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(977, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // formDBCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1145, 531);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.labelMenu);
            this.Controls.Add(this.cbboxMenu);
            this.Controls.Add(this.dataGridDB);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.Name = "formDBCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [데이터 베이스]";
            this.Load += new System.EventHandler(this.formDBCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dataGridDB;
        private System.Windows.Forms.ComboBox cbboxMenu;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Button btnRefresh;
    }
}