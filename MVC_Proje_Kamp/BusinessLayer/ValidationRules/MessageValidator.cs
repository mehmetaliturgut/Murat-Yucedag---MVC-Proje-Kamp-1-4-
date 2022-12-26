using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).MinimumLength(9).WithMessage("En az 9 karakter giriniz.");
            RuleFor(x => x.ReceiverMail).MaximumLength(35).WithMessage("35 karakteri aşamazsınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("35 karakteri aşamazsınız.");

        }

    }
}
