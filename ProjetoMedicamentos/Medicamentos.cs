using System.Collections.Generic;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos;

    public Medicamentos()
    {
        listaMedicamentos = new List<Medicamento>();
    }

    public List<Medicamento> ListaMedicamentos
    {
        get { return listaMedicamentos; }
    }

    public void adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

    public bool deletar(Medicamento medicamento)
    {
        Medicamento enc = pesquisar(medicamento);
        if (enc.Id != 0 && enc.qtdeDisponivel() == 0)
        {
            listaMedicamentos.Remove(enc);
            return true;
        }
        return false;
    }

    public Medicamento pesquisar(Medicamento medicamento)
    {
        foreach (var med in listaMedicamentos)
        {
            if (med.Equals(medicamento))
            {
                return med;
            }
        }
        return new Medicamento();
    }
}