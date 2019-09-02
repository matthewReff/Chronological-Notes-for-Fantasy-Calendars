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

            DependencyPropertyDescriptor.FromProperty(DisplayedDateProperty, typeof(DateDisplay))
               .AddValueChanged(this, OnDateChanged);
        }



        public static readonly DependencyProperty DisplayedDateProperty =
        DependencyProperty.Register
            (
            nameof(DisplayedDate),
            typeof(Date),
            typeof(DateDisplay),
            new FrameworkPropertyMetadata
                (
                    null
                )
            );


        public Date DisplayedDate
        {
            get { return (Date)GetValue(DisplayedDateProperty); }
            set { SetValue(DisplayedDateProperty, value); }
        }

        private void OnDateChanged(object sender, EventArgs e)
        {
            string content = "";
            if(DisplayedDate != null)
            {
                content += DisplayedDate.year.ToString();
                content += "\\";
                content += DisplayedDate.month.ToString();
                content += "\\";
                content += DisplayedDate.day.ToString();
                if(DisplayedDate.hour != null)
                {
                    content += " ";
                    content += DisplayedDate.hour.ToString();
                    content += ":";
                    content += DisplayedDate.minute.ToString();
                }
            }

            dateDisplayText.Text = content;
        }
    }
}
