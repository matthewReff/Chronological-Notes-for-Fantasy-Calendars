using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using DataAccessors;
using DataStructures;
using MainPageDisplayViewModelNamespace;

namespace MainPageDisplay.wpf
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
            
            DataContext = viewModel;
            InitializeComponent();
        }

        /*
        public void CreateNoteFromFields()
        {
            viewModel.TempList.Add(new Note { Title = viewModel.TitleField, Content = viewModel.ContentField, Date = new Date
            {
                year = 1,
                month = 1,
                day = 1,
                time = new Time
                {
                    hours = 0,
                    minutes = 0
                }
            }
            });

        }
        public void LoadTimelineFromFile()
        {
            DataAccessor data = new DataAccessor(viewModel.FilePathField);
            Timeline timeline = new Timeline();
            data.LoadTimeline(out timeline);
            viewModel.TimelineField = timeline;
        }
        */
    }
}
