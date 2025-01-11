namespace SagaDesign.Services;

public class PaymentService
{
    public async Task<bool> ProcessPaymentAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} için ödeme işleniyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
        return true; // Basitlik için başarılı kabul ediliyor
    }

    public async Task UndoProcessPaymentAsync(Order order)
    {
        Console.WriteLine($"Sipariş {order.Id} için ödeme geri alınıyor.");
        await Task.Delay(100); // Asenkron işlem simülasyonu
    }
}