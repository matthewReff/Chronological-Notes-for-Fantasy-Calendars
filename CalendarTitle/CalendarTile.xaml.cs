using ChronoCalendar;
using System.Windows;
using System.Windows.Controls;

namespace ChronoCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalendarTile : UserControl
    {
        CalendarTileViewModel viewModel;

        public CalendarTile(Timeline timeline)
        {

            viewModel = new CalendarTileViewModel(timeline);

            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
