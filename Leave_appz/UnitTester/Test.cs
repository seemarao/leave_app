using NUnit.Framework;
using System;
namespace UnitTester
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void casualLeaveValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.True(viewModels.casualLeaveDateLabelValidater(""),"Placeholder Shuld not be empty");
            Assert.True(viewModels.casualLeaveDateLabelValidater("Tap to Select Date"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void casualLeaveValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.casualLeaveDateLabelValidater("Some Info"), "Failed Because Validation Is Not handled properly");

        }

        [Test()]
        public void casualLeaveEntryValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.True(viewModels.casualLeaveMyEditorLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.casualLeaveMyEditorLabelValidater("Please provide the reason for your leave here !!"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void casualLeaveEntryValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.casualLeaveMyEditorLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }


        [Test()]
        public void earnedLeaveDateValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.True(viewModels.earnedLeaveDateLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.earnedLeaveDateLabelValidater("From Date"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void earnedLeaveDateValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.earnedLeaveDateLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }


        [Test()]
        public void earnedLeaveDateNValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.True(viewModels.earnedLeaveDateNLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.earnedLeaveDateNLabelValidater("To Date"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void earnedLeaveDateNValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.earnedLeaveDateNLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }





        [Test()]
        public void earnedLeaveMyEditorValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();
          
            Assert.True(viewModels.earnedLeaveMyEditorLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.earnedLeaveMyEditorLabelValidater("Please provide the reason for your leave here !!"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void earnedLeaveMyEditorValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.earnedLeaveMyEditorLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void checkForStringEmptyTrue()
        {
            var viewModels = new Leave_appz.ViewModels();

            Assert.True(viewModels.checkForEmptyString(""), "Placeholder Shuld not be empty");
           
        }

        [Test()]
        public void checkForStringEmptyFalse()
        {
            var viewModels = new Leave_appz.ViewModels();

            Assert.False(viewModels.checkForEmptyString("Some Info"), "Placeholder Shuld  be empty");

        }




        [Test()]
        public void sickLeaveDateValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();

            Assert.True(viewModels.sickLeaveDateLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.sickLeaveDateLabelValidater("Tap to Select Date"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void sickLeaveDateValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.sickLeaveDateLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }




        [Test()]
        public void sickLeaveEntryValidateTrue()
        {
            var viewModels = new Leave_appz.ViewModels();

            Assert.True(viewModels.sickLeaveEntryLabelValidater(""), "Placeholder Shuld not be empty");
            Assert.True(viewModels.sickLeaveEntryLabelValidater("Please provide the reason for your leave here !!"), "Tap to select date is considerd as empty");

        }

        [Test()]
        public void sickLeaveEntryValidateFalse()
        {
            var viewModels = new Leave_appz.ViewModels();
            Assert.False(viewModels.sickLeaveEntryLabelValidater("Some Info"), "Tap to select date is considerd as empty");

        }

    }
}
