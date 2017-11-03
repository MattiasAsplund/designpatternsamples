using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Behavioural.ChainOfResponsibility
{
    public delegate void LoanApprovedHandler(object sender, decimal amount);
    public delegate void LoanRequiresExecutiveMeetingHandler(object sender, decimal amount);
    public abstract class LoanApprovalHandler
    {
        private LoanApprovalHandler _nextHandler;
        public event LoanApprovedHandler LoanApproved;
        public event LoanRequiresExecutiveMeetingHandler LoanRequiresExecutiveMeeting;
        public void SetNext(LoanApprovalHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public void ProcessRequest(decimal amount)
        {
            if (AmountCleared(amount))
                LoanApproved?.Invoke(this, amount);
            else if (_nextHandler != null)
            { 
                _nextHandler.LoanApproved += (sender, amnt) =>
                {
                    LoanApproved?.Invoke(_nextHandler, amount);
                };
                _nextHandler.LoanRequiresExecutiveMeeting += (sender, amnt) =>
                {
                    LoanRequiresExecutiveMeeting?.Invoke(_nextHandler, amount);
                };
                _nextHandler.ProcessRequest(amount);
            }
            else
                LoanRequiresExecutiveMeeting?.Invoke(this, amount);
        }
        public abstract bool AmountCleared(decimal amount);
    }
}
