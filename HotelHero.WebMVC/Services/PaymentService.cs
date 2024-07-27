using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace HotelHero.WebMVC.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly IAdminService _adminService;

		private readonly string _filePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Data/PaymentHistory.json";

		public PaymentService(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public List<Payment> GetPaymentHistory()
		{
			List<Payment>? paymentHistory = null;
			if (File.Exists(_filePath))
			{
				var paymentHistoryJson = File.ReadAllText(_filePath);
				paymentHistory = JsonConvert.DeserializeObject<List<Payment>>(paymentHistoryJson);
			}

			paymentHistory ??= new List<Payment>();

			return paymentHistory;
		}

		public Payment GetPayment(int id)
		{
			var paymentHistory = GetPaymentHistory();
			var payment = paymentHistory.Find(x => x.PaymentId == id);
			return payment;
		}

		public Payment CreatePayment(int userId, Reservation reservation)
		{
			var payment = new Payment(GetNewPaymentId(), userId, reservation, _adminService.GetAdditionalServicesList());
			SavePayment(payment);
			return payment;
		}

		public void SavePayment(Payment payment)
		{
			var paymentHistory = GetPaymentHistory();
			paymentHistory.Add(payment);

			var paymentHistoryJson = JsonConvert.SerializeObject(paymentHistory, Formatting.Indented);
			File.WriteAllText(_filePath, paymentHistoryJson);
		}

		public Payment UpdatePayment(Payment updatedPayment)
		{
			var paymentHistory = GetPaymentHistory();
			var payment = paymentHistory.Find(x => x.PaymentId == updatedPayment.PaymentId);
			var paymentIndex = paymentHistory.IndexOf(payment);

			paymentHistory[paymentIndex] = updatedPayment;

			var paymentHistoryJson = JsonConvert.SerializeObject(paymentHistory, Formatting.Indented);
			File.WriteAllText(_filePath, paymentHistoryJson);
			return paymentHistory[paymentIndex];

		}
		private int GetNewPaymentId()
		{
			var paymentHistory = GetPaymentHistory();
			var id = paymentHistory.Count + 1;
			return id;
		}

		public void CancelPayment(int paymentId)
		{
			var paymentHistory = GetPaymentHistory();
			var payment = paymentHistory.Find(x => x.PaymentId == paymentId);
			paymentHistory.Remove(payment);
		}
	}
}
