using DesignPatternsLib.Behavioural.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsTestsLib
{
    public class ChainOfResponsibilityTests
    {
        private ITestOutputHelper _helper;
        public ChainOfResponsibilityTests(ITestOutputHelper helper)
        {
            _helper = helper;
        }
        [Fact]
        public void LoanOf25000()
        {
            var clerkApprovalHandler = new ClerkApprovalHandler();
            clerkApprovalHandler.LoanApproved += (sender, amount) =>
            {
                _helper.WriteLine($"{sender} cleared {amount}");
            };
            clerkApprovalHandler.ProcessRequest(25000);
        }
        [Fact]
        public void LoanOf75000()
        {
            var clerkApprovalHandler = new ClerkApprovalHandler();
            clerkApprovalHandler.SetNext(new ManagerApprovalHandler());
            clerkApprovalHandler.LoanRequiresExecutiveMeeting += (sender, amount) =>
            {
                _helper.WriteLine($"{sender} {amount} requires executive meeting");
            };
            clerkApprovalHandler.LoanApproved += (sender, amount) =>
            {
                _helper.WriteLine($"{sender} cleared {amount}");
            };
            clerkApprovalHandler.ProcessRequest(75000);
        }
        [Fact]
        public void LoanOf200000()
        {
            var clerkApprovalHandler = new ClerkApprovalHandler();
            clerkApprovalHandler.SetNext(new ManagerApprovalHandler());
            bool executiveMeeting = false;
            clerkApprovalHandler.LoanRequiresExecutiveMeeting += (sender, amount) =>
            {
                _helper.WriteLine($"{sender} {amount} requires executive meeting");
                executiveMeeting = true;
            };
            clerkApprovalHandler.LoanApproved += (sender, amount) =>
            {
                _helper.WriteLine($"{sender} cleared {amount}");
            };
            clerkApprovalHandler.ProcessRequest(200000);
            Assert.Equal(executiveMeeting, true);
        }
    }
}
