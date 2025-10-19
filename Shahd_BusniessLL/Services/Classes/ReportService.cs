using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Shahd_BusniessLL.Services.Classes
{
    public class ReportService
    {
        private readonly IProductRepo _productRepo;

        public ReportService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
             QuestPDF.Settings.License= LicenseType.Community;
        }


      public  QuestPDF.Infrastructure.IDocument CreateDocument()
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("s&shop-products")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            foreach (var item in _productRepo.GetAllProductsWithImages())
                            {
                              x.Item().Text($"id: {item.Id} , name : {item.Name}");

                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
        }
    
}
}
