import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Course } from '../_models';
import { CourseService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'take_course.component.html',
    styleUrls: ['./ss_onboarder.component.css'] 
})

export class Take_CourseComponent implements OnInit {


  onboarderid: any;
  course: any[] = [];

  constructor(
      private courseService: CourseService,
      private alertService: AlertService,

      private router: Router
  ) {
      // var movies = localStorage.getItem("user");
      // movies  = JSON.parse(movies);
      // if(movies){
      //   this.userId = movies['id'];
      //   console.log(movies['id']);
      // }
  }

  ngOnInit() { 
    var movies = localStorage.getItem("user");
    movies = JSON.parse(movies);
    this.onboarderid = movies['onboarderid'];

    this.loadAll();
  }

  private loadAll() {
    this.courseService.getCourseByOnboaderId(this.onboarderid)
    .pipe(first())
    .subscribe(
      course => {
        this.course = course;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

}