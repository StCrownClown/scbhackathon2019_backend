using Elasticsearch.Net;
using hacker2019_bester.Configurations;
using hacker2019_bester.Models;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace hacker2019_bester.Service
{
    public class ElasticSearch : ExternalService, IElasticSearch
    {
        private readonly string _indexName = "bester";
        private ElasticClient _elasticClient;
        private SingleNodeConnectionPool _connnectionPool;
        private ConnectionSettings _awsConnectionSetting;

        public ElasticSearch(IOptions<AWSConfiguration> AWSConfiguration) : base(AWSConfiguration.Value.elasticSearchEndpoint)
        {
            _connnectionPool = new SingleNodeConnectionPool(new Uri(AWSConfiguration.Value.elasticSearchEndpoint));
            _awsConnectionSetting = new ConnectionSettings(_connnectionPool);
            _elasticClient = new ElasticClient(_awsConnectionSetting);

            try
            {
                IExistsResponse _checkIndex = _elasticClient.IndexExists(_indexName);

                _awsConnectionSetting.DefaultIndex(_indexName).DefaultTypeName(_indexName);
                _elasticClient = new ElasticClient(_awsConnectionSetting);
            }
            catch
            {
            }
        }

        public void CreateJSONDocumentToIndex(Transaction transaction)
        {
            try
            {
                _elasticClient.IndexDocument(transaction);
            }
            catch
            {
                return;
            }
        }
    }
}
