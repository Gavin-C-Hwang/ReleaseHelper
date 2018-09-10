using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ReleaseHelper
{
    public partial class FrmDocument : Form
    {
        string csrId, targetFolder, operTask, secureYn, currentFunc, modifiedFunc, reviewDate, csrDoc, comments, unitTest, csrType = "rdCsrDb";
        TextParser parser;
        string linefeed = "줄을바꾼다xhdtlswk7";


        public FrmDocument(string csrId, string targetFolder, TextParser parser)
        {
            InitializeComponent();
            this.csrId = csrId;
            this.targetFolder = targetFolder;
            this.parser = parser;
          
        }

        private void FrmDocument_Load(object sender, EventArgs e)
        {
            tbxUnitTest.Text = tbxUnitTest.Text.Replace("UT-3264902-20160111-01", "UT-" + csrId + "-" + DateTime.Now.ToString("yyyyMMdd") + "-01");
            
            loadFile(targetFolder, csrId);

            tbxUnitTest.Text = tbxUnitTest.Text.Replace("황철(78068)",parser.UtUser);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(targetFolder + "\\DOC");
            System.IO.FileStream file_stream = new FileStream(targetFolder+"\\DOC\\CSR_"+csrId+"_doc.txt", FileMode.Create, FileAccess.Write);

            StreamWriter psWriter = new StreamWriter(file_stream, System.Text.Encoding.Default);
            
            string text = string.Format("#csrType={0}\r\n", csrType);
            text += string.Format("#tbxCustReq={0}\r\n", tbxCustReq.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxAcceptComments={0}\r\n", tbxAcceptComments.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxCurrentFunc={0}\r\n", tbxCurrentFunc.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxModifiedFunc={0}\r\n", tbxModifiedFunc.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxBuildDetail={0}\r\n", tbxBuildDetail.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxDevDetail={0}\r\n", tbxDevDetail.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxUnitTest={0}\r\n", tbxUnitTest.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxBeforeReview={0}\r\n", tbxBeforeReview.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxAcception={0}\r\n", tbxAcception.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxAnal={0}\r\n", tbxAnal.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxDevReview={0}\r\n", tbxDevReview.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxDevelop={0}\r\n", tbxDevelop.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxUnit={0}\r\n", tbxUnit.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxOther={0}\r\n", tbxOther.Text.Replace("\r\n", linefeed));
            text += string.Format("#tbxRealUser={0}\r\n", tbxRealUser.Text.Replace("\r\n", linefeed));
           

            psWriter.WriteLine(text);

            psWriter.Close();

            MessageBox.Show("complete");

        }

        private void loadFile(string targetFolder, string csrId) 
        {
            System.IO.StreamReader file = null;

            try
            {
                file = new System.IO.StreamReader(targetFolder + "\\DOC\\CSR_" + csrId + "_doc.txt", System.Text.Encoding.Default);
            }
            catch (FileNotFoundException e) {
                return;
            }
           
            string line = "";
            string contents = "";
            TextBox currentControl = new TextBox();
            while ((line = file.ReadLine()) != null)
            {
                line = line + "\r\n";
                if(line.Contains("#csrType="))
                {
                    line = line.Replace("#csrType=", "").Trim();
                    if (line == "rdCsrDb") rdCsrDb.Checked = true;
                    else if (line == "rdCsrModifyProgram") rdCsrModifyProgram.Checked = true;
                    else if (line == "rdCsrModifyFunction") rdCsrModifyFunction.Checked = true; 
                }
                else if (line.Contains("#tbxCustReq="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxCustReq;
                    line = line.Replace("#tbxCustReq=", "").Replace(linefeed,"\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxAcceptComments="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxAcceptComments;
                    line = line.Replace("#tbxAcceptComments=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxCurrentFunc="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxCurrentFunc;
                    line = line.Replace("#tbxCurrentFunc=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxModifiedFunc="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxModifiedFunc;
                    line = line.Replace("#tbxModifiedFunc=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxBuildDetail="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxBuildDetail;
                    line = line.Replace("#tbxBuildDetail=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxDevDetail="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxDevDetail;
                    line = line.Replace("#tbxDevDetail=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxUnitTest="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxUnitTest;
                    line = line.Replace("#tbxUnitTest=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxBeforeReview="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxBeforeReview;
                    line = line.Replace("#tbxBeforeReview=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxAcception="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxAcception;
                    line = line.Replace("#tbxAcception=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxAnal="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxAnal;
                    line = line.Replace("#tbxAnal=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxDevReview="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxDevReview;
                    line = line.Replace("#tbxDevReview=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxDevelop="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxDevelop;
                    line = line.Replace("#tbxDevelop=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxUnit="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxUnit;
                    line = line.Replace("#tbxUnit=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxOther="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxOther;
                    line = line.Replace("#tbxOther=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else if (line.Contains("#tbxRealUser="))
                {
                    currentControl.Text = contents;
                    contents = "";
                    currentControl = tbxRealUser;
                    line = line.Replace("#tbxRealUser=", "").Replace(linefeed, "\r\n");
                    contents += line;
                }
                else
                {
                    contents += line;
                }
               
            }
            currentControl.Text = contents;
            contents = "";

            file.Close();

            tbxFinish.Text = tbxFinish.Text.Replace("황철(78068)", parser.UtUser);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;   
        }


        private void rdCsrDb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            string name = radio.Name;
            if (radio.Checked) {
                csrType = name;
            } 
            
        }

        private void tbxDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            switch (csrType) 
            {
                case "rdCsrDb":
                    operTask = "데이터 수정";
                    secureYn = "N";
                    csrDoc = "데이터 수정 쿼리";
                    comments = "쿼리 실행 후 데이터 변경되었음을 확인하였습니다.";
                    break;
                case "rdCsrModifyProgram":
                    operTask = "프로그램 수정";
                    secureYn = "Y";
                    csrDoc = "프로그램 소스";
                    comments = "프로그램 소스 검토 결과 이상없음을 확인하였습니다.";
                    break;
                case "rdCsrModifyFunction":
                    operTask = "프로그램 수정";
                    secureYn = "Y";
                    csrDoc = "프로그램 소스";
                    comments = "프로그램 소스 검토 결과 이상없음을 확인하였습니다.";
                    break;
                default:
                    break;
            
            }

            currentFunc = tbxCurrentFunc.Text;
            modifiedFunc = tbxModifiedFunc.Text;
            reviewDate = DateTime.Now.ToString("yyyy-MM-dd") + " 09:00 ~ 09:30";
            unitTest = tbxUnitTest.Text;

            tbxBeforeReview.Text = string.Format(
                      "1. 요청사항 : {0}"
                + "\r\n2. 영향받는 타 시스템(모바일 포함, 없는 경우 N/A) : N/A"
                + "\r\n3. CSR발생원인 : 업무협조요청"
                + "\r\n4. 작업내용 : {1}"
                + "\r\n5. 영향평가의견 및 기타(단순CSR인 경우 N/A, GSI 영향범위) : N/A"
                + "\r\n6. 보안자가점검 필요여부(Y/N) : {2}"
                , tbxCustReq.Text
                , operTask
                , secureYn
            );

            tbxAcception.Text = string.Format(
                      "1. 접수의견 : {0}"
                + "\r\n"
                + "\r\n2. 요구사항정의"
                + "\r\n . 현재기능(AS-IS) : {1}"
                + "\r\n . 변경사항(TO-BE) : {2}"
                + "\r\n . 제약사항(Constraints) : N/A"
                + "\r\n . 해결방안(Solutions) : {3}"
                ,tbxAcceptComments.Text
                ,tbxCurrentFunc.Text
                ,tbxModifiedFunc.Text
                ,operTask 
            );

            tbxAnal.Text = string.Format(
                      "1. 현재기능(AS-IS) : {0}"
                + "\r\n2. 변경사항(TO-BE) : {1}"
                + "\r\n3. 제약사항(Constraints) : N/A"
                + "\r\n4. 해결방안(Solutions) : {2}"
                ,tbxCurrentFunc.Text
                ,tbxModifiedFunc.Text
                ,operTask
            );

            tbxDevReview.Text = string.Format(
                      "- 검토일시: {0}"
                + "\r\n- 검토대상산출물: {1}"
                + "\r\n- 의견: {2}"   
                ,reviewDate
                ,csrDoc
                ,comments
            );

            tbxDevelop.Text = string.Format(
                      "- 설계 내역"
                + "\r\n  . 변경대상 산출물명 : N/A"
                + "\r\n  . 테스트케이스 작성 완료(Y/N) : Y"
                + "\r\n  . 단위테스트케이스-보안자가점검 작성 완료 여부(Y/N 여부 또는 N/A) : {0}"
                + "\r\n  . 상세내용 "
                + "\r\n    {1}"
                + "\r\n- 개발 내역"
                + "\r\n  . 상세내용(접수 단계의 AS-IS, TO-BE 요약을 중복 기록하지 말 것) : "
                + "\r\n    {2}"
                ,secureYn
                ,tbxBuildDetail.Text
                ,tbxDevDetail.Text
            );

            tbxUnit.Text = tbxUnitTest.Text;
            tbxOther.Text = tbxUnitTest.Text.Replace("UT-", "OT-")
                .Replace(parser.UtUser, parser.OtUser);
            tbxRealUser.Text = tbxUnitTest.Text
                .Replace("UT-", "RT-")
                .Replace(parser.UtUser, parser.RtUser);

            tbxFinish.Text = tbxFinish.Text.Replace("황철(78068)", parser.UtUser);

        }//end btnConvert_Click
    }
}
