using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dominio.Entidades;

public class Produto : EntidadeBase
{
    public string Nome { get; set; }

    public virtual Produto? ProdutoPai { get; set; }
    public int? ProdutoPaiId { get; set; }

    public virtual Categoria Categoria { get; set; }
    public int CategoriaId { get; set; }

    public virtual Marca Marca { get; set; }
    public int MarcaId { get; set; }

    public string NumeroDeSerie;

    public String Modelo { get; set; }

    public double Valor { get; set; }

    private readonly List<Produto> _acessorios;

    public virtual IEnumerable<Produto> Acessorios => _acessorios;

    public virtual NotaFiscal? NotaFiscal { get; set; }

    public int? NotaFiscalId { get; set; }

    protected Produto()
    {

    }

    public Produto(string nome, string modelo, Categoria categoria, Marca marca, double valor)
    {
        Nome = nome ?? throw new Exception("É Obrigatório Registrar o Nome");
        Modelo = modelo;
        Categoria = categoria ?? throw new Exception("É Obrigatório Ter uma Categoria");
        Marca = marca ?? throw new Exception("É Obrigatório Ter uma Marca");
        Valor = valor;
        _acessorios = new List<Produto>();
    }

    public IEnumerable<Produto> LerAcessorios()
    {
        return Acessorios;
    }

    public void AdicionarAcessorio(string nome, string modelo,float valor = 0)
    {
        var acessorio = new Produto(nome, modelo, Categoria, Marca, valor);
        acessorio.ProdutoPai = this;
        _acessorios.Add(acessorio);
        var maxId = _acessorios.Max(x => x.Id);
        acessorio.Id = ++maxId;
    }

    public void AdicionarAcessorio(string nome, string modelo, float valor, Marca marca)
    {
        var acessorio = new Produto(nome, modelo, Categoria, marca, valor);
        _acessorios.Add(acessorio);
        var maxId = _acessorios.Max(x => x.Id);
        acessorio.Id = ++maxId;
    }

    public void AtualizarAcessorio(Produto acessorio)
    {
        var item = _acessorios.FirstOrDefault(x => x.Id == acessorio.Id);
        if (item == null)
        {
            throw new Exception("Item Não Encontrado");
        }
        _acessorios.Remove(item);
        _acessorios.Add(acessorio);
    }

    public void RemoverAcessorio(Produto acessorio)
    {
        var item = _acessorios.FirstOrDefault(x => x.Id == acessorio.Id);
        _acessorios.Remove(item);

    }

    public double Total => Acessorios.Sum(x => x.Valor) + Valor;

}


