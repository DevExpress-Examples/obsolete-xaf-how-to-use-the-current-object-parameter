using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace CurrentObjectParameter.Win {
    public partial class CurrentObjectParameterWindowsFormsApplication : WinApplication {
        public CurrentObjectParameterWindowsFormsApplication() {
            InitializeComponent();
        }
        private void CurrentObjectParameterWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
