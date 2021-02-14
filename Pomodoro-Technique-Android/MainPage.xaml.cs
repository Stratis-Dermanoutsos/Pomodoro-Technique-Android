using System;
using System.Collections.Generic;
using Pomodoro_Technique_Android.Backend;
using Xamarin.Forms;

namespace Pomodoro_Technique_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

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

        async void OnClear(object sender, EventArgs e)
        {
            bool deleted = await App.Database.DeleteItemsAsync();

            listView.ItemsSource = await App.Database.GetItemsAsync();
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            ProgramContentPage program = new ProgramContentPage();
            Navigation.PushAsync(program);
        }
    }
}
