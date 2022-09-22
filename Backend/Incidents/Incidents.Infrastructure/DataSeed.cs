using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;

namespace Incidents.Infrastructure
{
    public class DataSeed
    {
        public async Task SeedData(IncidentsDbContext context)
        {

            #region Contacts

            var contacts = new List<Contact>();

            if (!context.Contacts.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    contacts.Add(new Contact
                    {
                        FirstName = "Random string",
                        LastName = $"Juan{i + 1}",
                        Email = $"MehBruh{i + 1}@service.domain",
                    });
                }

                await context.Contacts.AddRangeAsync(contacts);
            }

            #endregion

            #region Accounts

            var accounts = new List<Account>();

            if (!context.Accounts.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    accounts.Add(new Account
                    {
                        AccountName = $"AccountName{i + 1}",
                        Contacts = new List<Contact> { contacts[i] },
                    });
                }

                await context.Accounts.AddRangeAsync(accounts);
            }


            #endregion

            #region Incidents

            var incidents = new List<Incident>();

            if(!context.Incidents.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    incidents.Add(new Incident
                    {
                        IncidentName = Guid.NewGuid().ToString(),
                        Description = $"Description of Incident №{i + 1}",

                        Accounts = new List<Account> { accounts[i] },

                    });
                }

                await context.Incidents.AddRangeAsync(incidents);
            }

            #endregion

            await context.SaveChangesAsync();
        }
    }
}
