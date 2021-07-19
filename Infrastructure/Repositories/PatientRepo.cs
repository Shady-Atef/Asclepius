using Domain.PatientAggregate;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class PatientRepo
    {
        private ImhotepContext Context { get; }

        public PatientRepo(ImhotepContext _context)
        {
            this.Context = _context;
        }

        public void Add(Patient patient)
        {
            Context.Patient.Add(patient);
        }

        public long GetNextRoaderKey()
        {
            return Context.GetNextSequenceValue("PatientSeq");
        }
    }
}