using System;

class Program
{
    static void Main(string[] args)
    {
        // Crear direcciones
        Address addressUSA = new Address("123 Main Street", "Rexburg", "ID", "USA");
        Address addressCanada = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        // Crear clientes
        Customer customer1 = new Customer("John Smith", addressUSA);
        Customer customer2 = new Customer("Maria Garcia", addressCanada);

        // Crear productos para el primer pedido
        Product product1 = new Product("Laptop", "P001", 999.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("Keyboard", "P003", 75.00, 1);

        // Crear productos para el segundo pedido
        Product product4 = new Product("Monitor", "P004", 299.99, 1);
        Product product5 = new Product("USB Cable", "P005", 9.99, 3);

        // Crear pedidos
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Mostrar resultados del primer pedido
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        // Mostrar resultados del segundo pedido
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}