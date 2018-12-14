import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url = 'https://localhost:44375/api/TableBooks';
 
 
  constructor(private http: HttpClient) { }

 
  getProduct() {
    return this.http.get<Product[]>(this.url);
  }

  
  
  createProduct(idbook) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, idbook)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(idbook);
          }
        );
    });
    return promise;
  }

  deleteProduct(idbook: any) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, idbook)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(idbook);
          }
        );
    });
    console.log(idbook);
    return promise
  }

  getOnePerson(idbook) {
    return this.http.get<Product[]>(this.url + idbook);
  }

  updateProduct(data) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url;
      this.http.post(apiURL, data).toPromise().then(
        res => {
          console.log(res);
          resolve(data);
        }
      );
    });
    return promise;
  }

}