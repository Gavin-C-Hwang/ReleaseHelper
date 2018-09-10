namespace WindowsFormsApplication1
{
    partial class FmReleaseHelper
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmReleaseHelper));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxReleaseFileList = new System.Windows.Forms.TextBox();
            this.tbxCsrId = new System.Windows.Forms.TextBox();
            this.btnMakeDirectories = new System.Windows.Forms.Button();
            this.lblLocalFiles = new System.Windows.Forms.Label();
            this.tbxBackupFiles = new System.Windows.Forms.TextBox();
            this.lblBackup = new System.Windows.Forms.Label();
            this.lblSearchCnt = new System.Windows.Forms.Label();
            this.lblBackupCnt = new System.Windows.Forms.Label();
            this.cbFileTypeAll = new System.Windows.Forms.CheckBox();
            this.lblGNBForSystem = new System.Windows.Forms.Label();
            this.lblGnBForFileType = new System.Windows.Forms.Label();
            this.brnCompare = new System.Windows.Forms.Button();
            this.rdProd = new System.Windows.Forms.RadioButton();
            this.rdDev = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblDebugSystem = new System.Windows.Forms.Label();
            this.lblDebugFileType = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSvn = new System.Windows.Forms.Button();
            this.btnDoc = new System.Windows.Forms.Button();
            this.lblCurPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(459, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 24);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxReleaseFileList
            // 
            this.tbxReleaseFileList.Location = new System.Drawing.Point(12, 67);
            this.tbxReleaseFileList.Multiline = true;
            this.tbxReleaseFileList.Name = "tbxReleaseFileList";
            this.tbxReleaseFileList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxReleaseFileList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxReleaseFileList.Size = new System.Drawing.Size(1167, 226);
            this.tbxReleaseFileList.TabIndex = 1;
            this.tbxReleaseFileList.TextChanged += new System.EventHandler(this.tbxReleaseFileList_TextChanged);
            // 
            // tbxCsrId
            // 
            this.tbxCsrId.Location = new System.Drawing.Point(319, 42);
            this.tbxCsrId.Name = "tbxCsrId";
            this.tbxCsrId.Size = new System.Drawing.Size(133, 21);
            this.tbxCsrId.TabIndex = 2;
            // 
            // btnMakeDirectories
            // 
            this.btnMakeDirectories.Location = new System.Drawing.Point(570, 40);
            this.btnMakeDirectories.Name = "btnMakeDirectories";
            this.btnMakeDirectories.Size = new System.Drawing.Size(103, 24);
            this.btnMakeDirectories.TabIndex = 3;
            this.btnMakeDirectories.Text = "반영폴더생성";
            this.btnMakeDirectories.UseVisualStyleBackColor = true;
            this.btnMakeDirectories.Click += new System.EventHandler(this.btnMakeDirectories_Click);
            // 
            // lblLocalFiles
            // 
            this.lblLocalFiles.AutoSize = true;
            this.lblLocalFiles.Location = new System.Drawing.Point(12, 50);
            this.lblLocalFiles.Name = "lblLocalFiles";
            this.lblLocalFiles.Size = new System.Drawing.Size(53, 12);
            this.lblLocalFiles.TabIndex = 6;
            this.lblLocalFiles.Text = "검색결과";
            // 
            // tbxBackupFiles
            // 
            this.tbxBackupFiles.Location = new System.Drawing.Point(12, 325);
            this.tbxBackupFiles.Multiline = true;
            this.tbxBackupFiles.Name = "tbxBackupFiles";
            this.tbxBackupFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxBackupFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxBackupFiles.Size = new System.Drawing.Size(1167, 254);
            this.tbxBackupFiles.TabIndex = 7;
            // 
            // lblBackup
            // 
            this.lblBackup.AutoSize = true;
            this.lblBackup.Location = new System.Drawing.Point(12, 310);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(53, 12);
            this.lblBackup.TabIndex = 8;
            this.lblBackup.Text = "백업파일";
            // 
            // lblSearchCnt
            // 
            this.lblSearchCnt.AutoSize = true;
            this.lblSearchCnt.Location = new System.Drawing.Point(92, 50);
            this.lblSearchCnt.Name = "lblSearchCnt";
            this.lblSearchCnt.Size = new System.Drawing.Size(23, 12);
            this.lblSearchCnt.TabIndex = 9;
            this.lblSearchCnt.Text = "0건";
            // 
            // lblBackupCnt
            // 
            this.lblBackupCnt.AutoSize = true;
            this.lblBackupCnt.Location = new System.Drawing.Point(92, 310);
            this.lblBackupCnt.Name = "lblBackupCnt";
            this.lblBackupCnt.Size = new System.Drawing.Size(23, 12);
            this.lblBackupCnt.TabIndex = 10;
            this.lblBackupCnt.Text = "0건";
            // 
            // cbFileTypeAll
            // 
            this.cbFileTypeAll.AutoSize = true;
            this.cbFileTypeAll.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbFileTypeAll.Location = new System.Drawing.Point(159, 12);
            this.cbFileTypeAll.Name = "cbFileTypeAll";
            this.cbFileTypeAll.Size = new System.Drawing.Size(50, 16);
            this.cbFileTypeAll.TabIndex = 11;
            this.cbFileTypeAll.Text = "전체";
            this.cbFileTypeAll.UseVisualStyleBackColor = true;
            this.cbFileTypeAll.CheckedChanged += new System.EventHandler(this.cbFileTypeAll_CheckedChanged);
            // 
            // lblGNBForSystem
            // 
            this.lblGNBForSystem.BackColor = System.Drawing.SystemColors.Control;
            this.lblGNBForSystem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGNBForSystem.Location = new System.Drawing.Point(3, 5);
            this.lblGNBForSystem.Name = "lblGNBForSystem";
            this.lblGNBForSystem.Size = new System.Drawing.Size(141, 34);
            this.lblGNBForSystem.TabIndex = 12;
            // 
            // lblGnBForFileType
            // 
            this.lblGnBForFileType.BackColor = System.Drawing.SystemColors.Control;
            this.lblGnBForFileType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGnBForFileType.Location = new System.Drawing.Point(150, 5);
            this.lblGnBForFileType.Name = "lblGnBForFileType";
            this.lblGnBForFileType.Size = new System.Drawing.Size(949, 34);
            this.lblGnBForFileType.TabIndex = 14;
            // 
            // brnCompare
            // 
            this.brnCompare.Location = new System.Drawing.Point(679, 40);
            this.brnCompare.Name = "brnCompare";
            this.brnCompare.Size = new System.Drawing.Size(75, 24);
            this.brnCompare.TabIndex = 17;
            this.brnCompare.Text = "Compare";
            this.brnCompare.UseVisualStyleBackColor = true;
            this.brnCompare.Click += new System.EventHandler(this.brnCompare_Click);
            // 
            // rdProd
            // 
            this.rdProd.AutoSize = true;
            this.rdProd.Location = new System.Drawing.Point(215, 46);
            this.rdProd.Name = "rdProd";
            this.rdProd.Size = new System.Drawing.Size(47, 16);
            this.rdProd.TabIndex = 18;
            this.rdProd.Text = "운영";
            this.rdProd.UseVisualStyleBackColor = true;
            // 
            // rdDev
            // 
            this.rdDev.AutoSize = true;
            this.rdDev.Checked = true;
            this.rdDev.Location = new System.Drawing.Point(150, 46);
            this.rdDev.Name = "rdDev";
            this.rdDev.Size = new System.Drawing.Size(59, 16);
            this.rdDev.TabIndex = 19;
            this.rdDev.TabStop = true;
            this.rdDev.Text = "개발망";
            this.rdDev.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "CSR ID";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1133, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(46, 23);
            this.btnSettings.TabIndex = 21;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblDebugSystem
            // 
            this.lblDebugSystem.AutoSize = true;
            this.lblDebugSystem.Location = new System.Drawing.Point(10, 30);
            this.lblDebugSystem.Name = "lblDebugSystem";
            this.lblDebugSystem.Size = new System.Drawing.Size(0, 12);
            this.lblDebugSystem.TabIndex = 23;
            this.lblDebugSystem.Visible = false;
            // 
            // lblDebugFileType
            // 
            this.lblDebugFileType.AutoSize = true;
            this.lblDebugFileType.Location = new System.Drawing.Point(509, 26);
            this.lblDebugFileType.Name = "lblDebugFileType";
            this.lblDebugFileType.Size = new System.Drawing.Size(0, 12);
            this.lblDebugFileType.TabIndex = 24;
            this.lblDebugFileType.Visible = false;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(850, 40);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(87, 22);
            this.btnBackup.TabIndex = 25;
            this.btnBackup.Text = "백업";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Visible = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSvn
            // 
            this.btnSvn.Location = new System.Drawing.Point(1133, 29);
            this.btnSvn.Name = "btnSvn";
            this.btnSvn.Size = new System.Drawing.Size(46, 23);
            this.btnSvn.TabIndex = 26;
            this.btnSvn.Text = "SVN";
            this.btnSvn.UseVisualStyleBackColor = true;
            this.btnSvn.Click += new System.EventHandler(this.btnSvn_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.Location = new System.Drawing.Point(760, 40);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(84, 24);
            this.btnDoc.TabIndex = 27;
            this.btnDoc.Text = "GAMS처리";
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // lblCurPath
            // 
            this.lblCurPath.AutoSize = true;
            this.lblCurPath.Location = new System.Drawing.Point(148, 310);
            this.lblCurPath.Name = "lblCurPath";
            this.lblCurPath.Size = new System.Drawing.Size(0, 12);
            this.lblCurPath.TabIndex = 28;
            // 
            // FmReleaseHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 583);
            this.Controls.Add(this.lblCurPath);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.btnSvn);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.lblDebugFileType);
            this.Controls.Add(this.lblDebugSystem);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdDev);
            this.Controls.Add(this.rdProd);
            this.Controls.Add(this.brnCompare);
            this.Controls.Add(this.lblBackupCnt);
            this.Controls.Add(this.lblSearchCnt);
            this.Controls.Add(this.lblBackup);
            this.Controls.Add(this.tbxBackupFiles);
            this.Controls.Add(this.cbFileTypeAll);
            this.Controls.Add(this.lblLocalFiles);
            this.Controls.Add(this.btnMakeDirectories);
            this.Controls.Add(this.tbxReleaseFileList);
            this.Controls.Add(this.tbxCsrId);
            this.Controls.Add(this.lblGnBForFileType);
            this.Controls.Add(this.lblGNBForSystem);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmReleaseHelper";
            this.Text = "ReleaseHelper                                                                    " +
    "                                                                                " +
    "            Powered by GavinLab";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxReleaseFileList;
        private System.Windows.Forms.TextBox tbxCsrId;
        private System.Windows.Forms.Button btnMakeDirectories;
        private System.Windows.Forms.Label lblLocalFiles;
        private System.Windows.Forms.TextBox tbxBackupFiles;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.Label lblSearchCnt;
        private System.Windows.Forms.Label lblBackupCnt;
        private System.Windows.Forms.CheckBox cbFileTypeAll;
        private System.Windows.Forms.Label lblGNBForSystem;
        private System.Windows.Forms.Label lblGnBForFileType;
        private System.Windows.Forms.Button brnCompare;
        private System.Windows.Forms.RadioButton rdProd;
        private System.Windows.Forms.RadioButton rdDev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblDebugSystem;
        private System.Windows.Forms.Label lblDebugFileType;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnSvn;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Label lblCurPath;
    }
}

