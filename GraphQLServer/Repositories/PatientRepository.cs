namespace GraphQLServer.Repositories
{
    public class PatientRepository
    {
        private readonly Dictionary<Guid, Patient> _journal = new List<Patient>()
        {
            new()
            {
                FullName = "Vadya",
                Age = 21,
                Analyses = new() { new() { Name = "wer|werwe|werew"}, new() { Name = "name2" } },
                Id = Guid.NewGuid()
            },
            new()
            {
                FullName = "Katya",
                Age = 19,
                Analyses = new() { new() { Name = "wer|000|werew"}, new() { Name = "name3" }},
                Id = Guid.NewGuid()
            }
        }.ToDictionary(x => x.Id);

        public Patient Create(Patient patient)
        {
            if (patient is not null)
            {
                var id = Guid.NewGuid();
                patient.Id = id;
                _journal.Add(id, patient);
            }
            return patient;
        }

        public List<Patient> GetPatients()
        {
            return _journal.Values.ToList();
        }

        public Patient GetPatientById(Guid id)
        {
            if (_journal.ContainsKey(id)) return _journal[id];
            else throw new KeyNotFoundException("Patient doesn't exist");
        }

        public Patient Update(Patient updatePatient)
        {
            return _journal[updatePatient.Id] = updatePatient;
        }
        public void Delete(Guid id)
        {
            _journal.Remove(id);
        }
    }
}
