using BruTile.Wms;
using FAP.Desktop.ViewModel;
using Mapsui.Geometries.WellKnownText;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
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

namespace FAP.Desktop.View
{
    /// <summary>
    /// Interaction logic for RouteCalculationVew.xaml
    /// </summary>
    public partial class RouteCalculationVew : Window
    {
        private MapViewModel mapViewModel;
        public RouteCalculationVew()
        {
            InitializeComponent();
        }
    }
}
