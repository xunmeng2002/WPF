using System;
using System.Collections.Generic;
using System.Text;

namespace DemoForTabControlBindingError
{
    
    public class Order : PropertyChangedNotify
    {
        private bool isSelected = false;
        private string type = "";
        private int reqid = 0;
        private int envno = 0;


        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;
                isSelected = value;
                OnPropertyChanged();
            }
        }
        public string Type {
            get => type;
            set
            {
                if (type == value)
                    return;
                type = value;
                OnPropertyChanged();
            }
        }
        public int Reqid
        {
            get => reqid;
            set
            {
                if (reqid == value)
                    return;
                reqid = value;
                OnPropertyChanged();
            }
        }
        public int Envno
        {
            get => envno;
            set
            {
                if (envno == value)
                    return;
                envno = value;
                OnPropertyChanged();
            }
        }
    }
}
