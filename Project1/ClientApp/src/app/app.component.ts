import { Component, OnInit, AfterContentInit, Input} from '@angular/core';
import { AppService, Cars } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent implements OnInit{

  cars: Cars[];
  carsLenght: number;

  brand: string = '';
  displayedColumns: string[] = ['№', 'Марка', 'Цвет', 'Номер', 'Год выпуска', 'Удалить'];

  constructor(private appService: AppService) {}

  ngOnInit() {
    console.log("responce");
    this.appService.getAllList()
      .subscribe(responce => {
        this.cars = responce;
        this.carsLenght = this.cars.length;
      });
  }

  addCarItem(car: Cars) {
    this.cars.push(car);
    this.carsLenght = this.cars.length;
  }

  getCarList(cars: Cars[]) {
    this.cars = cars;
    this.carsLenght = cars.length;
    console.log(this.carsLenght)
  }

  filterCarList(brand: string) {
    console.log(this.carsLenght)
    if (!this.brand.trim()) {
      return;
    }
    this.appService.filterCarList(brand)
      .subscribe(responce => {
        console.log(responce)
        this.cars = responce;
        this.carsLenght = responce.length;
        // this.brand = '';
      })
  }

  deleteCar(id:any) {
    console.log(this.carsLenght)
    this.appService.deleteCarInList(id)
      .subscribe(responce => {
        console.log(responce)
        this.cars = this.cars.filter(c => c.id !== id)
        this.carsLenght = this.carsLenght - 1;
      })
  }
}
