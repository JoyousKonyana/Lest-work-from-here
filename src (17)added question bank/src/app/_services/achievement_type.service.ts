

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Achievment_Type, Badge} from '../_models';

@Injectable({
  providedIn: 'root'
})
export class Achievment_TypeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/AchievementType';  
   url2 = 'https://localhost:44319/api/Badge';  

  //  userId: any = localStorage.getItem('user');
  movies:any = localStorage.getItem("user");
  moviesi:any     = JSON.parse(this.movies);
  userId;
  if(movie){
   this.userId = this.moviesi['id'];
  }
  
  //  console.log(movies['id']);

  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllAchievment_Type(): Observable<any> {  
    return this.http.get<any>(`${this.url}/GetAllAchievemntTypes`);  
  }

  getAllBadges(): Observable<Badge[]> {  
    return this.http.get<Badge[]>(`${this.url2}/GetAllbadges`);  
  } 

  getAchievment_TypeById(id: number): Observable<Achievment_Type> {  
      return this.http.get<Achievment_Type>(`${this.url}/GetAchievementTypeByID/`+ id);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteAchievementType/`+ id + '/' + this.userId);
  }

  update(id: number, achievment_type:Achievment_Type) {
    return this.http.put(`${this.url}/UpdateAchievementType/`+id + '/' + this.userId, achievment_type);
  }

  create(achievment_type:Achievment_Type) {
    return this.http.post(`${this.url}/CreateAchievementType/`+ this.userId, achievment_type, {headers:this.httHeaders});
  }

} 