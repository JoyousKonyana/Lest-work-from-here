import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Learning_Outcome} from '../_models';
import { LessonOutcomeDTO } from '../_models/LessonOutcomeDTO';

@Injectable({
  providedIn: 'root'
})
export class Learning_OutcomeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/LessonOutcome';  
  //  userId: any = localStorage.getItem('user');
 
  
  userId;
  constructor(private http: HttpClient) {
    var movies = localStorage.getItem("user");
    movies     = JSON.parse(movies);
    if(movies){
      this.userId = movies['id'];
      console.log(movies['id']);
    }
   }  

  getAllLearning_Outcome(): Observable<Learning_Outcome[]> {  
    return this.http.get<Learning_Outcome[]>(`${this.url}/GetAllLessonOutcomes`);  
  }  

  getAllLearning_Outcome2(): Observable<LessonOutcomeDTO[]> {  
    return this.http.get<LessonOutcomeDTO[]>(`${this.url}/GetAllLessonOutcomes`);  
  }  

  getLearning_OutcomeById(id: number): Observable<Learning_Outcome> {  
      return this.http.get<Learning_Outcome>(`${this.url}/GeLessonOutcomeByLessonId/`+id);  
    }  

    getLearning_OutcomeByLessonID(id: number): Observable<any> {  
      return this.http.get<any>(`${this.url}/GeLessonOutcomeByLessonId/`+id);  
    } 

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteLessonOutcome/` + id + '/'+ this.userId);
  }

  update(id: number, learning_outcome: Learning_Outcome) {
    return this.http.put(`${this.url}/UpdateLessonOutcome/`+ id +'/' + this.userId, learning_outcome);
  }

  create(learning_outcome: Learning_Outcome) {
    return this.http.post(`${this.url}/CreateLessonOutcome/` + this.userId, learning_outcome);
  }

 


} 