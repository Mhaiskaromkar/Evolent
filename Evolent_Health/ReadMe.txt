Evolent Web API Project
--------------------------------
This Restful Web API sample is created To provide interfaces to add ,edit and delete contacts and information
using Repository pattern and UnitOfWork along with dependency injection.


Project Directory Contains Evolent_Health.mdf database file and also script file which need to attach to 
sql server instance and need to change below connection string datasource in a web.config file.

    <add name="Evolent_HealthEntities" connectionString="metadata=res://*/Model.Evolent.csdl|res://*/Model.Evolent.ssdl|res://*/Model.Evolent.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ADMIN-PC\sqlexpress;initial catalog=Evolent_Health;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

After change above connection string run Evolent.WebApi project sample.



First Need to Attach Evolent.mdf database file.

This sample is created for Evolent web api Using Repositroy Pattern and UnitOfWork alomg with dependency injection contains projects for
1] Evolent.DataModel
2} Evolent.Entities
3] Evolent.Services
4] Evolent.WebApi
5] Evolent.WebApi.Tests