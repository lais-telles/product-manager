import { Component } from '@angular/core';
import { ProdutoService } from '../../services/produto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-form-produto',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './form-produto.html'
})
export class FormProdutoComponent {

  produto = {
    nome: '',
    sku: '',
    categoria: '',
    preco: 0,
    quantidadeEstoque: 0
  };

  categorias = ['Eletrônicos', 'Roupas', 'Alimentos', 'Outros'];

  constructor(private service: ProdutoService) {}

  salvar() {
    this.service.criar(this.produto).subscribe({
      next: () => {
        alert('Produto criado!');
        location.reload(); // simples e rápido (ok pro teste)
      },
      error: (err) => alert(err.error)
    });
  }
}