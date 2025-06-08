using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightBooking.Models;
using FlightBooking.Services;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.ComponentModel;

namespace FlightBooking.ViewModels
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Booking> Bookings { get; set; }
        private int _confirmedCount;
        public int ConfirmedCount
        {
            get => _confirmedCount;
            set
            {
                _confirmedCount = value;
                NotifyPropertyChanged(nameof(ConfirmedCount));
            }
        }
        private int _completedCount;
        public int CompletedCount
        {
            get => _completedCount;
            set
            {
                _completedCount = value;
                NotifyPropertyChanged(nameof(CompletedCount));
            }
        }
        private string _notificationMessage;
        public string NotificationMessage
        {
            get => _notificationMessage;
            set
            {
                _notificationMessage = value;
                NotifyPropertyChanged(nameof(NotificationMessage));
            }
        }

        public ICommand RefreshCommand { get; }
        public ICommand ExportToPdfCommand { get; }

        public ReportsViewModel()
        {
            _apiClient = new ApiClient();
            Bookings = new ObservableCollection<Booking>();
            RefreshCommand = new RelayCommand(RefreshData);
            ExportToPdfCommand = new RelayCommand(ExportToPdf);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var bookings = await _apiClient.GetBookingsAsync();
                if (bookings != null)
                {
                    Bookings.Clear();
                    foreach (var booking in bookings) Bookings.Add(booking);
                    UpdateCounts();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void RefreshData(object parameter)
        {
            LoadData();
            NotificationMessage = "Данные обновлены!";
            Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
        }

        private void ExportToPdf(object parameter)
        {
            try
            {
                if (Bookings == null || !Bookings.Any())
                {
                    NotificationMessage = "Нет данных для экспорта!";
                    Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
                    return;
                }

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Отчёт по бронированиям";
                PdfPage page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont titleFont = new XFont("Arial", 20, XFontStyle.Bold);
                XFont headerFont = new XFont("Arial", 14, XFontStyle.Bold);
                XFont bodyFont = new XFont("Arial", 12);

                gfx.DrawString("Отчёт по бронированиям", titleFont, XBrushes.Black,
                    new XRect(0, 50, page.Width, page.Height), XStringFormats.Center);
                gfx.DrawLine(XPens.Black, 50, 90, page.Width - 50, 90);

                double yPos = 120;
                gfx.DrawString("Статистика бронирований:", headerFont, XBrushes.Black,
                    new XRect(0, yPos, page.Width, page.Height), XStringFormats.Center);
                yPos += 40;
                gfx.DrawString($"Подтверждено: {ConfirmedCount}", bodyFont, XBrushes.Black,
                    new XRect(0, yPos, page.Width, page.Height), XStringFormats.Center);
                yPos += 30;
                gfx.DrawString($"Завершено: {CompletedCount}", bodyFont, XBrushes.Black,
                    new XRect(0, yPos, page.Width, page.Height), XStringFormats.Center);
                yPos += 60;

                double tableX = 50;
                double tableY = yPos;
                double cellWidth = (page.Width - 100) / 5; 
                string[] headers = { "Номер брони", "Рейс", "Клиент", "Дата", "Статус" };
                for (int i = 0; i < headers.Length; i++)
                {
                    gfx.DrawRectangle(XBrushes.LightGray, tableX + i * cellWidth, tableY, cellWidth, 25);
                    gfx.DrawString(headers[i], bodyFont, XBrushes.Black,
                        new XRect(tableX + i * cellWidth, tableY, cellWidth, 25), XStringFormats.Center);
                }
                tableY += 25;

                foreach (var booking in Bookings)
                {
                    string[] data = {
                        booking.BookingId.ToString(),
                        booking.Flight?.FlightNumber ?? "N/A",
                        booking.User?.FullName ?? "N/A",
                        booking.BookingDate.ToString("dd/MM/yyyy HH:mm"),
                        booking.Status ?? "N/A"
                    };
                    for (int i = 0; i < data.Length; i++)
                    {
                        gfx.DrawRectangle(XBrushes.White, tableX + i * cellWidth, tableY, cellWidth, 25);
                        gfx.DrawString(data[i], bodyFont, XBrushes.Black,
                            new XRect(tableX + i * cellWidth, tableY, cellWidth, 25), XStringFormats.Center);
                    }
                    tableY += 25;

                    if (tableY > page.Height - 50)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);

                        for (int i = 0; i < headers.Length; i++)
                        {
                            gfx.DrawRectangle(XBrushes.LightGray, tableX + i * cellWidth, tableY, cellWidth, 25);
                            gfx.DrawString(headers[i], bodyFont, XBrushes.Black,
                                new XRect(tableX + i * cellWidth, tableY, cellWidth, 25), XStringFormats.Center);
                        }
                        tableY += 25;
                    }
                }

                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filePath = Path.Combine(desktopPath, "Report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf");
                document.Save(filePath);
                NotificationMessage = "Экспорт в PDF выполнен!";
                Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка экспорта в PDF: {ex.Message}");
                NotificationMessage = "Ошибка при экспорте в PDF!";
                Task.Delay(10000).ContinueWith(_ => NotificationMessage = "");
            }
        }

        private void UpdateCounts()
        {
            ConfirmedCount = Bookings.Count(b => b.Status == "Подтверждено");
            CompletedCount = Bookings.Count(b => b.Status == "Завершено");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}