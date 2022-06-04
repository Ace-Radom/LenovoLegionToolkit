﻿using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib.Controllers;
using LenovoLegionToolkit.WPF.Controls.Settings;
using LenovoLegionToolkit.WPF.Utils;

namespace LenovoLegionToolkit.WPF.Windows
{
    public partial class CPUBoostModesWindow
    {
        private readonly CPUBoostModeController _cpuBoostController = Container.Resolve<CPUBoostModeController>();

        public CPUBoostModesWindow()
        {
            InitializeComponent();

            ResizeMode = ResizeMode.CanMinimize;

            _titleBar.UseSnapLayout = false;
            _titleBar.CanMaximize = false;

            Loaded += CPUBoostModesWindow_Loaded;
            IsVisibleChanged += CPUBoostModesWindow_IsVisibleChanged;
        }

        private async void CPUBoostModesWindow_Loaded(object sender, RoutedEventArgs e) => await RefreshAsync();

        private async void CPUBoostModesWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsLoaded && IsVisible)
                await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            var loadingTask = Task.Delay(500);

            var settings = await _cpuBoostController.GetSettingsAsync();

            _stackPanel.Children.Clear();
            foreach (var setting in settings)
                _stackPanel.Children.Add(new CPUBoostModeControl(setting));

            await loadingTask;

            _loader.Visibility = Visibility.Collapsed;
            _content.Visibility = Visibility.Visible;
        }
    }
}