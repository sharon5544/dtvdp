using HelixToolkit.Wpf;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using LiveCharts.Wpf;
using HelixToolkit.Wpf;

namespace DTVPDProject.ViewModels
{
    public class PerformanceViewModel : INotifyPropertyChanged
    {
        // Properties for Line Chart
        public SeriesCollection LineChartSeries { get; set; }
        public List<string> LineChartXAxis { get; set; }
        public List<string> LineChartYAxis { get; set; }

        // Properties for Pie Chart
        public SeriesCollection PieChartSeries { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PerformanceViewModel()
        {
            LineChartSeries = new SeriesCollection();
            LineChartXAxis = new List<string>();
            LineChartYAxis = new List<string>();

            PieChartSeries = new SeriesCollection();
        }

        // Load line chart data
        public void LoadLineChartData()
        {
            var values = new ChartValues<double> { 3, 5, 7, 9, 6, 4 };

            LineChartSeries.Clear();
            LineChartSeries.Add(new LineSeries
            {
                Title = "Line Data",
                Values = values
            });

            LineChartXAxis = new List<string> { "Step 1", "Step 2", "Step 3", "Step 4", "Step 5" };
            LineChartYAxis = new List<string> { "Value" };

            OnPropertyChanged("LineChartSeries");
            OnPropertyChanged("LineChartXAxis");
            OnPropertyChanged("LineChartYAxis");
        }

        // Load pie chart data
        public void LoadPieChartData()
        {
            PieChartSeries.Clear();
            PieChartSeries.Add(new PieSeries
            {
                Title = "Slice 1",
                Values = new ChartValues<double> { 4 },
                DataLabels = true
            });
            PieChartSeries.Add(new PieSeries
            {
                Title = "Slice 2",
                Values = new ChartValues<double> { 6 },
                DataLabels = true
            });

            OnPropertyChanged("PieChartSeries");
        }

        // Load 3D model into the viewport
        public void Load3DModel(HelixViewport3D viewport)
        {
            var meshBuilder = new MeshBuilder();
            meshBuilder.AddBox(new Point3D(0, 0, 0), 10, 10, 10);

            var mesh = meshBuilder.ToMesh();
            var material = Materials.Red;

            var model = new GeometryModel3D(mesh, material);
            viewport.Children.Clear(); // Clear existing models
            viewport.Children.Add(new ModelVisual3D { Content = model });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void Load3DModel(object viewport3D)
        {
            throw new NotImplementedException();
        }
    }
}

