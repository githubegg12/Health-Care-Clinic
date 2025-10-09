using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories
{
    public static class PetRepository
    {

        /// Adds a new pet to a patient by their ID.
        public static bool AddPetToPatient(Guid patientId, Pet pet)
        {
            var patient = PatientRepository.GetById(patientId);
            if (patient == null)
                return false;

            patient.Pets.Add(pet);
            return true;
        }


        /// Retrieves all pets associated with a specific patient.
        public static List<Pet> GetPetsByPatient(Guid patientId)
        {
            var patient = PatientRepository.GetById(patientId);
            return patient?.Pets ?? new List<Pet>();
        }
        
        /// Searches for pets by name within a patient's pet list.
        public static List<Pet> SearchPetByName(Guid patientId, string petName)
        {
            var patient = PatientRepository.GetById(patientId);
            if (patient == null)
                return new List<Pet>();

            return patient.Pets
                .Where(p => p.PetName.Equals(petName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// Removes a pet from a patient by pet name.
        public static bool RemovePet(Guid patientId, string petName)
        {
            var patient = PatientRepository.GetById(patientId);
            if (patient == null)
                return false;

            var petToRemove = patient.Pets
                .FirstOrDefault(p => p.PetName.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (petToRemove != null)
            {
                patient.Pets.Remove(petToRemove);
                return true;
            }

            return false;
        }

        /// Updates an existing pet's data by replacing it with a new object.
        public static bool UpdatePet(Guid patientId, string oldPetName, Pet updatedPet)
        {
            var patient = PatientRepository.GetById(patientId);
            if (patient == null)
                return false;

            var petIndex = patient.Pets.FindIndex(p => p.PetName.Equals(oldPetName, StringComparison.OrdinalIgnoreCase));

            if (petIndex >= 0)
            {
                patient.Pets[petIndex] = updatedPet;
                return true;
            }
            return false;
        }
    }
}
