using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(),Messages.Listed);
        }

        public IDataResult<CreditCard> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.GetById(c => c.CardNumber == cardNumber),Messages.Listed);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.Updated);
        }

        public IResult VerifyCard(CreditCard creditCard)
        {
            var result = _creditCardDal.GetById(c=> c.CardNumber == creditCard.CardNumber && c.CardExpirationDate == creditCard.CardExpirationDate && c.CardCvv == creditCard.CardCvv && c.NameOnTheCard == creditCard.NameOnTheCard);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
