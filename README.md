# keypay-dotnetcore
KeyPay API Client for .Net Core 5.x
This repo is derived from the official KeyPay .Net 4.5.x client repo located at https://github.com/KeyPay/keypay-dotnet


### Get Started
The KeyPay Client can be installed using the Nuget package manager.

```
Install-Package KeyPay-Core
```

### Example
```csharp
	var apiKey = "{your KeyPay API Key goes here}";
	
	// Create a client instance
	var client = new KeyPayApiV2Client("https://api.yourpayroll.com.au/api/v2", apiKey)));
	
	// Retrieve a list of the businesses associated with the API Key
	var business = client.Business.List();
```

### More Help?
Please check out our [online documentation](http://api.keypay.com.au/) as a reference.
Check the tests project for basic examples of implementing the client.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
