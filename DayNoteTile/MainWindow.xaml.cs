using MainPageDisplayViewModelNamespace;
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

namespace DayNoteTile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalendarPageViewModel viewModel;
        public MainWindow()
        {
            viewModel = new CalendarPageViewModel();

            //NoteListView += ContentCollectionChanged;
            DataContext = viewModel;

            InitializeComponent();


            TextBlock textBlock = new TextBlock();
            textBlock.Text = "AAAAAAA";
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.VerticalAlignment = VerticalAlignment.Stretch;
            textBlock.Width = 1000;
            textBlock.Height = 1000;
            temp = textBlock;

            //calendarGrid.Children.Add(textBlock);
        }
    }
}
