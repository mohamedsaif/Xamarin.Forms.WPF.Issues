using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.IssuesApp.Views;

namespace XF.IssuesApp
{
	public partial class MainPage : ContentPage
	{
        public MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)this.BindingContext;
            }
        }

		public MainPage()
        {
            BindingContext = new MainViewModel();

            this.Title = "Issues";

            Grid grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid.VerticalOptions = LayoutOptions.FillAndExpand;
            grid.Padding = 20;
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });

            List<View> viewList = new List<View>();

            AddIssue1(viewList);
            AddIssue2(viewList);
            AddIssue3(viewList);
            AddIssue4(viewList);
            AddIssue5(viewList);
            AddIssue6(viewList);
            AddIssue7(viewList);

            int currentViewRowNo = 0;
            int viewColumn = 1;

            var length = viewList.Count();

            for (int i = 0; i < length; i++)
            {
                var view = viewList[i];

                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                grid.Children.Add(view);
                Grid.SetRow(view, currentViewRowNo);
                Grid.SetColumn(view, viewColumn);
                currentViewRowNo++;
            }

            ScrollView scrollView = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            scrollView.Content = grid;

            this.Content = scrollView;
        }

        #region Issue 7

        private void AddIssue7(List<View> viewList)
        {
            var issueNo = "7";

            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "If I create a custom control in the xamarin.forms project, and a custom bindable property in it and then a view that uses it binds to that property with TwoWay binding - it only binds the Get not the Set ?";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label issueTestLabel1Description = new Label();
                issueTestLabel1Description.Text = "Below should show the same in the label as what you type in the text box as they are both bound to the same Property in the ViewModel! :";
                issueTestLabel1Description.HorizontalTextAlignment = TextAlignment.Center;

                Entry entry = new Entry();
                entry.BindingContext = this.BindingContext;
                //entry.BackgroundColor = Color.Gray;
                //entry.TextColor = Color.White;
                entry.HeightRequest = 50;
                entry.SetBinding(Entry.TextProperty, "Issue" + issueNo + "Field", BindingMode.TwoWay);

                Issue7CustomLabel issue7CustomLabel = new Issue7CustomLabel();
                issue7CustomLabel.BindingContext = this.BindingContext;
                //entry.BackgroundColor = Color.Gray;
                //entry.TextColor = Color.White;
                issue7CustomLabel.HeightRequest = 50;
                issue7CustomLabel.SetBinding(Issue7CustomLabel.DeferredTextProperty, "Issue" + issueNo + "Field", BindingMode.OneWay);

                var issueTestStackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Orientation = StackOrientation.Vertical
                };

                issueTestStackLayout.Children.Add(issueTestLabel1Description);
                issueTestStackLayout.Children.Add(entry);
                issueTestStackLayout.Children.Add(issue7CustomLabel);

                var contentView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                contentView.Content = issueTestStackLayout;

                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, contentView));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.BindingContext = this.BindingContext;
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.BindingContext = this.BindingContext;
            issueStatusLabel.Text = "Fixed - thank you!";
            issueStatusLabel.BackgroundColor = Color.Green;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 7

        #region Issue 6

        private void AddIssue6(List<View> viewList)
        {
            var issueNo = "6";

            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "Placeholder Property on Entry doesn't work on Xamarin.Forms.WPF ? ";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label issueTestLabel1Description = new Label();
                issueTestLabel1Description.Text = "Below should show the text '" + ViewModel.Issue6Field + "' as the placeholder :";
                issueTestLabel1Description.HorizontalTextAlignment = TextAlignment.Center;

                Entry entry = new Entry();
                entry.BindingContext = this.BindingContext;
                //entry.BackgroundColor = Color.Gray;
                //entry.TextColor = Color.White;
                entry.HeightRequest = 50;
                entry.SetBinding(Entry.PlaceholderProperty, "Issue" + issueNo + "Field", BindingMode.OneWay);

                var issueTestStackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Orientation = StackOrientation.Vertical
                };

                issueTestStackLayout.Children.Add(issueTestLabel1Description);
                issueTestStackLayout.Children.Add(entry);

                var contentView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                contentView.Content = issueTestStackLayout;

                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, contentView));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.BindingContext = this.BindingContext;
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.BindingContext = this.BindingContext;
            issueStatusLabel.Text = "Still an issue";
            issueStatusLabel.BackgroundColor = Color.Red;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 6

        #region Issue 5

        private void AddIssue5(List<View> viewList)
        {
            var issueNo = "5";

            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "Binding of Commands to Buttons doesn't work - only setting them manually through code works ?";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label issueTestLabel1Description = new Label();
                issueTestLabel1Description.Text = "Clicking the below should open a message to say Success if the Command Binding is working :";
                issueTestLabel1Description.HorizontalTextAlignment = TextAlignment.Center;

                Button button = new Button();
                button.BindingContext = this.BindingContext;
                //button.BackgroundColor = Color.Gray;
                //button.TextColor = Color.White;
                button.Text = "Click Me!";
                button.HeightRequest = 50;
                button.SetBinding(Button.CommandProperty, "Issue" + issueNo + "FieldCommand", BindingMode.OneWay);
                button.Clicked += (innerSender, innerArgs) =>
                {
                    ViewModel.Issue5Field = "Failed!";
                    button.Command.Execute(null);
                    DisplayAlert("Alert", ViewModel.Issue5Field, "OK");
                };
                
                var issueTestStackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Orientation = StackOrientation.Vertical
                };

                issueTestStackLayout.Children.Add(issueTestLabel1Description);
                issueTestStackLayout.Children.Add(button);

                var contentView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                contentView.Content = issueTestStackLayout;

                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, contentView));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.BindingContext = this.BindingContext;
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.BindingContext = this.BindingContext;
            issueStatusLabel.Text = "Fixed - thank you!";
            issueStatusLabel.BackgroundColor = Color.Green;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 5

        #region Issue 4

        private void AddIssue4(List<View> viewList)
        {
            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            var issueNo = "4";

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "Popping a Modal Page isn't transparent even though I'm setting it to transparent in both the NavigationPage, and the ContentPage inside it";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label issueTestLabel1Description = new Label();
                issueTestLabel1Description.BackgroundColor = Color.Purple;
                issueTestLabel1Description.HorizontalOptions = LayoutOptions.Center;
                issueTestLabel1Description.VerticalOptions = LayoutOptions.Center;
                issueTestLabel1Description.Text = "The entire Page Background behind this Label should be Transparent";
                issueTestLabel1Description.TextColor = Color.White;

                var issuePageToPush = new ShowIssuePage(this.BindingContext, issueTestLabel1Description, Color.Transparent);
                var issueNavigationPageToPush = new NavigationPage(issuePageToPush)
                {
                    BackgroundColor = Color.Transparent
                };
                this.Navigation.PushModalAsync(issueNavigationPageToPush);
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.Text = "Still an issue";
            issueStatusLabel.BackgroundColor = Color.Red;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 4

        #region Issue 3

        private void AddIssue3(List<View> viewList)
        {
            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            var issueNo = "3";

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "For all controls with FontFamily - setting it to a CUSTOM font defined in the platform specific project does not work in Xamarin.Forms.WPF";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label issueTestLabel1Description = new Label();
                issueTestLabel1Description.Text = "Below is supposed to show a hamburger icon (like used in a mobile app) from the FontAwesome font :";

                Label issueTestLabel1 = new Label();
                issueTestLabel1.BindingContext = this.BindingContext;
                issueTestLabel1.BackgroundColor = Color.Gray;
                issueTestLabel1.TextColor = Color.White;
                issueTestLabel1.HorizontalTextAlignment = TextAlignment.Center;
                issueTestLabel1.HeightRequest = 50;
                issueTestLabel1.VerticalTextAlignment = TextAlignment.Center;
                string fontName = string.Empty;
                switch (Device.RuntimePlatform)
                {
                    case Device.WPF:
                        fontName = "/oneX;component/Assets/Fonts/fontawesome-webfont.ttf";
                        break;
                    default:
                        break;
                }
                if (fontName.Length > 0)
                {
                    issueTestLabel1.FontFamily = fontName;
                }
                issueTestLabel1.FontSize = 40;
                issueTestLabel1.SetBinding(Label.TextProperty, "Issue" + issueNo + "Field1", BindingMode.OneWay);

                Label issueTestLabel2Description = new Label();
                issueTestLabel2Description.Text = "Below is supposed to show the text in the Pick Ax font, which is very scratchy and not normal :";

                Label issueTestLabel2 = new Label();
                issueTestLabel2.BindingContext = this.BindingContext;
                issueTestLabel2.BackgroundColor = Color.Gray;
                issueTestLabel2.TextColor = Color.White;
                issueTestLabel2.HorizontalTextAlignment = TextAlignment.Center;
                issueTestLabel2.HeightRequest = 50;
                issueTestLabel2.VerticalTextAlignment = TextAlignment.Center;
                string fontName2 = string.Empty;
                switch (Device.RuntimePlatform)
                {
                    case Device.WPF:
                        fontName2 = "/oneX;component/Assets/Fonts/#Pick Ax";
                        break;
                    default:
                        break;
                }
                if (fontName.Length > 0)
                {
                    issueTestLabel2.FontFamily = fontName2;
                }
                issueTestLabel2.FontSize = 40;
                issueTestLabel2.SetBinding(Label.TextProperty, "Issue" + issueNo + "Field2", BindingMode.OneWay);

                var issueTestStackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Orientation = StackOrientation.Vertical
                };

                issueTestStackLayout.Children.Add(issueTestLabel1Description);
                issueTestStackLayout.Children.Add(issueTestLabel1);
                issueTestStackLayout.Children.Add(issueTestLabel2Description);
                issueTestStackLayout.Children.Add(issueTestLabel2);

                var contentView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                contentView.Content = issueTestStackLayout;

                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, contentView));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.Text = "Still an issue";
            issueStatusLabel.BackgroundColor = Color.Red;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 3

        #region Issue 2

        private void AddIssue2(List<View> viewList)
        {
            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            var issueNo = "2";

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.Text = "Label VerticalContentAlignment doesn't work - you have to set VerticalAlignment for the whole label to get it to center for the example";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Label label = new Label();
                label.BindingContext = this.BindingContext;
                label.BackgroundColor = Color.Gray;
                label.TextColor = Color.White;
                label.HeightRequest = 50;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.SetBinding(Label.TextProperty, "Issue" + issueNo + "Field", BindingMode.TwoWay);
                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, label));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.BindingContext = this.BindingContext;
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.BindingContext = this.BindingContext;
            issueStatusLabel.Text = "Still an issue";
            issueStatusLabel.BackgroundColor = Color.Red;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 2

        #region Issue 1

        private void AddIssue1(List<View> viewList)
        {
            var issueNo = "1";

            //Divider
            viewList.Add(new ContentView { BackgroundColor = Color.Black, HeightRequest = 5, WidthRequest = -1 });

            Label issueHeadingLabel = new Label();
            issueHeadingLabel.BindingContext = this.BindingContext;
            issueHeadingLabel.Text = "Issue " + issueNo;
            issueHeadingLabel.FontSize = 20;
            issueHeadingLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueHeadingLabel);

            Label issueDescriptionLabel = new Label();
            issueDescriptionLabel.BindingContext = this.BindingContext;
            issueDescriptionLabel.Text = "Entry control crashes with exception if bound to NULL string";
            issueDescriptionLabel.LineBreakMode = LineBreakMode.WordWrap;
            viewList.Add(issueDescriptionLabel);

            Button issueButton = new Button();
            issueButton.BindingContext = this.BindingContext;
            issueButton.Text = "Click to Show Issue " + issueNo;
            issueButton.Clicked += (sender, args) =>
            {
                Entry entry = new Entry();
                entry.BindingContext = this.BindingContext;
                entry.BackgroundColor = Color.Gray;
                entry.TextColor = Color.White;
                entry.HeightRequest = 50;
                entry.SetBinding(Entry.TextProperty, "Issue" + issueNo + "Field", BindingMode.TwoWay);
                this.Navigation.PushModalAsync(new ShowIssuePage(this.BindingContext, entry));
            };
            viewList.Add(issueButton);

            Label issueStatusDescriptionLabel = new Label();
            issueStatusDescriptionLabel.BindingContext = this.BindingContext;
            issueStatusDescriptionLabel.Text = "Status:";
            viewList.Add(issueStatusDescriptionLabel);

            Label issueStatusLabel = new Label();
            issueStatusLabel.BindingContext = this.BindingContext;
            issueStatusLabel.Text = "Fixed - thank you!";
            issueStatusLabel.BackgroundColor = Color.Green;
            issueStatusLabel.TextColor = Color.White;
            issueStatusLabel.FontAttributes = FontAttributes.Bold;
            viewList.Add(issueStatusLabel);
        }

        #endregion Issue 1
    }
}