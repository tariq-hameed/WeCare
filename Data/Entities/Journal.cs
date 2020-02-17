using System.Collections.Generic;

namespace WeCare.Data.Entities
{
    public class Journal
    {
        public int Id { get; protected set; }
        public IList<JournalEntry> Entries { get; set; } = new List<JournalEntry>();
        public int PatientId { get; protected set; }

        public Journal(int id, int patientId)
        {
            Id = id;
            PatientId = patientId;
        }


        public Journal(int patientId)
        {
            PatientId = patientId;
        }
    }
}