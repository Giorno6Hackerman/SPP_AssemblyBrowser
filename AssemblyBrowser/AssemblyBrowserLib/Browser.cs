using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib
{
    public class Browser : INotifyPropertyChanged
    {
        public AssemblyInfo Asm 
        { 
            get 
            { 
                return _asm; 
            }

            set
            {
                Asm = value;
                OnPropertyChanged("Asm");
            }
        }

        private AssemblyInfo _asm;
        private string _path;

        public Browser(string path) 
        {
            _asm = new AssemblyInfo(path);
        }

        public void BrowseAssembly()
        {
            Asm = _asm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
