using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChronoCalendar
{
    public class NoteDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
        SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is Note)
            {
                Note noteItem = item as Note;

                if (noteItem.Date.minute == null)
                    return
                        element.FindResource("TruncatedNoteTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("FullNoteTemplate") as DataTemplate;
            }

            return null;
        }
    }
    
}
