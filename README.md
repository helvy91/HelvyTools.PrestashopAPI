🚀 HelvyTools.PrestashopAPI - C# .NET Library for PrestaShop API Consumption

HelvyTools.PrestashopAPI is a lightweight C# .NET library tailored for interacting with PrestaShop's API. Designed to simplify the process of integrating PrestaShop functionality into your C# .NET projects, this library offers an easy-to-use solution for managing your PrestaShop store programmatically.

Features:

1. Effortless Integration: Quickly integrate HelvyTools.PrestashopAPI into your C# .NET project with minimal configuration.
2. Streamlined API Interaction: Simplify the handling of PrestaShop API requests and responses.
3. Resource Operations: Perform common operations on various PrestaShop resources, including products, stocks and product pictures

Getting Started
```
var client = new PrestaShopApiClient("your_store_url",  "your_api_key");
```
Example: Retrieve Products:
```
// Get single product by id
var product = client.GetAsync<Product>(12);

// Get filtered product list
var products = client.GetAsync<Product>("price", 120);
```


Happy coding with HelvyTools.PrestashopAPI! 🚀🛒
