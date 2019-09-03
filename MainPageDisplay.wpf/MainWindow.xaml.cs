using ChronoCalendar;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ChronoCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainPageDisplayViewModel viewModel;
        public MainWindow()
        {
            viewModel = new MainPageDisplayViewModel();

            //NoteListView += ContentCollectionChanged;

            DataContext = viewModel;

            InitializeComponent();
        }

        private void CreateCalendarViewClick(object sender, RoutedEventArgs e)
        {
            var thing = new CalendarPage(viewModel.TimelineField);
            thing.Owner = this;
            thing.Show();
        }

        private void CreteFileViewerButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string currentPathDirectory = Path.GetDirectoryName(viewModel.FilePathField);
            openFileDialog.InitialDirectory = currentPathDirectory;
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != "")
            {
                viewModel.FilePathField = openFileDialog.FileName;
            }
        }
    }
}
