## Project Information

**Diagram**

<img src="https://github.com/YildirimMehmet/aspnet-core-microservices-phone-dictionary/blob/master/assets/readme/PhoneDirectoryDiagram.png?raw=true" width="700" />

**Test Coverage**

<img src="https://github.com/YildirimMehmet/aspnet-core-microservices-phone-dictionary/blob/master/assets/readme/PhoneDirectoryTestCoverage.png?raw=true" width="700" />


## Run the project

**For Docker Compose**

    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

| Service | Swagger |
|--|--|
| Api Gateway | http://localhost:5360/swagger/index.html |
| Company Api | http://localhost:5361/swagger/index.html |
| Contact Api | http://localhost:5362/swagger/index.html |
| Person Api | http://localhost:5363/swagger/index.html |
| Report Api | http://localhost:5364/swagger/index.html |

## Tech Stacks

 - ASP.NET Core
 - PostgreSQL, EF
 - RabbitMQ, MassTransit
 - XUnit, Moq
 - Ocelot Gateway
 - Docker
