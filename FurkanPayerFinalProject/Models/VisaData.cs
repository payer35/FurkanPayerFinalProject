using System.Collections.Generic;

namespace FurkanPayerFinalProject.Models
{
    public class VisaData
    {
        public Dictionary<string, DestinationCountry> Countries { get; set; } = new();
    }

    public class DestinationCountry
    {
        public string Name { get; set; }
        public Dictionary<string, VisaType> VisaTypes { get; set; } = new();
    }

    public class VisaType
    {
        public string Name { get; set; }
        public Dictionary<string, DurationType> Durations { get; set; } = new();
    }

    public class DurationType
    {
        public string Name { get; set; }
        public Dictionary<string, VisaDetails> ApplicantTypes { get; set; } = new();
    }

    public class VisaDetails
    {
        public List<Document> Documents { get; set; } = new();
        public string ProcessingTime { get; set; }
        public string Fee { get; set; }
    }

    public class Document
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public bool Required { get; set; }
    }

    public static class VisaDataProvider
    {
        public static VisaData GetVisaData()
        {
            return new VisaData
            {
                Countries = new Dictionary<string, DestinationCountry>
                {
                    { "Germany", CreateGermanyData() },
                    { "United States of America", CreateAmericaData() }
                }
            };
        }

        private static DestinationCountry CreateGermanyData()
        {
            return new DestinationCountry
            {
                Name = "Germany",
                VisaTypes = new Dictionary<string, VisaType>
                {
                    { "Tourist", CreateVisaType("Tourist", "80 EUR", "10-15 days") },
                    { "Business", CreateVisaType("Business", "100 EUR", "7-10 days") },
                    { "Student", CreateVisaType("Student", "75 EUR", "15-20 days") }
                }
            };
        }

        private static DestinationCountry CreateAmericaData()
        {
            return new DestinationCountry
            {
                Name = "United States of America",
                VisaTypes = new Dictionary<string, VisaType>
                {
                    { "Tourist", CreateVisaType("Tourist", "160 USD", "3-5 days") },
                    { "Business", CreateVisaType("Business", "190 USD", "5-7 days") },
                    { "Student", CreateVisaType("Student", "140 USD", "7-10 days") }
                }
            };
        }

        private static VisaType CreateVisaType(string name, string fee, string processingTime)
        {
            return new VisaType
            {
                Name = name,
                Durations = new Dictionary<string, DurationType>
                {
                    { "Short Term", CreateDurationType("Short Term", fee, processingTime, name) },
                    { "Long Term", CreateDurationType("Long Term", fee, "20-25 days", name) }
                }
            };
        }

        private static DurationType CreateDurationType(string name, string fee, string processingTime, string visaType)
        {
            return new DurationType
            {
                Name = name,
                ApplicantTypes = new Dictionary<string, VisaDetails>
                {
                    { "Employed", CreateVisaDetails(fee, processingTime, true, visaType) },
                    { "Self-Employed", CreateVisaDetails(fee, processingTime, true, visaType) },
                    { "Student", CreateVisaDetails(fee, processingTime, false, visaType) },
                    { "Retired", CreateVisaDetails(fee, processingTime, false, visaType) }
                }
            };
        }

        private static VisaDetails CreateVisaDetails(string fee, string processingTime, bool includeEmploymentDocs, string visaType)
        {
            var documents = new List<Document>(VisaCommonDocuments.CommonDocuments);
            documents.AddRange(VisaCommonDocuments.FinancialDocuments);

            if (includeEmploymentDocs)
            {
                documents.Add(new Document
                {
                    Name = "Employment Letter",
                    Details = "Current employment verification letter from employer",
                    Required = true
                });
                documents.Add(new Document
                {
                    Name = "Pay Slips",
                    Details = "Last 3 months of pay slips",
                    Required = true
                });
            }

            if (visaType == "Tourist")
            {
                documents.Add(new Document
                {
                    Name = "Flight Reservation",
                    Details = "Confirmed flight reservation for your trip.",
                    Required = true
                });
                documents.Add(new Document
                {
                    Name = "Hotel Booking",
                    Details = "Proof of accommodation for your stay.",
                    Required = true
                });
            }
            else if (visaType == "Student")
            {
                documents.Add(new Document
                {
                    Name = "University Acceptance Letter",
                    Details = "Proof of admission to a recognized educational institution.",
                    Required = true
                });
                documents.Add(new Document
                {
                    Name = "Transcript",
                    Details = "Latest academic transcripts from your previous studies.",
                    Required = true
                });
            }
            else if (visaType == "Business")
            {
                documents.Add(new Document
                {
                    Name = "Invitation Letter",
                    Details = "Official invitation letter from a business entity in the destination country.",
                    Required = true
                });
                documents.Add(new Document
                {
                    Name = "Business Registration Certificate",
                    Details = "Certificate of registration of your business.",
                    Required = true
                });
            }

            return new VisaDetails
            {
                Documents = documents,
                ProcessingTime = processingTime,
                Fee = fee
            };
        }
    }
}
