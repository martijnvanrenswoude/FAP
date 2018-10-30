using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FAP.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        public ObservableCollection<DataVM> Data { get; set; }
        public string PDFName { get; set; }
        public ICommand Export { get; set; }

        public MainViewModel()
        {
            Data = new ObservableCollection<DataVM>();

            Data.Add(new DataVM("Noah", "30-10-2018"));
            Data.Add(new DataVM("Sem", "12-02-2018"));
            Data.Add(new DataVM("Lucas", "06-02-2018"));
            Data.Add(new DataVM("Finn", "12-08-2018"));
            Data.Add(new DataVM("Daan", "24-09-2018"));
            Data.Add(new DataVM("Levi", "16-11-2018"));
            Data.Add(new DataVM("Milan", "02-05-2018"));
            Data.Add(new DataVM("Bram", "19-04-2018"));
            Data.Add(new DataVM("Luuk", "26-12-2018"));
            Data.Add(new DataVM("Jesse", "04-07-2018"));
            Data.Add(new DataVM("Liam", "28-08-2018"));
            Data.Add(new DataVM("Mees", "25-01-2018"));
            Data.Add(new DataVM("Thom", "06-11-2018"));
            Data.Add(new DataVM("Sam", "13-08-2018"));
            Data.Add(new DataVM("Thijs", "18-09-2018"));

            Export = new RelayCommand(ExportToPDF);
        }

        private void ExportToPDF()
        {
            if (PDFName == null)
                return;

            Document pdfDocument = new Document();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            PdfWriter.GetInstance(pdfDocument, new FileStream(path + "\\PDF\\" + PDFName + ".PDF", FileMode.Create));
            pdfDocument.Open();

            pdfDocument.Add(new Paragraph("Naam     Startdatum"));
            foreach (var item in Data)
            {
                pdfDocument.Add(new Paragraph(item.Name + "     " + item.DayOfEmployment));
            }
            pdfDocument.Close();
        }
    }
}