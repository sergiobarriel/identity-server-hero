# Identity Server Hero
## Examples of grant types for different use cases.

### Client credentials

![screenshot](https://github.com/sergiobarriel/identity-server-hero/blob/master/img/client_credentials.PNG)

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

![screenshot](https://github.com/sergiobarriel/identity-server-hero/blob/master/img/resource_owner_password.PNG)

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

### Implicit 
...

### How to add Identity Server UI

On solution folder:

```bash
$ dotnet new -i identityserver4.templates
```

On identity server 4 project folder:

```bash
$ cd Superheros.IdentityServer
$ dotnet new is4ui
```
