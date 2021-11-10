import { Onboarder_Course_Enrollment } from './../_models/onboarder_course_enrollment';
import { AssignCourse } from './../_models/assigncourse';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Course } from '../_models';
import * as _models from '../_models';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  //Joyous, please put the link of the API here
  url = 'https://localhost:44319/api/Course';
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

  getAllCourse(): Observable<any> {
    return this.http.get<any>(`${this.url}/GetAllCourses`);
  }

  getCourseById(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/GetCourseById/` + id);
  }

  getCourseByOnboaderId(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/GetCourseByonboarderId/` + id);
  }

 

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteCourse/` + id + '/' + this.userId);
  }

  update(id: number, course: Course) {
    return this.http.put(`${this.url}/UpdateCourse/` + id, course);
  }

  create(course: Course) {
    var number = this.userId;
   //alert(this.userId);
   console.log("course", number)
    return this.http.post(`${this.url}/CreateCourse/` + this.userId, course);
  }

  assigne(assign: Onboarder_Course_Enrollment) {
   
    return this.http.post(`${this.url}/AssignCourse/` + this.userId, assign);
  }

}
