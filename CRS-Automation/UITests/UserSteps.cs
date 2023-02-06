using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CRS_Automation.UITests
{
    [Binding, Scope(Tag = "user")]
    public class UserSteps
    {
        private readonly GlobalSteps global;

        public UserSteps(GlobalSteps global)
        {
            this.global = global;
        }

        [Given(@"I am an '([^']*)' user")]
        public void GivenIAmAnUser(string admin)
        {
            throw new PendingStepException();
        }

        [When(@"I enter my login credentials")]
        public void WhenIEnterMyLoginCredentials()
        {
            throw new PendingStepException();
        }

        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }

        [When(@"I update my user information")]
        public void WhenIUpdateMyUserInformation(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"I validate that my user information was successfully updated")]
        public void ThenIValidateThatMyUserInformationWasSuccessfullyUpdated()
        {
            throw new PendingStepException();
        }

        [When(@"I add a new user to the system")]
        public void WhenIAddANewUserToTheSystem()
        {
            throw new PendingStepException();
        }

        [Then(@"I validate that the new user was successfully created")]
        public void ThenIValidateThatTheNewUserWasSuccessfullyCreated()
        {
            throw new PendingStepException();
        }

    }
}
