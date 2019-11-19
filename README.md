# Identity Server Hero
## Examples of grant types for different use cases.

### Client credentials
[Go to implementation](https://github.com/sergiobarriel/identity-server-hero/blob/master/Superheros/Superheros.Console/Flows/ClientCredentialsFlow.cs)

```csharp
var tokenClient = new TokenClient(httpClient, new TokenClientOptions()
{
    Address = discoveryDocument.TokenEndpoint,
    ClientId = _configuration["Flows:ClientCredentials:ClientId"],
    ClientSecret = _configuration["Flows:ClientCredentials:ClientSecret"],
});

var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync(_configuration["Flows:ClientCredentials:Resource"]);
```

### Resource owner password
[Go to implementation](https://github.com/sergiobarriel/identity-server-hero/blob/master/Superheros/Superheros.Console/Flows/ResourceOwnerPasswordFlow.cs)

```csharp
var tokenClient = new TokenClient(httpClient, new TokenClientOptions()
{
    Address = discoveryDocument.TokenEndpoint,
    ClientId = _configuration["Flows:ResourceOwnerPassword:ClientId"],
    ClientSecret = _configuration["Flows:ResourceOwnerPassword:ClientSecret"],
});

var tokenResponse = await tokenClient.RequestPasswordTokenAsync(credentials.username, credentials.password);
```
