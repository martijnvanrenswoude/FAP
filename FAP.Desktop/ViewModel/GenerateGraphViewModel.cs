using FAP.Domain;
using FAP.Repository.Generic;
using GalaSoft.MvvmLight.Command;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class GenerateGraphViewModel
    {
        GenericRepository<Event> EventRepository;
        GenericRepository<Employee> EmployeeRepository;
        GenericRepository<Planning> PlanningRepository;

        public List<Employee> Inspectors;
        public ObservableCollection<Event> Events { get; set; }

        public Event SelectedEvent { get; set; }
        public IEnumerable<Planning> SelectedPlanning { get; set; }

        public RelayCommand GenerateButton { get; set; }
        private Document document { get; set; }

        public GenerateGraphViewModel(GenericRepository<Event> EventRepository, GenericRepository<Employee> EmployeeRepository
            , GenericRepository<Planning> PlanningRepository)
        {
            this.EventRepository = EventRepository;
            this.EmployeeRepository = EmployeeRepository;
            this.PlanningRepository = PlanningRepository;
            Events = new ObservableCollection<Event>(EventRepository.Get());
            Inspectors = new List<Employee>();

            GenerateButton = new RelayCommand(Generate);
        }

        private void Generate()
        {
            SelectedPlanning = SelectedEvent.Planning;
            Inspectors.Clear();
            foreach(var item in SelectedPlanning)
            {
                Inspectors.Add(item.Employee);
            }

            document = new Document();
            CreateDocument(document);
            CreateChart(document);

            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;
            renderer.RenderDocument();
            string filename = "C:/Users/sjors/Documents/fap_pdf/test.pdf";
            renderer.PdfDocument.Save(filename);
        }

        public void CreateDocument(Document document)
        {
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph("Rapport " + SelectedEvent.name + " " + SelectedEvent.date.ToString("dd/MM/yyyy"));
            paragraph.Format.Font.Size = 28;
            paragraph.Format.Font.Color = Colors.DodgerBlue;
            paragraph.Format.SpaceAfter = "1cm";
           
            document.LastSection.AddParagraph("Aanwezige inspecteurs: ");
            paragraph = document.LastSection.AddParagraph();
            
            foreach (var item in Inspectors)
            {
                paragraph.AddText(item.name + " " + item.surname);
                if (!item.Equals(Inspectors.Last()))
                {
                    paragraph.AddText(", ");
                }
            }
            paragraph.Format.SpaceAfter = "1cm";
        }

        public void CreateChart(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Grafiek");
            paragraph.Format.SpaceAfter = "1cm";

            Chart chart = new Chart();
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Line;
            series.Add(new double[] { 0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 });

            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("A", "B", "C", "D");

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);
        }
    }
}
