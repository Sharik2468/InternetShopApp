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
        public static void WriteUser(UserModel user, string filePath, DateTime Start, DateTime End)
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

                    Paragraph PheaderString = new Paragraph("Отчёт о продажах", font);
                    PheaderString.Alignment = Element.ALIGN_CENTER;

                    Paragraph PnameString = new Paragraph(user.Name + " " + user.Surname, font);
                    PnameString.Alignment = Element.ALIGN_CENTER;

                    String dateString = "Дата сохранения " + System.DateTime.Now.ToShortDateString();
                    Paragraph PdateString = new Paragraph(dateString, font)
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };

                    document.Add(PdateString);
                    document.Add(PheaderString);
                    document.Add(PnameString);

                    OrderService _orderService = new OrderService();
                    ProductService _productService = new ProductService();
                    List<OrderModel> AllOrders = _orderService.GetAllAcceptedOrdersForSelasman(user.Client_Code, Start, End);

                    int OrderSumm = 0;
                    int BenefitSumm = 0;

                    foreach (var Order in AllOrders)
                    {
                        List<OrderItemModel> AllItemsOfOrder = _orderService.GetAllOrderItems(Order.Order_Code);
                        Paragraph PorderString = new Paragraph("Заказ № " + Order.Order_Code.ToString(), font);
                        PorderString.Alignment = Element.ALIGN_LEFT;
                        document.Add(PorderString);

                        foreach (var Item in AllItemsOfOrder)
                        {
                            Product prod = _productService.GetProductByID((int)Item.Product_Code)[0];
                            Paragraph PitemString = new Paragraph("Имя товара: " + prod.Name+ " " +
                                                                  "Количество: " + Item.Amount_Order_Item+ " "+
                                                                  "Рыночная цена: " + prod.MarketPrice*Item.Amount_Order_Item+" "+
                                                                  "Закупочная цена: " + prod.PurchasePrice * Item.Amount_Order_Item + " "+
                                                                  "Выгода: "+ (prod.MarketPrice * Item.Amount_Order_Item - prod.PurchasePrice * Item.Amount_Order_Item).ToString() + " ", font);
                            PitemString.Alignment = Element.ALIGN_LEFT;
                            document.Add(PitemString);

                            OrderSumm += (int)Item.Order_Sum;
                            BenefitSumm += (int)(prod.MarketPrice * Item.Amount_Order_Item - prod.PurchasePrice * Item.Amount_Order_Item);
                        }

                        Paragraph PseparatorString = new Paragraph(" ", font);
                        PseparatorString.Alignment = Element.ALIGN_LEFT;
                        document.Add(PseparatorString);
                    }

                    Paragraph PsumString = new Paragraph("Итоговая стоимость заказа: " + OrderSumm, font);
                    PsumString.Alignment = Element.ALIGN_CENTER;
                    document.Add(PsumString);

                    Paragraph PBsumString = new Paragraph("Итоговая выгода от заказов: " + BenefitSumm, font);
                    PBsumString.Alignment = Element.ALIGN_CENTER;
                    document.Add(PBsumString);

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
