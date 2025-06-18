using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using OfficeOpenXml;
using System.Windows;
using FlightBooking.Models;
using FlightBooking.Services;
using System.ComponentModel;
using System.Linq;

namespace FlightBooking.ViewModels
{
    public class PaymentsViewModel : INotifyPropertyChanged
    {
        private readonly ApiClient _apiClient;
        public ObservableCollection<Payment> Payments { get; set; }
        public ObservableCollection<Booking> AvailableBookings { get; set; }
        private Payment _selectedPayment;
        public Payment SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                _selectedPayment = value;
                NotifyPropertyChanged(nameof(SelectedPayment));
                UpdateFormFromSelectedPayment();
            }
        }
        private Payment _newPayment;
        public Payment NewPayment
        {
            get => _newPayment;
            set
            {
                _newPayment = value;
                NotifyPropertyChanged(nameof(NewPayment));
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

        public ObservableCollection<string> StatusOptions { get; set; }
        public ICommand RefreshCommand { get; }
        public ICommand CreatePaymentCommand { get; }
        public ICommand EditPaymentCommand { get; }
        public ICommand DeletePaymentCommand { get; }
        public ICommand ExportToExcelCommand { get; }

        public PaymentsViewModel()
        {
            _apiClient = new ApiClient();
            Payments = new ObservableCollection<Payment>();
            AvailableBookings = new ObservableCollection<Booking>();
            NewPayment = new Payment { PaymentDate = DateTime.Now, Status = "Ожидает" };
            StatusOptions = new ObservableCollection<string> { "Завершено", "Неудачно", "Ожидает" };
            RefreshCommand = new AsyncRelayCommand(RefreshDataAsync);
            CreatePaymentCommand = new AsyncRelayCommand(CreatePaymentAsync, () => CanExecute(null));
            EditPaymentCommand = new AsyncRelayCommand(EditPaymentAsync, () => CanEditDelete(null));
            DeletePaymentCommand = new AsyncRelayCommand(DeletePaymentAsync, () => CanEditDelete(null));
            ExportToExcelCommand = new AsyncRelayCommand(ExportToExcelAsync);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var currentPayment = SelectedPayment;
                var currentBookingId = NewPayment?.BookingId ?? 0; 
                var payments = await _apiClient.GetPaymentsAsync();
                var bookings = await _apiClient.GetBookingsAsync();

                System.Diagnostics.Debug.WriteLine($"Получено платежей: {payments?.Count ?? 0}");
                System.Diagnostics.Debug.WriteLine($"Получено бронирований: {bookings?.Count ?? 0}");

                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    if (payments != null && payments.Any())
                    {
                        Payments.Clear();
                        foreach (var payment in payments) Payments.Add(payment);
                        SelectedPayment = Payments.FirstOrDefault(p => p == currentPayment) ?? (Payments.Count > 0 ? Payments[0] : null);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Нет данных платежей.");
                        NotificationMessage = "Нет данных платежей!";
                        Task.Delay(2000).ContinueWith(_ => NotificationMessage = "");
                    }

                    if (bookings != null && bookings.Any())
                    {
                        AvailableBookings.Clear();
                        foreach (var booking in bookings) AvailableBookings.Add(booking);
                        NewPayment.BookingId = AvailableBookings.Any(b => b.BookingId == currentBookingId)
                            ? currentBookingId
                            : AvailableBookings[0].BookingId;
                        System.Diagnostics.Debug.WriteLine($"Set BookingId to: {NewPayment.BookingId}");
                        NotifyPropertyChanged(nameof(NewPayment)); 
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Нет данных бронирований.");
                        NotificationMessage = "Нет доступных бронирований!";
                        Task.Delay(2000).ContinueWith(_ => NotificationMessage = "");
                        NewPayment.BookingId = 0; 
                        NotifyPropertyChanged(nameof(NewPayment));
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    NotificationMessage = "Ошибка загрузки данных!";
                    Task.Delay(2000).ContinueWith(_ => NotificationMessage = "");
                });
            }
        }

        private void UpdateFormFromSelectedPayment()
        {
            if (SelectedPayment != null && NewPayment != null)
            {
                NewPayment.PaymentId = SelectedPayment.PaymentId;
                NewPayment.BookingId = SelectedPayment.BookingId;
                NewPayment.Amount = SelectedPayment.Amount;
                NewPayment.PaymentDate = SelectedPayment.PaymentDate;
                NewPayment.PaymentMethod = SelectedPayment.PaymentMethod;
                NewPayment.Status = SelectedPayment.Status;
                NotifyPropertyChanged(nameof(NewPayment));
            }
        }

        private async Task RefreshDataAsync()
        {
            LoadData();
            NotificationMessage = "Данные обновлены!";
        }

        private async Task CreatePaymentAsync()
        {
            if (NewPayment.BookingId <= 0 || NewPayment.Amount <= 0 || string.IsNullOrEmpty(NewPayment.Status))
            {
                NotificationMessage = "Выберите значение из списка и заполните Amount и статус!";
                await Task.Delay(10000);
                NotificationMessage = "";
                return;
            }

            try
            {
                var payment = new Payment
                {
                    BookingId = NewPayment.BookingId,
                    Amount = NewPayment.Amount,
                    PaymentDate = NewPayment.PaymentDate,
                    PaymentMethod = NewPayment.PaymentMethod ?? "Кредитная карта",
                    Status = NewPayment.Status
                };
                System.Diagnostics.Debug.WriteLine($"Создание платежа: {Newtonsoft.Json.JsonConvert.SerializeObject(payment)}");
                var createdPayment = await _apiClient.CreatePaymentAsync(payment);
                if (createdPayment != null && createdPayment.PaymentId > 0)
                {
                    LoadData();
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        if (Payments.Any()) SelectedPayment = Payments[0];
                        NewPayment.BookingId = AvailableBookings.Any(b => b.BookingId == NewPayment.BookingId)
                            ? NewPayment.BookingId
                            : AvailableBookings.Any() ? AvailableBookings[0].BookingId : 0;
                        NotifyPropertyChanged(nameof(NewPayment));
                    });
                    UpdateFormFromSelectedPayment();
                    NotificationMessage = "Платеж создан!";
                }
                else
                {
                    NotificationMessage = "Ошибка создания платежа!";
                    await Task.Delay(10000);
                    NotificationMessage = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка создания платежа: {ex.Message}");
                NotificationMessage = "Ошибка создания платежа!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async Task EditPaymentAsync()
        {
            if (NewPayment == null || string.IsNullOrEmpty(NewPayment.Status) || NewPayment.BookingId <= 0 || NewPayment.PaymentId <= 0)
            {
                NotificationMessage = "Заполните корректные данные для редактирования!";
                await Task.Delay(10000);
                NotificationMessage = "";
                return;
            }

            try
            {
                var paymentToUpdate = new Payment
                {
                    PaymentId = NewPayment.PaymentId,
                    BookingId = NewPayment.BookingId,
                    Amount = NewPayment.Amount,
                    PaymentDate = NewPayment.PaymentDate,
                    PaymentMethod = NewPayment.PaymentMethod ?? "Кредитная карта",
                    Status = NewPayment.Status
                };
                await _apiClient.UpdatePaymentAsync(paymentToUpdate);
                LoadData();
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    if (Payments.Any()) SelectedPayment = Payments[0];
                    NewPayment.BookingId = AvailableBookings.Any(b => b.BookingId == NewPayment.BookingId)
                        ? NewPayment.BookingId
                        : AvailableBookings.Any() ? AvailableBookings[0].BookingId : 0;
                    NotifyPropertyChanged(nameof(NewPayment));
                });
                UpdateFormFromSelectedPayment();
                NotificationMessage = "Платеж отредактирован!";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка редактирования платежа: {ex.Message}");
                NotificationMessage = "Ошибка редактирования платежа!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private async Task DeletePaymentAsync()
        {
            if (SelectedPayment == null)
            {
                NotificationMessage = "Выберите платеж для удаления!";
                await Task.Delay(10000);
                NotificationMessage = "";
                return;
            }

            try
            {
                await _apiClient.DeletePaymentAsync(SelectedPayment.PaymentId);
                LoadData();
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    if (Payments.Any()) SelectedPayment = Payments[0]; 
                });
                UpdateFormFromSelectedPayment(); 
                NotificationMessage = "Платеж удалён!";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка удаления платежа: {ex.Message}");
                NotificationMessage = "Ошибка удаления платежа!";
                await Task.Delay(10000);
                NotificationMessage = "";
            }
        }

        private bool CanExecute(object parameter)
        {
            return true; 
        }

        private bool CanEditDelete(object parameter)
        {
            return SelectedPayment != null;
        }

        private async Task ExportToExcelAsync()
        {
            try
            {
                if (Payments == null || !Payments.Any())
                {
                    NotificationMessage = "Нет данных для экспорта!";
                    await Task.Delay(10000);
                    NotificationMessage = "";
                    return;
                }

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Платежи");
                    worksheet.Cells[1, 1].Value = "ID Платежа";
                    worksheet.Cells[1, 2].Value = "Номер Брони";
                    worksheet.Cells[1, 3].Value = "Сумма";
                    worksheet.Cells[1, 4].Value = "Дата Платежа";
                    worksheet.Cells[1, 5].Value = "Метод Оплаты";
                    worksheet.Cells[1, 6].Value = "Статус";

                    int row = 2;
                    foreach (var payment in Payments)
                    {
                        worksheet.Cells[row, 1].Value = payment.PaymentId;
                        worksheet.Cells[row, 2].Value = payment.BookingId;
                        worksheet.Cells[row, 3].Value = payment.Amount;
                        worksheet.Cells[row, 4].Value = payment.PaymentDate.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cells[row, 5].Value = payment.PaymentMethod ?? "N/A";
                        worksheet.Cells[row, 6].Value = payment.Status ?? "N/A";
                        row++;
                    }

                    var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var filePath = Path.Combine(desktopPath, "Платежи_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                    NotificationMessage = "Экспортировано!";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка экспорта в Excel: {ex.Message}");
                NotificationMessage = "Ошибка экспорта!";
                await Task.Delay(2000);
                NotificationMessage = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}