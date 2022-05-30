using GraphQLServer.Models;

namespace GraphQLServer.Repositories
{
    public class PatientRepository
    {
        private readonly Dictionary<Guid, PatientModel> _journal = new List<PatientModel>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Vadym",
                IsRecordActive = true,
                Gender  = "male",
                BirthDate = new(2001,02,19),
                Telecom = "Vadyms telecom",
                IsDeceased = false,
                DeceasedDateTime = null,
                Adress = "Ukraine",
                MaritalStatus  = "norm",
                IsMultipleBirth  = false,
                MultipleBirthCount  = 1,
                Photo  = ":)",
                Contact = new()
                {
                    Address = "Lviv",
                    Name = "Something",
                    Organization = "KPI",
                    Period = new()
                    {
                        StartDate = new(2012, 5, 1),
                        EndDate = null
                    },
                    Relationship = "Katya",
                    Telecom = null
                },
                Communications = new List<Communication>
                {
                    new()
                    {
                        Language = "ua",
                        Preferred = true,
                    },
                    new()
                    {
                        Language = "en",
                        Preferred = false,
                    }
                },
                GeneralPractitioner = new()
                {
                    Name = "Bandera",
                    Organization = "Bandera Org"
                },
                ManagingOrganization = "Dell"
            },
             new()
            {
                Id = Guid.NewGuid(),
                Name = "Katya",
                IsRecordActive = true,
                Gender  = "female",
                BirthDate = new(2000, 09, 23),
                Telecom = "Katyas telecom",
                IsDeceased = false,
                DeceasedDateTime = null,
                Adress = "Ukraine",
                MaritalStatus  = "super norm",
                IsMultipleBirth  = false,
                MultipleBirthCount  = 1,
                Photo  = "(=^･ω･^=)",
                Contact = new()
                {
                    Address = "Lviv",
                    Name = "Something",
                    Organization = "KPI",
                    Period = new()
                    {
                        StartDate = new(2014, 09, 3),
                        EndDate = new(2020, 01, 21),
                    },
                    Relationship = "Vadya",
                    Telecom = null
                },
                Communications = new List<Communication>
                {
                    new()
                    {
                        Language = "ua",
                        Preferred = true,
                    },
                    new()
                    {
                        Language = "en",
                        Preferred = false,
                    }
                },
                GeneralPractitioner = new()
                {
                    Name = "Sternenko",
                    Organization = "Sternenko Org"
                },
                ManagingOrganization = "Ololo"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Borya",
                IsRecordActive = true,
                Gender  = "female",
                BirthDate = new(2007, 09, 23),
                Telecom = "Boryas telecom",
                IsDeceased = false,
                DeceasedDateTime = null,
                Adress = "BNR",
                MaritalStatus  = "ne norm",
                IsMultipleBirth  = false,
                MultipleBirthCount  = 1,
                Photo  = "(=^･ω･^=)",
                Contact = new()
                {
                    Address = "Lviv2",
                    Name = "Something2",
                    Organization = "KPI2",
                    Period = new()
                    {
                        StartDate = new(2014, 09, 3),
                        EndDate = new(2020, 01, 21),
                    },
                    Relationship = "((((",
                    Telecom = null
                },
                Communications = new List<Communication>
                {
                    new()
                    {
                        Language = "ua",
                        Preferred = true,
                    },
                    new()
                    {
                        Language = "ru",
                        Preferred = false,
                    }
                },
                GeneralPractitioner = new()
                {
                    Name = "Sternenko",
                    Organization = "Sternenko Org"
                },
                ManagingOrganization = "Ololo"
            }
        }.ToDictionary(x => x.Id);

        public PatientModel Create(PatientModel patient)
        {
            if (patient is not null)
            {
                var id = Guid.NewGuid();
                patient.Id = id;
                _journal.Add(id, patient);
            }
            return patient;
        }

        public List<PatientModel> GetPatients()
        {
            return _journal.Values.ToList();
        }

        public PatientModel GetPatientById(Guid id)
        {
            if (_journal.ContainsKey(id))
            {
                return _journal[id];
            }

            throw new KeyNotFoundException("Patient doesn't exist");
        }

        public PatientModel Update(PatientModel updatePatient)
        {
            if (_journal.ContainsKey(updatePatient.Id))
            {
                return _journal[updatePatient.Id] = updatePatient;
            }
            throw new KeyNotFoundException("Patient doesn't exist");
        }
        public void Delete(Guid id)
        {
            if (_journal.ContainsKey(id))
            {
                _journal.Remove(id);
            }
            else
            {
                throw new KeyNotFoundException("Patient doesn't exist");
            }
        }
    }
}
