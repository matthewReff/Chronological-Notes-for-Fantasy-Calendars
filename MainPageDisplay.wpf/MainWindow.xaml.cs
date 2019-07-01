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

            //NoteListView += ContentCollectionChanged;

            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
