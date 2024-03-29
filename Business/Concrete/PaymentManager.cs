﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult ReceivePayment(Payment payment)
        {
            if (payment.Amount <=2000)
            {
                return new SuccessResult(Messages.PaymentCompleted);

            }

            return new ErrorResult(Messages.InsufficientBalance);

        }
    }
}
