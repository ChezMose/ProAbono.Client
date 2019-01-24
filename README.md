# ProAbono.Client

Designed to work with the ProAbono API Live

# What it does

It's a .Net client for the ProAbono API
It contains an internal cache to reduce the calls to the 'Usage' resource and make your application faster.


# Getting started - Configuration

Add this configuration in your configuration file (don't forget to ajust all values)

```xml
  <appSettings>
	  <!-- ProAbono configuration -->
	  <add key="ProAbono.Api.Endpoint.Api" value="http://api-xxxxxxxx.proabono.com" />
	  <add key="ProAbono.Api.KeyAgent" value="your-agent-key" />
	  <add key="ProAbono.Api.KeyApi" value="your-api-key" />
  </appSettings>
```

# Getting started - Example

using ProAbonoApi;

```c#
namespace MyApp
{
	public class Demo
	{
		public void Test()
		{
			// get the current usage
			Usage usage;
			var report = Client.Current.FastGetUsage(out usage, "customer-18", "feature-4", false);
			if (report.IsSuccess())
			{
				
			}
		}
	}
}
```
