using NullableDatePickerTest.Controls;
using NullableDatePickerTest.UWP.Custom;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace NullableDatePickerTest.UWP.Custom
{
    public class NullableDatePickerRenderer : ViewRenderer<NullableDatePicker, Windows.UI.Xaml.Controls.Grid>
    {
        private CalendarDatePicker datePicker;
        private Windows.UI.Xaml.Controls.Button cancelButton;
        private Windows.UI.Xaml.Controls.Grid calendarView;

        protected override void OnElementChanged(ElementChangedEventArgs<NullableDatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control == null)
            {
                datePicker = new CalendarDatePicker();
                datePicker.MinDate = Element.MinimumDate;
                datePicker.MaxDate = Element.MaximumDate;
                datePicker.Date = Element.NullableDate;
                datePicker.DateChanged += DatePicker_DateChanged;

                cancelButton = new Windows.UI.Xaml.Controls.Button()
                {
                    Content = "Clear",
                    Margin = new Windows.UI.Xaml.Thickness(5),
                    Command = new Command(
                        () => datePicker.Date = null,
                        () => datePicker.Date != null)
                };

                calendarView = new Windows.UI.Xaml.Controls.Grid();
                calendarView.SizeChanged += CalendarView_SizeChanged;

                calendarView.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition()
                {
                    Width = new Windows.UI.Xaml.GridLength(0, Windows.UI.Xaml.GridUnitType.Auto)
                });

                calendarView.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition()
                {
                    Width = new Windows.UI.Xaml.GridLength(0, Windows.UI.Xaml.GridUnitType.Auto)
                });

                calendarView.Children.Add(datePicker);
                Windows.UI.Xaml.Controls.Grid.SetColumn(datePicker, 0);

                calendarView.Children.Add(cancelButton);
                Windows.UI.Xaml.Controls.Grid.SetColumn(cancelButton, 1);

                SetNativeControl(calendarView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == NullableDatePicker.NullableDateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
            {
                ((Command)cancelButton.Command).ChangeCanExecute();

                if (Element.NullableDate == null)
                {
                    datePicker.PlaceholderText = Element.NullPlaceholder;
                    datePicker.Date = null;
                    return;
                }
                else
                {
                    datePicker.Date = Element.NullableDate;
                }
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void DatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (Element != null)
            {
                Element.NullableDate = args.NewDate?.Date;
            }
        }

        private void CalendarView_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            if (Element != null)
            {
                // NOTE: Depending on the placeholder text, the width needed for the calendar view may be different
                Element.WidthRequest = e.NewSize.Width;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                datePicker.DateChanged -= DatePicker_DateChanged;
                datePicker = null;
                cancelButton = null;
                calendarView = null;
            }

            base.Dispose(disposing);
        }
    }
}