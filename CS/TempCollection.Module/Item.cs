using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace TempCollection.Module {
    [DefaultClassOptions]
    [DefaultProperty("Id")]
    public class Item : BaseObject {
        private string _id;
        private int _quantity;
        private Order _Order;
        public Item(Session session)
            : base(session) {
        }
        public string Id {
            get { return _id; }
            set {
                SetPropertyValue("Id", ref _id, value);
            }
        }
        public int Quantity {
            get { return _quantity; }
            set {
                SetPropertyValue("Quantity", ref _quantity, value);
            }
        }
        [Association("RealAssociation")]
        public Order Order {
            get { return _Order; }
            set { SetPropertyValue("Order", ref _Order, value); }
        }
    }
}