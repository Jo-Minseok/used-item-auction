namespace deal_Program
{
    partial class formUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formUpload));
            this.btnUploadobj = new System.Windows.Forms.Button();
            this.cbboxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.txtboxObjname = new System.Windows.Forms.TextBox();
            this.txtboxStartmoney = new System.Windows.Forms.TextBox();
            this.txtboxBuyprice = new System.Windows.Forms.TextBox();
            this.labelObjname = new System.Windows.Forms.Label();
            this.labelStartmoney = new System.Windows.Forms.Label();
            this.labelBuyprice = new System.Windows.Forms.Label();
            this.labelBuydate = new System.Windows.Forms.Label();
            this.txtboxExplanation = new System.Windows.Forms.TextBox();
            this.labelExplanation = new System.Windows.Forms.Label();
            this.btnUploadProfile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openMainImage = new System.Windows.Forms.OpenFileDialog();
            this.labelSubImage = new System.Windows.Forms.Label();
            this.flowLayoutPanelSub = new System.Windows.Forms.FlowLayoutPanel();
            this.groupboxSub1 = new System.Windows.Forms.GroupBox();
            this.btnUploadSub1 = new System.Windows.Forms.Button();
            this.btnSubImage1 = new System.Windows.Forms.Button();
            this.btnSubImg1Delete = new System.Windows.Forms.Button();
            this.groupboxSub2 = new System.Windows.Forms.GroupBox();
            this.btnUploadSub2 = new System.Windows.Forms.Button();
            this.btnSubImage2 = new System.Windows.Forms.Button();
            this.btnSubImg2Delete = new System.Windows.Forms.Button();
            this.groupboxSub3 = new System.Windows.Forms.GroupBox();
            this.btnUploadSub3 = new System.Windows.Forms.Button();
            this.btnSubImage3 = new System.Windows.Forms.Button();
            this.btnSubImg3Delete = new System.Windows.Forms.Button();
            this.openSubImage1 = new System.Windows.Forms.OpenFileDialog();
            this.dateTimeBuy = new System.Windows.Forms.DateTimePicker();
            this.groupboxInforObj = new System.Windows.Forms.GroupBox();
            this.labelMaxString = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEndAuctionL = new System.Windows.Forms.Label();
            this.openSubImage2 = new System.Windows.Forms.OpenFileDialog();
            this.openSubImage3 = new System.Windows.Forms.OpenFileDialog();
            this.pictureboxProfile = new System.Windows.Forms.PictureBox();
            this.btnMainRemove = new System.Windows.Forms.Button();
            this.flowLayoutPanelSub.SuspendLayout();
            this.groupboxSub1.SuspendLayout();
            this.groupboxSub2.SuspendLayout();
            this.groupboxSub3.SuspendLayout();
            this.groupboxInforObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUploadobj
            // 
            this.btnUploadobj.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUploadobj.Location = new System.Drawing.Point(868, 12);
            this.btnUploadobj.Name = "btnUploadobj";
            this.btnUploadobj.Size = new System.Drawing.Size(75, 23);
            this.btnUploadobj.TabIndex = 4;
            this.btnUploadobj.Text = "경매 등록";
            this.btnUploadobj.UseVisualStyleBackColor = true;
            this.btnUploadobj.Click += new System.EventHandler(this.btnUploadobj_Click);
            // 
            // cbboxCategory
            // 
            this.cbboxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbboxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbboxCategory.FormattingEnabled = true;
            this.cbboxCategory.Location = new System.Drawing.Point(101, 29);
            this.cbboxCategory.Name = "cbboxCategory";
            this.cbboxCategory.Size = new System.Drawing.Size(121, 21);
            this.cbboxCategory.TabIndex = 0;
            this.cbboxCategory.SelectedIndexChanged += new System.EventHandler(this.cbboxCategory_SelectedIndexChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(42, 32);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(51, 13);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "카테고리";
            // 
            // txtboxObjname
            // 
            this.txtboxObjname.Location = new System.Drawing.Point(101, 55);
            this.txtboxObjname.MaxLength = 24;
            this.txtboxObjname.Name = "txtboxObjname";
            this.txtboxObjname.Size = new System.Drawing.Size(280, 21);
            this.txtboxObjname.TabIndex = 1;
            this.txtboxObjname.TextChanged += new System.EventHandler(this.txtboxObjname_TextChanged);
            // 
            // txtboxStartmoney
            // 
            this.txtboxStartmoney.Location = new System.Drawing.Point(101, 82);
            this.txtboxStartmoney.MaxLength = 13;
            this.txtboxStartmoney.Name = "txtboxStartmoney";
            this.txtboxStartmoney.Size = new System.Drawing.Size(280, 21);
            this.txtboxStartmoney.TabIndex = 2;
            this.txtboxStartmoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxStartmoney.TextChanged += new System.EventHandler(this.txtboxStartmoney_TextChanged);
            this.txtboxStartmoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtboxStartmoney_KeyPress);
            // 
            // txtboxBuyprice
            // 
            this.txtboxBuyprice.Location = new System.Drawing.Point(101, 112);
            this.txtboxBuyprice.MaxLength = 13;
            this.txtboxBuyprice.Name = "txtboxBuyprice";
            this.txtboxBuyprice.Size = new System.Drawing.Size(280, 21);
            this.txtboxBuyprice.TabIndex = 3;
            this.txtboxBuyprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtboxBuyprice.TextChanged += new System.EventHandler(this.txtboxBuyprice_TextChanged);
            this.txtboxBuyprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtboxBuyprice_KeyPress);
            // 
            // labelObjname
            // 
            this.labelObjname.AutoSize = true;
            this.labelObjname.Location = new System.Drawing.Point(54, 58);
            this.labelObjname.Name = "labelObjname";
            this.labelObjname.Size = new System.Drawing.Size(40, 13);
            this.labelObjname.TabIndex = 9;
            this.labelObjname.Text = "제품명";
            // 
            // labelStartmoney
            // 
            this.labelStartmoney.AutoSize = true;
            this.labelStartmoney.Location = new System.Drawing.Point(10, 85);
            this.labelStartmoney.Name = "labelStartmoney";
            this.labelStartmoney.Size = new System.Drawing.Size(79, 13);
            this.labelStartmoney.TabIndex = 10;
            this.labelStartmoney.Text = "경매 시작 가격";
            // 
            // labelBuyprice
            // 
            this.labelBuyprice.AutoSize = true;
            this.labelBuyprice.Location = new System.Drawing.Point(10, 115);
            this.labelBuyprice.Name = "labelBuyprice";
            this.labelBuyprice.Size = new System.Drawing.Size(79, 13);
            this.labelBuyprice.TabIndex = 11;
            this.labelBuyprice.Text = "구매 당시 가격";
            // 
            // labelBuydate
            // 
            this.labelBuydate.AutoSize = true;
            this.labelBuydate.Location = new System.Drawing.Point(401, 115);
            this.labelBuydate.Name = "labelBuydate";
            this.labelBuydate.Size = new System.Drawing.Size(54, 13);
            this.labelBuydate.TabIndex = 12;
            this.labelBuydate.Text = "구매 날짜";
            // 
            // txtboxExplanation
            // 
            this.txtboxExplanation.Location = new System.Drawing.Point(101, 166);
            this.txtboxExplanation.MaxLength = 1000;
            this.txtboxExplanation.Multiline = true;
            this.txtboxExplanation.Name = "txtboxExplanation";
            this.txtboxExplanation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxExplanation.Size = new System.Drawing.Size(674, 211);
            this.txtboxExplanation.TabIndex = 7;
            this.txtboxExplanation.TextChanged += new System.EventHandler(this.txtboxExplanation_TextChanged);
            // 
            // labelExplanation
            // 
            this.labelExplanation.AutoSize = true;
            this.labelExplanation.Location = new System.Drawing.Point(66, 169);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(29, 13);
            this.labelExplanation.TabIndex = 14;
            this.labelExplanation.Text = "설명";
            // 
            // btnUploadProfile
            // 
            this.btnUploadProfile.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUploadProfile.Location = new System.Drawing.Point(9, 253);
            this.btnUploadProfile.Name = "btnUploadProfile";
            this.btnUploadProfile.Size = new System.Drawing.Size(100, 28);
            this.btnUploadProfile.TabIndex = 1;
            this.btnUploadProfile.Text = "업로드";
            this.btnUploadProfile.UseVisualStyleBackColor = true;
            this.btnUploadProfile.Click += new System.EventHandler(this.btnUploadProfile_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(949, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openMainImage
            // 
            this.openMainImage.Filter = "이미지 파일 (*.png, *.jpg)|*.png;*jpg|모든 파일(*.*)|*.*";
            this.openMainImage.InitialDirectory = "C:\\";
            // 
            // labelSubImage
            // 
            this.labelSubImage.AutoSize = true;
            this.labelSubImage.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSubImage.Location = new System.Drawing.Point(13, 452);
            this.labelSubImage.Name = "labelSubImage";
            this.labelSubImage.Size = new System.Drawing.Size(90, 13);
            this.labelSubImage.TabIndex = 18;
            this.labelSubImage.Text = "제품 상세 이미지";
            // 
            // flowLayoutPanelSub
            // 
            this.flowLayoutPanelSub.Controls.Add(this.groupboxSub1);
            this.flowLayoutPanelSub.Controls.Add(this.groupboxSub2);
            this.flowLayoutPanelSub.Controls.Add(this.groupboxSub3);
            this.flowLayoutPanelSub.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flowLayoutPanelSub.Location = new System.Drawing.Point(12, 467);
            this.flowLayoutPanelSub.Name = "flowLayoutPanelSub";
            this.flowLayoutPanelSub.Size = new System.Drawing.Size(1011, 360);
            this.flowLayoutPanelSub.TabIndex = 3;
            // 
            // groupboxSub1
            // 
            this.groupboxSub1.Controls.Add(this.btnUploadSub1);
            this.groupboxSub1.Controls.Add(this.btnSubImage1);
            this.groupboxSub1.Controls.Add(this.btnSubImg1Delete);
            this.groupboxSub1.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupboxSub1.Location = new System.Drawing.Point(3, 3);
            this.groupboxSub1.Name = "groupboxSub1";
            this.groupboxSub1.Size = new System.Drawing.Size(330, 354);
            this.groupboxSub1.TabIndex = 21;
            this.groupboxSub1.TabStop = false;
            // 
            // btnUploadSub1
            // 
            this.btnUploadSub1.Location = new System.Drawing.Point(6, 326);
            this.btnUploadSub1.Name = "btnUploadSub1";
            this.btnUploadSub1.Size = new System.Drawing.Size(157, 23);
            this.btnUploadSub1.TabIndex = 1;
            this.btnUploadSub1.Text = "업로드 1";
            this.btnUploadSub1.UseVisualStyleBackColor = true;
            this.btnUploadSub1.Click += new System.EventHandler(this.btnUploadSub1_Click);
            // 
            // btnSubImage1
            // 
            this.btnSubImage1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnSubImage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubImage1.BackgroundImage")));
            this.btnSubImage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubImage1.Location = new System.Drawing.Point(6, 10);
            this.btnSubImage1.Name = "btnSubImage1";
            this.btnSubImage1.Size = new System.Drawing.Size(317, 310);
            this.btnSubImage1.TabIndex = 0;
            this.btnSubImage1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSubImage1.UseVisualStyleBackColor = true;
            this.btnSubImage1.Click += new System.EventHandler(this.btnSubImage1_Click);
            // 
            // btnSubImg1Delete
            // 
            this.btnSubImg1Delete.Location = new System.Drawing.Point(166, 326);
            this.btnSubImg1Delete.Name = "btnSubImg1Delete";
            this.btnSubImg1Delete.Size = new System.Drawing.Size(157, 23);
            this.btnSubImg1Delete.TabIndex = 2;
            this.btnSubImg1Delete.Text = "삭제";
            this.btnSubImg1Delete.UseVisualStyleBackColor = true;
            this.btnSubImg1Delete.Click += new System.EventHandler(this.btnSubImg1Delete_Click);
            // 
            // groupboxSub2
            // 
            this.groupboxSub2.Controls.Add(this.btnUploadSub2);
            this.groupboxSub2.Controls.Add(this.btnSubImage2);
            this.groupboxSub2.Controls.Add(this.btnSubImg2Delete);
            this.groupboxSub2.Location = new System.Drawing.Point(339, 3);
            this.groupboxSub2.Name = "groupboxSub2";
            this.groupboxSub2.Size = new System.Drawing.Size(330, 354);
            this.groupboxSub2.TabIndex = 22;
            this.groupboxSub2.TabStop = false;
            this.groupboxSub2.Visible = false;
            // 
            // btnUploadSub2
            // 
            this.btnUploadSub2.Location = new System.Drawing.Point(6, 326);
            this.btnUploadSub2.Name = "btnUploadSub2";
            this.btnUploadSub2.Size = new System.Drawing.Size(157, 23);
            this.btnUploadSub2.TabIndex = 4;
            this.btnUploadSub2.Text = "업로드 2";
            this.btnUploadSub2.UseVisualStyleBackColor = true;
            this.btnUploadSub2.Click += new System.EventHandler(this.btnUploadSub2_Click);
            // 
            // btnSubImage2
            // 
            this.btnSubImage2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnSubImage2.BackgroundImage = global::deal_Program.Properties.Resources.plus;
            this.btnSubImage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubImage2.Location = new System.Drawing.Point(6, 10);
            this.btnSubImage2.Name = "btnSubImage2";
            this.btnSubImage2.Size = new System.Drawing.Size(317, 310);
            this.btnSubImage2.TabIndex = 3;
            this.btnSubImage2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSubImage2.UseVisualStyleBackColor = true;
            this.btnSubImage2.Click += new System.EventHandler(this.btnSubImage2_Click);
            // 
            // btnSubImg2Delete
            // 
            this.btnSubImg2Delete.Location = new System.Drawing.Point(166, 326);
            this.btnSubImg2Delete.Name = "btnSubImg2Delete";
            this.btnSubImg2Delete.Size = new System.Drawing.Size(157, 23);
            this.btnSubImg2Delete.TabIndex = 5;
            this.btnSubImg2Delete.Text = "삭제";
            this.btnSubImg2Delete.UseVisualStyleBackColor = true;
            this.btnSubImg2Delete.Click += new System.EventHandler(this.btnSubImg2Delete_Click);
            // 
            // groupboxSub3
            // 
            this.groupboxSub3.Controls.Add(this.btnUploadSub3);
            this.groupboxSub3.Controls.Add(this.btnSubImage3);
            this.groupboxSub3.Controls.Add(this.btnSubImg3Delete);
            this.groupboxSub3.Location = new System.Drawing.Point(675, 3);
            this.groupboxSub3.Name = "groupboxSub3";
            this.groupboxSub3.Size = new System.Drawing.Size(330, 354);
            this.groupboxSub3.TabIndex = 22;
            this.groupboxSub3.TabStop = false;
            this.groupboxSub3.Visible = false;
            // 
            // btnUploadSub3
            // 
            this.btnUploadSub3.Location = new System.Drawing.Point(6, 326);
            this.btnUploadSub3.Name = "btnUploadSub3";
            this.btnUploadSub3.Size = new System.Drawing.Size(157, 23);
            this.btnUploadSub3.TabIndex = 7;
            this.btnUploadSub3.Text = "업로드 3";
            this.btnUploadSub3.UseVisualStyleBackColor = true;
            this.btnUploadSub3.Click += new System.EventHandler(this.btnUploadSub3_Click);
            // 
            // btnSubImage3
            // 
            this.btnSubImage3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnSubImage3.BackgroundImage = global::deal_Program.Properties.Resources.plus;
            this.btnSubImage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubImage3.Location = new System.Drawing.Point(6, 10);
            this.btnSubImage3.Name = "btnSubImage3";
            this.btnSubImage3.Size = new System.Drawing.Size(317, 310);
            this.btnSubImage3.TabIndex = 6;
            this.btnSubImage3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSubImage3.UseVisualStyleBackColor = true;
            this.btnSubImage3.Click += new System.EventHandler(this.btnSubImage3_Click);
            // 
            // btnSubImg3Delete
            // 
            this.btnSubImg3Delete.Location = new System.Drawing.Point(166, 326);
            this.btnSubImg3Delete.Name = "btnSubImg3Delete";
            this.btnSubImg3Delete.Size = new System.Drawing.Size(157, 23);
            this.btnSubImg3Delete.TabIndex = 8;
            this.btnSubImg3Delete.Text = "삭제";
            this.btnSubImg3Delete.UseVisualStyleBackColor = true;
            this.btnSubImg3Delete.Click += new System.EventHandler(this.btnSubImg3Delete_Click);
            // 
            // openSubImage1
            // 
            this.openSubImage1.Filter = "이미지 파일 (*.png, *.jpg)|*.png;*jpg|모든 파일(*.*)|*.*";
            this.openSubImage1.InitialDirectory = "C:\\";
            // 
            // dateTimeBuy
            // 
            this.dateTimeBuy.Location = new System.Drawing.Point(461, 112);
            this.dateTimeBuy.Name = "dateTimeBuy";
            this.dateTimeBuy.Size = new System.Drawing.Size(212, 21);
            this.dateTimeBuy.TabIndex = 4;
            this.dateTimeBuy.ValueChanged += new System.EventHandler(this.dateTimeBuy_ValueChanged);
            // 
            // groupboxInforObj
            // 
            this.groupboxInforObj.Controls.Add(this.labelMaxString);
            this.groupboxInforObj.Controls.Add(this.dateTimePickerEndTime);
            this.groupboxInforObj.Controls.Add(this.dateTimeEnd);
            this.groupboxInforObj.Controls.Add(this.labelEndAuctionL);
            this.groupboxInforObj.Controls.Add(this.cbboxCategory);
            this.groupboxInforObj.Controls.Add(this.dateTimeBuy);
            this.groupboxInforObj.Controls.Add(this.labelCategory);
            this.groupboxInforObj.Controls.Add(this.txtboxObjname);
            this.groupboxInforObj.Controls.Add(this.labelObjname);
            this.groupboxInforObj.Controls.Add(this.txtboxStartmoney);
            this.groupboxInforObj.Controls.Add(this.labelStartmoney);
            this.groupboxInforObj.Controls.Add(this.txtboxExplanation);
            this.groupboxInforObj.Controls.Add(this.labelExplanation);
            this.groupboxInforObj.Controls.Add(this.txtboxBuyprice);
            this.groupboxInforObj.Controls.Add(this.labelBuyprice);
            this.groupboxInforObj.Controls.Add(this.labelBuydate);
            this.groupboxInforObj.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupboxInforObj.Location = new System.Drawing.Point(222, 41);
            this.groupboxInforObj.Name = "groupboxInforObj";
            this.groupboxInforObj.Size = new System.Drawing.Size(802, 390);
            this.groupboxInforObj.TabIndex = 2;
            this.groupboxInforObj.TabStop = false;
            this.groupboxInforObj.Text = "제품 정보";
            // 
            // labelMaxString
            // 
            this.labelMaxString.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMaxString.BackColor = System.Drawing.SystemColors.Window;
            this.labelMaxString.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelMaxString.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelMaxString.Location = new System.Drawing.Point(653, 362);
            this.labelMaxString.Name = "labelMaxString";
            this.labelMaxString.Size = new System.Drawing.Size(100, 13);
            this.labelMaxString.TabIndex = 26;
            this.labelMaxString.Text = "0/1000";
            this.labelMaxString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(278, 139);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.ShowUpDown = true;
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(103, 21);
            this.dateTimePickerEndTime.TabIndex = 6;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(101, 139);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(171, 21);
            this.dateTimeEnd.TabIndex = 5;
            // 
            // labelEndAuctionL
            // 
            this.labelEndAuctionL.AutoSize = true;
            this.labelEndAuctionL.Location = new System.Drawing.Point(10, 145);
            this.labelEndAuctionL.Name = "labelEndAuctionL";
            this.labelEndAuctionL.Size = new System.Drawing.Size(79, 13);
            this.labelEndAuctionL.TabIndex = 23;
            this.labelEndAuctionL.Text = "경매 종료 날짜";
            // 
            // openSubImage2
            // 
            this.openSubImage2.Filter = "이미지 파일 (*.png, *.jpg)|*.png;*jpg|모든 파일(*.*)|*.*";
            this.openSubImage2.InitialDirectory = "C:\\";
            // 
            // openSubImage3
            // 
            this.openSubImage3.Filter = "이미지 파일 (*.png, *.jpg)|*.png;*jpg|모든 파일(*.*)|*.*";
            this.openSubImage3.InitialDirectory = "C:\\";
            // 
            // pictureboxProfile
            // 
            this.pictureboxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureboxProfile.Image = global::deal_Program.Properties.Resources.no;
            this.pictureboxProfile.Location = new System.Drawing.Point(9, 51);
            this.pictureboxProfile.Name = "pictureboxProfile";
            this.pictureboxProfile.Size = new System.Drawing.Size(205, 196);
            this.pictureboxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxProfile.TabIndex = 15;
            this.pictureboxProfile.TabStop = false;
            // 
            // btnMainRemove
            // 
            this.btnMainRemove.Font = new System.Drawing.Font("ONE 모바일고딕 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMainRemove.Location = new System.Drawing.Point(114, 253);
            this.btnMainRemove.Name = "btnMainRemove";
            this.btnMainRemove.Size = new System.Drawing.Size(100, 28);
            this.btnMainRemove.TabIndex = 19;
            this.btnMainRemove.Text = "삭제";
            this.btnMainRemove.UseVisualStyleBackColor = true;
            this.btnMainRemove.Click += new System.EventHandler(this.btnMainRemove_Click);
            // 
            // formUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 838);
            this.Controls.Add(this.btnMainRemove);
            this.Controls.Add(this.groupboxInforObj);
            this.Controls.Add(this.labelSubImage);
            this.Controls.Add(this.flowLayoutPanelSub);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUploadProfile);
            this.Controls.Add(this.pictureboxProfile);
            this.Controls.Add(this.btnUploadobj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유즈 옥션 [업로드]";
            this.Load += new System.EventHandler(this.formUpload_Load);
            this.flowLayoutPanelSub.ResumeLayout(false);
            this.groupboxSub1.ResumeLayout(false);
            this.groupboxSub2.ResumeLayout(false);
            this.groupboxSub3.ResumeLayout(false);
            this.groupboxInforObj.ResumeLayout(false);
            this.groupboxInforObj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadobj;
        private System.Windows.Forms.ComboBox cbboxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.TextBox txtboxObjname;
        private System.Windows.Forms.TextBox txtboxStartmoney;
        private System.Windows.Forms.TextBox txtboxBuyprice;
        private System.Windows.Forms.Label labelObjname;
        private System.Windows.Forms.Label labelStartmoney;
        private System.Windows.Forms.Label labelBuyprice;
        private System.Windows.Forms.Label labelBuydate;
        private System.Windows.Forms.TextBox txtboxExplanation;
        private System.Windows.Forms.Label labelExplanation;
        private System.Windows.Forms.PictureBox pictureboxProfile;
        private System.Windows.Forms.Button btnUploadProfile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openMainImage;
        private System.Windows.Forms.Label labelSubImage;
        private System.Windows.Forms.Button btnSubImage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSub;
        private System.Windows.Forms.OpenFileDialog openSubImage1;
        private System.Windows.Forms.GroupBox groupboxSub1;
        private System.Windows.Forms.Button btnUploadSub1;
        private System.Windows.Forms.Button btnSubImg1Delete;
        private System.Windows.Forms.GroupBox groupboxSub2;
        private System.Windows.Forms.Button btnUploadSub2;
        private System.Windows.Forms.Button btnSubImage2;
        private System.Windows.Forms.Button btnSubImg2Delete;
        private System.Windows.Forms.GroupBox groupboxSub3;
        private System.Windows.Forms.Button btnUploadSub3;
        private System.Windows.Forms.Button btnSubImage3;
        private System.Windows.Forms.Button btnSubImg3Delete;
        private System.Windows.Forms.DateTimePicker dateTimeBuy;
        private System.Windows.Forms.GroupBox groupboxInforObj;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label labelEndAuctionL;
        private System.Windows.Forms.OpenFileDialog openSubImage2;
        private System.Windows.Forms.OpenFileDialog openSubImage3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label labelMaxString;
        private System.Windows.Forms.Button btnMainRemove;
    }
}