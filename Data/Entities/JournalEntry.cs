using System;
using System.ComponentModel.DataAnnotations;

namespace WeCare.Data.Entities
{
    public class JournalEntry
    {
        public int Id { get; protected set; }
        public DateTime Date { get; protected set; } = DateTime.Now;
        public string Entry { get; protected set; }
        public int JournalId { get; protected set; }
        

        public JournalEntry(string entry)
        {
            Entry = entry;
           
        }

    }
}