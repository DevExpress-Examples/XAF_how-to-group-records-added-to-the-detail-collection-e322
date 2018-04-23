using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Collections.Generic;
using System.ComponentModel;

namespace TempCollection.Module {
    [DefaultClassOptions]
    [DefaultProperty("Description")]
    public class Order : BaseObject {
        private string _description;
        public Order(Session session) : base(session) { }
        Dictionary<string, int> dictionaryCore = null;
        public void CollectGroupingInfo() {
            Items.Sorting.Clear();
            Items.Sorting.Add(new SortProperty("Id", SortingDirection.Ascending));
            dictionaryCore = new Dictionary<string, int>();
            foreach (Item item in Items) {
                if (dictionaryCore.ContainsKey(item.Id)) {
                    dictionaryCore[item.Id] += item.Quantity;
                }
                else {
                    dictionaryCore.Add(item.Id, item.Quantity);
                }
            }
        }
        public void UpdateGrouping() {
            CollectGroupingInfo();
            Session.Delete(Items);
            foreach (KeyValuePair<string, int> pair in dictionaryCore) {
                Item newItem = new Item(Session);
                newItem.Id=pair.Key;
                newItem.Quantity = pair.Value;
                Items.Add(newItem);
            }
        }
        public string Description {
            get { return _description; }
            set { SetPropertyValue("Description", ref _description, value); }
        }
        [Association("RealAssociation", typeof(Item)), Aggregated]
        public XPCollection<Item> Items {
            get { return GetCollection<Item>("Items"); }
        }
    }
}