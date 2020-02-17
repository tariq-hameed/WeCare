using System;

namespace WeCare.Data.Entities
{
    public class JournalEntry
    {
        public int Id { get;  set; }
        public DateTime Date { get;  set; } = DateTime.Now;
        public string Entry { get;  set; }
        public int JournalId { get;  set; }

        public JournalEntry(string entry)
        {
            Entry = entry;
        }

        public JournalEntry(int id, string entry, DateTime date, int journalId)
            : this(entry)
        {
            Id = id;
            Date = date;
            JournalId = journalId;
        }
    }
}

