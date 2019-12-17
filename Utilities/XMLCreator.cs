using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinic.API.Utilities
{
    public static class XMLCreator
    {
        public static void CreatePrescription(Prescription prescription)
        {
            string fileName = "Documents/Prescriptions/" +prescription.Id+".xml";

            if (File.Exists(fileName))
                throw new Exception("You cant modyfy prescription");


            XDocument newPrescriptionFile = new XDocument(
                new XComment("Recepta_nr " + prescription.Id),
                new XElement("Dane",
                    new XElement("Pacjent",
                        new XElement("Imie", prescription.Appointment.Patient.FirstName),
                        new XElement("Nazwisko", prescription.Appointment.Patient.SecondName),
                        new XElement("PESEL", prescription.Appointment.Patient.Pesel),
                        new XElement("Adres", prescription.Appointment.Patient.Street + prescription.Appointment.Patient.HouseNumber),
                        new XElement("Miejscowosc", prescription.Appointment.Patient.PostCode + prescription.Appointment.Patient.City)
                        ),
                    new XElement("Lekarz",
                        new XElement("Imie", prescription.Appointment.Doctor.FirstName),
                        new XElement("Nazwisko", prescription.Appointment.Doctor.SecondName),
                        new XElement("Nr_licencji", prescription.Appointment.Doctor.Id)
                    ),
                   new XElement("Lek", prescription.Drug),
                   new XElement("Data_wystawienia", prescription.CreatedAt)

                )
            );

            newPrescriptionFile.Save(fileName);

        }

        public static void CreateReferral(Referral referral)
        {
            string fileName = "Documents/Referrals/" + referral.Id + ".xml";

            if (File.Exists(fileName))
                throw new Exception("You cant modyfy prescription");


            XDocument newReferralFile = new XDocument(
                new XComment("Skierowanie " + referral.Id),
                new XElement("Dane",
                    new XElement("Pacjent",
                        new XElement("Imie", referral.Appointment.Patient.FirstName),
                        new XElement("Nazwisko", referral.Appointment.Patient.SecondName),
                        new XElement("PESEL", referral.Appointment.Patient.Pesel),
                        new XElement("Adres", referral.Appointment.Patient.Street + referral.Appointment.Patient.HouseNumber),
                        new XElement("Miejscowosc", referral.Appointment.Patient.PostCode + referral.Appointment.Patient.City)
                        ),
                    new XElement("Lekarz",
                        new XElement("Imie", referral.Appointment.Doctor.FirstName),
                        new XElement("Nazwisko", referral.Appointment.Doctor.SecondName),
                        new XElement("Nr_licencji", referral.Appointment.Doctor.Id)
                    ),
                   new XElement("SKierowanie_na", referral.Treatment),
                   new XElement("Data_wystawienia", referral.CreatedAt)

                )
            );

            newReferralFile.Save(fileName);

        }
    }
}
