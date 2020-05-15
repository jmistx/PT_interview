# [Positive Technologies](https://www.ptsecurity.com/) job interview task

```
Disclaimer: This code is old but I still think some pieces are clean and nice. 
If you somewhy interested my codestyle, I advise to start from tests.
```

## Task explanation

**App A** and **App B** communicate through different transports to calculate Fibonacci Numbers. 

- **A** initiate communication
- **A** send **N[i]** to **B**
- **B** calculates **N[i - 1] + N[i]** then send it to **A**
- **A** do the same thing
- infinite loop here

Features:
- **A** get initial number from `stdin`.
- **A** -> **B** communication through REST WebApi
- **B** -> **A** communication through MessageBus

Desired technologies:
- ASP.NET WebApi
- RestSharp
- MassTransit Bus
- Log4Net
- StructureMap

Prerequisites:
- Erlang
- RabbitMQ guest:guest@localhost
