using DnnSummit.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class SponsorControl : ContentView
    {
        public StackLayout Control { get; set; }
        public SponsorControl()
        {
            Control = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(0, 10),
                Margin = 0
            };
            Content = Control;
        }

        public StackLayout CreateRow(Sponsor[] sponsors, bool isLastRow = false)
        {
            var row = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                Spacing = 20,
                Margin = new Thickness(10, 0, 10, 0),
                HeightRequest = RowHeight
            };

            if (isLastRow)
            {
                var box = new BoxView
                {
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
                };

                row.Children.Add(box);
            }

            foreach (var item in sponsors)
            {
                var image = new Image
                {
                    Source = item.ImageLink,
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                    VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, false),
                    Margin = 0
                };

                if (SponsorTapped != null)
                {
                    var tapGesture = new TapGestureRecognizer
                    {
                        Command = SponsorTapped,
                        CommandParameter = item
                    };
                    image.GestureRecognizers.Add(tapGesture);
                }

                row.Children.Add(image);

            }

            if (isLastRow)
            {
                var box = new BoxView
                {
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
                };

                row.Children.Add(box);
            }

            return row;
        }

        public ICommand SponsorTapped
        {
            get { return (ICommand)GetValue(SponsorTappedProperty); }
            set { SetValue(SponsorTappedProperty, value); }
        }

        public static readonly BindableProperty SponsorTappedProperty = BindableProperty.Create(
            nameof(SponsorTapped),
            typeof(ICommand),
            typeof(SponsorControl),
            null,
            propertyChanged: OnSponsorTappedPropertyChanged);

        private static void OnSponsorTappedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SponsorControl)bindable;
            if (context != null)
            {
                context.SponsorTapped = (ICommand)newValue;
                OnItemsSourcePropertyChanged(context, null, context.ItemsSource);
            }
        }

        public double RowHeight
        {
            get { return (double)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create(
            nameof(RowHeight),
            typeof(double),
            typeof(SponsorControl),
            (double)100,
            propertyChanged: OnRowHeightPropertyChanged);

        private static void OnRowHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SponsorControl)bindable;
            if (context != null)
            {
                context.RowHeight = (double)newValue;
                OnItemsSourcePropertyChanged(context, null, context.ItemsSource);
            }
        }

        public int SponsorsPerRow
        {
            get { return (int)GetValue(SponsorsPerRowProperty); }
            set { SetValue(SponsorsPerRowProperty, value); }
        }

        public static readonly BindableProperty SponsorsPerRowProperty = BindableProperty.Create(
            nameof(SponsorsPerRow),
            typeof(int),
            typeof(SponsorControl),
            3,
            propertyChanged: OnSponsorsPerRowPropertyChanged);

        private static void OnSponsorsPerRowPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SponsorControl)bindable;
            if (context != null)
            {
                context.SponsorsPerRow = (int)newValue;
                OnItemsSourcePropertyChanged(context, null, context.ItemsSource);
            }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(SponsorControl),
            null,
            propertyChanged: OnItemsSourcePropertyChanged);

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SponsorControl)bindable;
            if (context != null)
            {
                context.Control.Children.Clear();

                var data = (IEnumerable<Sponsor>)newValue;                
                if (data != null)
                {
                    var current = new List<Sponsor>();
                    var sponsors = data.ToArray();

                    for (int index = 0; index < sponsors.Length; index++)
                    {
                        current.Add(sponsors[index]);                        

                        if ((index > 0 && (index + 1) % context.SponsorsPerRow == 0) || index == sponsors.Length - 1)
                        {
                            bool isLast = false;
                            if (index == sponsors.Length - 1 && context.Control.Children.Count() > 0 && (index +1) % context.SponsorsPerRow != 0)
                            {
                                isLast = true;
                            }

                            var row = context.CreateRow(current.ToArray(), isLast);
                            current.Clear();

                            context.Control.Children.Add(row);
                        }
                    }
                }
            }
        }
    }
}
