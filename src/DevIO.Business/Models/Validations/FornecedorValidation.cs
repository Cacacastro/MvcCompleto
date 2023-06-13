using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;


namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation() 
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () => 
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf).WithMessage("O campo documento precisa ter {ComparisonValue} caracteres");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true).WithMessage("Documento inválido");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () => 
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj).WithMessage("O campo documento precisa ter {ComparisonValue} caracteres");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true).WithMessage("Documento inválido");
            });
        }
    }
}
