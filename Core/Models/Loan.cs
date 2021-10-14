using System;
using System.Runtime.Serialization;

namespace Core.Models
{
    [DataContract]
    public class Loan
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public DateTime LoanDate { get; set; }

        [DataMember]
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
