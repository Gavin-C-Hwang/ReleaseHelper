using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReleaseHelper.Properties;

namespace ReleaseHelper
{
    public partial class FmSettingsP : Form
    {

        string projectsInfo;

        public FmSettingsP()
        {
            InitializeComponent();
            projectsInfo = Settings.Default.projectsInfo; 
        }

        private void FmSettingsP_Load(object sender, EventArgs e)
        {
            tbxSettings.Text = projectsInfo;   
        }
        private void FmSettingsP_Shown(object sender, EventArgs e)
        {
            tbxSettings.Select(0,0);
        }

        private void tbxSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    tbxSettings.SelectAll();
                }//if
            }//if
        }//tbxSettings_KeyDown

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.projectsInfo = tbxSettings.Text;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
        }//btnSave_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }//btnCancel_Click



 
    }//FmSettingsP
}//ReleaseHelper
