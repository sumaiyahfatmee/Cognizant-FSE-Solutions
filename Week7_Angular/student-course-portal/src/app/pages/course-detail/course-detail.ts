import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { CourseService } from '../../services/course';
import { Course } from '../../models/course.model';
import { switchMap } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { Student } from '../../models/student.model';
import { EnrollmentService } from '../../services/enrollment';

@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.css',
})
export class CourseDetail {

  course?: Course;
  students: Student[] = [];

constructor(
  private route: ActivatedRoute,
  private courseService: CourseService,
  private enrollmentService: EnrollmentService
) {

this.route.paramMap.pipe(

  map(params => params.get('id') ?? ''),

  switchMap(courseId =>
    this.courseService.getCourseById(Number(courseId))
  )

).subscribe({

  next: course => {

    this.course = course;

    // switchMap is preferred because it cancels the
    // previous inner Observable whenever a new courseId arrives.

   this.enrollmentService
  .getStudentsByCourse(course.id)
  .subscribe(students => {
    this.students = students;
  });

  }

});
  }

}