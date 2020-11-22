using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using AssemblyBrowserLib;
using System.Runtime.CompilerServices;

namespace AssemblyBrowser
{
    class MainViewVM : INotifyPropertyChanged
    {
        private Browser _browser;
        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                _browser = new Browser(_path);
                OnPropertyChanged("Path");
            }
        }

        public MainViewVM()
        {
            
        }

        public AssemblyInfo AsmInfo => _browser.Asm;
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
