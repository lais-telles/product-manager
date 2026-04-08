import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListaProdutosComponent } from './pages/lista-produtos/lista-produtos';
import { FormProdutoComponent } from './pages/form-produto/form-produto';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ListaProdutosComponent, FormProdutoComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('product-front');
}
