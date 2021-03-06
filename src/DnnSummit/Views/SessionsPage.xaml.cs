﻿using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnnSummit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SessionsPage : ContentPage
	{
        private bool _isHidingTabs = false;
        private DateTime _startTime;
        private int _showTabsElapse;
        private Point _tabPosition;
        private bool _isFirstLoad = true;
        private bool _isItemAppearing = true;

        public static EventHandler DayChanged;

        public SessionsPage()
		{
			InitializeComponent ();
            _tabPosition = new Point(Tabs.TranslationX, Tabs.TranslationY);
            DayChanged += OnDayChanged;
        }

        ~SessionsPage()
        {
            DayChanged -= OnDayChanged;
        }

        private void OnDayChanged(object sender, EventArgs e)
        {
            _isFirstLoad = true;
        }

        private async void TimerTick(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
            if (timer != null && _isHidingTabs)
            {
                var currentTime = DateTime.Now;
                var elapsed = currentTime.Subtract(_startTime).TotalMilliseconds;
                if (elapsed > _showTabsElapse)
                {
                    timer.Stop();
                    _isHidingTabs = false;
                    await Tabs.TranslateTo(_tabPosition.X, _tabPosition.Y);
                }
            }
        }

        private void FirstLoadTimerTick(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
            timer.Stop();
            _isItemAppearing = true;
        }

        private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (!_isItemAppearing) return;

            if (_isFirstLoad)
            {
                var firstLoadTimer = new Timer(250);
                firstLoadTimer.Elapsed += FirstLoadTimerTick;

                _isItemAppearing = false;
                _isFirstLoad = false;
                firstLoadTimer.Start();
                return;
            }

            if (_isHidingTabs)
            {
                _showTabsElapse += 75;
            }
            else
            {
                var listView = (ListView)sender;
                if (listView != null)
                {
                    
                    _showTabsElapse = 1000;
                    _isHidingTabs = true;
                    var timer = new Timer(250);
                    timer.Elapsed += TimerTick;
                    timer.Start();
                    _startTime = DateTime.Now;

                    await Tabs.TranslateTo(Tabs.TranslationX, Tabs.TranslationY - 50);
                }
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView)sender;
            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}