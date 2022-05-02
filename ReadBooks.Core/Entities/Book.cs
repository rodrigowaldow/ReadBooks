using ReadBooks.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooks.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string description, string author, string publisher, int idBookOwner, int totalPages)
        {
            Title = title;
            Description = description;
            Author = author;
            Publisher = publisher;
            IdBookOwner = idBookOwner;
            TotalPages = totalPages;

            CreatedAt = DateTime.Now;
            Status = BookStatusEnum.Created;
            Notes = new List<BookNote>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int IdBookOwner { get; private set; }
        public User BookOwner { get; private set; }
        public int TotalPages { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public BookStatusEnum Status { get; private set; }
        public List<BookNote> Notes { get; private set; }

        public void Cancel()
        {
            if (Status == BookStatusEnum.Created || Status == BookStatusEnum.InProgress)
            {
                Status = BookStatusEnum.Cancelled;
            }
        }

        public void Finish()
        {
            if (Status == BookStatusEnum.PaymentPending)
            {
                Status = BookStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Start()
        {
            if (Status == BookStatusEnum.Created)
            {
                Status = BookStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, int totalPages)
        {
            Title = title;
            Description = description;
            TotalPages = totalPages;
        }
    }
}
