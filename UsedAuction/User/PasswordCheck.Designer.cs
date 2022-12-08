namespace deal_Program
{
    partial class formPasswordCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPasswordCheck));
            this.labelFindpw = new System.Windows.Forms.Label();
            this.txtbxPW = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFindpw
            // 
            this.labelFindpw.AutoSize = true;
            this.labelFindpw.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelFindpw.Location = new System.Drawing.Point(9, 9);
            this.labelFindpw.Name = "labelFindpw";
            this.labelFindpw.Size = new System.Drawing.Size(120, 13);
            this.labelFindpw.TabIndex = 0;
            this.labelFindpw.Text = "비밀번호를 입력하세요";
            // 
            // txtbxPW
            // 
            this.txtbxPW.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtbxPW.Location = new System.Drawing.Point(12, 27);
            this.txtbxPW.MaxLength = 16;
            this.txtbxPW.Name = "txtbxPW";
            this.txtbxPW.PasswordChar = '●';
            this.txtbxPW.Size = new System.Drawing.Size(212, 21);
            this.txtbxPW.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(17, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("ONE 모바일고딕 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCheck.Location = new System.Drawing.Point(137, 54);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "확인";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // formPasswordCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 86);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtbxPW);
            this.Controls.Add(this.labelFindpw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formPasswordCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비밀번호 확인";
            this.Load += new System.EventHandler(this.formPasswordCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFindpw;
        private System.Windows.Forms.TextBox txtbxPW;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheck;
    }
}