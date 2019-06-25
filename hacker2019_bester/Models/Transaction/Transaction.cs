using Nest;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace hacker2019_bester.Models
{

    [ElasticsearchType(IdProperty = nameof(transactionId))]
    public class Transaction
    {
        [NotMapped]
        public string transactionId { get; set; }
        public PaymentResponse transaction { get; set; }
        public Profile customer { get; set; }
        public PaymentRequest payment { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
