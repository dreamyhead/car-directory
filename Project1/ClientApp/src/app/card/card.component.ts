import { Component, OnInit, DoCheck, Input } from '@angular/core';
import { AppService, Cars } from '../app.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() cars: Cars[];
  @Input() carsLenghtList: number;

  brand: string = '';
  displayedColumns: string[] = ['№', 'Марка', 'Цвет', 'Номер', 'Год выпуска', 'Удалить'];

  constructor(private appService: AppService) { }

  ngOnInit() {}
  // ngDoCheck() {
  //   console.log(this.carsLenghtList);
  // }

  filterCarList(brand: string) {
    console.log(this.carsLenghtList)
    if (!this.brand.trim()) {
      return;
    }
    this.appService.filterCarList(brand)
      .subscribe(responce => {
        console.log(responce)
        this.cars = responce;
        this.carsLenghtList = responce.length;
        // this.brand = '';
      })
  }

  deleteCar(id:any) {
    console.log(this.carsLenghtList)
    this.appService.deleteCarInList(id)
      .subscribe(responce => {
        console.log(responce)
        this.cars = this.cars.filter(c => c.id !== id)
        this.carsLenghtList = this.carsLenghtList - 1;
      })
  }
}
