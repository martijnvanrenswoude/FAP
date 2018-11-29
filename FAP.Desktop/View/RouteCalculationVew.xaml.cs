using BruTile.Wms;
using FAP.Desktop.ViewModel;
using Mapsui.Geometries.WellKnownText;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI.Wpf;
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
            mapViewModel = new MapViewModel();
            MapControl.Map.Layers.Add(mapViewModel.CreateWmtsLayer());

            var backgroudLayers = mapViewModel.GetPdokWmtsLayers().ToList();
            //backgroudLayers.Insert(0, _mapsuiSamples.CreateAdressLayerTms());
            //backgroudLayers.Insert(0, _mapsuiSamples.CreateWmtsLayer());
            backgroudLayers.Insert(0, new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap)) { Name = "OpenStreetMap" });

            LayersComboBox.ItemsSource = CreateBackgroundLayerItems(backgroudLayers);
            LayersComboBox.SelectionChanged += LayersComboBoxOnSelectionChanged;
            LayersComboBox.SelectedIndex = 0;
        }

        private void LayersComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (LayersComboBox.SelectedIndex < 0) return;
            MapControl.Map.Layers.Clear();
            var layer = (TileLayer)((ComboBoxItem)LayersComboBox.SelectedItem).Content;
            MapControl.Map.Layers.Add(layer);
            MapControl.Refresh();
        }

        private IEnumerable<ComboBoxItem> CreateBackgroundLayerItems(IEnumerable<ILayer> layers)
        {
            return layers.Select(l => new ComboBoxItem { Name = RemoveIllegalCharacters(l.Name), Content = l });
        }

        /// <summary>
        /// Removes characters that are not allowd in ComboBoxItem.Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>More illegal characters should be added when needed.</returns>
        private string RemoveIllegalCharacters(string name)
        {
            return name.Replace("_", "");
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var geo = _geodanSamples.FindAdress(Query.Text);
        //    var geometry = GeometryFromWKT.Parse(geo);

        //    /**
        //     * We willen het zoek resultaat tonen op de Mapsui kaart
        //     */
        //    var centroid = geometry.GetBoundingBox().GetCentroid();
        //    var sphericalCentroid = SphericalMercator.FromLonLat(centroid.X, centroid.Y);

        //    MapControl.Map.NavigateTo(sphericalCentroid);
        //    MapControl.Map.NavigateTo(MapControl.Map.Resolutions[15]);

        //}

        private static Layer CreateGeometryLayer(Geometry geometry)
        {
            return new Layer
            {
                DataSource = new MemoryProvider(geometry)
                {
                    CRS = "EPSG:4326" // EPSG for WGS84 projection, important for projection
                },
                Style = new VectorStyle() { Fill = new Brush(new Color(0, 0, 0, 64)), Outline = new Pen(Color.Red, 2) }
            };
        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var geo = _geodanSamples.FindAdress(Query.Text);
        //    var geometry = GeometryFromWKT.Parse(geo);

        //    MapControl.Map.Transformation = new MinimalTransformation();
        //    MapControl.Map.CRS = "EPSG:3857"; // EPSG for SphericalMercator, important for projection
        //    MapControl.Map.Layers.Add(CreateGeometryLayer(geometry));
        //    MapControl.Map.NavigateTo(MapControl.Map.Layers[1].Envelope);
        //}
    }
}
