using MediatR;
using System.Transactions;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Application.Common.Interfaces;

namespace GreenMarket.Application.Common.Behaviours
{
    public class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, ICommand
    {
        private readonly IUnitOfWork _dataSource;

        public UnitOfWorkBehaviour(IUnitOfWork dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {

            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = await next();

                await _dataSource.SaveChangesAsync(cancellationToken);

                transaction.Complete();

                return response;
            }
        }
    }
}
