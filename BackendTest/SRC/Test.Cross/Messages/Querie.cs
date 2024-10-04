using MediatR;

namespace Test.Cross.Messages;

public abstract class Querie<T> : IRequest<T> where T : class { }
