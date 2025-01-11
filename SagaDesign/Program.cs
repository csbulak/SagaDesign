using SagaDesign;
using SagaDesign.Services;

var inventoryService = new InventoryService();
var paymentService = new PaymentService();
var shippingService = new ShippingService();
var orderSagaService = new OrderSagaService(inventoryService, paymentService, shippingService);

var order = new Order { Id = 1, Product = "Laptop", Amount = 1500.00M };

bool success = await orderSagaService.ProcessOrderAsync(order);

if (success)
    Console.WriteLine("Sipariş başarıyla işlendi.");
else
    Console.WriteLine("Sipariş işleme başarısız oldu ve telafi edildi.");