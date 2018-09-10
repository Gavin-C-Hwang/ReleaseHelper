using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections;
using ReleaseHelper.Properties;
using ReleaseHelper;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class FmReleaseHelper : Form
    {
        //search keyword
        private string csrId = null;


        //workspace folder path[system name, local root path, dev root path for backup, prod root path for backup]
        private string[,] arPathWorkspace;

        //release folder name
        private string targetFolder = "";

        //search file type
        private string[] fileTypeForSearch;

        //the difference of folders hirachy.
        private string[,] folderPath;

        //release file list each systems
        private string[][] releaseFileList;

        public TextParser parser = new TextParser();

        int searchFileCnt = 0;
        string[] releaseFileListlines;
        string[] backupFileListlines;


        public FmReleaseHelper()
        {
            InitializeComponent();
        }//Form1

        private void initData() 
        {
            try
            {
                ArrayList systemsInfo = parser.parse();
                fileTypeForSearch = parser.FileTypeForSearch;
                folderPath = parser.EditableFolders;
                targetFolder = parser.TargetFolder;
                Hashtable row = (Hashtable)systemsInfo[0];

                arPathWorkspace = new string[systemsInfo.Count, row.Count];

                //[counts of systems][the cound of released files]
                releaseFileList = releaseFileList == null ? new string[arPathWorkspace.GetLength(0)][] : releaseFileList;

                for (int i = 0; i < arPathWorkspace.GetLength(0); i++)
                {
                    row = (Hashtable)systemsInfo[i];

                    for (int j = 0; j < arPathWorkspace.GetLength(1); j++)
                    {
                        arPathWorkspace[i, j] = row[Regex.Replace(parser.FileColumns[j], @"[0-9]+\.", "")].ToString();
                    }//for
                }//for
            }//try
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }//catch
            
        }//initData

        private void Form1_Load(object sender, EventArgs e)
        {
            initData();
            setCheckBoexes();
        }//Form1_Load

        #region button event
        //seach button action
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if ("".Equals(Settings.Default.selectedSystem) || "".Equals(Settings.Default.selectedFileType))
            {
                MessageBox.Show("시스템과 검색파일 종류를 선택해야 합니다.");
                return;
            }//if

            releaseFileList = new string[arPathWorkspace.GetLength(0)][];
            releaseFileListlines = null;
            fileTypeForSearch = Settings.Default.selectedFileType.Split(',');

       
            tbxReleaseFileList.Text = string.Empty;
            tbxBackupFiles.Text = string.Empty;
            csrId = tbxCsrId.Text;

            searchFileCnt = 0;
            for (int i = 0; i<  arPathWorkspace.GetLength(0); i++)
            {
                DirectoryInfo di = new DirectoryInfo(arPathWorkspace[i, 1]);
                string[] systemFiles = new string[0];
                List<DirectoryInfo> lDi = di.GetDirectories("*", SearchOption.TopDirectoryOnly).ToList();
                lDi.Insert(0, di);

                foreach (DirectoryInfo diPath in lDi)
                {
                    string folderPath = diPath.FullName;
                    if(folderPath.Contains(".svn")) continue;
                    //get the files that has keyword from local system root path  
                    if (!Settings.Default.selectedSystem.Contains(arPathWorkspace[i, 0])) continue;
                    lblCurPath.Text = string.Format("{0}에서 {1} 찾는중...", folderPath, csrId);
                    lblCurPath.Refresh();

                    Task<string[]> fileListAsync = GetFileList(csrId, folderPath, diPath.FullName == arPathWorkspace[i, 1]?false:true);
                    string[] folderFiles = await fileListAsync;
                    systemFiles = systemFiles.Concat(folderFiles).ToArray();

                    searchFileCnt += folderFiles.Length;

                    for (int j = 0; j < folderFiles.Length; j++)
                    {
                        tbxReleaseFileList.Text += folderFiles[j] + "\r\n";
                    }//for
                    tbxReleaseFileList.Refresh();
                    lblSearchCnt.Text = searchFileCnt + "건";
                    lblSearchCnt.Refresh();
                }
                releaseFileList[i] = systemFiles;

            }//for    
            lblCurPath.Text = "검색완료";
            MessageBox.Show("검색완료 " + lblSearchCnt.Text);

        }//btnSearch_Click

        //compare button action
        private void brnCompare_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo pinfo = new ProcessStartInfo();
            p.StartInfo = pinfo;
            pinfo.FileName = "CMD.exe";
            pinfo.WindowStyle = ProcessWindowStyle.Hidden;
            pinfo.CreateNoWindow = true;
            pinfo.UseShellExecute = false;

            pinfo.RedirectStandardInput = true;
            pinfo.RedirectStandardError = true;
            pinfo.RedirectStandardOutput = true;
            p.EnableRaisingEvents = false;
            p.Start();
            

            int selectionStart = tbxReleaseFileList.SelectionStart;
            int selectionLength = tbxReleaseFileList.SelectionLength;

            releaseFileListlines = releaseFileListlines == null ? tbxReleaseFileList.Lines : releaseFileListlines;
             backupFileListlines = backupFileListlines == null ? tbxBackupFiles.Lines : backupFileListlines;

            int selectedLine = 0;
            int currentReleaseFileCnt= 0;
            //total count include \r\n. it is 36 char bigger than text count.
            for (int i = 0; i<releaseFileListlines.Length; i++)
            {
                int preCnt = currentReleaseFileCnt;
                currentReleaseFileCnt = preCnt + releaseFileListlines[i].Length + 2;

                if (preCnt < selectionStart && selectionStart < currentReleaseFileCnt) 
                {
                    selectedLine = i;   
                }
            }

            string execUcl = "";
            if (string.IsNullOrEmpty(parser.CompareToolPath)) {
                MessageBox.Show("(비교툴경로)가 설정되어있지 않습니다.");
                return;
            } 

            if (releaseFileListlines[selectedLine].EndsWith(".java"))
            {
                string[] decompileFiles = decompileJava(backupFileListlines[selectedLine]);
                if (decompileFiles[0] == null || decompileFiles[1] == null) return;
                try { execUcl = string.Format(@"""{0}"" ""{1}"" ""{2}""", parser.CompareToolPath, decompileFiles[0], decompileFiles[1]); }
                catch { execUcl = string.Format(@"ucl.exe"); }
            }
            else
            {
                try { execUcl = string.Format(@"""{0}"" ""{1}"" ""{2}""", parser.CompareToolPath, releaseFileListlines[selectedLine], backupFileListlines[selectedLine]); }
                catch { execUcl = string.Format(@"ucl.exe"); }
            }

            
            
            p.StandardInput.WriteLine(execUcl);
            p.StandardInput.Close();

            //  p.WaitForExit();
            p.Close();
            tbxReleaseFileList.Focus();
            tbxReleaseFileList.SelectionStart = selectionStart;
            tbxReleaseFileList.SelectionLength = selectionLength;
            
        }//brnCompare_Click

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string targetFolderFullPath = targetFolder + "\\" + DateTime.Now.ToString("yyyyMMdd") + (rdProd.Checked ? "_prod" : "_dev") + "\\";
            tbxBackupFiles.Text = string.Empty;
            string fCsrId = "CSR_ID_" + csrId;

            int backupFileCnt = 0;
            int backupFileindex = 0;

            backupFileListlines = new string[searchFileCnt];


            for (int h = 0; h < releaseFileList.GetLength(0); h++)
            {
                string classPath = parser.getClassPath(arPathWorkspace[h, 1]);
                string srcPath = parser.getSrcPath(arPathWorkspace[h, 1]);

                if (releaseFileList[h] == null) continue;

                for (int i = 0; i < releaseFileList[h].GetLength(0); i++)
                {
                    if (releaseFileList[h][i] == null || releaseFileList[h][i] == "") continue;
                    FileInfo fi = null;
                    if (releaseFileList[h][i].EndsWith(".java"))
                    {
                        fi = new FileInfo(releaseFileList[h][i].Replace(srcPath, classPath).Replace(".java", ".class"));
                    }
                    else
                    {
                        fi = new FileInfo(releaseFileList[h][i]);
                    }//if

                    string relativeFolderPath = fi.DirectoryName.Replace(arPathWorkspace[h, 1], "");
                    string targetFolderPath = ChangeFolderSchema(targetFolderFullPath + fCsrId + "\\" + arPathWorkspace[h, 0] + relativeFolderPath);


                    #region 파일 백업 시작.
                    string sourceFileNameInServer = ChangeFolderSchema(arPathWorkspace[h, rdDev.Checked ? 2 : 3] + relativeFolderPath + "\\" + fi.Name);
                    string destFileNameForBackup = ChangeFolderSchema(targetFolderFullPath + fCsrId + "\\backup\\" + arPathWorkspace[h, 0] + relativeFolderPath + "\\" + fi.Name);

                    FileInfo backFiles = new FileInfo(destFileNameForBackup);
                    Directory.CreateDirectory(backFiles.DirectoryName);

                    backupFileCnt++;
                    try
                    {
                        if (sourceFileNameInServer.ToUpper().Contains("FTP"))
                        {
                            string[] ftpInfo = sourceFileNameInServer.Split(',');
                            if (ftpInfo.Length != 4) throw new Exception("ftpInfo length is not 4.");

                            string host = ftpInfo[0].Trim() + "/";
                            string id = ftpInfo[1].Trim();
                            string pass = ftpInfo[2].Trim();
                            string filePath = ftpInfo[3].Replace("\\", "/").Trim();

                            backupFileListlines[backupFileindex] = destFileNameForBackup;
                            backupFileindex++;

                            string result = FTP.Instance(host, id, pass).download(filePath, destFileNameForBackup);
                            if (!"".Equals(result)) { throw new Exception(result); }

                        }
                        else
                        {
                            backupFileListlines[backupFileindex] = destFileNameForBackup;
                            backupFileindex++;
                            File.Copy(sourceFileNameInServer, destFileNameForBackup, true);
                        }//if
                        tbxBackupFiles.Text += sourceFileNameInServer + "\r\n";
                    }//try
                    catch (FileNotFoundException err)
                    {
                        tbxBackupFiles.Text += sourceFileNameInServer + "  >>" + err.GetType().ToString() + "<<\r\n";
                        backupFileCnt--;
                    }//catch
                    catch (DirectoryNotFoundException err)
                    {
                        tbxBackupFiles.Text += sourceFileNameInServer + "  >>" + err.GetType().ToString() + "<<\r\n";
                        backupFileCnt--;
                    }//catch
                    catch (Exception err)
                    {
                        tbxBackupFiles.Text += sourceFileNameInServer + "  >>" + err.GetType().ToString() + "<<\r\n";
                        backupFileCnt--;
                    }//catch

                    lblBackupCnt.Text = backupFileCnt + "건";
                    #endregion file backup logic.
                }//for
            }//for


        }//btnBackup_Click

        //setting button action
        private void btnSettings_Click(object sender, EventArgs e)
        {
            FmSettingsP pop = new FmSettingsP();
            if (DialogResult.OK == pop.ShowDialog()) 
            {
                initData();
                setCheckBoexes();
            }
        }//btnSettings_Click

        private void btnSvn_Click(object sender, EventArgs e)
        {
            string targetFolderFullPath = targetFolder + "\\" + DateTime.Now.ToString("yyyyMMdd") + (rdProd.Checked ? "_prod" : "_dev") + "\\";
            string fCsrId = "CSR_ID_" + csrId;

            for (int h = 0; h < releaseFileList.GetLength(0); h++)
            {
                
                if (releaseFileList[h] == null) continue;

                for (int i = 0; i < releaseFileList[h].GetLength(0); i++)
                {
                    FileInfo fi = new FileInfo(releaseFileList[h][i]);

                    string relativeFolderPath = fi.DirectoryName.Replace(arPathWorkspace[h, 1], "");
                    string targetFolderPath = targetFolderFullPath + fCsrId + "\\SVN\\" + arPathWorkspace[h, 0] + relativeFolderPath;

                    Directory.CreateDirectory(targetFolderPath);

                    string sourceFileName = fi.FullName;
                    string destFileName = targetFolderPath + "\\" + fi.Name;

                    //copy the local files to release folder.
                    File.Copy(sourceFileName, destFileName, true);


                }//for
            }//for
            MessageBox.Show("Completed");
        }//btnSvn_Click

        #endregion

        //convert the files that has keyword in pathWOrkspace to single array
        private async Task<string[]> GetFileList(string csrNo, string pathWorkspace, bool recursive) 
        {

             string result = await getFilesFromCmd(csrNo, pathWorkspace, recursive);
             string[] contents = result.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
             string[] realContents = new string[contents.Length - 4];
             for (int i = 0; i < realContents.Length; i++)
             {
                 realContents[i] = contents[i + 3];
             }//for

             return realContents;

        }//GetFileList

        private async Task<string> getFilesFromCmd(string csrNo, string path, bool recursive)
        {
            Process p = new Process();
            ProcessStartInfo pinfo = new ProcessStartInfo();
            p.StartInfo = pinfo;
            pinfo.FileName = "CMD.exe";
            pinfo.WindowStyle = ProcessWindowStyle.Hidden;
            pinfo.CreateNoWindow = true;
            pinfo.UseShellExecute = false;

            pinfo.RedirectStandardInput = true;
            pinfo.RedirectStandardError = true;
            pinfo.RedirectStandardOutput = true;
            p.EnableRaisingEvents = false;
            p.Start();

            string command = string.Format(@"findstr /M {0} ""{1}"" ", recursive?"/S":"", csrNo);

            for (int i = 0; i < fileTypeForSearch.Length; i++)
            {
                command += string.Format(@"{0}\*.{1} ", path, fileTypeForSearch[i]);
            }//for

            p.StandardInput.WriteLine(command);
            p.StandardInput.Close();

            string result = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return result;
        }

        //make the folder hirachy
        private void btnMakeDirectories_Click(object sender, EventArgs e)
        {
            #region 반영폴더생성 및 파일 복사
            string targetFolderFullPath = targetFolder + "\\" + DateTime.Now.ToString("yyyyMMdd")+(rdProd.Checked?"_prod":"_dev") + "\\"  ;
            tbxBackupFiles.Text = string.Empty;
            string fCsrId = "CSR_ID_" + csrId;

            //get the index of selected checkbox
            int selectedIdx = 0;
            for (int i = 0; i < arPathWorkspace.GetLength(0); i++)
            {
                if (Settings.Default.selectedSystem.Contains(arPathWorkspace[i, 0]))
                {
                    selectedIdx = i;
                    break;
                }
            }

            //convert the file info in textbox to single array
            if (releaseFileList[selectedIdx] == null) 
            {
                releaseFileList[selectedIdx] = tbxReleaseFileList.Lines;
                searchFileCnt = tbxReleaseFileList.Lines.Length;
                csrId = "SVN_" + tbxCsrId.Text;
                fCsrId = "CSR_ID_" + csrId;
            }
            
            



            int backupFileCnt = 0;
            for (int h = 0; h < releaseFileList.GetLength(0); h++)
            {
                string classPath = parser.getClassPath(arPathWorkspace[h,1]);
                string srcPath = parser.getSrcPath(arPathWorkspace[h, 1]);

                if (releaseFileList[h] == null) continue; 

                for (int i = 0; i < releaseFileList[h].GetLength(0); i++)
                {
                    FileInfo fi = null;
                    if (releaseFileList[h][i] == null || releaseFileList[h][i] == "") continue;

                    if (releaseFileList[h][i].Contains(".java"))
                    {
                        fi = new FileInfo(releaseFileList[h][i].Replace(srcPath, classPath).Replace(".java", ".class"));
                    }
                    else
                    {
                        fi = new FileInfo(releaseFileList[h][i]);
                    }

                    string relativeFolderPath = fi.DirectoryName.Replace(arPathWorkspace[h, 1], "");
                    string targetFolderPath = ChangeFolderSchema(targetFolderFullPath + fCsrId + "\\" + arPathWorkspace[h, 0] + relativeFolderPath);

                    Directory.CreateDirectory(targetFolderPath);

                    string sourceFileName = fi.FullName;
                    string destFileName = targetFolderPath + "\\" + fi.Name;

                    //copy local file to release folder
                    try { File.Copy(sourceFileName, destFileName, true); } catch (Exception err) { MessageBox.Show(err.Message); continue; }
            

                }//for
            }//for
            #endregion

            btnBackup_Click(sender, e);
            MessageBox.Show("Completed.");
        }//btnMakeDirectories_Click


        private void tbxReleaseFileList_TextChanged(object sender, EventArgs e)
        {
            tbxReleaseFileList.Text = tbxReleaseFileList.Text.Replace("/branches/GPT_Officeplus", "C:\\iKEP4-Project\\workspace\\Officeplus").Replace("/", "\\");
        }

        
        //fix folder path.
        private string ChangeFolderSchema(string root)
        {
            string result = root;

            for (int i = 0; i < folderPath.GetLength(0); i++)
            {
                result = result.Replace(folderPath[i, 0], folderPath[i, 1]);
            }//for

            return result;
        }//ChangeFolderSchema

        #region for check boxes
        private void cbChildSystem_CheckedChanged(object sender, EventArgs e) 
        {
            getSelectedCheckBoxNames("cbChildSystems");
        }//cbChildSystem_CheckedChanged

        private void cbChildFileType_CheckedChanged(object sender, EventArgs e)
        {
            getSelectedCheckBoxNames("cbChildFileType");
        }//cbChildFileType_CheckedChanged
       
        private void cbFileTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFileTypeAll.Checked)
            {
                foreach (Control ct in this.Controls)
                {
                    if (ct is CheckBox && ct.Name.Contains("cbChildFileType"))
                    {
                        ((CheckBox)ct).Checked = true;
                    }//if
                }//foreach
            }//if
            else
            {
                foreach (Control ct in this.Controls)
                {
                    if (ct is CheckBox && ct.Name.Contains("cbChildFileType"))
                    {
                        ((CheckBox)ct).Checked = false;
                    }//if
                }//foreach
            }//else

            getSelectedCheckBoxNames("cbChildFileType");
        }//cbFileTypeAll_CheckedChanged

        private void getSelectedCheckBoxNames(string cbName)
        {
            if (!IsloadedCheckBoxes) return;
            string selectedText = "";

            foreach (Control ct in this.Controls)
            {
                if (ct is CheckBox && ct.Name.Contains(cbName))
                {
                    if (((CheckBox)ct).Checked)
                    {
                        selectedText = selectedText + ct.Text + ",";
                    }
                }//if
            }//foreach 

            if ("cbChildSystems".Equals(cbName))
            {
                try { Settings.Default.selectedSystem = selectedText.Substring(0, selectedText.Length - 1);  }
                catch { Settings.Default.selectedSystem = ""; }
            }
            else if ("cbChildFileType".Equals(cbName))
            {
                try { Settings.Default.selectedFileType = selectedText.Substring(0, selectedText.Length - 1);  }
                catch { Settings.Default.selectedFileType = ""; }
            }
            lblDebugSystem.Text = Settings.Default.selectedSystem;
            lblDebugFileType.Text = Settings.Default.selectedFileType;
            Settings.Default.Save();
        }//getSelectedCheckBoxNames

        bool IsloadedCheckBoxes = false;

        private void setCheckBoexes()
        {
            IsloadedCheckBoxes = false;

            foreach (Control ct in this.Controls)
            {
                if (ct is CheckBox && (ct.Name.Contains("cbChildSystems")  || (ct.Name.Contains("cbChildFileType"))) )
                {
                    this.Controls.Remove(ct);
                }//if
            }//foreach 

     
            for (int i = 0; i < arPathWorkspace.GetLength(0); i++)
            { 
                CheckBox checkBox = new CheckBox();
                checkBox.Checked = true;
                checkBox.AutoSize = true;
                checkBox.Location = new System.Drawing.Point(30+90 * i, 12);
                checkBox.Name = "cbChildSystems" + i;
                checkBox.Size = new System.Drawing.Size(49, 16);
                checkBox.Text = arPathWorkspace[i, 0];
                checkBox.UseVisualStyleBackColor = true;
                checkBox.CheckedChanged += new System.EventHandler(this.cbChildSystem_CheckedChanged);
                this.Controls.Add(checkBox);
                checkBox.BringToFront();  
                if (Settings.Default.selectedSystem.Contains(checkBox.Text)) checkBox.Checked = true;
                this.Text = this.Text.Replace("ReleaseHelper", "ReleaseHelper_" + arPathWorkspace[i, 0]);
                Settings.Default.selectedSystem = arPathWorkspace[i, 0];
            }//for

            CheckBox ckbPrevFileType = null;
            for (int i = 0; i < fileTypeForSearch.Length; i++)
            {
                CheckBox checkBox = new CheckBox();

                checkBox.AutoSize = true;
                if (ckbPrevFileType == null) checkBox.Location = new System.Drawing.Point(220, 12);
                else checkBox.Location = new System.Drawing.Point(ckbPrevFileType.Location.X+ckbPrevFileType.Width+20  , 12);

                checkBox.Name = "cbChildFileType" + i;
                checkBox.Size = new System.Drawing.Size(49, 16);
                checkBox.Text = fileTypeForSearch[i];
                checkBox.UseVisualStyleBackColor = true;
                checkBox.CheckedChanged += new System.EventHandler(this.cbChildFileType_CheckedChanged);
                this.Controls.Add(checkBox);
                checkBox.BringToFront();
                ckbPrevFileType = checkBox;
                if (Settings.Default.selectedFileType.Contains(checkBox.Text)) checkBox.Checked = true;
            }//for
            this.ResumeLayout(false);
            this.PerformLayout();
            IsloadedCheckBoxes = true;
        }//setCheckBoexes

        private void btnDoc_Click(object sender, EventArgs e)
        {
            FrmDocument pop = new FrmDocument(tbxCsrId.Text, targetFolder, parser);
            if (DialogResult.OK == pop.ShowDialog())
            {
                
            }
        }


        #endregion

        //sourceClass 파일과 targetClass 파일을 디컴파일 한 다음 자바 경로를 리턴한다.
        private string[] decompileJava(string targetClass)
        {
            string sourceClass = targetClass.Replace(@"\backup","");
            FileInfo fi = new FileInfo(targetClass);
            string[] result = new string[2];
            Process p = new Process();
            ProcessStartInfo pinfo = new ProcessStartInfo();
            p.StartInfo = pinfo;
            pinfo.FileName = "CMD.exe";
            pinfo.WindowStyle = ProcessWindowStyle.Hidden;
            pinfo.CreateNoWindow = true;
            pinfo.UseShellExecute = false;

            pinfo.RedirectStandardInput = true;
            pinfo.RedirectStandardError = true;
            pinfo.RedirectStandardOutput = true;
            p.EnableRaisingEvents = false;
            p.Start();
            
            string execSource = "";
            string execTarget = "";
            if (string.IsNullOrEmpty(parser.DecompilerPath)) {
                MessageBox.Show("(디컴파일러경로)가 설정되어있지 않습니다.");
                return result;
            }
            string tempSourceFolderPath = targetFolder + @"\temp\source";
            string tempTargetFolderPath = targetFolder + @"\temp\target";

            try { Directory.Delete(tempSourceFolderPath, true); } catch {;}
            try{ Directory.Delete(tempTargetFolderPath, true); } catch {; }
            Directory.CreateDirectory(tempSourceFolderPath);
            Directory.CreateDirectory(tempTargetFolderPath);
            try { execSource = string.Format(@"java -jar ""{0}"" -od ""{1}"" ""{2}""", parser.DecompilerPath, tempSourceFolderPath, sourceClass); }
            catch(Exception e) { MessageBox.Show(e.Message); }

            try { execTarget = string.Format(@"java -jar ""{0}"" -od ""{1}"" ""{2}""", parser.DecompilerPath, tempTargetFolderPath, targetClass); }
            catch (Exception e) { MessageBox.Show(e.Message); }

            p.StandardInput.WriteLine(execSource);
            p.StandardInput.WriteLine(execTarget);
            p.StandardInput.Close();

            p.WaitForExit();
            p.Close();

            result[0] = tempSourceFolderPath + @"\" + fi.Name.Replace(".class", ".java");    //source 자바경로
            result[1] = tempTargetFolderPath + @"\" + fi.Name.Replace(".class", ".java");    //target 자바경로
            return result;
        }
       

    }//Form1
}//namespace
