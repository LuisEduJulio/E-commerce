using ApiCatalogo.Validations;
using APICatalogo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Produtos")]
    public class Produto : IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório")]
        [StringLength(80, ErrorMessage ="O nome deve ter entre 5 e 80 caracteres", MinimumLength = 5)]
        [MaxLength(80)]
        //[PrimeiraLetraMaiuscula]
        public string Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "O preço deve está entre R$ {1},00 e R$ {2},00")]
        public double Preco { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categorias { get; set; }
        public int CategoriaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.Nome))
            {
                var primeiraLetra = this.Nome[0].ToString();
                if (primeiraLetra != primeiraLetra.ToUpper())
                {
                    yield return new
                        ValidationResult("A primeira letra do produto deve ser maiúscula",
                        new[]
                        { nameof(this.Nome) }
                        );
                }
            }

            if (this.Estoque <= 0)
            {
                yield return new
                       ValidationResult("O estoque deve ser maior que zero",
                       new[]
                       { nameof(this.Estoque) }
                       );
            }
        }
    }
}

