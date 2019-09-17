using ChronoCalendar;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ChronoCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DateDisplay : UserControl
    {
        public DateDisplay()
        {
            InitializeComponent();

        }

        public static readonly DependencyProperty DisplayedDateProperty =
        DependencyProperty.Register
            (
            nameof(DisplayedDate),
            typeof(Date),
            typeof(DateDisplay),
            new PropertyMetadata(null, new PropertyChangedCallback(OnChange))
            );


        public Date DisplayedDate
        {
            get { return (Date)GetValue(DisplayedDateProperty); }
            set { SetValue(DisplayedDateProperty, value); }
        }

        private static void OnChange(DependencyObject d,
         DependencyPropertyChangedEventArgs e)
        {
            DateDisplay UserControl1Control = d as DateDisplay;
            UserControl1Control.SecondLayerChanged(e);
        }
        private void SecondLayerChanged(DependencyPropertyChangedEventArgs e)
        {
            string content = "";
            if (DisplayedDate != null)
            {
                content += DisplayedDate.Year.ToString();
                content += "\\";
                content += DisplayedDate.Month.ToString();
                content += "\\";
                content += DisplayedDate.Day.ToString();
                if (DisplayedDate.Hour != null)
                {
                    content += " ";
                    content += DisplayedDate.Hour.ToString();
                    content += ":";
                    content += DisplayedDate.Minute.ToString();
                }
            }

            dateDisplayText.Text = content;
        }

    }
}
