using Pomodoro_Technique_Android.Backend;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro_Technique_Android
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramContentPage : ContentPage
    {
        int currentPeriodInSeconds;
        int timesWork = 0;
        bool isWorking;

        public ProgramContentPage()
        {
            InitializeComponent();

            /* Set the <timeStarted> */
            DateTime dateCreated = DateTime.Now;
            string timeStarted = string.Format("{0}/{1} - {2}:{3}:{4}", dateCreated.Day, dateCreated.Month, dateCreated.Hour.ToString("00"), dateCreated.Minute.ToString("00"), dateCreated.Second.ToString("00"));
            this.LabelTimeStarted.Text = timeStarted;

            StartWork();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // called every 1 second
                this.currentPeriodInSeconds--;
                PrintTime();
                if (this.currentPeriodInSeconds == 0) {
                    if (isWorking)
                        StartBreak();
                    else
                        StartWork();
                }

                return true; // return true to repeat counting, false to stop timer
            });
        }

        #region Database
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
        #endregion

        /* Start the working period */
        private void StartWork()
        {
            DisplayAlert("Work period", "Time to put in some more work!", "OK");

            /* Set variables */
            this.currentPeriodInSeconds = 1500;
            this.timesWork++;
            this.isWorking = true;

            this.LabelPeriod.Text = "Work period";

            PrintTime(); // Print
        }

        /* Start the break period */
        private void StartBreak()
        {
            DisplayAlert("Break period", "Time for a break.", "OK");

            /* Set variables */
            this.currentPeriodInSeconds = (this.timesWork / 4 >= 1 && this.timesWork % 4 == 0) ? 900 : 300;
            isWorking = false;

            this.LabelPeriod.Text = "Break period";

            PrintTime(); // Print
        }

        /* Print the Time */
        private void PrintTime()
        {
            int minutes = currentPeriodInSeconds / 60;
            int seconds = currentPeriodInSeconds % 60;

            string remTime = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
            this.LabelTimeRemaining.Text = remTime;
        }
    }
}