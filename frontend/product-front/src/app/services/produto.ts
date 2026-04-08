import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private api = 'http://localhost:5112/api/produtos';

  constructor(private http: HttpClient) {}

  listar() {
    return this.http.get(this.api);
  }

  criar(produto: any) {
    return this.http.post(this.api, produto);
  }

  deletar(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }
}