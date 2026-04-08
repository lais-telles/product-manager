import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../services/produto';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-lista-produtos',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './lista-produtos.html'
})
export class ListaProdutosComponent implements OnInit {

  produtos: any[] = [];

  constructor(private service: ProdutoService, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.service.listar().subscribe((res: any) => {
      this.produtos = res;

      this.cdr.detectChanges(); // 👈 FORÇA ATUALIZAÇÃO
    });
  }

  remover(id: number) {
    this.service.deletar(id).subscribe(() => {
      this.ngOnInit();
    });
  }
}