import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../../service/product.service';
import { AlertService } from '../../shared/services/alert.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateproductComponent implements OnInit {

  errorMsg: string;
  form: FormGroup;
  idbook: any;
  items: any;
  errMsg: string;

  constructor(private builder: FormBuilder,
    private router: Router,
    private productSV: ProductService,
    private activateRouter: ActivatedRoute,
    private alertSV: AlertService) {
    this.initialCreateFormData(), 
    this.activateRouter.params.forEach(
      params => {
        this.idbook = params.id;
      }
    )

  }
  ngOnInit() {
  }
  private initialCreateFormData() {
    this.form = this.builder.group({
      idbook:[0],
      nameBook:new FormControl('',Validators.required),
      detailBook:new FormControl('',Validators.required),
      priceBook:new FormControl('',Validators.required),
         
    });
  }
 
  
  onSubmit() {
    const patt = /^[a-zA-Zก-ฮ]{2,3000}$/;
    if (this.form.invalid) {
      console.log('ข้อมูลไม่ครบ');
      alert('ข้อมูลไม่ครบ');
    } else if (patt.test(this.form.get('nameBook').value) === false) {
      console.log('nameBook ผิดพลาด');
      alert('nameBook ผิดพลาด');
    } else if (patt.test(this.form.get('detailBook').value) === false) {
      console.log('detailBook ผิดพลาด');
      alert('detailBook ผิดพลาด');
    } 
    else {
      this.productSV
        .createProduct(this.form.value)
        .then(res => {
          this.alertSV.notify('เพิ่มข้อมูลเรียบร้อยแล้ว', 'success')
          this.router.navigate(['/', 'home']);
        })
        .catch(err => this.errorMsg = err);

    }
  }
}
