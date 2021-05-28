using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableDatePickerTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DateTime? _selectedDateTime;
        public DateTime? SelectedDateTime
        {
            get { return _selectedDateTime; }
            set { SetProperty(ref _selectedDateTime, value); }
        }

        public DelegateCommand<string> AddDaysCommand { get; private set; }
        public DelegateCommand SetDateNullCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AddDaysCommand = new DelegateCommand<string>(AddDays);
            SetDateNullCommand = new DelegateCommand(SetDateNull);

            Title = "Main Page";
            SelectedDateTime = null;
        }

        void AddDays(string numberOfDays)
        {
            double days;
            double.TryParse(numberOfDays, out days);
            if (SelectedDateTime.HasValue)
            {
                SelectedDateTime = SelectedDateTime.Value.AddDays(days);
            }
        }

        void SetDateNull()
        {
            SelectedDateTime = null;
        }
    }
}
