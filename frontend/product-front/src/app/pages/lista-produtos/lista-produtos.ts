import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ProdutoService } from '../../services/produto';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { FormProdutoComponent } from '../form-produto/form-produto';

@Component({
  selector: 'app-lista-produtos',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule
  ],
  templateUrl: './lista-produtos.html'
})
export class ListaProdutosComponent implements OnInit {

  produtos = new MatTableDataSource<any>();

  displayedColumns: string[] = [
    'nome',
    'preco',
    'quantidadeEstoque',
    'sku',
    'acoes'
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private service: ProdutoService,
    private cdr: ChangeDetectorRef,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.service.listar().subscribe((res: any) => {
      this.produtos.data = res;

      setTimeout(() => {
        this.produtos.paginator = this.paginator;
      });

      this.cdr.detectChanges();
    });
  }

  abrirNovo() {
    const dialogRef = this.dialog.open(FormProdutoComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) this.ngOnInit();
    });
  }

  editar(produto: any) {
    const dialogRef = this.dialog.open(FormProdutoComponent, {
      width: '500px',
      data: produto
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) this.ngOnInit();
    });
  }

  remover(id: number) {
    this.service.deletar(id).subscribe(() => {
      this.ngOnInit();
    });
  }
}