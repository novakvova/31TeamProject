using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private string fName;
        public string FirstName
        {
            get { return this.fName; }
            set
            {
                if (this.fName != value)
                {
                    this.fName = value;
                    this.NotifyPropertyChanged("FirstName");
                }
            }
        }

        private string lName;
        public string LastName
        {
            get { return this.lName; }
            set
            {
                if (this.lName != value)
                {
                    this.lName = value;
                    this.NotifyPropertyChanged("LastName");
                }
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
