using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using AssemblyBrowserLib;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Microsoft.Win32;

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
            GetInfoCommand = new DelegateCommand(() =>
            {
                Path = GetFilePath();
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

        public AssemblyInfo AsmInfo => _browser.Asm;

        public DelegateCommand GetInfoCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
