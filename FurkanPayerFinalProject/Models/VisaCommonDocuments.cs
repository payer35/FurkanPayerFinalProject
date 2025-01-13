using System.Collections.Generic;
using System.Reflection.Metadata;

namespace FurkanPayerFinalProject.Models
{
    public static class VisaCommonDocuments
    {
        public static readonly List<Document> CommonDocuments = new()
        {
            new Document
            {
                Name = "Valid Passport",
                Details = "Must be valid for at least 6 months after the planned return date.",
                Required = true
            },
            new Document
            {
                Name = "Visa Application Form",
                Details = "Must be completed and signed.",
                Required = true
            },
            new Document
            {
                Name = "Biometric Photo",
                Details = "Recent photo with white background, size 35x45mm.",
                Required = true
            }
        };

        public static readonly List<Document> FinancialDocuments = new()
        {
            new Document
            {
                Name = "Bank Statement",
                Details = "Bank statements from the last 3 months to prove financial stability.",
                Required = true
            },
            new Document
            {
                Name = "Travel Health Insurance",
                Details = "Insurance with a minimum coverage of €30,000.",
                Required = true
            }
        };
    }
}
