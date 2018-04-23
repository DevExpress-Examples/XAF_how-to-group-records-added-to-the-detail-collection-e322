using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace TempCollection.Module.Win {
    public partial class ViewController1 : ViewController {
        public ViewController1() {
            InitializeComponent();
            RegisterActions(components);
            TargetViewId = "Order_DetailView";
        }
        protected override void OnActivated() {
            base.OnActivated();
            ObjectSpace.Committing += new EventHandler<CancelEventArgs>(ObjectSpace_Committing);
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            ObjectSpace.Committing -= new EventHandler<CancelEventArgs>(ObjectSpace_Committing);
        }
        void ObjectSpace_Committing(object sender, CancelEventArgs e) {
            Order obj = (Order)View.CurrentObject;
            obj.UpdateGrouping();
        }
    }
}
