using GalaSoft.MvvmLight.Command;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.ViewModel
{
    public class GenerateGraphViewModel
    {

        public RelayCommand GenerateButton { get; set; }
        private Document document { get; set; }

        public GenerateGraphViewModel()
        {
            GenerateButton = new RelayCommand(Generate);
        }

        private void Generate()
        {
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
            Paragraph paragraph = section.AddParagraph("PDF met gegenereerde grafiek");
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
            series.Add(new double[] { 0, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512});

            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);
        }
    }
}
