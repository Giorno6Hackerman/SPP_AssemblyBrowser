using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib
{
    public class Browser : BindableBase//, INotifyPropertyChanged
    {
        public AssemblyInfo Asm 
        { 
            get 
            { 
                return _asm; 
            }

            set
            {
                _asm = value;
                //OnPropertyChanged("Asm");
            }
        }

        private AssemblyInfo _asm;
        private string _path;

        public Browser(string path) 
        {
            _path = path;
        }

        public void BrowseAssembly()
        {
            Asm = new AssemblyInfo(_path);
        }
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }*/
    }
}
