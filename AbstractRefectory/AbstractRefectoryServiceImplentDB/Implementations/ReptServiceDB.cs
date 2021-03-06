﻿using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;using System.util;
using DB;

namespace DB.Implementations
{
    public class ReptServiceDB : IReptService
    {
        private AbstractDbContext context;
        public ReptServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public void SaveProductPrice(ReptBindingModel model)
        {
            if (File.Exists(model.FileName))
            {
                File.Delete(model.FileName);
            }
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref
               missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем текст
                range.Text = "Прайс продуктов";
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();
                var orderlists = context.Products.ToList();

                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, orderlists.Count, 2, ref
               missing, ref missing);
                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";
                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                for (int i = 0; i < orderlists.Count; ++i)
                {
                    table.Cell(i + 1, 1).Range.Text = orderlists[i].ProductName;
                    table.Cell(i + 1, 2).Range.Text = orderlists[i].Price.ToString();
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;
                range.Text = "Дата: " + DateTime.Now.ToLongDateString();
                font = range.Font;
                font.Size = 12;
                font.Name = "Times New Roman";
                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;
                range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(model.FileName, ref fileFormat, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }
        public List<FridgesLoadViewModel> GetFridgesLoad()
        {
            return context.Fridges.ToList().GroupJoin(
                context.FridgeProducts.Include(r => r.Product).ToList(), storage => storage,
                storageMaterial => storageMaterial.Fridge,
                    (storage, storageMatList) =>
                        new FridgesLoadViewModel
                        {
                            FridgeName = storage.FridgeName,
                            TotalCount = storageMatList.Sum(r => r.Count),
                            Products = storageMatList.Select(r => new Tuple<string,
                           int>(r.Product.ProductName, r.Count))
                        })
 .ToList();
        }
        public void SaveFridgesLoad(ReptBindingModel model)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //или создаем excel-файл, или открываем существующий
                if (File.Exists(model.FileName))
                {
                    excel.Workbooks.Open(model.FileName, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(model.FileName, XlFileFormat.xlExcel8,
                    Type.Missing,
                     Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                //Получаем ссылку на лист
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                //очищаем ячейки
                excelworksheet.Cells.Clear();
                //настройки страницы
                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;
                //получаем ссылку на первые 3 ячейки
                Microsoft.Office.Interop.Excel.Range excelcells =
               excelworksheet.get_Range("A1", "C1");
                //объединяем их
                excelcells.Merge(Type.Missing);
                //задаем текст, настройки шрифта и ячейки
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Загруженность холодильников";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment =
               Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment =
           Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;
                excelcells = excelworksheet.get_Range("A2", "C2");
                excelcells.Merge(Type.Missing);
                excelcells.Value2 = "на" + DateTime.Now.ToShortDateString();
                excelcells.RowHeight = 20;
                excelcells.HorizontalAlignment =
               Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment =
               Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;
                var dict = GetFridgesLoad();
                if (dict != null)
                {
                    excelcells = excelworksheet.get_Range("C1", "C1");
                    foreach (var elem in dict)
                    {
                        //спускаемся на 2 ячейку вниз и 2 ячейкт влево
                        excelcells = excelcells.get_Offset(2, -2);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = elem.FridgeName;
                        excelcells = excelcells.get_Offset(1, 1);
                        //обводим границы
                        if (elem.Products.Count() > 0)
                        {
                            //получаем ячейкт для выбеления рамки под таблицу
                            var excelBorder =
                             excelworksheet.get_Range(excelcells,
                             excelcells.get_Offset(elem.Products.Count()
                            - 1, 1));
                            excelBorder.Borders.LineStyle =
                           Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelBorder.Borders.Weight =
                           Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                            excelBorder.HorizontalAlignment = Constants.xlCenter;
                            excelBorder.VerticalAlignment = Constants.xlCenter;
                            excelBorder.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,

                            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,

                            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                             1);
                            foreach (var listElem in elem.Products)
                            {
                                excelcells.Value2 = listElem.Item1;
                                excelcells.ColumnWidth = 10;
                                excelcells.get_Offset(0, 1).Value2 = listElem.Item2;
                                excelcells = excelcells.get_Offset(1, 0);
                            }
                        }
                        excelcells = excelcells.get_Offset(0, -1);
                        excelcells.Value2 = "Итого";
                        excelcells.Font.Bold = true;
                        excelcells = excelcells.get_Offset(0, 2);
                        excelcells.Value2 = elem.TotalCount;
                        excelcells.Font.Bold = true;
                    }
                }
                
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //закрываем
                excel.Quit();
            }
        }
        public List<AdminOrdersViewModel> GetAdminOrders(ReptBindingModel model)
        {
            return context.Orders
            .Include(rec => rec.Admin)
           .Include(rec => rec.OrderList)
           .Where(rec => rec.DateCreate >= model.DateFrom &&
           rec.DateCreate <= model.DateTo)
            .Select(rec => new AdminOrdersViewModel
            {
                CustomerName = rec.Admin.AdminFIO,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate)
           + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) +
           " " +
            SqlFunctions.DateName("yyyy",
           rec.DateCreate),
                OrderListName = rec.OrderList.OrderListName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString()
            })
           .ToList();
        }
        public void SaveAdminOrders(ReptBindingModel model)
        {
            //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }
            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate,
           FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H,
           BaseFont.NOT_EMBEDDED);
            //вставляем заголовок
            var phraseTitle = new Phrase("Заказы клиентов",
            new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new
           iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);
            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString()
           +
            " по " + model.DateTo.Value.ToShortDateString(),
           new iTextSharp.text.Font(baseFont, 14,
           iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);
            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(6)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160, 100, 100, 140 });
            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10,
           iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("ФИО администратора", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Дата создания", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Лист заказа", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Количество", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Сумма", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Статус", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //заполняем таблицу
            var list = GetAdminOrders(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {
                cell = new PdfPCell(new Phrase(list[i].CustomerName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].DateCreate, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].CustomerName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Count.ToString(), fontForCells));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Sum.ToString(), fontForCells));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Status, fontForCells));
                table.AddCell(cell);
            }
            //вставляем итого
            cell = new PdfPCell(new Phrase("Итого:", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 4,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(list.Sum(rec => rec.Sum).ToString(),
           fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("", fontForCellBold))
            {
                Border = 0
            };
            table.AddCell(cell);
            //вставляем таблицу
            doc.Add(table);
            doc.Close();
        }
    }
}
