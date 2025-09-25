// See https://aka.ms/new-console-template for more information

using ClinicaSalud.Models;

// Creating patients
Patient patient= new Patient();
patient.Name = "Juan";
patient.Lastname = "Pérez";
patient.Age = 30;
patient.Id = 12345678;
patient.Symptom = "I have Cancer";
Console.WriteLine($"Patient information:\nId:{patient.Id}\nName:{patient.Name} {patient.Lastname}" +
                  $"\nAge:{patient.Age}\nSymptom:{patient.Symptom}");

