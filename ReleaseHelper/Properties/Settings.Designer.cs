﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReleaseHelper.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"1. 시스템이름             : MFG
2. 로컬프로젝트경로    : C:\Users\78068\workspace\ezmweb
3. 개발망프로젝트경로 : \\10.77.14.98\jeus_lgcns.mfg
4. 운영프로젝트경로    : \\165.244.227.178\jeus_mfg

1. 시스템이름             : MFG-P
2. 로컬프로젝트경로    : C:\Users\78068\workspace\lgmweb
3. 개발망프로젝트경로 : \\10.77.14.98\jeus_lgcns.mfg.partner
4. 운영프로젝트경로    : \\165.244.227.178\jeus_mfgpartner

1. 시스템이름             : PLM
2. 로컬프로젝트경로    :C:\Users\78068\workspace\PLM_dev
3. 개발망프로젝트경로 : ftp://10.62.2.36, wasadm, !dev2011!, dynamoad/bea81/user_projects/domains/pdmdomain/applications
4. 운영프로젝트경로    :

1. 시스템이름            : TIMS
2.로컬프로젝트경로    : C:\lte\eclipse\workspace\CaMaS
3.개발망프로젝트경로 : 
4.운영프로젝트경로    :

1. 시스템이름            : SQL
2.로컬프로젝트경로    : C:\Users\78068\workspace\ezmweb\Project Doc\90.Shared Doc\02.U-MFG\황철\10.쿼리
3.개발망프로젝트경로 : 
4.운영프로젝트경로    :

검색파일종류:*,xrw,jsp,js,xml,java,sql

반영폴더경로:D:황철업무폴더\반영폴더

폴더경로조정
devonhome:WEB-INF\devonhome
web:")]
        public string projectsInfo {
            get {
                return ((string)(this["projectsInfo"]));
            }
            set {
                this["projectsInfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string selectedSystem {
            get {
                return ((string)(this["selectedSystem"]));
            }
            set {
                this["selectedSystem"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string selectedFileType {
            get {
                return ((string)(this["selectedFileType"]));
            }
            set {
                this["selectedFileType"] = value;
            }
        }
    }
}
