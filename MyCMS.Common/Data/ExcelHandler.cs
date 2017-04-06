using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCMS.Utilities.Data
{
    public class ExcelHandler
    {
        private string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);

            return match.Value;
        }

        private int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            var convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }

            return convertedValue;
        }

        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);

                int currentColumnIndex = ConvertColumnNameToNumber(columnName);

                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }

                yield return cell;
                currentCount++;
            }
        }

        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            return (text ?? string.Empty).Trim();
        }

        //public ExcelData ReadExcel(Stream fileStream, int fristRowIndex = 0)
        //{
        //    var data = new ExcelData();



        //    // Open the excel document
        //    WorkbookPart workbookPart; List<Row> rows;
        //    try
        //    {
        //        SpreadsheetDocument document = SpreadsheetDocument.Open(fileStream, false);
        //        workbookPart = document.WorkbookPart;

        //        var sheets = workbookPart.Workbook.Descendants<Sheet>();
        //        var sheet = sheets.First();
        //        data.SheetName = sheet.Name;

        //        var workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;
        //        Columns columns = workSheet.Descendants<Columns>().FirstOrDefault();
        //        data.ColumnConfigurations = columns;

        //        var sheetData = workSheet.Elements<SheetData>().First();
        //        rows = sheetData.Elements<Row>().ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        data.Status.Message = "Unable to open the file";
        //        return data;
        //    }

        //    // Read the header
        //    if (rows.Count > 0)
        //    {
        //        var row = rows[fristRowIndex];
        //        var cellEnumerator = GetExcelCellEnumerator(row);
        //        while (cellEnumerator.MoveNext())
        //        {
        //            var cell = cellEnumerator.Current;
        //            var text = ReadExcelCell(cell, workbookPart).Trim();
        //            data.Headers.Add(text);
        //        }
        //    }

        //    // Read the sheet data
        //    if (rows.Count > 1)
        //    {
        //        for (var i = fristRowIndex; i < rows.Count; i++)
        //        {
        //            var dataRow = new List<string>();
        //            data.DataRows.Add(dataRow);
        //            var row = rows[i];
        //            var cellEnumerator = GetExcelCellEnumerator(row);
        //            while (cellEnumerator.MoveNext())
        //            {
        //                var cell = cellEnumerator.Current;
        //                var text = ReadExcelCell(cell, workbookPart).Trim();
        //                dataRow.Add(text);
        //            }
        //        }
        //    }

        //    return data;
        //}

        private string ColumnLetter(int intCol)
        {
            var intFirstLetter = ((intCol) / 676) + 64;
            var intSecondLetter = ((intCol % 676) / 26) + 64;
            var intThirdLetter = (intCol % 26) + 65;

            var firstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
            var secondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
            var thirdLetter = (char)intThirdLetter;

            return string.Concat(firstLetter, secondLetter, thirdLetter).Trim();
        }

        private Cell CreateTextCell(string header, UInt32 index, string text)
        {
            var cell = new Cell
            {
                DataType = CellValues.InlineString,
                CellReference = header + index
            };

            var istring = new InlineString();
            var t = new Text { Text = text };
            istring.AppendChild(t);
            cell.AppendChild(istring);
            return cell;
        }

        //public byte[] GenerateExcel(ExcelData data)
        //{
        //    var stream = new MemoryStream();
        //    var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

        //    var workbookpart = document.AddWorkbookPart();
        //    workbookpart.Workbook = new Workbook();
        //    var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
        //    var sheetData = new SheetData();

        //    worksheetPart.Worksheet = new Worksheet(sheetData);

        //    var sheets = document.WorkbookPart.Workbook.
        //        AppendChild<Sheets>(new Sheets());

        //    var sheet = new Sheet()
        //    {
        //        Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
        //        SheetId = 1,
        //        Name = data.SheetName ?? "Sheet 1"
        //    };
        //    sheets.AppendChild(sheet);

        //    // Add header
        //    UInt32 rowIdex = 0;
        //    var row = new Row { RowIndex = ++rowIdex };
        //    sheetData.AppendChild(row);
        //    var cellIdex = 0;

        //    foreach (var header in data.Headers)
        //    {
        //        row.AppendChild(CreateTextCell(ColumnLetter(cellIdex++), rowIdex, header ?? string.Empty));
        //    }
        //    if (data.Headers.Count > 0)
        //    {
        //        // Add the column configuration if available
        //        if (data.ColumnConfigurations != null)
        //        {
        //            var columns = (Columns)data.ColumnConfigurations.Clone();
        //            worksheetPart.Worksheet
        //                .InsertAfter(columns, worksheetPart.Worksheet.SheetFormatProperties);
        //        }
        //    }

        //    // Add sheet data
        //    foreach (var rowData in data.DataRows)
        //    {
        //        cellIdex = 0;
        //        row = new Row { RowIndex = ++rowIdex };
        //        sheetData.AppendChild(row);
        //        foreach (var callData in rowData)
        //        {
        //            var cell = CreateTextCell(ColumnLetter(cellIdex++), rowIdex, callData ?? string.Empty);
        //            row.AppendChild(cell);
        //        }
        //    }

        //    workbookpart.Workbook.Save();
        //    document.Close();

        //    return stream.ToArray();
        //}

    }

}
