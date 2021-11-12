import { Lesson_ContentService } from './../_services/lesson_conent.service';
import { Lesson_Content } from './../_models/lesson_content';
import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { AlertService } from '../_services';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({ 
    templateUrl: 'archieve_content.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class Archieve_ContentComponent implements OnInit {
    lesson_content: any;

  searchText = '';
  id!: any;

  newLesson_ContentClicked = false;

  model: any = {};
  model2: any = {};

  model3: Lesson_Content = {
    lessonConentId: 0,
      LessonContenetTypeId: 1,
      LessonOutcomeId: 0,
      ArchiveStatusId: 1,
      LessonContentDescription: '',
      LessonContent1: ''
  };


  myValue = 0;


  constructor(
    private lesson_contentService: Lesson_ContentService,
    private alertService: AlertService,

    private _Activatedroute: ActivatedRoute,
    private router: Router,
  ) {
  }

  ngOnInit() {
    this.loadAll();
  }

    loadAll() {
        this.lesson_contentService.getLesson_ContentByArchieveId(2)
            .pipe(first())
            .subscribe(
                lesson_content => {
                this.lesson_content = lesson_content;
                console.log(this.lesson_content)
                },
                error => {
                this.alertService.error('Error, Could not retrieve course lessons');
                }
            );
    }

  unarchieveLesson_Content(i) {
    let editLesson_ContentInfo = i;

    this.model3.LessonOutcomeId = this.lesson_content[editLesson_ContentInfo].lessonOutcomeId;
    this.model3.lessonConentId = this.lesson_content[editLesson_ContentInfo].lessonContentId;
    this.model3.ArchiveStatusId = 1;
    this.model3.LessonContentDescription = this.lesson_content[editLesson_ContentInfo].lessonContentDescription;
    this.model3.LessonContent1 = this.lesson_content[editLesson_ContentInfo].lessonContent1;
    
        this.lesson_contentService.update(this.model3.lessonConentId, this.model3)
          .pipe(first())
          .subscribe(
            data => {
              this.alertService.success('Lesson Content was successfully UnArchieved', true);
              this.loadAll();
              window.document.location.reload();
            },
            error => {
            
              this.alertService.error('Error, Lesson Content was unsuccesfully UnArchieved');
              this.loadAll();
            });
  }
 }