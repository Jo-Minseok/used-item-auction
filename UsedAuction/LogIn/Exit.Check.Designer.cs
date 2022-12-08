namespace deal_Program
{
    partial class formExitCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formExitCheck));
            this.labelExit = new System.Windows.Forms.Label();
            this.btnExitYes = new System.Windows.Forms.Button();
            this.btnExitNo = new System.Windows.Forms.Button();
            this.timerExit = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelExit
            // 
            this.labelExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelExit.Location = new System.Drawing.Point(25, 35);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(215, 18);
            this.labelExit.TabIndex = 0;
            this.labelExit.Text = "프로그램을 종료하시겠습니까?";
            this.labelExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExitYes
            // 
            this.btnExitYes.AutoEllipsis = true;
            this.btnExitYes.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExitYes.Location = new System.Drawing.Point(42, 72);
            this.btnExitYes.Name = "btnExitYes";
            this.btnExitYes.Size = new System.Drawing.Size(75, 23);
            this.btnExitYes.TabIndex = 1;
            this.btnExitYes.Text = "예(10)";
            this.btnExitYes.UseVisualStyleBackColor = true;
            this.btnExitYes.Click += new System.EventHandler(this.btnExitYes_Click);
            // 
            // btnExitNo
            // 
            this.btnExitNo.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExitNo.Location = new System.Drawing.Point(140, 72);
            this.btnExitNo.Name = "btnExitNo";
            this.btnExitNo.Size = new System.Drawing.Size(75, 23);
            this.btnExitNo.TabIndex = 2;
            this.btnExitNo.Text = "아니요";
            this.btnExitNo.UseVisualStyleBackColor = true;
            this.btnExitNo.Click += new System.EventHandler(this.btnExitNo_Click);
            // 
            // timerExit
            // 
            this.timerExit.Interval = 1000;
            // 
            // formExitCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 107);
            this.Controls.Add(this.btnExitNo);
            this.Controls.Add(this.btnExitYes);
            this.Controls.Add(this.labelExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formExitCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "종료";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formExitCheck_FormClosing);
            this.Load += new System.EventHandler(this.formExitCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Button btnExitYes;
        private System.Windows.Forms.Button btnExitNo;
        private System.Windows.Forms.Timer timerExit;
    }
}