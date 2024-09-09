using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace dotnet
{
    public class OnCreate
    {
        private readonly ILogger _logger;
        private const string _LOG_FORMAT = 
        """
        Number of documents modified: {0}
        - {1}
        """;

        public OnCreate(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<OnCreate>();
        }

        [Function("OnCreate")]
        public void Run([CosmosDBTrigger(
            databaseName: "%COSMOSDB_DATABASENAME%",
            containerName: "%COSMOSDB_CONTAINERNAME%",
            Connection = "COSMOSDB_CONNECTIONSTRING",
            LeaseContainerName = "%COSMOSDB_LEASECONTAINERNAME%",
            CreateLeaseContainerIfNotExists = true)] IReadOnlyList<MyDocument> input)
        {
            if (input != null && input.Count > 0)
            {
                _logger.LogInformation(
                    string.Format(_LOG_FORMAT, 
                        input.Count, 
                        string.Join("\n- ", input.Select(doc => doc.id))
                    ));
            }
        }
    }

    public class MyDocument
    {
        public string id { get; set; }
    }
}
