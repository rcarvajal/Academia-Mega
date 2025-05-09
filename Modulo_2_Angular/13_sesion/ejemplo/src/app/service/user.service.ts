import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: any = 'https://randomuser.me/api/?results=10';

  constructor( private http:HttpClient) {  }

  getUsers(): Observable<any>{
    return this.http.get(this.apiUrl);
  };

}
