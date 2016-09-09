using System.Net;
using MD5OnlineGenerator.BusinessLogic.Validation.Interfaces;
using MD5OnlineGenerator.ServiceModel.Requests;
using ServiceStack;
using ServiceStack.FluentValidation;

namespace MD5OnlineGenerator.BusinessLogic.Validation.Impl
{
    public class MD5Validator : AbstractValidator<MD5Request>
    {
        public MD5Validator(IUrlValidator urlValidator)
        {
            RuleFor(r => r.Url).Must(urlValidator.ValidUrl)
                .WithMessage("Provided input is not in corret Url format.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
