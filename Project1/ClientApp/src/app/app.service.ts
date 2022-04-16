import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cars {
  id?: number;
  brand: string;
  color: string;
  plateNumber: string;
  productYear: number;
}

@Injectable({
  providedIn: 'root'
})

export class AppService {
  constructor(private http: HttpClient) {}

  getAllList(): Observable<Cars[]> {
    return this.http.get<Cars[]>('caritems')
  }

  addCarInList(newCar: Cars): Observable<Cars> {
    return this.http.post<Cars>('caritems', newCar)
  }

  filterCarList(brand: string): Observable<Cars[]> {
    return this.http.get<Cars[]>(`caritems/${brand}`)
  }

  deleteCarInList(id: any): Observable<void> {
    return this.http.delete<void>(`caritems/${id}`)
  }
}
