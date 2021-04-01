using FigScene.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FigScene
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IDrawable> _figures;
        public MainWindow()
        {
            InitializeComponent();
            _figures = GetFigures().ToList();
            FigList.ItemsSource = _figures;
        }

        private IEnumerable<IDrawable> GetFigures()
        {
            var iDrawable = typeof(IDrawable);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => iDrawable.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t) as IDrawable);
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FigList.SelectedIndex == -1)
                return;

            BigImage.Source = _figures[FigList.SelectedIndex].Image;

            FigList.SelectedIndex = -1;
        }
    }
}
