using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Incidents.Application.Services;
using Incidents.Controllers;
using Incidents.Domain.Entities;
using Incidents.Domain.Requests;
using Incidents.Domain.Responces;
using Incidents.Helpers;
using Incidents.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Incidents.Tests
{
    [TestClass]
    public class AccountControllerTest
    {
        private readonly IServiceProvider serviceProvider;

        public AccountControllerTest()
        {
            var services = new ServiceCollection();

            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<IncidentsDbContext>(options => options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            serviceProvider = services.BuildServiceProvider();
        }

        private void SeedData(IncidentsDbContext context)
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

                context.Contacts.AddRangeAsync(contacts);
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

                context.Accounts.AddRangeAsync(accounts);
            }


            #endregion

            #region Incidents

            var incidents = new List<Incident>();

            if (!context.Incidents.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    incidents.Add(new Incident
                    {
                        IncidentName = Guid.NewGuid().ToString(),
                        Description = $"Description of Incident ¹{i + 1}",

                        Accounts = new List<Account> { accounts[i] },

                    });
                }

                context.Incidents.AddRangeAsync(incidents);
            }

            #endregion

            context.SaveChangesAsync();
        }


        [TestMethod]
        public void TestCreateAccount()
        {
            var dbContext = serviceProvider.GetRequiredService<IncidentsDbContext>();
            SeedData(dbContext);
            var accountService = new AccountService(dbContext);

            var request = new AccountRequest { AccountName = "AccountName1", ContactEmail = "MehBruh1@service.domain" };

            var response = accountService.CreateAccount(request);

            Assert.AreEqual(OperationResult.Failure, response.Result.Result);

        }
    }
}
