using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Behavioural.ChainOfResponsibility
{
    public class ManagerApprovalHandler : LoanApprovalHandler
    {
        public override bool AmountCleared(decimal amount)
        {
            return (amount <= 100000);
        }
    }
}
