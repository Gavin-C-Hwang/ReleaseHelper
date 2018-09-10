using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;

namespace ReleaseHelper
{
    public class TextParser
    {
        string[] fileColumns = {"시스템이름"
                               ,"로컬프로젝트경로"
                               ,"개발망프로젝트경로" 
                               ,"운영프로젝트경로"
                               };
        string fileTypeColumn = "검색파일종류";
        string editableFolderPathColumn = "폴더경로조정";
        string targetFolderColumn = "반영폴더경로";
        string javaPathColumn = "자바파일경로";
        string classPathColumn = "클래스파일경로";
        string compareToolPathColumn = "비교툴경로";
        string decompilerPathColumn = "디컴파일러경로";
        string utUserColumn = "단위테스트유저";
        string otUserColumn = "3자테스트유저";
        string rtUserColumn = "사용자테스트유저";
        ArrayList systemsInfo;
        string[] fileTypeForSearch;
        Hashtable editableFolders = new Hashtable();
        string targetFolder;
        string javaPath;
        string classPath;
        string compareToolPath;
        string decompilerPath;
        string utUser;
        string otUser;
        string rtUser;

        public ArrayList SystemsInfo 
        {
            get { return systemsInfo; }
        }

        public string[] FileColumns
        {
            get { return fileColumns; }
        }//FileColumns

        public string[] FileTypeForSearch
        {
            get { return fileTypeForSearch; }
        }//FileType

        public string TargetFolder
        {
            get { return targetFolder; }
        }//TargetFolder

        public String JavaPath
        {
            get { return javaPath; }
        }

        public String ClassPath
        {
            get { return classPath; }
        }

        public String CompareToolPath
        {
            get { return compareToolPath; }
        }

        public String DecompilerPath
        {
            get { return decompilerPath; }
        }

        public String UtUser
        {
            get { return utUser; }
        }

        public String OtUser
        {
            get { return otUser; }
        }

        public String RtUser
        {
            get { return rtUser; }
        }

        public string[,] EditableFolders 
        {
            get 
            {
                string[,] result = new string[editableFolders.Count, 2];

                int inx = 0;
                foreach (DictionaryEntry pair in editableFolders)
                {
                    result[inx, 0] = (string)pair.Key;
                    result[inx, 1] = (string)pair.Value;
                    inx++;
                }
                return result; 
            }
        }//EditableFolders

        public ArrayList parse()
        {
            systemsInfo = new ArrayList();
            //StreamReader streamReader = new StreamReader("./Settings.txt");
            StringReader streamReader = new StringReader(ReleaseHelper.Properties.Settings.Default.projectsInfo);
            
            string line;
            Hashtable row = new Hashtable();
            bool toggleEditableFolders = false;
            while( (line = streamReader.ReadLine()) != null )
            {
                //line = line.Replace(" ","");
                line = getValidLine(line);

                if ("".Equals(line)) continue;
                if (line.StartsWith("//")) continue;

                    //검색파일종류 파싱
                    if (line.Contains(fileTypeColumn))
                {
                    line = line.Replace(fileTypeColumn + ":", "");
                    fileTypeForSearch = line.Split(',');
                    continue;
                }//if

                //반영폴더경로 파싱
                if (line.Contains(targetFolderColumn))
                {
                    line = line.Replace(targetFolderColumn + ":", "");
                    targetFolder = line;
                    continue;
                }//if

                //자바소스경로 파싱
                if (line.Contains(javaPathColumn))
                {
                    line = line.Replace(javaPathColumn + ":", "");
                    javaPath = line;
                    continue;
                }//if

                //클래스경로 파싱
                if (line.Contains(classPathColumn))
                {
                    line = line.Replace(classPathColumn + ":", "");
                    classPath = line;
                    continue;
                }//if

                //비교툴경로 파싱
                if (line.Contains(compareToolPathColumn))
                {
                    line = line.Replace(compareToolPathColumn + ":", "");
                    compareToolPath = line;
                    continue;
                }//if

                //디컴파일러경로 파싱
                if (line.Contains(decompilerPathColumn))
                {
                    line = line.Replace(decompilerPathColumn + ":", "");
                    decompilerPath = line;
                    continue;
                }//if

                //단위테스트유저 파싱
                if (line.Contains(utUserColumn))
                {
                    line = line.Replace(utUserColumn + ":", "");
                    utUser = line;
                    continue;
                }//if

                //3자테스트유저 파싱
                if (line.Contains(otUserColumn))
                {
                    line = line.Replace(otUserColumn + ":", "");
                    otUser = line;
                    continue;
                }//if

                //사용자테스트유저 파싱
                if (line.Contains(rtUserColumn))
                {
                    line = line.Replace(rtUserColumn + ":", "");
                    rtUser = line;
                    continue;
                }//if

                //폴더경로조정 만나면 그 밑으로는 폴더경로조정에 대한 것으로 간주함.
                if (line.Contains(editableFolderPathColumn))
                {
                    toggleEditableFolders = true;
                    continue;
                }//if
                //폴더경로조정 스위치가 켜져있으면
                if (toggleEditableFolders)
                {
                    string[] editableFolder = line.Split(':');
                    editableFolders[editableFolder[1] == "" ? "\\"+editableFolder[0] : editableFolder[0]] = editableFolder[1];
                    continue;

                }//if

                for (int i = 0; i < fileColumns.Length; i++)
                {
                    if (line.Contains(fileColumns[i]))
                    {
                        string columnValue = Regex.Replace(line, @"[0-9]*\.*?" + fileColumns[i] + ":", ""); 
                           // line.Replace(fileColumns[i] + ":", "");
                        row[ Regex.Replace(fileColumns[i],@"[0-9]+\.","")] = columnValue;

                        if (row.Count == fileColumns.Length) 
                        {
                            systemsInfo.Add(row);
                            row = new Hashtable();  
                        }//if
                        continue;   
                    }//if
                }//for
            }//while

            streamReader.Close();

            return systemsInfo;
        }//parse

        public string getClassPath(string projectPath) 
        {
            try
            {
                string classPath = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(projectPath + "\\.classpath");
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if ("output".Equals(node.Attributes["kind"].InnerText))
                    {
                        classPath = node.Attributes["path"].InnerText;
                        break;
                    }//if
                }//foreach

                return (classPath == ""?ClassPath:classPath.Replace('/','\\'));
            }//try
            catch (Exception err)
            {
                return ClassPath;
            }//catch
            
        }//getClassPath

        public string getSrcPath(string projectPath)
        {
            try
            {
                string srcPath = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(projectPath + "\\.classpath");
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if ("src".Equals(node.Attributes["kind"].InnerText))
                    {
                        srcPath = node.Attributes["path"].InnerText;
                        break;
                    }
                }
                return (srcPath==""?JavaPath:srcPath.Replace('/', '\\'));
            }//try
            catch (Exception err)
            {
                return JavaPath;
            }//catch
            
        }//getClassPath


        public string getValidLine(string line)
        {
            char[] separater = { ':' };
            string[] data = line.Split(separater, 2);

            if (data.Length == 1) return line;


            string header = data[0].Replace(" ","");
            string value = data[1].Trim();

            return header +":" +value;

        
        
        }
    }//TextParser
}//ReleaseHelper
