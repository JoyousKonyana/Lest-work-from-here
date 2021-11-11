import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Lesson } from '../_models';
import { LessonService, AlertService } from '../_services';

@Component({
    templateUrl: 'take_lesson.component.html',
    styleUrls: ['./ss_onboarder.component.css']
})

export class Take_LessonComponent implements OnInit {

  lesson: any[] = [];

  id: any;

  constructor(
      private lessonService: LessonService,
      private alertService: AlertService,

      private _Activatedroute:ActivatedRoute,
      private router: Router,
  ) {

  }

  ngOnInit() {
      this._Activatedroute.paramMap.subscribe(params => {
        this.id = params.get('id');
        // alert(this.id);
        localStorage.setItem("courseid", this.id);
      });

      this.loadAll();
  }

  loadAll() {
    this.lessonService.getLessonByCourseId(this.id)
    .pipe(first())
    .subscribe(
      lesson => {
        this.lesson = lesson;
        console.log("lesson", this.lesson);
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      }
    );
  }

}
