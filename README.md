# 🛒 Loja Eletrônicos — Carrinho e Checkout

Projeto desenvolvido para implementar um sistema simples de **carrinho de compras e checkout**, aplicando conceitos de **Programação Orientada a Objetos (POO)** em C#.

O sistema permite adicionar itens ao carrinho, calcular subtotais, aplicar cupons de desconto e finalizar a compra.

## 📋 Sobre o projeto

O carrinho é responsável por controlar os produtos adicionados, calcular os valores da compra, validar cupons e controlar o status da compra.

O projeto foi desenvolvido a partir de um diagrama de classes e de regras de negócio previamente definidas.

## 🧱 Estrutura

O projeto possui as seguintes classes e enumerações:

- `CarrinhoCompras` — Responsável pelo gerenciamento do carrinho, itens, cupom, status e cálculo do total.
- `ItemCarrinho` — Representa um produto dentro do carrinho, contendo preço e quantidade.
- `CupomDesconto` — Representa um cupom de desconto e realiza sua validação.
- `StatusCarrinho` — Define os estados do carrinho.
- `TipoFrete` — Define os tipos de frete disponíveis.

## ⚙️ Funcionalidades

- Adicionar itens ao carrinho
- Atualizar a quantidade de um item
- Calcular o subtotal dos itens
- Calcular o total da compra
- Validar e aplicar cupons de desconto
- Finalizar a compra
- Alterar o status do carrinho
- Impedir operações inválidas

## 📌 Regras de negócio

### RN01 — Quantidade válida
Um item só pode ser adicionado ou atualizado com quantidade maior que zero.

### RN02 — Subtotal
O subtotal de cada item é calculado através da multiplicação do preço unitário pela quantidade.

### RN03 — Cupom
O desconto só pode ser aplicado quando o subtotal do carrinho for maior ou igual ao valor mínimo definido pelo cupom.

### RN04 — Finalização
Somente um carrinho com status `Aberto` pode ser finalizado.

Após a finalização, o status do carrinho passa para `Fechado`.

### RN05 — Integridade
Uma operação rejeitada não deve inserir, remover ou alterar indevidamente os itens do carrinho.

## 🧪 Casos de teste

| ID | Cenário | Ação | Resultado esperado |
|---|---|---|---|
| CT1.01 | Item com quantidade 0 | Tentar adicionar o item | Operação rejeitada e lista permanece sem o item |
| CT1.02 | Dois itens de R$100,00 com quantidade 1 | Calcular o total | Total igual a R$200,00 |
| CT1.03 | Subtotal de R$150,00 e cupom mínimo de R$200,00 | Aplicar o cupom | Operação rejeitada e nenhum desconto aplicado |
| CT1.04 | Carrinho aberto com itens válidos | Finalizar a compra | Operação aceita e status passa para `Fechado` |

## 🎯 Critério de aceite

Após a execução dos testes, o sistema deve apresentar:

- Valor total da compra
- Status atual do carrinho
- Quantidade de itens no carrinho

## 🛠️ Tecnologias

- C#
- .NET
- Programação Orientada a Objetos
- Git e GitHub

## 📚 Conceitos praticados

- Classes e objetos
- Encapsulamento
- Enumerações (`enum`)
- Relacionamento entre classes
- Listas e coleções
- Métodos
- Validação de regras de negócio
- Controle de estado de objetos
- Testes de cenários

## 👨‍💻 Autores

- Bianca Alison Llusco Justo
- Erick Raphael dos Santos
- Pedro Gustavo Ferreira Silva