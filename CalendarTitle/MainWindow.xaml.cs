using ChronoCalendar;
using System.Windows;
using System.Windows.Controls;

namespace CalendarTile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalendarTile : UserControl
    {
        CalendarTileViewModel ViewModel;

        public CalendarTile()
        {
            ViewModel = new CalendarTileViewModel();

            //NoteListView += ContentCollectionChanged;

            DataContext = ViewModel;

            InitializeComponent();
        }
    }
}
