using Test.Cross.Messages;

namespace Test.Cross.Utils;

public abstract class Entity
{
    public Guid Id { get; set; }
    public bool Excluido { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Excluido = false;
    }

    private List<Event> _notificacoes;
    public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

    public void AdicionarEvento(Event evento)
    {
        _notificacoes = _notificacoes ?? new List<Event>();
        _notificacoes.Add(evento);
    }

    public void RemoverEvento(Event eventItem)
    {
        _notificacoes?.Remove(eventItem);
    }

    public void LimparEventos()
    {
        _notificacoes?.Clear();
    }

    public void Excluir(bool excluir)
    {
        Excluido = excluir;
    }
}
