using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Behavioural.ChainOfResponsibility
{
    public class ClerkApprovalHandler : LoanApprovalHandler
    {
        public override bool AmountCleared(decimal amount)
        {
            return (amount <= 25000);
        }
    }
}
