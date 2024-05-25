
public abstract class Pessoa
{
    public string NomePessoa { get; set; }

    public abstract double CalculeIR(int declaracao);

}

public class PessoaFisica : Pessoa, ValidarDocumento
{
    public override double CalculeIR(int declaracao)
    {
        return 1.0;
    }

    public bool Validar()
    {
        return true;
    }
}

public class PessoaJuridica : Pessoa, ValidarDocumento
{
    public override double CalculeIR(int declaracao)
    {
        return 1.0;
    }

    public bool Validar()
    {
        return true;
    }
}

public interface ValidarDocumento
{
    bool Validar();
}