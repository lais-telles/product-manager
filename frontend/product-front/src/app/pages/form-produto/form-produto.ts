import { Component } from '@angular/core';
import { ProdutoService } from '../../services/produto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-form-produto',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatDialogModule,
    MatFormFieldModule
  ],
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

  constructor(
    private service: ProdutoService,
    private dialogRef: MatDialogRef<FormProdutoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if (data) {
      this.produto = { ...data };
    }
  }

  salvar() {
    if (this.data) {
      // edição
      this.service.atualizar(this.data.id, this.produto).subscribe({
        next: () => {
          this.dialogRef.close(true);
        },
        error: (err) => alert(err.error)
      });
    } else {
      // criação
      this.service.criar(this.produto).subscribe({
        next: () => {
          this.dialogRef.close(true);
        },
        error: (err) => alert(err.error)
      });
    }
  }

  formValido(): boolean {
    return (
      this.produto.nome.trim() !== '' &&
      this.produto.sku.trim() !== '' &&
      this.produto.categoria.trim() !== '' &&
      this.produto.preco > 0 &&
      this.produto.quantidadeEstoque >= 0
    );
  }

  fechar() {
    this.dialogRef.close();
  }
}