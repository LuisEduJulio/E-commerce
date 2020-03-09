using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogo.Migrations
{
    public partial class populadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome, ImageUrl) Values('Bebidas','http://www.macoratti.net/Imagens/1.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImageUrl) Values('Lanches','http://www.macoratti.net/Imagens/2.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImageUrl) Values('Sobremesas','http://www.macoratti.net/Imagens/3.jpg')");

            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) Values('Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45,'http://www.macoratti.net/Imagens/coca.jpg',50, now()," +
                "(select CategoriaId from Categorias where Nome='Bebidas'))");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) Values('Lanche de Atum', 'Lanche de Atum com Maiones',8.50,'http://www.macoratti.net/Imagens/atum.jpg',10, now()," +
                "(select CategoriaId from Categorias where Nome='Lanches'))");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) Values('Pudim 100 g', 'Pudim de Leite Condensado',6.75,'http://www.macoratti.net/Imagens/pudim.jpg',20, now()," +
                "(select CategoriaId from Categorias where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
