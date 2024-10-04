namespace Test.Cross.Utils;

public static class Placa
{
    public static bool ValidarPlaca(string placa)
    {
        if (placa.Length > 7)
            return false;

        return true;
    }
}
