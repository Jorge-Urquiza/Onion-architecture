using FluentValidation;
using MediatR;

namespace Application.Behaviours
{
    public class ValidationBehavior<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse> 
            where IRequest : IRequest<IResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<IRequest>> validators) { 
            _validators = validators; 
        }
        public async Task<IResponse> Handle(IRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any()) {
                var context = new FluentValidation.ValidationContext<IRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0) {
                    //custom
                    throw new Exceptions.ValidationException(failures); 
                }
            }
            return await next();
        }
    }
}
