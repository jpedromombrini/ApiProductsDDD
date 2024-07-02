namespace ApiProduct.Domain.Entities;
public class Produto : Entity
{       
    public string Descricao { get; set;} = "";
    public string Situacao { get; set;}  = "";
    public DateTime Fabricacao { get; set; } 
    public DateTime Validade { get; set; } 
    public int CodigoFornecedor { get; set; } 
    public string DescricaoFornecedor { get; set; } = "";
    public string CnpjFornecedor { get; set; } = "";

}