using App2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App2.Connection
{
    public class BasketUser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static Matheboard matheboarduser;
        public static Processor processoruser;
        public static Videocards videocarduser;
        public static Rams ramuser;
        public static PowerCases powercaseuser;
        public static Cases casesuser;
        public static HardDisks hdduser;
        public static SolidStateDrives ssduser;
        public static M2 m2user;
        
        //    public static Matheboard matheboardUser;
        //    public string MatheboardUser
        //    {
        //        get
        //        {
        //          return matheboardUser.MatheboardName;
        //        }
        //        set
        //        {
        //            matheboardUser.MatheboardName = value;
        //            OnPropertyChanged("MatheboardUser");
        //        }
        //    }
        //    public BasketUser()
        //    {
        //        if(DesignMode.IsDesignModeEnabled)
        //        {
        //            this.MatheboardUser = matheboardUser.MatheboardName;
        //        }
        //    }
        //    private void OnPropertyChanged(string propertyName)
        //    {
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //        }
        //    }


    }
}
