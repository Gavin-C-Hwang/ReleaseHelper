namespace ReleaseHelper
{
    partial class FrmDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocument));
            this.tbxBeforeReview = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdCsrDb = new System.Windows.Forms.RadioButton();
            this.rdCsrModifyProgram = new System.Windows.Forms.RadioButton();
            this.rdCsrModifyFunction = new System.Windows.Forms.RadioButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAcception = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAnal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDevelop = new System.Windows.Forms.TextBox();
            this.tbxDevReview = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxOther = new System.Windows.Forms.TextBox();
            this.tbxRealUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxCurrentFunc = new System.Windows.Forms.TextBox();
            this.tbxModifiedFunc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxUnitTest = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tbxAcceptComments = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxBuildDetail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxDevDetail = new System.Windows.Forms.TextBox();
            this.tbxCustReq = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxRelease = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxFinish = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxBeforeReview
            // 
            this.tbxBeforeReview.Location = new System.Drawing.Point(14, 344);
            this.tbxBeforeReview.Multiline = true;
            this.tbxBeforeReview.Name = "tbxBeforeReview";
            this.tbxBeforeReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxBeforeReview.Size = new System.Drawing.Size(427, 90);
            this.tbxBeforeReview.TabIndex = 80;
            this.tbxBeforeReview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(498, 893);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 893);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdCsrDb
            // 
            this.rdCsrDb.AutoSize = true;
            this.rdCsrDb.Checked = true;
            this.rdCsrDb.Location = new System.Drawing.Point(9, 12);
            this.rdCsrDb.Name = "rdCsrDb";
            this.rdCsrDb.Size = new System.Drawing.Size(83, 16);
            this.rdCsrDb.TabIndex = 21;
            this.rdCsrDb.TabStop = true;
            this.rdCsrDb.Text = "데이터수정";
            this.rdCsrDb.UseVisualStyleBackColor = true;
            this.rdCsrDb.CheckedChanged += new System.EventHandler(this.rdCsrDb_CheckedChanged);
            // 
            // rdCsrModifyProgram
            // 
            this.rdCsrModifyProgram.AutoSize = true;
            this.rdCsrModifyProgram.Location = new System.Drawing.Point(9, 34);
            this.rdCsrModifyProgram.Name = "rdCsrModifyProgram";
            this.rdCsrModifyProgram.Size = new System.Drawing.Size(95, 16);
            this.rdCsrModifyProgram.TabIndex = 20;
            this.rdCsrModifyProgram.Text = "단순프로그램";
            this.rdCsrModifyProgram.UseVisualStyleBackColor = true;
            this.rdCsrModifyProgram.CheckedChanged += new System.EventHandler(this.rdCsrDb_CheckedChanged);
            // 
            // rdCsrModifyFunction
            // 
            this.rdCsrModifyFunction.AutoSize = true;
            this.rdCsrModifyFunction.Location = new System.Drawing.Point(9, 56);
            this.rdCsrModifyFunction.Name = "rdCsrModifyFunction";
            this.rdCsrModifyFunction.Size = new System.Drawing.Size(71, 16);
            this.rdCsrModifyFunction.TabIndex = 22;
            this.rdCsrModifyFunction.Text = "기능수정";
            this.rdCsrModifyFunction.UseVisualStyleBackColor = true;
            this.rdCsrModifyFunction.CheckedChanged += new System.EventHandler(this.rdCsrDb_CheckedChanged);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(14, 329);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 25;
            this.lbl1.Text = "사전검토";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "접수";
            // 
            // tbxAcception
            // 
            this.tbxAcception.Location = new System.Drawing.Point(447, 343);
            this.tbxAcception.Multiline = true;
            this.tbxAcception.Name = "tbxAcception";
            this.tbxAcception.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxAcception.Size = new System.Drawing.Size(524, 91);
            this.tbxAcception.TabIndex = 90;
            this.tbxAcception.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "분석";
            // 
            // tbxAnal
            // 
            this.tbxAnal.Location = new System.Drawing.Point(12, 454);
            this.tbxAnal.Multiline = true;
            this.tbxAnal.Name = "tbxAnal";
            this.tbxAnal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxAnal.Size = new System.Drawing.Size(431, 69);
            this.tbxAnal.TabIndex = 100;
            this.tbxAnal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "개발";
            // 
            // tbxDevelop
            // 
            this.tbxDevelop.Location = new System.Drawing.Point(449, 454);
            this.tbxDevelop.Multiline = true;
            this.tbxDevelop.Name = "tbxDevelop";
            this.tbxDevelop.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDevelop.Size = new System.Drawing.Size(522, 158);
            this.tbxDevelop.TabIndex = 110;
            this.tbxDevelop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // tbxDevReview
            // 
            this.tbxDevReview.Location = new System.Drawing.Point(12, 544);
            this.tbxDevReview.Multiline = true;
            this.tbxDevReview.Name = "tbxDevReview";
            this.tbxDevReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDevReview.Size = new System.Drawing.Size(431, 68);
            this.tbxDevReview.TabIndex = 120;
            this.tbxDevReview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 529);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "개발검토";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 624);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "단위테스트";
            // 
            // tbxUnit
            // 
            this.tbxUnit.Location = new System.Drawing.Point(9, 639);
            this.tbxUnit.Multiline = true;
            this.tbxUnit.Name = "tbxUnit";
            this.tbxUnit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxUnit.Size = new System.Drawing.Size(311, 144);
            this.tbxUnit.TabIndex = 130;
            this.tbxUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 624);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "3자테스트";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(660, 624);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "사용자테스트";
            // 
            // tbxOther
            // 
            this.tbxOther.Location = new System.Drawing.Point(335, 639);
            this.tbxOther.Multiline = true;
            this.tbxOther.Name = "tbxOther";
            this.tbxOther.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxOther.Size = new System.Drawing.Size(311, 144);
            this.tbxOther.TabIndex = 140;
            this.tbxOther.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // tbxRealUser
            // 
            this.tbxRealUser.Location = new System.Drawing.Point(662, 639);
            this.tbxRealUser.Multiline = true;
            this.tbxRealUser.Name = "tbxRealUser";
            this.tbxRealUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRealUser.Size = new System.Drawing.Size(311, 144);
            this.tbxRealUser.TabIndex = 150;
            this.tbxRealUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "현재기능";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(579, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "변경기능";
            // 
            // tbxCurrentFunc
            // 
            this.tbxCurrentFunc.Location = new System.Drawing.Point(210, 69);
            this.tbxCurrentFunc.Multiline = true;
            this.tbxCurrentFunc.Name = "tbxCurrentFunc";
            this.tbxCurrentFunc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCurrentFunc.Size = new System.Drawing.Size(363, 69);
            this.tbxCurrentFunc.TabIndex = 30;
            // 
            // tbxModifiedFunc
            // 
            this.tbxModifiedFunc.Location = new System.Drawing.Point(631, 70);
            this.tbxModifiedFunc.Multiline = true;
            this.tbxModifiedFunc.Name = "tbxModifiedFunc";
            this.tbxModifiedFunc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxModifiedFunc.Size = new System.Drawing.Size(345, 69);
            this.tbxModifiedFunc.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 44;
            this.label10.Text = "단위테스트";
            // 
            // tbxUnitTest
            // 
            this.tbxUnitTest.Location = new System.Drawing.Point(496, 155);
            this.tbxUnitTest.Multiline = true;
            this.tbxUnitTest.Name = "tbxUnitTest";
            this.tbxUnitTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxUnitTest.Size = new System.Drawing.Size(346, 157);
            this.tbxUnitTest.TabIndex = 70;
            this.tbxUnitTest.Text = resources.GetString("tbxUnitTest.Text");
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConvert.Location = new System.Drawing.Point(853, 144);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(123, 169);
            this.btnConvert.TabIndex = 45;
            this.btnConvert.Text = "변환";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tbxAcceptComments
            // 
            this.tbxAcceptComments.Location = new System.Drawing.Point(631, 6);
            this.tbxAcceptComments.Multiline = true;
            this.tbxAcceptComments.Name = "tbxAcceptComments";
            this.tbxAcceptComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxAcceptComments.Size = new System.Drawing.Size(345, 58);
            this.tbxAcceptComments.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(579, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "접수의견";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 49;
            this.label12.Text = "설계상세";
            // 
            // tbxBuildDetail
            // 
            this.tbxBuildDetail.Location = new System.Drawing.Point(16, 155);
            this.tbxBuildDetail.Multiline = true;
            this.tbxBuildDetail.Name = "tbxBuildDetail";
            this.tbxBuildDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxBuildDetail.Size = new System.Drawing.Size(473, 71);
            this.tbxBuildDetail.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 51;
            this.label13.Text = "개발상세";
            // 
            // tbxDevDetail
            // 
            this.tbxDevDetail.Location = new System.Drawing.Point(16, 245);
            this.tbxDevDetail.Multiline = true;
            this.tbxDevDetail.Name = "tbxDevDetail";
            this.tbxDevDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDevDetail.Size = new System.Drawing.Size(473, 67);
            this.tbxDevDetail.TabIndex = 60;
            // 
            // tbxCustReq
            // 
            this.tbxCustReq.Location = new System.Drawing.Point(210, 6);
            this.tbxCustReq.Multiline = true;
            this.tbxCustReq.Name = "tbxCustReq";
            this.tbxCustReq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCustReq.Size = new System.Drawing.Size(363, 58);
            this.tbxCustReq.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 52;
            this.label14.Text = "요청사항";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 786);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 151;
            this.label15.Text = "릴리즈";
            // 
            // tbxRelease
            // 
            this.tbxRelease.Location = new System.Drawing.Point(9, 801);
            this.tbxRelease.Multiline = true;
            this.tbxRelease.Name = "tbxRelease";
            this.tbxRelease.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRelease.Size = new System.Drawing.Size(332, 88);
            this.tbxRelease.TabIndex = 160;
            this.tbxRelease.Text = resources.GetString("tbxRelease.Text");
            this.tbxRelease.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(965, 12);
            this.label16.TabIndex = 153;
            this.label16.Text = "=================================================================================" +
    "===============================================================================";
            // 
            // tbxFinish
            // 
            this.tbxFinish.Location = new System.Drawing.Point(676, 801);
            this.tbxFinish.Multiline = true;
            this.tbxFinish.Name = "tbxFinish";
            this.tbxFinish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFinish.Size = new System.Drawing.Size(289, 88);
            this.tbxFinish.TabIndex = 180;
            this.tbxFinish.Text = "안녕하십니까. CNS운영팀 황철(78068)입니다.\r\n\r\n요청하신 CSR이 완료되었습니다.\r\n\r\n확인해 보시고 이상 있으면 연락주세요.\r\n\r\n감사" +
    "합니다.";
            this.tbxFinish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(345, 786);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 12);
            this.label17.TabIndex = 154;
            this.label17.Text = "릴리즈 결과";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(343, 801);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(327, 88);
            this.textBox2.TabIndex = 170;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDoc_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(683, 786);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 171;
            this.label18.Text = "종료";
            // 
            // FrmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 926);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbxFinish);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbxRelease);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbxCustReq);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbxDevDetail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbxBuildDetail);
            this.Controls.Add(this.tbxAcceptComments);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxUnitTest);
            this.Controls.Add(this.tbxModifiedFunc);
            this.Controls.Add(this.tbxCurrentFunc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxRealUser);
            this.Controls.Add(this.tbxOther);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxDevReview);
            this.Controls.Add(this.tbxDevelop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAnal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxAcception);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.rdCsrModifyFunction);
            this.Controls.Add(this.rdCsrDb);
            this.Controls.Add(this.rdCsrModifyProgram);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxBeforeReview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDocument";
            this.Text = "FrmDocument";
            this.Load += new System.EventHandler(this.FrmDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxBeforeReview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdCsrDb;
        private System.Windows.Forms.RadioButton rdCsrModifyProgram;
        private System.Windows.Forms.RadioButton rdCsrModifyFunction;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAcception;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAnal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDevelop;
        private System.Windows.Forms.TextBox tbxDevReview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxOther;
        private System.Windows.Forms.TextBox tbxRealUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxCurrentFunc;
        private System.Windows.Forms.TextBox tbxModifiedFunc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxUnitTest;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox tbxAcceptComments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxBuildDetail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxDevDetail;
        private System.Windows.Forms.TextBox tbxCustReq;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxRelease;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxFinish;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label18;
    }
}