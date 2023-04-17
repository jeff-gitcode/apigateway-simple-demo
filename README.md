Api Gateay Simple Demo

Tech Stack

[x] Routing
[x] Ocelot
[] YARP
[] Rate Limiting
[] Caching /SPAN
[] Retry policies / QoS
[] Load Balancing
[] Logging

## Simple api

![alt text](./doc/doc/webapi-demo.jpg)

## Ocelot

![alt text](./doc/doc/ocelot-demo.jpg)

```javascript
$ dotnet new sln -o apigateway-simple-demo

$ dotnet new webapi -o Presentation.WebApi

$ dotnet sln add .\Presentation.WebApi\Presentation.WebApi.csproj

$ dotnet build

$ dotnet run --project .\Presentation.WebApi\

# run swagger
http://localhost:5166/swagger/index.html

# add api gateway project
$ dotnet new webapi -o Ocelot.ApiGateway

$ dotnet sln add .\Ocelot.ApiGateway\Ocelot.ApiGateway.csproj

# add api gateway package
dotnet add .\Ocelot.ApiGateway\ package Ocelot

# setup ocelot.json for downstream(webapi) and upstream(ocelot)
```
