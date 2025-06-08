using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightBooking.Models;

namespace FlightBooking.Services
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7090/api/") };
        }

        public async Task<List<Flight>> GetFlightsAsync()
        {
            var response = await _client.GetStringAsync("flights");
            return JsonConvert.DeserializeObject<List<Flight>>(response);
        }

        public async Task<Flight> CreateFlightAsync(Flight flight)
        {
            var content = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            Console.WriteLine($"Отправляем: {await content.ReadAsStringAsync()}");
            var response = await _client.PostAsync("flights", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Получили статус: {response.StatusCode}, тело: {responseContent}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка сервера: {response.StatusCode} - {responseContent}");
            }
            return JsonConvert.DeserializeObject<Flight>(responseContent);
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            var json = JsonConvert.SerializeObject(flight);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"flights/{flight.FlightId}", content);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка обновления: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task DeleteFlightAsync(int flightId)
        {
            var response = await _client.DeleteAsync($"flights/{flightId}");
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка удаления: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _client.GetStringAsync("users");
            return JsonConvert.DeserializeObject<List<User>>(response);
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            var response = await _client.GetStringAsync("bookings");
            return JsonConvert.DeserializeObject<List<Booking>>(response);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
            Console.WriteLine($"Отправляем: {await content.ReadAsStringAsync()}");
            var response = await _client.PostAsync("bookings", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Получили статус: {response.StatusCode}, тело: {responseContent}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка сервера: {response.StatusCode} - {responseContent}");
            }
            return JsonConvert.DeserializeObject<Booking>(responseContent);
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var response = await _client.DeleteAsync($"bookings/{bookingId}");
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка удаления: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            var json = JsonConvert.SerializeObject(booking);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"bookings/{booking.BookingId}", content);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка обновления: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("users", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"users/{user.UserId}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(responseContent);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var response = await _client.DeleteAsync($"users/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка удаления: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            var response = await _client.GetStringAsync("payments");
            return JsonConvert.DeserializeObject<List<Payment>>(response);
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            var content = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");
            Console.WriteLine($"Отправляем: {await content.ReadAsStringAsync()}");
            var response = await _client.PostAsync("payments", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Получили статус: {response.StatusCode}, тело: {responseContent}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка сервера: {response.StatusCode} - {responseContent}");
            }
            return JsonConvert.DeserializeObject<Payment>(responseContent);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            var json = JsonConvert.SerializeObject(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"payments/{payment.PaymentId}", content);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка обновления платежа: {response.StatusCode} - {responseContent}");
            }
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var response = await _client.DeleteAsync($"payments/{paymentId}");
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ошибка удаления: {response.StatusCode} - {responseContent}");
            }
        }
    }
}