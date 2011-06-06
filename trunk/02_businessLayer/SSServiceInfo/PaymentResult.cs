using System;

namespace SSServiceInfo
{
    public class PaymentResult
    {
        private int m_goPaymentID;

        public int GoPaymentID
        {
            get { return m_goPaymentID; }
            set { m_goPaymentID = value; }
        }

        private DateTime m_payDate;

        public DateTime PayDate
        {
            get { return m_payDate; }
            set { m_payDate = value; }
        }

        private int m_errorCode;

        public int ErrorCode
        {
            get { return m_errorCode; }
            set { m_errorCode = value; }
        }

        public PaymentResult() { }

        public PaymentResult(int goPaymentID, DateTime payDate, int errorCode)
        {
            m_goPaymentID = goPaymentID;
            m_payDate = payDate;
            m_errorCode = errorCode;
        }
    }
}
