using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand OpenDialog { get; set; }

        public Dispatcher DialogDispatcher { get; set; }

        public MainWindow()
        {
            DialogDispatcher = MyDispatcher.StartNew();
            OpenDialog = new RelayCommand(PromptDialog);
            DataContext = this;
            InitializeComponent();
        }

        private void PromptDialog(object obj)
        {
            DialogDispatcher.Invoke(new Action(() =>
            {
                // Dialog erstellen und anzeigen
                DialogWindow dialog = new();
                dialog.ShowDialog();
            }));
        }

        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
