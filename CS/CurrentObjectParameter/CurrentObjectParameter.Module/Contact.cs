using System;
using System.ComponentModel;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace CurrentObjectParameter.Module {
    [DefaultClassOptions]
    public class Contact : BaseObject {
        public Contact(Session session) : base(session) { }

        public string Name {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }

        [Association("Contact-Department")]
        public Department Department {
            get { return GetPropertyValue<Department>("Department"); }
            set { SetPropertyValue<Department>("Department", value); }
        }

        [DataSourceCriteria("Department = '@This.Department'")]
        public Position Position {
            get { return GetPropertyValue<Position>("Position"); }
            set { SetPropertyValue<Position>("Position", value); }
        }
    }

    [DefaultClassOptions]
    public class Position : BaseObject {
        public Position(Session session) : base(session) { }

        public string Title {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue<string>("Title", value); }
        }

        [Association("Department-Position", typeof(Department))]
        public Department Department {
            get { return GetPropertyValue<Department>("Department"); }
            set { SetPropertyValue<Department>("Department", value); }
        }
    }

    [DefaultClassOptions]
    public class Department : BaseObject {
        public Department(Session session) : base(session) { }

        public string Title {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue<string>("Title", value); }
        }

        [Association("Contact-Department", typeof(Contact))]
        public XPCollection Contacts {
            get { return GetCollection("Contacts"); }
        }

        [Association("Department-Position", typeof(Position))]
        public XPCollection Positions {
            get { return GetCollection("Positions"); }
        }
    }

}
