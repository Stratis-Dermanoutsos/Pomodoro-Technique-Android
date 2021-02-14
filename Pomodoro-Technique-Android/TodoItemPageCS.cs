using Pomodoro_Technique_Android.Backend;
using Xamarin.Forms;

namespace Pomodoro_Technique_Android
{
    public class TodoItemPageCS : ContentPage
    {
        public TodoItemPageCS()
        {
            Title = "Todo Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) => {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) => {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.DeleteItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) => {
                await Navigation.PopAsync();
            };

            var frame = new Frame
            {
                BackgroundColor = Color.FromHex("#2196F3"),
                Padding = new Thickness(24),
                Margin = new Thickness(10),
                CornerRadius = 25,
                Content = new StackLayout
                {
                    Children = {
                        new Label { Text = "Name" },
                        nameEntry,
                        new Label { Text = "Done" },
                        doneSwitch,
                        saveButton,
                        deleteButton,
                        cancelButton
                    }
                }
            };

            Content = new StackLayout
            {
                BackgroundColor = Color.DarkGray,
                Children = { frame }
            };
        }
    }
}
