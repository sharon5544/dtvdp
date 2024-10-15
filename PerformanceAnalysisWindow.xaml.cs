using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using DTVPDProject.ViewModels;

namespace DTVPDProject.Pages
{
    /// <summary>
    /// Interaction logic for PerformanceAnalysisPageWindow.xaml
    /// </summary>
    public partial class PerformanceAnalysisWindow : Window
    {
        public PerformanceAnalysisWindow()
        {
            InitializeComponent();
            DataContext = new PerformanceViewModel(); // Set ViewModel as DataContext

        }
        // Load line chart data when text block is clicked
        private void LoadLineChart_Click(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (PerformanceViewModel)DataContext;
            viewModel.LoadLineChartData();
        }

        // Load pie chart data when text block is clicked
        private void LoadPieChart_Click(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (PerformanceViewModel)DataContext;
            viewModel.LoadPieChartData();
        }

        private void Load3DModelButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (PerformanceViewModel)DataContext;
            viewModel.Load3DModel(viewport3D);  // Passing the 3D viewport to the ViewModel
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}




