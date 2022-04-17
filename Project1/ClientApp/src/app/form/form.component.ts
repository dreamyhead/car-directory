import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators} from "@angular/forms";
import { AppService, Cars } from '../app.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})

export class FormComponent implements OnInit {

  form: FormGroup;
  brand: string = '';
  color: string = '';
  plateNumber: string = '';
  productYear: number;

  @Output() eventCarItem: EventEmitter<Cars> = new EventEmitter<Cars>();
  @Output() eventCarList: EventEmitter<Cars[]> = new EventEmitter<Cars[]>();

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.form = new FormGroup({
      brand: new FormControl('', [
        Validators.minLength(1)
      ]),
      color: new FormControl('', [
        Validators.minLength(1)
      ]),
      plateNumber: new FormControl('', [
        Validators.minLength(7),
        Validators.minLength(9)
      ]),
      productYear: new FormControl(null, [
        Validators.minLength(4),
        Validators.min(0)
      ])
    })
  }
  submit() {
    const formData = {...this.form.value};
    this.appService.addCarInList(formData)
      .subscribe(car => this.eventCarItem.emit(car))
    this.form.reset();
  }
  // addCar() {
  //   if (!this.brand.trim() || !this.color.trim() || !this.plateNumber.trim()) {
  //     return;
  //   }

  //   const newCar: Cars = {
  //     brand: this.brand,
  //     color: this.color,
  //     plateNumber: this.plateNumber,
  //     productYear: this.productYear,
  //   }

  //   this.appService.addCarInList(newCar)
  //     .subscribe(car => {
  //       console.log(car);
  //       this.eventCarItem.emit(car);
  //       this.brand = this.color = this.plateNumber = '';
  //       this.productYear = 0;
  //     })
  // }

  getAllList() {
    this.appService.getAllList()
      .subscribe(cars => {
        console.log(cars);
        this.eventCarList.emit(cars);
      });
  }

}
