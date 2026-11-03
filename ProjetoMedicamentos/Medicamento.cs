using System;
using System.Collections.Generic;

public class Medicamento
{
    private int id;
    private string nome;
    private string laboratorio;
    private Queue<Lote> lotes;

    public Medicamento()
    {
        this.lotes = new Queue<Lote>();
    }

    public Medicamento(int id, string nome, string laboratorio)
    {
        this.id = id;
        this.nome = nome;
        this.laboratorio = laboratorio;
        this.lotes = new Queue<Lote>();
    }

    public int Id
    {
        get { return id; }
    }

    public Queue<Lote> Lotes
    {
        get { return lotes; }
    }

    public int qtdeDisponivel()
    {
        int total = 0;
        foreach (var lote in lotes)
        {
            total += lote.Qtde;
        }
        return total;
    }

    public void comprar(Lote lote)
    {
        lotes.Enqueue(lote);
    }

    public bool vender(int qtde)
    {
        if (qtde > qtdeDisponivel()) return false;

        while (qtde > 0 && lotes.Count > 0)
        {
            Lote loteAtual = lotes.Peek();
            if (loteAtual.Qtde <= qtde)
            {
                qtde -= loteAtual.Qtde;
                lotes.Dequeue();
            }
            else
            {
                loteAtual.Qtde -= qtde;
                qtde = 0;
            }
        }
        return true;
    }

    public override string ToString()
    {
        return $"{id}-{nome}-{laboratorio}-{qtdeDisponivel()}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Medicamento outro)
        {
            return this.id == outro.id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}