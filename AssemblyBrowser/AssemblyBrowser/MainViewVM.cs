using System.ComponentModel;
using AssemblyBrowserLib;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Microsoft.Win32;
using Prism.Mvvm;

namespace AssemblyBrowser
{
    public class MainViewVM : BindableBase//INotifyPropertyChanged
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
                //OnPropertyChanged("Path");
            }
        }

        public MainViewVM()
        {
            GetInfoCommand = new DelegateCommand(() =>
            {
                Path = GetFilePath();
                _browser = new Browser(_path);
                _browser.BrowseAssembly();
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

        public AssemblyInfo AsmInfo => _browser?.Asm;

        public DelegateCommand GetInfoCommand { get; }
        /*public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }*/
    }
}
