using MainPageDisplayViewModelNamespace;
using System.Windows;

namespace CalendarTile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalendarTileViewModel ViewModel;

        public MainWindow()
        {
            ViewModel = new CalendarTileViewModel();

            //NoteListView += ContentCollectionChanged;

            DataContext = ViewModel;

            InitializeComponent();
        }
    }
}
