using Microsoft.Office.Interop.Excel;

namespace DownloadExcel.API.Services
{
    public class FileCreatorService<T> : IFileCreatorService<T> where T : class
    {
        public MemoryStream XlsxCreator(IEnumerable<T> data)
        {
            var excel = new Application();

            var workBooks = excel.Workbooks;
            var workBook = workBooks.Add(XlWBATemplate.xlWBATWorksheet);
            var workSheet = (Worksheet)excel.ActiveSheet;

            ExcelHeader(workSheet);

            ExcelRowsData(data, workSheet);

            var tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xlsx");
            workBook.SaveAs(tempFile);
            workBook.Close();
            workBooks.Close();
            excel.Quit();
            var memoryStream = new MemoryStream(File.ReadAllBytes(tempFile));

            return memoryStream;
        }
        private static void ExcelHeader(Worksheet workSheet)
        {
            for (int i = 0; i < typeof(T).GetProperties().Count(); i++)
                workSheet.Cells[1, i + 1] = typeof(T).GetProperties()[i].Name;
        }

        private static void ExcelRowsData(IEnumerable<T> data, Worksheet workSheet)
        {
            var row = 2;
            foreach (var item in data)
            {
                var column = 1;
                foreach (var prop in item.GetType().GetProperties())
                {
                    var value = prop.GetValue(item, null);
                    workSheet.Cells[row, column] = value?.ToString();
                    column++;
                }
                row++;
            }
        }

    }
}
