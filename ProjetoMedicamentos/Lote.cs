using System;

public class Lote
{
    private int id;
    private int qtde;
    private DateTime venc;

    public Lote() { }

    public Lote(int id, int qtde, DateTime venc)
    {
        this.id = id;
        this.qtde = qtde;
        this.venc = venc;
    }

    public int Qtde
    {
        get { return qtde; }
        set { qtde = value; }
    }

    public DateTime Venc
    {
        get { return venc; }
    }

    public int Id
    {
        get { return id; }
    }

    public override string ToString()
    {
        return $"{id}-{qtde}-{venc:dd/MM/yyyy}";
    }
}