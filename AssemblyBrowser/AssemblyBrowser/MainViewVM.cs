using System.ComponentModel;
using AssemblyBrowserLib;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Microsoft.Win32;
using Prism.Mvvm;

namespace AssemblyBrowser
{
    public class MainViewVM : /*BindableBase*/INotifyPropertyChanged
    {
        //private Browser _browser;
        private AssemblyInfo _asm;
        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value ?? _path;
                OnPropertyChanged("Path");
            }
        }

        public MainViewVM()
        {
            GetInfoCommand = new DelegateCommand(() =>
            {
                Path = GetFilePath();
                if(Path != null)
                    AsmInfo = new AssemblyInfo(_path);
                //_browser.BrowseAssembly();
            });
        }

        private string GetFilePath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Assembly| *.dll";
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }

        public AssemblyInfo AsmInfo
        {
            get
            {
                return _asm;
            }

            set
            {
                _asm = value;
                OnPropertyChanged("AsmInfo");
            }
        }

        public DelegateCommand GetInfoCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
