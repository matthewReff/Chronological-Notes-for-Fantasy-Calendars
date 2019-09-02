using ChronoCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronoCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalendarPage : Window
    {
        private CalendarPageViewModel viewModel;
        public CalendarPage()
        {
            viewModel = new CalendarPageViewModel();

            //NoteListView += ContentCollectionChanged;

            DataContext = viewModel;

            InitializeComponent();

            ReloadCalendar();
        }

        void ReloadCalendar()
        {
            int daysInMonth = 31;
            int daysInWeek = 7;
            int rowsAdded = 0;
            Grid grid = new Grid();
            grid.ShowGridLines = true;

            while(daysInMonth > 0)
            {
                daysInMonth -= daysInWeek;
                rowsAdded++;
            }

            for(int i = 0; i < rowsAdded; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for(int i = 0; i < daysInWeek; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for(int i = 0; i < rowsAdded; i++)
            {
                for(int j = 0; j < daysInWeek; j++)
                {
                    int currentTileIndex = i * daysInWeek + j;
                    Timeline derivedTimeline = viewModel.TimelineField.GetNotesFromDay(new Date(1, 1, currentTileIndex + 1));
                    CalendarTile tile = new CalendarTile(derivedTimeline);

                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);

                    grid.Children.Add(tile);
                }
            }

            CalendarViewContent.Content = grid;
        }

    }

}
