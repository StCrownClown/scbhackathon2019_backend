using hacker2019_bester.Models;

namespace hacker2019_bester.Service
{
    public interface IElasticSearch
    {
        void CreateJSONDocumentToIndex(Transaction transaction);
    }
}
