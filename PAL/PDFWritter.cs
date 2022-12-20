using iTextSharp.text;
using iTextSharp.text.pdf;
using PL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PL
{
    class PDFWritter
    {
        /// <summary>
        /// Сохранить информацию о пользователе в файл
        /// </summary>
        /// <param name="user">Порльзователь</param>
        /// <param name="filePath">Путь к файлу</param>
        public static void WriteUser(SalesmanModel user, string filePath)
        {
            var document = new Document();
            try
            {
                var baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                var fontB = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);

                using (FileStream stream = new FileStream(@filePath, FileMode.Create))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    Paragraph PheaderString = new Paragraph(user.Saleman_Name, fontB);
                    PheaderString.Alignment = Element.ALIGN_CENTER;

                    String dateString = "Дата сохранения " + System.DateTime.Now.ToShortDateString();
                    Paragraph PdateString = new Paragraph(dateString, font)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };

                    PdfImage jpg = PDFImage.GetInstance(user.ImageBytes);
                    jpg.Alignment = Element.ALIGN_CENTER;
                    jpg.ScaleAbsolute(jpg.Width / 10, jpg.Height / 10);

                    document.Add(PheaderString);
                    document.Add(PdateString);
                    document.Add(jpg);
                    document.Close();
                }
            }
            catch (DocumentException ex)
            {
                //Необходимо использование логгера
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
